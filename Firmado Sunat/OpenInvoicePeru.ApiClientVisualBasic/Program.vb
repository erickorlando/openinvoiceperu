Imports System.Collections.ObjectModel
Imports System.IO
Imports Newtonsoft.Json
Imports OpenInvoicePeru.FirmadoSunat.Models
Imports RestSharp

Module Program

    Private ReadOnly BaseUrl As String = "http://localhost:50888/OpenInvoicePeru/api"

	Sub Main(args As String())
		Console.WriteLine("Prueba de API REST de OpenInvoicePeru (Visual Basic)")
		Dim client As New RestClient(BaseUrl)

		Dim requestInvoice As New RestRequest("invoice", Method.POST)

		Dim documento As New DocumentoElectronico() With { _
			.Emisor = New Contribuyente() With { _
				.NroDocumento = "20100070970", _
				.TipoDocumento = "6", _
				.Direccion = "CAL.MORELLI NRO. 181 INT. P-2", _
				.Urbanizacion = "-", _
				.Departamento = "LIMA", _
				.Provincia = "LIMA", _
				.Distrito = "SAN BORJA", _
				.NombreComercial = "PLAZA VEA", _
				.NombreLegal = "SUPERMERCADOS PERUANOS SOCIEDAD ANONIMA" _
			}, _
			.Receptor = New Contribuyente() With { _
				.NroDocumento = "20100039207", _
				.TipoDocumento = "6", _
				.NombreLegal = "RANSA COMERCIAL S.A." _
			}, _
            .IdDocumento = "FF11-001", _
			.FechaEmision = DateTime.Today.AddDays(-5).ToShortDateString(), _
			.Moneda = "PEN", _
			.MontoEnLetras = "SON CIENTO DIECIOCHO SOLES CON 0/100", _
			.CalculoIgv = 0.18D, _
			.CalculoIsc = 0.10D, _
			.CalculoDetraccion = 0.04D, _
			.TipoDocumento = "01", _
			.TotalIgv = 18, _
			.TotalVenta = 118, _
			.Gravadas = 100, _
			.Items = New ObservableCollection(Of DetalleDocumento)() 
		}

        documento.Items.Add(New DetalleDocumento() With { _
					.Id = 1, _
					.Cantidad = 5, _
					.PrecioReferencial = 20, _
					.PrecioUnitario = 20, _
					.TipoPrecio = "01", _
					.CodigoItem = "1234234", _
					.Descripcion = "Arroz Costeño", _
					.UnidadMedida = "KG", _
					.Impuesto = 18, _
					.TipoImpuesto = "10", _
					.TotalVenta = 100, _
					.Suma = 100 _
				})
        
		Console.WriteLine("Generando XML....")

		Dim json As Object = JsonConvert.SerializeObject(documento)
		requestInvoice.AddParameter("application/json;charset=utf-8", json, ParameterType.RequestBody)
		requestInvoice.RequestFormat = DataFormat.Json

		Dim documentoResponse As Object = client.Execute(Of DocumentoResponse)(requestInvoice)

		Console.WriteLine("Firmando XML...")
		' Firmado del Documento.
		Dim firmado As New FirmadoRequest() With { _
			.TramaXmlSinFirma = documentoResponse.Data.TramaXmlSinFirma, _
			.CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("certificado.pfx")), _
			.PasswordCertificado = String.Empty, _
			.DocumentoRetencion = False _
		}

		Dim requestFirma As New RestRequest("firmar", Method.POST) With { _
			.RequestFormat = DataFormat.Json _
		}
		requestFirma.AddBody(firmado)

		Dim responseFirma As Object = client.Execute(Of FirmadoResponse)(requestFirma)

		Console.WriteLine("Enviando a SUNAT....")

		Dim sendBill As New SendBillRequest() With { _
			.Ruc = documento.Emisor.NroDocumento, _
			.UsuarioSol = "MODDATOS", _
			.ClaveSol = "MODDATOS", _
			.EndPointUrl = "https://e-beta.sunat.gob.pe/ol-ti-itcpfegem-beta/billService", _
			.IdDocumento = documento.IdDocumento, _
			.TipoDocumento = documento.TipoDocumento, _
			.TramaXmlFirmado = responseFirma.Data.TramaXmlFirmado _
		}

		Dim requestSendBill As New RestRequest("sendbill", Method.POST) With { _
			.RequestFormat = DataFormat.Json _
		}
		requestSendBill.AddBody(sendBill)

		Dim responseSendBill As Object = client.Execute(Of SendBillResponse)(requestSendBill)

		Console.WriteLine("Respuesta de SUNAT:")
		Console.WriteLine(responseSendBill.Data.MensajeRespuesta)

		Console.ReadLine()
	End Sub

End Module

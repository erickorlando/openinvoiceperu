Option Strict On

Imports System.Collections.ObjectModel
Imports System.IO
Imports OpenInvoicePeru.FirmadoSunat.Models
Imports RestSharp

Module Program

    Private ReadOnly BaseUrl As String = "http://localhost:50888/OpenInvoicePeru/api"

	Sub Main(args As String())
		Console.WriteLine("Prueba de API REST de OpenInvoicePeru (Visual Basic)")
		
		Dim documento As New DocumentoElectronico() With {
			.Emisor = New Contribuyente() With {
				.NroDocumento = "20100070970",
				.TipoDocumento = "6",
				.Direccion = "CAL.MORELLI NRO. 181 INT. P-2",
				.Urbanizacion = "-",
				.Departamento = "LIMA",
				.Provincia = "LIMA",
				.Distrito = "SAN BORJA",
				.NombreComercial = "PLAZA VEA",
				.NombreLegal = "SUPERMERCADOS PERUANOS SOCIEDAD ANONIMA"
			},
			.Receptor = New Contribuyente() With {
				.NroDocumento = "20100039207",
				.TipoDocumento = "6",
				.NombreLegal = "RANSA COMERCIAL S.A."
			},
            .IdDocumento = "FF11-001",
			.FechaEmision = DateTime.Today.AddDays(-5).ToShortDateString(),
			.Moneda = "PEN",
			.MontoEnLetras = "SON CIENTO DIECIOCHO SOLES CON 0/100",
			.CalculoIgv = 0.18D,
			.CalculoIsc = 0.10D,
			.CalculoDetraccion = 0.04D,
			.TipoDocumento = "01",
			.TotalIgv = 18,
			.TotalVenta = 118,
			.Gravadas = 100,
			.Items = New ObservableCollection(Of DetalleDocumento)() 
		}

        documento.Items.Add(New DetalleDocumento() With {
					.Id = 1,
					.Cantidad = 5,
					.PrecioReferencial = 20,
					.PrecioUnitario = 20,
					.TipoPrecio = "01",
					.CodigoItem = "1234234",
					.Descripcion = "Arroz Costeño",
					.UnidadMedida = "KG",
					.Impuesto = 18,
					.TipoImpuesto = "10",
					.TotalVenta = 100,
					.Suma = 100
				})
        
		Console.WriteLine("Generando XML....")
        Dim client As New RestClient(BaseUrl)

		Dim requestInvoice As New RestRequest("GenerarFactura", Method.POST)
		requestInvoice.RequestFormat = DataFormat.Json
        requestInvoice.AddBody(documento)

		Dim documentoResponse = client.Execute(Of DocumentoResponse)(requestInvoice)

		Console.WriteLine("Firmando XML...")
		' Firmado del Documento.
		Dim firmado As New FirmadoRequest() With {
			.TramaXmlSinFirma = documentoResponse.Data.TramaXmlSinFirma,
			.CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("certificado.pfx")),
			.PasswordCertificado = String.Empty,
			.DocumentoRetencion = False
		}

		Dim requestFirma As New RestRequest("Firmar", Method.POST) With { 
			.RequestFormat = DataFormat.Json 
		}
		requestFirma.AddBody(firmado)

		Dim responseFirma = client.Execute(Of FirmadoResponse)(requestFirma)

		Console.WriteLine("Enviando a SUNAT....")

		Dim sendBill As New EnviarDocumentoRequest() With { 
			.Ruc = documento.Emisor.NroDocumento, 
			.UsuarioSol = "MODDATOS", 
			.ClaveSol = "MODDATOS", 
			.EndPointUrl = "https://e-beta.sunat.gob.pe/ol-ti-itcpfegem-beta/billService", 
			.IdDocumento = documento.IdDocumento, 
			.TipoDocumento = documento.TipoDocumento, 
			.TramaXmlFirmado = responseFirma.Data.TramaXmlFirmado 
		}

		Dim requestSendBill As New RestRequest("EnviarDocumento", Method.POST) With { 
			.RequestFormat = DataFormat.Json 
		}
		requestSendBill.AddBody(sendBill)

		Dim responseSendBill = client.Execute(Of EnviarDocumentoResponse)(requestSendBill)

		Console.WriteLine("Respuesta de SUNAT:")
		Console.WriteLine(responseSendBill.Data.MensajeRespuesta)

		Console.ReadLine()
	End Sub

End Module

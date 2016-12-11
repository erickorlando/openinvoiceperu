Option Strict On

Imports System.IO
Imports OpenInvoicePeru.Firmado.Models
Imports RestSharp

Module Program

    Private ReadOnly _baseUrl As String = "http://localhost:50888/OpenInvoicePeru/api"
    Private ReadOnly _urlSunat As String = "https://e-beta.sunat.gob.pe/ol-ti-itcpfegem-beta/billService"

    Private Const FormatoFecha As String = "yyyy-MM-dd"

    Private Function CrearEmisor() As Contribuyente
        Return New Contribuyente() With {
                            .NroDocumento = "20100070970",
                            .TipoDocumento = "6",
                            .Direccion = "CAL.MORELLI NRO. 181 INT. P-2",
                            .Urbanizacion = "-",
                            .Departamento = "LIMA",
                            .Provincia = "LIMA",
                            .Distrito = "SAN BORJA",
                            .NombreComercial = "PLAZA VEA",
                            .NombreLegal = "SUPERMERCADOS PERUANOS SOCIEDAD ANONIMA",
                            .Ubigeo = "140101"}
    End Function

    Sub Main(args As String())
        Console.WriteLine("Prueba de API REST de OpenInvoicePeru (Visual Basic)")
        CrearFactura()
        CrearResumenDiario()
        CrearComunicacionBaja()
        CrearDocumentoRetencion()
    End Sub

    Private Sub CrearFactura()

        Try
            Console.WriteLine("Ejemplo Factura")
            Dim documento As New DocumentoElectronico() With {
                    .Emisor = CrearEmisor(),
                    .Receptor = New Contribuyente() With {
                    .NroDocumento = "20100039207",
                    .TipoDocumento = "6",
                    .NombreLegal = "RANSA COMERCIAL S.A."
                    },
                    .IdDocumento = "FF11-002",
                    .FechaEmision = Date.Today.AddDays(-5).ToString(FormatoFecha),
                    .Moneda = "PEN",
                    .MontoEnLetras = "SON CIENTO DIECIOCHO SOLES CON 0/100",
                    .CalculoIgv = 0.18D,
                    .CalculoIsc = 0.1D,
                    .CalculoDetraccion = 0.04D,
                    .TipoDocumento = "01",
                    .TotalIgv = 18,
                    .TotalVenta = 118,
                    .Gravadas = 100,
                    .Items = New List(Of DetalleDocumento)()
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
            Dim client As New RestClient(_baseUrl)

            Dim requestInvoice As New RestRequest("GenerarFactura", Method.POST)
            requestInvoice.RequestFormat = DataFormat.Json
            requestInvoice.AddBody(documento)

            Dim documentoResponse = client.Execute(Of DocumentoResponse)(requestInvoice)

            If Not documentoResponse.Data.Exito Then
                Throw New ApplicationException(documentoResponse.Data.MensajeError)
            End If


            Console.WriteLine("Firmando XML...")
            ' Firmado del Documento.
            Dim firmado As New FirmadoRequest() With {
                    .TramaXmlSinFirma = documentoResponse.Data.TramaXmlSinFirma,
                    .CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("certificado.pfx")),
                    .PasswordCertificado = String.Empty,
                    .UnSoloNodoExtension = False
                    }

            Dim requestFirma As New RestRequest("Firmar", Method.POST) With {
                    .RequestFormat = DataFormat.Json
                    }
            requestFirma.AddBody(firmado)

            Dim responseFirma = client.Execute(Of FirmadoResponse)(requestFirma)

            If Not responseFirma.Data.Exito Then
                Throw New ApplicationException(responseFirma.Data.MensajeError)
            End If

            Console.WriteLine("Enviando a SUNAT....")

            Dim sendBill As New EnviarDocumentoRequest() With {
                    .Ruc = documento.Emisor.NroDocumento,
                    .UsuarioSol = "MODDATOS",
                    .ClaveSol = "MODDATOS",
                    .EndPointUrl = _urlSunat,
                    .IdDocumento = documento.IdDocumento,
                    .TipoDocumento = documento.TipoDocumento,
                    .TramaXmlFirmado = responseFirma.Data.TramaXmlFirmado
                    }

            Dim restRequest As New RestRequest("EnviarDocumento", Method.POST) With {
                    .RequestFormat = DataFormat.Json
                    }
            restRequest.AddBody(sendBill)

            Dim restResponse = client.Execute(Of EnviarDocumentoResponse)(restRequest)

            If Not restResponse.Data.Exito Then
                Throw New ApplicationException(restResponse.Data.MensajeError)
            End If

            Console.WriteLine("Respuesta de SUNAT:")
            Console.WriteLine(restResponse.Data.MensajeRespuesta)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally
            Console.ReadLine()
        End Try
    End Sub

    Private Sub CrearResumenDiario()
        Try
            Console.WriteLine("Ejemplo de Resumen Diario")
            Dim documentoResumenDiario As New ResumenDiario() With {
                .IdDocumento = String.Format("RC-{0:yyyyMMdd}-001", Date.Today),
                .FechaEmision = Date.Today.ToString(FormatoFecha),
                .FechaReferencia = Date.Today.AddDays(-1).ToString(FormatoFecha),
                .Emisor = CrearEmisor(),
                .Resumenes = New List(Of GrupoResumen)
            }

            documentoResumenDiario.Resumenes.Add(New GrupoResumen() With {
                .Id = 1,
                .CorrelativoInicio = 33386,
                .CorrelativoFin = 33390,
                .Moneda = "PEN",
                .TotalVenta = 190.9D,
                .TotalIgv = 29.12D,
                .Gravadas = 161.78D,
                .Exoneradas = 0,
                .Exportacion = 0,
                .TipoDocumento = "03",
                .Serie = "BB50"})
            documentoResumenDiario.Resumenes.Add(New GrupoResumen() With {
                .Id = 2,
                .CorrelativoInicio = 40000,
                .CorrelativoFin = 40500,
                .Moneda = "PEN",
                .TotalVenta = 9580D,
                .TotalIgv = 1411.36D,
                .Gravadas = 8168.64D,
                .Exoneradas = 0,
                .Exportacion = 0,
                .TipoDocumento = "03",
                .Serie = "BB30"})


            Console.WriteLine("Generando XML....")
            Dim client As New RestClient(_baseUrl)
            Dim requestInvoice As New RestRequest("GenerarResumenDiario", Method.POST)
            requestInvoice.RequestFormat = DataFormat.Json
            requestInvoice.AddBody(documentoResumenDiario)
            Dim documentoResponse = client.Execute(Of DocumentoResponse)(requestInvoice)
            If Not documentoResponse.Data.Exito Then
                Throw New ApplicationException(documentoResponse.Data.MensajeError)
            End If
            Console.WriteLine("Firmando XML...")
            ' Firmado del Documento.
            Dim firmado As New FirmadoRequest() With {
                .TramaXmlSinFirma = documentoResponse.Data.TramaXmlSinFirma,
                .CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("Certificado.pfx")),
                .PasswordCertificado = String.Empty,
                .UnSoloNodoExtension = True
            }

            Dim requestFirma As New RestRequest("Firmar", Method.POST) With {
            .RequestFormat = DataFormat.Json}
            requestFirma.AddBody(firmado)

            Dim responseFirma = client.Execute(Of FirmadoResponse)(requestFirma)

            If Not responseFirma.Data.Exito Then
                Throw New ApplicationException(responseFirma.Data.MensajeError)
            End If

            Console.WriteLine("Enviando a SUNAT....")

            Dim sendBill As New EnviarDocumentoRequest() With {
                .Ruc = documentoResumenDiario.Emisor.NroDocumento,
                .UsuarioSol = "MODDATOS",
                .ClaveSol = "MODDATOS",
                .EndPointUrl = _urlSunat,
                .IdDocumento = documentoResumenDiario.IdDocumento,
                .TramaXmlFirmado = responseFirma.Data.TramaXmlFirmado
            }

            Dim requestSendBill As New RestRequest("EnviarResumen", Method.POST) With {
                .RequestFormat = DataFormat.Json
            }

            requestSendBill.AddBody(sendBill)

            Dim responseSendBill = client.Execute(Of EnviarResumenResponse)(requestSendBill)

            If Not responseSendBill.Data.Exito Then
                Throw New ApplicationException(responseSendBill.Data.MensajeError)
            Else
                Console.WriteLine("Nro de Ticket: {0}", responseSendBill.Data.NroTicket)
            End If

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally
            Console.ReadLine()
        End Try
    End Sub

    Private Sub CrearComunicacionBaja()
        Try
            Console.WriteLine("Ejemplo de Comunicación de Baja")
            Dim documentoBaja As New ComunicacionBaja() With {
                .IdDocumento = String.Format("RA-{0:yyyyMMdd}-001", Date.Today),
                .FechaEmision = Date.Today.ToString(FormatoFecha),
                .FechaReferencia = Date.Today.AddDays(-1).ToString(FormatoFecha),
                .Emisor = CrearEmisor(),
                .Bajas = New List(Of DocumentoBaja)()
            }

            documentoBaja.Bajas.Add(New DocumentoBaja() With {
                .Id = 1,
                .Correlativo = "33386",
                .TipoDocumento = "03",
                .Serie = "BB50",
                .MotivoBaja = "Anulación por otro tipo de documento"})

            documentoBaja.Bajas.Add(New DocumentoBaja() With {
                .Id = 2,
                .Correlativo = "86486",
                .TipoDocumento = "01",
                .Serie = "FF14",
                .MotivoBaja = "Anulación por otro datos erroneos"})

            Console.WriteLine("Generando XML....")
            Dim client As New RestClient(_baseUrl)
            Dim requestInvoice As New RestRequest("GenerarComunicacionBaja", Method.POST)
            requestInvoice.RequestFormat = DataFormat.Json
            requestInvoice.AddBody(documentoBaja)
            Dim documentoResponse = client.Execute(Of DocumentoResponse)(requestInvoice)
            If Not documentoResponse.Data.Exito Then
                Throw New ApplicationException(documentoResponse.Data.MensajeError)
            End If
            Console.WriteLine("Firmando XML...")
            ' Firmado del Documento.
            Dim firmado As New FirmadoRequest() With {
                .TramaXmlSinFirma = documentoResponse.Data.TramaXmlSinFirma,
                .CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("Certificado.pfx")),
                .PasswordCertificado = String.Empty,
                .UnSoloNodoExtension = True
            }

            Dim requestFirma As New RestRequest("Firmar", Method.POST) With {
            .RequestFormat = DataFormat.Json}
            requestFirma.AddBody(firmado)

            Dim responseFirma = client.Execute(Of FirmadoResponse)(requestFirma)

            If Not responseFirma.Data.Exito Then
                Throw New ApplicationException(responseFirma.Data.MensajeError)
            End If

            Console.WriteLine("Enviando a SUNAT....")

            Dim sendBill As New EnviarDocumentoRequest() With {
                .Ruc = documentoBaja.Emisor.NroDocumento,
                .UsuarioSol = "MODDATOS",
                .ClaveSol = "MODDATOS",
                .EndPointUrl = _urlSunat,
                .IdDocumento = documentoBaja.IdDocumento,
                .TramaXmlFirmado = responseFirma.Data.TramaXmlFirmado
            }

            Dim requestSendBill As New RestRequest("EnviarResumen", Method.POST) With {
                .RequestFormat = DataFormat.Json
            }

            requestSendBill.AddBody(sendBill)

            Dim responseSendBill = client.Execute(Of EnviarResumenResponse)(requestSendBill)

            If Not responseSendBill.Data.Exito Then
                Throw New ApplicationException(responseSendBill.Data.MensajeError)
            Else
                Console.WriteLine("Nro de Ticket: {0}", responseSendBill.Data.NroTicket)
            End If

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally
            Console.ReadLine()
        End Try
    End Sub

    Private Sub CrearDocumentoRetencion()
        Try
            Console.WriteLine("Ejemplo de Retención")
            Dim documento As New DocumentoRetencion() With {.Emisor = CrearEmisor(),
                .Receptor = New Contribuyente With
                {
                    .NroDocumento = "20100039207",
                    .TipoDocumento = "6",
                    .NombreLegal = "RANSA COMERCIAL S.A.",
                    .Ubigeo = "150101",
                    .Direccion = "Av. Argentina 2833",
                    .Urbanizacion = "-",
                    .Departamento = "CALLAO",
                    .Provincia = "CALLAO",
                    .Distrito = "CALLAO"
                },
                .IdDocumento = "R001-123",
                .FechaEmision = Date.Today.ToString(FormatoFecha),
                .Moneda = "PEN",
                .RegimenRetencion = "01",
                .TasaRetencion = 3,
                .ImporteTotalRetenido = 300,
                .ImporteTotalPagado = 10000,
                .Observaciones = "Emision de Facturas del periodo Dic. 2016",
                .DocumentosRelacionados = New List(Of ItemRetencion)()}

            documento.DocumentosRelacionados.Add(New ItemRetencion() With {
                            .NroDocumento = "E001-457",
                            .TipoDocumento = "01",
                            .MonedaDocumentoRelacionado = "USD",
                            .FechaEmision = Date.Today.AddDays(-3).ToString(FormatoFecha),
                            .ImporteTotal = 10000,
                            .FechaPago = Date.Today.ToString(FormatoFecha),
                            .NumeroPago = 153,
                            .ImporteSinRetencion = 9700,
                            .ImporteRetenido = 300,
                            .FechaRetencion = Date.Today.ToString(FormatoFecha),
                            .ImporteTotalNeto = 10000,
                            .TipoCambio = 3.41D,
                            .FechaTipoCambio = Date.Today.ToString(FormatoFecha)
                        })

            Console.WriteLine("Generando XML....")

            Dim client = New RestClient(_baseUrl)

            Dim requestRetencion = New RestRequest("GenerarRetencion", Method.POST) With {
                .RequestFormat = DataFormat.Json
            }

            requestRetencion.AddBody(documento)

            Dim documentoResponse = client.Execute(Of DocumentoResponse)(requestRetencion)

            If Not documentoResponse.Data.Exito Then
                Throw New ApplicationException(documentoResponse.Data.MensajeError)
            End If

            Console.WriteLine("Firmando XML...")
            ' Firmado del Documento.
            Dim firmado As New FirmadoRequest() With {
               .TramaXmlSinFirma = documentoResponse.Data.TramaXmlSinFirma,
               .CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("certificado.pfx")),
               .PasswordCertificado = String.Empty,
               .UnSoloNodoExtension = True
               }

            Dim requestFirma As New RestRequest("Firmar", Method.POST) With {
               .RequestFormat = DataFormat.Json
               }
            requestFirma.AddBody(firmado)

            Dim responseFirma = client.Execute(Of FirmadoResponse)(requestFirma)

            If Not responseFirma.Data.Exito Then
                Throw New ApplicationException(responseFirma.Data.MensajeError)
            End If

            Console.WriteLine("Enviando Retención a SUNAT....")

            Dim sendBill = New EnviarDocumentoRequest With {
                .Ruc = documento.Emisor.NroDocumento,
                .UsuarioSol = "MODDATOS",
                .ClaveSol = "MODDATOS",
                .EndPointUrl = "https://e-beta.sunat.gob.pe/ol-ti-itemision-otroscpe-gem-beta/billService",
                .IdDocumento = documento.IdDocumento,
                .TipoDocumento = "20",
                .TramaXmlFirmado = responseFirma.Data.TramaXmlFirmado
            }

            Dim restRequest As New RestRequest("EnviarDocumento", Method.POST) With {
                 .RequestFormat = DataFormat.Json
                 }
            restRequest.AddBody(sendBill)

            Dim restResponse = client.Execute(Of EnviarDocumentoResponse)(restRequest)

            If Not restResponse.Data.Exito Then
                Throw New ApplicationException(restResponse.Data.MensajeError)
            End If

            Console.WriteLine("Respuesta de SUNAT:")
            Console.WriteLine(restResponse.Data.MensajeRespuesta)

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally
            Console.ReadLine()
        End Try
    End Sub

End Module

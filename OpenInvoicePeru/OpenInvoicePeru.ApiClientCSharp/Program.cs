using System;
using System.Collections.Generic;
using System.IO;
using OpenInvoicePeru.Firmado.Models;
using RestSharp;

namespace OpenInvoicePeru.ApiClientCSharp
{
    class Program
    {
        private static readonly string BaseUrl = "http://localhost:50888/OpenInvoicePeru/api";
        private static readonly string UrlSunat = "https://e-beta.sunat.gob.pe/ol-ti-itcpfegem-beta/billService";

        private const string FormatoFecha = "yyyy-MM-dd";

        static void Main()
        {
            Console.WriteLine("Prueba de API REST de OpenInvoicePeru (C#)");
            CrearFactura();
            CrearResumenDiario();
            CrearComunicacionBaja();
            CrearDocumentoRetencion();
        }

        private static Contribuyente CrearEmisor()
        {
            return new Contribuyente
            {
                NroDocumento = "20100070970",
                TipoDocumento = "6",
                Direccion = "CAL.MORELLI NRO. 181 INT. P-2",
                Urbanizacion = "-",
                Departamento = "LIMA",
                Provincia = "LIMA",
                Distrito = "SAN BORJA",
                NombreComercial = "PLAZA VEA",
                NombreLegal = "SUPERMERCADOS PERUANOS SOCIEDAD ANONIMA",
                Ubigeo = "140101"
            };
        }

        private static void CrearFactura()
        {
            try
            {
                Console.WriteLine("Ejemplo Factura");
                var documento = new DocumentoElectronico
                {
                    Emisor = CrearEmisor(),
                    Receptor = new Contribuyente
                    {
                        NroDocumento = "20100039207",
                        TipoDocumento = "6",
                        NombreLegal = "RANSA COMERCIAL S.A."
                    },
                    IdDocumento = "FF11-001",
                    FechaEmision = DateTime.Today.AddDays(-5).ToString(FormatoFecha),
                    Moneda = "PEN",
                    MontoEnLetras = "SON CIENTO DIECIOCHO SOLES CON 0/100",
                    CalculoIgv = 0.18m,
                    CalculoIsc = 0.10m,
                    CalculoDetraccion = 0.04m,
                    TipoDocumento = "01",
                    TotalIgv = 18,
                    TotalVenta = 118,
                    Gravadas = 100,
                    Items = new List<DetalleDocumento>
                    {
                        new DetalleDocumento
                        {
                            Id = 1,
                            Cantidad = 5,
                            PrecioReferencial = 20,
                            PrecioUnitario = 20,
                            TipoPrecio = "01",
                            CodigoItem = "1234234",
                            Descripcion = "Arroz Costeño",
                            UnidadMedida = "KG",
                            Impuesto = 18,
                            TipoImpuesto = "10", // Gravada
                            TotalVenta = 100,
                            Suma = 100
                        }
                    }
                };

                Console.WriteLine("Generando XML....");

                var client = new RestClient(BaseUrl);

                var requestInvoice = new RestRequest("GenerarFactura", Method.POST)
                {
                    RequestFormat = DataFormat.Json
                };

                requestInvoice.AddBody(documento);

                var documentoResponse = client.Execute<DocumentoResponse>(requestInvoice);

                if (!documentoResponse.Data.Exito)
                {
                    throw new ApplicationException(documentoResponse.Data.MensajeError);
                }

                Console.WriteLine("Firmando XML...");
                // Firmado del Documento.
                var firmado = new FirmadoRequest
                {
                    TramaXmlSinFirma = documentoResponse.Data.TramaXmlSinFirma,
                    CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("certificado.pfx")),
                    PasswordCertificado = string.Empty,
                    UnSoloNodoExtension = false
                };

                var requestFirma = new RestRequest("Firmar", Method.POST)
                {
                    RequestFormat = DataFormat.Json
                };
                requestFirma.AddBody(firmado);

                var responseFirma = client.Execute<FirmadoResponse>(requestFirma);

                if (!responseFirma.Data.Exito)
                {
                    throw new ApplicationException(responseFirma.Data.MensajeError);
                }

                Console.WriteLine("Enviando a SUNAT....");

                var sendBill = new EnviarDocumentoRequest
                {
                    Ruc = documento.Emisor.NroDocumento,
                    UsuarioSol = "MODDATOS",
                    ClaveSol = "MODDATOS",
                    EndPointUrl = UrlSunat,
                    IdDocumento = documento.IdDocumento,
                    TipoDocumento = documento.TipoDocumento,
                    TramaXmlFirmado = responseFirma.Data.TramaXmlFirmado
                };

                var requestSendBill = new RestRequest("EnviarDocumento", Method.POST)
                {
                    RequestFormat = DataFormat.Json
                };
                requestSendBill.AddBody(sendBill);

                var responseSendBill = client.Execute<EnviarDocumentoResponse>(requestSendBill);

                if (!responseSendBill.Data.Exito)
                {
                    throw new ApplicationException(responseSendBill.Data.MensajeError);
                }

                Console.WriteLine("Respuesta de SUNAT:");
                Console.WriteLine(responseSendBill.Data.MensajeRespuesta);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        private static void CrearResumenDiario()
        {
            try
            {
                Console.WriteLine("Ejemplo de Resumen Diario");
                var documentoResumenDiario = new ResumenDiario
                {
                    IdDocumento = string.Format("RC-{0:yyyyMMdd}-001", DateTime.Today),
                    FechaEmision = DateTime.Today.ToString(FormatoFecha),
                    FechaReferencia = DateTime.Today.AddDays(-1).ToString(FormatoFecha),
                    Emisor = CrearEmisor(),
                    Resumenes = new List<GrupoResumen>()
                };

                documentoResumenDiario.Resumenes.Add(new GrupoResumen
                {
                    Id = 1,
                    CorrelativoInicio = 33386,
                    CorrelativoFin = 33390,
                    Moneda = "PEN",
                    TotalVenta = 190.9m,
                    TotalIgv = 29.12m,
                    Gravadas = 161.78m,
                    Exoneradas = 0,
                    Exportacion = 0,
                    TipoDocumento = "03",
                    Serie = "BB50"
                });
                documentoResumenDiario.Resumenes.Add(new GrupoResumen
                {
                    Id = 2,
                    CorrelativoInicio = 40000,
                    CorrelativoFin = 40500,
                    Moneda = "PEN",
                    TotalVenta = 9580m,
                    TotalIgv = 1411.36m,
                    Gravadas = 8168.64m,
                    Exoneradas = 0,
                    Exportacion = 0,
                    TipoDocumento = "03",
                    Serie = "BB30"
                });


                Console.WriteLine("Generando XML....");
                var client = new RestClient(BaseUrl);
                var requestInvoice = new RestRequest("GenerarResumenDiario", Method.POST)
                {
                    RequestFormat = DataFormat.Json
                };
                requestInvoice.AddBody(documentoResumenDiario);
                var documentoResponse = client.Execute<DocumentoResponse>(requestInvoice);
                if (!documentoResponse.Data.Exito)
                {
                    throw new ApplicationException(documentoResponse.Data.MensajeError);
                }
                Console.WriteLine("Firmando XML...");
                // Firmado del Documento.
                var firmado = new FirmadoRequest
                {
                    TramaXmlSinFirma = documentoResponse.Data.TramaXmlSinFirma,
                    CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("Certificado.pfx")),
                    PasswordCertificado = string.Empty,
                    UnSoloNodoExtension = true
                };

                var requestFirma = new RestRequest("Firmar", Method.POST) { RequestFormat = DataFormat.Json };
                requestFirma.AddBody(firmado);

                var responseFirma = client.Execute<FirmadoResponse>(requestFirma);

                if (!responseFirma.Data.Exito)
                {
                    throw new ApplicationException(responseFirma.Data.MensajeError);
                }

                Console.WriteLine("Enviando a SUNAT....");

                var sendBill = new EnviarDocumentoRequest
                {
                    Ruc = documentoResumenDiario.Emisor.NroDocumento,
                    UsuarioSol = "MODDATOS",
                    ClaveSol = "MODDATOS",
                    EndPointUrl = UrlSunat,
                    IdDocumento = documentoResumenDiario.IdDocumento,
                    TramaXmlFirmado = responseFirma.Data.TramaXmlFirmado
                };

                var restRequest = new RestRequest("EnviarResumen", Method.POST) { RequestFormat = DataFormat.Json };

                restRequest.AddBody(sendBill);

                var restResponse = client.Execute<EnviarResumenResponse>(restRequest);

                if (!restResponse.Data.Exito)
                {
                    throw new ApplicationException(restResponse.Data.MensajeError);
                }

                Console.WriteLine("Nro de Ticket: {0}", restResponse.Data.NroTicket);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        private static void CrearComunicacionBaja()
        {
            try
            {
                Console.WriteLine("Ejemplo de Comunicación de Baja");
                var documentoBaja = new ComunicacionBaja
                {
                    IdDocumento = string.Format("RA-{0:yyyyMMdd}-001", DateTime.Today),
                    FechaEmision = DateTime.Today.ToString(FormatoFecha),
                    FechaReferencia = DateTime.Today.AddDays(-1).ToString(FormatoFecha),
                    Emisor = CrearEmisor(),
                    Bajas = new List<DocumentoBaja>()
                };

                documentoBaja.Bajas.Add(new DocumentoBaja
                {
                    Id = 1,
                    Correlativo = "33386",
                    TipoDocumento = "03",
                    Serie = "BB50",
                    MotivoBaja = "Anulación por otro tipo de documento"
                });
                documentoBaja.Bajas.Add(new DocumentoBaja
                {
                    Id = 2,
                    Correlativo = "86486",
                    TipoDocumento = "01",
                    Serie = "FF14",
                    MotivoBaja = "Anulación por otro datos erroneos"
                });

                Console.WriteLine("Generando XML....");
                var client = new RestClient(BaseUrl);
                var requestInvoice = new RestRequest("GenerarComunicacionBaja", Method.POST)
                {
                    RequestFormat = DataFormat.Json
                };
                requestInvoice.AddBody(documentoBaja);
                var documentoResponse = client.Execute<DocumentoResponse>(requestInvoice);
                if (!documentoResponse.Data.Exito)
                {
                    throw new ApplicationException(documentoResponse.Data.MensajeError);
                }
                Console.WriteLine("Firmando XML...");
                // Firmado del Documento.
                var firmado = new FirmadoRequest
                {
                    TramaXmlSinFirma = documentoResponse.Data.TramaXmlSinFirma,
                    CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("Certificado.pfx")),
                    PasswordCertificado = string.Empty,
                    UnSoloNodoExtension = true
                };

                var requestFirma = new RestRequest("Firmar", Method.POST) { RequestFormat = DataFormat.Json };
                requestFirma.AddBody(firmado);

                var responseFirma = client.Execute<FirmadoResponse>(requestFirma);

                if (!responseFirma.Data.Exito)
                {
                    throw new ApplicationException(responseFirma.Data.MensajeError);
                }

                Console.WriteLine("Enviando a SUNAT....");

                var sendBill = new EnviarDocumentoRequest
                {
                    Ruc = documentoBaja.Emisor.NroDocumento,
                    UsuarioSol = "MODDATOS",
                    ClaveSol = "MODDATOS",
                    EndPointUrl = UrlSunat,
                    IdDocumento = documentoBaja.IdDocumento,
                    TramaXmlFirmado = responseFirma.Data.TramaXmlFirmado
                };

                var restRequest = new RestRequest("EnviarResumen", Method.POST) { RequestFormat = DataFormat.Json };

                restRequest.AddBody(sendBill);

                var restResponse = client.Execute<EnviarResumenResponse>(restRequest);

                if (!restResponse.Data.Exito)
                {
                    throw new ApplicationException(restResponse.Data.MensajeError);
                }

                Console.WriteLine("Nro de Ticket: {0}", restResponse.Data.NroTicket);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        private static void CrearDocumentoRetencion()
        {
            try
            {
                Console.WriteLine("Ejemplo de Retención");
                var documento = new DocumentoRetencion
                {
                    Emisor = CrearEmisor(),
                    Receptor = new Contribuyente
                    {
                        NroDocumento = "20100039207",
                        TipoDocumento = "6",
                        NombreLegal = "RANSA COMERCIAL S.A.",
                        Ubigeo = "150101",
                        Direccion = "Av. Argentina 2833",
                        Urbanizacion = "-",
                        Departamento = "CALLAO",
                        Provincia = "CALLAO",
                        Distrito = "CALLAO"
                    },
                    IdDocumento = "R001-123",
                    FechaEmision = DateTime.Today.ToString(FormatoFecha),
                    Moneda = "PEN",
                    RegimenRetencion = "01",
                    TasaRetencion = 3,
                    ImporteTotalRetenido = 300,
                    ImporteTotalPagado = 10000,
                    Observaciones = "Emision de Facturas del periodo Dic. 2016",
                    DocumentosRelacionados = new List<ItemRetencion>
                    {
                        new ItemRetencion
                        {
                            NroDocumento = "E001-457",
                            TipoDocumento = "01",
                            MonedaDocumentoRelacionado = "USD",
                            FechaEmision = DateTime.Today.AddDays(-3).ToString(FormatoFecha),
                            ImporteTotal = 10000,
                            FechaPago = DateTime.Today.ToString(FormatoFecha),
                            NumeroPago = 153,
                            ImporteSinRetencion = 9700,
                            ImporteRetenido = 300,
                            FechaRetencion = DateTime.Today.ToString(FormatoFecha),
                            ImporteTotalNeto = 10000,
                            TipoCambio = 3.41m,
                            FechaTipoCambio = DateTime.Today.ToString(FormatoFecha)
                        }
                    }
                };

                Console.WriteLine("Generando XML....");

                var client = new RestClient(BaseUrl);

                var requestRetencion = new RestRequest("GenerarRetencion", Method.POST)
                {
                    RequestFormat = DataFormat.Json
                };

                requestRetencion.AddBody(documento);

                var documentoResponse = client.Execute<DocumentoResponse>(requestRetencion);

                if (!documentoResponse.Data.Exito)
                {
                    throw new ApplicationException(documentoResponse.Data.MensajeError);
                }

                Console.WriteLine("Firmando XML...");
                // Firmado del Documento.
                var firmado = new FirmadoRequest
                {
                    TramaXmlSinFirma = documentoResponse.Data.TramaXmlSinFirma,
                    CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("certificado.pfx")),
                    PasswordCertificado = string.Empty,
                    UnSoloNodoExtension = true
                };

                var requestFirma = new RestRequest("Firmar", Method.POST)
                {
                    RequestFormat = DataFormat.Json
                };
                requestFirma.AddBody(firmado);

                var responseFirma = client.Execute<FirmadoResponse>(requestFirma);

                if (!responseFirma.Data.Exito)
                {
                    throw new ApplicationException(responseFirma.Data.MensajeError);
                }

                Console.WriteLine("Enviando Retención a SUNAT....");

                var sendBill = new EnviarDocumentoRequest
                {
                    Ruc = documento.Emisor.NroDocumento,
                    UsuarioSol = "MODDATOS",
                    ClaveSol = "MODDATOS",
                    EndPointUrl = "https://e-beta.sunat.gob.pe/ol-ti-itemision-otroscpe-gem-beta/billService",
                    IdDocumento = documento.IdDocumento,
                    TipoDocumento = "20",
                    TramaXmlFirmado = responseFirma.Data.TramaXmlFirmado
                };

                var requestSendBill = new RestRequest("EnviarDocumento", Method.POST)
                {
                    RequestFormat = DataFormat.Json
                };
                requestSendBill.AddBody(sendBill);

                var responseSendBill = client.Execute<EnviarDocumentoResponse>(requestSendBill);

                if (!responseSendBill.Data.Exito)
                {
                    throw new ApplicationException(responseSendBill.Data.MensajeError);
                }

                Console.WriteLine("Respuesta de SUNAT:");
                Console.WriteLine(responseSendBill.Data.MensajeRespuesta);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}

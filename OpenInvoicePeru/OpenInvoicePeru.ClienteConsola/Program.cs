using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using OpenInvoicePeru.Comun.Dto.Intercambio;
using OpenInvoicePeru.Comun.Dto.Modelos;

namespace OpenInvoicePeru.ClienteConsola
{
    class Program
    {
        private const string UrlSunat = "https://e-beta.sunat.gob.pe/ol-ti-itcpfegem-beta/billService";
        private const string UrlOtroCpe = "https://e-beta.sunat.gob.pe/ol-ti-itemision-otroscpe-gem-beta/billService";
        private const string UrlGuiaRemision = "https://e-beta.sunat.gob.pe/ol-ti-itemision-guia-gem-beta/billService";
        private const string FormatoFecha = "yyyy-MM-dd";

        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Title = "OpenInvoicePeru - Prueba de Envio de Documentos Electrónicos con UBL 2.1";

            CrearFactura();
            //CrearFacturaConExonerado();
            //CrearFacturaConPlaca();
            //CrearFacturaConDetraccion();
            //CrearBoleta();
            //CrearNotaCredito();
            //CrearNotaDebito();
            //CrearResumenDiario();
            //CrearComunicacionBaja();
            //CrearDocumentoRetencion();
            //CrearDocumentoPercepcion();
            //CrearGuiaRemision();
        }

        private static Compania CrearEmisor()
        {
            return new Compania
            {
                NroDocumento = "20257471609",
                TipoDocumento = "6",
                NombreComercial = "FRAMEWORK PERU",
                NombreLegal = "EMPRESA DE SOFTWARE S.A.C.",
                CodigoAnexo = "0001"
            };
        }

        private static Negocio ToNegocio(Compania compania)
        {
            return new Negocio
            {
                NroDocumento = compania.NroDocumento,
                TipoDocumento = compania.TipoDocumento,
                NombreComercial = compania.NombreComercial,
                NombreLegal = compania.NombreLegal,
                Distrito = "LIMA",
                Provincia = "LIMA",
                Departamento = "LIMA",
                Direccion = "AV. LIMA 123",
                Ubigeo = "150101"
            };
        }

        private static void CrearFactura()
        {
            try
            {
                Console.WriteLine("Ejemplo Factura");
                //var documento = new DocumentoElectronico
                //{
                //    Emisor = CrearEmisor(),
                //    Receptor = new Compania
                //    {
                //        NroDocumento = "20100039207",
                //        TipoDocumento = "6",
                //        NombreLegal = "RANSA COMERCIAL S.A."
                //    },
                //    IdDocumento = "FF11-001",
                //    FechaEmision = DateTime.Today.AddDays(-5).ToString(FormatoFecha),
                //    HoraEmision = DateTime.Now.ToString("HH:mm:ss"),
                //    Moneda = "PEN",
                //    TipoDocumento = "01",
                //    TotalIgv = 18,
                //    TotalVenta = 118,
                //    Gravadas = 100,
                //    Items = new List<DetalleDocumento>
                //    {
                //        new DetalleDocumento
                //        {
                //            Id = 1,
                //            Cantidad = 5,
                //            PrecioReferencial = 20,
                //            PrecioUnitario = 20,
                //            TipoPrecio = "01",
                //            CodigoItem = "1234234",
                //            Descripcion = "Arroz Costeño",
                //            UnidadMedida = "KG",
                //            Impuesto = 18,
                //            TipoImpuesto = "10", // Gravada
                //            TotalVenta = 100,
                //        }
                //    }
                //};

                var documento = JsonConvert.DeserializeObject<DocumentoElectronico>("{\"IdDocumento\":\"FM01-00001519\",\"TipoDocumento\":\"01\",\"Emisor\":{\"NroDocumento\":\"20167795120\",\"TipoDocumento\":\"6\",\"NombreLegal\":\"INVERSIONES ANCONA S.A.C\",\"NombreComercial\":\"INVERSIONES ANCONA\",\"CodigoAnexo\":\"0000\"},\"Receptor\":{\"NroDocumento\":\"20544705688\",\"TipoDocumento\":\"6\",\"NombreLegal\":\"INVERSIONES EDUCA S.A.\",\"CodigoAnexo\":\"0000\"},\"FechaEmision\":\"2018-10-09\",\"HoraEmision\":\"11:57:02\",\"Moneda\":\"PEN\",\"TipoOperacion\":\"0101\",\"MontoEnLetras\":\"-\",\"Gravadas\":0,\"Gratuitas\":120,\"Inafectas\":0,\"Exoneradas\":0,\"DescuentoGlobal\":0,\"Items\":[{\"Id\":1,\"Cantidad\":10,\"UnidadMedida\":\"NIU\",\"CodigoItem\":\"4X40K09936\",\"Descripcion\":\"LENOVO ESSENTIAL BACK PACK\",\"PrecioUnitario\":0,\"PrecioReferencial\":12,\"TipoPrecio\":\"01\",\"TipoImpuesto\":\"21\",\"Impuesto\":0,\"ImpuestoSelectivo\":0,\"OtroImpuesto\":0,\"Descuento\":0,\"TotalVenta\":0}],\"TotalVenta\":0,\"TotalIgv\":0,\"TotalIsc\":0,\"TotalOtrosTributos\":0,\"Leyendas\":[{\"Codigo\":\"1002\",\"Descripcion\":\"TRANSFERENCIA GRATUITA DE UN BIEN Y/O SERVICIO PRESTADO GRATUITAMENTE\"}]}");

                FirmaryEnviar(documento, GenerarDocumento(documento));
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
        
        private static void CrearFacturaConExonerado()
        {
            try
            {
                Console.WriteLine("Ejemplo Factura");
                var documento = new DocumentoElectronico
                {
                    Emisor = CrearEmisor(),
                    Receptor = new Compania
                    {
                        NroDocumento = "20100039207",
                        TipoDocumento = "6",
                        NombreLegal = "RANSA COMERCIAL S.A."
                    },
                    IdDocumento = "FF11-002",
                    FechaEmision = DateTime.Today.ToString(FormatoFecha),
                    HoraEmision = DateTime.Now.ToString("HH:mm:ss"),
                    Moneda = "PEN",
                    TipoDocumento = "01",
                    TotalIgv = 0,
                    TotalVenta = 100,
                    Exoneradas = 100,
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
                            UnidadMedida = "KGM",
                            Impuesto = 0,
                            TipoImpuesto = "20", // Exonerado
                            TotalVenta = 100,
                        }
                    }
                };

                FirmaryEnviar(documento, GenerarDocumento(documento));
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

        private static void CrearFacturaConPlaca()
        {
            try
            {
                Console.WriteLine("Ejemplo Factura con Placa Vehicular");
                var documento = new DocumentoElectronico
                {
                    Emisor = CrearEmisor(),
                    Receptor = new Compania
                    {
                        NroDocumento = "20100039207",
                        TipoDocumento = "6",
                        NombreLegal = "RANSA COMERCIAL S.A."
                    },
                    IdDocumento = "FF13-001",
                    FechaEmision = DateTime.Today.AddDays(-5).ToString(FormatoFecha),
                    HoraEmision = DateTime.Now.ToString("HH:mm:ss"),
                    Moneda = "PEN",
                    TipoDocumento = "01",
                    TotalIgv = 16.8m,
                    TotalVenta = 76.8m,
                    Gravadas = 60,
                    Items = new List<DetalleDocumento>
                    {
                        new DetalleDocumento
                        {
                            Id = 1,
                            Cantidad = 15,
                            PrecioReferencial = 4,
                            PrecioUnitario = 4,
                            TipoPrecio = "01",
                            CodigoItem = "GAS-01",
                            Descripcion = "GASOLINA 95",
                            UnidadMedida = "GLI",
                            Impuesto = 10.8m,
                            TipoImpuesto = "10", // Gravada
                            TotalVenta = 60,
                            PlacaVehiculo = "YG-9244"
                        }
                    }
                };

                FirmaryEnviar(documento, GenerarDocumento(documento));
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

        private static void CrearFacturaConDetraccion()
        {
            try
            {
                Console.WriteLine("Ejemplo Factura con Detracción");
                var documento = new DocumentoElectronico
                {
                    Emisor = CrearEmisor(),
                    Receptor = new Compania
                    {
                        NroDocumento = "20565211600",
                        TipoDocumento = "6",
                        NombreLegal = "WASPE PERU S.A.C."
                    },
                    IdDocumento = "FF12-500",
                    FechaEmision = DateTime.Today.ToString(FormatoFecha),
                    HoraEmision = DateTime.Now.ToString("HH:mm:ss"),
                    FechaVencimiento = DateTime.Today.AddDays(3).ToString(FormatoFecha),
                    Moneda = "PEN",
                    TipoDocumento = "01",
                    TipoOperacion = "1001",
                    CuentaBancoNacion = "00047-345",
                    MontoDetraccion = 99.12m,
                    TasaDetraccion = 12, //12% de Detraccion
                    CodigoBienOServicio = "022",  //Otros servicios empresariales (Catalogo 54)
                    CodigoMedioPago = "001", // Medio de Pago (Catalogo 59)
                    TotalIgv = 126,
                    TotalVenta = 826,
                    Gravadas = 700,
                    Items = new List<DetalleDocumento>
                    {
                        new DetalleDocumento
                        {
                            Id = 1,
                            Cantidad = 1,
                            PrecioReferencial = 700,
                            PrecioUnitario = 700,
                            TipoPrecio = "01",
                            CodigoItem = "DES-02",
                            Descripcion = "OPENINVOICEPERU UBL 2.1",
                            UnidadMedida = "NIU",
                            Impuesto = 126,
                            TipoImpuesto = "10", // Gravada
                            TotalVenta = 700 // Monto sin IGV
                        }
                    },
                    Leyendas = new List<Leyenda>
                    {
                        new Leyenda
                        {
                            Codigo = "2006",
                            Descripcion = "Operación sujeta a detracción"
                        }
                    }
                };

                FirmaryEnviar(documento, GenerarDocumento(documento));
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

        private static void CrearBoleta()
        {
            try
            {
                Console.WriteLine("Ejemplo Boleta");
                var documento = new DocumentoElectronico
                {
                    Emisor = CrearEmisor(),
                    Receptor = new Compania
                    {
                        NroDocumento = "88888888",
                        TipoDocumento = "1",
                        NombreLegal = "CLIENTE GENERICO"
                    },
                    IdDocumento = "BB11-001",
                    FechaEmision = DateTime.Today.AddDays(-5).ToString(FormatoFecha),
                    HoraEmision = DateTime.Now.ToString("HH:mm:ss"),
                    Moneda = "PEN",
                    TipoDocumento = "03",
                    TotalIgv = 18,
                    TotalVenta = 118,
                    Gravadas = 100,
                    Items = new List<DetalleDocumento>
                    {
                        new DetalleDocumento
                        {
                            Id = 1,
                            Cantidad = 10,
                            PrecioReferencial = 10,
                            PrecioUnitario = 10,
                            TipoPrecio = "01",
                            CodigoItem = "2435675",
                            Descripcion = "USB Kingston ©",
                            UnidadMedida = "NIU",
                            Impuesto = 18,
                            TipoImpuesto = "10", // Gravada
                            TotalVenta = 100,
                        }
                    }
                };

                FirmaryEnviar(documento, GenerarDocumento(documento));
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

        private static void CrearNotaCredito()
        {
            try
            {
                Console.WriteLine("Ejemplo Nota de Crédito de Factura");
                var documento = new DocumentoElectronico
                {
                    Emisor = CrearEmisor(),
                    Receptor = new Compania
                    {
                        NroDocumento = "20257471609",
                        TipoDocumento = "6",
                        NombreLegal = "FRAMEWORK PERU"
                    },
                    IdDocumento = "FN11-001",
                    FechaEmision = DateTime.Today.AddDays(-5).ToString(FormatoFecha),
                    HoraEmision = DateTime.Now.ToString("HH:mm:ss"),
                    Moneda = "PEN",
                    TipoDocumento = "07",
                    TotalIgv = 0.76m,
                    TotalVenta = 5,
                    Gravadas = 4.24m,
                    Items = new List<DetalleDocumento>
                    {
                        new DetalleDocumento
                        {
                            Id = 1,
                            Cantidad = 1,
                            PrecioReferencial = 4.24m,
                            PrecioUnitario = 4.24m,
                            TipoPrecio = "01",
                            CodigoItem = "2435675",
                            Descripcion = "Correcion Factura",
                            UnidadMedida = "NIU",
                            Impuesto = 0.76m,
                            TipoImpuesto = "10", // Gravada
                            TotalVenta = 5,
                        }
                    },
                    Discrepancias = new List<Discrepancia>
                    {
                        new Discrepancia
                        {
                            NroReferencia = "FF11-001",
                            Tipo = "01",
                            Descripcion = "Anulacion de la operacion"
                        }
                    },
                    Relacionados = new List<DocumentoRelacionado>
                    {
                        new DocumentoRelacionado
                        {
                            NroDocumento = "FF11-001",
                            TipoDocumento = "01"
                        }
                    }
                };

                FirmaryEnviar(documento, GenerarDocumento(documento));
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

        private static void CrearNotaDebito()
        {
            try
            {
                Console.WriteLine("Ejemplo Nota de Débito de Factura");
                var documento = new DocumentoElectronico
                {
                    Emisor = CrearEmisor(),
                    Receptor = new Compania
                    {
                        NroDocumento = "20257471609",
                        TipoDocumento = "6",
                        NombreLegal = "FRAMEWORK PERU"
                    },
                    IdDocumento = "FD11-001",
                    FechaEmision = DateTime.Today.ToString(FormatoFecha),
                    HoraEmision = DateTime.Now.ToString("HH:mm:ss"),
                    Moneda = "PEN",
                    TipoDocumento = "08",
                    TotalIgv = 0.76m,
                    TotalVenta = 5,
                    Gravadas = 4.24m,
                    Items = new List<DetalleDocumento>
                    {
                        new DetalleDocumento
                        {
                            Id = 1,
                            Cantidad = 1,
                            PrecioReferencial = 4.24m,
                            PrecioUnitario = 4.24m,
                            TipoPrecio = "01",
                            CodigoItem = "2435675",
                            Descripcion = "Penalidad por atraso de pago",
                            UnidadMedida = "NIU",
                            Impuesto = 0.76m,
                            TipoImpuesto = "10", // Gravada
                            TotalVenta = 5,
                        }
                    },
                    Discrepancias = new List<Discrepancia>
                    {
                        new Discrepancia
                        {
                            NroReferencia = "FF11-001",
                            Tipo = "03",
                            Descripcion = "Penalidad por falta de pago"
                        }
                    },
                    Relacionados = new List<DocumentoRelacionado>
                    {
                        new DocumentoRelacionado
                        {
                            NroDocumento = "FF11-001",
                            TipoDocumento = "01"
                        }
                    }
                };

                FirmaryEnviar(documento, GenerarDocumento(documento));
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
                var documentoResumenDiario = new ResumenDiarioNuevo
                {
                    IdDocumento = $"RC-{DateTime.Today:yyyyMMdd}-001",
                    FechaEmision = DateTime.Today.ToString(FormatoFecha),
                    FechaReferencia = DateTime.Today.AddDays(-1).ToString(FormatoFecha),
                    Emisor = CrearEmisor(),
                    Resumenes = new List<GrupoResumenNuevo>()
                };

                documentoResumenDiario.Resumenes.Add(new GrupoResumenNuevo
                {
                    Id = 1,
                    TipoDocumento = "03",
                    IdDocumento = "BB14-33386",
                    NroDocumentoReceptor = "41614074",
                    TipoDocumentoReceptor = "1",
                    CodigoEstadoItem = 1, // 1 - Agregar. 2 - Modificar. 3 - Eliminar
                    Moneda = "PEN",
                    TotalVenta = 190.9m,
                    TotalIgv = 29.12m,
                    Gravadas = 161.78m,
                });
                // Para los casos de envio de boletas anuladas, se debe primero informar las boletas creadas (1) y luego en un segundo resumen se envian las anuladas. De lo contrario se presentará el error 'El documento indicado no existe no puede ser modificado/eliminado'
                documentoResumenDiario.Resumenes.Add(new GrupoResumenNuevo
                {
                    Id = 2,
                    TipoDocumento = "03",
                    IdDocumento = "BB30-33384",
                    NroDocumentoReceptor = "08506678",
                    TipoDocumentoReceptor = "1",
                    CodigoEstadoItem = 1, // 1 - Agregar. 2 - Modificar. 3 - Eliminar
                    Moneda = "USD",
                    TotalVenta = 9580m,
                    TotalIgv = 1411.36m,
                    Gravadas = 8168.64m,
                });


                Console.WriteLine("Generando XML....");

                var documentoResponse = RestHelper<ResumenDiarioNuevo, DocumentoResponse>.Execute("GenerarResumenDiario/v2", documentoResumenDiario);

                if (!documentoResponse.Exito)
                    throw new InvalidOperationException(documentoResponse.MensajeError);

                Console.WriteLine("Firmando XML...");
                // Firmado del Documento.
                var firmado = new FirmadoRequest
                {
                    TramaXmlSinFirma = documentoResponse.TramaXmlSinFirma,
                    CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("Certificado.pfx")),
                    PasswordCertificado = string.Empty,
                };

                var responseFirma = RestHelper<FirmadoRequest, FirmadoResponse>.Execute("Firmar", firmado);

                if (!responseFirma.Exito)
                {
                    throw new InvalidOperationException(responseFirma.MensajeError);
                }

                Console.WriteLine("Guardando XML de Resumen....(Revisar carpeta del ejecutable)");

                File.WriteAllBytes("resumendiario.xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado));

                Console.WriteLine("Enviando a SUNAT....");

                var enviarDocumentoRequest = new EnviarDocumentoRequest
                {
                    Ruc = documentoResumenDiario.Emisor.NroDocumento,
                    UsuarioSol = "MODDATOS",
                    ClaveSol = "MODDATOS",
                    EndPointUrl = UrlSunat,
                    IdDocumento = documentoResumenDiario.IdDocumento,
                    TramaXmlFirmado = responseFirma.TramaXmlFirmado
                };

                var enviarResumenResponse = RestHelper<EnviarDocumentoRequest, EnviarResumenResponse>.Execute("EnviarResumen", enviarDocumentoRequest);

                if (!enviarResumenResponse.Exito)
                {
                    throw new InvalidOperationException(enviarResumenResponse.MensajeError);
                }

                Console.WriteLine("Nro de Ticket: {0}", enviarResumenResponse.NroTicket);
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
                    IdDocumento = $"RA-{DateTime.Today:yyyyMMdd}-001",
                    FechaEmision = DateTime.Today.ToString(FormatoFecha),
                    FechaReferencia = DateTime.Today.AddDays(-1).ToString(FormatoFecha),
                    Emisor = CrearEmisor(),
                    Bajas = new List<DocumentoBaja>()
                };

                // En las comunicaciones de Baja ya no se pueden colocar boletas, ya que la anulacion de las mismas
                // la realiza el resumen diario.
                documentoBaja.Bajas.Add(new DocumentoBaja
                {
                    Id = 1,
                    Correlativo = "33386",
                    TipoDocumento = "01",
                    Serie = "FA50",
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

                var documentoResponse = RestHelper<ComunicacionBaja, DocumentoResponse>.Execute("GenerarComunicacionBaja", documentoBaja);
                if (!documentoResponse.Exito)
                {
                    throw new InvalidOperationException(documentoResponse.MensajeError);
                }

                Console.WriteLine("Firmando XML...");
                // Firmado del Documento.
                var firmado = new FirmadoRequest
                {
                    TramaXmlSinFirma = documentoResponse.TramaXmlSinFirma,
                    CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("Certificado.pfx")),
                    PasswordCertificado = string.Empty,
                };

                var responseFirma = RestHelper<FirmadoRequest, FirmadoResponse>.Execute("Firmar", firmado);

                if (!responseFirma.Exito)
                {
                    throw new InvalidOperationException(responseFirma.MensajeError);
                }

                Console.WriteLine("Guardando XML de la Comunicacion de Baja....(Revisar carpeta del ejecutable)");

                File.WriteAllBytes("comunicacionbaja.xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado));

                Console.WriteLine("Enviando a SUNAT....");

                var sendBill = new EnviarDocumentoRequest
                {
                    Ruc = documentoBaja.Emisor.NroDocumento,
                    UsuarioSol = "MODDATOS",
                    ClaveSol = "MODDATOS",
                    EndPointUrl = UrlSunat,
                    IdDocumento = documentoBaja.IdDocumento,
                    TramaXmlFirmado = responseFirma.TramaXmlFirmado
                };

                var enviarResumenResponse = RestHelper<EnviarDocumentoRequest, EnviarResumenResponse>.Execute("EnviarResumen", sendBill);

                if (!enviarResumenResponse.Exito)
                {
                    throw new InvalidOperationException(enviarResumenResponse.MensajeError);
                }

                Console.WriteLine("Nro de Ticket: {0}", enviarResumenResponse.NroTicket);
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
                    Emisor = ToNegocio(CrearEmisor()),
                    Receptor = new Negocio
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

                var documentoResponse = RestHelper<DocumentoRetencion, DocumentoResponse>.Execute("GenerarRetencion", documento);

                if (!documentoResponse.Exito)
                {
                    throw new InvalidOperationException(documentoResponse.MensajeError);
                }

                Console.WriteLine("Firmando XML...");
                // Firmado del Documento.
                var firmado = new FirmadoRequest
                {
                    TramaXmlSinFirma = documentoResponse.TramaXmlSinFirma,
                    CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("certificado.pfx")),
                    PasswordCertificado = string.Empty,
                };

                var responseFirma = RestHelper<FirmadoRequest, FirmadoResponse>.Execute("Firmar", firmado);

                if (!responseFirma.Exito)
                {
                    throw new InvalidOperationException(responseFirma.MensajeError);
                }

                File.WriteAllBytes("retencion.xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado));

                Console.WriteLine("Enviando Retención a SUNAT....");

                var enviarDocumentoRequest = new EnviarDocumentoRequest
                {
                    Ruc = documento.Emisor.NroDocumento,
                    UsuarioSol = "MODDATOS",
                    ClaveSol = "MODDATOS",
                    EndPointUrl = UrlOtroCpe,
                    IdDocumento = documento.IdDocumento,
                    TipoDocumento = "20",
                    TramaXmlFirmado = responseFirma.TramaXmlFirmado
                };

                var enviarDocumentoResponse = RestHelper<EnviarDocumentoRequest, EnviarDocumentoResponse>.Execute("EnviarDocumento", enviarDocumentoRequest);

                if (!enviarDocumentoResponse.Exito)
                {
                    throw new InvalidOperationException(enviarDocumentoResponse.MensajeError);
                }

                Console.WriteLine("Respuesta de SUNAT:");
                Console.WriteLine(enviarDocumentoResponse.MensajeRespuesta);

                File.WriteAllBytes("retencioncdr.zip", Convert.FromBase64String(enviarDocumentoResponse.TramaZipCdr));
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

        private static void CrearDocumentoPercepcion()
        {
            try
            {
                Console.WriteLine("Ejemplo de Percepción");
                var documento = new DocumentoPercepcion
                {
                    Emisor = ToNegocio(CrearEmisor()),
                    Receptor = new Negocio
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
                    IdDocumento = "P001-123",
                    FechaEmision = DateTime.Today.ToString(FormatoFecha),
                    Moneda = "PEN",
                    RegimenPercepcion = "01",
                    TasaPercepcion = 2,
                    ImporteTotalPercibido = 200,
                    ImporteTotalCobrado = 10000,
                    Observaciones = "Emision de Facturas del periodo Dic. 2016",
                    DocumentosRelacionados = new List<ItemPercepcion>
                    {
                        new ItemPercepcion
                        {
                            NroDocumento = "E001-457",
                            TipoDocumento = "01",
                            MonedaDocumentoRelacionado = "USD",
                            FechaEmision = DateTime.Today.AddDays(-3).ToString(FormatoFecha),
                            ImporteTotal = 10000,
                            FechaPago = DateTime.Today.ToString(FormatoFecha),
                            NumeroPago = 153,
                            ImporteSinPercepcion = 9800,
                            ImportePercibido = 200,
                            FechaPercepcion = DateTime.Today.ToString(FormatoFecha),
                            ImporteTotalNeto = 10000,
                            TipoCambio = 3.41m,
                            FechaTipoCambio = DateTime.Today.ToString(FormatoFecha)
                        }
                    }
                };

                Console.WriteLine("Generando XML....");

                var documentoResponse = RestHelper<DocumentoPercepcion, DocumentoResponse>.Execute("GenerarPercepcion", documento);

                if (!documentoResponse.Exito)
                {
                    throw new InvalidOperationException(documentoResponse.MensajeError);
                }

                Console.WriteLine("Firmando XML...");
                // Firmado del Documento.
                var firmado = new FirmadoRequest
                {
                    TramaXmlSinFirma = documentoResponse.TramaXmlSinFirma,
                    CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("certificado.pfx")),
                    PasswordCertificado = string.Empty,
                };

                var responseFirma = RestHelper<FirmadoRequest, FirmadoResponse>.Execute("Firmar", firmado);

                if (!responseFirma.Exito)
                {
                    throw new InvalidOperationException(responseFirma.MensajeError);
                }

                File.WriteAllBytes("percepcion.xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado));

                Console.WriteLine("Enviando Retención a SUNAT....");

                var sendBill = new EnviarDocumentoRequest
                {
                    Ruc = documento.Emisor.NroDocumento,
                    UsuarioSol = "MODDATOS",
                    ClaveSol = "MODDATOS",
                    EndPointUrl = UrlOtroCpe,
                    IdDocumento = documento.IdDocumento,
                    TipoDocumento = "40",
                    TramaXmlFirmado = responseFirma.TramaXmlFirmado
                };

                var responseSendBill = RestHelper<EnviarDocumentoRequest, EnviarDocumentoResponse>.Execute("EnviarDocumento", sendBill);

                if (!responseSendBill.Exito)
                {
                    throw new InvalidOperationException(responseSendBill.MensajeError);
                }

                Console.WriteLine("Respuesta de SUNAT:");
                Console.WriteLine(responseSendBill.MensajeRespuesta);

                File.WriteAllBytes("percepcioncdr.zip", Convert.FromBase64String(responseSendBill.TramaZipCdr));
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

        private static void CrearGuiaRemision()
        {
            try
            {
                Console.WriteLine("Ejemplo de Guia de Remisión");
                var guia = new GuiaRemision
                {
                    IdDocumento = "TAAA-2344",
                    FechaEmision = DateTime.Today.ToString(FormatoFecha),
                    TipoDocumento = "09",
                    Glosa = "Guia de Prueba",
                    Remitente = CrearEmisor(),
                    Destinatario = new Contribuyente
                    {
                        NroDocumento = "20100039207",
                        TipoDocumento = "6",
                        NombreLegal = "RANSA COMERCIAL S.A.",
                    },
                    ShipmentId = "001",
                    CodigoMotivoTraslado = "01",
                    DescripcionMotivo = "VENTA DIRECTA",
                    Transbordo = false,
                    PesoBrutoTotal = 50,
                    NroPallets = 0,
                    ModalidadTraslado = "01",
                    FechaInicioTraslado = DateTime.Today.ToString(FormatoFecha),
                    RucTransportista = "20257471609",
                    RazonSocialTransportista = "FRAMEWORK PERU",
                    NroPlacaVehiculo = "YG-9244",
                    NroDocumentoConductor = "88888888",
                    DireccionPartida = new Direccion
                    {
                        Ubigeo = "150119",
                        DireccionCompleta = "AV. ARAMBURU 878"
                    },
                    DireccionLlegada = new Direccion
                    {
                        Ubigeo = "150101",
                        DireccionCompleta = "AV. ARGENTINA 2388"
                    },
                    NumeroContenedor = string.Empty,
                    CodigoPuerto = string.Empty,
                    BienesATransportar = new List<DetalleGuia>()
                {
                    new DetalleGuia
                    {
                        Correlativo = 1,
                        CodigoItem = "XXXX",
                        Descripcion = "XXXXXXX",
                        UnidadMedida = "NIU",
                        Cantidad = 4,
                        LineaReferencia = 1
                    }
                }
                };

                Console.WriteLine("Generando XML....");

                var documentoResponse = RestHelper<GuiaRemision, DocumentoResponse>.Execute("GenerarGuiaRemision", guia);

                if (!documentoResponse.Exito)
                {
                    throw new InvalidOperationException(documentoResponse.MensajeError);
                }

                Console.WriteLine("Firmando XML...");
                // Firmado del Documento.
                var firmado = new FirmadoRequest
                {
                    TramaXmlSinFirma = documentoResponse.TramaXmlSinFirma,
                    CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("certificado.pfx")),
                    PasswordCertificado = string.Empty,
                };

                var responseFirma = RestHelper<FirmadoRequest, FirmadoResponse>.Execute("Firmar", firmado);

                if (!responseFirma.Exito)
                {
                    throw new InvalidOperationException(responseFirma.MensajeError);
                }

                File.WriteAllBytes("GuiaRemision.xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado));

                Console.WriteLine("Enviando a SUNAT....");

                var documentoRequest = new EnviarDocumentoRequest
                {
                    Ruc = guia.Remitente.NroDocumento,
                    UsuarioSol = "MODDATOS",
                    ClaveSol = "MODDATOS",
                    EndPointUrl = UrlGuiaRemision,
                    IdDocumento = guia.IdDocumento,
                    TipoDocumento = guia.TipoDocumento,
                    TramaXmlFirmado = responseFirma.TramaXmlFirmado
                };

                var enviarDocumentoResponse = RestHelper<EnviarDocumentoRequest, EnviarDocumentoResponse>.Execute("EnviarDocumento", documentoRequest);

                if (!enviarDocumentoResponse.Exito)
                {
                    throw new InvalidOperationException(enviarDocumentoResponse.MensajeError);
                }

                File.WriteAllBytes("GuaiRemisionCdr.zip", Convert.FromBase64String(enviarDocumentoResponse.TramaZipCdr));

                Console.WriteLine("Respuesta de SUNAT:");
                Console.WriteLine(enviarDocumentoResponse.MensajeRespuesta);
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

        private static DocumentoResponse GenerarDocumento(DocumentoElectronico documento)
        {
            Console.WriteLine("Generando XML....");

            var metodo = "GenerarFactura";
            switch (documento.TipoDocumento)
            {
                case "01":
                case "03":
                    metodo = "GenerarFactura";
                    break;
                case "07":
                    metodo = "GenerarNotaCredito";
                    break;
                case "08":
                    metodo = "GenerarNotaDebito";
                    break;
            }

            var documentoResponse = RestHelper<DocumentoElectronico, DocumentoResponse>.Execute(metodo, documento);

            if (!documentoResponse.Exito)
            {
                throw new InvalidOperationException(documentoResponse.MensajeError);
            }

            return documentoResponse;
        }

        private static void FirmaryEnviar(DocumentoElectronico documento, DocumentoResponse documentoResponse)
        {
            Console.WriteLine("Firmando XML...");
            // Firmado del Documento.
            var firmado = new FirmadoRequest
            {
                TramaXmlSinFirma = documentoResponse.TramaXmlSinFirma,
                CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("certificado.pfx")),
                PasswordCertificado = string.Empty,
            };

            var responseFirma = RestHelper<FirmadoRequest, FirmadoResponse>.Execute("Firmar", firmado);

            if (!responseFirma.Exito)
            {
                throw new InvalidOperationException(responseFirma.MensajeError);
            }

            Console.WriteLine("Escribiendo el archivo {0}.xml .....", documento.IdDocumento);

            File.WriteAllBytes($"{documento.IdDocumento}.xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado));

            Console.WriteLine("Enviando a SUNAT....");

            var documentoRequest = new EnviarDocumentoRequest
            {
                Ruc = documento.Emisor.NroDocumento,
                UsuarioSol = "MODDATOS",
                ClaveSol = "MODDATOS",
                EndPointUrl = UrlSunat,
                IdDocumento = documento.IdDocumento,
                TipoDocumento = documento.TipoDocumento,
                TramaXmlFirmado = responseFirma.TramaXmlFirmado
            };

            var enviarDocumentoResponse = RestHelper<EnviarDocumentoRequest, EnviarDocumentoResponse>.Execute("EnviarDocumento", documentoRequest);

            if (!enviarDocumentoResponse.Exito)
            {
                throw new InvalidOperationException(enviarDocumentoResponse.MensajeError);
            }

            File.WriteAllBytes($"{documento.IdDocumento}.zip", Convert.FromBase64String(enviarDocumentoResponse.TramaZipCdr));

            Console.WriteLine("Respuesta de SUNAT:");
            Console.WriteLine(enviarDocumentoResponse.MensajeRespuesta);
        }
    }
}

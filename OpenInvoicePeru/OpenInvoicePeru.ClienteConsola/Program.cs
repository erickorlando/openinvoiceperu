using OpenInvoicePeru.Comun.Dto.Intercambio;
using OpenInvoicePeru.Comun.Dto.Modelos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace OpenInvoicePeru.ClienteConsola
{
    class Program
    {
        private const string UrlSunat = "https://e-beta.sunat.gob.pe/ol-ti-itcpfegem-beta/billService";
        private const string FormatoFecha = "yyyy-MM-dd";

        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Title = "OpenInvoicePeru - Prueba de Envío de Documentos Electrónicos con UBL 2.1";

            //CrearFactura();
            //CrearBoleta();
            //CrearResumenDiario();
            //CrearFacturaConDetraccionTransportes();
            CrearNotaCredito();
            CrearNotaDebito();

            //var documento = new DocumentoElectronico
            //{
            //    IdDocumento = "B001-124",
            //    TipoDocumento = "03",
            //    Emisor = new Compania
            //    {
            //        NroDocumento = "20257471609"
            //    }
            //};

            //FirmaryEnviar(documento, new DocumentoResponse
            //{
            //    TramaXmlSinFirma = Convert.ToBase64String(File.ReadAllBytes(@"C:\GitProjects\OpenInvoicePeruUBL21\OpenInvoicePeru\artifacts\B001-124.XML"))
            //});

            //ConsultarTicket("300000005449503", "20454791887");

            Console.ReadLine();
        }

        private static Compania CrearEmisor()
        {
            return new Compania
            {
                NroDocumento = "20167795120",
                TipoDocumento = "6",
                NombreComercial = "INVERSIONES ANCONA",
                NombreLegal = "INVERSIONES ANCONA S.A.C",
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
                Console.WriteLine("Ejemplo Factura Gravada (FF11-001)");
                var documento = new DocumentoElectronico
                {
                    Emisor = CrearEmisor(),
                    Receptor = new Compania
                    {
                        NroDocumento = "20100121809",
                        TipoDocumento = "6",
                        NombreLegal = "ADMINISTRADORA CLINICA RICARDO PALMA S.A."
                    },
                    IdDocumento = "FM01-00003422",
                    FechaEmision = "2020-07-07",  // DateTime.Today.ToString(FormatoFecha),
                    HoraEmision = "12:00:00", //DateTime.Now.ToString("HH:mm:ss"),
                    Moneda = "USD",
                    TipoDocumento = "01",
                    TotalIgv = 300.6m,
                    TotalVenta = 1967.06m,
                    Gravadas = 1667m,
                    Gratuitas = 300m,
                    Items = new List<DetalleDocumento>
                    {
                        new DetalleDocumento
                        {
                            Id = 1,
                            Cantidad = 2,
                            PrecioReferencial = 21.19m,
                            PrecioUnitario = 21.19m,
                            TipoPrecio = "01",
                            CodigoItem = "1234234",
                            Descripcion = "Arroz Costeño",
                            UnidadMedida = "NIU",
                            Impuesto = 7.62m, //Impuesto del Precio * Cantidad
                            TipoImpuesto = "10", // Gravada
                            TotalVenta = 50m,
                        },
                        new DetalleDocumento
                        {
                            Id = 2,
                            Cantidad = 10,
                            PrecioReferencial = 45.60m,
                            PrecioUnitario = 45.60m,
                            TipoPrecio = "01",
                            CodigoItem = "AER345667",
                            Descripcion = "Aceite Primor",
                            UnidadMedida = "NIU",
                            Impuesto = 82.08m,
                            TipoImpuesto = "10", // Gravada
                            TotalVenta = 538.08m,
                        },
                        new DetalleDocumento
                        {
                            Id = 3,
                            Cantidad = 10,
                            PrecioReferencial = 20,
                            PrecioUnitario = 20,
                            TipoPrecio = "01",
                            CodigoItem = "3445666777",
                            Descripcion = "Shampoo Palmolive",
                            UnidadMedida = "NIU",
                            Impuesto = 36,
                            TipoImpuesto = "10", // Gravada
                            TotalVenta = 236,
                        },
                        new DetalleDocumento
                        {
                            Id = 4,
                            Cantidad = 1,
                            PrecioReferencial = 0.10m,
                            PrecioUnitario = 0.10m,
                            TipoPrecio = "01",
                            CodigoItem = "BOL",
                            Descripcion = "Bolsa Plastica",
                            UnidadMedida = "NIU",
                            Impuesto = 0.018m,
                            TipoImpuesto = "10", // Gravada
                            OtroImpuesto = 0.10m,
                            TotalVenta = 0.20m,
                            CantidadBolsas = 1,
                            PrecioUnitarioBolsa = 0.10m
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
                Console.WriteLine("Ejemplo Factura Gravada (BB11-001)");
                var documento = new DocumentoElectronico
                {
                    Emisor = CrearEmisor(),
                    Receptor = new Compania
                    {
                        NroDocumento = "88888888",
                        TipoDocumento = "1",
                        NombreLegal = "CLIENTES VARIOS"
                    },
                    IdDocumento = "BB11-008",
                    FechaEmision = DateTime.Today.ToString(FormatoFecha),
                    HoraEmision = "12:00:00", //DateTime.Now.ToString("HH:mm:ss"),
                    Moneda = "PEN",
                    TipoDocumento = "03",
                    TotalIgv = 125.7264m,
                    TotalVenta = 824.2064m,
                    TotalOtrosTributos = 0.10m,
                    Gravadas = 698.48m,
                    Items = new List<DetalleDocumento>
                    {
                        new DetalleDocumento
                        {
                            Id = 1,
                            Cantidad = 2,
                            PrecioReferencial = 21.19m,
                            PrecioUnitario = 21.19m,
                            TipoPrecio = "01",
                            CodigoItem = "1234234",
                            Descripcion = "Arroz Costeño",
                            UnidadMedida = "NIU",
                            Impuesto = 7.62m, //Impuesto del Precio * Cantidad
                            TipoImpuesto = "10", // Gravada
                            TotalVenta = 50m,
                        },
                        new DetalleDocumento
                        {
                            Id = 2,
                            Cantidad = 10,
                            PrecioReferencial = 45.60m,
                            PrecioUnitario = 45.60m,
                            TipoPrecio = "01",
                            CodigoItem = "AER345667",
                            Descripcion = "Aceite Primor",
                            UnidadMedida = "NIU",
                            Impuesto = 82.08m,
                            TipoImpuesto = "10", // Gravada
                            TotalVenta = 538.08m,
                        },
                        new DetalleDocumento
                        {
                            Id = 3,
                            Cantidad = 10,
                            PrecioReferencial = 20,
                            PrecioUnitario = 20,
                            TipoPrecio = "01",
                            CodigoItem = "3445666777",
                            Descripcion = "Shampoo Palmolive",
                            UnidadMedida = "NIU",
                            Impuesto = 36,
                            TipoImpuesto = "10", // Gravada
                            TotalVenta = 236,
                        },
                        new DetalleDocumento
                        {
                            Id = 4,
                            Cantidad = 1,
                            PrecioReferencial = 0.10m,
                            PrecioUnitario = 0.10m,
                            TipoPrecio = "01",
                            CodigoItem = "BOL",
                            Descripcion = "Bolsa Plastica",
                            UnidadMedida = "NIU",
                            Impuesto = 0.00m,
                            TipoImpuesto = "20", // Exonerada
                            OtroImpuesto = 0.10m,
                            TotalVenta = 0.20m,
                            CantidadBolsas = 1,
                            PrecioUnitarioBolsa = 0.10m
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
        private static void CrearFacturaConDetraccionTransportes()
        {
            try
            {
                Console.WriteLine("Ejemplo Factura con Detracción de Transportes");
                var documento = new DocumentoElectronico
                {
                    Emisor = CrearEmisor(),
                    Receptor = new Compania
                    {
                        NroDocumento = "20100039207",
                        TipoDocumento = "6",
                        NombreLegal = "RANSA COMERCIAL S.A."
                    },
                    IdDocumento = "FF11-001",
                    FechaEmision = DateTime.Today.AddDays(-5).ToString(FormatoFecha),
                    HoraEmision = DateTime.Now.ToString("HH:mm:ss"),
                    Moneda = "PEN",
                    TipoDocumento = "01",
                    TipoOperacion = "1001",
                    CuentaBancoNacion = "00047-345",
                    MontoDetraccion = 99.12m,
                    TasaDetraccion = 4, //4% de Detracción
                    CodigoBienOServicio = "027",  //Servicio de Transporte de Carga (Catalogo 54)
                    CodigoMedioPago = "001", // Medio de Pago (Catalogo 59)
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
                            Descripcion = "Transporte",
                            UnidadMedida = "KG",
                            Impuesto = 18,
                            TipoImpuesto = "10", // Gravada
                            TotalVenta = 100,
                            UbigeoOrigen = "150101",
                            DireccionOrigen = "Av. Argentina 2388",
                            UbigeoDestino = "160101",
                            DireccionDestino = "Jr. Morona 171",
                            DetalleViaje = "Viaje con carga pesada",
                            ValorReferencial = 500,
                            ValorReferencialCargaEfectiva = 520,
                            ValorReferencialCargaUtil = 480
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
                Console.WriteLine("Ejemplo Nota de Crédito de Factura (FN11-001)");
                var documento = new DocumentoElectronico
                {
                    Emisor = CrearEmisor(),
                    Receptor = new Compania
                    {
                        NroDocumento = "20335955065",
                        TipoDocumento = "6",
                        NombreLegal = "MEDIA NETWORKS LATIN AMERICA S.A.C.",
                        CodigoAnexo = ""
                    },
                    IdDocumento = "FC01-00000178",
                    FechaEmision = DateTime.Today.AddDays(-5).ToString(FormatoFecha),
                    HoraEmision = DateTime.Now.ToString("HH:mm:ss"),
                    FechaVencimiento = "2020-02-29",
                    MontoEnLetras = string.Empty,
                    Moneda = "USD",
                    TipoDocumento = "07",
                    TotalIgv = 435.60m,
                    TotalVenta = 2855.60m,
                    Gravadas = 2420m,
                    Items = new List<DetalleDocumento>
                    {
                        new DetalleDocumento
                        {
                            Id = 1,
                            Cantidad = 1,
                            PrecioReferencial = 2420.0m,
                            PrecioUnitario = 2420m,
                            TipoPrecio = "01",
                            CodigoItem = "2435675",
                            Descripcion = "Dproc (CCD)",
                            UnidadMedida = "NIU",
                            Impuesto = 435.60m,
                            TipoImpuesto = "10", // Gravada
                            TotalVenta = 2420m,
                        }
                    },
                    Discrepancias = new List<Discrepancia>
                    {
                        new Discrepancia
                        {
                            NroReferencia = "FM01-00001318",
                            Tipo = "01",
                            Descripcion = "CANCELACION TOTAL"
                        }
                    },
                    //Relacionados = new List<DocumentoRelacionado>
                    //{
                    //    new DocumentoRelacionado
                    //    {
                    //        NroDocumento = "FF11-001",
                    //        TipoDocumento = "01"
                    //    }
                    //}
                };

                File.WriteAllText("notacredito.json", Newtonsoft.Json.JsonConvert.SerializeObject(documento));

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
                Console.WriteLine("Ejemplo Nota de Débito de Factura (FD11-001)");
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
                    TotalImpuestoBolsas = 6.50m,
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

                ConsultarTicket(enviarResumenResponse.NroTicket, documentoResumenDiario.Emisor.NroDocumento);
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

                ConsultarTicket(enviarResumenResponse.NroTicket, documentoBaja.Emisor.NroDocumento);
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

        private static void ConsultarTicket(string nroTicket, string nroRuc)
        {
            var consultarTicketRequest = new ConsultaTicketRequest
            {
                Ruc = nroRuc,
                NroTicket = nroTicket,
                UsuarioSol = "VETERIF1",
                ClaveSol = "FF4KG8SF4",
                EndPointUrl = UrlSunat
            };

            var response = RestHelper<ConsultaTicketRequest, EnviarDocumentoResponse>.Execute("ConsultarTicket", consultarTicketRequest);

            if (!response.Exito)
            {
                Console.WriteLine($"{response.MensajeError} {response.Pila}");
                return;
            }

            var archivo = response.NombreArchivo.Replace(".xml", string.Empty);
            Console.WriteLine($"Escribiendo documento en la carpeta del ejecutable... {archivo}");

            File.WriteAllBytes($"{archivo}.zip", Convert.FromBase64String(response.TramaZipCdr));

            Console.WriteLine($"Código: {response.CodigoRespuesta} => {response.MensajeRespuesta}");
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
                ValoresQr = documentoResponse.ValoresParaQr
            };

            var responseFirma = RestHelper<FirmadoRequest, FirmadoResponse>.Execute("Firmar", firmado);

            if (!responseFirma.Exito)
            {
                throw new InvalidOperationException(responseFirma.MensajeError);
            }

            if (!string.IsNullOrEmpty(responseFirma.CodigoQr))
            {
                using (var mem = new MemoryStream(Convert.FromBase64String(responseFirma.CodigoQr)))
                {
                    Console.WriteLine("Guardando Imagen QR para el documento...");
                    var imagen = Image.FromStream(mem);
                    imagen.Save($"{documento.IdDocumento}.png");
                }
            }

            Console.WriteLine("Escribiendo el archivo {0}.xml .....", documento.IdDocumento);

            var path = $"{documento.IdDocumento}.xml";
            File.WriteAllBytes(path, Convert.FromBase64String(responseFirma.TramaXmlFirmado));
            Process.Start(path);

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

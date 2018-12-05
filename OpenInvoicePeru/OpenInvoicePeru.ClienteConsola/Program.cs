using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Console.Title = "OpenInvoicePeru - Prueba de Envío de Documentos Electrónicos con UBL 2.1";

            CrearFacturaConDetraccionTransportes();
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

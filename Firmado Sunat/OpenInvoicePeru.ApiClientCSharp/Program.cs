using System;
using System.Collections.ObjectModel;
using System.IO;
using OpenInvoicePeru.FirmadoSunat.Models;
using RestSharp;

namespace OpenInvoicePeru.ApiClientCSharp
{
    class Program
    {
        private static readonly string _baseUrl = "http://localhost:50888/OpenInvoicePeru/api";

        static void Main(string[] args)
        {
            Console.WriteLine("Prueba de API REST de OpenInvoicePeru (C#)");
          
            var documento = new DocumentoElectronico
            {
                Emisor = new Contribuyente
                {
                    NroDocumento = "20100070970",
                    TipoDocumento = "6",
                    Direccion = "CAL.MORELLI NRO. 181 INT. P-2",
                    Urbanizacion = "-",
                    Departamento = "LIMA",
                    Provincia = "LIMA",
                    Distrito = "SAN BORJA",
                    NombreComercial = "PLAZA VEA",
                    NombreLegal = "SUPERMERCADOS PERUANOS SOCIEDAD ANONIMA"
                },
                Receptor = new Contribuyente
                {
                    NroDocumento = "20100039207",
                    TipoDocumento = "6",
                    NombreLegal = "RANSA COMERCIAL S.A."
                },
                IdDocumento = "FF11-001",
                FechaEmision = DateTime.Today.AddDays(-5).ToShortDateString(),
                Moneda = "PEN",
                MontoEnLetras = "SON CIENTO DIECIOCHO SOLES CON 0/100",
                CalculoIgv = 0.18m,
                CalculoIsc = 0.10m,
                CalculoDetraccion = 0.04m,
                TipoDocumento = "01",
                TotalIgv = 18,
                TotalVenta = 118,
                Gravadas = 100,
                Items = new ObservableCollection<DetalleDocumento>()
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

            var client = new RestClient(_baseUrl);

            var requestInvoice = new RestRequest("GenerarFactura", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            requestInvoice.AddBody(documento);

            var documentoResponse = client.Execute<DocumentoResponse>(requestInvoice);

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
            
            Console.WriteLine("Enviando a SUNAT....");

            var sendBill = new EnviarDocumentoRequest
            {
                Ruc = documento.Emisor.NroDocumento,
                UsuarioSol = "MODDATOS",
                ClaveSol = "MODDATOS",
                EndPointUrl = "https://e-beta.sunat.gob.pe/ol-ti-itcpfegem-beta/billService",
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
            
            Console.WriteLine("Respuesta de SUNAT:");
            Console.WriteLine(responseSendBill.Data.MensajeRespuesta);

            Console.ReadLine();
        }
    }
}

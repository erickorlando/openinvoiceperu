using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenInvoicePeru.FirmadoSunat.Models;
using OpenInvoicePeruApi.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenInvoicePeruApi.Controllers.Tests
{
    [TestClass()]
    public class GenerarFacturaControllerTests
    {
        [TestMethod()]
        public void PostTest()
        {
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
                FechaEmision = DateTime.Today.AddDays(-5).ToString("yyyy-MM-dd"),
                Moneda = "PEN",
                MontoEnLetras = "SON CIENTO DIECIOCHO SOLES CON 0/100",
                CalculoIgv = 0.18m,
                CalculoIsc = 0.10m,
                CalculoDetraccion = 0.04m,
                TipoDocumento = "01",
                TotalIgv = 18,
                TotalVenta = 118,
                Gravadas = 100,
                Items = new List<DetalleDocumento>()
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

            var controller = new GenerarFacturaController();

            var response =  controller.Post(documento);

            Assert.IsTrue(response.Exito);

        }
    }
}
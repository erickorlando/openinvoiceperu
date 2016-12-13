using System.Threading.Tasks;
using Moq;
using OpenInvoicePeru.Comun;
using OpenInvoicePeru.Firmado;
using OpenInvoicePeru.Tests.Fake;
using Xunit;

namespace OpenInvoicePeru.Tests
{
    public class SerializadorTests
    {
        [Fact]
        public async Task Serializador_No_Debe_Generar_Trama_Vacia()
        {
            ISerializador serializador = new SerializadorFake();
            var invoice = new Mock<IEstructuraXml>();
            
            var result = await serializador.GenerarXml(invoice.Object);

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task Serializador_No_Debe_Generar_TramaZip_Vacia()
        {
            ISerializador serializador = new SerializadorFake();
            var result = await serializador.GenerarZip("trama", "20255390288");

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task Serializador_Debe_Retornar_Exito()
        {
            ISerializador serializador = new SerializadorFake();
            var result = await serializador.GenerarDocumentoRespuesta(It.IsAny<string>());
            
            Assert.True(result.Exito);
        }
    }
}
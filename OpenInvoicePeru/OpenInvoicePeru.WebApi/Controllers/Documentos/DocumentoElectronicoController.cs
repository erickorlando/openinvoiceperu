using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using OpenInvoicePeru.Comun.Dto.Modelos;
using OpenInvoicePeru.Datos;
using OpenInvoicePeru.Entidades;
using OpenInvoicePeru.Firmado;
using OpenInvoicePeru.Xml;

namespace OpenInvoicePeru.WebApi.Controllers.Documentos
{
    [RoutePrefix("api/Documentos")]
    public class DocumentoElectronicoController : ApiController
    {

        private readonly ISerializador _serializador;
        private readonly ICertificador _certificador;
        private readonly OpenInvoicePeruDb _context;

        public DocumentoElectronicoController(ISerializador serializador, ICertificador certificador, OpenInvoicePeruDb context)
        {
            _serializador = serializador;
            _certificador = certificador;
            _context = context;
        }


        //[Route("Documento/Generar/{tipodoc}")]
        //[HttpPost]
        //public async Task<CabeceraDocumento> Generar(string tipoDoc, [FromBody]DocumentoElectronico documentoElectronico)
        //{
        //    IDocumentoXml documentoXml;
        //    switch (tipoDoc)
        //    {
        //        case "01":
        //        case "03":
        //            documentoXml = new FacturaXml();
        //            break;
        //        case "07":
        //            documentoXml = new NotaCreditoXml();
        //            break;
        //        case "08":
        //            documentoXml = new NotaCreditoXml();
        //            break;
        //        default:
        //            throw new InvalidOperationException($"El tipo de Documento {tipoDoc} no está registrado");
        //    }

        //    try
        //    {
        //        var tipoDocumento = await _context.Set<TipoDocumento>()
        //            .SingleOrDefaultAsync(p => p.Codigo == documentoElectronico.TipoDocumento);

        //        var cabeceraDocumento = new CabeceraDocumento
        //        {
        //            IdDocumento = documentoElectronico.IdDocumento,
                    
        //        };

        //        var documento = documentoXml.Generar(documentoElectronico);


        //    }
        //    catch (Exception ex)
        //    {
        //        Trace.WriteLine(ex);
        //        throw;
        //    }
        //}

    }
}

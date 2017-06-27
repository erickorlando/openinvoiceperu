using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using OpenInvoicePeru.Datos;
using OpenInvoicePeru.Entidades;

namespace OpenInvoicePeru.WebApi.Controllers.Admin
{
    [RoutePrefix("api/admin")]
    public class ParametroConfiguracionController : ApiController
    {

        private readonly OpenInvoicePeruDb _context;

        public ParametroConfiguracionController(OpenInvoicePeruDb context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Parametros/{id}")]
        public async Task<ParametroConfiguracion> Get(int id)
        {
            return await _context.Set<ParametroConfiguracion>().FindAsync(id);
        }

        [HttpGet]
        [Route("Parametros/GetByRuc/{ruc}")]
        public async Task<ParametroConfiguracion> GetByRuc(string ruc)
        {
            var empresa =  await _context.Set<Empresa>().SingleOrDefaultAsync(e => e.NroDocumento == ruc);

            if (empresa == null)
                throw new InvalidOperationException($"Empresa con el RUC {ruc} no existe");

            return await _context.Set<ParametroConfiguracion>()
                .Include(p => p.Contribuyente)
                .Include(p => p.Contribuyente.Ubigeo)
                .Include(p => p.Contribuyente.TipoDocumento)
                .SingleOrDefaultAsync(p => p.IdContribuyente == empresa.Id);
        }

        [HttpGet]
        [Route("Parametros/GetAll/")]
        public async Task<IEnumerable<ParametroConfiguracion>> GetAll()
        {
            return await _context.Set<ParametroConfiguracion>()
                .Include(p => p.Contribuyente)
                .AsNoTracking().ToListAsync();
        }

        [HttpPost]
        [Route("Parametros/")]
        public async Task<IHttpActionResult> Post(ParametroConfiguracion entity)
        {
            _context.Set<ParametroConfiguracion>().Add(entity);
            await _context.SaveChangesAsync();

            return Ok(entity);
        }

        [Route("Parametros/")]
        public async Task<IHttpActionResult> Put(ParametroConfiguracion entity)
        {
            _context.Set<ParametroConfiguracion>().Attach(entity);
            _context.SetEntityState(entity);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [Route("Parametros/")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var entity = await _context.Set<ParametroConfiguracion>().FindAsync(id);
            if (entity == null)
                return NotFound();
            _context.Set<ParametroConfiguracion>().Remove(entity);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

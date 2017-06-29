using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using OpenInvoicePeru.Datos;
using OpenInvoicePeru.Entidades;

namespace OpenInvoicePeru.WebApi.Controllers.Admin
{
    [RoutePrefix("api/admin")]
    public class EmpresasController : ApiController
    {
        private readonly OpenInvoicePeruDb _context;

        public EmpresasController(OpenInvoicePeruDb context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Empresas/{id}")]
        public async Task<Empresa> Get(int id)
        {
            return await _context.Set<Empresa>().FindAsync(id);
        }

        [HttpGet]
        [Route("Empresas/GetAll/")]
        public async Task<IEnumerable<Empresa>> GetAll()
        {
            return await _context.Set<Empresa>()
                .Include(p => p.Ubigeo)
                .Include(p => p.TipoDocumento)
                .AsNoTracking().ToListAsync();
        }

        [HttpPost]
        [Route("Empresas/")]
        public async Task<IHttpActionResult> Post(Empresa entity)
        {
            _context.Set<Empresa>().Add(entity);
            await _context.SaveChangesAsync();

            return Ok(entity);
        }

        [Route("Empresas/")]
        public async Task<IHttpActionResult> Put(Empresa entity)
        {
            _context.Set<Empresa>().Attach(entity);
            _context.SetEntityState(entity);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [Route("Empresas/")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var entity = await _context.Set<Empresa>().FindAsync(id);
            if (entity == null)
                return NotFound();
            _context.Set<Empresa>().Remove(entity);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

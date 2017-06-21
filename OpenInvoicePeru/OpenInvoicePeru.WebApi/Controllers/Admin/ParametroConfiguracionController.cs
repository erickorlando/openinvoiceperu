using System.Linq;
using System.Web.Http;
using OpenInvoicePeru.Datos;
using OpenInvoicePeru.Entidades;

namespace OpenInvoicePeru.WebApi.Controllers.Admin
{
    [RoutePrefix("/api/admin/ParametroConfiguracion")]
    public class ParametroConfiguracionController : ApiController
    {
        private readonly OpenInvoicePeruDb _context;

        public ParametroConfiguracionController(OpenInvoicePeruDb context)
        {
            _context = context;
        }

        //// GET: api/ParametroConfiguracion
        //public IEnumerable<ParametroConfiguracion> Get()
        //{
        //    return _context.Parametros.AsNoTracking().ToList();
        //}

        // GET: api/ParametroConfiguracion/5
        public ParametroConfiguracion Get(string ruc)
        {
            return _context.Parametros.SingleOrDefault(d => d.Contribuyente.NroDocumento == ruc);
        }

        // POST: api/ParametroConfiguracion
        public void Post([FromBody]ParametroConfiguracion value)
        {
            _context.Set<ParametroConfiguracion>().Add(value);
            _context.SaveChanges();
        }

        // PUT: api/ParametroConfiguracion/5
        public void Put(int id, [FromBody]ParametroConfiguracion value)
        {

        }

        // DELETE: api/ParametroConfiguracion/5
        public void Delete(int id)
        {
        }
    }
}

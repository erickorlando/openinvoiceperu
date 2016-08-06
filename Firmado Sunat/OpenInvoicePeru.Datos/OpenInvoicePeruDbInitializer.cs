using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenInvoicePeru.Datos.Entidades;
using SQLite.CodeFirst;

namespace OpenInvoicePeru.Datos
{
    public class OpenInvoicePeruDbInitializer : SqliteDropCreateDatabaseWhenModelChanges<OpenInvoicePeruDb>
    {
        public OpenInvoicePeruDbInitializer(DbModelBuilder modelBuilder) 
            : base(modelBuilder, typeof(CustomHistory))
        {

        }

        protected override void Seed(OpenInvoicePeruDb context)
        {
            context.Monedas.AddOrUpdate(
                p => p.Id,
                new Moneda
                {
                    Codigo = "PEN",
                    Descripcion = "Soles"
                },
                new Moneda
                {
                    Codigo = "USD",
                    Descripcion = "Dólares Americanos"
                });

            context.DireccionesSunat.AddOrUpdate(
                p => p.Id,
                new DireccionSunat
                {
                    Codigo =  "Desarrollo",
                    Descripcion = "https://e-beta.sunat.gob.pe/ol-ti-itcpfegem-beta/billService"
                },
                new DireccionSunat
                {
                    Codigo = "Homologación",
                    Descripcion = "https://www.sunat.gob.pe/ol-ti-itcpgem-sqa/billService"
                },
                new DireccionSunat
                {
                    Codigo = "Producción",
                    Descripcion = "https://www.sunat.gob.pe/ol-ti-itcpfegem/billService"
                },
                new DireccionSunat
                {
                    Codigo = "Retención/Percepción Desarrollo",
                    Descripcion = "https://e-beta.sunat.gob.pe/ol-ti-itemision-otroscpe-gem-beta/billService"
                },
                new DireccionSunat
                {
                    Codigo = "Retención/Percepción Produccion",
                    Descripcion = "https://www.sunat.gob.pe:443/ol-ti-itemision-otroscpe-gem/billService"
                });
        }
    }
}

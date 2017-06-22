using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using OpenInvoicePeru.Comun.Dto.Modelos;
using OpenInvoicePeru.Datos;
using OpenInvoicePeru.Entidades;

namespace OpenInvoicePeru.WinApp
{
    public partial class FrmDiscrepancia : PlantillaBase
    {
        private readonly string _tipoDoc;

        public FrmDiscrepancia()
        {
            InitializeComponent();
        }

        public FrmDiscrepancia(Discrepancia discrepancia, string tipoDoc)
        {
            InitializeComponent();
            _tipoDoc = tipoDoc;
            discrepanciaBindingSource.DataSource = discrepancia;
            discrepanciaBindingSource.ResetBindings(false);

            Load += (s, e) =>
            {
                using (var ctx = new OpenInvoicePeruDb())
                {
                    var tipoDocumento = ctx.Set<TipoDocumento>()
                        .AsNoTracking()
                        .SingleOrDefault(p => p.Codigo == _tipoDoc);

                    if (tipoDocumento == null) return;

                    tipoDiscrepanciaBindingSource.DataSource = ctx.Set<TipoDiscrepancia>()
                                .Where(t => t.IdTipoDocumento == tipoDocumento.Id).AsNoTracking().ToList();

                    tipoDiscrepanciaBindingSource.ResetBindings(false);
                }
            };

            toolOk.Click += (s, e) =>
            {
                discrepanciaBindingSource.EndEdit();

                DialogResult = DialogResult.OK;
            };

            toolCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }
    }
}

using System.Linq;
using System.Windows.Forms;
using OpenInvoicePeru.Comun.Dto.Modelos;
using OpenInvoicePeru.Datos;

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
                    tipoDiscrepanciaBindingSource.DataSource = ctx.TipoDiscrepancias
                            .Where(t => t.IdTipoDocumento == int.Parse(_tipoDoc)).ToList();

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

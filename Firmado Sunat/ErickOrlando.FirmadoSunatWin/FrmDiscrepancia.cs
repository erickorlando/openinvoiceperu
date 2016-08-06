using System.Linq;
using System.Windows.Forms;
using OpenInvoicePeru.Datos;
using OpenInvoicePeru.FirmadoSunat.Models;

namespace OpenInvoicePeru.FirmadoSunatWin
{
    public partial class FrmDiscrepancia : Form
    {
        private readonly Discrepancia _discrepancia;
        private readonly string _tipoDoc;

        public FrmDiscrepancia()
        {
            InitializeComponent();
        }

        public FrmDiscrepancia(Discrepancia discrepancia, string tipoDoc)
        {
            InitializeComponent();
            _discrepancia = discrepancia;
            _tipoDoc = tipoDoc;
            discrepanciaBindingSource.DataSource = _discrepancia;
            discrepanciaBindingSource.ResetBindings(false);

            Load += (s, e) =>
            {
                using (var ctx = new OpenInvoicePeruDb())
                {
                    tipoDiscrepanciaBindingSource.DataSource = ctx.TipoDiscrepancias
                            .Where(t => t.DocumentoAplicado == _tipoDoc).ToList();

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

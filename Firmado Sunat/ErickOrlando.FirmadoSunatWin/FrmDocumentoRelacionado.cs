using System.Linq;
using System.Windows.Forms;
using OpenInvoicePeru.Datos;
using OpenInvoicePeru.FirmadoSunat.Models;

namespace OpenInvoicePeru.FirmadoSunatWin
{
    public partial class FrmDocumentoRelacionado : Form
    {
        private readonly DocumentoRelacionado _documentoRelacionado;

        public FrmDocumentoRelacionado()
        {
            InitializeComponent();
        }

        public FrmDocumentoRelacionado(DocumentoRelacionado documentoRelacionado)
        {
            InitializeComponent();
            _documentoRelacionado = documentoRelacionado;
            documentoRelacionadoBindingSource.DataSource = _documentoRelacionado;
            documentoRelacionadoBindingSource.ResetBindings(false);

            Load += (s, e) =>
            {
                using (var ctx = new OpenInvoicePeruDb())
                {
                    tipoDocumentoRelacionadoBindingSource.DataSource = ctx.TipoDocumentoRelacionados.ToList();
                    tipoDocumentoRelacionadoBindingSource.ResetBindings(false);
                }
            };

            toolOk.Click += (s, e) =>
            {
                documentoRelacionadoBindingSource.EndEdit();
                DialogResult = DialogResult.OK;
            };

            toolCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }
    }
}

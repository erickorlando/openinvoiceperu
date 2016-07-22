using System.Windows.Forms;
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

            toolOk.Click += (s, e) =>
            {
                documentoRelacionadoBindingSource.EndEdit();
                _documentoRelacionado.TipoDocumento = tipoDocumentoComboBox.Text;
                DialogResult = DialogResult.OK;
            };

            toolCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }
    }
}

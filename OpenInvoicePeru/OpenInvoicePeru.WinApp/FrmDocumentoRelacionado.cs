using System.Linq;
using System.Windows.Forms;
using OpenInvoicePeru.Comun.Dto.Modelos;
using OpenInvoicePeru.Datos;

namespace OpenInvoicePeru.WinApp
{
    public partial class FrmDocumentoRelacionado : PlantillaBase
    {
        public FrmDocumentoRelacionado()
        {
            InitializeComponent();
        }

        public FrmDocumentoRelacionado(DocumentoRelacionado documentoRelacionado)
        {
            InitializeComponent();
            documentoRelacionadoBindingSource.DataSource = documentoRelacionado;
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

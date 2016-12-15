using System.Linq;
using System.Windows.Forms;
using OpenInvoicePeru.Comun.Dto.Modelos;
using OpenInvoicePeru.Datos;

namespace OpenInvoicePeru.WinApp
{
    public partial class FrmDatosGuia : PlantillaBase
    {
        private readonly DatosGuia _datosGuia;

        public FrmDatosGuia()
        {
            InitializeComponent();
        }

        public FrmDatosGuia(DatosGuia datosGuia)
        {
            InitializeComponent();
            _datosGuia = datosGuia;

            datosGuiaBindingSource.DataSource = _datosGuia;
            datosGuiaBindingSource.ResetBindings(false);

            Load += (s, e) =>
            {
                using (var ctx = new OpenInvoicePeruDb())
                {
                    tipoDocumentoContribuyenteBindingSource.DataSource = ctx.TipoDocumentoContribuyentes.ToList(); 
                    tipoDocumentoContribuyenteBindingSource.ResetBindings(false);

                    modalidadTransporteBindingSource.DataSource = ctx.ModalidadTransportes.ToList();
                    modalidadTransporteBindingSource.ResetBindings(false);
                }
            };

            toolOk.Click += (s, e) =>
            {
                datosGuiaBindingSource.EndEdit();
                _datosGuia.UnidadMedida = unidadMedidaComboBox.Text;
                
                DialogResult = DialogResult.OK;
            };

            toolCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }
    }
}

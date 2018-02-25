using System.Windows.Forms;

namespace OpenInvoicePeru.WinApp
{
    partial class FrmDocumento
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            ComponentFactory.Krypton.Toolkit.KryptonLabel montoEnLetrasLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel gravadasLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel exoneradasLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel inafectasLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel gratuitasLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel tipoOperacionLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel totalIgvLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel totalIscLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel totalOtrosTributosLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel totalVentaLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel calculoIgvLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel calculoIscLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel calculoDetraccionLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel urbanizacionLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel descuentoGlobalLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel montoPercepcionLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel montoDetraccionLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel tipoDocAnticipoLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel docAnticipoLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel montoAnticipoLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel monedaAnticipoLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel placaVehiculoLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboTipoDocRec = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.receptorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipoDocumentoContribuyenteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtNroDocEm = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.emisorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grpEmisor = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.txtDptoEm = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.urbanizacionTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtUbigeoEm = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtDistritoEm = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtProvEm = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtDirEm = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtNombreComEm = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtNombreLegalEm = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.grpReceptor = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.label16 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label17 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtNombreLegalRec = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtNroDocRec = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.textBox17 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.documentoElectronicoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label18 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label19 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtpFecha = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.label20 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboTipoDoc = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.tipoDocumentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label21 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboMoneda = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.monedaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvDetalle = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.idDataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.codigoItemDataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.unidadMedidaDataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.precioUnitarioDataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.precioReferencialDataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.tipoPrecioDataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Descuento = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.impuestoDataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.tipoImpuestoDataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.impuestoSelectivoDataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.otroImpuestoDataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.totalVentaDataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.detallesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.montoEnLetrasTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.gravadasTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.exoneradasTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.inafectasTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.gratuitasTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tipoOperacionComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.tipoOperacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.totalIgvTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.totalIscTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.totalOtrosTributosTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.totalVentaTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnAgregar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnEliminar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolGenerar = new System.Windows.Forms.ToolStripButton();
            this.calculoIgvTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.calculoIscTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.calculoDetraccionTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnDuplicar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.descuentoGlobalTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.montoPercepcionTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tbPaginas = new System.Windows.Forms.TabControl();
            this.tpDetalles = new System.Windows.Forms.TabPage();
            this.tpAdicionales = new System.Windows.Forms.TabPage();
            this.datoAdicionalesDataGridView = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.dataGridViewTextBoxColumn1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.datoAdicionalesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tpRelacionados = new System.Windows.Forms.TabPage();
            this.relacionadosDataGridView = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.dataGridViewTextBoxColumn4 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.relacionadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbDiscrepancias = new System.Windows.Forms.TabPage();
            this.discrepanciasDataGridView = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.dataGridViewTextBoxColumn5 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.discrepanciasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.montoDetraccionTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnCalcDetraccion = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnGuia = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.groupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.monedaAnticipoComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.montoAnticipoTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.docAnticipoTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tipoDocAnticipoComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.tipoDocumentoAnticipoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.placaVehiculoTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            montoEnLetrasLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            gravadasLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            exoneradasLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            inafectasLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            gratuitasLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            tipoOperacionLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            totalIgvLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            totalIscLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            totalOtrosTributosLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            totalVentaLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            calculoIgvLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            calculoIscLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            calculoDetraccionLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            urbanizacionLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            descuentoGlobalLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            montoPercepcionLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            montoDetraccionLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            tipoDocAnticipoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            docAnticipoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            montoAnticipoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            monedaAnticipoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            placaVehiculoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoDocRec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receptorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDocumentoContribuyenteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emisorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpEmisor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpEmisor.Panel)).BeginInit();
            this.grpEmisor.Panel.SuspendLayout();
            this.grpEmisor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpReceptor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpReceptor.Panel)).BeginInit();
            this.grpReceptor.Panel.SuspendLayout();
            this.grpReceptor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentoElectronicoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDocumentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monedaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detallesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoOperacionComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoOperacionBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tbPaginas.SuspendLayout();
            this.tpDetalles.SuspendLayout();
            this.tpAdicionales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datoAdicionalesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datoAdicionalesBindingSource)).BeginInit();
            this.tpRelacionados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.relacionadosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.relacionadosBindingSource)).BeginInit();
            this.tbDiscrepancias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discrepanciasDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discrepanciasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1.Panel)).BeginInit();
            this.groupBox1.Panel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monedaAnticipoComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDocAnticipoComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDocumentoAnticipoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // montoEnLetrasLabel
            // 
            montoEnLetrasLabel.Location = new System.Drawing.Point(206, 264);
            montoEnLetrasLabel.Name = "montoEnLetrasLabel";
            montoEnLetrasLabel.Size = new System.Drawing.Size(102, 20);
            montoEnLetrasLabel.TabIndex = 21;
            montoEnLetrasLabel.Values.Text = "Monto En Letras:";
            // 
            // gravadasLabel
            // 
            gravadasLabel.Location = new System.Drawing.Point(11, 548);
            gravadasLabel.Name = "gravadasLabel";
            gravadasLabel.Size = new System.Drawing.Size(63, 20);
            gravadasLabel.TabIndex = 36;
            gravadasLabel.Values.Text = "Gravadas:";
            // 
            // exoneradasLabel
            // 
            exoneradasLabel.Location = new System.Drawing.Point(11, 574);
            exoneradasLabel.Name = "exoneradasLabel";
            exoneradasLabel.Size = new System.Drawing.Size(75, 20);
            exoneradasLabel.TabIndex = 38;
            exoneradasLabel.Values.Text = "Exoneradas:";
            // 
            // inafectasLabel
            // 
            inafectasLabel.Location = new System.Drawing.Point(11, 600);
            inafectasLabel.Name = "inafectasLabel";
            inafectasLabel.Size = new System.Drawing.Size(62, 20);
            inafectasLabel.TabIndex = 40;
            inafectasLabel.Values.Text = "Inafectas:";
            // 
            // gratuitasLabel
            // 
            gratuitasLabel.Location = new System.Drawing.Point(11, 626);
            gratuitasLabel.Name = "gratuitasLabel";
            gratuitasLabel.Size = new System.Drawing.Size(62, 20);
            gratuitasLabel.TabIndex = 42;
            gratuitasLabel.Values.Text = "Gratuitas:";
            // 
            // tipoOperacionLabel
            // 
            tipoOperacionLabel.Location = new System.Drawing.Point(206, 229);
            tipoOperacionLabel.Name = "tipoOperacionLabel";
            tipoOperacionLabel.Size = new System.Drawing.Size(97, 20);
            tipoOperacionLabel.TabIndex = 19;
            tipoOperacionLabel.Values.Text = "Tipo Operación:";
            // 
            // totalIgvLabel
            // 
            totalIgvLabel.Location = new System.Drawing.Point(663, 548);
            totalIgvLabel.Name = "totalIgvLabel";
            totalIgvLabel.Size = new System.Drawing.Size(63, 20);
            totalIgvLabel.TabIndex = 44;
            totalIgvLabel.Values.Text = "Total IGV:";
            // 
            // totalIscLabel
            // 
            totalIscLabel.Location = new System.Drawing.Point(663, 574);
            totalIscLabel.Name = "totalIscLabel";
            totalIscLabel.Size = new System.Drawing.Size(61, 20);
            totalIscLabel.TabIndex = 46;
            totalIscLabel.Values.Text = "Total ISC:";
            // 
            // totalOtrosTributosLabel
            // 
            totalOtrosTributosLabel.Location = new System.Drawing.Point(663, 600);
            totalOtrosTributosLabel.Name = "totalOtrosTributosLabel";
            totalOtrosTributosLabel.Size = new System.Drawing.Size(122, 20);
            totalOtrosTributosLabel.TabIndex = 48;
            totalOtrosTributosLabel.Values.Text = "Total Otros Tributos:";
            // 
            // totalVentaLabel
            // 
            totalVentaLabel.Location = new System.Drawing.Point(663, 626);
            totalVentaLabel.Name = "totalVentaLabel";
            totalVentaLabel.Size = new System.Drawing.Size(75, 20);
            totalVentaLabel.TabIndex = 50;
            totalVentaLabel.Values.Text = "Total Venta:";
            // 
            // calculoIgvLabel
            // 
            calculoIgvLabel.Location = new System.Drawing.Point(308, 6);
            calculoIgvLabel.Name = "calculoIgvLabel";
            calculoIgvLabel.Size = new System.Drawing.Size(76, 20);
            calculoIgvLabel.TabIndex = 2;
            calculoIgvLabel.Values.Text = "Cálculo IGV:";
            // 
            // calculoIscLabel
            // 
            calculoIscLabel.Location = new System.Drawing.Point(450, 5);
            calculoIscLabel.Name = "calculoIscLabel";
            calculoIscLabel.Size = new System.Drawing.Size(74, 20);
            calculoIscLabel.TabIndex = 4;
            calculoIscLabel.Values.Text = "Cálculo ISC:";
            // 
            // calculoDetraccionLabel
            // 
            calculoDetraccionLabel.Location = new System.Drawing.Point(586, 6);
            calculoDetraccionLabel.Name = "calculoDetraccionLabel";
            calculoDetraccionLabel.Size = new System.Drawing.Size(115, 20);
            calculoDetraccionLabel.TabIndex = 6;
            calculoDetraccionLabel.Values.Text = "Cálculo Detracción:";
            // 
            // urbanizacionLabel
            // 
            urbanizacionLabel.Location = new System.Drawing.Point(304, 13);
            urbanizacionLabel.Name = "urbanizacionLabel";
            urbanizacionLabel.Size = new System.Drawing.Size(84, 20);
            urbanizacionLabel.TabIndex = 9;
            urbanizacionLabel.Values.Text = "Urbanización:";
            // 
            // descuentoGlobalLabel
            // 
            descuentoGlobalLabel.Location = new System.Drawing.Point(206, 295);
            descuentoGlobalLabel.Name = "descuentoGlobalLabel";
            descuentoGlobalLabel.Size = new System.Drawing.Size(80, 20);
            descuentoGlobalLabel.TabIndex = 23;
            descuentoGlobalLabel.Values.Text = "Dcto. Global:";
            // 
            // montoPercepcionLabel
            // 
            montoPercepcionLabel.Location = new System.Drawing.Point(549, 229);
            montoPercepcionLabel.Name = "montoPercepcionLabel";
            montoPercepcionLabel.Size = new System.Drawing.Size(113, 20);
            montoPercepcionLabel.TabIndex = 26;
            montoPercepcionLabel.Values.Text = "Monto Percepción:";
            // 
            // montoDetraccionLabel
            // 
            montoDetraccionLabel.Location = new System.Drawing.Point(549, 264);
            montoDetraccionLabel.Name = "montoDetraccionLabel";
            montoDetraccionLabel.Size = new System.Drawing.Size(112, 20);
            montoDetraccionLabel.TabIndex = 28;
            montoDetraccionLabel.Values.Text = "Monto Detracción:";
            // 
            // tipoDocAnticipoLabel
            // 
            tipoDocAnticipoLabel.Location = new System.Drawing.Point(8, 6);
            tipoDocAnticipoLabel.Name = "tipoDocAnticipoLabel";
            tipoDocAnticipoLabel.Size = new System.Drawing.Size(111, 20);
            tipoDocAnticipoLabel.TabIndex = 0;
            tipoDocAnticipoLabel.Values.Text = "Tipo Doc Anticipo:";
            // 
            // docAnticipoLabel
            // 
            docAnticipoLabel.Location = new System.Drawing.Point(8, 29);
            docAnticipoLabel.Name = "docAnticipoLabel";
            docAnticipoLabel.Size = new System.Drawing.Size(84, 20);
            docAnticipoLabel.TabIndex = 2;
            docAnticipoLabel.Values.Text = "Doc Anticipo:";
            // 
            // montoAnticipoLabel
            // 
            montoAnticipoLabel.Location = new System.Drawing.Point(8, 53);
            montoAnticipoLabel.Name = "montoAnticipoLabel";
            montoAnticipoLabel.Size = new System.Drawing.Size(99, 20);
            montoAnticipoLabel.TabIndex = 4;
            montoAnticipoLabel.Values.Text = "Monto Anticipo:";
            // 
            // monedaAnticipoLabel
            // 
            monedaAnticipoLabel.Location = new System.Drawing.Point(8, 77);
            monedaAnticipoLabel.Name = "monedaAnticipoLabel";
            monedaAnticipoLabel.Size = new System.Drawing.Size(107, 20);
            monedaAnticipoLabel.TabIndex = 6;
            monedaAnticipoLabel.Values.Text = "Moneda Anticipo:";
            // 
            // placaVehiculoLabel
            // 
            placaVehiculoLabel.Location = new System.Drawing.Point(778, 6);
            placaVehiculoLabel.Name = "placaVehiculoLabel";
            placaVehiculoLabel.Size = new System.Drawing.Size(92, 20);
            placaVehiculoLabel.TabIndex = 8;
            placaVehiculoLabel.Values.Text = "Placa Vehiculo:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(37, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 0;
            this.label1.Values.Text = "Tipo Doc:";
            // 
            // cboTipoDocRec
            // 
            this.cboTipoDocRec.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.receptorBindingSource, "TipoDocumento", true));
            this.cboTipoDocRec.DataSource = this.tipoDocumentoContribuyenteBindingSource;
            this.cboTipoDocRec.DisplayMember = "DescripcionCompleta";
            this.cboTipoDocRec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDocRec.DropDownWidth = 194;
            this.cboTipoDocRec.FormattingEnabled = true;
            this.cboTipoDocRec.Location = new System.Drawing.Point(138, 8);
            this.cboTipoDocRec.Name = "cboTipoDocRec";
            this.cboTipoDocRec.Size = new System.Drawing.Size(194, 21);
            this.cboTipoDocRec.TabIndex = 1;
            this.cboTipoDocRec.ValueMember = "Codigo";
            // 
            // receptorBindingSource
            // 
            this.receptorBindingSource.DataSource = typeof(OpenInvoicePeru.Comun.Dto.Modelos.Contribuyente);
            // 
            // tipoDocumentoContribuyenteBindingSource
            // 
            this.tipoDocumentoContribuyenteBindingSource.DataSource = typeof(OpenInvoicePeru.Entidades.TipoDocumentoContribuyente);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 0;
            this.label2.Values.Text = "Nro. Doc:";
            // 
            // txtNroDocEm
            // 
            this.txtNroDocEm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.emisorBindingSource, "NroDocumento", true));
            this.txtNroDocEm.Location = new System.Drawing.Point(201, 10);
            this.txtNroDocEm.MaxLength = 11;
            this.txtNroDocEm.Name = "txtNroDocEm";
            this.txtNroDocEm.Size = new System.Drawing.Size(100, 23);
            this.txtNroDocEm.TabIndex = 1;
            // 
            // emisorBindingSource
            // 
            this.emisorBindingSource.DataSource = typeof(OpenInvoicePeru.Comun.Dto.Modelos.Contribuyente);
            // 
            // grpEmisor
            // 
            this.grpEmisor.Location = new System.Drawing.Point(7, 31);
            this.grpEmisor.Name = "grpEmisor";
            // 
            // grpEmisor.Panel
            // 
            this.grpEmisor.Panel.Controls.Add(this.txtDptoEm);
            this.grpEmisor.Panel.Controls.Add(this.urbanizacionTextBox);
            this.grpEmisor.Panel.Controls.Add(urbanizacionLabel);
            this.grpEmisor.Panel.Controls.Add(this.label9);
            this.grpEmisor.Panel.Controls.Add(this.label8);
            this.grpEmisor.Panel.Controls.Add(this.label7);
            this.grpEmisor.Panel.Controls.Add(this.label6);
            this.grpEmisor.Panel.Controls.Add(this.label5);
            this.grpEmisor.Panel.Controls.Add(this.label3);
            this.grpEmisor.Panel.Controls.Add(this.label2);
            this.grpEmisor.Panel.Controls.Add(this.txtUbigeoEm);
            this.grpEmisor.Panel.Controls.Add(this.txtDistritoEm);
            this.grpEmisor.Panel.Controls.Add(this.txtProvEm);
            this.grpEmisor.Panel.Controls.Add(this.txtDirEm);
            this.grpEmisor.Panel.Controls.Add(this.txtNombreComEm);
            this.grpEmisor.Panel.Controls.Add(this.txtNombreLegalEm);
            this.grpEmisor.Panel.Controls.Add(this.txtNroDocEm);
            this.grpEmisor.Panel.Controls.Add(this.label4);
            this.grpEmisor.Size = new System.Drawing.Size(507, 179);
            this.grpEmisor.TabIndex = 11;
            this.grpEmisor.Values.Heading = "Datos del Emisor";
            // 
            // txtDptoEm
            // 
            this.txtDptoEm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.emisorBindingSource, "Departamento", true));
            this.txtDptoEm.Location = new System.Drawing.Point(391, 36);
            this.txtDptoEm.Name = "txtDptoEm";
            this.txtDptoEm.Size = new System.Drawing.Size(100, 23);
            this.txtDptoEm.TabIndex = 12;
            // 
            // urbanizacionTextBox
            // 
            this.urbanizacionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.emisorBindingSource, "Urbanizacion", true));
            this.urbanizacionTextBox.Location = new System.Drawing.Point(391, 10);
            this.urbanizacionTextBox.Name = "urbanizacionTextBox";
            this.urbanizacionTextBox.Size = new System.Drawing.Size(100, 23);
            this.urbanizacionTextBox.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(5, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 20);
            this.label9.TabIndex = 6;
            this.label9.Values.Text = "Ubigeo:";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(306, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 20);
            this.label8.TabIndex = 15;
            this.label8.Values.Text = "Distrito:";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(306, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 20);
            this.label7.TabIndex = 11;
            this.label7.Values.Text = "Departamento:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(306, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 13;
            this.label6.Values.Text = "Provincia:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(5, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 8;
            this.label5.Values.Text = "Dirección:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 2;
            this.label3.Values.Text = "Nombre Legal:";
            // 
            // txtUbigeoEm
            // 
            this.txtUbigeoEm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.emisorBindingSource, "Ubigeo", true));
            this.txtUbigeoEm.Location = new System.Drawing.Point(201, 91);
            this.txtUbigeoEm.Name = "txtUbigeoEm";
            this.txtUbigeoEm.Size = new System.Drawing.Size(100, 23);
            this.txtUbigeoEm.TabIndex = 7;
            // 
            // txtDistritoEm
            // 
            this.txtDistritoEm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.emisorBindingSource, "Distrito", true));
            this.txtDistritoEm.Location = new System.Drawing.Point(391, 90);
            this.txtDistritoEm.Name = "txtDistritoEm";
            this.txtDistritoEm.Size = new System.Drawing.Size(100, 23);
            this.txtDistritoEm.TabIndex = 16;
            // 
            // txtProvEm
            // 
            this.txtProvEm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.emisorBindingSource, "Provincia", true));
            this.txtProvEm.Location = new System.Drawing.Point(391, 61);
            this.txtProvEm.Name = "txtProvEm";
            this.txtProvEm.Size = new System.Drawing.Size(100, 23);
            this.txtProvEm.TabIndex = 14;
            // 
            // txtDirEm
            // 
            this.txtDirEm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.emisorBindingSource, "Direccion", true));
            this.txtDirEm.Location = new System.Drawing.Point(110, 120);
            this.txtDirEm.Name = "txtDirEm";
            this.txtDirEm.Size = new System.Drawing.Size(191, 23);
            this.txtDirEm.TabIndex = 8;
            // 
            // txtNombreComEm
            // 
            this.txtNombreComEm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.emisorBindingSource, "NombreComercial", true));
            this.txtNombreComEm.Location = new System.Drawing.Point(110, 61);
            this.txtNombreComEm.Name = "txtNombreComEm";
            this.txtNombreComEm.Size = new System.Drawing.Size(191, 23);
            this.txtNombreComEm.TabIndex = 5;
            // 
            // txtNombreLegalEm
            // 
            this.txtNombreLegalEm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.emisorBindingSource, "NombreLegal", true));
            this.txtNombreLegalEm.Location = new System.Drawing.Point(110, 36);
            this.txtNombreLegalEm.Name = "txtNombreLegalEm";
            this.txtNombreLegalEm.Size = new System.Drawing.Size(191, 23);
            this.txtNombreLegalEm.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(5, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 20);
            this.label4.TabIndex = 4;
            this.label4.Values.Text = "Nombre Comercial:";
            // 
            // grpReceptor
            // 
            this.grpReceptor.Location = new System.Drawing.Point(518, 31);
            this.grpReceptor.Name = "grpReceptor";
            // 
            // grpReceptor.Panel
            // 
            this.grpReceptor.Panel.Controls.Add(this.cboTipoDocRec);
            this.grpReceptor.Panel.Controls.Add(this.label1);
            this.grpReceptor.Panel.Controls.Add(this.label16);
            this.grpReceptor.Panel.Controls.Add(this.label17);
            this.grpReceptor.Panel.Controls.Add(this.txtNombreLegalRec);
            this.grpReceptor.Panel.Controls.Add(this.txtNroDocRec);
            this.grpReceptor.Size = new System.Drawing.Size(452, 179);
            this.grpReceptor.TabIndex = 12;
            this.grpReceptor.Values.Heading = "Datos del Receptor";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(37, 64);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(91, 20);
            this.label16.TabIndex = 4;
            this.label16.Values.Text = "Nombre Legal:";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(37, 38);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 20);
            this.label17.TabIndex = 2;
            this.label17.Values.Text = "Nro. Doc.:";
            // 
            // txtNombreLegalRec
            // 
            this.txtNombreLegalRec.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.receptorBindingSource, "NombreLegal", true));
            this.txtNombreLegalRec.Location = new System.Drawing.Point(138, 61);
            this.txtNombreLegalRec.Name = "txtNombreLegalRec";
            this.txtNombreLegalRec.Size = new System.Drawing.Size(194, 23);
            this.txtNombreLegalRec.TabIndex = 5;
            // 
            // txtNroDocRec
            // 
            this.txtNroDocRec.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.receptorBindingSource, "NroDocumento", true));
            this.txtNroDocRec.Location = new System.Drawing.Point(232, 35);
            this.txtNroDocRec.MaxLength = 11;
            this.txtNroDocRec.Name = "txtNroDocRec";
            this.txtNroDocRec.Size = new System.Drawing.Size(100, 23);
            this.txtNroDocRec.TabIndex = 3;
            // 
            // textBox17
            // 
            this.textBox17.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "IdDocumento", true));
            this.textBox17.Location = new System.Drawing.Point(101, 226);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(100, 23);
            this.textBox17.TabIndex = 14;
            // 
            // documentoElectronicoBindingSource
            // 
            this.documentoElectronicoBindingSource.DataSource = typeof(OpenInvoicePeru.Comun.Dto.Modelos.DocumentoElectronico);
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(14, 229);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(91, 20);
            this.label18.TabIndex = 13;
            this.label18.Values.Text = "Id Documento:";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(14, 261);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(90, 20);
            this.label19.TabIndex = 15;
            this.label19.Values.Text = "Fecha Emisión:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "FechaEmision", true));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(101, 258);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(100, 21);
            this.dtpFecha.TabIndex = 16;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(3, 6);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(122, 20);
            this.label20.TabIndex = 0;
            this.label20.Values.Text = "Tipo de Documento:";
            // 
            // cboTipoDoc
            // 
            this.cboTipoDoc.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.documentoElectronicoBindingSource, "TipoDocumento", true));
            this.cboTipoDoc.DataSource = this.tipoDocumentoBindingSource;
            this.cboTipoDoc.DisplayMember = "Descripcion";
            this.cboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDoc.DropDownWidth = 175;
            this.cboTipoDoc.FormattingEnabled = true;
            this.cboTipoDoc.Location = new System.Drawing.Point(126, 3);
            this.cboTipoDoc.Name = "cboTipoDoc";
            this.cboTipoDoc.Size = new System.Drawing.Size(175, 21);
            this.cboTipoDoc.TabIndex = 1;
            this.cboTipoDoc.ValueMember = "Codigo";
            // 
            // tipoDocumentoBindingSource
            // 
            this.tipoDocumentoBindingSource.DataSource = typeof(OpenInvoicePeru.Entidades.TipoDocumento);
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(14, 292);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(59, 20);
            this.label21.TabIndex = 17;
            this.label21.Values.Text = "Moneda:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.documentoElectronicoBindingSource, "Moneda", true));
            this.cboMoneda.DataSource = this.monedaBindingSource;
            this.cboMoneda.DisplayMember = "Descripcion";
            this.cboMoneda.DropDownWidth = 100;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(101, 289);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(100, 21);
            this.cboMoneda.TabIndex = 18;
            this.cboMoneda.ValueMember = "Codigo";
            // 
            // monedaBindingSource
            // 
            this.monedaBindingSource.DataSource = typeof(OpenInvoicePeru.Entidades.Moneda);
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AutoGenerateColumns = false;
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.codigoItemDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn,
            this.unidadMedidaDataGridViewTextBoxColumn,
            this.precioUnitarioDataGridViewTextBoxColumn,
            this.precioReferencialDataGridViewTextBoxColumn,
            this.tipoPrecioDataGridViewTextBoxColumn,
            this.Descuento,
            this.impuestoDataGridViewTextBoxColumn,
            this.tipoImpuestoDataGridViewTextBoxColumn,
            this.impuestoSelectivoDataGridViewTextBoxColumn,
            this.otroImpuestoDataGridViewTextBoxColumn,
            this.totalVentaDataGridViewTextBoxColumn});
            this.dgvDetalle.DataSource = this.detallesBindingSource;
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.Location = new System.Drawing.Point(3, 3);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(868, 156);
            this.dgvDetalle.TabIndex = 25;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Width = 46;
            // 
            // codigoItemDataGridViewTextBoxColumn
            // 
            this.codigoItemDataGridViewTextBoxColumn.DataPropertyName = "CodigoItem";
            this.codigoItemDataGridViewTextBoxColumn.HeaderText = "Codigo Item";
            this.codigoItemDataGridViewTextBoxColumn.Name = "codigoItemDataGridViewTextBoxColumn";
            this.codigoItemDataGridViewTextBoxColumn.Width = 102;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.Width = 98;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.cantidadDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.Width = 84;
            // 
            // unidadMedidaDataGridViewTextBoxColumn
            // 
            this.unidadMedidaDataGridViewTextBoxColumn.DataPropertyName = "UnidadMedida";
            this.unidadMedidaDataGridViewTextBoxColumn.HeaderText = "Unidad Medida";
            this.unidadMedidaDataGridViewTextBoxColumn.Name = "unidadMedidaDataGridViewTextBoxColumn";
            this.unidadMedidaDataGridViewTextBoxColumn.Width = 117;
            // 
            // precioUnitarioDataGridViewTextBoxColumn
            // 
            this.precioUnitarioDataGridViewTextBoxColumn.DataPropertyName = "PrecioUnitario";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.precioUnitarioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.precioUnitarioDataGridViewTextBoxColumn.HeaderText = "Precio Unitario";
            this.precioUnitarioDataGridViewTextBoxColumn.Name = "precioUnitarioDataGridViewTextBoxColumn";
            this.precioUnitarioDataGridViewTextBoxColumn.Width = 114;
            // 
            // precioReferencialDataGridViewTextBoxColumn
            // 
            this.precioReferencialDataGridViewTextBoxColumn.DataPropertyName = "PrecioReferencial";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.precioReferencialDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.precioReferencialDataGridViewTextBoxColumn.HeaderText = "Precio Referencial";
            this.precioReferencialDataGridViewTextBoxColumn.Name = "precioReferencialDataGridViewTextBoxColumn";
            this.precioReferencialDataGridViewTextBoxColumn.Width = 130;
            // 
            // tipoPrecioDataGridViewTextBoxColumn
            // 
            this.tipoPrecioDataGridViewTextBoxColumn.DataPropertyName = "TipoPrecio";
            this.tipoPrecioDataGridViewTextBoxColumn.HeaderText = "Tipo Precio";
            this.tipoPrecioDataGridViewTextBoxColumn.Name = "tipoPrecioDataGridViewTextBoxColumn";
            this.tipoPrecioDataGridViewTextBoxColumn.Width = 96;
            // 
            // Descuento
            // 
            this.Descuento.DataPropertyName = "Descuento";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.Descuento.DefaultCellStyle = dataGridViewCellStyle4;
            this.Descuento.HeaderText = "Descuento";
            this.Descuento.Name = "Descuento";
            this.Descuento.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Descuento.Width = 92;
            // 
            // impuestoDataGridViewTextBoxColumn
            // 
            this.impuestoDataGridViewTextBoxColumn.DataPropertyName = "Impuesto";
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.impuestoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.impuestoDataGridViewTextBoxColumn.HeaderText = "Impuesto";
            this.impuestoDataGridViewTextBoxColumn.Name = "impuestoDataGridViewTextBoxColumn";
            this.impuestoDataGridViewTextBoxColumn.Width = 86;
            // 
            // tipoImpuestoDataGridViewTextBoxColumn
            // 
            this.tipoImpuestoDataGridViewTextBoxColumn.DataPropertyName = "TipoImpuesto";
            this.tipoImpuestoDataGridViewTextBoxColumn.HeaderText = "Tipo Impuesto";
            this.tipoImpuestoDataGridViewTextBoxColumn.Name = "tipoImpuestoDataGridViewTextBoxColumn";
            this.tipoImpuestoDataGridViewTextBoxColumn.Width = 113;
            // 
            // impuestoSelectivoDataGridViewTextBoxColumn
            // 
            this.impuestoSelectivoDataGridViewTextBoxColumn.DataPropertyName = "ImpuestoSelectivo";
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.impuestoSelectivoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.impuestoSelectivoDataGridViewTextBoxColumn.HeaderText = "Impuesto Selectivo";
            this.impuestoSelectivoDataGridViewTextBoxColumn.Name = "impuestoSelectivoDataGridViewTextBoxColumn";
            this.impuestoSelectivoDataGridViewTextBoxColumn.Width = 136;
            // 
            // otroImpuestoDataGridViewTextBoxColumn
            // 
            this.otroImpuestoDataGridViewTextBoxColumn.DataPropertyName = "OtroImpuesto";
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.otroImpuestoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.otroImpuestoDataGridViewTextBoxColumn.HeaderText = "Otro Impuesto";
            this.otroImpuestoDataGridViewTextBoxColumn.Name = "otroImpuestoDataGridViewTextBoxColumn";
            this.otroImpuestoDataGridViewTextBoxColumn.Width = 113;
            // 
            // totalVentaDataGridViewTextBoxColumn
            // 
            this.totalVentaDataGridViewTextBoxColumn.DataPropertyName = "TotalVenta";
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.totalVentaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.totalVentaDataGridViewTextBoxColumn.HeaderText = "Total Venta";
            this.totalVentaDataGridViewTextBoxColumn.Name = "totalVentaDataGridViewTextBoxColumn";
            this.totalVentaDataGridViewTextBoxColumn.Width = 94;
            // 
            // detallesBindingSource
            // 
            this.detallesBindingSource.DataMember = "Items";
            this.detallesBindingSource.DataSource = this.documentoElectronicoBindingSource;
            // 
            // montoEnLetrasTextBox
            // 
            this.montoEnLetrasTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "MontoEnLetras", true));
            this.montoEnLetrasTextBox.Location = new System.Drawing.Point(300, 261);
            this.montoEnLetrasTextBox.Name = "montoEnLetrasTextBox";
            this.montoEnLetrasTextBox.Size = new System.Drawing.Size(244, 23);
            this.montoEnLetrasTextBox.TabIndex = 22;
            // 
            // gravadasTextBox
            // 
            this.gravadasTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "Gravadas", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.gravadasTextBox.Location = new System.Drawing.Point(92, 545);
            this.gravadasTextBox.Name = "gravadasTextBox";
            this.gravadasTextBox.Size = new System.Drawing.Size(100, 23);
            this.gravadasTextBox.TabIndex = 37;
            // 
            // exoneradasTextBox
            // 
            this.exoneradasTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "Exoneradas", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.exoneradasTextBox.Location = new System.Drawing.Point(92, 571);
            this.exoneradasTextBox.Name = "exoneradasTextBox";
            this.exoneradasTextBox.Size = new System.Drawing.Size(100, 23);
            this.exoneradasTextBox.TabIndex = 39;
            // 
            // inafectasTextBox
            // 
            this.inafectasTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "Inafectas", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.inafectasTextBox.Location = new System.Drawing.Point(92, 597);
            this.inafectasTextBox.Name = "inafectasTextBox";
            this.inafectasTextBox.Size = new System.Drawing.Size(100, 23);
            this.inafectasTextBox.TabIndex = 41;
            // 
            // gratuitasTextBox
            // 
            this.gratuitasTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "Gratuitas", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.gratuitasTextBox.Location = new System.Drawing.Point(92, 623);
            this.gratuitasTextBox.Name = "gratuitasTextBox";
            this.gratuitasTextBox.Size = new System.Drawing.Size(100, 23);
            this.gratuitasTextBox.TabIndex = 43;
            // 
            // tipoOperacionComboBox
            // 
            this.tipoOperacionComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.documentoElectronicoBindingSource, "TipoOperacion", true));
            this.tipoOperacionComboBox.DataSource = this.tipoOperacionBindingSource;
            this.tipoOperacionComboBox.DisplayMember = "DescripcionCompleta";
            this.tipoOperacionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoOperacionComboBox.DropDownWidth = 242;
            this.tipoOperacionComboBox.FormattingEnabled = true;
            this.tipoOperacionComboBox.Location = new System.Drawing.Point(300, 225);
            this.tipoOperacionComboBox.Name = "tipoOperacionComboBox";
            this.tipoOperacionComboBox.Size = new System.Drawing.Size(242, 21);
            this.tipoOperacionComboBox.TabIndex = 20;
            this.tipoOperacionComboBox.ValueMember = "Codigo";
            // 
            // tipoOperacionBindingSource
            // 
            this.tipoOperacionBindingSource.DataSource = typeof(OpenInvoicePeru.Entidades.TipoOperacion);
            // 
            // totalIgvTextBox
            // 
            this.totalIgvTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "TotalIgv", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.totalIgvTextBox.Location = new System.Drawing.Point(789, 545);
            this.totalIgvTextBox.Name = "totalIgvTextBox";
            this.totalIgvTextBox.Size = new System.Drawing.Size(100, 23);
            this.totalIgvTextBox.TabIndex = 45;
            // 
            // totalIscTextBox
            // 
            this.totalIscTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "TotalIsc", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.totalIscTextBox.Location = new System.Drawing.Point(789, 571);
            this.totalIscTextBox.Name = "totalIscTextBox";
            this.totalIscTextBox.Size = new System.Drawing.Size(100, 23);
            this.totalIscTextBox.TabIndex = 47;
            // 
            // totalOtrosTributosTextBox
            // 
            this.totalOtrosTributosTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "TotalOtrosTributos", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.totalOtrosTributosTextBox.Location = new System.Drawing.Point(789, 597);
            this.totalOtrosTributosTextBox.Name = "totalOtrosTributosTextBox";
            this.totalOtrosTributosTextBox.Size = new System.Drawing.Size(100, 23);
            this.totalOtrosTributosTextBox.TabIndex = 49;
            // 
            // totalVentaTextBox
            // 
            this.totalVentaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "TotalVenta", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.totalVentaTextBox.Location = new System.Drawing.Point(789, 623);
            this.totalVentaTextBox.Name = "totalVentaTextBox";
            this.totalVentaTextBox.Size = new System.Drawing.Size(100, 23);
            this.totalVentaTextBox.TabIndex = 51;
            // 
            // btnAgregar
            // 
            this.btnAgregar.AutoSize = true;
            this.btnAgregar.BackgroundImage = global::OpenInvoicePeru.WinApp.Properties.Resources.nuevo;
            this.btnAgregar.Location = new System.Drawing.Point(898, 413);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(88, 24);
            this.btnAgregar.TabIndex = 33;
            this.btnAgregar.Values.Image = global::OpenInvoicePeru.WinApp.Properties.Resources.nuevo;
            this.btnAgregar.Values.Text = "&Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.AutoSize = true;
            this.btnEliminar.BackgroundImage = global::OpenInvoicePeru.WinApp.Properties.Resources.delete;
            this.btnEliminar.Location = new System.Drawing.Point(898, 466);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(88, 24);
            this.btnEliminar.TabIndex = 35;
            this.btnEliminar.Values.Image = global::OpenInvoicePeru.WinApp.Properties.Resources.delete;
            this.btnEliminar.Values.Text = "&Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolGenerar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(998, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolGenerar
            // 
            this.toolGenerar.Image = global::OpenInvoicePeru.WinApp.Properties.Resources.iconxml;
            this.toolGenerar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolGenerar.Name = "toolGenerar";
            this.toolGenerar.Size = new System.Drawing.Size(95, 22);
            this.toolGenerar.Text = "&Generar XML";
            this.toolGenerar.Click += new System.EventHandler(this.toolGenerar_Click);
            // 
            // calculoIgvTextBox
            // 
            this.calculoIgvTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "CalculoIgv", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.calculoIgvTextBox.Location = new System.Drawing.Point(382, 3);
            this.calculoIgvTextBox.Name = "calculoIgvTextBox";
            this.calculoIgvTextBox.Size = new System.Drawing.Size(64, 23);
            this.calculoIgvTextBox.TabIndex = 3;
            // 
            // calculoIscTextBox
            // 
            this.calculoIscTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "CalculoIsc", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.calculoIscTextBox.Location = new System.Drawing.Point(518, 2);
            this.calculoIscTextBox.Name = "calculoIscTextBox";
            this.calculoIscTextBox.Size = new System.Drawing.Size(65, 23);
            this.calculoIscTextBox.TabIndex = 5;
            // 
            // calculoDetraccionTextBox
            // 
            this.calculoDetraccionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "CalculoDetraccion", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.calculoDetraccionTextBox.Location = new System.Drawing.Point(698, 3);
            this.calculoDetraccionTextBox.Name = "calculoDetraccionTextBox";
            this.calculoDetraccionTextBox.Size = new System.Drawing.Size(73, 23);
            this.calculoDetraccionTextBox.TabIndex = 7;
            // 
            // btnDuplicar
            // 
            this.btnDuplicar.AutoSize = true;
            this.btnDuplicar.BackgroundImage = global::OpenInvoicePeru.WinApp.Properties.Resources.iconcopy;
            this.btnDuplicar.Location = new System.Drawing.Point(898, 439);
            this.btnDuplicar.Name = "btnDuplicar";
            this.btnDuplicar.Size = new System.Drawing.Size(88, 24);
            this.btnDuplicar.TabIndex = 34;
            this.btnDuplicar.Values.Image = global::OpenInvoicePeru.WinApp.Properties.Resources.iconcopy;
            this.btnDuplicar.Values.Text = "&Duplicar";
            this.btnDuplicar.Click += new System.EventHandler(this.btnDuplicar_Click);
            // 
            // descuentoGlobalTextBox
            // 
            this.descuentoGlobalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "DescuentoGlobal", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.descuentoGlobalTextBox.Location = new System.Drawing.Point(300, 292);
            this.descuentoGlobalTextBox.Name = "descuentoGlobalTextBox";
            this.descuentoGlobalTextBox.Size = new System.Drawing.Size(89, 23);
            this.descuentoGlobalTextBox.TabIndex = 24;
            // 
            // montoPercepcionTextBox
            // 
            this.montoPercepcionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "MontoPercepcion", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.montoPercepcionTextBox.Location = new System.Drawing.Point(657, 226);
            this.montoPercepcionTextBox.Name = "montoPercepcionTextBox";
            this.montoPercepcionTextBox.Size = new System.Drawing.Size(88, 23);
            this.montoPercepcionTextBox.TabIndex = 27;
            // 
            // tbPaginas
            // 
            this.tbPaginas.Controls.Add(this.tpDetalles);
            this.tbPaginas.Controls.Add(this.tpAdicionales);
            this.tbPaginas.Controls.Add(this.tpRelacionados);
            this.tbPaginas.Controls.Add(this.tbDiscrepancias);
            this.tbPaginas.Location = new System.Drawing.Point(7, 351);
            this.tbPaginas.Name = "tbPaginas";
            this.tbPaginas.SelectedIndex = 0;
            this.tbPaginas.Size = new System.Drawing.Size(882, 188);
            this.tbPaginas.TabIndex = 32;
            // 
            // tpDetalles
            // 
            this.tpDetalles.Controls.Add(this.dgvDetalle);
            this.tpDetalles.Location = new System.Drawing.Point(4, 22);
            this.tpDetalles.Name = "tpDetalles";
            this.tpDetalles.Padding = new System.Windows.Forms.Padding(3);
            this.tpDetalles.Size = new System.Drawing.Size(874, 162);
            this.tpDetalles.TabIndex = 0;
            this.tpDetalles.Text = "Detalle de Documentos";
            this.tpDetalles.UseVisualStyleBackColor = true;
            // 
            // tpAdicionales
            // 
            this.tpAdicionales.AutoScroll = true;
            this.tpAdicionales.Controls.Add(this.datoAdicionalesDataGridView);
            this.tpAdicionales.Location = new System.Drawing.Point(4, 22);
            this.tpAdicionales.Name = "tpAdicionales";
            this.tpAdicionales.Padding = new System.Windows.Forms.Padding(3);
            this.tpAdicionales.Size = new System.Drawing.Size(874, 162);
            this.tpAdicionales.TabIndex = 1;
            this.tpAdicionales.Text = "Datos Adicionales";
            this.tpAdicionales.UseVisualStyleBackColor = true;
            // 
            // datoAdicionalesDataGridView
            // 
            this.datoAdicionalesDataGridView.AllowUserToAddRows = false;
            this.datoAdicionalesDataGridView.AutoGenerateColumns = false;
            this.datoAdicionalesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.datoAdicionalesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datoAdicionalesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.datoAdicionalesDataGridView.DataSource = this.datoAdicionalesBindingSource;
            this.datoAdicionalesDataGridView.Location = new System.Drawing.Point(1, 0);
            this.datoAdicionalesDataGridView.Name = "datoAdicionalesDataGridView";
            this.datoAdicionalesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datoAdicionalesDataGridView.Size = new System.Drawing.Size(870, 177);
            this.datoAdicionalesDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Codigo";
            this.dataGridViewTextBoxColumn1.HeaderText = "Codigo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 75;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Contenido";
            this.dataGridViewTextBoxColumn2.HeaderText = "Contenido";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 92;
            // 
            // datoAdicionalesBindingSource
            // 
            this.datoAdicionalesBindingSource.DataMember = "DatoAdicionales";
            this.datoAdicionalesBindingSource.DataSource = this.documentoElectronicoBindingSource;
            // 
            // tpRelacionados
            // 
            this.tpRelacionados.AutoScroll = true;
            this.tpRelacionados.Controls.Add(this.relacionadosDataGridView);
            this.tpRelacionados.Location = new System.Drawing.Point(4, 22);
            this.tpRelacionados.Name = "tpRelacionados";
            this.tpRelacionados.Padding = new System.Windows.Forms.Padding(3);
            this.tpRelacionados.Size = new System.Drawing.Size(874, 162);
            this.tpRelacionados.TabIndex = 2;
            this.tpRelacionados.Text = "Documentos Relacionados";
            this.tpRelacionados.UseVisualStyleBackColor = true;
            // 
            // relacionadosDataGridView
            // 
            this.relacionadosDataGridView.AllowUserToAddRows = false;
            this.relacionadosDataGridView.AllowUserToDeleteRows = false;
            this.relacionadosDataGridView.AutoGenerateColumns = false;
            this.relacionadosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.relacionadosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.relacionadosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn3});
            this.relacionadosDataGridView.DataSource = this.relacionadosBindingSource;
            this.relacionadosDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.relacionadosDataGridView.Location = new System.Drawing.Point(3, 3);
            this.relacionadosDataGridView.Name = "relacionadosDataGridView";
            this.relacionadosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.relacionadosDataGridView.Size = new System.Drawing.Size(868, 156);
            this.relacionadosDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TipoDocumento";
            this.dataGridViewTextBoxColumn4.HeaderText = "Tipo de Documento";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 130;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "NroDocumento";
            this.dataGridViewTextBoxColumn3.HeaderText = "Nro. Documento";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 115;
            // 
            // relacionadosBindingSource
            // 
            this.relacionadosBindingSource.DataMember = "Relacionados";
            this.relacionadosBindingSource.DataSource = this.documentoElectronicoBindingSource;
            // 
            // tbDiscrepancias
            // 
            this.tbDiscrepancias.AutoScroll = true;
            this.tbDiscrepancias.Controls.Add(this.discrepanciasDataGridView);
            this.tbDiscrepancias.Location = new System.Drawing.Point(4, 22);
            this.tbDiscrepancias.Name = "tbDiscrepancias";
            this.tbDiscrepancias.Padding = new System.Windows.Forms.Padding(3);
            this.tbDiscrepancias.Size = new System.Drawing.Size(874, 162);
            this.tbDiscrepancias.TabIndex = 3;
            this.tbDiscrepancias.Text = "Discrepancias";
            this.tbDiscrepancias.UseVisualStyleBackColor = true;
            // 
            // discrepanciasDataGridView
            // 
            this.discrepanciasDataGridView.AllowUserToAddRows = false;
            this.discrepanciasDataGridView.AllowUserToDeleteRows = false;
            this.discrepanciasDataGridView.AutoGenerateColumns = false;
            this.discrepanciasDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.discrepanciasDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.discrepanciasDataGridView.DataSource = this.discrepanciasBindingSource;
            this.discrepanciasDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.discrepanciasDataGridView.Location = new System.Drawing.Point(3, 3);
            this.discrepanciasDataGridView.Name = "discrepanciasDataGridView";
            this.discrepanciasDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.discrepanciasDataGridView.Size = new System.Drawing.Size(868, 156);
            this.discrepanciasDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "NroReferencia";
            this.dataGridViewTextBoxColumn5.HeaderText = "Nro. Referencia";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 117;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Tipo";
            this.dataGridViewTextBoxColumn6.HeaderText = "Tipo";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 60;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Descripcion";
            this.dataGridViewTextBoxColumn7.HeaderText = "Descripcion";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 98;
            // 
            // discrepanciasBindingSource
            // 
            this.discrepanciasBindingSource.DataMember = "Discrepancias";
            this.discrepanciasBindingSource.DataSource = this.documentoElectronicoBindingSource;
            // 
            // montoDetraccionTextBox
            // 
            this.montoDetraccionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "MontoDetraccion", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.montoDetraccionTextBox.Location = new System.Drawing.Point(657, 261);
            this.montoDetraccionTextBox.Name = "montoDetraccionTextBox";
            this.montoDetraccionTextBox.Size = new System.Drawing.Size(88, 23);
            this.montoDetraccionTextBox.TabIndex = 29;
            // 
            // btnCalcDetraccion
            // 
            this.btnCalcDetraccion.AutoSize = true;
            this.btnCalcDetraccion.Location = new System.Drawing.Point(625, 290);
            this.btnCalcDetraccion.Name = "btnCalcDetraccion";
            this.btnCalcDetraccion.Size = new System.Drawing.Size(120, 24);
            this.btnCalcDetraccion.TabIndex = 30;
            this.btnCalcDetraccion.Values.Text = "&Calcular Detracción";
            this.btnCalcDetraccion.Click += new System.EventHandler(this.btnCalcDetraccion_Click);
            // 
            // btnGuia
            // 
            this.btnGuia.AutoSize = true;
            this.btnGuia.Location = new System.Drawing.Point(395, 290);
            this.btnGuia.Name = "btnGuia";
            this.btnGuia.Size = new System.Drawing.Size(157, 24);
            this.btnGuia.TabIndex = 25;
            this.btnGuia.Values.Text = "G&uia de Rem. Transportista";
            this.btnGuia.Click += new System.EventHandler(this.btnGuia_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(752, 217);
            this.groupBox1.Name = "groupBox1";
            // 
            // groupBox1.Panel
            // 
            this.groupBox1.Panel.Controls.Add(this.monedaAnticipoComboBox);
            this.groupBox1.Panel.Controls.Add(this.montoAnticipoTextBox);
            this.groupBox1.Panel.Controls.Add(this.docAnticipoTextBox);
            this.groupBox1.Panel.Controls.Add(this.tipoDocAnticipoComboBox);
            this.groupBox1.Panel.Controls.Add(monedaAnticipoLabel);
            this.groupBox1.Panel.Controls.Add(montoAnticipoLabel);
            this.groupBox1.Panel.Controls.Add(docAnticipoLabel);
            this.groupBox1.Panel.Controls.Add(tipoDocAnticipoLabel);
            this.groupBox1.Size = new System.Drawing.Size(232, 128);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.Values.Heading = "Regularización de Anticipos";
            // 
            // monedaAnticipoComboBox
            // 
            this.monedaAnticipoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.documentoElectronicoBindingSource, "MonedaAnticipo", true));
            this.monedaAnticipoComboBox.DataSource = this.monedaBindingSource;
            this.monedaAnticipoComboBox.DisplayMember = "Descripcion";
            this.monedaAnticipoComboBox.DropDownWidth = 100;
            this.monedaAnticipoComboBox.FormattingEnabled = true;
            this.monedaAnticipoComboBox.Location = new System.Drawing.Point(116, 74);
            this.monedaAnticipoComboBox.Name = "monedaAnticipoComboBox";
            this.monedaAnticipoComboBox.Size = new System.Drawing.Size(100, 21);
            this.monedaAnticipoComboBox.TabIndex = 7;
            this.monedaAnticipoComboBox.ValueMember = "Codigo";
            // 
            // montoAnticipoTextBox
            // 
            this.montoAnticipoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "MontoAnticipo", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.montoAnticipoTextBox.Location = new System.Drawing.Point(116, 50);
            this.montoAnticipoTextBox.Name = "montoAnticipoTextBox";
            this.montoAnticipoTextBox.Size = new System.Drawing.Size(100, 23);
            this.montoAnticipoTextBox.TabIndex = 5;
            // 
            // docAnticipoTextBox
            // 
            this.docAnticipoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "DocAnticipo", true));
            this.docAnticipoTextBox.Location = new System.Drawing.Point(116, 26);
            this.docAnticipoTextBox.Name = "docAnticipoTextBox";
            this.docAnticipoTextBox.Size = new System.Drawing.Size(100, 23);
            this.docAnticipoTextBox.TabIndex = 3;
            // 
            // tipoDocAnticipoComboBox
            // 
            this.tipoDocAnticipoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.documentoElectronicoBindingSource, "TipoDocAnticipo", true));
            this.tipoDocAnticipoComboBox.DataSource = this.tipoDocumentoAnticipoBindingSource;
            this.tipoDocAnticipoComboBox.DisplayMember = "DescripcionCompleta";
            this.tipoDocAnticipoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoDocAnticipoComboBox.DropDownWidth = 360;
            this.tipoDocAnticipoComboBox.FormattingEnabled = true;
            this.tipoDocAnticipoComboBox.Location = new System.Drawing.Point(116, 3);
            this.tipoDocAnticipoComboBox.Name = "tipoDocAnticipoComboBox";
            this.tipoDocAnticipoComboBox.Size = new System.Drawing.Size(100, 21);
            this.tipoDocAnticipoComboBox.TabIndex = 1;
            this.tipoDocAnticipoComboBox.ValueMember = "Codigo";
            // 
            // tipoDocumentoAnticipoBindingSource
            // 
            this.tipoDocumentoAnticipoBindingSource.DataSource = typeof(OpenInvoicePeru.Entidades.TipoDocumentoAnticipo);
            // 
            // placaVehiculoTextBox
            // 
            this.placaVehiculoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "PlacaVehiculo", true));
            this.placaVehiculoTextBox.Location = new System.Drawing.Point(867, 3);
            this.placaVehiculoTextBox.Name = "placaVehiculoTextBox";
            this.placaVehiculoTextBox.Size = new System.Drawing.Size(100, 23);
            this.placaVehiculoTextBox.TabIndex = 9;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.textBox17);
            this.kryptonPanel1.Controls.Add(this.dtpFecha);
            this.kryptonPanel1.Controls.Add(this.cboMoneda);
            this.kryptonPanel1.Controls.Add(this.calculoDetraccionTextBox);
            this.kryptonPanel1.Controls.Add(this.tbPaginas);
            this.kryptonPanel1.Controls.Add(totalVentaLabel);
            this.kryptonPanel1.Controls.Add(this.btnEliminar);
            this.kryptonPanel1.Controls.Add(this.totalVentaTextBox);
            this.kryptonPanel1.Controls.Add(totalOtrosTributosLabel);
            this.kryptonPanel1.Controls.Add(this.btnDuplicar);
            this.kryptonPanel1.Controls.Add(this.totalOtrosTributosTextBox);
            this.kryptonPanel1.Controls.Add(this.btnGuia);
            this.kryptonPanel1.Controls.Add(totalIscLabel);
            this.kryptonPanel1.Controls.Add(this.btnAgregar);
            this.kryptonPanel1.Controls.Add(this.totalIscTextBox);
            this.kryptonPanel1.Controls.Add(this.groupBox1);
            this.kryptonPanel1.Controls.Add(totalIgvLabel);
            this.kryptonPanel1.Controls.Add(this.btnCalcDetraccion);
            this.kryptonPanel1.Controls.Add(this.totalIgvTextBox);
            this.kryptonPanel1.Controls.Add(this.montoDetraccionTextBox);
            this.kryptonPanel1.Controls.Add(descuentoGlobalLabel);
            this.kryptonPanel1.Controls.Add(gratuitasLabel);
            this.kryptonPanel1.Controls.Add(this.calculoIgvTextBox);
            this.kryptonPanel1.Controls.Add(this.gratuitasTextBox);
            this.kryptonPanel1.Controls.Add(this.descuentoGlobalTextBox);
            this.kryptonPanel1.Controls.Add(inafectasLabel);
            this.kryptonPanel1.Controls.Add(this.montoPercepcionTextBox);
            this.kryptonPanel1.Controls.Add(this.inafectasTextBox);
            this.kryptonPanel1.Controls.Add(this.calculoIscTextBox);
            this.kryptonPanel1.Controls.Add(exoneradasLabel);
            this.kryptonPanel1.Controls.Add(this.tipoOperacionComboBox);
            this.kryptonPanel1.Controls.Add(this.exoneradasTextBox);
            this.kryptonPanel1.Controls.Add(this.grpEmisor);
            this.kryptonPanel1.Controls.Add(gravadasLabel);
            this.kryptonPanel1.Controls.Add(this.gravadasTextBox);
            this.kryptonPanel1.Controls.Add(this.montoEnLetrasTextBox);
            this.kryptonPanel1.Controls.Add(this.grpReceptor);
            this.kryptonPanel1.Controls.Add(this.label20);
            this.kryptonPanel1.Controls.Add(this.cboTipoDoc);
            this.kryptonPanel1.Controls.Add(calculoIgvLabel);
            this.kryptonPanel1.Controls.Add(montoDetraccionLabel);
            this.kryptonPanel1.Controls.Add(this.placaVehiculoTextBox);
            this.kryptonPanel1.Controls.Add(calculoIscLabel);
            this.kryptonPanel1.Controls.Add(montoPercepcionLabel);
            this.kryptonPanel1.Controls.Add(calculoDetraccionLabel);
            this.kryptonPanel1.Controls.Add(placaVehiculoLabel);
            this.kryptonPanel1.Controls.Add(this.label18);
            this.kryptonPanel1.Controls.Add(this.label19);
            this.kryptonPanel1.Controls.Add(montoEnLetrasLabel);
            this.kryptonPanel1.Controls.Add(tipoOperacionLabel);
            this.kryptonPanel1.Controls.Add(this.label21);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 25);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(998, 666);
            this.kryptonPanel1.TabIndex = 52;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.documentoElectronicoBindingSource;
            // 
            // FrmDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 691);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDocumento";
            this.Text = "OpenInvoicePeru - Generación de Documento Electrónico";
            this.Load += new System.EventHandler(this.FrmDocumento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoDocRec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receptorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDocumentoContribuyenteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emisorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpEmisor.Panel)).EndInit();
            this.grpEmisor.Panel.ResumeLayout(false);
            this.grpEmisor.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpEmisor)).EndInit();
            this.grpEmisor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpReceptor.Panel)).EndInit();
            this.grpReceptor.Panel.ResumeLayout(false);
            this.grpReceptor.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpReceptor)).EndInit();
            this.grpReceptor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentoElectronicoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDocumentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monedaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detallesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoOperacionComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoOperacionBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tbPaginas.ResumeLayout(false);
            this.tpDetalles.ResumeLayout(false);
            this.tpAdicionales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datoAdicionalesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datoAdicionalesBindingSource)).EndInit();
            this.tpRelacionados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.relacionadosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.relacionadosBindingSource)).EndInit();
            this.tbDiscrepancias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.discrepanciasDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discrepanciasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1.Panel)).EndInit();
            this.groupBox1.Panel.ResumeLayout(false);
            this.groupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.monedaAnticipoComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDocAnticipoComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDocumentoAnticipoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboTipoDocRec;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNroDocEm;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox grpEmisor;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label9;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label8;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label7;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label6;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUbigeoEm;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtDistritoEm;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtDptoEm;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtProvEm;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtDirEm;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNombreComEm;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNombreLegalEm;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox grpReceptor;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label16;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label17;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNombreLegalRec;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNroDocRec;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textBox17;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label18;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label19;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpFecha;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label20;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboTipoDoc;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label21;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboMoneda;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvDetalle;
        private System.Windows.Forms.BindingSource documentoElectronicoBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox montoEnLetrasTextBox;
        private System.Windows.Forms.BindingSource detallesBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox gravadasTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox exoneradasTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox inafectasTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox gratuitasTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox tipoOperacionComboBox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox totalIgvTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox totalIscTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox totalOtrosTributosTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox totalVentaTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAgregar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnEliminar;
        private System.Windows.Forms.BindingSource emisorBindingSource;
        private System.Windows.Forms.BindingSource receptorBindingSource;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolGenerar;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox calculoIgvTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox calculoIscTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox calculoDetraccionTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDuplicar;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox descuentoGlobalTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox urbanizacionTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox montoPercepcionTextBox;
        private System.Windows.Forms.TabControl tbPaginas;
        private System.Windows.Forms.TabPage tpDetalles;
        private System.Windows.Forms.TabPage tpAdicionales;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView datoAdicionalesDataGridView;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.BindingSource datoAdicionalesBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox montoDetraccionTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCalcDetraccion;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnGuia;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox groupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox monedaAnticipoComboBox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox montoAnticipoTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox docAnticipoTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox tipoDocAnticipoComboBox;
        private System.Windows.Forms.TabPage tpRelacionados;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView relacionadosDataGridView;
        private System.Windows.Forms.BindingSource relacionadosBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.TabPage tbDiscrepancias;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView discrepanciasDataGridView;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.BindingSource discrepanciasBindingSource;
        private System.Windows.Forms.BindingSource tipoDocumentoContribuyenteBindingSource;
        private System.Windows.Forms.BindingSource tipoDocumentoBindingSource;
        private System.Windows.Forms.BindingSource tipoOperacionBindingSource;
        private System.Windows.Forms.BindingSource tipoDocumentoAnticipoBindingSource;
        private System.Windows.Forms.BindingSource monedaBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox placaVehiculoTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ErrorProvider errorProvider1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn codigoItemDataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn unidadMedidaDataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn precioUnitarioDataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn precioReferencialDataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn tipoPrecioDataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Descuento;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn impuestoDataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn tipoImpuestoDataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn impuestoSelectivoDataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn otroImpuestoDataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn totalVentaDataGridViewTextBoxColumn;
    }
}
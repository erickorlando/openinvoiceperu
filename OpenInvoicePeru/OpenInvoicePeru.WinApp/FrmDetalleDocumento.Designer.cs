using System.Windows.Forms;

namespace OpenInvoicePeru.WinApp
{
    partial class FrmDetalleDocumento
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
            ComponentFactory.Krypton.Toolkit.KryptonLabel idLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel codigoItemLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel descripcionLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel precioUnitarioLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel precioReferencialLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel cantidadLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel unidadMedidaLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel impuestoLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel tipoImpuestoLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel impuestoSelectivoLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel otroImpuestoLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel totalVentaLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel tipoPrecioLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel descuentoLabel;
            this.detalleDocumentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codigoItemTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.descripcionTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.precioUnitarioTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.precioReferencialTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.cantidadTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.unidadMedidaComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.impuestoTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tipoImpuestoComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.tipoImpuestoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.impuestoSelectivoTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.otroImpuestoTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.totalVentaTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.barraBotones = new System.Windows.Forms.ToolStrip();
            this.toolOk = new System.Windows.Forms.ToolStripButton();
            this.toolCancel = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnCalcIgv = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCalcIsc = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.tipoPrecioComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.tipoPrecioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.idNumericUpDown = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.descuentoTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            idLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            codigoItemLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            descripcionLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            precioUnitarioLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            precioReferencialLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            cantidadLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            unidadMedidaLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            impuestoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            tipoImpuestoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            impuestoSelectivoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            otroImpuestoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            totalVentaLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            tipoPrecioLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            descuentoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.detalleDocumentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unidadMedidaComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoImpuestoComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoImpuestoBindingSource)).BeginInit();
            this.barraBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoPrecioComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoPrecioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.Location = new System.Drawing.Point(3, 7);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(24, 20);
            idLabel.TabIndex = 1;
            idLabel.Values.Text = "Id:";
            // 
            // codigoItemLabel
            // 
            codigoItemLabel.Location = new System.Drawing.Point(3, 31);
            codigoItemLabel.Name = "codigoItemLabel";
            codigoItemLabel.Size = new System.Drawing.Size(81, 20);
            codigoItemLabel.TabIndex = 2;
            codigoItemLabel.Values.Text = "Código Item:";
            // 
            // descripcionLabel
            // 
            descripcionLabel.Location = new System.Drawing.Point(3, 57);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(77, 20);
            descripcionLabel.TabIndex = 4;
            descripcionLabel.Values.Text = "Descripcion:";
            // 
            // precioUnitarioLabel
            // 
            precioUnitarioLabel.Location = new System.Drawing.Point(3, 83);
            precioUnitarioLabel.Name = "precioUnitarioLabel";
            precioUnitarioLabel.Size = new System.Drawing.Size(94, 20);
            precioUnitarioLabel.TabIndex = 6;
            precioUnitarioLabel.Values.Text = "Precio Unitario:";
            // 
            // precioReferencialLabel
            // 
            precioReferencialLabel.Location = new System.Drawing.Point(4, 109);
            precioReferencialLabel.Name = "precioReferencialLabel";
            precioReferencialLabel.Size = new System.Drawing.Size(110, 20);
            precioReferencialLabel.TabIndex = 8;
            precioReferencialLabel.Values.Text = "Precio Referencial:";
            // 
            // cantidadLabel
            // 
            cantidadLabel.Location = new System.Drawing.Point(3, 159);
            cantidadLabel.Name = "cantidadLabel";
            cantidadLabel.Size = new System.Drawing.Size(62, 20);
            cantidadLabel.TabIndex = 10;
            cantidadLabel.Values.Text = "Cantidad:";
            // 
            // unidadMedidaLabel
            // 
            unidadMedidaLabel.Location = new System.Drawing.Point(4, 183);
            unidadMedidaLabel.Name = "unidadMedidaLabel";
            unidadMedidaLabel.Size = new System.Drawing.Size(97, 20);
            unidadMedidaLabel.TabIndex = 12;
            unidadMedidaLabel.Values.Text = "Unidad Medida:";
            // 
            // impuestoLabel
            // 
            impuestoLabel.Location = new System.Drawing.Point(4, 235);
            impuestoLabel.Name = "impuestoLabel";
            impuestoLabel.Size = new System.Drawing.Size(65, 20);
            impuestoLabel.TabIndex = 14;
            impuestoLabel.Values.Text = "Impuesto:";
            // 
            // tipoImpuestoLabel
            // 
            tipoImpuestoLabel.Location = new System.Drawing.Point(3, 258);
            tipoImpuestoLabel.Name = "tipoImpuestoLabel";
            tipoImpuestoLabel.Size = new System.Drawing.Size(92, 20);
            tipoImpuestoLabel.TabIndex = 16;
            tipoImpuestoLabel.Values.Text = "Tipo Impuesto:";
            // 
            // impuestoSelectivoLabel
            // 
            impuestoSelectivoLabel.Location = new System.Drawing.Point(4, 285);
            impuestoSelectivoLabel.Name = "impuestoSelectivoLabel";
            impuestoSelectivoLabel.Size = new System.Drawing.Size(116, 20);
            impuestoSelectivoLabel.TabIndex = 18;
            impuestoSelectivoLabel.Values.Text = "Impuesto Selectivo:";
            // 
            // otroImpuestoLabel
            // 
            otroImpuestoLabel.Location = new System.Drawing.Point(4, 311);
            otroImpuestoLabel.Name = "otroImpuestoLabel";
            otroImpuestoLabel.Size = new System.Drawing.Size(93, 20);
            otroImpuestoLabel.TabIndex = 20;
            otroImpuestoLabel.Values.Text = "Otro Impuesto:";
            // 
            // totalVentaLabel
            // 
            totalVentaLabel.Location = new System.Drawing.Point(4, 337);
            totalVentaLabel.Name = "totalVentaLabel";
            totalVentaLabel.Size = new System.Drawing.Size(75, 20);
            totalVentaLabel.TabIndex = 22;
            totalVentaLabel.Values.Text = "Total Venta:";
            // 
            // tipoPrecioLabel
            // 
            tipoPrecioLabel.Location = new System.Drawing.Point(4, 133);
            tipoPrecioLabel.Name = "tipoPrecioLabel";
            tipoPrecioLabel.Size = new System.Drawing.Size(74, 20);
            tipoPrecioLabel.TabIndex = 27;
            tipoPrecioLabel.Values.Text = "Tipo Precio:";
            // 
            // detalleDocumentoBindingSource
            // 
            this.detalleDocumentoBindingSource.DataSource = typeof(OpenInvoicePeru.Comun.Dto.Modelos.DetalleDocumento);
            // 
            // codigoItemTextBox
            // 
            this.codigoItemTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "CodigoItem", true));
            this.codigoItemTextBox.Location = new System.Drawing.Point(120, 28);
            this.codigoItemTextBox.Name = "codigoItemTextBox";
            this.codigoItemTextBox.Size = new System.Drawing.Size(100, 23);
            this.codigoItemTextBox.TabIndex = 1;
            // 
            // descripcionTextBox
            // 
            this.descripcionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "Descripcion", true));
            this.descripcionTextBox.Location = new System.Drawing.Point(120, 54);
            this.descripcionTextBox.Name = "descripcionTextBox";
            this.descripcionTextBox.Size = new System.Drawing.Size(240, 23);
            this.descripcionTextBox.TabIndex = 2;
            // 
            // precioUnitarioTextBox
            // 
            this.precioUnitarioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "PrecioUnitario", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.precioUnitarioTextBox.Location = new System.Drawing.Point(120, 80);
            this.precioUnitarioTextBox.Name = "precioUnitarioTextBox";
            this.precioUnitarioTextBox.Size = new System.Drawing.Size(100, 23);
            this.precioUnitarioTextBox.TabIndex = 3;
            // 
            // precioReferencialTextBox
            // 
            this.precioReferencialTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "PrecioReferencial", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.precioReferencialTextBox.Location = new System.Drawing.Point(120, 106);
            this.precioReferencialTextBox.Name = "precioReferencialTextBox";
            this.precioReferencialTextBox.Size = new System.Drawing.Size(100, 23);
            this.precioReferencialTextBox.TabIndex = 4;
            // 
            // cantidadTextBox
            // 
            this.cantidadTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "Cantidad", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.cantidadTextBox.Location = new System.Drawing.Point(120, 156);
            this.cantidadTextBox.Name = "cantidadTextBox";
            this.cantidadTextBox.Size = new System.Drawing.Size(100, 23);
            this.cantidadTextBox.TabIndex = 6;
            // 
            // unidadMedidaComboBox
            // 
            this.unidadMedidaComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "UnidadMedida", true));
            this.unidadMedidaComboBox.DropDownWidth = 100;
            this.unidadMedidaComboBox.FormattingEnabled = true;
            this.unidadMedidaComboBox.Items.AddRange(new object[] {
            "NIU",
            "KG",
            "ONZ",
            "LTR"});
            this.unidadMedidaComboBox.Location = new System.Drawing.Point(120, 182);
            this.unidadMedidaComboBox.Name = "unidadMedidaComboBox";
            this.unidadMedidaComboBox.Size = new System.Drawing.Size(100, 21);
            this.unidadMedidaComboBox.TabIndex = 7;
            // 
            // impuestoTextBox
            // 
            this.impuestoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "Impuesto", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.impuestoTextBox.Location = new System.Drawing.Point(120, 232);
            this.impuestoTextBox.Name = "impuestoTextBox";
            this.impuestoTextBox.Size = new System.Drawing.Size(100, 23);
            this.impuestoTextBox.TabIndex = 9;
            // 
            // tipoImpuestoComboBox
            // 
            this.tipoImpuestoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.detalleDocumentoBindingSource, "TipoImpuesto", true));
            this.tipoImpuestoComboBox.DataSource = this.tipoImpuestoBindingSource;
            this.tipoImpuestoComboBox.DisplayMember = "DescripcionCompleta";
            this.tipoImpuestoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoImpuestoComboBox.DropDownWidth = 240;
            this.tipoImpuestoComboBox.FormattingEnabled = true;
            this.tipoImpuestoComboBox.Location = new System.Drawing.Point(120, 258);
            this.tipoImpuestoComboBox.Name = "tipoImpuestoComboBox";
            this.tipoImpuestoComboBox.Size = new System.Drawing.Size(240, 21);
            this.tipoImpuestoComboBox.TabIndex = 11;
            this.tipoImpuestoComboBox.ValueMember = "Codigo";
            // 
            // tipoImpuestoBindingSource
            // 
            this.tipoImpuestoBindingSource.DataSource = typeof(OpenInvoicePeru.Entidades.TipoImpuesto);
            // 
            // impuestoSelectivoTextBox
            // 
            this.impuestoSelectivoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "ImpuestoSelectivo", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.impuestoSelectivoTextBox.Location = new System.Drawing.Point(120, 282);
            this.impuestoSelectivoTextBox.Name = "impuestoSelectivoTextBox";
            this.impuestoSelectivoTextBox.Size = new System.Drawing.Size(100, 23);
            this.impuestoSelectivoTextBox.TabIndex = 12;
            // 
            // otroImpuestoTextBox
            // 
            this.otroImpuestoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "OtroImpuesto", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.otroImpuestoTextBox.Location = new System.Drawing.Point(120, 308);
            this.otroImpuestoTextBox.Name = "otroImpuestoTextBox";
            this.otroImpuestoTextBox.Size = new System.Drawing.Size(100, 23);
            this.otroImpuestoTextBox.TabIndex = 14;
            // 
            // totalVentaTextBox
            // 
            this.totalVentaTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.totalVentaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "TotalVenta", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.totalVentaTextBox.Location = new System.Drawing.Point(120, 334);
            this.totalVentaTextBox.Name = "totalVentaTextBox";
            this.totalVentaTextBox.Size = new System.Drawing.Size(100, 23);
            this.totalVentaTextBox.TabIndex = 15;
            // 
            // barraBotones
            // 
            this.barraBotones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.barraBotones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOk,
            this.toolCancel});
            this.barraBotones.Location = new System.Drawing.Point(0, 0);
            this.barraBotones.Name = "barraBotones";
            this.barraBotones.Size = new System.Drawing.Size(374, 25);
            this.barraBotones.TabIndex = 24;
            this.barraBotones.Text = "toolStrip1";
            // 
            // toolOk
            // 
            this.toolOk.Image = global::OpenInvoicePeru.WinApp.Properties.Resources.aceptar;
            this.toolOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOk.Name = "toolOk";
            this.toolOk.Size = new System.Drawing.Size(68, 22);
            this.toolOk.Text = "&Aceptar";
            this.toolOk.Click += new System.EventHandler(this.toolOk_Click);
            // 
            // toolCancel
            // 
            this.toolCancel.Image = global::OpenInvoicePeru.WinApp.Properties.Resources.cancelar;
            this.toolCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCancel.Name = "toolCancel";
            this.toolCancel.Size = new System.Drawing.Size(73, 22);
            this.toolCancel.Text = "&Cancelar";
            this.toolCancel.Click += new System.EventHandler(this.toolCancel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.detalleDocumentoBindingSource;
            // 
            // btnCalcIgv
            // 
            this.btnCalcIgv.AutoSize = true;
            this.btnCalcIgv.Location = new System.Drawing.Point(235, 231);
            this.btnCalcIgv.Name = "btnCalcIgv";
            this.btnCalcIgv.Size = new System.Drawing.Size(125, 24);
            this.btnCalcIgv.TabIndex = 10;
            this.btnCalcIgv.Values.Text = "C&alcular IGV";
            this.btnCalcIgv.Click += new System.EventHandler(this.btnCalcIgv_Click);
            // 
            // btnCalcIsc
            // 
            this.btnCalcIsc.AutoSize = true;
            this.btnCalcIsc.Location = new System.Drawing.Point(235, 281);
            this.btnCalcIsc.Name = "btnCalcIsc";
            this.btnCalcIsc.Size = new System.Drawing.Size(125, 24);
            this.btnCalcIsc.TabIndex = 13;
            this.btnCalcIsc.Values.Text = "Ca&lcular ISC";
            this.btnCalcIsc.Click += new System.EventHandler(this.btnCalcIsc_Click);
            // 
            // tipoPrecioComboBox
            // 
            this.tipoPrecioComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.detalleDocumentoBindingSource, "TipoPrecio", true));
            this.tipoPrecioComboBox.DataSource = this.tipoPrecioBindingSource;
            this.tipoPrecioComboBox.DisplayMember = "DescripcionCompleta";
            this.tipoPrecioComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoPrecioComboBox.DropDownWidth = 240;
            this.tipoPrecioComboBox.FormattingEnabled = true;
            this.tipoPrecioComboBox.Location = new System.Drawing.Point(120, 132);
            this.tipoPrecioComboBox.Name = "tipoPrecioComboBox";
            this.tipoPrecioComboBox.Size = new System.Drawing.Size(240, 21);
            this.tipoPrecioComboBox.TabIndex = 5;
            this.tipoPrecioComboBox.ValueMember = "Codigo";
            // 
            // tipoPrecioBindingSource
            // 
            this.tipoPrecioBindingSource.DataSource = typeof(OpenInvoicePeru.Entidades.TipoPrecio);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.idNumericUpDown);
            this.kryptonPanel1.Controls.Add(this.tipoPrecioComboBox);
            this.kryptonPanel1.Controls.Add(this.codigoItemTextBox);
            this.kryptonPanel1.Controls.Add(this.descripcionTextBox);
            this.kryptonPanel1.Controls.Add(this.precioUnitarioTextBox);
            this.kryptonPanel1.Controls.Add(this.totalVentaTextBox);
            this.kryptonPanel1.Controls.Add(this.precioReferencialTextBox);
            this.kryptonPanel1.Controls.Add(this.otroImpuestoTextBox);
            this.kryptonPanel1.Controls.Add(this.cantidadTextBox);
            this.kryptonPanel1.Controls.Add(this.impuestoSelectivoTextBox);
            this.kryptonPanel1.Controls.Add(this.unidadMedidaComboBox);
            this.kryptonPanel1.Controls.Add(this.tipoImpuestoComboBox);
            this.kryptonPanel1.Controls.Add(this.descuentoTextBox);
            this.kryptonPanel1.Controls.Add(this.impuestoTextBox);
            this.kryptonPanel1.Controls.Add(idLabel);
            this.kryptonPanel1.Controls.Add(tipoPrecioLabel);
            this.kryptonPanel1.Controls.Add(this.btnCalcIsc);
            this.kryptonPanel1.Controls.Add(codigoItemLabel);
            this.kryptonPanel1.Controls.Add(this.btnCalcIgv);
            this.kryptonPanel1.Controls.Add(descripcionLabel);
            this.kryptonPanel1.Controls.Add(totalVentaLabel);
            this.kryptonPanel1.Controls.Add(precioUnitarioLabel);
            this.kryptonPanel1.Controls.Add(otroImpuestoLabel);
            this.kryptonPanel1.Controls.Add(precioReferencialLabel);
            this.kryptonPanel1.Controls.Add(impuestoSelectivoLabel);
            this.kryptonPanel1.Controls.Add(cantidadLabel);
            this.kryptonPanel1.Controls.Add(tipoImpuestoLabel);
            this.kryptonPanel1.Controls.Add(unidadMedidaLabel);
            this.kryptonPanel1.Controls.Add(descuentoLabel);
            this.kryptonPanel1.Controls.Add(impuestoLabel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 25);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(374, 368);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // idNumericUpDown
            // 
            this.idNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.detalleDocumentoBindingSource, "Id", true));
            this.idNumericUpDown.Location = new System.Drawing.Point(120, 3);
            this.idNumericUpDown.Name = "idNumericUpDown";
            this.idNumericUpDown.Size = new System.Drawing.Size(100, 22);
            this.idNumericUpDown.TabIndex = 0;
            // 
            // descuentoTextBox
            // 
            this.descuentoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "Descuento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N2"));
            this.descuentoTextBox.Location = new System.Drawing.Point(120, 206);
            this.descuentoTextBox.Name = "descuentoTextBox";
            this.descuentoTextBox.Size = new System.Drawing.Size(100, 23);
            this.descuentoTextBox.TabIndex = 8;
            // 
            // descuentoLabel
            // 
            descuentoLabel.Location = new System.Drawing.Point(4, 209);
            descuentoLabel.Name = "descuentoLabel";
            descuentoLabel.Size = new System.Drawing.Size(71, 20);
            descuentoLabel.TabIndex = 14;
            descuentoLabel.Values.Text = "Descuento:";
            // 
            // FrmDetalleDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 393);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.barraBotones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDetalleDocumento";
            this.Text = "Detalle del Documento";
            ((System.ComponentModel.ISupportInitialize)(this.detalleDocumentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unidadMedidaComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoImpuestoComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoImpuestoBindingSource)).EndInit();
            this.barraBotones.ResumeLayout(false);
            this.barraBotones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoPrecioComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoPrecioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource detalleDocumentoBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox codigoItemTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox descripcionTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox precioUnitarioTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox precioReferencialTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox cantidadTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox unidadMedidaComboBox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox impuestoTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox tipoImpuestoComboBox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox impuestoSelectivoTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox otroImpuestoTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox totalVentaTextBox;
        private System.Windows.Forms.ToolStrip barraBotones;
        private System.Windows.Forms.ToolStripButton toolOk;
        private System.Windows.Forms.ToolStripButton toolCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCalcIsc;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCalcIgv;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox tipoPrecioComboBox;
        private System.Windows.Forms.BindingSource tipoImpuestoBindingSource;
        private System.Windows.Forms.BindingSource tipoPrecioBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown idNumericUpDown;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox descuentoTextBox;
    }
}
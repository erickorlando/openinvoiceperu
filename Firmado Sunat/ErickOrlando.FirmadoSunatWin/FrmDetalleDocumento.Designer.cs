namespace OpenInvoicePeru.FirmadoSunatWin
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
            System.Windows.Forms.Label idLabel;
            System.Windows.Forms.Label codigoItemLabel;
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label precioUnitarioLabel;
            System.Windows.Forms.Label precioReferencialLabel;
            System.Windows.Forms.Label cantidadLabel;
            System.Windows.Forms.Label unidadMedidaLabel;
            System.Windows.Forms.Label impuestoLabel;
            System.Windows.Forms.Label tipoImpuestoLabel;
            System.Windows.Forms.Label impuestoSelectivoLabel;
            System.Windows.Forms.Label otroImpuestoLabel;
            System.Windows.Forms.Label totalVentaLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDetalleDocumento));
            this.detalleDocumentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.codigoItemTextBox = new System.Windows.Forms.TextBox();
            this.descripcionTextBox = new System.Windows.Forms.TextBox();
            this.precioUnitarioTextBox = new System.Windows.Forms.TextBox();
            this.precioReferencialTextBox = new System.Windows.Forms.TextBox();
            this.cantidadTextBox = new System.Windows.Forms.TextBox();
            this.unidadMedidaComboBox = new System.Windows.Forms.ComboBox();
            this.impuestoTextBox = new System.Windows.Forms.TextBox();
            this.tipoImpuestoComboBox = new System.Windows.Forms.ComboBox();
            this.impuestoSelectivoTextBox = new System.Windows.Forms.TextBox();
            this.otroImpuestoTextBox = new System.Windows.Forms.TextBox();
            this.totalVentaTextBox = new System.Windows.Forms.TextBox();
            this.barraBotones = new System.Windows.Forms.ToolStrip();
            this.toolOk = new System.Windows.Forms.ToolStripButton();
            this.toolCancel = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            idLabel = new System.Windows.Forms.Label();
            codigoItemLabel = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            precioUnitarioLabel = new System.Windows.Forms.Label();
            precioReferencialLabel = new System.Windows.Forms.Label();
            cantidadLabel = new System.Windows.Forms.Label();
            unidadMedidaLabel = new System.Windows.Forms.Label();
            impuestoLabel = new System.Windows.Forms.Label();
            tipoImpuestoLabel = new System.Windows.Forms.Label();
            impuestoSelectivoLabel = new System.Windows.Forms.Label();
            otroImpuestoLabel = new System.Windows.Forms.Label();
            totalVentaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.detalleDocumentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idNumericUpDown)).BeginInit();
            this.barraBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(12, 35);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(19, 13);
            idLabel.TabIndex = 1;
            idLabel.Text = "Id:";
            // 
            // codigoItemLabel
            // 
            codigoItemLabel.AutoSize = true;
            codigoItemLabel.Location = new System.Drawing.Point(12, 61);
            codigoItemLabel.Name = "codigoItemLabel";
            codigoItemLabel.Size = new System.Drawing.Size(66, 13);
            codigoItemLabel.TabIndex = 2;
            codigoItemLabel.Text = "Codigo Item:";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(12, 87);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(66, 13);
            descripcionLabel.TabIndex = 4;
            descripcionLabel.Text = "Descripcion:";
            // 
            // precioUnitarioLabel
            // 
            precioUnitarioLabel.AutoSize = true;
            precioUnitarioLabel.Location = new System.Drawing.Point(12, 113);
            precioUnitarioLabel.Name = "precioUnitarioLabel";
            precioUnitarioLabel.Size = new System.Drawing.Size(79, 13);
            precioUnitarioLabel.TabIndex = 6;
            precioUnitarioLabel.Text = "Precio Unitario:";
            // 
            // precioReferencialLabel
            // 
            precioReferencialLabel.AutoSize = true;
            precioReferencialLabel.Location = new System.Drawing.Point(12, 139);
            precioReferencialLabel.Name = "precioReferencialLabel";
            precioReferencialLabel.Size = new System.Drawing.Size(97, 13);
            precioReferencialLabel.TabIndex = 8;
            precioReferencialLabel.Text = "Precio Referencial:";
            // 
            // cantidadLabel
            // 
            cantidadLabel.AutoSize = true;
            cantidadLabel.Location = new System.Drawing.Point(12, 165);
            cantidadLabel.Name = "cantidadLabel";
            cantidadLabel.Size = new System.Drawing.Size(52, 13);
            cantidadLabel.TabIndex = 10;
            cantidadLabel.Text = "Cantidad:";
            // 
            // unidadMedidaLabel
            // 
            unidadMedidaLabel.AutoSize = true;
            unidadMedidaLabel.Location = new System.Drawing.Point(12, 191);
            unidadMedidaLabel.Name = "unidadMedidaLabel";
            unidadMedidaLabel.Size = new System.Drawing.Size(82, 13);
            unidadMedidaLabel.TabIndex = 12;
            unidadMedidaLabel.Text = "Unidad Medida:";
            // 
            // impuestoLabel
            // 
            impuestoLabel.AutoSize = true;
            impuestoLabel.Location = new System.Drawing.Point(12, 217);
            impuestoLabel.Name = "impuestoLabel";
            impuestoLabel.Size = new System.Drawing.Size(53, 13);
            impuestoLabel.TabIndex = 14;
            impuestoLabel.Text = "Impuesto:";
            // 
            // tipoImpuestoLabel
            // 
            tipoImpuestoLabel.AutoSize = true;
            tipoImpuestoLabel.Location = new System.Drawing.Point(12, 243);
            tipoImpuestoLabel.Name = "tipoImpuestoLabel";
            tipoImpuestoLabel.Size = new System.Drawing.Size(77, 13);
            tipoImpuestoLabel.TabIndex = 16;
            tipoImpuestoLabel.Text = "Tipo Impuesto:";
            // 
            // impuestoSelectivoLabel
            // 
            impuestoSelectivoLabel.AutoSize = true;
            impuestoSelectivoLabel.Location = new System.Drawing.Point(12, 269);
            impuestoSelectivoLabel.Name = "impuestoSelectivoLabel";
            impuestoSelectivoLabel.Size = new System.Drawing.Size(100, 13);
            impuestoSelectivoLabel.TabIndex = 18;
            impuestoSelectivoLabel.Text = "Impuesto Selectivo:";
            // 
            // otroImpuestoLabel
            // 
            otroImpuestoLabel.AutoSize = true;
            otroImpuestoLabel.Location = new System.Drawing.Point(12, 295);
            otroImpuestoLabel.Name = "otroImpuestoLabel";
            otroImpuestoLabel.Size = new System.Drawing.Size(76, 13);
            otroImpuestoLabel.TabIndex = 20;
            otroImpuestoLabel.Text = "Otro Impuesto:";
            // 
            // totalVentaLabel
            // 
            totalVentaLabel.AutoSize = true;
            totalVentaLabel.Location = new System.Drawing.Point(12, 321);
            totalVentaLabel.Name = "totalVentaLabel";
            totalVentaLabel.Size = new System.Drawing.Size(65, 13);
            totalVentaLabel.TabIndex = 22;
            totalVentaLabel.Text = "Total Venta:";
            // 
            // detalleDocumentoBindingSource
            // 
            this.detalleDocumentoBindingSource.DataSource = typeof(OpenInvoicePeru.FirmadoSunat.Models.DetalleDocumento);
            // 
            // idNumericUpDown
            // 
            this.idNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.detalleDocumentoBindingSource, "Id", true));
            this.idNumericUpDown.Location = new System.Drawing.Point(112, 33);
            this.idNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.idNumericUpDown.Name = "idNumericUpDown";
            this.idNumericUpDown.Size = new System.Drawing.Size(100, 20);
            this.idNumericUpDown.TabIndex = 2;
            this.idNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // codigoItemTextBox
            // 
            this.codigoItemTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "CodigoItem", true));
            this.codigoItemTextBox.Location = new System.Drawing.Point(112, 58);
            this.codigoItemTextBox.Name = "codigoItemTextBox";
            this.codigoItemTextBox.Size = new System.Drawing.Size(100, 20);
            this.codigoItemTextBox.TabIndex = 3;
            // 
            // descripcionTextBox
            // 
            this.descripcionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "Descripcion", true));
            this.descripcionTextBox.Location = new System.Drawing.Point(112, 84);
            this.descripcionTextBox.Name = "descripcionTextBox";
            this.descripcionTextBox.Size = new System.Drawing.Size(240, 20);
            this.descripcionTextBox.TabIndex = 5;
            // 
            // precioUnitarioTextBox
            // 
            this.precioUnitarioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "PrecioUnitario", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.precioUnitarioTextBox.Location = new System.Drawing.Point(112, 110);
            this.precioUnitarioTextBox.Name = "precioUnitarioTextBox";
            this.precioUnitarioTextBox.Size = new System.Drawing.Size(100, 20);
            this.precioUnitarioTextBox.TabIndex = 7;
            // 
            // precioReferencialTextBox
            // 
            this.precioReferencialTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "PrecioReferencial", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.precioReferencialTextBox.Location = new System.Drawing.Point(112, 136);
            this.precioReferencialTextBox.Name = "precioReferencialTextBox";
            this.precioReferencialTextBox.Size = new System.Drawing.Size(100, 20);
            this.precioReferencialTextBox.TabIndex = 9;
            // 
            // cantidadTextBox
            // 
            this.cantidadTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "Cantidad", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.cantidadTextBox.Location = new System.Drawing.Point(112, 162);
            this.cantidadTextBox.Name = "cantidadTextBox";
            this.cantidadTextBox.Size = new System.Drawing.Size(100, 20);
            this.cantidadTextBox.TabIndex = 11;
            // 
            // unidadMedidaComboBox
            // 
            this.unidadMedidaComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "UnidadMedida", true));
            this.unidadMedidaComboBox.FormattingEnabled = true;
            this.unidadMedidaComboBox.Items.AddRange(new object[] {
            "NIU",
            "KG",
            "ONZ",
            "LTR"});
            this.unidadMedidaComboBox.Location = new System.Drawing.Point(112, 188);
            this.unidadMedidaComboBox.Name = "unidadMedidaComboBox";
            this.unidadMedidaComboBox.Size = new System.Drawing.Size(100, 21);
            this.unidadMedidaComboBox.TabIndex = 13;
            // 
            // impuestoTextBox
            // 
            this.impuestoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "Impuesto", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.impuestoTextBox.Location = new System.Drawing.Point(112, 214);
            this.impuestoTextBox.Name = "impuestoTextBox";
            this.impuestoTextBox.Size = new System.Drawing.Size(100, 20);
            this.impuestoTextBox.TabIndex = 15;
            // 
            // tipoImpuestoComboBox
            // 
            this.tipoImpuestoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "TipoImpuesto", true));
            this.tipoImpuestoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoImpuestoComboBox.FormattingEnabled = true;
            this.tipoImpuestoComboBox.Items.AddRange(new object[] {
            "10 Gravado - Operación Onerosa",
            "11 Gravado – Retiro por premio",
            "12 Gravado – Retiro por donación",
            "13 Gravado – Retiro",
            "14 Gravado – Retiro por publicidad",
            "15 Gravado – Bonificaciones",
            "16 Gravado – Retiro por entrega a trabajadores",
            "17 Gravado – IVAP",
            "20 Exonerado - Operación Onerosa",
            "21 Exonerado – Transferencia Gratuita",
            "30 Inafecto - Operación Onerosa",
            "31 Inafecto – Retiro por Bonificación",
            "32 Inafecto – Retiro",
            "33 Inafecto – Retiro por Muestras Médicas",
            "34 Inafecto - Retiro por Convenio Colectivo",
            "35 Inafecto – Retiro por premio",
            "36 Inafecto - Retiro por publicidad",
            "40 Exportación"});
            this.tipoImpuestoComboBox.Location = new System.Drawing.Point(112, 240);
            this.tipoImpuestoComboBox.Name = "tipoImpuestoComboBox";
            this.tipoImpuestoComboBox.Size = new System.Drawing.Size(240, 21);
            this.tipoImpuestoComboBox.TabIndex = 17;
            // 
            // impuestoSelectivoTextBox
            // 
            this.impuestoSelectivoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "ImpuestoSelectivo", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.impuestoSelectivoTextBox.Location = new System.Drawing.Point(112, 266);
            this.impuestoSelectivoTextBox.Name = "impuestoSelectivoTextBox";
            this.impuestoSelectivoTextBox.Size = new System.Drawing.Size(100, 20);
            this.impuestoSelectivoTextBox.TabIndex = 19;
            // 
            // otroImpuestoTextBox
            // 
            this.otroImpuestoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "OtroImpuesto", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.otroImpuestoTextBox.Location = new System.Drawing.Point(112, 292);
            this.otroImpuestoTextBox.Name = "otroImpuestoTextBox";
            this.otroImpuestoTextBox.Size = new System.Drawing.Size(100, 20);
            this.otroImpuestoTextBox.TabIndex = 21;
            // 
            // totalVentaTextBox
            // 
            this.totalVentaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "TotalVenta", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.totalVentaTextBox.Location = new System.Drawing.Point(112, 318);
            this.totalVentaTextBox.Name = "totalVentaTextBox";
            this.totalVentaTextBox.Size = new System.Drawing.Size(100, 20);
            this.totalVentaTextBox.TabIndex = 23;
            // 
            // barraBotones
            // 
            this.barraBotones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOk,
            this.toolCancel});
            this.barraBotones.Location = new System.Drawing.Point(0, 0);
            this.barraBotones.Name = "barraBotones";
            this.barraBotones.Size = new System.Drawing.Size(397, 25);
            this.barraBotones.TabIndex = 24;
            this.barraBotones.Text = "toolStrip1";
            // 
            // toolOk
            // 
            this.toolOk.Image = global::OpenInvoicePeru.FirmadoSunatWin.Properties.Resources.ok;
            this.toolOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOk.Name = "toolOk";
            this.toolOk.Size = new System.Drawing.Size(68, 22);
            this.toolOk.Text = "&Aceptar";
            // 
            // toolCancel
            // 
            this.toolCancel.Image = global::OpenInvoicePeru.FirmadoSunatWin.Properties.Resources.cancel;
            this.toolCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCancel.Name = "toolCancel";
            this.toolCancel.Size = new System.Drawing.Size(73, 22);
            this.toolCancel.Text = "&Cancelar";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.detalleDocumentoBindingSource;
            // 
            // FrmDetalleDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 358);
            this.Controls.Add(this.barraBotones);
            this.Controls.Add(totalVentaLabel);
            this.Controls.Add(this.totalVentaTextBox);
            this.Controls.Add(otroImpuestoLabel);
            this.Controls.Add(this.otroImpuestoTextBox);
            this.Controls.Add(impuestoSelectivoLabel);
            this.Controls.Add(this.impuestoSelectivoTextBox);
            this.Controls.Add(tipoImpuestoLabel);
            this.Controls.Add(this.tipoImpuestoComboBox);
            this.Controls.Add(impuestoLabel);
            this.Controls.Add(this.impuestoTextBox);
            this.Controls.Add(unidadMedidaLabel);
            this.Controls.Add(this.unidadMedidaComboBox);
            this.Controls.Add(cantidadLabel);
            this.Controls.Add(this.cantidadTextBox);
            this.Controls.Add(precioReferencialLabel);
            this.Controls.Add(this.precioReferencialTextBox);
            this.Controls.Add(precioUnitarioLabel);
            this.Controls.Add(this.precioUnitarioTextBox);
            this.Controls.Add(descripcionLabel);
            this.Controls.Add(this.descripcionTextBox);
            this.Controls.Add(codigoItemLabel);
            this.Controls.Add(this.codigoItemTextBox);
            this.Controls.Add(idLabel);
            this.Controls.Add(this.idNumericUpDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDetalleDocumento";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle del Documento";
            ((System.ComponentModel.ISupportInitialize)(this.detalleDocumentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idNumericUpDown)).EndInit();
            this.barraBotones.ResumeLayout(false);
            this.barraBotones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource detalleDocumentoBindingSource;
        private System.Windows.Forms.NumericUpDown idNumericUpDown;
        private System.Windows.Forms.TextBox codigoItemTextBox;
        private System.Windows.Forms.TextBox descripcionTextBox;
        private System.Windows.Forms.TextBox precioUnitarioTextBox;
        private System.Windows.Forms.TextBox precioReferencialTextBox;
        private System.Windows.Forms.TextBox cantidadTextBox;
        private System.Windows.Forms.ComboBox unidadMedidaComboBox;
        private System.Windows.Forms.TextBox impuestoTextBox;
        private System.Windows.Forms.ComboBox tipoImpuestoComboBox;
        private System.Windows.Forms.TextBox impuestoSelectivoTextBox;
        private System.Windows.Forms.TextBox otroImpuestoTextBox;
        private System.Windows.Forms.TextBox totalVentaTextBox;
        private System.Windows.Forms.ToolStrip barraBotones;
        private System.Windows.Forms.ToolStripButton toolOk;
        private System.Windows.Forms.ToolStripButton toolCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
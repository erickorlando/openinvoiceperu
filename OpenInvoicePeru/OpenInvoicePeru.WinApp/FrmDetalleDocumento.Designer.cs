using System.Windows.Forms;
using OpenInvoicePeru.Firmado.Models;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDetalleDocumento));
            this.idNumericUpDown = new System.Windows.Forms.NumericUpDown();
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
            ((System.ComponentModel.ISupportInitialize)(this.idNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleDocumentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoImpuestoBindingSource)).BeginInit();
            this.barraBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoPrecioBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(12, 35);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(20, 13);
            idLabel.TabIndex = 1;
            idLabel.Text = "Id:";
            // 
            // codigoItemLabel
            // 
            codigoItemLabel.AutoSize = true;
            codigoItemLabel.Location = new System.Drawing.Point(12, 61);
            codigoItemLabel.Name = "codigoItemLabel";
            codigoItemLabel.Size = new System.Drawing.Size(73, 13);
            codigoItemLabel.TabIndex = 2;
            codigoItemLabel.Text = "Código Item:";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(12, 87);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(70, 13);
            descripcionLabel.TabIndex = 4;
            descripcionLabel.Text = "Descripcion:";
            // 
            // precioUnitarioLabel
            // 
            precioUnitarioLabel.AutoSize = true;
            precioUnitarioLabel.Location = new System.Drawing.Point(12, 113);
            precioUnitarioLabel.Name = "precioUnitarioLabel";
            precioUnitarioLabel.Size = new System.Drawing.Size(86, 13);
            precioUnitarioLabel.TabIndex = 6;
            precioUnitarioLabel.Text = "Precio Unitario:";
            // 
            // precioReferencialLabel
            // 
            precioReferencialLabel.AutoSize = true;
            precioReferencialLabel.Location = new System.Drawing.Point(12, 139);
            precioReferencialLabel.Name = "precioReferencialLabel";
            precioReferencialLabel.Size = new System.Drawing.Size(101, 13);
            precioReferencialLabel.TabIndex = 8;
            precioReferencialLabel.Text = "Precio Referencial:";
            // 
            // cantidadLabel
            // 
            cantidadLabel.AutoSize = true;
            cantidadLabel.Location = new System.Drawing.Point(12, 195);
            cantidadLabel.Name = "cantidadLabel";
            cantidadLabel.Size = new System.Drawing.Size(57, 13);
            cantidadLabel.TabIndex = 10;
            cantidadLabel.Text = "Cantidad:";
            // 
            // unidadMedidaLabel
            // 
            unidadMedidaLabel.AutoSize = true;
            unidadMedidaLabel.Location = new System.Drawing.Point(12, 221);
            unidadMedidaLabel.Name = "unidadMedidaLabel";
            unidadMedidaLabel.Size = new System.Drawing.Size(90, 13);
            unidadMedidaLabel.TabIndex = 12;
            unidadMedidaLabel.Text = "Unidad Medida:";
            // 
            // impuestoLabel
            // 
            impuestoLabel.AutoSize = true;
            impuestoLabel.Location = new System.Drawing.Point(12, 247);
            impuestoLabel.Name = "impuestoLabel";
            impuestoLabel.Size = new System.Drawing.Size(58, 13);
            impuestoLabel.TabIndex = 14;
            impuestoLabel.Text = "Impuesto:";
            // 
            // tipoImpuestoLabel
            // 
            tipoImpuestoLabel.AutoSize = true;
            tipoImpuestoLabel.Location = new System.Drawing.Point(12, 273);
            tipoImpuestoLabel.Name = "tipoImpuestoLabel";
            tipoImpuestoLabel.Size = new System.Drawing.Size(83, 13);
            tipoImpuestoLabel.TabIndex = 16;
            tipoImpuestoLabel.Text = "Tipo Impuesto:";
            // 
            // impuestoSelectivoLabel
            // 
            impuestoSelectivoLabel.AutoSize = true;
            impuestoSelectivoLabel.Location = new System.Drawing.Point(12, 299);
            impuestoSelectivoLabel.Name = "impuestoSelectivoLabel";
            impuestoSelectivoLabel.Size = new System.Drawing.Size(106, 13);
            impuestoSelectivoLabel.TabIndex = 18;
            impuestoSelectivoLabel.Text = "Impuesto Selectivo:";
            // 
            // otroImpuestoLabel
            // 
            otroImpuestoLabel.AutoSize = true;
            otroImpuestoLabel.Location = new System.Drawing.Point(12, 325);
            otroImpuestoLabel.Name = "otroImpuestoLabel";
            otroImpuestoLabel.Size = new System.Drawing.Size(85, 13);
            otroImpuestoLabel.TabIndex = 20;
            otroImpuestoLabel.Text = "Otro Impuesto:";
            // 
            // totalVentaLabel
            // 
            totalVentaLabel.AutoSize = true;
            totalVentaLabel.Location = new System.Drawing.Point(12, 351);
            totalVentaLabel.Name = "totalVentaLabel";
            totalVentaLabel.Size = new System.Drawing.Size(66, 13);
            totalVentaLabel.TabIndex = 22;
            totalVentaLabel.Text = "Total Venta:";
            // 
            // tipoPrecioLabel
            // 
            tipoPrecioLabel.AutoSize = true;
            tipoPrecioLabel.Location = new System.Drawing.Point(12, 166);
            tipoPrecioLabel.Name = "tipoPrecioLabel";
            tipoPrecioLabel.Size = new System.Drawing.Size(66, 13);
            tipoPrecioLabel.TabIndex = 27;
            tipoPrecioLabel.Text = "Tipo Precio:";
            // 
            // idNumericUpDown
            // 
            this.idNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.detalleDocumentoBindingSource, "Id", true));
            this.idNumericUpDown.Location = new System.Drawing.Point(118, 33);
            this.idNumericUpDown.Name = "idNumericUpDown";
            this.idNumericUpDown.Size = new System.Drawing.Size(100, 22);
            this.idNumericUpDown.TabIndex = 0;
            this.idNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // detalleDocumentoBindingSource
            // 
            this.detalleDocumentoBindingSource.DataSource = typeof(OpenInvoicePeru.Firmado.Models.DetalleDocumento);
            // 
            // codigoItemTextBox
            // 
            this.codigoItemTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "CodigoItem", true));
            this.codigoItemTextBox.Location = new System.Drawing.Point(118, 58);
            this.codigoItemTextBox.Name = "codigoItemTextBox";
            this.codigoItemTextBox.Size = new System.Drawing.Size(100, 22);
            this.codigoItemTextBox.TabIndex = 1;
            // 
            // descripcionTextBox
            // 
            this.descripcionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "Descripcion", true));
            this.descripcionTextBox.Location = new System.Drawing.Point(118, 84);
            this.descripcionTextBox.Name = "descripcionTextBox";
            this.descripcionTextBox.Size = new System.Drawing.Size(240, 22);
            this.descripcionTextBox.TabIndex = 2;
            // 
            // precioUnitarioTextBox
            // 
            this.precioUnitarioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "PrecioUnitario", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.precioUnitarioTextBox.Location = new System.Drawing.Point(118, 110);
            this.precioUnitarioTextBox.Name = "precioUnitarioTextBox";
            this.precioUnitarioTextBox.Size = new System.Drawing.Size(100, 22);
            this.precioUnitarioTextBox.TabIndex = 3;
            // 
            // precioReferencialTextBox
            // 
            this.precioReferencialTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "PrecioReferencial", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.precioReferencialTextBox.Location = new System.Drawing.Point(118, 136);
            this.precioReferencialTextBox.Name = "precioReferencialTextBox";
            this.precioReferencialTextBox.Size = new System.Drawing.Size(100, 22);
            this.precioReferencialTextBox.TabIndex = 4;
            // 
            // cantidadTextBox
            // 
            this.cantidadTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "Cantidad", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.cantidadTextBox.Location = new System.Drawing.Point(118, 192);
            this.cantidadTextBox.Name = "cantidadTextBox";
            this.cantidadTextBox.Size = new System.Drawing.Size(100, 22);
            this.cantidadTextBox.TabIndex = 6;
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
            this.unidadMedidaComboBox.Location = new System.Drawing.Point(118, 218);
            this.unidadMedidaComboBox.Name = "unidadMedidaComboBox";
            this.unidadMedidaComboBox.Size = new System.Drawing.Size(100, 21);
            this.unidadMedidaComboBox.TabIndex = 7;
            // 
            // impuestoTextBox
            // 
            this.impuestoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "Impuesto", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.impuestoTextBox.Location = new System.Drawing.Point(118, 244);
            this.impuestoTextBox.Name = "impuestoTextBox";
            this.impuestoTextBox.Size = new System.Drawing.Size(100, 22);
            this.impuestoTextBox.TabIndex = 8;
            // 
            // tipoImpuestoComboBox
            // 
            this.tipoImpuestoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.detalleDocumentoBindingSource, "TipoImpuesto", true));
            this.tipoImpuestoComboBox.DataSource = this.tipoImpuestoBindingSource;
            this.tipoImpuestoComboBox.DisplayMember = "DescripcionCompleta";
            this.tipoImpuestoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.tipoImpuestoComboBox.FormattingEnabled = true;
            this.tipoImpuestoComboBox.Location = new System.Drawing.Point(118, 270);
            this.tipoImpuestoComboBox.Name = "tipoImpuestoComboBox";
            this.tipoImpuestoComboBox.Size = new System.Drawing.Size(240, 21);
            this.tipoImpuestoComboBox.TabIndex = 10;
            this.tipoImpuestoComboBox.ValueMember = "Codigo";
            // 
            // tipoImpuestoBindingSource
            // 
            this.tipoImpuestoBindingSource.DataSource = typeof(OpenInvoicePeru.Datos.Entidades.TipoImpuesto);
            // 
            // impuestoSelectivoTextBox
            // 
            this.impuestoSelectivoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "ImpuestoSelectivo", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.impuestoSelectivoTextBox.Location = new System.Drawing.Point(118, 296);
            this.impuestoSelectivoTextBox.Name = "impuestoSelectivoTextBox";
            this.impuestoSelectivoTextBox.Size = new System.Drawing.Size(100, 22);
            this.impuestoSelectivoTextBox.TabIndex = 11;
            // 
            // otroImpuestoTextBox
            // 
            this.otroImpuestoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "OtroImpuesto", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.otroImpuestoTextBox.Location = new System.Drawing.Point(118, 322);
            this.otroImpuestoTextBox.Name = "otroImpuestoTextBox";
            this.otroImpuestoTextBox.Size = new System.Drawing.Size(100, 22);
            this.otroImpuestoTextBox.TabIndex = 13;
            // 
            // totalVentaTextBox
            // 
            this.totalVentaTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.totalVentaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "TotalVenta", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.totalVentaTextBox.Location = new System.Drawing.Point(118, 348);
            this.totalVentaTextBox.Name = "totalVentaTextBox";
            this.totalVentaTextBox.Size = new System.Drawing.Size(100, 22);
            this.totalVentaTextBox.TabIndex = 14;
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
            this.btnCalcIgv.Location = new System.Drawing.Point(233, 242);
            this.btnCalcIgv.Name = "btnCalcIgv";
            this.btnCalcIgv.Size = new System.Drawing.Size(125, 23);
            this.btnCalcIgv.TabIndex = 9;
            this.btnCalcIgv.Text = "C&alcular IGV";
            this.btnCalcIgv.Click += new System.EventHandler(this.btnCalcIgv_Click);
            // 
            // btnCalcIsc
            // 
            this.btnCalcIsc.Location = new System.Drawing.Point(233, 294);
            this.btnCalcIsc.Name = "btnCalcIsc";
            this.btnCalcIsc.Size = new System.Drawing.Size(125, 23);
            this.btnCalcIsc.TabIndex = 12;
            this.btnCalcIsc.Text = "Ca&lcular ISC";
            this.btnCalcIsc.Click += new System.EventHandler(this.btnCalcIsc_Click);
            // 
            // tipoPrecioComboBox
            // 
            this.tipoPrecioComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.detalleDocumentoBindingSource, "TipoPrecio", true));
            this.tipoPrecioComboBox.DataSource = this.tipoPrecioBindingSource;
            this.tipoPrecioComboBox.DisplayMember = "DescripcionCompleta";
            this.tipoPrecioComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.tipoPrecioComboBox.FormattingEnabled = true;
            this.tipoPrecioComboBox.Location = new System.Drawing.Point(118, 163);
            this.tipoPrecioComboBox.Name = "tipoPrecioComboBox";
            this.tipoPrecioComboBox.Size = new System.Drawing.Size(240, 21);
            this.tipoPrecioComboBox.TabIndex = 5;
            this.tipoPrecioComboBox.ValueMember = "Codigo";
            // 
            // tipoPrecioBindingSource
            // 
            this.tipoPrecioBindingSource.DataSource = typeof(OpenInvoicePeru.Datos.Entidades.TipoPrecio);
            // 
            // FrmDetalleDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 379);
            this.Controls.Add(tipoPrecioLabel);
            this.Controls.Add(this.tipoPrecioComboBox);
            this.Controls.Add(this.btnCalcIsc);
            this.Controls.Add(this.btnCalcIgv);
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
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDetalleDocumento";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle del Documento";
            ((System.ComponentModel.ISupportInitialize)(this.idNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleDocumentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoImpuestoBindingSource)).EndInit();
            this.barraBotones.ResumeLayout(false);
            this.barraBotones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoPrecioBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource detalleDocumentoBindingSource;
        private System.Windows.Forms.NumericUpDown idNumericUpDown;
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
    }
}
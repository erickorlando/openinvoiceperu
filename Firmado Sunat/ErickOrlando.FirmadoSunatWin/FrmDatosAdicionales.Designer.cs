namespace OpenInvoicePeru.FirmadoSunatWin
{
    partial class FrmDatosAdicionales
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
            System.Windows.Forms.Label codigoLabel;
            System.Windows.Forms.Label contenidoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDatosAdicionales));
            this.datoAdicionalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codigoComboBox = new System.Windows.Forms.ComboBox();
            this.contenidoTextBox = new System.Windows.Forms.TextBox();
            this.barraBotones = new System.Windows.Forms.ToolStrip();
            this.toolOk = new System.Windows.Forms.ToolStripButton();
            this.toolCancel = new System.Windows.Forms.ToolStripButton();
            codigoLabel = new System.Windows.Forms.Label();
            contenidoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datoAdicionalBindingSource)).BeginInit();
            this.barraBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // codigoLabel
            // 
            codigoLabel.AutoSize = true;
            codigoLabel.Location = new System.Drawing.Point(12, 43);
            codigoLabel.Name = "codigoLabel";
            codigoLabel.Size = new System.Drawing.Size(43, 13);
            codigoLabel.TabIndex = 1;
            codigoLabel.Text = "Codigo:";
            // 
            // contenidoLabel
            // 
            contenidoLabel.AutoSize = true;
            contenidoLabel.Location = new System.Drawing.Point(12, 74);
            contenidoLabel.Name = "contenidoLabel";
            contenidoLabel.Size = new System.Drawing.Size(58, 13);
            contenidoLabel.TabIndex = 3;
            contenidoLabel.Text = "Contenido:";
            // 
            // datoAdicionalBindingSource
            // 
            this.datoAdicionalBindingSource.DataSource = typeof(OpenInvoicePeru.FirmadoSunat.Models.DatoAdicional);
            // 
            // codigoComboBox
            // 
            this.codigoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codigoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codigoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datoAdicionalBindingSource, "Codigo", true));
            this.codigoComboBox.FormattingEnabled = true;
            this.codigoComboBox.Items.AddRange(new object[] {
            "3000 Detracciones: CODIGO DE BB Y SS SUJETOS A DETRACCION",
            "3001 Detracciones: NUMERO DE CTA EN EL BN",
            "3002 Detracciones: Recursos Hidrobiológicos-Nombre y matrícula de la embarcación",
            "3003 Detracciones: Recursos Hidrobiológicos-Tipo y cantidad de especie vendida",
            "3004 Detracciones: Recursos Hidrobiológicos -Lugar de descarga",
            "3005 Detracciones: Recursos Hidrobiológicos -Fecha de descarga",
            "3006 Detracciones: Transporte Bienes vía terrestre – Numero Registro MTC",
            "3007 Detracciones: Transporte Bienes vía terrestre – configuración vehicular",
            "3008 Detracciones: Transporte Bienes vía terrestre – punto de origen",
            "3009 Detracciones: Transporte Bienes vía terrestre – punto destino",
            "3010 Detracciones: Transporte Bienes vía terrestre – valor referencial preliminar" +
                "",
            "4000 Beneficio hospedajes: Código País de emisión del pasaporte",
            "4001 Beneficio hospedajes: Código País de residencia del sujeto no domiciliado",
            "4002 Beneficio Hospedajes: Fecha de ingreso al país",
            "4003 Beneficio Hospedajes: Fecha de ingreso al establecimiento",
            "4004 Beneficio Hospedajes: Fecha de salida del establecimiento",
            "4005 Beneficio Hospedajes: Número de días de permanencia",
            "4006 Beneficio Hospedajes: Fecha de consumo",
            "4007 Beneficio Hospedajes: Paquete turístico - Nombres y Apellidos del Huésped",
            "4008 Beneficio Hospedajes: Paquete turístico – Tipo documento identidad del huésp" +
                "ed",
            "4009 Beneficio Hospedajes: Paquete turístico – Numero de documento identidad de h" +
                "uésped",
            "5000 Proveedores Estado: Número de Expediente",
            "5001 Proveedores Estado : Código de unidad ejecutora",
            "5002 Proveedores Estado : N° de proceso de selección",
            "5003 Proveedores Estado : N° de contrato",
            "6000 Comercialización de Oro : Código Único Concesión Minera",
            "6001 Comercialización de Oro : N° declaración compromiso",
            "6002 Comercialización de Oro : N° Reg. Especial .Comerci. Oro",
            "6003 Comercialización de Oro : N° Resolución que autoriza Planta de Beneficio",
            "6004 Comercialización de Oro : Ley Mineral (% concent. oro)"});
            this.codigoComboBox.Location = new System.Drawing.Point(71, 40);
            this.codigoComboBox.Name = "codigoComboBox";
            this.codigoComboBox.Size = new System.Drawing.Size(336, 21);
            this.codigoComboBox.TabIndex = 2;
            // 
            // contenidoTextBox
            // 
            this.contenidoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datoAdicionalBindingSource, "Contenido", true));
            this.contenidoTextBox.Location = new System.Drawing.Point(71, 71);
            this.contenidoTextBox.Name = "contenidoTextBox";
            this.contenidoTextBox.Size = new System.Drawing.Size(336, 20);
            this.contenidoTextBox.TabIndex = 4;
            // 
            // barraBotones
            // 
            this.barraBotones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOk,
            this.toolCancel});
            this.barraBotones.Location = new System.Drawing.Point(0, 0);
            this.barraBotones.Name = "barraBotones";
            this.barraBotones.Size = new System.Drawing.Size(419, 25);
            this.barraBotones.TabIndex = 5;
            this.barraBotones.Text = "toolStrip1";
            // 
            // toolOk
            // 
            this.toolOk.Image = global::OpenInvoicePeru.FirmadoSunatWin.Properties.Resources.aceptar;
            this.toolOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOk.Name = "toolOk";
            this.toolOk.Size = new System.Drawing.Size(68, 22);
            this.toolOk.Text = "&Aceptar";
            this.toolOk.Click += new System.EventHandler(this.toolOk_Click);
            // 
            // toolCancel
            // 
            this.toolCancel.Image = global::OpenInvoicePeru.FirmadoSunatWin.Properties.Resources.cancelar;
            this.toolCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCancel.Name = "toolCancel";
            this.toolCancel.Size = new System.Drawing.Size(73, 22);
            this.toolCancel.Text = "&Cancelar";
            // 
            // FrmDatosAdicionales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 113);
            this.Controls.Add(this.barraBotones);
            this.Controls.Add(contenidoLabel);
            this.Controls.Add(this.contenidoTextBox);
            this.Controls.Add(codigoLabel);
            this.Controls.Add(this.codigoComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDatosAdicionales";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datos Adicionales";
            ((System.ComponentModel.ISupportInitialize)(this.datoAdicionalBindingSource)).EndInit();
            this.barraBotones.ResumeLayout(false);
            this.barraBotones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource datoAdicionalBindingSource;
        private System.Windows.Forms.ComboBox codigoComboBox;
        private System.Windows.Forms.TextBox contenidoTextBox;
        private System.Windows.Forms.ToolStrip barraBotones;
        private System.Windows.Forms.ToolStripButton toolOk;
        private System.Windows.Forms.ToolStripButton toolCancel;
    }
}
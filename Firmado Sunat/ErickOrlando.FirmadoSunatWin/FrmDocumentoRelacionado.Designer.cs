namespace OpenInvoicePeru.FirmadoSunatWin
{
    partial class FrmDocumentoRelacionado
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
            System.Windows.Forms.Label tipoDocumentoLabel;
            System.Windows.Forms.Label nroDocumentoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDocumentoRelacionado));
            this.barraBotones = new System.Windows.Forms.ToolStrip();
            this.toolOk = new System.Windows.Forms.ToolStripButton();
            this.toolCancel = new System.Windows.Forms.ToolStripButton();
            this.documentoRelacionadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipoDocumentoComboBox = new System.Windows.Forms.ComboBox();
            this.nroDocumentoTextBox = new System.Windows.Forms.TextBox();
            tipoDocumentoLabel = new System.Windows.Forms.Label();
            nroDocumentoLabel = new System.Windows.Forms.Label();
            this.barraBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentoRelacionadoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // barraBotones
            // 
            this.barraBotones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOk,
            this.toolCancel});
            this.barraBotones.Location = new System.Drawing.Point(0, 0);
            this.barraBotones.Name = "barraBotones";
            this.barraBotones.Size = new System.Drawing.Size(379, 25);
            this.barraBotones.TabIndex = 6;
            this.barraBotones.Text = "toolStrip1";
            // 
            // toolOk
            // 
            this.toolOk.Image = global::OpenInvoicePeru.FirmadoSunatWin.Properties.Resources.aceptar;
            this.toolOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOk.Name = "toolOk";
            this.toolOk.Size = new System.Drawing.Size(68, 22);
            this.toolOk.Text = "&Aceptar";
            // 
            // toolCancel
            // 
            this.toolCancel.Image = global::OpenInvoicePeru.FirmadoSunatWin.Properties.Resources.cancelar;
            this.toolCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCancel.Name = "toolCancel";
            this.toolCancel.Size = new System.Drawing.Size(73, 22);
            this.toolCancel.Text = "&Cancelar";
            // 
            // documentoRelacionadoBindingSource
            // 
            this.documentoRelacionadoBindingSource.DataSource = typeof(OpenInvoicePeru.FirmadoSunat.Models.DocumentoRelacionado);
            // 
            // tipoDocumentoLabel
            // 
            tipoDocumentoLabel.AutoSize = true;
            tipoDocumentoLabel.Location = new System.Drawing.Point(9, 41);
            tipoDocumentoLabel.Name = "tipoDocumentoLabel";
            tipoDocumentoLabel.Size = new System.Drawing.Size(89, 13);
            tipoDocumentoLabel.TabIndex = 7;
            tipoDocumentoLabel.Text = "Tipo Documento:";
            // 
            // tipoDocumentoComboBox
            // 
            this.tipoDocumentoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoRelacionadoBindingSource, "TipoDocumento", true));
            this.tipoDocumentoComboBox.FormattingEnabled = true;
            this.tipoDocumentoComboBox.Items.AddRange(new object[] {
            "01 FACTURA",
            "03 BOLETA DE VENTA",
            "07 NOTA DE CREDITO",
            "08 NOTA DE DEBITO",
            "09 GUIA DE REMISIÓN REMITENTE",
            "13 DOCUMENTO EMITIDO POR BANCOS, II.FF., CREDITICIAS Y DE SEGUROS",
            "18 DOCUMENTOS EMITIDOS POR LAS AFP",
            "31 GUIA DE REMISIÓN TRANSPORTISTA",
            "56 COMPROBANTE DE PAGO SEAE"});
            this.tipoDocumentoComboBox.Location = new System.Drawing.Point(104, 38);
            this.tipoDocumentoComboBox.Name = "tipoDocumentoComboBox";
            this.tipoDocumentoComboBox.Size = new System.Drawing.Size(236, 21);
            this.tipoDocumentoComboBox.TabIndex = 8;
            // 
            // nroDocumentoLabel
            // 
            nroDocumentoLabel.AutoSize = true;
            nroDocumentoLabel.Location = new System.Drawing.Point(9, 68);
            nroDocumentoLabel.Name = "nroDocumentoLabel";
            nroDocumentoLabel.Size = new System.Drawing.Size(85, 13);
            nroDocumentoLabel.TabIndex = 8;
            nroDocumentoLabel.Text = "Nro Documento:";
            // 
            // nroDocumentoTextBox
            // 
            this.nroDocumentoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoRelacionadoBindingSource, "NroDocumento", true));
            this.nroDocumentoTextBox.Location = new System.Drawing.Point(104, 65);
            this.nroDocumentoTextBox.Name = "nroDocumentoTextBox";
            this.nroDocumentoTextBox.Size = new System.Drawing.Size(152, 20);
            this.nroDocumentoTextBox.TabIndex = 9;
            // 
            // FrmDocumentoRelacionado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 104);
            this.Controls.Add(nroDocumentoLabel);
            this.Controls.Add(this.nroDocumentoTextBox);
            this.Controls.Add(tipoDocumentoLabel);
            this.Controls.Add(this.tipoDocumentoComboBox);
            this.Controls.Add(this.barraBotones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDocumentoRelacionado";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Documento Relacionado";
            this.barraBotones.ResumeLayout(false);
            this.barraBotones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentoRelacionadoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip barraBotones;
        private System.Windows.Forms.ToolStripButton toolOk;
        private System.Windows.Forms.ToolStripButton toolCancel;
        private System.Windows.Forms.BindingSource documentoRelacionadoBindingSource;
        private System.Windows.Forms.ComboBox tipoDocumentoComboBox;
        private System.Windows.Forms.TextBox nroDocumentoTextBox;
    }
}

namespace OpenInvoicePeru.WinApp
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
            ComponentFactory.Krypton.Toolkit.KryptonLabel tipoDocumentoLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel nroDocumentoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDocumentoRelacionado));
            this.barraBotones = new System.Windows.Forms.ToolStrip();
            this.toolOk = new System.Windows.Forms.ToolStripButton();
            this.toolCancel = new System.Windows.Forms.ToolStripButton();
            this.documentoRelacionadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipoDocumentoComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.tipoDocumentoRelacionadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nroDocumentoTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            tipoDocumentoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            nroDocumentoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.barraBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentoRelacionadoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDocumentoComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDocumentoRelacionadoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tipoDocumentoLabel
            // 
            tipoDocumentoLabel.Location = new System.Drawing.Point(7, 15);
            tipoDocumentoLabel.Name = "tipoDocumentoLabel";
            tipoDocumentoLabel.Size = new System.Drawing.Size(105, 20);
            tipoDocumentoLabel.TabIndex = 7;
            tipoDocumentoLabel.Values.Text = "Tipo Documento:";
            // 
            // nroDocumentoLabel
            // 
            nroDocumentoLabel.Location = new System.Drawing.Point(7, 42);
            nroDocumentoLabel.Name = "nroDocumentoLabel";
            nroDocumentoLabel.Size = new System.Drawing.Size(101, 20);
            nroDocumentoLabel.TabIndex = 8;
            nroDocumentoLabel.Values.Text = "Nro Documento:";
            // 
            // barraBotones
            // 
            this.barraBotones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.barraBotones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOk,
            this.toolCancel});
            this.barraBotones.Location = new System.Drawing.Point(0, 0);
            this.barraBotones.Name = "barraBotones";
            this.barraBotones.Size = new System.Drawing.Size(365, 25);
            this.barraBotones.TabIndex = 6;
            this.barraBotones.Text = "toolStrip1";
            // 
            // toolOk
            // 
            this.toolOk.Image = global::OpenInvoicePeru.WinApp.Properties.Resources.aceptar;
            this.toolOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOk.Name = "toolOk";
            this.toolOk.Size = new System.Drawing.Size(68, 22);
            this.toolOk.Text = "&Aceptar";
            // 
            // toolCancel
            // 
            this.toolCancel.Image = global::OpenInvoicePeru.WinApp.Properties.Resources.cancelar;
            this.toolCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCancel.Name = "toolCancel";
            this.toolCancel.Size = new System.Drawing.Size(73, 22);
            this.toolCancel.Text = "&Cancelar";
            // 
            // documentoRelacionadoBindingSource
            // 
            this.documentoRelacionadoBindingSource.DataSource = typeof(OpenInvoicePeru.Comun.Dto.Modelos.DocumentoRelacionado);
            // 
            // tipoDocumentoComboBox
            // 
            this.tipoDocumentoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.documentoRelacionadoBindingSource, "TipoDocumento", true));
            this.tipoDocumentoComboBox.DataSource = this.tipoDocumentoRelacionadoBindingSource;
            this.tipoDocumentoComboBox.DisplayMember = "DescripcionCompleta";
            this.tipoDocumentoComboBox.DropDownWidth = 236;
            this.tipoDocumentoComboBox.FormattingEnabled = true;
            this.tipoDocumentoComboBox.Location = new System.Drawing.Point(107, 12);
            this.tipoDocumentoComboBox.Name = "tipoDocumentoComboBox";
            this.tipoDocumentoComboBox.Size = new System.Drawing.Size(236, 21);
            this.tipoDocumentoComboBox.TabIndex = 8;
            this.tipoDocumentoComboBox.ValueMember = "Codigo";
            // 
            // tipoDocumentoRelacionadoBindingSource
            // 
            this.tipoDocumentoRelacionadoBindingSource.DataSource = typeof(OpenInvoicePeru.Entidades.TipoDocumentoRelacionado);
            // 
            // nroDocumentoTextBox
            // 
            this.nroDocumentoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoRelacionadoBindingSource, "NroDocumento", true));
            this.nroDocumentoTextBox.Location = new System.Drawing.Point(107, 39);
            this.nroDocumentoTextBox.Name = "nroDocumentoTextBox";
            this.nroDocumentoTextBox.Size = new System.Drawing.Size(152, 23);
            this.nroDocumentoTextBox.TabIndex = 9;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.nroDocumentoTextBox);
            this.kryptonPanel1.Controls.Add(nroDocumentoLabel);
            this.kryptonPanel1.Controls.Add(this.tipoDocumentoComboBox);
            this.kryptonPanel1.Controls.Add(tipoDocumentoLabel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 25);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(365, 76);
            this.kryptonPanel1.TabIndex = 10;
            // 
            // FrmDocumentoRelacionado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 101);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.barraBotones);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDocumentoRelacionado";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Documento Relacionado";
            this.barraBotones.ResumeLayout(false);
            this.barraBotones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentoRelacionadoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDocumentoComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDocumentoRelacionadoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip barraBotones;
        private System.Windows.Forms.ToolStripButton toolOk;
        private System.Windows.Forms.ToolStripButton toolCancel;
        private System.Windows.Forms.BindingSource documentoRelacionadoBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox tipoDocumentoComboBox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox nroDocumentoTextBox;
        private System.Windows.Forms.BindingSource tipoDocumentoRelacionadoBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
    }
}
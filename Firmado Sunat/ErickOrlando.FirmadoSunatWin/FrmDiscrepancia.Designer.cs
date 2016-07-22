namespace OpenInvoicePeru.FirmadoSunatWin
{
    partial class FrmDiscrepancia
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
            System.Windows.Forms.Label tipoLabel;
            System.Windows.Forms.Label nroReferenciaLabel;
            System.Windows.Forms.Label descripcionLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDiscrepancia));
            this.barraBotones = new System.Windows.Forms.ToolStrip();
            this.toolOk = new System.Windows.Forms.ToolStripButton();
            this.toolCancel = new System.Windows.Forms.ToolStripButton();
            this.discrepanciaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipoComboBox = new System.Windows.Forms.ComboBox();
            this.nroReferenciaTextBox = new System.Windows.Forms.TextBox();
            this.descripcionTextBox = new System.Windows.Forms.TextBox();
            tipoLabel = new System.Windows.Forms.Label();
            nroReferenciaLabel = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            this.barraBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discrepanciaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tipoLabel
            // 
            tipoLabel.AutoSize = true;
            tipoLabel.Location = new System.Drawing.Point(6, 37);
            tipoLabel.Name = "tipoLabel";
            tipoLabel.Size = new System.Drawing.Size(31, 13);
            tipoLabel.TabIndex = 7;
            tipoLabel.Text = "Tipo:";
            // 
            // nroReferenciaLabel
            // 
            nroReferenciaLabel.AutoSize = true;
            nroReferenciaLabel.Location = new System.Drawing.Point(6, 64);
            nroReferenciaLabel.Name = "nroReferenciaLabel";
            nroReferenciaLabel.Size = new System.Drawing.Size(82, 13);
            nroReferenciaLabel.TabIndex = 8;
            nroReferenciaLabel.Text = "Nro Referencia:";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(6, 90);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(66, 13);
            descripcionLabel.TabIndex = 9;
            descripcionLabel.Text = "Descripcion:";
            // 
            // barraBotones
            // 
            this.barraBotones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOk,
            this.toolCancel});
            this.barraBotones.Location = new System.Drawing.Point(0, 0);
            this.barraBotones.Name = "barraBotones";
            this.barraBotones.Size = new System.Drawing.Size(376, 25);
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
            // discrepanciaBindingSource
            // 
            this.discrepanciaBindingSource.DataSource = typeof(OpenInvoicePeru.FirmadoSunat.Models.Discrepancia);
            // 
            // tipoComboBox
            // 
            this.tipoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tipoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tipoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.discrepanciaBindingSource, "Tipo", true));
            this.tipoComboBox.FormattingEnabled = true;
            this.tipoComboBox.Items.AddRange(new object[] {
            "--Notas de Crédito--",
            "01 Anulación de la operación",
            "02 Anulación por error en el RUC",
            "03 Corrección por error en la descripción",
            "04 Descuento global",
            "05 Descuento por ítem",
            "06 Devolución total",
            "07 Devolución por ítem",
            "08 Bonificación",
            "09 Disminución en el valor",
            "10 Otros Conceptos",
            "--Notas de Débito--",
            "01 Intereses por mora",
            "02 Aumento en el valor",
            "03 Penalidades/otros conceptos"});
            this.tipoComboBox.Location = new System.Drawing.Point(95, 34);
            this.tipoComboBox.Name = "tipoComboBox";
            this.tipoComboBox.Size = new System.Drawing.Size(265, 21);
            this.tipoComboBox.TabIndex = 8;
            // 
            // nroReferenciaTextBox
            // 
            this.nroReferenciaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.discrepanciaBindingSource, "NroReferencia", true));
            this.nroReferenciaTextBox.Location = new System.Drawing.Point(95, 61);
            this.nroReferenciaTextBox.Name = "nroReferenciaTextBox";
            this.nroReferenciaTextBox.Size = new System.Drawing.Size(100, 20);
            this.nroReferenciaTextBox.TabIndex = 9;
            // 
            // descripcionTextBox
            // 
            this.descripcionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.discrepanciaBindingSource, "Descripcion", true));
            this.descripcionTextBox.Location = new System.Drawing.Point(95, 87);
            this.descripcionTextBox.Name = "descripcionTextBox";
            this.descripcionTextBox.Size = new System.Drawing.Size(265, 20);
            this.descripcionTextBox.TabIndex = 10;
            // 
            // FrmDiscrepancia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 119);
            this.Controls.Add(descripcionLabel);
            this.Controls.Add(this.descripcionTextBox);
            this.Controls.Add(nroReferenciaLabel);
            this.Controls.Add(this.nroReferenciaTextBox);
            this.Controls.Add(tipoLabel);
            this.Controls.Add(this.tipoComboBox);
            this.Controls.Add(this.barraBotones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDiscrepancia";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Discrepancia";
            this.barraBotones.ResumeLayout(false);
            this.barraBotones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discrepanciaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip barraBotones;
        private System.Windows.Forms.ToolStripButton toolOk;
        private System.Windows.Forms.ToolStripButton toolCancel;
        private System.Windows.Forms.BindingSource discrepanciaBindingSource;
        private System.Windows.Forms.ComboBox tipoComboBox;
        private System.Windows.Forms.TextBox nroReferenciaTextBox;
        private System.Windows.Forms.TextBox descripcionTextBox;
    }
}
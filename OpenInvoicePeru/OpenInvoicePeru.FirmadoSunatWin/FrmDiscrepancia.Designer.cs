using OpenInvoicePeru.Firmado.Models;

namespace OpenInvoicePeru.WinApp
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
            this.tipoDiscrepanciaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            tipoLabel = new System.Windows.Forms.Label();
            nroReferenciaLabel = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            this.barraBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discrepanciaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDiscrepanciaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tipoLabel
            // 
            tipoLabel.AutoSize = true;
            tipoLabel.Location = new System.Drawing.Point(6, 37);
            tipoLabel.Name = "tipoLabel";
            tipoLabel.Size = new System.Drawing.Size(32, 13);
            tipoLabel.TabIndex = 7;
            tipoLabel.Text = "Tipo:";
            // 
            // nroReferenciaLabel
            // 
            nroReferenciaLabel.AutoSize = true;
            nroReferenciaLabel.Location = new System.Drawing.Point(6, 64);
            nroReferenciaLabel.Name = "nroReferenciaLabel";
            nroReferenciaLabel.Size = new System.Drawing.Size(86, 13);
            nroReferenciaLabel.TabIndex = 8;
            nroReferenciaLabel.Text = "Nro Referencia:";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(6, 90);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(70, 13);
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
            // discrepanciaBindingSource
            // 
            this.discrepanciaBindingSource.DataSource = typeof(Discrepancia);
            // 
            // tipoComboBox
            // 
            this.tipoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tipoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tipoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.discrepanciaBindingSource, "Tipo", true));
            this.tipoComboBox.DataSource = this.tipoDiscrepanciaBindingSource;
            this.tipoComboBox.DisplayMember = "Descripcion";
            this.tipoComboBox.FormattingEnabled = true;
            this.tipoComboBox.Location = new System.Drawing.Point(95, 34);
            this.tipoComboBox.Name = "tipoComboBox";
            this.tipoComboBox.Size = new System.Drawing.Size(265, 21);
            this.tipoComboBox.TabIndex = 8;
            this.tipoComboBox.ValueMember = "Codigo";
            // 
            // nroReferenciaTextBox
            // 
            this.nroReferenciaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.discrepanciaBindingSource, "NroReferencia", true));
            this.nroReferenciaTextBox.Location = new System.Drawing.Point(95, 61);
            this.nroReferenciaTextBox.Name = "nroReferenciaTextBox";
            this.nroReferenciaTextBox.Size = new System.Drawing.Size(100, 22);
            this.nroReferenciaTextBox.TabIndex = 9;
            // 
            // descripcionTextBox
            // 
            this.descripcionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.discrepanciaBindingSource, "Descripcion", true));
            this.descripcionTextBox.Location = new System.Drawing.Point(95, 87);
            this.descripcionTextBox.Name = "descripcionTextBox";
            this.descripcionTextBox.Size = new System.Drawing.Size(265, 22);
            this.descripcionTextBox.TabIndex = 10;
            // 
            // tipoDiscrepanciaBindingSource
            // 
            this.tipoDiscrepanciaBindingSource.DataSource = typeof(OpenInvoicePeru.Datos.Entidades.TipoDiscrepancia);
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
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            ((System.ComponentModel.ISupportInitialize)(this.tipoDiscrepanciaBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource tipoDiscrepanciaBindingSource;
    }
}
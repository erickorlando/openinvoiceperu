
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
            ComponentFactory.Krypton.Toolkit.KryptonLabel tipoLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel nroReferenciaLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel descripcionLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDiscrepancia));
            this.barraBotones = new System.Windows.Forms.ToolStrip();
            this.toolOk = new System.Windows.Forms.ToolStripButton();
            this.toolCancel = new System.Windows.Forms.ToolStripButton();
            this.discrepanciaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipoComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.tipoDiscrepanciaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nroReferenciaTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.descripcionTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            tipoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            nroReferenciaLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            descripcionLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.barraBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discrepanciaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDiscrepanciaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tipoLabel
            // 
            tipoLabel.Location = new System.Drawing.Point(6, 11);
            tipoLabel.Name = "tipoLabel";
            tipoLabel.Size = new System.Drawing.Size(37, 20);
            tipoLabel.TabIndex = 7;
            tipoLabel.Values.Text = "Tipo:";
            // 
            // nroReferenciaLabel
            // 
            nroReferenciaLabel.Location = new System.Drawing.Point(6, 38);
            nroReferenciaLabel.Name = "nroReferenciaLabel";
            nroReferenciaLabel.Size = new System.Drawing.Size(94, 20);
            nroReferenciaLabel.TabIndex = 8;
            nroReferenciaLabel.Values.Text = "Nro Referencia:";
            // 
            // descripcionLabel
            // 
            descripcionLabel.Location = new System.Drawing.Point(6, 64);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(77, 20);
            descripcionLabel.TabIndex = 9;
            descripcionLabel.Values.Text = "Descripcion:";
            // 
            // barraBotones
            // 
            this.barraBotones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.barraBotones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOk,
            this.toolCancel});
            this.barraBotones.Location = new System.Drawing.Point(0, 0);
            this.barraBotones.Name = "barraBotones";
            this.barraBotones.Size = new System.Drawing.Size(383, 25);
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
            this.discrepanciaBindingSource.DataSource = typeof(OpenInvoicePeru.Comun.Dto.Modelos.Discrepancia);
            // 
            // tipoComboBox
            // 
            this.tipoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tipoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tipoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.discrepanciaBindingSource, "Tipo", true));
            this.tipoComboBox.DataSource = this.tipoDiscrepanciaBindingSource;
            this.tipoComboBox.DisplayMember = "DescripcionCompleta";
            this.tipoComboBox.DropDownWidth = 265;
            this.tipoComboBox.FormattingEnabled = true;
            this.tipoComboBox.Location = new System.Drawing.Point(109, 8);
            this.tipoComboBox.Name = "tipoComboBox";
            this.tipoComboBox.Size = new System.Drawing.Size(265, 21);
            this.tipoComboBox.TabIndex = 8;
            this.tipoComboBox.ValueMember = "Codigo";
            // 
            // tipoDiscrepanciaBindingSource
            // 
            this.tipoDiscrepanciaBindingSource.DataSource = typeof(OpenInvoicePeru.Entidades.TipoDiscrepancia);
            // 
            // nroReferenciaTextBox
            // 
            this.nroReferenciaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.discrepanciaBindingSource, "NroReferencia", true));
            this.nroReferenciaTextBox.Location = new System.Drawing.Point(109, 35);
            this.nroReferenciaTextBox.Name = "nroReferenciaTextBox";
            this.nroReferenciaTextBox.Size = new System.Drawing.Size(100, 23);
            this.nroReferenciaTextBox.TabIndex = 9;
            // 
            // descripcionTextBox
            // 
            this.descripcionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.discrepanciaBindingSource, "Descripcion", true));
            this.descripcionTextBox.Location = new System.Drawing.Point(109, 61);
            this.descripcionTextBox.Name = "descripcionTextBox";
            this.descripcionTextBox.Size = new System.Drawing.Size(265, 23);
            this.descripcionTextBox.TabIndex = 10;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(descripcionLabel);
            this.kryptonPanel1.Controls.Add(this.tipoComboBox);
            this.kryptonPanel1.Controls.Add(this.descripcionTextBox);
            this.kryptonPanel1.Controls.Add(tipoLabel);
            this.kryptonPanel1.Controls.Add(nroReferenciaLabel);
            this.kryptonPanel1.Controls.Add(this.nroReferenciaTextBox);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 25);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(383, 95);
            this.kryptonPanel1.TabIndex = 11;
            // 
            // FrmDiscrepancia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 120);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.barraBotones);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDiscrepancia";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Discrepancia";
            this.barraBotones.ResumeLayout(false);
            this.barraBotones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discrepanciaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDiscrepanciaBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource discrepanciaBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox tipoComboBox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox nroReferenciaTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox descripcionTextBox;
        private System.Windows.Forms.BindingSource tipoDiscrepanciaBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
    }
}
using OpenInvoicePeru.Firmado.Models;

namespace OpenInvoicePeru.WinApp
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
            this.tipoDatoAdicionalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            codigoLabel = new System.Windows.Forms.Label();
            contenidoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datoAdicionalBindingSource)).BeginInit();
            this.barraBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDatoAdicionalBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // codigoLabel
            // 
            codigoLabel.AutoSize = true;
            codigoLabel.Location = new System.Drawing.Point(12, 43);
            codigoLabel.Name = "codigoLabel";
            codigoLabel.Size = new System.Drawing.Size(48, 13);
            codigoLabel.TabIndex = 1;
            codigoLabel.Text = "Codigo:";
            // 
            // contenidoLabel
            // 
            contenidoLabel.AutoSize = true;
            contenidoLabel.Location = new System.Drawing.Point(12, 74);
            contenidoLabel.Name = "contenidoLabel";
            contenidoLabel.Size = new System.Drawing.Size(65, 13);
            contenidoLabel.TabIndex = 3;
            contenidoLabel.Text = "Contenido:";
            // 
            // datoAdicionalBindingSource
            // 
            this.datoAdicionalBindingSource.DataSource = typeof(DatoAdicional);
            // 
            // codigoComboBox
            // 
            this.codigoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codigoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codigoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.datoAdicionalBindingSource, "Codigo", true));
            this.codigoComboBox.DataSource = this.tipoDatoAdicionalBindingSource;
            this.codigoComboBox.DisplayMember = "Descripcion";
            this.codigoComboBox.FormattingEnabled = true;
            this.codigoComboBox.Location = new System.Drawing.Point(80, 40);
            this.codigoComboBox.Name = "codigoComboBox";
            this.codigoComboBox.Size = new System.Drawing.Size(336, 21);
            this.codigoComboBox.TabIndex = 2;
            this.codigoComboBox.ValueMember = "Codigo";
            // 
            // contenidoTextBox
            // 
            this.contenidoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datoAdicionalBindingSource, "Contenido", true));
            this.contenidoTextBox.Location = new System.Drawing.Point(80, 71);
            this.contenidoTextBox.Name = "contenidoTextBox";
            this.contenidoTextBox.Size = new System.Drawing.Size(336, 22);
            this.contenidoTextBox.TabIndex = 4;
            // 
            // barraBotones
            // 
            this.barraBotones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOk,
            this.toolCancel});
            this.barraBotones.Location = new System.Drawing.Point(0, 0);
            this.barraBotones.Name = "barraBotones";
            this.barraBotones.Size = new System.Drawing.Size(440, 25);
            this.barraBotones.TabIndex = 5;
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
            // 
            // tipoDatoAdicionalBindingSource
            // 
            this.tipoDatoAdicionalBindingSource.DataSource = typeof(OpenInvoicePeru.Datos.Entidades.TipoDatoAdicional);
            // 
            // FrmDatosAdicionales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 113);
            this.Controls.Add(this.barraBotones);
            this.Controls.Add(contenidoLabel);
            this.Controls.Add(this.contenidoTextBox);
            this.Controls.Add(codigoLabel);
            this.Controls.Add(this.codigoComboBox);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            ((System.ComponentModel.ISupportInitialize)(this.tipoDatoAdicionalBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource tipoDatoAdicionalBindingSource;
    }
}
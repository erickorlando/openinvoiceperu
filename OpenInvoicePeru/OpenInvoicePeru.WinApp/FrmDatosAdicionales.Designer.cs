
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
            ComponentFactory.Krypton.Toolkit.KryptonLabel codigoLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel contenidoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDatosAdicionales));
            this.datoAdicionalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codigoComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.tipoDatoAdicionalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contenidoTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.barraBotones = new System.Windows.Forms.ToolStrip();
            this.toolOk = new System.Windows.Forms.ToolStripButton();
            this.toolCancel = new System.Windows.Forms.ToolStripButton();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            codigoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            contenidoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.datoAdicionalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigoComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDatoAdicionalBindingSource)).BeginInit();
            this.barraBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // codigoLabel
            // 
            codigoLabel.Location = new System.Drawing.Point(11, 15);
            codigoLabel.Name = "codigoLabel";
            codigoLabel.Size = new System.Drawing.Size(53, 20);
            codigoLabel.TabIndex = 1;
            codigoLabel.Values.Text = "Codigo:";
            // 
            // contenidoLabel
            // 
            contenidoLabel.Location = new System.Drawing.Point(11, 46);
            contenidoLabel.Name = "contenidoLabel";
            contenidoLabel.Size = new System.Drawing.Size(70, 20);
            contenidoLabel.TabIndex = 3;
            contenidoLabel.Values.Text = "Contenido:";
            // 
            // datoAdicionalBindingSource
            // 
            this.datoAdicionalBindingSource.DataSource = typeof(OpenInvoicePeru.Comun.Dto.Modelos.DatoAdicional);
            // 
            // codigoComboBox
            // 
            this.codigoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codigoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codigoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.datoAdicionalBindingSource, "Codigo", true));
            this.codigoComboBox.DataSource = this.tipoDatoAdicionalBindingSource;
            this.codigoComboBox.DisplayMember = "DescripcionCompleta";
            this.codigoComboBox.DropDownWidth = 336;
            this.codigoComboBox.FormattingEnabled = true;
            this.codigoComboBox.Location = new System.Drawing.Point(87, 12);
            this.codigoComboBox.Name = "codigoComboBox";
            this.codigoComboBox.Size = new System.Drawing.Size(336, 21);
            this.codigoComboBox.TabIndex = 2;
            this.codigoComboBox.ValueMember = "Codigo";
            // 
            // tipoDatoAdicionalBindingSource
            // 
            this.tipoDatoAdicionalBindingSource.DataSource = typeof(OpenInvoicePeru.Entidades.TipoDatoAdicional);
            // 
            // contenidoTextBox
            // 
            this.contenidoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datoAdicionalBindingSource, "Contenido", true));
            this.contenidoTextBox.Location = new System.Drawing.Point(87, 43);
            this.contenidoTextBox.Name = "contenidoTextBox";
            this.contenidoTextBox.Size = new System.Drawing.Size(336, 23);
            this.contenidoTextBox.TabIndex = 4;
            // 
            // barraBotones
            // 
            this.barraBotones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.barraBotones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOk,
            this.toolCancel});
            this.barraBotones.Location = new System.Drawing.Point(0, 0);
            this.barraBotones.Name = "barraBotones";
            this.barraBotones.Size = new System.Drawing.Size(448, 25);
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
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.contenidoTextBox);
            this.kryptonPanel1.Controls.Add(this.codigoComboBox);
            this.kryptonPanel1.Controls.Add(contenidoLabel);
            this.kryptonPanel1.Controls.Add(codigoLabel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 25);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(448, 78);
            this.kryptonPanel1.TabIndex = 6;
            // 
            // FrmDatosAdicionales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 103);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.barraBotones);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDatosAdicionales";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datos Adicionales";
            ((System.ComponentModel.ISupportInitialize)(this.datoAdicionalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codigoComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDatoAdicionalBindingSource)).EndInit();
            this.barraBotones.ResumeLayout(false);
            this.barraBotones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource datoAdicionalBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox codigoComboBox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox contenidoTextBox;
        private System.Windows.Forms.ToolStrip barraBotones;
        private System.Windows.Forms.ToolStripButton toolOk;
        private System.Windows.Forms.ToolStripButton toolCancel;
        private System.Windows.Forms.BindingSource tipoDatoAdicionalBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
    }
}
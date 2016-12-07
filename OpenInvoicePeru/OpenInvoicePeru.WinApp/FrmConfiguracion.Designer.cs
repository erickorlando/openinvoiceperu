using OpenInvoicePeru.Firmado.Models;

namespace OpenInvoicePeru.WinApp
{
    partial class FrmConfiguracion
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
            ComponentFactory.Krypton.Toolkit.KryptonLabel urbanizacionLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfiguracion));
            this.emisorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grpEmisor = new System.Windows.Forms.GroupBox();
            this.urbanizacionTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtUbigeoEm = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtDistritoEm = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtDptoEm = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtProvEm = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtDirEm = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtNombreComEm = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtNombreLegalEm = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtNroDocEm = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            urbanizacionLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.emisorBindingSource)).BeginInit();
            this.grpEmisor.SuspendLayout();
            this.SuspendLayout();
            // 
            // emisorBindingSource
            // 
            this.emisorBindingSource.DataSource = typeof(Contribuyente);
            // 
            // grpEmisor
            // 
            this.grpEmisor.Controls.Add(this.urbanizacionTextBox);
            this.grpEmisor.Controls.Add(urbanizacionLabel);
            this.grpEmisor.Controls.Add(this.label9);
            this.grpEmisor.Controls.Add(this.label8);
            this.grpEmisor.Controls.Add(this.label7);
            this.grpEmisor.Controls.Add(this.label6);
            this.grpEmisor.Controls.Add(this.label5);
            this.grpEmisor.Controls.Add(this.label3);
            this.grpEmisor.Controls.Add(this.label2);
            this.grpEmisor.Controls.Add(this.txtUbigeoEm);
            this.grpEmisor.Controls.Add(this.txtDistritoEm);
            this.grpEmisor.Controls.Add(this.txtDptoEm);
            this.grpEmisor.Controls.Add(this.txtProvEm);
            this.grpEmisor.Controls.Add(this.txtDirEm);
            this.grpEmisor.Controls.Add(this.txtNombreComEm);
            this.grpEmisor.Controls.Add(this.txtNombreLegalEm);
            this.grpEmisor.Controls.Add(this.txtNroDocEm);
            this.grpEmisor.Controls.Add(this.label4);
            this.grpEmisor.Location = new System.Drawing.Point(12, 12);
            this.grpEmisor.Name = "grpEmisor";
            this.grpEmisor.Size = new System.Drawing.Size(492, 176);
            this.grpEmisor.TabIndex = 10;
            this.grpEmisor.TabStop = false;
            this.grpEmisor.Text = "Datos del Emisor";
            // 
            // urbanizacionTextBox
            // 
            this.urbanizacionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.emisorBindingSource, "Urbanizacion", true));
            this.urbanizacionTextBox.Location = new System.Drawing.Point(384, 37);
            this.urbanizacionTextBox.Name = "urbanizacionTextBox";
            this.urbanizacionTextBox.Size = new System.Drawing.Size(100, 20);
            this.urbanizacionTextBox.TabIndex = 11;
            // 
            // urbanizacionLabel
            // 
            urbanizacionLabel.AutoSize = true;
            urbanizacionLabel.Location = new System.Drawing.Point(303, 40);
            urbanizacionLabel.Name = "urbanizacionLabel";
            urbanizacionLabel.Size = new System.Drawing.Size(72, 13);
            urbanizacionLabel.TabIndex = 10;
            urbanizacionLabel.Text = "Urbanización:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Ubigeo:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(305, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Distrito:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(305, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Departamento:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(305, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Provincia:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Dirección:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre Legal:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nro. Doc:";
            // 
            // txtUbigeoEm
            // 
            this.txtUbigeoEm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.emisorBindingSource, "Ubigeo", true));
            this.txtUbigeoEm.Location = new System.Drawing.Point(103, 115);
            this.txtUbigeoEm.Name = "txtUbigeoEm";
            this.txtUbigeoEm.Size = new System.Drawing.Size(103, 20);
            this.txtUbigeoEm.TabIndex = 7;
            // 
            // txtDistritoEm
            // 
            this.txtDistritoEm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.emisorBindingSource, "Distrito", true));
            this.txtDistritoEm.Location = new System.Drawing.Point(384, 115);
            this.txtDistritoEm.Name = "txtDistritoEm";
            this.txtDistritoEm.Size = new System.Drawing.Size(100, 20);
            this.txtDistritoEm.TabIndex = 17;
            // 
            // txtDptoEm
            // 
            this.txtDptoEm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.emisorBindingSource, "Departamento", true));
            this.txtDptoEm.Location = new System.Drawing.Point(384, 63);
            this.txtDptoEm.Name = "txtDptoEm";
            this.txtDptoEm.Size = new System.Drawing.Size(100, 20);
            this.txtDptoEm.TabIndex = 15;
            // 
            // txtProvEm
            // 
            this.txtProvEm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.emisorBindingSource, "Provincia", true));
            this.txtProvEm.Location = new System.Drawing.Point(384, 88);
            this.txtProvEm.Name = "txtProvEm";
            this.txtProvEm.Size = new System.Drawing.Size(100, 20);
            this.txtProvEm.TabIndex = 13;
            // 
            // txtDirEm
            // 
            this.txtDirEm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.emisorBindingSource, "Direccion", true));
            this.txtDirEm.Location = new System.Drawing.Point(103, 143);
            this.txtDirEm.Name = "txtDirEm";
            this.txtDirEm.Size = new System.Drawing.Size(194, 20);
            this.txtDirEm.TabIndex = 9;
            // 
            // txtNombreComEm
            // 
            this.txtNombreComEm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.emisorBindingSource, "NombreComercial", true));
            this.txtNombreComEm.Location = new System.Drawing.Point(103, 88);
            this.txtNombreComEm.Name = "txtNombreComEm";
            this.txtNombreComEm.Size = new System.Drawing.Size(194, 20);
            this.txtNombreComEm.TabIndex = 5;
            // 
            // txtNombreLegalEm
            // 
            this.txtNombreLegalEm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.emisorBindingSource, "NombreLegal", true));
            this.txtNombreLegalEm.Location = new System.Drawing.Point(103, 63);
            this.txtNombreLegalEm.Name = "txtNombreLegalEm";
            this.txtNombreLegalEm.Size = new System.Drawing.Size(194, 20);
            this.txtNombreLegalEm.TabIndex = 3;
            // 
            // txtNroDocEm
            // 
            this.txtNroDocEm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.emisorBindingSource, "NroDocumento", true));
            this.txtNroDocEm.Location = new System.Drawing.Point(103, 33);
            this.txtNroDocEm.Name = "txtNroDocEm";
            this.txtNroDocEm.Size = new System.Drawing.Size(103, 20);
            this.txtNroDocEm.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nombre Comercial:";
            // 
            // FrmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 399);
            this.Controls.Add(this.grpEmisor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfiguracion";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración";
            ((System.ComponentModel.ISupportInitialize)(this.emisorBindingSource)).EndInit();
            this.grpEmisor.ResumeLayout(false);
            this.grpEmisor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource emisorBindingSource;
        private System.Windows.Forms.GroupBox grpEmisor;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox urbanizacionTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label9;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label8;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label7;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label6;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUbigeoEm;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtDistritoEm;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtDptoEm;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtProvEm;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtDirEm;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNombreComEm;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNombreLegalEm;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNroDocEm;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label4;
    }
}
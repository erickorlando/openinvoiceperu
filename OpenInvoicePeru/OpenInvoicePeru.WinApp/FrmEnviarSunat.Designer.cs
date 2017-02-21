using System.Windows.Forms;

namespace OpenInvoicePeru.WinApp
{
    partial class FrmEnviarSunat
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
            this.btnBrowse = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtResult = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtSource = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnGen = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtNroRuc = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtUsuarioSol = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtClaveSol = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.groupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.rbResumen = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbRetenciones = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbDocumentos = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.label5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtRutaCertificado = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtPassCertificado = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnBrowseCert = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cboTipoDoc = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtSerieCorrelativo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnGetStatus = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnGenerar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboUrlServicio = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.direccionSunatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chkVoz = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1.Panel)).BeginInit();
            this.groupBox1.Panel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUrlServicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.direccionSunatBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(355, 349);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(103, 24);
            this.btnBrowse.TabIndex = 19;
            this.btnBrowse.Values.Text = "Exami&nar";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtResult
            // 
            this.txtResult.BackColor = System.Drawing.SystemColors.Info;
            this.txtResult.Location = new System.Drawing.Point(3, 441);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(341, 143);
            this.txtResult.TabIndex = 22;
            // 
            // txtSource
            // 
            this.txtSource.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSource.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtSource.Location = new System.Drawing.Point(3, 351);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(341, 23);
            this.txtSource.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 20);
            this.label1.TabIndex = 16;
            this.label1.Values.Text = "Seleccione el Documento XML:";
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(348, 441);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(115, 32);
            this.btnGen.TabIndex = 23;
            this.btnGen.Values.Text = "&Enviar";
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 2;
            this.label2.Values.Text = "Numero de RUC:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 4;
            this.label3.Values.Text = "Usuario SOL:";
            // 
            // txtNroRuc
            // 
            this.txtNroRuc.Location = new System.Drawing.Point(3, 67);
            this.txtNroRuc.MaxLength = 11;
            this.txtNroRuc.Name = "txtNroRuc";
            this.txtNroRuc.Size = new System.Drawing.Size(153, 23);
            this.txtNroRuc.TabIndex = 3;
            // 
            // txtUsuarioSol
            // 
            this.txtUsuarioSol.AutoCompleteCustomSource.AddRange(new string[] {
            "MODDATOS"});
            this.txtUsuarioSol.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtUsuarioSol.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtUsuarioSol.Location = new System.Drawing.Point(3, 125);
            this.txtUsuarioSol.Name = "txtUsuarioSol";
            this.txtUsuarioSol.Size = new System.Drawing.Size(153, 23);
            this.txtUsuarioSol.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 6;
            this.label4.Values.Text = "Clave SOL:";
            // 
            // txtClaveSol
            // 
            this.txtClaveSol.Location = new System.Drawing.Point(3, 176);
            this.txtClaveSol.Name = "txtClaveSol";
            this.txtClaveSol.PasswordChar = '*';
            this.txtClaveSol.Size = new System.Drawing.Size(153, 23);
            this.txtClaveSol.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(173, 44);
            this.groupBox1.Name = "groupBox1";
            // 
            // groupBox1.Panel
            // 
            this.groupBox1.Panel.Controls.Add(this.rbResumen);
            this.groupBox1.Panel.Controls.Add(this.rbRetenciones);
            this.groupBox1.Panel.Controls.Add(this.rbDocumentos);
            this.groupBox1.Size = new System.Drawing.Size(288, 111);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.Values.Heading = "Grupo de Documentos";
            // 
            // rbResumen
            // 
            this.rbResumen.Location = new System.Drawing.Point(28, 66);
            this.rbResumen.Name = "rbResumen";
            this.rbResumen.Size = new System.Drawing.Size(206, 20);
            this.rbResumen.TabIndex = 2;
            this.rbResumen.Values.Text = "Resumen y Comunicacion de baja";
            // 
            // rbRetenciones
            // 
            this.rbRetenciones.Location = new System.Drawing.Point(28, 36);
            this.rbRetenciones.Name = "rbRetenciones";
            this.rbRetenciones.Size = new System.Drawing.Size(195, 20);
            this.rbRetenciones.TabIndex = 1;
            this.rbRetenciones.Values.Text = "Retenciones, Percepciones y GR";
            // 
            // rbDocumentos
            // 
            this.rbDocumentos.Checked = true;
            this.rbDocumentos.Location = new System.Drawing.Point(28, 5);
            this.rbDocumentos.Name = "rbDocumentos";
            this.rbDocumentos.Size = new System.Drawing.Size(150, 20);
            this.rbDocumentos.TabIndex = 0;
            this.rbDocumentos.Values.Text = "Factura, Boleta, NC, ND";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 20);
            this.label5.TabIndex = 11;
            this.label5.Values.Text = "Seleccione el Certificado:";
            // 
            // txtRutaCertificado
            // 
            this.txtRutaCertificado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtRutaCertificado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtRutaCertificado.Location = new System.Drawing.Point(3, 239);
            this.txtRutaCertificado.Name = "txtRutaCertificado";
            this.txtRutaCertificado.Size = new System.Drawing.Size(341, 23);
            this.txtRutaCertificado.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 275);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 20);
            this.label6.TabIndex = 14;
            this.label6.Values.Text = "Contraseña del Certificado:";
            // 
            // txtPassCertificado
            // 
            this.txtPassCertificado.Location = new System.Drawing.Point(3, 298);
            this.txtPassCertificado.Name = "txtPassCertificado";
            this.txtPassCertificado.PasswordChar = '*';
            this.txtPassCertificado.Size = new System.Drawing.Size(341, 23);
            this.txtPassCertificado.TabIndex = 15;
            // 
            // btnBrowseCert
            // 
            this.btnBrowseCert.Location = new System.Drawing.Point(355, 234);
            this.btnBrowseCert.Name = "btnBrowseCert";
            this.btnBrowseCert.Size = new System.Drawing.Size(103, 32);
            this.btnBrowseCert.TabIndex = 13;
            this.btnBrowseCert.Values.Text = "E&xaminar";
            this.btnBrowseCert.Click += new System.EventHandler(this.btnBrowseCert_Click);
            // 
            // cboTipoDoc
            // 
            this.cboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDoc.DropDownWidth = 201;
            this.cboTipoDoc.Items.AddRange(new object[] {
            "Factura",
            "Boleta",
            "Nota de Crédito",
            "Nota de Débito",
            "Retención",
            "Percepción",
            "Resumen Diario",
            "Comunicacion de Baja",
            "Guía de Remisión"});
            this.cboTipoDoc.Location = new System.Drawing.Point(173, 177);
            this.cboTipoDoc.Name = "cboTipoDoc";
            this.cboTipoDoc.Size = new System.Drawing.Size(201, 21);
            this.cboTipoDoc.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(169, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 20);
            this.label7.TabIndex = 9;
            this.label7.Values.Text = "Tipo de Documento:";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(3, 389);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(192, 20);
            this.label8.TabIndex = 20;
            this.label8.Values.Text = "Serie-Correlativo del Documento:";
            // 
            // txtSerieCorrelativo
            // 
            this.txtSerieCorrelativo.Location = new System.Drawing.Point(3, 412);
            this.txtSerieCorrelativo.Name = "txtSerieCorrelativo";
            this.txtSerieCorrelativo.Size = new System.Drawing.Size(341, 23);
            this.txtSerieCorrelativo.TabIndex = 21;
            // 
            // btnGetStatus
            // 
            this.btnGetStatus.AutoSize = true;
            this.btnGetStatus.Location = new System.Drawing.Point(348, 479);
            this.btnGetStatus.Name = "btnGetStatus";
            this.btnGetStatus.Size = new System.Drawing.Size(115, 64);
            this.btnGetStatus.TabIndex = 24;
            this.btnGetStatus.Values.Text = "Consultar N° Ticket";
            this.btnGetStatus.Click += new System.EventHandler(this.btnGetStatus_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.AutoSize = true;
            this.btnGenerar.Location = new System.Drawing.Point(355, 318);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(103, 27);
            this.btnGenerar.TabIndex = 18;
            this.btnGenerar.Values.Text = "&Generar XML";
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(3, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 20);
            this.label9.TabIndex = 0;
            this.label9.Values.Text = "Url del Servicio:";
            // 
            // cboUrlServicio
            // 
            this.cboUrlServicio.DataSource = this.direccionSunatBindingSource;
            this.cboUrlServicio.DisplayMember = "Codigo";
            this.cboUrlServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUrlServicio.DropDownWidth = 433;
            this.cboUrlServicio.Location = new System.Drawing.Point(3, 19);
            this.cboUrlServicio.Name = "cboUrlServicio";
            this.cboUrlServicio.Size = new System.Drawing.Size(433, 21);
            this.cboUrlServicio.TabIndex = 1;
            this.cboUrlServicio.ValueMember = "Descripcion";
            // 
            // direccionSunatBindingSource
            // 
            this.direccionSunatBindingSource.DataSource = typeof(OpenInvoicePeru.Entidades.DireccionSunat);
            // 
            // chkVoz
            // 
            this.chkVoz.Checked = true;
            this.chkVoz.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVoz.Location = new System.Drawing.Point(347, 549);
            this.chkVoz.Name = "chkVoz";
            this.chkVoz.Size = new System.Drawing.Size(122, 20);
            this.chkVoz.TabIndex = 25;
            this.chkVoz.Values.Text = "Hablar en voz alta";
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.txtResult);
            this.kryptonPanel1.Controls.Add(this.chkVoz);
            this.kryptonPanel1.Controls.Add(this.label1);
            this.kryptonPanel1.Controls.Add(this.btnGenerar);
            this.kryptonPanel1.Controls.Add(this.label2);
            this.kryptonPanel1.Controls.Add(this.cboUrlServicio);
            this.kryptonPanel1.Controls.Add(this.label9);
            this.kryptonPanel1.Controls.Add(this.cboTipoDoc);
            this.kryptonPanel1.Controls.Add(this.label8);
            this.kryptonPanel1.Controls.Add(this.groupBox1);
            this.kryptonPanel1.Controls.Add(this.label5);
            this.kryptonPanel1.Controls.Add(this.btnGetStatus);
            this.kryptonPanel1.Controls.Add(this.label3);
            this.kryptonPanel1.Controls.Add(this.btnGen);
            this.kryptonPanel1.Controls.Add(this.label6);
            this.kryptonPanel1.Controls.Add(this.btnBrowseCert);
            this.kryptonPanel1.Controls.Add(this.label4);
            this.kryptonPanel1.Controls.Add(this.btnBrowse);
            this.kryptonPanel1.Controls.Add(this.label7);
            this.kryptonPanel1.Controls.Add(this.txtSource);
            this.kryptonPanel1.Controls.Add(this.txtClaveSol);
            this.kryptonPanel1.Controls.Add(this.txtSerieCorrelativo);
            this.kryptonPanel1.Controls.Add(this.txtUsuarioSol);
            this.kryptonPanel1.Controls.Add(this.txtRutaCertificado);
            this.kryptonPanel1.Controls.Add(this.txtNroRuc);
            this.kryptonPanel1.Controls.Add(this.txtPassCertificado);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(476, 622);
            this.kryptonPanel1.TabIndex = 26;
            // 
            // FrmEnviarSunat
            // 
            this.AcceptButton = this.btnGen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 622);
            this.Controls.Add(this.kryptonPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FrmEnviarSunat";
            this.ShowInTaskbar = true;
            this.Text = "OpenInvoicePeru - Prueba de Envio a SUNAT";
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1.Panel)).EndInit();
            this.groupBox1.Panel.ResumeLayout(false);
            this.groupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUrlServicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.direccionSunatBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton btnBrowse;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtResult;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSource;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnGen;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNroRuc;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUsuarioSol;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtClaveSol;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox groupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbRetenciones;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbDocumentos;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtRutaCertificado;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label6;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPassCertificado;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnBrowseCert;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboTipoDoc;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label7;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label8;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSerieCorrelativo;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbResumen;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnGetStatus;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnGenerar;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label9;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboUrlServicio;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkVoz;
        private System.Windows.Forms.BindingSource direccionSunatBindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
    }
}
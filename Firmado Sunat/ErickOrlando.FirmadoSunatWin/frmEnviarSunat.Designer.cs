namespace ErickOrlando.FirmadoSunatWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEnviarSunat));
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGen = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNroRuc = new System.Windows.Forms.TextBox();
            this.txtUsuarioSol = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtClaveSol = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbResumen = new System.Windows.Forms.RadioButton();
            this.rbRetenciones = new System.Windows.Forms.RadioButton();
            this.rbDocumentos = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRutaCertificado = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPassCertificado = new System.Windows.Forms.TextBox();
            this.btnBrowseCert = new System.Windows.Forms.Button();
            this.cboTipoDoc = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSerieCorrelativo = new System.Windows.Forms.TextBox();
            this.btnGetStatus = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(340, 320);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(103, 32);
            this.btnBrowse.TabIndex = 16;
            this.btnBrowse.Text = "Exami&nar";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.BackColor = System.Drawing.SystemColors.Info;
            this.txtResult.Location = new System.Drawing.Point(10, 437);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(319, 143);
            this.txtResult.TabIndex = 20;
            // 
            // txtSource
            // 
            this.txtSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSource.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSource.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtSource.Location = new System.Drawing.Point(10, 324);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(319, 21);
            this.txtSource.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Seleccione el Documento XML:";
            // 
            // btnGen
            // 
            this.btnGen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGen.Location = new System.Drawing.Point(340, 437);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(103, 32);
            this.btnGen.TabIndex = 19;
            this.btnGen.Text = "&Enviar";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Numero de RUC:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Usuario SOL:";
            // 
            // txtNroRuc
            // 
            this.txtNroRuc.Location = new System.Drawing.Point(10, 40);
            this.txtNroRuc.MaxLength = 11;
            this.txtNroRuc.Name = "txtNroRuc";
            this.txtNroRuc.Size = new System.Drawing.Size(153, 21);
            this.txtNroRuc.TabIndex = 1;
            // 
            // txtUsuarioSol
            // 
            this.txtUsuarioSol.AutoCompleteCustomSource.AddRange(new string[] {
            "MODDATOS"});
            this.txtUsuarioSol.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtUsuarioSol.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtUsuarioSol.Location = new System.Drawing.Point(10, 98);
            this.txtUsuarioSol.Name = "txtUsuarioSol";
            this.txtUsuarioSol.Size = new System.Drawing.Size(153, 21);
            this.txtUsuarioSol.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Clave SOL:";
            // 
            // txtClaveSol
            // 
            this.txtClaveSol.Location = new System.Drawing.Point(10, 149);
            this.txtClaveSol.Name = "txtClaveSol";
            this.txtClaveSol.PasswordChar = '*';
            this.txtClaveSol.Size = new System.Drawing.Size(153, 21);
            this.txtClaveSol.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbResumen);
            this.groupBox1.Controls.Add(this.rbRetenciones);
            this.groupBox1.Controls.Add(this.rbDocumentos);
            this.groupBox1.Location = new System.Drawing.Point(180, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 104);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grupo de Documentos";
            // 
            // rbResumen
            // 
            this.rbResumen.AutoSize = true;
            this.rbResumen.Location = new System.Drawing.Point(28, 74);
            this.rbResumen.Name = "rbResumen";
            this.rbResumen.Size = new System.Drawing.Size(197, 17);
            this.rbResumen.TabIndex = 1;
            this.rbResumen.Text = "Resumen y Comunicacion de baja";
            this.rbResumen.UseVisualStyleBackColor = true;
            // 
            // rbRetenciones
            // 
            this.rbRetenciones.AutoSize = true;
            this.rbRetenciones.Location = new System.Drawing.Point(28, 51);
            this.rbRetenciones.Name = "rbRetenciones";
            this.rbRetenciones.Size = new System.Drawing.Size(166, 17);
            this.rbRetenciones.TabIndex = 1;
            this.rbRetenciones.Text = "Retenciones y Percepciones";
            this.rbRetenciones.UseVisualStyleBackColor = true;
            // 
            // rbDocumentos
            // 
            this.rbDocumentos.AutoSize = true;
            this.rbDocumentos.Checked = true;
            this.rbDocumentos.Location = new System.Drawing.Point(28, 22);
            this.rbDocumentos.Name = "rbDocumentos";
            this.rbDocumentos.Size = new System.Drawing.Size(145, 17);
            this.rbDocumentos.TabIndex = 0;
            this.rbDocumentos.TabStop = true;
            this.rbDocumentos.Text = "Factura, Boleta, NC, ND";
            this.rbDocumentos.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Seleccione el Certificado:";
            // 
            // txtRutaCertificado
            // 
            this.txtRutaCertificado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRutaCertificado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtRutaCertificado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtRutaCertificado.Location = new System.Drawing.Point(10, 212);
            this.txtRutaCertificado.Name = "txtRutaCertificado";
            this.txtRutaCertificado.Size = new System.Drawing.Size(319, 21);
            this.txtRutaCertificado.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Contraseña del Certificado:";
            // 
            // txtPassCertificado
            // 
            this.txtPassCertificado.Location = new System.Drawing.Point(10, 271);
            this.txtPassCertificado.Name = "txtPassCertificado";
            this.txtPassCertificado.PasswordChar = '*';
            this.txtPassCertificado.Size = new System.Drawing.Size(319, 21);
            this.txtPassCertificado.TabIndex = 13;
            // 
            // btnBrowseCert
            // 
            this.btnBrowseCert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseCert.Location = new System.Drawing.Point(340, 207);
            this.btnBrowseCert.Name = "btnBrowseCert";
            this.btnBrowseCert.Size = new System.Drawing.Size(103, 32);
            this.btnBrowseCert.TabIndex = 11;
            this.btnBrowseCert.Text = "E&xaminar";
            this.btnBrowseCert.UseVisualStyleBackColor = true;
            this.btnBrowseCert.Click += new System.EventHandler(this.btnBrowseCert_Click);
            // 
            // cboTipoDoc
            // 
            this.cboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDoc.Items.AddRange(new object[] {
            "Factura",
            "Boleta",
            "Nota de Crédito",
            "Nota de Débito",
            "Retención",
            "Percepción",
            "Resumen Diario",
            "Comunicacion de Baja"});
            this.cboTipoDoc.Location = new System.Drawing.Point(180, 150);
            this.cboTipoDoc.Name = "cboTipoDoc";
            this.cboTipoDoc.Size = new System.Drawing.Size(201, 20);
            this.cboTipoDoc.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(176, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Tipo de Documento:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 362);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(177, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Serie-Correlativo del Documento:";
            // 
            // txtSerieCorrelativo
            // 
            this.txtSerieCorrelativo.Location = new System.Drawing.Point(10, 385);
            this.txtSerieCorrelativo.Name = "txtSerieCorrelativo";
            this.txtSerieCorrelativo.Size = new System.Drawing.Size(319, 21);
            this.txtSerieCorrelativo.TabIndex = 18;
            // 
            // btnGetStatus
            // 
            this.btnGetStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetStatus.Location = new System.Drawing.Point(340, 475);
            this.btnGetStatus.Name = "btnGetStatus";
            this.btnGetStatus.Size = new System.Drawing.Size(103, 53);
            this.btnGetStatus.TabIndex = 19;
            this.btnGetStatus.Text = "Consultar N° Ticket";
            this.btnGetStatus.UseVisualStyleBackColor = true;
            this.btnGetStatus.Click += new System.EventHandler(this.btnGetStatus_Click);
            // 
            // FrmEnviarSunat
            // 
            this.AcceptButton = this.btnGen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 593);
            this.Controls.Add(this.cboTipoDoc);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGetStatus);
            this.Controls.Add(this.btnGen);
            this.Controls.Add(this.btnBrowseCert);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtClaveSol);
            this.Controls.Add(this.txtUsuarioSol);
            this.Controls.Add(this.txtNroRuc);
            this.Controls.Add(this.txtPassCertificado);
            this.Controls.Add(this.txtRutaCertificado);
            this.Controls.Add(this.txtSerieCorrelativo);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmEnviarSunat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prueba de Envio a SUNAT";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNroRuc;
        private System.Windows.Forms.TextBox txtUsuarioSol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtClaveSol;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbRetenciones;
        private System.Windows.Forms.RadioButton rbDocumentos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRutaCertificado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPassCertificado;
        private System.Windows.Forms.Button btnBrowseCert;
        private System.Windows.Forms.ComboBox cboTipoDoc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSerieCorrelativo;
        private System.Windows.Forms.RadioButton rbResumen;
        private System.Windows.Forms.Button btnGetStatus;
    }
}
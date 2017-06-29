namespace OpenInvoicePeru.WinPart
{
    partial class PlantillaMant
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
            this.ribbon = new ComponentFactory.Krypton.Ribbon.KryptonRibbon();
            this.inicioTab = new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab();
            this.accionesGroup = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupLines1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.btnGuardar = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.btnCancelar = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.miscGroup = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupLines2 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.btnRefrescar = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.InDesignHelperMode = true;
            this.ribbon.Name = "ribbon";
            this.ribbon.QATUserChange = false;
            this.ribbon.RibbonAppButton.AppButtonVisible = false;
            this.ribbon.RibbonTabs.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab[] {
            this.inicioTab});
            this.ribbon.SelectedTab = this.inicioTab;
            this.ribbon.Size = new System.Drawing.Size(618, 135);
            this.ribbon.TabIndex = 1;
            // 
            // inicioTab
            // 
            this.inicioTab.Groups.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup[] {
            this.accionesGroup,
            this.miscGroup});
            this.inicioTab.Text = "Inicio";
            // 
            // accionesGroup
            // 
            this.accionesGroup.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupLines1});
            this.accionesGroup.TextLine1 = "Acciones";
            // 
            // kryptonRibbonGroupLines1
            // 
            this.kryptonRibbonGroupLines1.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.btnGuardar,
            this.btnCancelar});
            // 
            // btnGuardar
            // 
            this.btnGuardar.ImageLarge = global::OpenInvoicePeru.WinPart.Properties.Resources.guardar;
            this.btnGuardar.ImageSmall = global::OpenInvoicePeru.WinPart.Properties.Resources.guardar;
            this.btnGuardar.TextLine1 = "Guardar";
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageLarge = global::OpenInvoicePeru.WinPart.Properties.Resources.cancelar;
            this.btnCancelar.ImageSmall = global::OpenInvoicePeru.WinPart.Properties.Resources.cancelar;
            this.btnCancelar.TextLine1 = "Cancelar";
            // 
            // miscGroup
            // 
            this.miscGroup.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupLines2});
            this.miscGroup.TextLine1 = "Miscelánea";
            // 
            // kryptonRibbonGroupLines2
            // 
            this.kryptonRibbonGroupLines2.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.btnRefrescar});
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.ImageLarge = global::OpenInvoicePeru.WinPart.Properties.Resources.refrescar;
            this.btnRefrescar.ImageSmall = global::OpenInvoicePeru.WinPart.Properties.Resources.refrescar;
            this.btnRefrescar.TextLine1 = "Refrescar";
            // 
            // PlantillaMant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 489);
            this.Controls.Add(this.ribbon);
            this.Name = "PlantillaMant";
            this.Text = "Plantilla Mantenimiento";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Ribbon.KryptonRibbon ribbon;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonTab inicioTab;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup accionesGroup;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupLines1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnGuardar;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnCancelar;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup miscGroup;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupLines2;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnRefrescar;
    }
}
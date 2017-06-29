namespace OpenInvoicePeru.WinPart
{
    partial class PlantillaGestor
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
            this.kryptonRibbonGroupButton1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupButton2 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupButton4 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.miscGroup = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupLines2 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.kryptonRibbonGroupButton3 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
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
            this.ribbon.TabIndex = 0;
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
            this.kryptonRibbonGroupButton1,
            this.kryptonRibbonGroupButton2,
            this.kryptonRibbonGroupButton4});
            // 
            // kryptonRibbonGroupButton1
            // 
            this.kryptonRibbonGroupButton1.ImageLarge = global::OpenInvoicePeru.WinPart.Properties.Resources.nuevo;
            this.kryptonRibbonGroupButton1.ImageSmall = global::OpenInvoicePeru.WinPart.Properties.Resources.nuevo;
            this.kryptonRibbonGroupButton1.TextLine1 = "Nuevo";
            // 
            // kryptonRibbonGroupButton2
            // 
            this.kryptonRibbonGroupButton2.ImageLarge = global::OpenInvoicePeru.WinPart.Properties.Resources.eliminar;
            this.kryptonRibbonGroupButton2.ImageSmall = global::OpenInvoicePeru.WinPart.Properties.Resources.eliminar;
            this.kryptonRibbonGroupButton2.TextLine1 = "Eliminar";
            // 
            // kryptonRibbonGroupButton4
            // 
            this.kryptonRibbonGroupButton4.ImageLarge = global::OpenInvoicePeru.WinPart.Properties.Resources.Editar;
            this.kryptonRibbonGroupButton4.ImageSmall = global::OpenInvoicePeru.WinPart.Properties.Resources.Editar;
            this.kryptonRibbonGroupButton4.TextLine1 = "Ver/Editar";
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
            this.kryptonRibbonGroupButton3});
            // 
            // kryptonRibbonGroupButton3
            // 
            this.kryptonRibbonGroupButton3.ImageLarge = global::OpenInvoicePeru.WinPart.Properties.Resources.refrescar;
            this.kryptonRibbonGroupButton3.ImageSmall = global::OpenInvoicePeru.WinPart.Properties.Resources.refrescar;
            this.kryptonRibbonGroupButton3.TextLine1 = "Refrescar";
            // 
            // PlantillaGestor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 489);
            this.Controls.Add(this.ribbon);
            this.Name = "PlantillaGestor";
            this.Text = "PlantillaGestor";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Ribbon.KryptonRibbon ribbon;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonTab inicioTab;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup accionesGroup;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupLines1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton2;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton4;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup miscGroup;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupLines2;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton3;
    }
}
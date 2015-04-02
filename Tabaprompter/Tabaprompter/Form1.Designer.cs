namespace Tabaprompter
{
    partial class Form1
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
            this.topBottemDivider = new System.Windows.Forms.SplitContainer();
            this.tabVideoDivider = new System.Windows.Forms.SplitContainer();
            this.selectorsControlsDivider = new System.Windows.Forms.SplitContainer();
            this.controlsLogDivider = new System.Windows.Forms.SplitContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLibraryAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.topBottemDivider)).BeginInit();
            this.topBottemDivider.Panel1.SuspendLayout();
            this.topBottemDivider.Panel2.SuspendLayout();
            this.topBottemDivider.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabVideoDivider)).BeginInit();
            this.tabVideoDivider.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectorsControlsDivider)).BeginInit();
            this.selectorsControlsDivider.Panel2.SuspendLayout();
            this.selectorsControlsDivider.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlsLogDivider)).BeginInit();
            this.controlsLogDivider.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // topBottemDivider
            // 
            this.topBottemDivider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topBottemDivider.Location = new System.Drawing.Point(0, 28);
            this.topBottemDivider.Name = "topBottemDivider";
            this.topBottemDivider.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // topBottemDivider.Panel1
            // 
            this.topBottemDivider.Panel1.Controls.Add(this.tabVideoDivider);
            // 
            // topBottemDivider.Panel2
            // 
            this.topBottemDivider.Panel2.Controls.Add(this.selectorsControlsDivider);
            this.topBottemDivider.Size = new System.Drawing.Size(1037, 300);
            this.topBottemDivider.SplitterDistance = 198;
            this.topBottemDivider.TabIndex = 0;
            // 
            // tabVideoDivider
            // 
            this.tabVideoDivider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabVideoDivider.Location = new System.Drawing.Point(0, 0);
            this.tabVideoDivider.Name = "tabVideoDivider";
            this.tabVideoDivider.Size = new System.Drawing.Size(1037, 198);
            this.tabVideoDivider.SplitterDistance = 467;
            this.tabVideoDivider.TabIndex = 0;
            // 
            // selectorsControlsDivider
            // 
            this.selectorsControlsDivider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectorsControlsDivider.Location = new System.Drawing.Point(0, 0);
            this.selectorsControlsDivider.Name = "selectorsControlsDivider";
            // 
            // selectorsControlsDivider.Panel2
            // 
            this.selectorsControlsDivider.Panel2.Controls.Add(this.controlsLogDivider);
            this.selectorsControlsDivider.Size = new System.Drawing.Size(1037, 98);
            this.selectorsControlsDivider.SplitterDistance = 345;
            this.selectorsControlsDivider.TabIndex = 0;
            // 
            // controlsLogDivider
            // 
            this.controlsLogDivider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlsLogDivider.Location = new System.Drawing.Point(0, 0);
            this.controlsLogDivider.Name = "controlsLogDivider";
            this.controlsLogDivider.Size = new System.Drawing.Size(688, 98);
            this.controlsLogDivider.SplitterDistance = 229;
            this.controlsLogDivider.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1037, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newLibraryToolStripMenuItem,
            this.openLibraryToolStripMenuItem,
            this.saveLibraryToolStripMenuItem,
            this.saveLibraryAsToolStripMenuItem,
            this.importTabToolStripMenuItem,
            this.exportTabToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openLibraryToolStripMenuItem
            // 
            this.openLibraryToolStripMenuItem.Name = "openLibraryToolStripMenuItem";
            this.openLibraryToolStripMenuItem.Size = new System.Drawing.Size(178, 24);
            this.openLibraryToolStripMenuItem.Text = "Open Library";
            // 
            // saveLibraryToolStripMenuItem
            // 
            this.saveLibraryToolStripMenuItem.Name = "saveLibraryToolStripMenuItem";
            this.saveLibraryToolStripMenuItem.Size = new System.Drawing.Size(178, 24);
            this.saveLibraryToolStripMenuItem.Text = "Save Library";
            // 
            // saveLibraryAsToolStripMenuItem
            // 
            this.saveLibraryAsToolStripMenuItem.Name = "saveLibraryAsToolStripMenuItem";
            this.saveLibraryAsToolStripMenuItem.Size = new System.Drawing.Size(178, 24);
            this.saveLibraryAsToolStripMenuItem.Text = "Save Library As";
            // 
            // newLibraryToolStripMenuItem
            // 
            this.newLibraryToolStripMenuItem.Name = "newLibraryToolStripMenuItem";
            this.newLibraryToolStripMenuItem.Size = new System.Drawing.Size(178, 24);
            this.newLibraryToolStripMenuItem.Text = "New Library";
            // 
            // importTabToolStripMenuItem
            // 
            this.importTabToolStripMenuItem.Name = "importTabToolStripMenuItem";
            this.importTabToolStripMenuItem.Size = new System.Drawing.Size(178, 24);
            this.importTabToolStripMenuItem.Text = "Import Tab";
            // 
            // exportTabToolStripMenuItem
            // 
            this.exportTabToolStripMenuItem.Name = "exportTabToolStripMenuItem";
            this.exportTabToolStripMenuItem.Size = new System.Drawing.Size(178, 24);
            this.exportTabToolStripMenuItem.Text = "Export Tab";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 328);
            this.Controls.Add(this.topBottemDivider);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.topBottemDivider.Panel1.ResumeLayout(false);
            this.topBottemDivider.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.topBottemDivider)).EndInit();
            this.topBottemDivider.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabVideoDivider)).EndInit();
            this.tabVideoDivider.ResumeLayout(false);
            this.selectorsControlsDivider.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.selectorsControlsDivider)).EndInit();
            this.selectorsControlsDivider.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.controlsLogDivider)).EndInit();
            this.controlsLogDivider.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer topBottemDivider;
        private System.Windows.Forms.SplitContainer tabVideoDivider;
        private System.Windows.Forms.SplitContainer selectorsControlsDivider;
        private System.Windows.Forms.SplitContainer controlsLogDivider;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newLibraryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLibraryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLibraryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLibraryAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportTabToolStripMenuItem;
    }
}


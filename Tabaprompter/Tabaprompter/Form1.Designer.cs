﻿namespace Tabaprompter
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
            this.components = new System.ComponentModel.Container();
            this.topBottemDivider = new System.Windows.Forms.SplitContainer();
            this.tabVideoDivider = new System.Windows.Forms.SplitContainer();
            this.browserAddressDivider = new System.Windows.Forms.SplitContainer();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.videoAddressBarPanel = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.enableVideoCheckBox = new System.Windows.Forms.CheckBox();
            this.addressBarTextBox = new System.Windows.Forms.TextBox();
            this.addressGoButton = new System.Windows.Forms.Button();
            this.addressStopButton = new System.Windows.Forms.Button();
            this.selectorsControlsDivider = new System.Windows.Forms.SplitContainer();
            this.selectorFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.artistComboBox = new System.Windows.Forms.ComboBox();
            this.titleComboBox = new System.Windows.Forms.ComboBox();
            this.controlsLogDivider = new System.Windows.Forms.SplitContainer();
            this.controlFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.scrollPlayButton = new System.Windows.Forms.Button();
            this.scrollStopButton = new System.Windows.Forms.Button();
            this.scrollResetButton = new System.Windows.Forms.Button();
            this.markModeButton = new System.Windows.Forms.Button();
            this.scrollStartDelayTable = new System.Windows.Forms.TableLayoutPanel();
            this.startDelayLabel = new System.Windows.Forms.Label();
            this.startDelayTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.scrollDelayMultiplierNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLibraryAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scrollTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.topBottemDivider)).BeginInit();
            this.topBottemDivider.Panel1.SuspendLayout();
            this.topBottemDivider.Panel2.SuspendLayout();
            this.topBottemDivider.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabVideoDivider)).BeginInit();
            this.tabVideoDivider.Panel2.SuspendLayout();
            this.tabVideoDivider.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.browserAddressDivider)).BeginInit();
            this.browserAddressDivider.Panel1.SuspendLayout();
            this.browserAddressDivider.Panel2.SuspendLayout();
            this.browserAddressDivider.SuspendLayout();
            this.videoAddressBarPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectorsControlsDivider)).BeginInit();
            this.selectorsControlsDivider.Panel1.SuspendLayout();
            this.selectorsControlsDivider.Panel2.SuspendLayout();
            this.selectorsControlsDivider.SuspendLayout();
            this.selectorFlowPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlsLogDivider)).BeginInit();
            this.controlsLogDivider.Panel1.SuspendLayout();
            this.controlsLogDivider.SuspendLayout();
            this.controlFlowPanel.SuspendLayout();
            this.scrollStartDelayTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scrollDelayMultiplierNumericUpDown)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // topBottemDivider
            // 
            this.topBottemDivider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topBottemDivider.Location = new System.Drawing.Point(0, 24);
            this.topBottemDivider.Margin = new System.Windows.Forms.Padding(2);
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
            this.topBottemDivider.Size = new System.Drawing.Size(916, 320);
            this.topBottemDivider.SplitterDistance = 205;
            this.topBottemDivider.SplitterWidth = 3;
            this.topBottemDivider.TabIndex = 0;
            // 
            // tabVideoDivider
            // 
            this.tabVideoDivider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabVideoDivider.Location = new System.Drawing.Point(0, 0);
            this.tabVideoDivider.Margin = new System.Windows.Forms.Padding(2);
            this.tabVideoDivider.Name = "tabVideoDivider";
            // 
            // tabVideoDivider.Panel2
            // 
            this.tabVideoDivider.Panel2.Controls.Add(this.browserAddressDivider);
            this.tabVideoDivider.Size = new System.Drawing.Size(916, 205);
            this.tabVideoDivider.SplitterDistance = 379;
            this.tabVideoDivider.SplitterWidth = 3;
            this.tabVideoDivider.TabIndex = 0;
            // 
            // browserAddressDivider
            // 
            this.browserAddressDivider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserAddressDivider.Location = new System.Drawing.Point(0, 0);
            this.browserAddressDivider.Name = "browserAddressDivider";
            this.browserAddressDivider.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // browserAddressDivider.Panel1
            // 
            this.browserAddressDivider.Panel1.Controls.Add(this.webBrowser);
            // 
            // browserAddressDivider.Panel2
            // 
            this.browserAddressDivider.Panel2.Controls.Add(this.videoAddressBarPanel);
            this.browserAddressDivider.Size = new System.Drawing.Size(534, 205);
            this.browserAddressDivider.SplitterDistance = 147;
            this.browserAddressDivider.TabIndex = 0;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(534, 147);
            this.webBrowser.TabIndex = 0;
            // 
            // videoAddressBarPanel
            // 
            this.videoAddressBarPanel.Controls.Add(this.flowLayoutPanel1);
            this.videoAddressBarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoAddressBarPanel.Location = new System.Drawing.Point(0, 0);
            this.videoAddressBarPanel.Name = "videoAddressBarPanel";
            this.videoAddressBarPanel.Size = new System.Drawing.Size(534, 54);
            this.videoAddressBarPanel.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.enableVideoCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.addressBarTextBox);
            this.flowLayoutPanel1.Controls.Add(this.addressGoButton);
            this.flowLayoutPanel1.Controls.Add(this.addressStopButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(534, 54);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // enableVideoCheckBox
            // 
            this.enableVideoCheckBox.AutoSize = true;
            this.enableVideoCheckBox.Checked = true;
            this.enableVideoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableVideoCheckBox.Location = new System.Drawing.Point(2, 2);
            this.enableVideoCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.enableVideoCheckBox.Name = "enableVideoCheckBox";
            this.enableVideoCheckBox.Size = new System.Drawing.Size(53, 17);
            this.enableVideoCheckBox.TabIndex = 3;
            this.enableVideoCheckBox.Text = "Video";
            this.enableVideoCheckBox.UseVisualStyleBackColor = true;
            this.enableVideoCheckBox.CheckedChanged += new System.EventHandler(this.enableVideoCheckBox_CheckedChanged);
            // 
            // addressBarTextBox
            // 
            this.addressBarTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.addressBarTextBox.Location = new System.Drawing.Point(60, 3);
            this.addressBarTextBox.Name = "addressBarTextBox";
            this.addressBarTextBox.Size = new System.Drawing.Size(135, 20);
            this.addressBarTextBox.TabIndex = 0;
            // 
            // addressGoButton
            // 
            this.addressGoButton.Location = new System.Drawing.Point(201, 3);
            this.addressGoButton.Name = "addressGoButton";
            this.addressGoButton.Size = new System.Drawing.Size(48, 23);
            this.addressGoButton.TabIndex = 1;
            this.addressGoButton.Text = "Go";
            this.addressGoButton.UseVisualStyleBackColor = true;
            this.addressGoButton.Click += new System.EventHandler(this.addressGoButton_Click);
            // 
            // addressStopButton
            // 
            this.addressStopButton.Location = new System.Drawing.Point(255, 3);
            this.addressStopButton.Name = "addressStopButton";
            this.addressStopButton.Size = new System.Drawing.Size(49, 23);
            this.addressStopButton.TabIndex = 2;
            this.addressStopButton.Text = "Stop";
            this.addressStopButton.UseVisualStyleBackColor = true;
            this.addressStopButton.Click += new System.EventHandler(this.addressStopButton_Click);
            // 
            // selectorsControlsDivider
            // 
            this.selectorsControlsDivider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectorsControlsDivider.Location = new System.Drawing.Point(0, 0);
            this.selectorsControlsDivider.Margin = new System.Windows.Forms.Padding(2);
            this.selectorsControlsDivider.Name = "selectorsControlsDivider";
            // 
            // selectorsControlsDivider.Panel1
            // 
            this.selectorsControlsDivider.Panel1.Controls.Add(this.selectorFlowPanel);
            // 
            // selectorsControlsDivider.Panel2
            // 
            this.selectorsControlsDivider.Panel2.Controls.Add(this.controlsLogDivider);
            this.selectorsControlsDivider.Size = new System.Drawing.Size(916, 112);
            this.selectorsControlsDivider.SplitterDistance = 289;
            this.selectorsControlsDivider.SplitterWidth = 3;
            this.selectorsControlsDivider.TabIndex = 0;
            // 
            // selectorFlowPanel
            // 
            this.selectorFlowPanel.Controls.Add(this.artistComboBox);
            this.selectorFlowPanel.Controls.Add(this.titleComboBox);
            this.selectorFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectorFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.selectorFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.selectorFlowPanel.Name = "selectorFlowPanel";
            this.selectorFlowPanel.Size = new System.Drawing.Size(289, 112);
            this.selectorFlowPanel.TabIndex = 0;
            // 
            // artistComboBox
            // 
            this.artistComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.artistComboBox.Enabled = false;
            this.artistComboBox.FormattingEnabled = true;
            this.artistComboBox.Location = new System.Drawing.Point(3, 3);
            this.artistComboBox.Name = "artistComboBox";
            this.artistComboBox.Size = new System.Drawing.Size(278, 21);
            this.artistComboBox.TabIndex = 0;
            this.artistComboBox.SelectedIndexChanged += new System.EventHandler(this.artistComboBox_SelectedIndexChanged);
            // 
            // titleComboBox
            // 
            this.titleComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.titleComboBox.Enabled = false;
            this.titleComboBox.FormattingEnabled = true;
            this.titleComboBox.Location = new System.Drawing.Point(3, 30);
            this.titleComboBox.Name = "titleComboBox";
            this.titleComboBox.Size = new System.Drawing.Size(278, 21);
            this.titleComboBox.TabIndex = 1;
            this.titleComboBox.SelectedIndexChanged += new System.EventHandler(this.titleComboBox_SelectedIndexChanged);
            // 
            // controlsLogDivider
            // 
            this.controlsLogDivider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlsLogDivider.Location = new System.Drawing.Point(0, 0);
            this.controlsLogDivider.Margin = new System.Windows.Forms.Padding(2);
            this.controlsLogDivider.Name = "controlsLogDivider";
            // 
            // controlsLogDivider.Panel1
            // 
            this.controlsLogDivider.Panel1.Controls.Add(this.controlFlowPanel);
            this.controlsLogDivider.Size = new System.Drawing.Size(624, 112);
            this.controlsLogDivider.SplitterDistance = 346;
            this.controlsLogDivider.SplitterWidth = 3;
            this.controlsLogDivider.TabIndex = 0;
            // 
            // controlFlowPanel
            // 
            this.controlFlowPanel.Controls.Add(this.scrollPlayButton);
            this.controlFlowPanel.Controls.Add(this.scrollStopButton);
            this.controlFlowPanel.Controls.Add(this.scrollResetButton);
            this.controlFlowPanel.Controls.Add(this.markModeButton);
            this.controlFlowPanel.Controls.Add(this.scrollStartDelayTable);
            this.controlFlowPanel.Controls.Add(this.label1);
            this.controlFlowPanel.Controls.Add(this.label2);
            this.controlFlowPanel.Controls.Add(this.label3);
            this.controlFlowPanel.Controls.Add(this.scrollDelayMultiplierNumericUpDown);
            this.controlFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.controlFlowPanel.Name = "controlFlowPanel";
            this.controlFlowPanel.Size = new System.Drawing.Size(346, 112);
            this.controlFlowPanel.TabIndex = 0;
            // 
            // scrollPlayButton
            // 
            this.scrollPlayButton.Enabled = false;
            this.scrollPlayButton.Location = new System.Drawing.Point(3, 3);
            this.scrollPlayButton.Name = "scrollPlayButton";
            this.scrollPlayButton.Size = new System.Drawing.Size(75, 23);
            this.scrollPlayButton.TabIndex = 0;
            this.scrollPlayButton.Text = "Play";
            this.scrollPlayButton.UseVisualStyleBackColor = true;
            this.scrollPlayButton.Click += new System.EventHandler(this.scrollPlayButton_Click);
            // 
            // scrollStopButton
            // 
            this.scrollStopButton.Enabled = false;
            this.scrollStopButton.Location = new System.Drawing.Point(84, 3);
            this.scrollStopButton.Name = "scrollStopButton";
            this.scrollStopButton.Size = new System.Drawing.Size(75, 23);
            this.scrollStopButton.TabIndex = 1;
            this.scrollStopButton.Text = "Stop";
            this.scrollStopButton.UseVisualStyleBackColor = true;
            this.scrollStopButton.Click += new System.EventHandler(this.scrollStopButton_Click);
            // 
            // scrollResetButton
            // 
            this.scrollResetButton.Enabled = false;
            this.scrollResetButton.Location = new System.Drawing.Point(165, 3);
            this.scrollResetButton.Name = "scrollResetButton";
            this.scrollResetButton.Size = new System.Drawing.Size(75, 23);
            this.scrollResetButton.TabIndex = 2;
            this.scrollResetButton.Text = "Reset";
            this.scrollResetButton.UseVisualStyleBackColor = true;
            this.scrollResetButton.Click += new System.EventHandler(this.scrollResetButton_Click);
            // 
            // markModeButton
            // 
            this.markModeButton.Enabled = false;
            this.markModeButton.Location = new System.Drawing.Point(246, 3);
            this.markModeButton.Name = "markModeButton";
            this.markModeButton.Size = new System.Drawing.Size(75, 23);
            this.markModeButton.TabIndex = 3;
            this.markModeButton.Text = "Mark";
            this.markModeButton.UseVisualStyleBackColor = true;
            this.markModeButton.Click += new System.EventHandler(this.markModeButton_Click);
            // 
            // scrollStartDelayTable
            // 
            this.scrollStartDelayTable.ColumnCount = 2;
            this.scrollStartDelayTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.97619F));
            this.scrollStartDelayTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.02381F));
            this.scrollStartDelayTable.Controls.Add(this.startDelayLabel, 0, 0);
            this.scrollStartDelayTable.Controls.Add(this.startDelayTextBox, 1, 0);
            this.scrollStartDelayTable.Location = new System.Drawing.Point(2, 31);
            this.scrollStartDelayTable.Margin = new System.Windows.Forms.Padding(2);
            this.scrollStartDelayTable.Name = "scrollStartDelayTable";
            this.scrollStartDelayTable.RowCount = 1;
            this.scrollStartDelayTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scrollStartDelayTable.Size = new System.Drawing.Size(290, 28);
            this.scrollStartDelayTable.TabIndex = 4;
            // 
            // startDelayLabel
            // 
            this.startDelayLabel.AutoSize = true;
            this.startDelayLabel.Location = new System.Drawing.Point(2, 0);
            this.startDelayLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.startDelayLabel.Name = "startDelayLabel";
            this.startDelayLabel.Size = new System.Drawing.Size(59, 13);
            this.startDelayLabel.TabIndex = 2;
            this.startDelayLabel.Text = "Start Delay";
            // 
            // startDelayTextBox
            // 
            this.startDelayTextBox.Location = new System.Drawing.Point(155, 2);
            this.startDelayTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.startDelayTextBox.Name = "startDelayTextBox";
            this.startDelayTextBox.Size = new System.Drawing.Size(60, 20);
            this.startDelayTextBox.TabIndex = 3;
            this.startDelayTextBox.TextChanged += new System.EventHandler(this.startDelayTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(297, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // scrollDelayMultiplierNumericUpDown
            // 
            this.scrollDelayMultiplierNumericUpDown.DecimalPlaces = 1;
            this.scrollDelayMultiplierNumericUpDown.Location = new System.Drawing.Point(84, 63);
            this.scrollDelayMultiplierNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.scrollDelayMultiplierNumericUpDown.Name = "scrollDelayMultiplierNumericUpDown";
            this.scrollDelayMultiplierNumericUpDown.Size = new System.Drawing.Size(90, 20);
            this.scrollDelayMultiplierNumericUpDown.TabIndex = 7;
            this.scrollDelayMultiplierNumericUpDown.ValueChanged += new System.EventHandler(this.scrollDelayMultiplierNumericUpDown_ValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(916, 24);
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
            this.closeLibraryToolStripMenuItem,
            this.importTabToolStripMenuItem,
            this.exportTabToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newLibraryToolStripMenuItem
            // 
            this.newLibraryToolStripMenuItem.Name = "newLibraryToolStripMenuItem";
            this.newLibraryToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.newLibraryToolStripMenuItem.Text = "New Library";
            this.newLibraryToolStripMenuItem.Click += new System.EventHandler(this.newLibraryToolStripMenuItem_Click);
            // 
            // openLibraryToolStripMenuItem
            // 
            this.openLibraryToolStripMenuItem.Name = "openLibraryToolStripMenuItem";
            this.openLibraryToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.openLibraryToolStripMenuItem.Text = "Open Library";
            this.openLibraryToolStripMenuItem.Click += new System.EventHandler(this.openLibraryToolStripMenuItem_Click);
            // 
            // saveLibraryToolStripMenuItem
            // 
            this.saveLibraryToolStripMenuItem.Enabled = false;
            this.saveLibraryToolStripMenuItem.Name = "saveLibraryToolStripMenuItem";
            this.saveLibraryToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.saveLibraryToolStripMenuItem.Text = "Save Library";
            this.saveLibraryToolStripMenuItem.Click += new System.EventHandler(this.saveLibraryToolStripMenuItem_Click);
            // 
            // saveLibraryAsToolStripMenuItem
            // 
            this.saveLibraryAsToolStripMenuItem.Enabled = false;
            this.saveLibraryAsToolStripMenuItem.Name = "saveLibraryAsToolStripMenuItem";
            this.saveLibraryAsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.saveLibraryAsToolStripMenuItem.Text = "Save Library As";
            this.saveLibraryAsToolStripMenuItem.Click += new System.EventHandler(this.saveLibraryAsToolStripMenuItem_Click);
            // 
            // closeLibraryToolStripMenuItem
            // 
            this.closeLibraryToolStripMenuItem.Name = "closeLibraryToolStripMenuItem";
            this.closeLibraryToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.closeLibraryToolStripMenuItem.Text = "Close Library";
            this.closeLibraryToolStripMenuItem.Click += new System.EventHandler(this.closeLibraryToolStripMenuItem_Click);
            // 
            // importTabToolStripMenuItem
            // 
            this.importTabToolStripMenuItem.Name = "importTabToolStripMenuItem";
            this.importTabToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.importTabToolStripMenuItem.Text = "Import Tab";
            this.importTabToolStripMenuItem.Click += new System.EventHandler(this.importTabToolStripMenuItem_Click);
            // 
            // exportTabToolStripMenuItem
            // 
            this.exportTabToolStripMenuItem.Name = "exportTabToolStripMenuItem";
            this.exportTabToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.exportTabToolStripMenuItem.Text = "Export Tab";
            this.exportTabToolStripMenuItem.Click += new System.EventHandler(this.exportTabToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 344);
            this.Controls.Add(this.topBottemDivider);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.topBottemDivider.Panel1.ResumeLayout(false);
            this.topBottemDivider.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.topBottemDivider)).EndInit();
            this.topBottemDivider.ResumeLayout(false);
            this.tabVideoDivider.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabVideoDivider)).EndInit();
            this.tabVideoDivider.ResumeLayout(false);
            this.browserAddressDivider.Panel1.ResumeLayout(false);
            this.browserAddressDivider.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.browserAddressDivider)).EndInit();
            this.browserAddressDivider.ResumeLayout(false);
            this.videoAddressBarPanel.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.selectorsControlsDivider.Panel1.ResumeLayout(false);
            this.selectorsControlsDivider.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.selectorsControlsDivider)).EndInit();
            this.selectorsControlsDivider.ResumeLayout(false);
            this.selectorFlowPanel.ResumeLayout(false);
            this.controlsLogDivider.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.controlsLogDivider)).EndInit();
            this.controlsLogDivider.ResumeLayout(false);
            this.controlFlowPanel.ResumeLayout(false);
            this.controlFlowPanel.PerformLayout();
            this.scrollStartDelayTable.ResumeLayout(false);
            this.scrollStartDelayTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scrollDelayMultiplierNumericUpDown)).EndInit();
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
        private System.Windows.Forms.SplitContainer browserAddressDivider;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Panel videoAddressBarPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox addressBarTextBox;
        private System.Windows.Forms.Button addressGoButton;
        private System.Windows.Forms.Button addressStopButton;
        private System.Windows.Forms.ToolStripMenuItem closeLibraryToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel selectorFlowPanel;
        private System.Windows.Forms.ComboBox artistComboBox;
        private System.Windows.Forms.ComboBox titleComboBox;
        private System.Windows.Forms.FlowLayoutPanel controlFlowPanel;
        private System.Windows.Forms.Button scrollPlayButton;
        private System.Windows.Forms.Button scrollStopButton;
        private System.Windows.Forms.Button scrollResetButton;
        private System.Windows.Forms.Button markModeButton;
        private System.Windows.Forms.CheckBox enableVideoCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer scrollTimer;
        private System.Windows.Forms.TableLayoutPanel scrollStartDelayTable;
        private System.Windows.Forms.Label startDelayLabel;
        private System.Windows.Forms.TextBox startDelayTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown scrollDelayMultiplierNumericUpDown;
    }
}


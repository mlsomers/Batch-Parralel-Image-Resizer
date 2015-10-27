namespace BatchImageResampler {
  partial class Dashboard {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if(disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
      this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
      this.panelQueues = new System.Windows.Forms.Panel();
      this.threadStats3 = new BatchImageResampler.UI.ThreadStats();
      this.threadStats2 = new BatchImageResampler.UI.ThreadStats();
      this.threadStats1 = new BatchImageResampler.UI.ThreadStats();
      this.panel3 = new System.Windows.Forms.Panel();
      this.cbCombineIoThreads = new System.Windows.Forms.CheckBox();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.splitter1 = new System.Windows.Forms.Splitter();
      this.panelResizeSettings = new System.Windows.Forms.Panel();
      this.panel5 = new System.Windows.Forms.Panel();
      this.cbUseColorManagement = new System.Windows.Forms.CheckBox();
      this.label11 = new System.Windows.Forms.Label();
      this.algorithmCombo = new System.Windows.Forms.ComboBox();
      this.panel4 = new System.Windows.Forms.Panel();
      this.cbOverwrite = new System.Windows.Forms.CheckBox();
      this.tbFilenameFormat = new System.Windows.Forms.TextBox();
      this.label10 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.label6 = new System.Windows.Forms.Label();
      this.tbOutputDir = new System.Windows.Forms.TextBox();
      this.panel11 = new System.Windows.Forms.Panel();
      this.formatCombo = new System.Windows.Forms.ComboBox();
      this.label7 = new System.Windows.Forms.Label();
      this.panelResize = new System.Windows.Forms.Panel();
      this.neverEnlarge = new System.Windows.Forms.CheckBox();
      this.gbWidth = new System.Windows.Forms.GroupBox();
      this.xFitRb = new System.Windows.Forms.RadioButton();
      this.xCropRb = new System.Windows.Forms.RadioButton();
      this.gbHeight = new System.Windows.Forms.GroupBox();
      this.yFitRb = new System.Windows.Forms.RadioButton();
      this.yCropRb = new System.Windows.Forms.RadioButton();
      this.stretchCb = new System.Windows.Forms.CheckBox();
      this.panel10 = new System.Windows.Forms.Panel();
      this.label8 = new System.Windows.Forms.Label();
      this.maxHeight = new System.Windows.Forms.NumericUpDown();
      this.label9 = new System.Windows.Forms.Label();
      this.maxWidth = new System.Windows.Forms.NumericUpDown();
      this.resizeCb = new System.Windows.Forms.CheckBox();
      this.cbRotate = new System.Windows.Forms.CheckBox();
      this.cbSPortrait = new System.Windows.Forms.CheckBox();
      this.cbSLandscape = new System.Windows.Forms.CheckBox();
      this.label1 = new System.Windows.Forms.Label();
      this.toolStrip2 = new System.Windows.Forms.ToolStrip();
      this.btnLoadSettings = new System.Windows.Forms.ToolStripButton();
      this.btnSaveSettings = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.btnAbout = new System.Windows.Forms.ToolStripButton();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.btnOpenFiles = new System.Windows.Forms.ToolStripButton();
      this.btnRun = new System.Windows.Forms.ToolStripButton();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.destFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
      this.addFilesDialog = new System.Windows.Forms.OpenFileDialog();
      this.refreshTimer = new System.Windows.Forms.Timer(this.components);
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.lableRunningTime = new System.Windows.Forms.ToolStripStatusLabel();
      this.openSettingsDialog = new System.Windows.Forms.OpenFileDialog();
      this.saveSettingsDialog = new System.Windows.Forms.SaveFileDialog();
      this.toolStripContainer1.ContentPanel.SuspendLayout();
      this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
      this.toolStripContainer1.SuspendLayout();
      this.panelQueues.SuspendLayout();
      this.panel3.SuspendLayout();
      this.panelResizeSettings.SuspendLayout();
      this.panel5.SuspendLayout();
      this.panel4.SuspendLayout();
      this.panel11.SuspendLayout();
      this.panelResize.SuspendLayout();
      this.gbWidth.SuspendLayout();
      this.gbHeight.SuspendLayout();
      this.panel10.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.maxHeight)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.maxWidth)).BeginInit();
      this.toolStrip2.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStripContainer1
      // 
      // 
      // toolStripContainer1.ContentPanel
      // 
      this.toolStripContainer1.ContentPanel.Controls.Add(this.panelQueues);
      this.toolStripContainer1.ContentPanel.Controls.Add(this.splitter1);
      this.toolStripContainer1.ContentPanel.Controls.Add(this.panelResizeSettings);
      this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(865, 500);
      this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
      this.toolStripContainer1.Name = "toolStripContainer1";
      this.toolStripContainer1.Size = new System.Drawing.Size(865, 525);
      this.toolStripContainer1.TabIndex = 0;
      this.toolStripContainer1.Text = "toolStripContainer1";
      // 
      // toolStripContainer1.TopToolStripPanel
      // 
      this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
      this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip2);
      // 
      // panelQueues
      // 
      this.panelQueues.Controls.Add(this.threadStats3);
      this.panelQueues.Controls.Add(this.threadStats2);
      this.panelQueues.Controls.Add(this.threadStats1);
      this.panelQueues.Controls.Add(this.panel3);
      this.panelQueues.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelQueues.Location = new System.Drawing.Point(0, 388);
      this.panelQueues.Name = "panelQueues";
      this.panelQueues.Size = new System.Drawing.Size(571, 112);
      this.panelQueues.TabIndex = 1;
      // 
      // threadStats3
      // 
      this.threadStats3.Caption = "To be saved";
      this.threadStats3.Dock = System.Windows.Forms.DockStyle.Top;
      this.threadStats3.Location = new System.Drawing.Point(0, 78);
      this.threadStats3.MaxQueueLengthReadOnly = false;
      this.threadStats3.Name = "threadStats3";
      this.threadStats3.Queue = null;
      this.threadStats3.Size = new System.Drawing.Size(571, 29);
      this.threadStats3.TabIndex = 2;
      this.threadStats3.ThreadsAssigned = 1;
      this.threadStats3.ThreadsReadOnly = true;
      this.threadStats3.ThreadsAssignedChanged += new BatchImageResampler.UI.ThreadStats.ThreadsAssignedDelegate(this.threadStats3_ThreadsAssignedChanged);
      // 
      // threadStats2
      // 
      this.threadStats2.Caption = "To be processed";
      this.threadStats2.Dock = System.Windows.Forms.DockStyle.Top;
      this.threadStats2.Location = new System.Drawing.Point(0, 49);
      this.threadStats2.MaxQueueLengthReadOnly = false;
      this.threadStats2.Name = "threadStats2";
      this.threadStats2.Queue = null;
      this.threadStats2.Size = new System.Drawing.Size(571, 29);
      this.threadStats2.TabIndex = 1;
      this.threadStats2.ThreadsAssigned = 1;
      this.threadStats2.ThreadsReadOnly = false;
      this.threadStats2.ThreadsAssignedChanged += new BatchImageResampler.UI.ThreadStats.ThreadsAssignedDelegate(this.threadStats2_ThreadsAssignedChanged);
      // 
      // threadStats1
      // 
      this.threadStats1.Caption = "Images to be loaded";
      this.threadStats1.Dock = System.Windows.Forms.DockStyle.Top;
      this.threadStats1.Location = new System.Drawing.Point(0, 20);
      this.threadStats1.MaxQueueLengthReadOnly = true;
      this.threadStats1.Name = "threadStats1";
      this.threadStats1.Queue = null;
      this.threadStats1.Size = new System.Drawing.Size(571, 29);
      this.threadStats1.TabIndex = 0;
      this.threadStats1.ThreadsAssigned = 1;
      this.threadStats1.ThreadsReadOnly = true;
      this.threadStats1.ThreadsAssignedChanged += new BatchImageResampler.UI.ThreadStats.ThreadsAssignedDelegate(this.threadStats1_ThreadsAssignedChanged);
      // 
      // panel3
      // 
      this.panel3.BackColor = System.Drawing.Color.Gainsboro;
      this.panel3.Controls.Add(this.cbCombineIoThreads);
      this.panel3.Controls.Add(this.label5);
      this.panel3.Controls.Add(this.label4);
      this.panel3.Controls.Add(this.label3);
      this.panel3.Controls.Add(this.label2);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel3.Location = new System.Drawing.Point(0, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(571, 20);
      this.panel3.TabIndex = 3;
      // 
      // cbCombineIoThreads
      // 
      this.cbCombineIoThreads.AutoSize = true;
      this.cbCombineIoThreads.BackColor = System.Drawing.Color.Transparent;
      this.cbCombineIoThreads.Checked = true;
      this.cbCombineIoThreads.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbCombineIoThreads.Location = new System.Drawing.Point(3, 2);
      this.cbCombineIoThreads.Name = "cbCombineIoThreads";
      this.cbCombineIoThreads.Size = new System.Drawing.Size(226, 17);
      this.cbCombineIoThreads.TabIndex = 4;
      this.cbCombineIoThreads.Text = "Combine Load and Save in a single thread";
      this.toolTip1.SetToolTip(this.cbCombineIoThreads, "Check this to improve performance when the source and destination are both on the" +
        " same physical drive");
      this.cbCombineIoThreads.UseVisualStyleBackColor = false;
      this.cbCombineIoThreads.CheckedChanged += new System.EventHandler(this.cbCombineIoThreads_CheckedChanged);
      // 
      // label5
      // 
      this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(364, 4);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(32, 13);
      this.label5.TabIndex = 3;
      this.label5.Text = "Peak";
      // 
      // label4
      // 
      this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(287, 4);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(71, 13);
      this.label4.TabIndex = 2;
      this.label4.Text = "Queue length";
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(491, 4);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(46, 13);
      this.label3.TabIndex = 1;
      this.label3.Text = "Threads";
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(416, 4);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(60, 13);
      this.label2.TabIndex = 0;
      this.label2.Text = "Queue size";
      // 
      // splitter1
      // 
      this.splitter1.BackColor = System.Drawing.Color.Gainsboro;
      this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
      this.splitter1.Location = new System.Drawing.Point(571, 0);
      this.splitter1.Name = "splitter1";
      this.splitter1.Size = new System.Drawing.Size(7, 500);
      this.splitter1.TabIndex = 3;
      this.splitter1.TabStop = false;
      // 
      // panelResizeSettings
      // 
      this.panelResizeSettings.Controls.Add(this.panel5);
      this.panelResizeSettings.Controls.Add(this.panel4);
      this.panelResizeSettings.Controls.Add(this.panel11);
      this.panelResizeSettings.Controls.Add(this.panelResize);
      this.panelResizeSettings.Controls.Add(this.panel10);
      this.panelResizeSettings.Controls.Add(this.resizeCb);
      this.panelResizeSettings.Controls.Add(this.cbRotate);
      this.panelResizeSettings.Controls.Add(this.cbSPortrait);
      this.panelResizeSettings.Controls.Add(this.cbSLandscape);
      this.panelResizeSettings.Controls.Add(this.label1);
      this.panelResizeSettings.Dock = System.Windows.Forms.DockStyle.Right;
      this.panelResizeSettings.Location = new System.Drawing.Point(578, 0);
      this.panelResizeSettings.Name = "panelResizeSettings";
      this.panelResizeSettings.Size = new System.Drawing.Size(287, 500);
      this.panelResizeSettings.TabIndex = 2;
      // 
      // panel5
      // 
      this.panel5.Controls.Add(this.cbUseColorManagement);
      this.panel5.Controls.Add(this.label11);
      this.panel5.Controls.Add(this.algorithmCombo);
      this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel5.Location = new System.Drawing.Point(0, 382);
      this.panel5.Name = "panel5";
      this.panel5.Size = new System.Drawing.Size(287, 55);
      this.panel5.TabIndex = 31;
      // 
      // cbUseColorManagement
      // 
      this.cbUseColorManagement.AutoSize = true;
      this.cbUseColorManagement.Location = new System.Drawing.Point(5, 34);
      this.cbUseColorManagement.Name = "cbUseColorManagement";
      this.cbUseColorManagement.Size = new System.Drawing.Size(191, 17);
      this.cbUseColorManagement.TabIndex = 17;
      this.cbUseColorManagement.Text = "Use Embedded Color Management";
      this.toolTip1.SetToolTip(this.cbUseColorManagement, "Tell the algorithm to use the file\'s embedded color profile when resampling (I do" +
        "n\'t think GDI+ actually changes the calculation, guess it\'s only for displaying?" +
        ")");
      this.cbUseColorManagement.UseVisualStyleBackColor = true;
      this.cbUseColorManagement.CheckedChanged += new System.EventHandler(this.cbUseColorManagement_CheckedChanged);
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(9, 10);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(53, 13);
      this.label11.TabIndex = 16;
      this.label11.Text = "Algorithm:";
      // 
      // algorithmCombo
      // 
      this.algorithmCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.algorithmCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.algorithmCombo.FormattingEnabled = true;
      this.algorithmCombo.Location = new System.Drawing.Point(105, 7);
      this.algorithmCombo.Name = "algorithmCombo";
      this.algorithmCombo.Size = new System.Drawing.Size(177, 21);
      this.algorithmCombo.TabIndex = 15;
      this.toolTip1.SetToolTip(this.algorithmCombo, "Select a mathematical formula for resizing the images (affects quality and perfor" +
        "mance)");
      this.algorithmCombo.SelectedIndexChanged += new System.EventHandler(this.algorithmCombo_SelectedIndexChanged);
      // 
      // panel4
      // 
      this.panel4.Controls.Add(this.cbOverwrite);
      this.panel4.Controls.Add(this.tbFilenameFormat);
      this.panel4.Controls.Add(this.label10);
      this.panel4.Controls.Add(this.button1);
      this.panel4.Controls.Add(this.label6);
      this.panel4.Controls.Add(this.tbOutputDir);
      this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel4.Location = new System.Drawing.Point(0, 275);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(287, 107);
      this.panel4.TabIndex = 30;
      // 
      // cbOverwrite
      // 
      this.cbOverwrite.AutoSize = true;
      this.cbOverwrite.Location = new System.Drawing.Point(5, 85);
      this.cbOverwrite.Name = "cbOverwrite";
      this.cbOverwrite.Size = new System.Drawing.Size(109, 17);
      this.cbOverwrite.TabIndex = 5;
      this.cbOverwrite.Text = "Overwrite existing";
      this.cbOverwrite.UseVisualStyleBackColor = true;
      this.cbOverwrite.CheckedChanged += new System.EventHandler(this.cbOverwrite_CheckedChanged);
      // 
      // tbFilenameFormat
      // 
      this.tbFilenameFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbFilenameFormat.Location = new System.Drawing.Point(8, 59);
      this.tbFilenameFormat.Name = "tbFilenameFormat";
      this.tbFilenameFormat.Size = new System.Drawing.Size(274, 20);
      this.tbFilenameFormat.TabIndex = 4;
      this.tbFilenameFormat.Text = "*-resized";
      this.toolTip1.SetToolTip(this.tbFilenameFormat, "In the format \"prefix*postfix\" where \"*\" is the original filename.");
      this.tbFilenameFormat.TextChanged += new System.EventHandler(this.tbFilenameFormat_TextChanged);
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(9, 43);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(184, 13);
      this.label10.TabIndex = 3;
      this.label10.Text = "Destination Filename (excl. extension)";
      this.toolTip1.SetToolTip(this.label10, "In the format \"prefix*postfix\" where \"*\" is the original filename.");
      // 
      // button1
      // 
      this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.button1.Location = new System.Drawing.Point(245, 19);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(37, 21);
      this.button1.TabIndex = 2;
      this.button1.Text = "...";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(9, 6);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(82, 13);
      this.label6.TabIndex = 1;
      this.label6.Text = "Output directory";
      // 
      // tbOutputDir
      // 
      this.tbOutputDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbOutputDir.Location = new System.Drawing.Point(8, 20);
      this.tbOutputDir.Name = "tbOutputDir";
      this.tbOutputDir.Size = new System.Drawing.Size(239, 20);
      this.tbOutputDir.TabIndex = 0;
      this.tbOutputDir.TextChanged += new System.EventHandler(this.tbOutputDir_TextChanged);
      // 
      // panel11
      // 
      this.panel11.Controls.Add(this.formatCombo);
      this.panel11.Controls.Add(this.label7);
      this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel11.Location = new System.Drawing.Point(0, 245);
      this.panel11.Name = "panel11";
      this.panel11.Size = new System.Drawing.Size(287, 30);
      this.panel11.TabIndex = 27;
      // 
      // formatCombo
      // 
      this.formatCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.formatCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.formatCombo.FormattingEnabled = true;
      this.formatCombo.Location = new System.Drawing.Point(105, 4);
      this.formatCombo.Name = "formatCombo";
      this.formatCombo.Size = new System.Drawing.Size(178, 21);
      this.formatCombo.TabIndex = 10;
      this.formatCombo.SelectedIndexChanged += new System.EventHandler(this.formatCombo_SelectedIndexChanged);
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(3, 7);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(79, 13);
      this.label7.TabIndex = 11;
      this.label7.Text = "Storage format:";
      // 
      // panelResize
      // 
      this.panelResize.BackColor = System.Drawing.Color.Transparent;
      this.panelResize.Controls.Add(this.neverEnlarge);
      this.panelResize.Controls.Add(this.gbWidth);
      this.panelResize.Controls.Add(this.gbHeight);
      this.panelResize.Controls.Add(this.stretchCb);
      this.panelResize.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelResize.Location = new System.Drawing.Point(0, 129);
      this.panelResize.Name = "panelResize";
      this.panelResize.Size = new System.Drawing.Size(287, 116);
      this.panelResize.TabIndex = 24;
      // 
      // neverEnlarge
      // 
      this.neverEnlarge.AutoSize = true;
      this.neverEnlarge.Checked = true;
      this.neverEnlarge.CheckState = System.Windows.Forms.CheckState.Checked;
      this.neverEnlarge.Location = new System.Drawing.Point(5, 92);
      this.neverEnlarge.Name = "neverEnlarge";
      this.neverEnlarge.Size = new System.Drawing.Size(93, 17);
      this.neverEnlarge.TabIndex = 20;
      this.neverEnlarge.Text = "Never enlarge";
      this.neverEnlarge.UseVisualStyleBackColor = true;
      this.neverEnlarge.CheckedChanged += new System.EventHandler(this.neverEnlarge_CheckedChanged);
      // 
      // gbWidth
      // 
      this.gbWidth.Controls.Add(this.xFitRb);
      this.gbWidth.Controls.Add(this.xCropRb);
      this.gbWidth.Location = new System.Drawing.Point(3, 29);
      this.gbWidth.Name = "gbWidth";
      this.gbWidth.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.gbWidth.Size = new System.Drawing.Size(116, 57);
      this.gbWidth.TabIndex = 17;
      this.gbWidth.TabStop = false;
      this.gbWidth.Text = "Width";
      // 
      // xFitRb
      // 
      this.xFitRb.AutoSize = true;
      this.xFitRb.Dock = System.Windows.Forms.DockStyle.Top;
      this.xFitRb.Location = new System.Drawing.Point(5, 30);
      this.xFitRb.Name = "xFitRb";
      this.xFitRb.Size = new System.Drawing.Size(106, 17);
      this.xFitRb.TabIndex = 1;
      this.xFitRb.Text = "Fit";
      this.xFitRb.UseVisualStyleBackColor = true;
      this.xFitRb.CheckedChanged += new System.EventHandler(this.xCropRb_CheckedChanged);
      // 
      // xCropRb
      // 
      this.xCropRb.AutoSize = true;
      this.xCropRb.Checked = true;
      this.xCropRb.Dock = System.Windows.Forms.DockStyle.Top;
      this.xCropRb.Location = new System.Drawing.Point(5, 13);
      this.xCropRb.Name = "xCropRb";
      this.xCropRb.Size = new System.Drawing.Size(106, 17);
      this.xCropRb.TabIndex = 0;
      this.xCropRb.TabStop = true;
      this.xCropRb.Text = "Crop";
      this.xCropRb.UseVisualStyleBackColor = true;
      this.xCropRb.CheckedChanged += new System.EventHandler(this.xCropRb_CheckedChanged);
      // 
      // gbHeight
      // 
      this.gbHeight.Controls.Add(this.yFitRb);
      this.gbHeight.Controls.Add(this.yCropRb);
      this.gbHeight.Location = new System.Drawing.Point(125, 29);
      this.gbHeight.Name = "gbHeight";
      this.gbHeight.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.gbHeight.Size = new System.Drawing.Size(127, 57);
      this.gbHeight.TabIndex = 18;
      this.gbHeight.TabStop = false;
      this.gbHeight.Text = "Height";
      // 
      // yFitRb
      // 
      this.yFitRb.AutoSize = true;
      this.yFitRb.Dock = System.Windows.Forms.DockStyle.Top;
      this.yFitRb.Location = new System.Drawing.Point(5, 30);
      this.yFitRb.Name = "yFitRb";
      this.yFitRb.Size = new System.Drawing.Size(117, 17);
      this.yFitRb.TabIndex = 1;
      this.yFitRb.Text = "Fit";
      this.yFitRb.UseVisualStyleBackColor = true;
      this.yFitRb.CheckedChanged += new System.EventHandler(this.yFitRb_CheckedChanged);
      // 
      // yCropRb
      // 
      this.yCropRb.AutoSize = true;
      this.yCropRb.Checked = true;
      this.yCropRb.Dock = System.Windows.Forms.DockStyle.Top;
      this.yCropRb.Location = new System.Drawing.Point(5, 13);
      this.yCropRb.Name = "yCropRb";
      this.yCropRb.Size = new System.Drawing.Size(117, 17);
      this.yCropRb.TabIndex = 0;
      this.yCropRb.TabStop = true;
      this.yCropRb.Text = "Crop";
      this.yCropRb.UseVisualStyleBackColor = true;
      this.yCropRb.CheckedChanged += new System.EventHandler(this.yFitRb_CheckedChanged);
      // 
      // stretchCb
      // 
      this.stretchCb.AutoSize = true;
      this.stretchCb.Location = new System.Drawing.Point(6, 6);
      this.stretchCb.Name = "stretchCb";
      this.stretchCb.Size = new System.Drawing.Size(161, 17);
      this.stretchCb.TabIndex = 14;
      this.stretchCb.Text = "Stretch (discard aspect ratio)";
      this.stretchCb.UseVisualStyleBackColor = true;
      this.stretchCb.CheckedChanged += new System.EventHandler(this.stretchCb_CheckedChanged);
      // 
      // panel10
      // 
      this.panel10.Controls.Add(this.label8);
      this.panel10.Controls.Add(this.maxHeight);
      this.panel10.Controls.Add(this.label9);
      this.panel10.Controls.Add(this.maxWidth);
      this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel10.Location = new System.Drawing.Point(0, 81);
      this.panel10.Name = "panel10";
      this.panel10.Size = new System.Drawing.Size(287, 48);
      this.panel10.TabIndex = 25;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(2, 1);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(69, 13);
      this.label8.TabIndex = 15;
      this.label8.Text = "Target Width";
      // 
      // maxHeight
      // 
      this.maxHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.maxHeight.Location = new System.Drawing.Point(127, 18);
      this.maxHeight.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
      this.maxHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.maxHeight.Name = "maxHeight";
      this.maxHeight.Size = new System.Drawing.Size(156, 20);
      this.maxHeight.TabIndex = 1;
      this.maxHeight.ThousandsSeparator = true;
      this.maxHeight.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
      this.maxHeight.ValueChanged += new System.EventHandler(this.maxHeight_ValueChanged);
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(124, 1);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(72, 13);
      this.label9.TabIndex = 16;
      this.label9.Text = "Target Height";
      // 
      // maxWidth
      // 
      this.maxWidth.Location = new System.Drawing.Point(5, 18);
      this.maxWidth.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
      this.maxWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.maxWidth.Name = "maxWidth";
      this.maxWidth.Size = new System.Drawing.Size(116, 20);
      this.maxWidth.TabIndex = 0;
      this.maxWidth.ThousandsSeparator = true;
      this.maxWidth.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
      this.maxWidth.ValueChanged += new System.EventHandler(this.maxWidth_ValueChanged);
      // 
      // resizeCb
      // 
      this.resizeCb.AutoSize = true;
      this.resizeCb.Checked = true;
      this.resizeCb.CheckState = System.Windows.Forms.CheckState.Checked;
      this.resizeCb.Dock = System.Windows.Forms.DockStyle.Top;
      this.resizeCb.Location = new System.Drawing.Point(0, 64);
      this.resizeCb.Name = "resizeCb";
      this.resizeCb.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
      this.resizeCb.Size = new System.Drawing.Size(287, 17);
      this.resizeCb.TabIndex = 26;
      this.resizeCb.Text = "Resize";
      this.resizeCb.UseVisualStyleBackColor = true;
      this.resizeCb.CheckedChanged += new System.EventHandler(this.resizeCb_CheckedChanged);
      // 
      // cbRotate
      // 
      this.cbRotate.AutoSize = true;
      this.cbRotate.Checked = true;
      this.cbRotate.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbRotate.Dock = System.Windows.Forms.DockStyle.Top;
      this.cbRotate.Location = new System.Drawing.Point(0, 47);
      this.cbRotate.Name = "cbRotate";
      this.cbRotate.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
      this.cbRotate.Size = new System.Drawing.Size(287, 17);
      this.cbRotate.TabIndex = 28;
      this.cbRotate.Text = "Rotate based on EXIF orientation data";
      this.cbRotate.UseVisualStyleBackColor = true;
      this.cbRotate.CheckedChanged += new System.EventHandler(this.cbRotate_CheckedChanged);
      // 
      // cbSPortrait
      // 
      this.cbSPortrait.AutoSize = true;
      this.cbSPortrait.Dock = System.Windows.Forms.DockStyle.Top;
      this.cbSPortrait.Location = new System.Drawing.Point(0, 30);
      this.cbSPortrait.Name = "cbSPortrait";
      this.cbSPortrait.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
      this.cbSPortrait.Size = new System.Drawing.Size(287, 17);
      this.cbSPortrait.TabIndex = 22;
      this.cbSPortrait.Text = "Skip portrait";
      this.cbSPortrait.UseVisualStyleBackColor = true;
      this.cbSPortrait.CheckedChanged += new System.EventHandler(this.cbSPortrait_CheckedChanged);
      // 
      // cbSLandscape
      // 
      this.cbSLandscape.AutoSize = true;
      this.cbSLandscape.Dock = System.Windows.Forms.DockStyle.Top;
      this.cbSLandscape.Location = new System.Drawing.Point(0, 13);
      this.cbSLandscape.Name = "cbSLandscape";
      this.cbSLandscape.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
      this.cbSLandscape.Size = new System.Drawing.Size(287, 17);
      this.cbSLandscape.TabIndex = 21;
      this.cbSLandscape.Text = "Skip landscape";
      this.cbSLandscape.UseVisualStyleBackColor = true;
      this.cbSLandscape.CheckedChanged += new System.EventHandler(this.cbSLandscape_CheckedChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Dock = System.Windows.Forms.DockStyle.Top;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(0, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(116, 13);
      this.label1.TabIndex = 29;
      this.label1.Text = "Processing Options";
      // 
      // toolStrip2
      // 
      this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
      this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoadSettings,
            this.btnSaveSettings,
            this.toolStripSeparator1,
            this.btnAbout});
      this.toolStrip2.Location = new System.Drawing.Point(744, 0);
      this.toolStrip2.Name = "toolStrip2";
      this.toolStrip2.Size = new System.Drawing.Size(87, 25);
      this.toolStrip2.TabIndex = 1;
      // 
      // btnLoadSettings
      // 
      this.btnLoadSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnLoadSettings.Image = global::BatchImageResampler.Properties.Resources.folder_wrench;
      this.btnLoadSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnLoadSettings.Name = "btnLoadSettings";
      this.btnLoadSettings.Size = new System.Drawing.Size(23, 22);
      this.btnLoadSettings.Text = "Load settings";
      this.btnLoadSettings.Click += new System.EventHandler(this.btnLoadSettings_Click);
      // 
      // btnSaveSettings
      // 
      this.btnSaveSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnSaveSettings.Image = global::BatchImageResampler.Properties.Resources.disk;
      this.btnSaveSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnSaveSettings.Name = "btnSaveSettings";
      this.btnSaveSettings.Size = new System.Drawing.Size(23, 22);
      this.btnSaveSettings.Text = "Save settings";
      this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // btnAbout
      // 
      this.btnAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnAbout.Image = global::BatchImageResampler.Properties.Resources.information;
      this.btnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnAbout.Name = "btnAbout";
      this.btnAbout.Size = new System.Drawing.Size(23, 22);
      this.btnAbout.Text = "About Batch Image Resizer";
      this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
      // 
      // toolStrip1
      // 
      this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenFiles,
            this.btnRun});
      this.toolStrip1.Location = new System.Drawing.Point(8, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(58, 25);
      this.toolStrip1.TabIndex = 0;
      // 
      // btnOpenFiles
      // 
      this.btnOpenFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnOpenFiles.Image = global::BatchImageResampler.Properties.Resources.folder_image;
      this.btnOpenFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnOpenFiles.Name = "btnOpenFiles";
      this.btnOpenFiles.Size = new System.Drawing.Size(23, 22);
      this.btnOpenFiles.Text = "Add input files";
      this.btnOpenFiles.Click += new System.EventHandler(this.btnOpenFiles_Click);
      // 
      // btnRun
      // 
      this.btnRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnRun.Image = global::BatchImageResampler.Properties.Resources.control_play_blue;
      this.btnRun.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnRun.Name = "btnRun";
      this.btnRun.Size = new System.Drawing.Size(23, 22);
      this.btnRun.Text = "Run";
      this.btnRun.ToolTipText = "Run batch";
      this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
      // 
      // destFolderDialog
      // 
      this.destFolderDialog.Description = "Destination folder";
      this.destFolderDialog.RootFolder = System.Environment.SpecialFolder.System;
      // 
      // addFilesDialog
      // 
      this.addFilesDialog.Filter = "Image files|*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.tif;*.tiff|All files (*.*)|*.*";
      this.addFilesDialog.Multiselect = true;
      this.addFilesDialog.SupportMultiDottedExtensions = true;
      this.addFilesDialog.Title = "Select source files";
      // 
      // refreshTimer
      // 
      this.refreshTimer.Interval = 200;
      this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lableRunningTime});
      this.statusStrip1.Location = new System.Drawing.Point(0, 525);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(865, 22);
      this.statusStrip1.TabIndex = 4;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // toolStripStatusLabel1
      // 
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new System.Drawing.Size(82, 17);
      this.toolStripStatusLabel1.Text = "Running time:";
      this.toolStripStatusLabel1.ToolTipText = "Not verry accurate in this implementation.";
      // 
      // lableRunningTime
      // 
      this.lableRunningTime.ForeColor = System.Drawing.Color.Navy;
      this.lableRunningTime.Name = "lableRunningTime";
      this.lableRunningTime.Size = new System.Drawing.Size(13, 17);
      this.lableRunningTime.Text = "0";
      this.lableRunningTime.ToolTipText = "Not verry accurate in this implementation.";
      // 
      // openSettingsDialog
      // 
      this.openSettingsDialog.Filter = "Batch Image Resizer settings file (*.bir)|*.bir|All files (*.*)|*.*";
      this.openSettingsDialog.Title = "Load image resizing presets";
      // 
      // saveSettingsDialog
      // 
      this.saveSettingsDialog.Filter = "Batch Image Resizer settings file (*.bir)|*.bir|All files (*.*)|*.*";
      this.saveSettingsDialog.Title = "Save image resizing presets";
      // 
      // Dashboard
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(865, 547);
      this.Controls.Add(this.toolStripContainer1);
      this.Controls.Add(this.statusStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Dashboard";
      this.Text = "Batch Image Resizer";
      this.toolStripContainer1.ContentPanel.ResumeLayout(false);
      this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
      this.toolStripContainer1.TopToolStripPanel.PerformLayout();
      this.toolStripContainer1.ResumeLayout(false);
      this.toolStripContainer1.PerformLayout();
      this.panelQueues.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.panelResizeSettings.ResumeLayout(false);
      this.panelResizeSettings.PerformLayout();
      this.panel5.ResumeLayout(false);
      this.panel5.PerformLayout();
      this.panel4.ResumeLayout(false);
      this.panel4.PerformLayout();
      this.panel11.ResumeLayout(false);
      this.panel11.PerformLayout();
      this.panelResize.ResumeLayout(false);
      this.panelResize.PerformLayout();
      this.gbWidth.ResumeLayout(false);
      this.gbWidth.PerformLayout();
      this.gbHeight.ResumeLayout(false);
      this.gbHeight.PerformLayout();
      this.panel10.ResumeLayout(false);
      this.panel10.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.maxHeight)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.maxWidth)).EndInit();
      this.toolStrip2.ResumeLayout(false);
      this.toolStrip2.PerformLayout();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStripContainer toolStripContainer1;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton btnOpenFiles;
    private System.Windows.Forms.Panel panelQueues;
    private UI.ThreadStats threadStats3;
    private UI.ThreadStats threadStats2;
    private UI.ThreadStats threadStats1;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Splitter splitter1;
    private System.Windows.Forms.Panel panelResizeSettings;
    private System.Windows.Forms.Panel panel11;
    private System.Windows.Forms.ComboBox formatCombo;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Panel panelResize;
    private System.Windows.Forms.CheckBox neverEnlarge;
    private System.Windows.Forms.GroupBox gbWidth;
    private System.Windows.Forms.RadioButton xFitRb;
    private System.Windows.Forms.RadioButton xCropRb;
    private System.Windows.Forms.GroupBox gbHeight;
    private System.Windows.Forms.RadioButton yFitRb;
    private System.Windows.Forms.RadioButton yCropRb;
    private System.Windows.Forms.CheckBox stretchCb;
    private System.Windows.Forms.Panel panel10;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.NumericUpDown maxHeight;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.NumericUpDown maxWidth;
    private System.Windows.Forms.CheckBox resizeCb;
    private System.Windows.Forms.CheckBox cbRotate;
    private System.Windows.Forms.CheckBox cbSPortrait;
    private System.Windows.Forms.CheckBox cbSLandscape;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Panel panel5;
    private System.Windows.Forms.CheckBox cbUseColorManagement;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.ComboBox algorithmCombo;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.CheckBox cbOverwrite;
    private System.Windows.Forms.TextBox tbFilenameFormat;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox tbOutputDir;
    private System.Windows.Forms.CheckBox cbCombineIoThreads;
    private System.Windows.Forms.FolderBrowserDialog destFolderDialog;
    private System.Windows.Forms.OpenFileDialog addFilesDialog;
    private System.Windows.Forms.ToolStripButton btnRun;
    private System.Windows.Forms.Timer refreshTimer;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    private System.Windows.Forms.ToolStripStatusLabel lableRunningTime;
    private System.Windows.Forms.ToolStrip toolStrip2;
    private System.Windows.Forms.ToolStripButton btnLoadSettings;
    private System.Windows.Forms.ToolStripButton btnSaveSettings;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton btnAbout;
    private System.Windows.Forms.OpenFileDialog openSettingsDialog;
    private System.Windows.Forms.SaveFileDialog saveSettingsDialog;
  }
}


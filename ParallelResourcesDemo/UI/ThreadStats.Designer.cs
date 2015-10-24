namespace BatchImageResampler.UI {
  partial class ThreadStats {
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      this.caption = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.panel3 = new System.Windows.Forms.Panel();
      this.threadsAssigned = new System.Windows.Forms.NumericUpDown();
      this.maxItemsInQueue = new System.Windows.Forms.NumericUpDown();
      this.labelHighWaterMark = new System.Windows.Forms.Label();
      this.labelCurrentQueueLength = new System.Windows.Forms.Label();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.btnPlay = new System.Windows.Forms.Button();
      this.btnPause = new System.Windows.Forms.Button();
      this.btnStop = new System.Windows.Forms.Button();
      this.ThreadControls = new System.Windows.Forms.Panel();
      this.queueGauge1 = new BatchImageResampler.UI.QueueGauge();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.threadsAssigned)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.maxItemsInQueue)).BeginInit();
      this.ThreadControls.SuspendLayout();
      this.SuspendLayout();
      // 
      // caption
      // 
      this.caption.AutoSize = true;
      this.caption.BackColor = System.Drawing.Color.Transparent;
      this.caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.caption.Location = new System.Drawing.Point(2, 0);
      this.caption.Name = "caption";
      this.caption.Size = new System.Drawing.Size(79, 13);
      this.caption.TabIndex = 0;
      this.caption.Text = "Queue Lable";
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.caption);
      this.panel2.Controls.Add(this.queueGauge1);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(0, 0);
      this.panel2.Name = "panel2";
      this.panel2.Padding = new System.Windows.Forms.Padding(5);
      this.panel2.Size = new System.Drawing.Size(379, 30);
      this.panel2.TabIndex = 2;
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.threadsAssigned);
      this.panel3.Controls.Add(this.maxItemsInQueue);
      this.panel3.Controls.Add(this.labelHighWaterMark);
      this.panel3.Controls.Add(this.labelCurrentQueueLength);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
      this.panel3.Location = new System.Drawing.Point(106, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(273, 30);
      this.panel3.TabIndex = 3;
      // 
      // threadsAssigned
      // 
      this.threadsAssigned.Enabled = false;
      this.threadsAssigned.Location = new System.Drawing.Point(197, 9);
      this.threadsAssigned.Name = "threadsAssigned";
      this.threadsAssigned.ReadOnly = true;
      this.threadsAssigned.Size = new System.Drawing.Size(70, 20);
      this.threadsAssigned.TabIndex = 3;
      this.toolTip1.SetToolTip(this.threadsAssigned, "Number of threads processing the queue");
      this.threadsAssigned.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.threadsAssigned.ValueChanged += new System.EventHandler(this.threadsAssigned_ValueChanged);
      // 
      // maxItemsInQueue
      // 
      this.maxItemsInQueue.Location = new System.Drawing.Point(121, 9);
      this.maxItemsInQueue.Name = "maxItemsInQueue";
      this.maxItemsInQueue.Size = new System.Drawing.Size(70, 20);
      this.maxItemsInQueue.TabIndex = 2;
      this.toolTip1.SetToolTip(this.maxItemsInQueue, "Maximum queue length throttle");
      this.maxItemsInQueue.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
      this.maxItemsInQueue.ValueChanged += new System.EventHandler(this.maxItemsInQueue_ValueChanged);
      // 
      // labelHighWaterMark
      // 
      this.labelHighWaterMark.AutoSize = true;
      this.labelHighWaterMark.Location = new System.Drawing.Point(64, 11);
      this.labelHighWaterMark.Name = "labelHighWaterMark";
      this.labelHighWaterMark.Size = new System.Drawing.Size(13, 13);
      this.labelHighWaterMark.TabIndex = 1;
      this.labelHighWaterMark.Text = "5";
      this.toolTip1.SetToolTip(this.labelHighWaterMark, "High Water Mark");
      // 
      // labelCurrentQueueLength
      // 
      this.labelCurrentQueueLength.AutoSize = true;
      this.labelCurrentQueueLength.Location = new System.Drawing.Point(12, 11);
      this.labelCurrentQueueLength.Name = "labelCurrentQueueLength";
      this.labelCurrentQueueLength.Size = new System.Drawing.Size(13, 13);
      this.labelCurrentQueueLength.TabIndex = 0;
      this.labelCurrentQueueLength.Text = "4";
      this.toolTip1.SetToolTip(this.labelCurrentQueueLength, "Current Queue Length");
      // 
      // btnPlay
      // 
      this.btnPlay.Image = global::BatchImageResampler.Properties.Resources.control_play_blue;
      this.btnPlay.Location = new System.Drawing.Point(0, 7);
      this.btnPlay.Name = "btnPlay";
      this.btnPlay.Size = new System.Drawing.Size(23, 23);
      this.btnPlay.TabIndex = 0;
      this.toolTip1.SetToolTip(this.btnPlay, "Start all threads");
      this.btnPlay.UseVisualStyleBackColor = true;
      // 
      // btnPause
      // 
      this.btnPause.Image = global::BatchImageResampler.Properties.Resources.control_pause_blue;
      this.btnPause.Location = new System.Drawing.Point(22, 7);
      this.btnPause.Name = "btnPause";
      this.btnPause.Size = new System.Drawing.Size(23, 23);
      this.btnPause.TabIndex = 1;
      this.toolTip1.SetToolTip(this.btnPause, "Pause queues (but keep existing threads)");
      this.btnPause.UseVisualStyleBackColor = true;
      // 
      // btnStop
      // 
      this.btnStop.Image = global::BatchImageResampler.Properties.Resources.control_stop_blue;
      this.btnStop.Location = new System.Drawing.Point(44, 7);
      this.btnStop.Name = "btnStop";
      this.btnStop.Size = new System.Drawing.Size(23, 23);
      this.btnStop.TabIndex = 2;
      this.toolTip1.SetToolTip(this.btnStop, "Stop all threads");
      this.btnStop.UseVisualStyleBackColor = true;
      // 
      // ThreadControls
      // 
      this.ThreadControls.Controls.Add(this.btnStop);
      this.ThreadControls.Controls.Add(this.btnPause);
      this.ThreadControls.Controls.Add(this.btnPlay);
      this.ThreadControls.Dock = System.Windows.Forms.DockStyle.Right;
      this.ThreadControls.Location = new System.Drawing.Point(379, 0);
      this.ThreadControls.Name = "ThreadControls";
      this.ThreadControls.Size = new System.Drawing.Size(70, 30);
      this.ThreadControls.TabIndex = 4;
      this.ThreadControls.Visible = false;
      // 
      // queueGauge1
      // 
      this.queueGauge1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.queueGauge1.Location = new System.Drawing.Point(5, 5);
      this.queueGauge1.Name = "queueGauge1";
      this.queueGauge1.Padding = new System.Windows.Forms.Padding(3, 8, 3, 2);
      this.queueGauge1.Size = new System.Drawing.Size(369, 20);
      this.queueGauge1.TabIndex = 1;
      this.queueGauge1.Text = "queueGauge1";
      // 
      // ThreadStats
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.panel3);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.ThreadControls);
      this.Name = "ThreadStats";
      this.Size = new System.Drawing.Size(449, 30);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.threadsAssigned)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.maxItemsInQueue)).EndInit();
      this.ThreadControls.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label caption;
    private System.Windows.Forms.Panel panel2;
    private QueueGauge queueGauge1;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.NumericUpDown maxItemsInQueue;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.Label labelHighWaterMark;
    private System.Windows.Forms.Label labelCurrentQueueLength;
    private System.Windows.Forms.NumericUpDown threadsAssigned;
    private System.Windows.Forms.Panel ThreadControls;
    private System.Windows.Forms.Button btnPlay;
    private System.Windows.Forms.Button btnStop;
    private System.Windows.Forms.Button btnPause;
  }
}

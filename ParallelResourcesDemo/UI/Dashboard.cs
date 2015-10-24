using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using BatchImageResampler.Properties;
using ImageResizingLogic;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;

namespace BatchImageResampler {
  public partial class Dashboard : Form {

    private ConversionSettings settings = new ConversionSettings();

    private Stopwatch stopwatch = new Stopwatch();

    private JobRunner runner;

    public Dashboard() {
      InitializeComponent();
    }

    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);
      formatCombo.Items.AddRange(Enum.GetNames(typeof(ImageResizingLogic.Format)));
      algorithmCombo.Items.AddRange(Enum.GetNames(typeof(InterpolationMode)));
      ExtractSettings();
    }

    private bool ExtractSettingsRecurLock = false;
    private void ExtractSettings() {
      if(ExtractSettingsRecurLock) return;
      ExtractSettingsRecurLock = true;
      try {
        cbSLandscape.Checked = settings.SkipLandscape;
        cbSPortrait.Checked = settings.SkipPortrait;
        cbRotate.Checked = settings.RotateOnExifRotationData;
        resizeCb.Checked = settings.Resize;
        maxWidth.Value = settings.MaxWidth;
        maxHeight.Value = settings.MaxHeight;
        stretchCb.Checked = !settings.KeepAspectRatio;
        xCropRb.Checked = settings.RestrictWidth == AspectAction.Crop;
        yCropRb.Checked = settings.RestrictHeight == AspectAction.Crop;
        xFitRb.Checked = settings.RestrictWidth == AspectAction.Fit;
        yFitRb.Checked = settings.RestrictHeight == AspectAction.Fit;
        neverEnlarge.Checked = settings.NeverEnlarge;
        formatCombo.SelectedItem = settings.ImageFormat.ToString();
        tbOutputDir.Text = settings.DestDir;
        tbFilenameFormat.Text = settings.DestName;
        cbOverwrite.Checked = settings.Overwrite;
        algorithmCombo.SelectedItem = settings.ResampleAlgorithm.ToString();
        cbUseColorManagement.Checked = settings.useEmbeddedColorManagement;
        cbCombineIoThreads.Checked = settings.CombineIoThreads;
        threadStats1.ThreadsReadOnly = settings.CombineIoThreads;
        threadStats3.ThreadsReadOnly = settings.CombineIoThreads;
        threadStats1.Queue = new QueueWorkers.WorkItemQueue<object>(settings.Files.Select<string, ConversionJob>(filename => new ConversionJob(settings, filename)));
        threadStats2.Queue = new QueueWorkers.WorkItemQueue<object>(settings.MaxProcessQueueLength);
        threadStats3.Queue = new QueueWorkers.WorkItemQueue<object>(settings.MaxSaveQueueLength);
        threadStats1.ThreadsAssigned = settings.CombineIoThreads ? 1 : settings.MaxReadThreads;
        threadStats2.ThreadsAssigned = settings.MaxProcessThreads;
        threadStats3.ThreadsAssigned = settings.CombineIoThreads ? 1 : settings.MaxWriteThreads;
        panelResize.Enabled = settings.Resize;
        gbWidth.Enabled = settings.KeepAspectRatio;
        gbHeight.Enabled = settings.KeepAspectRatio;
      } finally {
        ExtractSettingsRecurLock = false; 
      }
    }

    private void cbCombineIoThreads_CheckedChanged(object sender, EventArgs e) {
      settings.CombineIoThreads = cbCombineIoThreads.Checked;
      ExtractSettings();
    }

    private void cbSLandscape_CheckedChanged(object sender, EventArgs e) {
      settings.SkipLandscape = cbSLandscape.Checked;
    }

    private void cbSPortrait_CheckedChanged(object sender, EventArgs e) {
      settings.SkipPortrait = cbSPortrait.Checked;
    }

    private void cbRotate_CheckedChanged(object sender, EventArgs e) {
      settings.RotateOnExifRotationData = cbRotate.Checked;
    }

    private void resizeCb_CheckedChanged(object sender, EventArgs e) {
      settings.Resize = resizeCb.Checked;
      ExtractSettings();
    }

    private void maxWidth_ValueChanged(object sender, EventArgs e) {
      settings.MaxWidth = (int)maxWidth.Value;
    }

    private void maxHeight_ValueChanged(object sender, EventArgs e) {
      settings.MaxHeight = (int)maxHeight.Value;
    }

    private void stretchCb_CheckedChanged(object sender, EventArgs e) {
      settings.KeepAspectRatio = !stretchCb.Checked;
      ExtractSettings();
    }

    private void xCropRb_CheckedChanged(object sender, EventArgs e) {
      settings.RestrictWidth = xCropRb.Checked ? AspectAction.Crop : AspectAction.Fit;
    }

    private void yFitRb_CheckedChanged(object sender, EventArgs e) {
      settings.RestrictHeight = yCropRb.Checked ? AspectAction.Crop : AspectAction.Fit;
    }

    private void neverEnlarge_CheckedChanged(object sender, EventArgs e) {
      settings.NeverEnlarge = neverEnlarge.Checked;
    }

    private void formatCombo_SelectedIndexChanged(object sender, EventArgs e) {
      if(formatCombo.SelectedIndex < 0) return;
      settings.ImageFormat = (Format)Enum.Parse(typeof(Format), formatCombo.Items[formatCombo.SelectedIndex].ToString(), true);
    }

    private void tbOutputDir_TextChanged(object sender, EventArgs e) {
      settings.DestDir = tbOutputDir.Text;
    }

    private void tbFilenameFormat_TextChanged(object sender, EventArgs e) {
      settings.DestName = tbFilenameFormat.Text;
    }

    private void cbOverwrite_CheckedChanged(object sender, EventArgs e) {
      settings.Overwrite = cbOverwrite.Checked;
    }

    private void algorithmCombo_SelectedIndexChanged(object sender, EventArgs e) {
      if(algorithmCombo.SelectedIndex < 0) return;
      settings.ResampleAlgorithm = (InterpolationMode)Enum.Parse(typeof(InterpolationMode), algorithmCombo.Items[algorithmCombo.SelectedIndex].ToString(), true);
    }

    private void cbUseColorManagement_CheckedChanged(object sender, EventArgs e) {
      settings.useEmbeddedColorManagement = cbUseColorManagement.Checked;
    }

    private void btnOpenFiles_Click(object sender, EventArgs e) {
      btnRun.Enabled = false;
      if(addFilesDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
      if(addFilesDialog.FileNames.Length<=0) return;
      settings.Files = addFilesDialog.FileNames;
      btnRun.Enabled = true;
      if(string.IsNullOrWhiteSpace(settings.DestDir)) {
        tbOutputDir.Text = System.IO.Path.GetDirectoryName(addFilesDialog.FileNames[0])+"\\thumbnails";
        tbFilenameFormat_TextChanged(this, EventArgs.Empty);
      }
      ExtractSettings();
    }

    private void btnRun_Click(object sender, EventArgs e) {
      btnRun.Enabled = false;
      stopwatch.Reset();
      runner = new JobRunner(settings);
      threadStats1.Queue = runner.LoadImageWorker.Queue;
      threadStats2.Queue = runner.ProcessImageWorker.Queue;
      threadStats3.Queue = runner.SaveImageWorker.Queue;
      if(ReferenceEquals(runner, null)) return;
      stopwatch.Start();
      runner.Run();
      refreshTimer.Enabled = true;
    }

    private void refreshTimer_Tick(object sender, EventArgs e) {
      refreshTimer.Enabled = false;
      try {
        threadStats1.UpdateStats();
        threadStats2.UpdateStats();
        threadStats3.UpdateStats();
        lableRunningTime.Text = stopwatch.Elapsed.ToString();
      } finally {
        if(runner.IsFinished) { // one last refresh to be shure
          runner.Stop();
          stopwatch.Stop();
          threadStats1.UpdateStats();
          threadStats2.UpdateStats();
          threadStats3.UpdateStats();
          lableRunningTime.Text = stopwatch.Elapsed.ToString();
          btnRun.Enabled = true;
        } else refreshTimer.Enabled = true;
      }
    }

    private void btnLoadSettings_Click(object sender, EventArgs e) {
      if(openSettingsDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
      saveSettingsDialog.FileName = openSettingsDialog.FileName;
      XmlSerializer ser = new XmlSerializer(typeof(ConversionSettings));
      using(System.IO.Stream stream = System.IO.File.OpenRead(openSettingsDialog.FileName)) {
        settings = (ConversionSettings)ser.Deserialize(stream);
      }
      ExtractSettings();
    }

    private void btnSaveSettings_Click(object sender, EventArgs e) {
      if(saveSettingsDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
      XmlSerializer ser = new XmlSerializer(typeof(ConversionSettings));
      using(System.IO.Stream stream = System.IO.File.Create(saveSettingsDialog.FileName)) {
        ser.Serialize(stream, settings);
      }
    }

    private void btnAbout_Click(object sender, EventArgs e) {
      using(AboutBox ab = new AboutBox()) {
        ab.ShowDialog();
      }
    }

  }
}

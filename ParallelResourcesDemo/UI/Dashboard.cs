using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using ImageResizingLogic;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;

namespace BatchImageResampler {
  public partial class Dashboard : Form {

    private ConversionSettings _settings = new ConversionSettings();

    private readonly Stopwatch _stopwatch = new Stopwatch();

    private JobRunner _runner;

    public Dashboard() {
      InitializeComponent();
    }

    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);
      formatCombo.Items.AddRange(Enum.GetNames(typeof(ImageResizingLogic.Format)));
      algorithmCombo.Items.AddRange(Enum.GetNames(typeof(InterpolationMode)));
      ExtractSettings();
    }

    private bool _extractSettingsRecurLock = false;
    private void ExtractSettings() {
      if(_extractSettingsRecurLock) return;
      _extractSettingsRecurLock = true;
      try {
        cbSLandscape.Checked = _settings.SkipLandscape;
        cbSPortrait.Checked = _settings.SkipPortrait;
        cbRotate.Checked = _settings.RotateOnExifRotationData;
        resizeCb.Checked = _settings.Resize;
        maxWidth.Value = _settings.MaxWidth;
        maxHeight.Value = _settings.MaxHeight;
        stretchCb.Checked = !_settings.KeepAspectRatio;
        xCropRb.Checked = _settings.RestrictWidth == AspectAction.Crop;
        yCropRb.Checked = _settings.RestrictHeight == AspectAction.Crop;
        xFitRb.Checked = _settings.RestrictWidth == AspectAction.Fit;
        yFitRb.Checked = _settings.RestrictHeight == AspectAction.Fit;
        neverEnlarge.Checked = _settings.NeverEnlarge;
        formatCombo.SelectedItem = _settings.ImageFormat.ToString();
        tbOutputDir.Text = _settings.DestDir;
        tbFilenameFormat.Text = _settings.DestName;
        cbOverwrite.Checked = _settings.Overwrite;
        algorithmCombo.SelectedItem = _settings.ResampleAlgorithm.ToString();
        cbUseColorManagement.Checked = _settings.useEmbeddedColorManagement;
        cbCombineIoThreads.Checked = _settings.CombineIoThreads;
        threadStats1.ThreadsReadOnly = _settings.CombineIoThreads;
        threadStats3.ThreadsReadOnly = _settings.CombineIoThreads;
        threadStats1.Queue = new QueueWorkers.WorkItemQueue<object>(_settings.Files.Select(filename => new ConversionJob(_settings, filename)));
        threadStats2.Queue = new QueueWorkers.WorkItemQueue<object>(_settings.MaxProcessQueueLength);
        threadStats3.Queue = new QueueWorkers.WorkItemQueue<object>(_settings.MaxSaveQueueLength);
        threadStats1.ThreadsAssigned = _settings.CombineIoThreads ? 1 : _settings.MaxReadThreads;
        threadStats2.ThreadsAssigned = _settings.MaxProcessThreads;
        threadStats3.ThreadsAssigned = _settings.CombineIoThreads ? 1 : _settings.MaxWriteThreads;
        panelResize.Enabled = _settings.Resize;
        gbWidth.Enabled = _settings.KeepAspectRatio;
        gbHeight.Enabled = _settings.KeepAspectRatio;
      } finally {
        _extractSettingsRecurLock = false; 
      }
    }

    private void cbCombineIoThreads_CheckedChanged(object sender, EventArgs e) {
      _settings.CombineIoThreads = cbCombineIoThreads.Checked;
      ExtractSettings();
    }

    private void cbSLandscape_CheckedChanged(object sender, EventArgs e) {
      _settings.SkipLandscape = cbSLandscape.Checked;
    }

    private void cbSPortrait_CheckedChanged(object sender, EventArgs e) {
      _settings.SkipPortrait = cbSPortrait.Checked;
    }

    private void cbRotate_CheckedChanged(object sender, EventArgs e) {
      _settings.RotateOnExifRotationData = cbRotate.Checked;
    }

    private void resizeCb_CheckedChanged(object sender, EventArgs e) {
      _settings.Resize = resizeCb.Checked;
      ExtractSettings();
    }

    private void maxWidth_ValueChanged(object sender, EventArgs e) {
      _settings.MaxWidth = (int)maxWidth.Value;
    }

    private void maxHeight_ValueChanged(object sender, EventArgs e) {
      _settings.MaxHeight = (int)maxHeight.Value;
    }

    private void stretchCb_CheckedChanged(object sender, EventArgs e) {
      _settings.KeepAspectRatio = !stretchCb.Checked;
      ExtractSettings();
    }

    private void xCropRb_CheckedChanged(object sender, EventArgs e) {
      _settings.RestrictWidth = xCropRb.Checked ? AspectAction.Crop : AspectAction.Fit;
    }

    private void yFitRb_CheckedChanged(object sender, EventArgs e) {
      _settings.RestrictHeight = yCropRb.Checked ? AspectAction.Crop : AspectAction.Fit;
    }

    private void neverEnlarge_CheckedChanged(object sender, EventArgs e) {
      _settings.NeverEnlarge = neverEnlarge.Checked;
    }

    private void formatCombo_SelectedIndexChanged(object sender, EventArgs e) {
      if(formatCombo.SelectedIndex < 0) return;
      _settings.ImageFormat = (Format)Enum.Parse(typeof(Format), formatCombo.Items[formatCombo.SelectedIndex].ToString(), true);
    }

    private void tbOutputDir_TextChanged(object sender, EventArgs e) {
      _settings.DestDir = tbOutputDir.Text;
    }

    private void tbFilenameFormat_TextChanged(object sender, EventArgs e) {
      _settings.DestName = tbFilenameFormat.Text;
    }

    private void cbOverwrite_CheckedChanged(object sender, EventArgs e) {
      _settings.Overwrite = cbOverwrite.Checked;
    }

    private void algorithmCombo_SelectedIndexChanged(object sender, EventArgs e) {
      if(algorithmCombo.SelectedIndex < 0) return;
      _settings.ResampleAlgorithm = (InterpolationMode)Enum.Parse(typeof(InterpolationMode), algorithmCombo.Items[algorithmCombo.SelectedIndex].ToString(), true);
    }

    private void cbUseColorManagement_CheckedChanged(object sender, EventArgs e) {
      _settings.useEmbeddedColorManagement = cbUseColorManagement.Checked;
    }

    private void threadStats1_ThreadsAssignedChanged(object sender, UI.ThreadStats.ThreadsAssignedEventArgs e){
      _settings.MaxReadThreads = threadStats1.ThreadsAssigned;
    }

    private void threadStats2_ThreadsAssignedChanged(object sender, UI.ThreadStats.ThreadsAssignedEventArgs e){
      _settings.MaxProcessThreads = threadStats2.ThreadsAssigned;
      _settings.MaxProcessQueueLength = threadStats2.Queue.MaxItems;
    }

    private void threadStats3_ThreadsAssignedChanged(object sender, UI.ThreadStats.ThreadsAssignedEventArgs e){
      _settings.MaxWriteThreads = threadStats3.ThreadsAssigned;
      _settings.MaxSaveQueueLength = threadStats3.Queue.MaxItems;
    }

    private void btnOpenFiles_Click(object sender, EventArgs e) {
      btnRun.Enabled = false;
      if(addFilesDialog.ShowDialog() != DialogResult.OK) return;
      if(addFilesDialog.FileNames.Length<=0) return;
      _settings.Files = addFilesDialog.FileNames;
      btnRun.Enabled = true;
      if(string.IsNullOrWhiteSpace(_settings.DestDir)) {
        tbOutputDir.Text = System.IO.Path.GetDirectoryName(addFilesDialog.FileNames[0]) + @"\\thumbnails";
        tbFilenameFormat_TextChanged(this, EventArgs.Empty);
      }
      ExtractSettings();
    }

    private void btnRun_Click(object sender, EventArgs e) {
      btnRun.Enabled = false;
      panelResizeSettings.Enabled = false;
      panelQueues.Enabled = false;
      _stopwatch.Reset();
      _runner = new JobRunner(_settings);
      threadStats1.Queue = _runner.LoadImageWorker.Queue;
      threadStats2.Queue = _runner.ProcessImageWorker.Queue;
      threadStats3.Queue = _runner.SaveImageWorker.Queue;
      _stopwatch.Start();
      _runner.Run();
      refreshTimer.Enabled = true;
    }

    private void refreshTimer_Tick(object sender, EventArgs e) {
      refreshTimer.Enabled = false;
      try {
        threadStats1.UpdateStats();
        threadStats2.UpdateStats();
        threadStats3.UpdateStats();
        lableRunningTime.Text = _stopwatch.Elapsed.ToString();
      } finally {
        if(_runner.IsFinished) { // one last refresh to be shure
          _runner.Stop();
          _stopwatch.Stop();
          threadStats1.UpdateStats();
          threadStats2.UpdateStats();
          threadStats3.UpdateStats();
          lableRunningTime.Text = _stopwatch.Elapsed.ToString();
          btnRun.Enabled = true;
          panelResizeSettings.Enabled = true;
          panelQueues.Enabled = true;
        } else refreshTimer.Enabled = true;
      }
    }

    private void btnLoadSettings_Click(object sender, EventArgs e) {
      if(openSettingsDialog.ShowDialog() != DialogResult.OK) return;
      saveSettingsDialog.FileName = openSettingsDialog.FileName;
      XmlSerializer ser = new XmlSerializer(typeof(ConversionSettings));
      using(System.IO.Stream stream = System.IO.File.OpenRead(openSettingsDialog.FileName)) {
        _settings = (ConversionSettings)ser.Deserialize(stream);
      }
      ExtractSettings();
    }

    private void btnSaveSettings_Click(object sender, EventArgs e) {
      if(saveSettingsDialog.ShowDialog() != DialogResult.OK) return;
      XmlSerializer ser = new XmlSerializer(typeof(ConversionSettings));
      using(System.IO.Stream stream = System.IO.File.Create(saveSettingsDialog.FileName)) {
        ser.Serialize(stream, _settings);
      }
    }

    private void btnAbout_Click(object sender, EventArgs e) {
      using(AboutBox ab = new AboutBox()) {
        ab.ShowDialog();
      }
    }

    

    

  }
}

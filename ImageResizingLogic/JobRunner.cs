using System;
using QueueWorkers;
using System.Drawing;

namespace ImageResizingLogic {
  public class JobRunner {

    /// <summary>
    /// Threads responsible for loading the images into memory
    /// </summary>
    /// <remarks>
    /// We would have made this a QueueJob&lt;ConversionJob&gt; if we always were using the CombinedIoWorker
    /// </remarks>
    private Worker<ConversionJob> _LoadImageWorker;

    /// <summary>
    /// Threads responsible for processing the images
    /// </summary>
    private ResizeImageWorker _ProcessImageWorker;

    /// <summary>
    /// Threads responsible for saving the images back to disk
    /// </summary>
    /// <remarks>
    /// We would have made this a QueueJob&lt;ConversionJob&gt; if we always were using the CombinedIoWorker
    /// </remarks>
    private Worker<ConversionJob> _SaveImageWorker;

    /// <summary>
    /// Will run a single thread picking items from the LoadImageWorker and SaveImageWorker
    /// </summary>
    private MultiQueueWorker<ConversionJob> _CombinedIoWorker;

    private ConversionSettings _Settings;

    /// <summary>
    /// Constructor, wires everything up.
    /// Note that eaither the CombinedIoWorker will be used (using the base class of Load/SaveImageWorker's) or the Load/SaveImageWorker's themselves.
    /// Since I'm lazy, I'm instantiating all here even though some parts may never be used (for the sake of the demo)
    /// </summary>
    public JobRunner(ConversionSettings settings) {
      _Settings = settings;
      ConversionJob[] jobs = new ConversionJob[settings.Files.Length];
      for(int t = settings.Files.Length - 1; t >= 0; t--) jobs[t] = new ConversionJob(_Settings, settings.Files[t]);

      _SaveImageWorker = new Worker<ConversionJob>(_Settings.MaxSaveQueueLength);
      _ProcessImageWorker = new ResizeImageWorker(_Settings.MaxProcessQueueLength) { DestinationQueue = _SaveImageWorker.Queue };
      _LoadImageWorker = new Worker<ConversionJob>(jobs) { DestinationQueue = _ProcessImageWorker.Queue };

      _CombinedIoWorker = new MultiQueueWorker<ConversionJob>(new QueueJob<ConversionJob>[] { _LoadImageWorker, _SaveImageWorker });
      _CombinedIoWorker.Prioritize = true; // Saving is more important than loading (prevent memory crisis)

      // hooking up events, the _ProcessImageWorker uses inheritence wich is more favourable (compile-time binding rather than runtime)
      _LoadImageWorker.DoWork += LoadImage;
      _SaveImageWorker.DoWork += SaveImage;
    }

    public Worker<ConversionJob> LoadImageWorker { get { return _LoadImageWorker; } }
    public ResizeImageWorker ProcessImageWorker { get { return _ProcessImageWorker; } }
    public Worker<ConversionJob> SaveImageWorker { get { return _SaveImageWorker; } }
    public MultiQueueWorker<ConversionJob> CombinedIoWorker { get { return _CombinedIoWorker; } }

    public void Run() {
      if(!System.IO.Directory.Exists(_Settings.DestDir)) System.IO.Directory.CreateDirectory(_Settings.DestDir);
      if(_Settings.CombineIoThreads) {
        _CombinedIoWorker.Start();
        _ProcessImageWorker.Start(_Settings.MaxProcessThreads);
      } else {
        _LoadImageWorker.Start(_Settings.MaxReadThreads);
        _ProcessImageWorker.Start(_Settings.MaxProcessThreads);
        _SaveImageWorker.Start(_Settings.MaxWriteThreads);
      }
    }

    public bool IsFinished {
      get {
        if(_Settings.CombineIoThreads) {
          return (_ProcessImageWorker.Queue.Count == 0 && _ProcessImageWorker.Queue.IdleThreads == _ProcessImageWorker.ThreadCount
            && _LoadImageWorker.Queue.Count == 0 && _SaveImageWorker.Queue.Count == 0 && CombinedIoWorker.Idle);
        } else {
          return (_LoadImageWorker.Queue.Count == 0 && _LoadImageWorker.Queue.IdleThreads == _LoadImageWorker.ThreadCount
            && _ProcessImageWorker.Queue.Count == 0 && _ProcessImageWorker.Queue.IdleThreads == _ProcessImageWorker.ThreadCount
            && _SaveImageWorker.Queue.Count == 0 && _SaveImageWorker.Queue.IdleThreads == _SaveImageWorker.ThreadCount);
        }
      }
    }

    private void LoadImage(ConversionJob job) {
      job.ImageBitmap = (Bitmap)Image.FromFile(job.FileName, job.Settings.useEmbeddedColorManagement);
    }

    private void SaveImage(ConversionJob job) {
      if(ReferenceEquals(job.ImageBitmap, null)) {
        job.Log.Add(string.Concat("Unable to save empty image: ", job.FileName));
        return;
      }
      string ext = "." + job.Settings.ImageFormat.ToString();
      string filename = job.Settings.DestName.Replace("*", System.IO.Path.GetFileNameWithoutExtension(job.FileName));
      string destPath = System.IO.Path.Combine(job.Settings.DestDir, filename + ext);
      try {
        if(!job.Settings.Overwrite && System.IO.File.Exists(destPath)) {
          job.Log.Add(string.Concat("Overwriting existing image is not permitted: ", destPath));
          return;
        }
        job.ImageBitmap.Save(destPath, ResizingLogic.formats[(int)job.Settings.ImageFormat]);
      } catch(Exception ex) {
        job.Log.Add(string.Concat("An exception occurred while trying to save image \"", destPath, "\" : ", ex.Message));
      }
    }


    public void Stop() {
      _LoadImageWorker.Stop();
      _ProcessImageWorker.Stop();
      _SaveImageWorker.Stop();
      _CombinedIoWorker.Stop();
    }
  }

  
}

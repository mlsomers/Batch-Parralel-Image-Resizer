using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Drawing;

namespace ImageResizingLogic {

  /// <summary>
  /// Discrete container that can be passed from one process to the other and be buffered in a queue during a job's lifespan
  /// </summary>
  public class ConversionJob {

    public ConversionJob():base() { }
    public ConversionJob(ConversionSettings settings) : this() {
      _Settings = settings;
    }
    public ConversionJob(ConversionSettings settings, string filename) : this(settings) {
      _FileName = filename;
    }

    private string _FileName;
    /// <summary>
    /// Original filename of the image
    /// </summary>
    public string FileName {
      get { return _FileName; }
      set { _FileName = value; }
    }

    private ConversionSettings _Settings;
    /// <summary>
    /// All (meta) information needed to perform the job
    /// </summary>
    public ConversionSettings Settings {
      get { return _Settings; }
      set { _Settings = value; }
    }

    private Bitmap _ImageBitmap;
    /// <summary>
    /// The raw information needed for this specific job
    /// </summary>
    public Bitmap ImageBitmap {
      get { return _ImageBitmap; }
      set { _ImageBitmap = value; }
    }

    private List<string> _Log=new List<string>();
    /// <summary>
    /// Minimalistic log of errors or warnings belonging to this job
    /// </summary>
    public List<string> Log {
      get { return _Log; }
      set { _Log = value; }
    }
  }
}

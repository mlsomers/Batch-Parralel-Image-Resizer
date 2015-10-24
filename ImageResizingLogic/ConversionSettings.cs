using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace ImageResizingLogic {
  /// <summary>
  /// This class could be edited in a standard PropertyGrid
  /// </summary>
  [Serializable]
  public class ConversionSettings {

    private bool _Resize = true;
    /// <summary>
    /// True to resize images, otherwise images will only be saved in the chosen format
    /// </summary>
    [XmlAttribute("Resize")]
    [Category("Settings")]
    [DisplayName("Resize")]
    [Description("True to resize images, otherwise images will only be saved in the chosen format")]
    [DefaultValue(true)]
    public bool Resize {
      get { return _Resize; }
      set { _Resize = value; }
    }

    private bool _NeverEnlarge = true;
    /// <summary>
    /// This will ensure that small images do not grow in size, only large images are resized to fit the constraints
    /// </summary>
    [XmlAttribute("NeverEnlarge")]
    [Category("Settings")]
    [DisplayName("NeverEnlarge")]
    [Description("This will ensure that small images do not grow in size, only large images are resized to fit the constraints")]
    public bool NeverEnlarge {
      get { return _NeverEnlarge; }
      set { _NeverEnlarge = value; }
    }

    private int _MaxHeight = 60;
    /// <summary>
    /// Maximum image Height
    /// </summary>
    [XmlAttribute("MaxHeight")]
    [Category("Settings")]
    [DisplayName("Max Height")]
    [Description("Maximum image Height")]
    public int MaxHeight {
      get { return _MaxHeight; }
      set { _MaxHeight = value; }
    }

    private int _MaxWidth = 80;
    /// <summary>
    /// Maximum image Width
    /// </summary>
    [XmlAttribute("MaxWidth")]
    [Category("Settings")]
    [DisplayName("MaxWidth")]
    [Description("Maximum image Width")]
    public int MaxWidth {
      get { return _MaxWidth; }
      set { _MaxWidth = value; }
    }

    private AspectAction _RestrictWidth = AspectAction.Crop;
    /// <summary>
    /// Resize according to width (or ignore the width)
    /// </summary>
    [XmlAttribute("RestrictWidth")]
    [Category("Settings")]
    [DisplayName("RestrictWidth")]
    [Description("Resize according to width (or ignore the width)")]
    [DefaultValue(AspectAction.Crop)]
    public AspectAction RestrictWidth {
      get { return _RestrictWidth; }
      set { _RestrictWidth = value; }
    }

    private AspectAction _RestrictHeight = AspectAction.Fit;
    /// <summary>
    /// Resize according to height (or ignore the height)
    /// </summary>
    [XmlAttribute("RestrictHeight")]
    [Category("Settings")]
    [DisplayName("RestrictHeight")]
    [Description("Resize according to height (or ignore the height)")]
    [DefaultValue(AspectAction.Crop)]
    public AspectAction RestrictHeight {
      get { return _RestrictHeight; }
      set { _RestrictHeight = value; }
    }

    private bool _KeepAspectRatio = true;
    /// <summary>
    /// Keep aspect ratio. Will cause the image to have a different aspect ratio than the target space (leaving whitspace open in documents, or causing black borders on LCD photo displays)
    /// </summary>
    [XmlAttribute("kar")]
    [Category("Settings")]
    [DisplayName("Crop")]
    [Description("Keep aspect ratio. Will cause the image to have a different aspect ratio than the target space (leaving whitspace open in documents, or causing black borders on LCD photo displays)")]
    [DefaultValue(true)]
    public bool KeepAspectRatio {
      get { return _KeepAspectRatio; }
      set { _KeepAspectRatio = value; }
    }

    private string[] _Files = new string[0];
    /// <summary>
    /// The files that should be processed
    /// </summary>
    [XmlIgnore]
    [Category("Runtime")]
    [DisplayName("Files")]
    [Description("The files that should be processed")]
    public string[] Files {
      get { return _Files; }
      set { _Files = value; }
    }

    private string _DestDir;
    /// <summary>
    /// Destination directory for the processed files
    /// </summary>
    [XmlAttribute("DestDir")]
    [Category("Runtime")]
    [DisplayName("DestDir")]
    [Description("Destination directory for the processed files")]
    public string DestDir {
      get { return _DestDir; }
      set { _DestDir = value; }
    }

    private string _DestName = "*-smaller";
    /// <summary>
    /// New filename formatted as "prefix*postfix" where * represents the original filename (excluding the extension)
    /// </summary>
    [XmlAttribute("Dest")]
    [Category("Settings")]
    [DisplayName("DestName")]
    [Description("New filename formatted as \"prefix*postfix\" where * represents the original filename (excluding the extension)")]
    public string DestName {
      get { return _DestName; }
      set { _DestName = value; }
    }

    private bool _Overwrite;
    /// <summary>
    /// Overwrite an existing file when saving
    /// </summary>
    [XmlAttribute("Overwrite")]
    [Category("Settings")]
    [DisplayName("Overwrite")]
    [Description("Overwrite an existing file when saving")]
    public bool Overwrite {
      get { return _Overwrite; }
      set { _Overwrite = value; }
    }

    private InterpolationMode _ResampleAlgorithm = InterpolationMode.HighQualityBicubic;
    /// <summary>
    /// The mathematical algorithm used to resample the image (this can greatly influence the quality of the result and the processing resources (time it takes to finish the job))
    /// </summary>
    [XmlAttribute("ResampleAlgorithm")]
    [Category("Settings")]
    [DisplayName("Resample Algorithm")]
    [Description("The mathematical algorithm used to resample the image (this can greatly influence the quality of the result and the processing resources (time it takes to finish the job))")]
    public InterpolationMode ResampleAlgorithm {
      get { return _ResampleAlgorithm; }
      set { _ResampleAlgorithm = value; }
    }

    private bool _useEmbeddedColorManagement;
    /// <summary>
    /// Indicate if GDI+ should care about the embedded color profile or ignore it.
    /// </summary>
    [XmlAttribute("useEmbeddedColorManagement")]
    [Category("Settings")]
    [DisplayName("Use Embedded color management")]
    [Description("Indicate if GDI+ should care about the embedded color profile or ignore it.")]
    public bool useEmbeddedColorManagement {
      get { return _useEmbeddedColorManagement; }
      set { _useEmbeddedColorManagement = value; }
    }

    private Format _ImageFormat = Format.Jpeg;
    /// <summary>
    /// The desired format with which to store the Image
    /// </summary>
    [XmlAttribute("ImageCodec")]
    [Category("Settings")]
    [DisplayName("ImageCodec")]
    [Description("The desired format with which to store the Image")]
    [DefaultValue(Format.Jpeg)]
    public Format ImageFormat {
      get { return _ImageFormat; }
      set { _ImageFormat = value; }
    }

    private bool _SkipLandscape;
    /// <summary>
    /// Skip landscape ratio images
    /// </summary>
    [XmlAttribute("SkipLandscape")]
    [Category("Tweak")]
    [DisplayName("SkipLandscape")]
    [Description("Skip landscape ratio images")]
    public bool SkipLandscape {
      get { return _SkipLandscape; }
      set { _SkipLandscape = value; }
    }

    private bool _SkipPortrait;
    /// <summary>
    /// Skip portrait ratio images
    /// </summary>
    [XmlAttribute("SkipPortrait")]
    [Category("Tweak")]
    [DisplayName("SkipPortrait")]
    [Description("Skip portrait ratio images")]
    public bool SkipPortrait {
      get { return _SkipPortrait; }
      set { _SkipPortrait = value; }
    }

    private bool _RotateOnExifRotationData = true;
    /// <summary>
    /// Will physically rotate the image to the correct orientation based on EXIF rotation data
    /// </summary>
    [XmlAttribute("RotateOnExifRotationData")]
    [Category("Tweak")]
    [DisplayName("RotateOnExifRotationData")]
    [Description("Will physically rotate the image to the correct orientation based on EXIF rotation data")]
    [DefaultValue(true)]
    public bool RotateOnExifRotationData {
      get { return _RotateOnExifRotationData; }
      set { _RotateOnExifRotationData = value; }
    }

    private bool _CombineIoThreads;
    /// <summary>
    /// Do reading and writing operations in a single thread (usefull when source and destination are on the same physical drive)
    /// </summary>
    [XmlAttribute("CombineIoThreads")]
    [Category("Threads")]
    [DisplayName("CombineIoThreads")]
    [Description("Do reading and writing operations in a single thread (usefull when source and destination are on the same physical drive)")]
    public bool CombineIoThreads {
      get { return _CombineIoThreads; }
      set { _CombineIoThreads = value; }
    }

    private int _MaxReadThreads = 1;
    /// <summary>
    /// Maximum number of Reading IO threads
    /// </summary>
    [XmlAttribute("MaxReadThreads")]
    [Category("Threads")]
    [DisplayName("MaxReadThreads")]
    [Description("Maximum number of Reading IO threads")]
    public int MaxReadThreads {
      get { return _MaxReadThreads; }
      set { _MaxReadThreads = value; }
    }

    private int _MaxWriteThreads = 1;
    /// <summary>
    /// Maximum number of write IO threads
    /// </summary>
    [XmlAttribute("MaxWriteThreads")]
    [Category("Threads")]
    [DisplayName("MaxWriteThreads")]
    [Description("Maximum number of write IO threads")]
    public int MaxWriteThreads {
      get { return _MaxWriteThreads; }
      set { _MaxWriteThreads = value; }
    }

    private int _MaxProcessThreads = 2;
    /// <summary>
    /// Maximum number of threads processing the images
    /// </summary>
    [XmlAttribute("MaxProcessThreads")]
    [Category("Threads")]
    [DisplayName("MaxProcessThreads")]
    [Description("Maximum number of threads processing the images")]
    public int MaxProcessThreads {
      get { return _MaxProcessThreads; }
      set { _MaxProcessThreads = value; }
    }

    private int _MaxProcessQueueLength = 10;
    /// <summary>
    /// Maximum queue lenth of loaded images waiting to be processed
    /// </summary>
    [XmlAttribute("MaxProcessQueueLength")]
    [Category("Queues")]
    [DisplayName("MaxProcessQueueLength")]
    [Description("Maximum queue lenth of loaded images waiting to be processed")]
    public int MaxProcessQueueLength {
      get { return _MaxProcessQueueLength; }
      set { _MaxProcessQueueLength = value; }
    }

    private int _MaxSaveQueueLength = 10;
    /// <summary>
    /// Maximum length of processed images waiting to be saved
    /// </summary>
    [XmlAttribute("MaxSaveQueueLength")]
    [Category("Queues")]
    [DisplayName("MaxSaveQueueLength")]
    [Description("Maximum length of processed images waiting to be saved")]
    public int MaxSaveQueueLength {
      get { return _MaxSaveQueueLength; }
      set { _MaxSaveQueueLength = value; }
    }

  }

  [Serializable]
  public enum AspectAction {
    /// <summary>
    /// Cut the sticking-out edges off
    /// </summary>
    Crop,
    /// <summary>
    /// Shrink the image to fit, what happens to the other dimension depends on the "Keep Aspect Ratio" checkbox
    /// </summary>
    Fit
  }

  [Serializable]
  public enum Format {
    Jpeg = 0,
    Png = 1,
    Bmp = 2,
    Tiff = 3,
    Gif = 4,
    Wmf = 5,
    Emf = 6
  }
}

using System.Collections.Generic;
using QueueWorkers;

namespace ImageResizingLogic {
  public class ResizeImageWorker : Worker<ConversionJob> {
    public ResizeImageWorker() : base() { }
    public ResizeImageWorker(int capacity) : base(capacity) { }
    public ResizeImageWorker(IEnumerable<ConversionJob> collection) : base(collection) { }

    protected override void OnDoWork(ConversionJob workItem) {
      base.OnDoWork(workItem);
      Resize(workItem);
    }

    private static void Resize(ConversionJob workItem) {
      if(SkipImage(workItem)) return;
      int maxWidth = workItem.Settings.MaxWidth;
      int maxHeight = workItem.Settings.MaxHeight;
      if(workItem.Settings.NeverEnlarge) {
        if((maxWidth > workItem.ImageBitmap.Width) && (maxHeight > workItem.ImageBitmap.Height)) return; // smaller image, nothing to resize!
        if(maxWidth > workItem.ImageBitmap.Width) maxWidth = workItem.ImageBitmap.Width;
        if(maxHeight > workItem.ImageBitmap.Height) maxHeight = workItem.ImageBitmap.Height;
      }

      if(!workItem.Settings.KeepAspectRatio) { // resize unproportionally
        workItem.ImageBitmap = ResizingLogic.Resize(
          workItem.ImageBitmap,
          maxWidth,
          maxHeight,
          workItem.Settings.ResampleAlgorithm);
      } else {
        workItem.ImageBitmap = ResizingLogic.Resize(workItem.ImageBitmap,
          maxWidth,
          maxHeight,
          workItem.Settings.RestrictWidth == AspectAction.Crop,
          workItem.Settings.RestrictHeight == AspectAction.Crop,
          workItem.Settings.ResampleAlgorithm);
      }
    }

    private static bool SkipImage(ConversionJob workItem) {
      if(workItem.Settings.SkipLandscape && (workItem.ImageBitmap.Width > workItem.ImageBitmap.Height)) return true;
      if(workItem.Settings.SkipPortrait && (workItem.ImageBitmap.Width < workItem.ImageBitmap.Height)) return true;
      return false;
    }
  }
}

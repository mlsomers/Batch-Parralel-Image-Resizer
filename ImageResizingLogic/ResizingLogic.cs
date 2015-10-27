using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ImageResizingLogic {
  static class ResizingLogic {

    public static readonly System.Drawing.Imaging.ImageFormat[] formats = new System.Drawing.Imaging.ImageFormat[]{
      System.Drawing.Imaging.ImageFormat.Jpeg,
      System.Drawing.Imaging.ImageFormat.Png,
      System.Drawing.Imaging.ImageFormat.Bmp,
      System.Drawing.Imaging.ImageFormat.Tiff,
      System.Drawing.Imaging.ImageFormat.Gif,
      System.Drawing.Imaging.ImageFormat.Wmf,
      System.Drawing.Imaging.ImageFormat.Emf
    };

    public static Bitmap Resize(Bitmap source, int MaxWidth, int MaxHeight, bool cropWidth, bool cropHeight, InterpolationMode mode = InterpolationMode.HighQualityBicubic) {
      AspectRatio srcAspect = new AspectRatio(source.Width, source.Height);
      AspectRatio dstAspect = new AspectRatio(MaxWidth, MaxHeight);
      AspectRatioDiff compare = srcAspect.ComparedTo(dstAspect);
      if(compare == AspectRatioDiff.Same) return Resize(source, MaxWidth, MaxHeight, mode);

      if(compare == AspectRatioDiff.Wider) {
        if(!cropWidth) {
          return Resize(source, MaxWidth, srcAspect.FitWidth(MaxWidth), mode);
        } else {
          Bitmap bmp = Resize(source, srcAspect.FitHeight(MaxHeight), MaxHeight, mode);
          return CropWidth(bmp, MaxWidth);
        }
      }

      // Taller
      if(!cropHeight) {
        return Resize(source, srcAspect.FitHeight(MaxHeight), MaxHeight, mode);
      } else {
        Bitmap bp = Resize(source, MaxWidth, srcAspect.FitWidth(MaxWidth), mode);
        return CropHeight(bp, MaxHeight);
      }
    }

    public static Bitmap Resize(Bitmap source, int newWidth, int newHeight, InterpolationMode mode = InterpolationMode.HighQualityBicubic) {
      Bitmap result = new Bitmap(newWidth, newHeight);
      int start = mode.ToString().ToLowerInvariant().Contains("high") ? 1 : 0;
      using (Graphics g = Graphics.FromImage((Image)result)){
          g.InterpolationMode = mode;
          g.DrawImage(source, -start, -start, newWidth + start, newHeight + start);
      }
      return result;
    }

    private static Bitmap CropWidth(Bitmap source, int MaxWidth) {
      int diff = source.Width - MaxWidth;
      if(diff < 0) return source; // fits, nothing to crop
      int offset = -(int)Math.Round((double)diff / 2d);
      Bitmap result = new Bitmap(MaxWidth, source.Height, source.PixelFormat);
      using(Graphics g = Graphics.FromImage((Image)result)) {
        g.DrawImage(source, offset, 0, source.Width, source.Height);
      }
      return result;
    }

    private static Bitmap CropHeight(Bitmap source, int MaxHeight) {
      int diff = source.Height - MaxHeight;
      if(diff < 0) return source; // fits, nothing to crop
      int offset = -(int)Math.Round((double)diff / 2d);
      Bitmap result = new Bitmap(source.Width, MaxHeight, source.PixelFormat);
      using(Graphics g = Graphics.FromImage((Image)result)) {
        g.DrawImage(source, 0, offset, source.Width, source.Height);
      }
      return result;
    }

    private static void RotateImage(Bitmap bitmap, ConversionSettings job) {
      if(!job.RotateOnExifRotationData) return;
      int idx = Array.IndexOf(bitmap.PropertyIdList, 274);
      if(idx > -1) {
        byte orientation = bitmap.PropertyItems[idx].Value[0];
        switch(orientation) {
          case 1:
            // No rotation required.
            break;
          case 2:
            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
            break;
          case 3:
            bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
            break;
          case 4:
            bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
            break;
          case 5:
            bitmap.RotateFlip(RotateFlipType.Rotate90FlipX);
            break;
          case 6:
            bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
            break;
          case 7:
            bitmap.RotateFlip(RotateFlipType.Rotate270FlipX);
            break;
          case 8:
            bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
            break;
        }
        // This EXIF data is now invalid and should be removed.
        bitmap.RemovePropertyItem(274);
      }
    }
  }
}

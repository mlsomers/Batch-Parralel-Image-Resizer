using System;

namespace ImageResizingLogic {
  public struct AspectRatio {
    public int X;
    public int Y;

    public AspectRatio(int x, int y) {
      X = x;
      Y = y;
    }

    /// <summary>
    /// 1 when x=y, &gt;1 when x&gt;y otherwise &lt;1
    /// </summary>
    public double Ratio {
      get { return (double)X / (double)Y; }
    }

    /// <summary>
    /// Compares this ratio to another and returns if this one is wider, taller or the same
    /// </summary>
    /// <param name="other">Another aspect ratio</param>
    /// <returns>returns true when this is wider than the other ratio, false when it is taller</returns>
    public AspectRatioDiff ComparedTo(AspectRatio other) {
      double aspect = (this.Ratio - other.Ratio);
      if(aspect == 0d) return AspectRatioDiff.Same;
      return (aspect > 0d) ? AspectRatioDiff.Wider : AspectRatioDiff.Taller;
    }

    /// <summary>
    /// Returns the correct height maintaining aspect ratio (shrinking or enlarging)
    /// </summary>
    public int FitWidth(int width) {
      double ratio = (double)this.X / (double)width;
      return (int)Math.Round((double)this.Y / ratio);
    }

    /// <summary>
    /// Returns the correct width maintaining aspect ratio (shrinking or enlarging)
    /// </summary>
    public int FitHeight(int height) {
      double ratio = (double)this.Y / (double)height;
      return (int)Math.Round((double)this.X / ratio);
    }
  }

  [Serializable]
  public enum AspectRatioDiff {
    Wider,
    Taller,
    Same
  }
}

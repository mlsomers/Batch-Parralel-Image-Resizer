using System;
using System.Windows.Forms;
using System.Drawing;
using QueueWorkers;

namespace BatchImageResampler.UI {
  public class QueueGauge:Control {

    public IWorkItemQueue WorkQueue { get; set; }

    /// <summary>
    /// Make public after fully implementing vertical drawing
    /// </summary>
    private Orientation Orientation { get; set; }

    private const int ItemPadding = 3; // 3 pixels between each rectangle

    readonly Brush _emptyBrush = new SolidBrush(Color.FromKnownColor(KnownColor.Black));
    readonly Brush _filledBrush = new SolidBrush(Color.FromKnownColor(KnownColor.Red));
    readonly Brush _usedBrush = new SolidBrush(Color.FromKnownColor(KnownColor.Yellow));

    Pen _borderPen = new Pen(new SolidBrush(Color.FromKnownColor(KnownColor.DarkGray)));

    protected override void OnForeColorChanged(EventArgs e) {
      base.OnForeColorChanged(e);
      _borderPen = new Pen(new SolidBrush(ForeColor));
    }

    protected override void OnSizeChanged(EventArgs e) {
      base.OnSizeChanged(e);
      Invalidate();
    }

    protected override void OnPaintBackground(PaintEventArgs pevent) {
      base.OnPaintBackground(pevent);
      pevent.Graphics.Clear(BackColor);
    }

    protected override void OnPaint(PaintEventArgs e) {
      base.OnPaint(e);

      if(ReferenceEquals(WorkQueue, null)) {
        // create a dummy placeholder
        WorkQueue = new WorkItemQueue<object>(new object[] { new object(), new object(), new object(), new object() }){
            MaxItems = 7
        };
      }

      int max = Max(WorkQueue.MaxItems, WorkQueue.Count, WorkQueue.PerfStatsMaxQueueLength);
      if(max <= 0) max = 1;

      int hx, hy;
      if(Orientation == Orientation.Horizontal) {
        hx = (e.ClipRectangle.Width - Padding.Left) - Padding.Right;
        hy = (e.ClipRectangle.Height - Padding.Top) - Padding.Bottom;
      } else {
        hy = (e.ClipRectangle.Width - Padding.Left) - Padding.Right;
        hx = (e.ClipRectangle.Height - Padding.Top) - Padding.Bottom;
      }

      int len = (hx / max);
      int padding = ItemPadding;
      while(len < 3 * padding && padding > 0) {
        padding = padding-1;
      }
      if(padding <= 1) { DrawProgress(hx,hy,e); return; }
      len = len - padding;
      if(len <= 1) { DrawProgress(hx, hy,e); return; }

      int pos = (Orientation == Orientation.Horizontal) ? Padding.Left : Padding.Right;

      if(Orientation == Orientation.Horizontal) {
        Brush rectPen;
        for(int t = 0; t < max; t++) {
          if(t < WorkQueue.Count) rectPen = _filledBrush;
          else if(t < WorkQueue.PerfStatsMaxQueueLength) rectPen = _usedBrush;
          else rectPen = _emptyBrush;
          if(len > 3) e.Graphics.DrawRectangle(_borderPen, pos, Padding.Top, len, hy);
          e.Graphics.FillRectangle(rectPen, pos+1, Padding.Top+1, len-1, hy-1);
          pos = pos + len + padding;
        }
        if(len <= 3) {
          e.Graphics.DrawRectangle(_borderPen, Padding.Left, Padding.Top, (pos - padding) - Padding.Left, hy);
        }
      } else {
        // ToDo: add Vertical support
      }
    }

    private int Max(params int[] items) {
      int max = items[0];
      for(int t = items.Length - 1; t >= 0; t--) {
        if(max < items[t]) max = items[t];
      }
      return max;
    }

    /// <summary>
    /// When the Gauge becomes too compressed, we switch over to a ProgressBar-like view
    /// </summary>
    private void DrawProgress(int hx, int hy, PaintEventArgs e) {
      int max = Max(WorkQueue.MaxItems, WorkQueue.Count, WorkQueue.PerfStatsMaxQueueLength);
      hx -= 2; // extra border
      int wFilled = (hx * WorkQueue.Count) / max;
      if(wFilled < 0) wFilled = 0;
      int wUsed = ((hx * WorkQueue.PerfStatsMaxQueueLength) / max) - wFilled;
      int wmax = (hx - wUsed) - wFilled;

      int l = Padding.Left + 1;
      int t = Padding.Top + 1;
      int y = hy - 1;

      if(Orientation == Orientation.Horizontal) {
        e.Graphics.DrawRectangle(_borderPen, Padding.Left, Padding.Top, hx + 1, hy);
        e.Graphics.FillRectangle(_filledBrush, l, t, wFilled, y);
        if(wUsed>0) e.Graphics.FillRectangle(_usedBrush, l + wFilled, t, wUsed, y);
        if(wmax>0) e.Graphics.FillRectangle(_emptyBrush, l + wFilled + wUsed, t, wmax, y);
      } else {
        // ToDo: add vertical support
      }
    }

    internal void PaintDiff() {
      //Rectangle rc=new Rectangle();
      //Invalidate(rc);
      Invalidate();
    }
  }

  public enum Orientation {
    Horizontal=0,
    Vertical=1
  }
}

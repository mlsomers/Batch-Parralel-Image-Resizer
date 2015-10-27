using System;
using System.Globalization;
using System.Windows.Forms;
using QueueWorkers;

namespace BatchImageResampler.UI {
  public partial class ThreadStats : UserControl {
    public ThreadStats() {
      InitializeComponent();
    }

    private IWorkItemQueue _queue;

    public IWorkItemQueue Queue {
      get { return _queue; }
      set {
        _queue = value;
        if (ReferenceEquals(value, null)) return;
        queueGauge1.WorkQueue = value;
        if(maxItemsInQueue.Maximum < value.MaxItems) maxItemsInQueue.Maximum = value.MaxItems;
        maxItemsInQueue.Value = value.MaxItems;
        UpdateStats();
      }
    }

    public void UpdateStats() {
      queueGauge1.PaintDiff();
      if(ReferenceEquals(queueGauge1.WorkQueue, null)) return;
      labelCurrentQueueLength.Text = queueGauge1.WorkQueue.Count.ToString(CultureInfo.InvariantCulture);
      labelHighWaterMark.Text = queueGauge1.WorkQueue.PerfStatsMaxQueueLength.ToString(CultureInfo.InvariantCulture);
      if(ReferenceEquals(_queue, null)) return;
      btnPause.Enabled = _queue.PauseQueue;
    }

    private void maxItemsInQueue_ValueChanged(object sender, EventArgs e) {
      if(ReferenceEquals(queueGauge1.WorkQueue, null)) return;
      queueGauge1.WorkQueue.MaxItems = (int)maxItemsInQueue.Value;
      queueGauge1.Invalidate();
      OnThreadsAssignedChanged();
    }

    public string Caption {
      get { return caption.Text; }
      set { caption.Text = value; }
    }

    public bool ThreadsReadOnly {
      get {
        return threadsAssigned.ReadOnly;
      }
      set {
        threadsAssigned.ReadOnly = value;
        threadsAssigned.Enabled = !value;
      }
    }

    public int ThreadsAssigned {
      get { return (int)threadsAssigned.Value; }
      set { threadsAssigned.Value = value; }
    }

    public bool MaxQueueLengthReadOnly {
      get { return maxItemsInQueue.ReadOnly; }
      set { 
        maxItemsInQueue.ReadOnly = value;
        maxItemsInQueue.Enabled = !value;
      }
    }

    public class ThreadsAssignedEventArgs : EventArgs {
      public ThreadsAssignedEventArgs(int newValue) : base() {
        NewValue = newValue;
      }
      public int NewValue { get; set; }
    }

    public delegate void ThreadsAssignedDelegate(object sender, ThreadsAssignedEventArgs e);
    public event ThreadsAssignedDelegate ThreadsAssignedChanged;

    protected virtual void OnThreadsAssignedChanged(){
      if(!ReferenceEquals(ThreadsAssignedChanged,null)){
        ThreadsAssignedChanged(this,new ThreadsAssignedEventArgs((int)threadsAssigned.Value));
      }
    }

    private void threadsAssigned_ValueChanged(object sender, EventArgs e) {
      OnThreadsAssignedChanged();
    }
  }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace QueueWorkers {
  public class QueueJob<T> {
    public QueueJob(WorkItemQueue<T> queue)
      : base() {
      Queue = queue;
    }
    public QueueJob()
      : base() {
      Queue = new WorkItemQueue<T>();
    }
    public QueueJob(int capacity)
      : base() {
      Queue = new WorkItemQueue<T>(capacity);
    }
    public QueueJob(IEnumerable<T> collection)
      : base() {
      Queue = new WorkItemQueue<T>(collection);
    }

    public readonly WorkItemQueue<T> Queue;

    private WorkItemQueue<T> _DestinationQueue;
    /// <summary>
    /// The queue in wich to place processed WorkItems
    /// </summary>
    public WorkItemQueue<T> DestinationQueue {
      get { return _DestinationQueue; }
      set { _DestinationQueue = value; }
    }

    public event WorkItemDelegate<T> WorkDone;
    internal protected virtual void OnWorkDone(T workItem) {
      if(!ReferenceEquals(WorkDone, null)) WorkDone(workItem);
      if(!ReferenceEquals(_DestinationQueue, null)) _DestinationQueue.EnqueueWorkItem(workItem);
    }

    public event WorkItemDelegate<T> DoWork;
    internal protected virtual void OnDoWork(T workItem) {
      if(!ReferenceEquals(DoWork, null)) DoWork(workItem);
    }
  }
}

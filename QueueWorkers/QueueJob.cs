using System.Collections.Generic;

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

    private WorkItemQueue<T> _destinationQueue;
    /// <summary>
    /// The queue in wich to place processed WorkItems
    /// </summary>
    public WorkItemQueue<T> DestinationQueue {
      get { return _destinationQueue; }
      set { _destinationQueue = value; }
    }

    public event WorkItemDelegate<T> WorkDone;
    internal protected virtual void OnWorkDone(T workItem) {
      if(!ReferenceEquals(WorkDone, null)) WorkDone(workItem);
      if(!ReferenceEquals(_destinationQueue, null)) _destinationQueue.EnqueueWorkItem(workItem);
    }

    public event WorkItemDelegate<T> DoWork;
    internal protected virtual void OnDoWork(T workItem) {
      if(!ReferenceEquals(DoWork, null)) DoWork(workItem);
    }
  }
}

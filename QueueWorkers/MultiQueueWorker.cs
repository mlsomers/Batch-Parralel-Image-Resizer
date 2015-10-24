using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace QueueWorkers {
  /// <summary>
  /// This worker is used when there are several steps in a process that use the same resource, where multiple threads would not be beneficial (such as disk I/O)
  /// </summary>
  public class MultiQueueWorker<T> : List<QueueJob<T>> {

    public MultiQueueWorker() : base() { }
    public MultiQueueWorker(int capacity) : base(capacity) { }
    public MultiQueueWorker(IEnumerable<QueueJob<T>> collection) : base(collection) { }

    private List<QueueJob<T>> _FinishedWorkItemQueues = new List<QueueJob<T>>();
    /// <summary>
    /// List of WorkItem Queues that are finished processing
    /// </summary>
    public List<QueueJob<T>> FinishedWorkItemQueues {
      get { return _FinishedWorkItemQueues; }
    }

    private bool _Prioritize;
    /// <summary>
    /// If true, the last queue will have the highest priority, then the one before etc.. If false, all queues will get equal turns to run
    /// </summary>
    public bool Prioritize {
      get { return _Prioritize; }
      set { _Prioritize = value; }
    }

    private Thread workerThread;
    private bool shouldStop;
    private static readonly T stopObject = default(T);

    protected void WorkerLoop() {
      while(!shouldStop) {
        bool idle = true;
        for(int t = Count - 1; t >= 0; t--) {
          WorkItemQueue<T> queue = this[t].Queue;
          if(queue.Count > 0) {
            idle = false;
            T workItem = queue.DequeueWorkItem();
            if(workItem.Equals(stopObject)) {
              _FinishedWorkItemQueues.Add(this[t]);
              RemoveAt(t);
            } else {
              this[t].OnDoWork(workItem);
              this[t].OnWorkDone(workItem);
              if(_Prioritize) break;
            }
          }
        }
        if(idle && Count > 0) {
          Thread.Sleep(this[0].Queue.SleepSpan);
        }
      }
    }

    /// <summary>
    /// Start working using a single thread
    /// </summary>
    public void Start() {
      if(!ReferenceEquals(workerThread, null)) throw new InvalidOperationException("The MultiQueueWorker is already running");
      workerThread = new Thread(WorkerLoop);
      shouldStop = false;
      workerThread.Start();
    }

    /// <summary>
    /// Gracefully stop in a resumable manner (stopping the thread after finishing a task)
    /// </summary>
    public void Stop() {
      if(ReferenceEquals(workerThread, null)) return;
      shouldStop = true;
      for(int t = Count - 1; t >= 0; t--) {
        this[t].Queue.Stop = true;
      };
      workerThread.Join();
      workerThread = null;
      for(int t = Count - 1; t >= 0; t--) {
        this[t].Queue.Stop = false;
      };
    }

    /// <summary>
    /// Pause or depause processing the queues (whlie keeping threads alive)
    /// </summary>
    public bool Pause {
      get {
        if(Count <= 0) return false;
        return this[0].Queue.PauseQueue;
      }
      set {
        for(int t = Count - 1; t >= 0; t--) {
          this[t].Queue.PauseQueue = value;
        };
      }
    }

  }
}

using System;
using System.Collections.Generic;
using System.Threading;

namespace QueueWorkers {
  /// <summary>
  /// This worker is used when there are several steps in a process that use the same resource, where multiple threads would not be beneficial (such as disk I/O)
  /// </summary>
  public class MultiQueueWorker<T> : List<QueueJob<T>> {

    public MultiQueueWorker() : base() { }
    public MultiQueueWorker(int capacity) : base(capacity) { }
    public MultiQueueWorker(IEnumerable<QueueJob<T>> collection) : base(collection) { }

    private readonly List<QueueJob<T>> _finishedWorkItemQueues = new List<QueueJob<T>>();
    /// <summary>
    /// List of WorkItem Queues that are finished processing
    /// </summary>
    public List<QueueJob<T>> FinishedWorkItemQueues {
      get { return _finishedWorkItemQueues; }
    }

    private bool _prioritize;
    /// <summary>
    /// If true, the last queue will have the highest priority, then the one before etc.. If false, all queues will get equal turns to run
    /// </summary>
    public bool Prioritize {
      get { return _prioritize; }
      set { _prioritize = value; }
    }

    private Thread _workerThread;
    private bool _shouldStop;
    private static readonly T StopObject = default(T);
    private bool idle = true;

    public bool Idle {
      get { return idle; }
    }

    protected void WorkerLoop() {
      while(!_shouldStop) {
        idle = this[this.Count - 1].Queue.Count <= 0; // works for the last
        for(int t = Count - 1; t >= 0; t--) {
          WorkItemQueue<T> queue = this[t].Queue;
          if(queue.Count > 0) {
            idle = false;
            T workItem = queue.DequeueWorkItem();
            if(workItem.Equals(StopObject)) {
              _finishedWorkItemQueues.Add(this[t]);
              RemoveAt(t);
            } else {
              this[t].OnDoWork(workItem);
              this[t].OnWorkDone(workItem);
              if(_prioritize) break;
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
      if(!ReferenceEquals(_workerThread, null)) throw new InvalidOperationException("The MultiQueueWorker is already running");
      _workerThread = new Thread(WorkerLoop);
      _shouldStop = false;
      _workerThread.Start();
    }

    /// <summary>
    /// Gracefully stop in a resumable manner (stopping the thread after finishing a task)
    /// </summary>
    public void Stop() {
      if(ReferenceEquals(_workerThread, null)) return;
      _shouldStop = true;
      for(int t = Count - 1; t >= 0; t--) {
        this[t].Queue.Stop = true;
      }
      _workerThread.Join();
      _workerThread = null;
      for(int t = Count - 1; t >= 0; t--) {
        this[t].Queue.Stop = false;
      }
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
        }
      }
    }

  }
}

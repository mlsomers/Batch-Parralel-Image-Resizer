using System.Collections.Generic;
using System.Threading;

namespace QueueWorkers {
  public class WorkItemQueue<T> : Queue<T>, IWorkItemQueue {

    public WorkItemQueue(WorkItemQueue<T> queue) : base(queue) { }
    public WorkItemQueue() : base() { }
    public WorkItemQueue(int capacity) : base(capacity) {
      maxItems = capacity;
    }
    public WorkItemQueue(IEnumerable<T> collection) : base(collection) {
      maxItems = Count;
      maxQueueLength = maxItems;
    }

    /// <summary>
    /// Use this to lock the queue for a single thread
    /// </summary>
    public object SyncRoot = new object();

    // ****  Static properties  ****

    private static bool pause;
    /// <summary>
    /// When true, will will put to sleep any thread trying to add or retreive a workitem
    /// </summary>
    public static bool Pause {
      get { return pause; }
      set { pause = value; }
    }

    private bool pauseQueue;
    /// <summary>
    /// When true, will put to sleep any thread trying to add or retreive a workitem
    /// </summary>
    public bool PauseQueue {
      get { return pauseQueue; }
      set { pauseQueue = value; }
    }

    private static bool abort;
    /// <summary>
    /// Check if Abort has been called.
    /// </summary>
    public static bool Abort {
      get { return abort; }
    }

    private bool stop;
    /// <summary>
    /// Stop work by exiting threads but preserve workitems (only on dequeue in order to preserve all work)
    /// </summary>
    public bool Stop {
      get { return stop; }
      set { stop = value; }
    }

    /// <summary>
    /// When this is called, all workitems in all WorkItemQueues get thrown away and any thread that tries to add or remove an item will return void
    /// </summary>
    public static void AbortAllWork() {
      abort = true;
    }

    // ****  Instance properties  ****

    private int maxItems = 20;
    /// <summary>
    /// The maximum number of items allowed in the queue (to prevent memory issues)
    /// </summary>
    public int MaxItems {
      get { return maxItems; }
      set { maxItems = value; }
    }

    private int sleepSpan = 1;
    /// <summary>
    /// The number of millisecconds a thread will sleep when waiting
    /// </summary>
    public int SleepSpan {
      get { return sleepSpan; }
      set { sleepSpan = value; }
    }

    // **** Performance statistics ****

    private int maxQueueLength;
    private int dequeuedItems;
    private int idleThreads;

    /// <summary>
    /// Returns the maximum number of workitems in the queue reached during its lifespan
    /// </summary>
    public int PerfStatsMaxQueueLength {
      get { return maxQueueLength; }
    }

    public int PerfStatsProcessedItems {
        get { return dequeuedItems; }
    }

    public int IdleThreads {
      get { return idleThreads; }
    }

    // ****  Methods  ****

    /// <summary>
    /// Adds a workitem to the queue respecting the MaxItems limit, if the limit is reached this method will block untill there is room or AbortAllWork is called.
    /// </summary>
    /// <param name="item">Work Item</param>
    /// <returns>False if all operations should abort</returns>
    /// <remarks>Unfortunately the Enqueue method is not virtual, I personally rather add a new method than using the tricky "new" keyword.</remarks>
    public bool EnqueueWorkItem(T item) {
      while(!abort && (pause || pauseQueue || Count >= maxItems)) Thread.Sleep(sleepSpan);
      lock(SyncRoot) {
        if(abort) {
          Clear();
          return false;
        }
        Enqueue(item);
        if(maxQueueLength < maxItems) {
          int count = Count;
          if(count > maxQueueLength) maxQueueLength = count;
        }
      }
      return true;
    }

    /// <summary>
    /// Waits for an item to become available (if needed) and returns a workitem. Be sure to check for Null or default(T) (when AbortAllWork has been called).
    /// </summary>
    /// <returns>A workitem or default(T) when AbortAllWork was called.</returns>
    /// <remarks>Unfortunately the Dequeue method is not virtual, I personally rather add a new method than using the tricky "new" keyword.</remarks>
    public T DequeueWorkItem() {
      while(!abort && !stop) {
        idleThreads++;
        while((!abort && !stop) && (pause || pauseQueue || Count <= 0)) Thread.Sleep(sleepSpan);
        lock(SyncRoot) {
          idleThreads--;
          if(abort || stop) return default(T);
          if(Count <= 0) continue; // race condition
          dequeuedItems++;
          return Dequeue();
        }
      }
      return default(T);
    }

  }
}
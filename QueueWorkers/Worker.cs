using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace QueueWorkers {
  public class Worker<T> : QueueJob<T> {

    public Worker() : base() { }
    public Worker(int capacity) : base(capacity) { }
    public Worker(IEnumerable<T> collection) : base(collection) { }

    /// <summary>
    /// Threads responsible for processing a certain job
    /// </summary>
    protected readonly List<Thread> ProcessingThreads=new List<Thread>();
    private readonly object ProcessingThreadsLock = new object();
    private readonly T stopObject = default(T);
    private readonly object ChangeThreadCountLock = new object();
    private int threadCount;

    /// <summary>
    /// Pause or depause processing the queue
    /// </summary>
    public bool Pause {
      get { return Queue.PauseQueue; }
      set { Queue.PauseQueue = value; }
    }

    protected void WorkerLoop() {
      while(threadCount >= ProcessingThreads.Count) {
        T workItem = Queue.DequeueWorkItem();
        while(!ReferenceEquals(workItem, null) && !workItem.Equals(stopObject)) {
          OnDoWork(workItem);
          OnWorkDone(workItem);
          workItem = Queue.DequeueWorkItem();
        }
      }
      lock(ProcessingThreadsLock) {
        ProcessingThreads.Remove(Thread.CurrentThread);
      }
    }

    /// <summary>
    /// Start working using a single thread
    /// </summary>
    public void Start() {
      Start(1);
    }

    /// <summary>
    /// Gracefully stop in a resumable manner
    /// </summary>
    public void Stop() {
      Start(0);
    }

    public void Start(int threadCount) {
      lock(ChangeThreadCountLock) {
        this.threadCount = threadCount;
        if(ProcessingThreads.Count == 0) { // First call
          AddWorkers(threadCount);
        } else if(ProcessingThreads.Count > threadCount) { // subsequent call to reduce threads
          Queue.Stop = true;
          while(ProcessingThreads.Count > threadCount) Thread.Sleep(0);
          Queue.Stop = false;
          Thread.Sleep(0);// Note that too many threads might have exited at this point, sleep extra to get an up-to-date reading of count
        }
        if(ProcessingThreads.Count < threadCount) { // subsequent call to increase threads (or when decreasing caused too many threads to exit)
          AddWorkers(threadCount - ProcessingThreads.Count);
        }
      }
    }

    private void AddWorkers(int count) {
      Thread[] newWorkers = new Thread[count];
      for(int t = count - 1; t >= 0; t--) {
        newWorkers[t] = new Thread(WorkerLoop);
        newWorkers[t].Start();
      }
      lock(ProcessingThreadsLock) {
        ProcessingThreads.AddRange(newWorkers);
      }
    }

    
  }
}

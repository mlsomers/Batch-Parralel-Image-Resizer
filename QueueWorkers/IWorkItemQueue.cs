using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace QueueWorkers {
  public interface IWorkItemQueue: ICollection {
    /// <summary>
    /// When true, will put to sleep any thread trying to add or retreive a workitem
    /// </summary>
    bool PauseQueue { get; set; }
    
    /// <summary>
    /// Stop work by exiting threads but preserve workitems (only on dequeue in order to preserve all work)
    /// </summary>
    bool Stop { get; set; }

    /// <summary>
    /// The maximum number of items allowed in the queue (to prevent memory issues)
    /// </summary>
    int MaxItems { get; set; }

    /// <summary>
    /// The number of millisecconds a thread will sleep when waiting
    /// </summary>
    int SleepSpan { get; set; }

    /// <summary>
    /// Returns the maximum number of workitems in the queue reached during its lifespan
    /// </summary>
    int PerfStatsMaxQueueLength { get; }

  }
}

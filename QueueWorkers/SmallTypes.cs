using System;
using System.Collections.Generic;
using System.Text;

namespace QueueWorkers {
  public delegate void WorkItemDelegate<T>(T workItem);
}

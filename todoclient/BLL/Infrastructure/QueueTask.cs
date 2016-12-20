using BLL.Interfaces;
using System;
using System.Collections.Generic;

namespace BLL.Infrastructure
{
    public class QueueTasks
    {
        private Queue<ITaskAction> Queue { get; set; }

        public static QueueTasks Instance { get; }

        private QueueTasks()
        {
            Queue = new Queue<ITaskAction>();
        }

        static QueueTasks()
        {
            Instance = new QueueTasks();
        }

        public void Enqueue(ITaskAction action)
        {
            Queue.Enqueue(action);
        }

        public ITaskAction Dequeue()
        {
            return Queue.Dequeue();
        }

        public bool IsEmpty()
        {
            return Queue.Count == 0;
        }
    }
}

using BLL.Interfaces;
using System.Threading;

namespace BLL.Infrastructure
{
    public class Worker
    {
        private static QueueTasks Queue { get; set; }

        private static readonly ReaderWriterLockSlim lockSlim = new ReaderWriterLockSlim();

        public static Worker Instance { get; }

        private Worker()
        {
            Queue = QueueTasks.Instance;
        }

        static Worker()
        {
            Instance = new Worker();
        }

        public static void AddWork(ITaskAction action) => Queue.Enqueue(action);

        public void Run()
        {
            while (true)
            {
                lockSlim.EnterWriteLock();
                try
                {
                    if (!Queue.IsEmpty())
                    {
                        var task = Queue.Dequeue();
                        task.Execute();
                    }
                }
                finally
                {
                    lockSlim.ExitWriteLock();
                }
            }
        }
    }
}

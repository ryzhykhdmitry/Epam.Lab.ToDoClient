using System.Collections.Generic;
using BLL.Interfaces;
using System.Threading;

namespace BLL.Infrastructure
{
    public class Worker
    {
        private static Queue<ITaskAction> queue;

        private static ReaderWriterLockSlim lockSlim;

        public static Worker Instance { get; }

        private Worker()
        {
            queue = new Queue<ITaskAction>();
            lockSlim = new ReaderWriterLockSlim();
        }

        static Worker()
        {
            Instance = new Worker();
        }

        public static void AddWork(ITaskAction action)
        {
            lockSlim.EnterWriteLock();
            try
            {
                queue.Enqueue(action);
            }
            finally
            {
                lockSlim.ExitWriteLock();
            }
        }

        public void Run()
        {
            while (true)
            {
                if (queue.Count == 0) continue;

                ITaskAction task;

                lockSlim.EnterWriteLock();
                try
                {
                    task = queue.Dequeue();
                }
                finally
                {
                    lockSlim.ExitWriteLock();
                }

                task?.Execute();
            }
        }
    }
}

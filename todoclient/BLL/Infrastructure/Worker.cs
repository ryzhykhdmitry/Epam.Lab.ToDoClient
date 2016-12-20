using System.Collections.Generic;
using System.Net.Http;
using BLL.Interfaces;
using System.Threading;

namespace BLL.Infrastructure
{
    public class Worker
    {
        private readonly Queue<ITaskAction> queue;
        private readonly ReaderWriterLockSlim lockSlim;
        
        public Worker()
        {
            queue = new Queue<ITaskAction>();
            lockSlim = new ReaderWriterLockSlim();
        }

        public void AddWork(ITaskAction action)
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

                try
                {
                    task?.Execute();
                }
                catch (HttpRequestException)
                {
                }
            }
        }
    }
}

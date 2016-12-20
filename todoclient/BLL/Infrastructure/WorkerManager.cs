using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Actions;
using BLL.Interfaces;
using BLL.Interfaces.DTO;
using BLL.Interfaces.Repository;

namespace BLL.Infrastructure
{
    public class WorkerManager
    {
        private static readonly Dictionary<int, Worker> workers;

        static WorkerManager()
        {
            workers = new Dictionary<int, Worker>();
        }

        public static void AddWork(ITaskAction taskAction, int userId)
        {
            if (workers.ContainsKey(userId))
            {
                workers[userId].AddWork(taskAction);
            }
            else
            {
                var worker = new Worker();

                worker.AddWork(taskAction);

                Task.Run(() => worker.Run());

                workers.Add(userId, worker);
            }
        }

        public static void ActionsInitialize(IActionRepository actionRepository, ITaskRepository repository)
        {
            var result = actionRepository.GetAll();

            if (result != null && result.Count() != 0)
            {
                foreach (var bllAction in result)
                {
                    BllTask task = repository.GetById(bllAction.TaskId);

                    switch ((BllActionEnum)bllAction.ActionId)
                    {
                        case BllActionEnum.Add:
                            AddWork(new AddTask(task, repository, bllAction.Id, actionRepository), task.UserId);
                            break;

                        case BllActionEnum.Delete:
                            AddWork(new DeleteTask(task.Id, repository, bllAction.Id, actionRepository), task.UserId);
                            break;

                        case BllActionEnum.Update:
                            AddWork(new UpdateTask(task.Id, repository, bllAction.Id, actionRepository), task.UserId);
                            break;

                        default:
                            throw new InvalidEnumArgumentException();
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Actions;
using BLL.Interfaces.DTO;
using BLL.Interfaces.Repository;
using BLL.Mappers;

namespace BLL.Infrastructure
{
    public static class WorkerInitializer
    {
        public static void Initialize()
        {
            Task.Run(() => Worker.Instance.Run());
        }

        public static void ActionsInitialize(IActionRepository actionRepository, ITaskRepository repository)
        {
            var result = actionRepository.GetAll();

            if (result != null && result.Count() != 0)
            {
                foreach (var bllAction in result)
                {
                    switch ((BllActionEnum)bllAction.ActionId)
                    {
                        case BllActionEnum.Add:
                            Worker.AddWork(new AddTask(repository.GetById(bllAction.TaskId), repository, bllAction.Id, actionRepository));
                            break;

                        case BllActionEnum.Delete:
                            Worker.AddWork(new DeleteTask(bllAction.TaskId, repository, bllAction.Id, actionRepository));
                            break;

                        case BllActionEnum.Update:
                            Worker.AddWork(new UpdateTask(bllAction.TaskId, repository, bllAction.Id, actionRepository));
                            break;

                        default:
                            throw new InvalidEnumArgumentException();
                    }
                }
            }
        }
    }
}

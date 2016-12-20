using System;
using System.Collections.Generic;
using BLL.Interfaces;
using BLL.Interfaces.DTO;
using BLL.Interfaces.Repository;
using BLL.Services;
using System.Linq;

namespace BLL.Actions
{
    public class AddTask : ITaskAction
    {
        private readonly BllTask item;
        private readonly ITaskRepository repository;
        private readonly int actionId;
        private readonly IActionRepository actionRepository;

        public AddTask(BllTask item, ITaskRepository repository, int actionId, IActionRepository actionRepository)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (actionRepository == null) throw new ArgumentNullException(nameof(actionRepository));

            this.item = item;
            this.repository = repository;
            this.actionId = actionId;
            this.actionRepository = actionRepository;
        }

        public void Execute()
        {
            ToDoService.CreateItem(item);
            IList<BllTask> result = ToDoService.GetItems(item.UserId);

            BllTask task = repository.GetById(item.Id);

            task.ToDoId = result.LastOrDefault()?.ToDoId;
            
            repository.Update(task);
            actionRepository.Delete(actionId);
        }
    }
}

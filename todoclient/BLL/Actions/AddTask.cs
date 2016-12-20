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

        public AddTask(BllTask item, ITaskRepository repository)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (repository == null) throw new ArgumentNullException(nameof(repository));

            this.item = item;
            this.repository = repository;
        }

        public void Execute()
        {
            ToDoService.CreateItem(item);
            IList<BllTask> result = ToDoService.GetItems(item.UserId);

            BllTask task = repository.GetById(item.Id);

            task.ToDoId = result.LastOrDefault()?.ToDoId;
            
            repository.Update(task);
        }
    }
}

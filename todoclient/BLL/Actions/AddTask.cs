using System;
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
            var result = ToDoService.GetItems(item.UserId);

            item.ToDoId = result.LastOrDefault()?.ToDoId;

            repository.Update(item);
        }
    }
}

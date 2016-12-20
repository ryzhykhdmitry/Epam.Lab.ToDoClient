using System;
using BLL.Interfaces;
using BLL.Interfaces.DTO;
using BLL.Interfaces.Repository;
using BLL.Services;

namespace BLL.Actions
{
    public class DeleteTask : ITaskAction
    {
        private readonly BllTask item;
        private readonly ITaskRepository repository;

        public DeleteTask(BllTask item, ITaskRepository repository)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (repository == null) throw new ArgumentNullException(nameof(repository));

            this.item = item;
            this.repository = repository;
        }

        public void Execute()
        {
            var result = repository.GetById(item.Id);

            ToDoService.DeleteItem(result.ToDoId ?? 0);

            repository.Delete(result.Id);
        }
    }
}

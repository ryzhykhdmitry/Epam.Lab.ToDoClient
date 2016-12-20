using System;
using BLL.Interfaces;
using BLL.Interfaces.DTO;
using BLL.Interfaces.Repository;
using BLL.Services;

namespace BLL.Actions
{
    public class DeleteTask : ITaskAction
    {
        private readonly int itemId;
        private readonly ITaskRepository repository;
        private readonly int actionId;
        private readonly IActionRepository actionRepository;

        public DeleteTask(int itemId, ITaskRepository repository, int actionId, IActionRepository actionRepository)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (actionRepository == null) throw new ArgumentNullException(nameof(actionRepository));

            this.itemId = itemId;
            this.repository = repository;
            this.actionId = actionId;
            this.actionRepository = actionRepository;
        }

        public void Execute()
        {
            BllTask result = repository.GetById(itemId);

            ToDoService.DeleteItem(result.ToDoId ?? 0);

            repository.Delete(result.Id);

            actionRepository.Delete(actionId);
        }
    }
}

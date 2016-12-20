using System;
using BLL.Interfaces;
using BLL.Interfaces.DTO;
using BLL.Interfaces.Repository;
using BLL.Services;

namespace BLL.Actions
{
    public class UpdateTask : ITaskAction
    {
        private readonly int itemId;
        private readonly ITaskRepository repository;
        private readonly int actionId;
        private readonly IActionRepository actionRepository;

        public UpdateTask(int itemId, ITaskRepository repository, int actionId, IActionRepository actionRepository)
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
            
            ToDoService.UpdateItem(result);

            actionRepository.Delete(actionId);
        }
    }
}

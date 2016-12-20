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

        public UpdateTask(int itemId, ITaskRepository repository)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));

            this.itemId = itemId;
            this.repository = repository;
        }

        public void Execute()
        {
            BllTask result = repository.GetById(itemId);
            
            ToDoService.UpdateItem(result);
        }
    }
}

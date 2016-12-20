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

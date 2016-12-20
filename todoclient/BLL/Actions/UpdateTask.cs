using BLL.Interfaces;
using BLL.Interfaces.DTO;
using BLL.Interfaces.Repository;
using BLL.Services;

namespace BLL.Actions
{
    public class UpdateTask : ITaskAction
    {
        private readonly BllTask item;
        private readonly ITaskRepository repository;

        public UpdateTask(BllTask item, ITaskRepository repository)
        {
            this.item = item;
            this.repository = repository;
        }

        public void Execute()
        {
            ToDoService.UpdateItem(item);
        }
    }
}

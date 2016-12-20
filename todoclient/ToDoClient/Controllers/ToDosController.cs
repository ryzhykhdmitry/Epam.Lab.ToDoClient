using BLL.Interfaces;
using BLL.Interfaces.DTO;
using BLL.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BLL.Concrete;
using BLL.Interfaces.Repository;
using todoclient.Infrastructure.Mappers;
using todoclient.Models;
using ToDoClient.Services;

namespace ToDoClient.Controllers
{
    /// <summary>
    /// Processes todo requests.
    /// </summary>
    public class ToDosController : ApiController
    {
        private static readonly ITaskRepository taskRepo = new TaskRepository();
        private static readonly IActionRepository actionRepository = new ActionRepository();

        private readonly IService<BllTask> todoService = new Service(taskRepo, actionRepository);
        private readonly UserService userService = new UserService();

        /// <summary>
        /// Returns all todo-items for the current user.
        /// </summary>
        /// <returns>The list of todo-items.</returns>
        public IList<TaskViewModel> Get()
        {
            var userId = userService.GetOrCreateUser();
            return todoService.GetByUserId(userId).Select(t => t.GetTaskViewEntity()).ToList();
        }

        /// <summary>
        /// Updates the existing todo-item.
        /// </summary>
        /// <param name="todo">The todo-item to update.</param>
        public void Put(TaskViewModel todo)
        {
            if (todo == null)
                return;

            todo.UserId = userService.GetOrCreateUser();
            todoService.Update(todo.GetBllEntity());
        }

        /// <summary>
        /// Deletes the specified todo-item.
        /// </summary>
        /// <param name="id">The todo item identifier.</param>
        public void Delete(int id)
        {
            todoService.Delete(id);
        }

        /// <summary>
        /// Creates a new todo-item.
        /// </summary>
        /// <param name="todo">The todo-item to create.</param>
        public TaskViewModel Post(TaskViewModel todo)
        {
            todo.UserId = userService.GetOrCreateUser();
            return todoService.Add(todo.GetBllEntity()).GetTaskViewEntity();
        }
    }
}

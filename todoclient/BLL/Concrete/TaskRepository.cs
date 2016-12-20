using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BLL.Interfaces.DTO;
using BLL.Interfaces.Repository;
using BLL.Mappers;
using ORM;

namespace BLL.Concrete
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DbContext context;

        public TaskRepository()
        {
            context = new ToDoClientModel();
        }

        public TaskRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }
            context = dbContext;
        }

        public BllTask Create(BllTask e)
        {
            if (e == null) throw new ArgumentNullException(nameof(e));

            var result = context.Set<Task>().Add(e.GetOrmEntity());
            context.SaveChanges();

            return result.GetBllEntity();
        }

        public void Delete(int id)
        {
            var task = context.Set<Task>().FirstOrDefault(a => a.Id == id);

            if (task != null)
            {
                context.Set<Task>().Remove(task);
            }

            context.SaveChanges();
        }

        public IEnumerable<BllTask> GetAll()
        {
            var task = context.Set<Task>().ToList();

            return task.Select(u => u.GetBllEntity());
        }

        public IEnumerable<BllTask> GetAllByUserId(int id)
        {
            var tasks = context.Set<Task>().Where(a => a.UserId == id);

            return tasks.AsEnumerable().Select(u => u.GetBllEntity());
        }

        public BllTask GetById(int key)
        {
            var task = context.Set<Task>().FirstOrDefault(a => a.Id == key);

            return task?.GetBllEntity();
        }

        public BllTask Update(BllTask entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            var task = context.Set<Task>().FirstOrDefault(a => a.Id == entity.Id);

            if (task == null)
                return null;

            context.Set<Task>().Attach(task);

            if (entity.ToDoId != null) task.ToDoId = entity.ToDoId;
            task.IsCompleted = entity.IsCompleted;
            if (entity.Name != null) task.Name = entity.Name;
            task.IsDeleted = entity.IsDeleted;
            
            context.SaveChanges();

            return task.GetBllEntity();
        }
    }
}

using BLL.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.DTO;
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
                throw new ArgumentNullException("entitiesContext");
            }
            this.context = dbContext;
        }

        public void Create(BllTask e)
        {
            context.Set<ORM.Task>().Add(e.GetORMEntity());
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var article = context.Set<ORM.Task>().Where(a => a.Id == id).FirstOrDefault();
            if (article != null)
            {
                context.Set<ORM.Task>().Remove(article);
            }
            context.SaveChanges();
        }

        public IEnumerable<BllTask> GetAll()
        {
            var task = context.Set<ORM.Task>().ToList();
            return task.Select(u => u.GetBllEntity());
        }

        public IEnumerable<BllTask> GetAllByUserId(int id)
        {
            var tasks = context.Set<ORM.Task>().Where(a => a.UserId == id);
            return tasks.AsEnumerable().Select(u => u.GetBllEntity());
        }

        public BllTask GetById(int key)
        {
            var task = context.Set<ORM.Task>().Where(a => a.Id == key).FirstOrDefault();
            if (task == null)
            {
                return null;
            }
            return task.GetBllEntity();
        }

        public void Update(BllTask entity)
        {
            var task = context.Set<ORM.Task>().Where(a => a.Id == entity.Id).FirstOrDefault();

            context.Set<ORM.Task>().Attach(task);
            if (entity.ToDoId != null) task.ToDoId = entity.ToDoId;
            task.IsCompleted = entity.IsCompleted;
            if (entity.Name != null) task.Name = entity.Name;
            
            context.SaveChanges();
        }
    }
}

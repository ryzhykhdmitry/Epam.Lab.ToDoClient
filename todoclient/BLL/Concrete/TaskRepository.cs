using BLL.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.DTO;
using BLL.Mappers;

namespace BLL.Concrete
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DbContext context;

        public TaskRepository()
        {
        }

        public TaskRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("entitiesContex");
            }
            this.context = dbContext;
        }

        public void Create(BllTask e)
        {
            context.Set<ORM.Task>().Add(e.GetORMEntity());
            context.SaveChanges();
        }

        public void Delete(BllTask e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BllTask> GetAll()
        {
            var task = context.Set<ORM.Task>().ToList();
            return task.Select(u => u.GetBllEntity());
        }

        public BllTask GetById(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(BllTask entity)
        {
            throw new NotImplementedException();
        }
    }
}

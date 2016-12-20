using BLL.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.DTO;
using System.Data.Entity;
using BLL.Mappers;
using ORM;
using Action = ORM.Action;

namespace BLL.Concrete
{
    public class ActionRepository : IActionRepository
    {
        private readonly DbContext context;

        public ActionRepository()
        {
            context = new ToDoClientModel();
        }

        public ActionRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }
            context = dbContext;
        }

        public BllAction Create(BllAction e)
        {
            if (e == null) throw new ArgumentNullException(nameof(e));

            var result = context.Set<Action>().Add(e.GetOrmEntity());
            context.SaveChanges();

            return result.GetBllEntity();
        }

        public void Delete(int id)
        {
            var action = context.Set<Action>().FirstOrDefault(a => a.Id == id);
            if (action != null)
            {
                context.Set<Action>().Remove(action);
            }
            context.SaveChanges();
        }

        public IEnumerable<BllAction> GetAll()
        {
            var task = context.Set<Action>().ToList();
            return task.Select(u => u.GetBllEntity());
        }

        public BllAction GetById(int key)
        {
            return new BllAction();
        }

        public BllAction Update(BllAction entity)
        {
            return entity;
        }
    }
}

using BLL.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.DTO;
using System.Data.Entity;
using BLL.Mappers;

namespace BLL.Concrete
{
    public class ActionRepository : IActionRepository
    {
        private readonly DbContext context;

        public ActionRepository()
        {
        }

        public ActionRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("entitiesContex");
            }
            this.context = dbContext;
        }

        public BllAction Create(BllAction e)
        {
            var result = context.Set<ORM.Action>().Add(e.GetORMEntity());
            context.SaveChanges();
            return result.GetBllEntity();
        }

        public void Delete(int id)
        {
            var action = context.Set<ORM.Action>().Where(a => a.Id == id).FirstOrDefault();
            if (action != null)
            {
                context.Set<ORM.Action>().Remove(action);
            }
            context.SaveChanges();
        }

        public IEnumerable<BllAction> GetAll()
        {
            var task = context.Set<ORM.Action>().ToList();
            return task.Select(u => u.GetBllEntity());
        }

        public BllAction GetById(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(BllAction entity)
        {
            throw new NotImplementedException();
        }
    }
}

using BLL.Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Repository
{
    public interface IRepository<TEntity> where TEntity : IEntity 
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int key);

        TEntity Create(TEntity e);

        void Delete(int id);

        void Update(TEntity entity);
    }
}

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

        void Create(TEntity e);

        void Delete(TEntity e);

        void Update(TEntity entity);
    }
}

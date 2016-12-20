using BLL.Interfaces.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IService<T> where T:IEntity
    {
        BllTask Add(BllTask item);

        void Delete(int id);

        void Update(BllTask item);
        
        IEnumerable<BllTask> GetAll();

        BllTask Get(int id);

        IEnumerable<BllTask> GetByUserId(int userId);
    }
}

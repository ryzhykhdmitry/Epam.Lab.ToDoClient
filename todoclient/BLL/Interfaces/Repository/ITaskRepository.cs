using BLL.Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Repository
{
    public interface ITaskRepository : IRepository<BllTask>
    {
        IEnumerable<BllTask> GetAllByUserId(int id);

    }
}

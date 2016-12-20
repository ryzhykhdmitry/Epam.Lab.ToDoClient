using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.DTO
{
    public class BllAction : IEntity
    {
        public int Id { get; set; }

        public int TaskId { get; set; }

        public int ActionId { get; set; }

        public virtual ActionName ActionName { get; set; }

        public virtual ORM.Task Task { get; set; }
    }
}

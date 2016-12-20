using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.DTO
{
    public class BllActionName : IEntity
    {
        public int Id { get; set; }
        public string ActionName1 { get; set; }

        public virtual ICollection<BllAction> Actions { get; set; }
    }
}

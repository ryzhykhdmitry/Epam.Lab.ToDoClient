using BLL.Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class ActionMapper
    {
        public static BllAction GetBllEntity(this ORM.Action ormEntity)
        {
            return new BllAction()
            {
                Id = ormEntity.Id,
                TaskId = ormEntity.TaskId,
                ActionId = ormEntity.ActionId                
            };
        }

        public static ORM.Action GetOrmEntity(this BllAction bllEntity)
        {
            return new ORM.Action()
            {
                Id = bllEntity.Id,
                TaskId = bllEntity.TaskId,
                ActionId = bllEntity.ActionId
            };
        }
    }
}

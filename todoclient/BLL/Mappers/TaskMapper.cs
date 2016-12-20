using ORM;
using BLL.Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class TaskMapper
    {
        public static BllTask GetBllEntity(this ORM.Task ormEntity)
        {
            return new BllTask()
            {
                Id = ormEntity.Id,
                ToDoId = ormEntity.ToDoId,
                UserId = ormEntity.UserId,
                IsCompleted = ormEntity.IsCompleted,
                Name = ormEntity.Name
            };
        }

        public static ORM.Task GetORMEntity(this BllTask bllEntity)
        {
            return new ORM.Task()
            {
                Id = bllEntity.Id,
                ToDoId = bllEntity.ToDoId,
                UserId = bllEntity.UserId,
                IsCompleted = bllEntity.IsCompleted,
                Name = bllEntity.Name
            };
        }
    }
}

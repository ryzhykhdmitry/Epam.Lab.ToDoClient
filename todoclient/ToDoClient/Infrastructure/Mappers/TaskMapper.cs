using BLL.Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using todoclient.Models;

namespace todoclient.Infrastructure.Mappers
{
    public static class TaskMapper
    {
        public static BllTask GetBllEntity(this TaskViewModel viewEntity)
        {
            return new BllTask()
            {
                Id = viewEntity.Id,
                ToDoId = viewEntity.ToDoId,
                UserId = viewEntity.UserId,
                IsCompleted = viewEntity.IsCompleted,
                Name = viewEntity.Name,
                IsDeleted = viewEntity.IsDeleted
            };
        }

        public static TaskViewModel GetTaskViewEntity(this BllTask bllEntity)
        {
            return new TaskViewModel()
            {
                Id = bllEntity.Id,
                ToDoId = bllEntity.ToDoId,
                UserId = bllEntity.UserId,
                IsCompleted = bllEntity.IsCompleted,
                Name = bllEntity.Name,
                IsDeleted = bllEntity.IsDeleted
            };
        }
    }
}
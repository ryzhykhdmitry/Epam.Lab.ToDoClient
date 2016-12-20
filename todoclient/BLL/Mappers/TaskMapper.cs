using BLL.Interfaces.DTO;

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
                Name = ormEntity.Name,
                IsDeleted = ormEntity.IsDeleted
            };
        }

        public static ORM.Task GetOrmEntity(this BllTask bllEntity)
        {
            return new ORM.Task
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

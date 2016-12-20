using BLL.Actions;
using BLL.Concrete;
using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.Interfaces.DTO;
using BLL.Interfaces.Repository;
using System.Collections.Generic;

namespace BLL.Services
{
    public class Service : IService<BllTask>
    {
        private readonly ITaskRepository repository;
        private readonly IRepository<BllTask> actionsRepository;

        public Service()
        {
            repository = new TaskRepository();
            actionsRepository = default(IRepository<BllTask>);
        }

        public Service(ITaskRepository repository, IRepository<BllTask> actionsRepository)
        {
            this.repository = repository;
            this.actionsRepository = actionsRepository;
        }

        public void Add(BllTask item)
        {
            repository.Create(item);
            Worker.AddWork(new AddTask(item, repository));
        }

        public void Delete(int id)
        {
            var item = repository.GetById(id);
            Worker.AddWork(new DeleteTask(item, repository));
        }

        public void Update(BllTask item)
        {
            var currItem = repository.GetById(item.Id);
            Worker.AddWork(new UpdateTask(currItem, repository));
        }
        
        public IEnumerable<BllTask> GetAll()
        {
            return repository.GetAll();
        }

        public BllTask Get(int id)
        {
            return repository.GetById(id);
        }

        public IEnumerable<BllTask> GetByUserId(int userId)
        {
            return repository.GetAllByUserId(userId);
        }
    }
}

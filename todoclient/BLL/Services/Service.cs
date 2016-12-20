using System;
using BLL.Actions;
using BLL.Concrete;
using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.Interfaces.DTO;
using BLL.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class Service : IService<BllTask>
    {
        private readonly ITaskRepository repository;
        private IActionRepository actionRepository;

        public Service() : this(new TaskRepository(), new ActionRepository())
        {
        }

        public Service(ITaskRepository repository, IActionRepository actionRepository)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (actionRepository == null) throw new ArgumentNullException(nameof(actionRepository));

            this.repository = repository;
            this.actionRepository = actionRepository;

            Task.Run(() => Worker.Instance.Run());
        }

        public BllTask Add(BllTask item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            var result = repository.Create(item);
            Worker.AddWork(new AddTask(result, repository));

            return result;
        }

        public void Delete(int id)
        {
            var item = repository.GetById(id);

            item.IsDeleted = true;

            repository.Update(item);

            Worker.AddWork(new DeleteTask(item, repository));
        }

        public void Update(BllTask item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            repository.Update(item);
            Worker.AddWork(new UpdateTask(item, repository));
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
            var result = repository.GetAllByUserId(userId).Where(t => !t.IsDeleted);

            return result;
        }
    }
}

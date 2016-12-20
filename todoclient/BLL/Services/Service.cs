using System;
using BLL.Actions;
using BLL.Concrete;
using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.Interfaces.DTO;
using BLL.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class Service : IService<BllTask>
    {
        private readonly ITaskRepository repository;
        private readonly IActionRepository actionRepository;

        public Service() : this(new TaskRepository(), new ActionRepository())
        {
        }

        public Service(ITaskRepository repository, IActionRepository actionRepository)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (actionRepository == null) throw new ArgumentNullException(nameof(actionRepository));

            this.repository = repository;
            this.actionRepository = actionRepository;
        }

        public BllTask Add(BllTask item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            BllTask result = repository.Create(item);

            BllAction action = actionRepository.Create(new BllAction
            {
                ActionId = (int)BllActionEnum.Add,
                TaskId = result.Id
            });

            WorkerManager.AddWork(new AddTask(result, repository, action.Id, actionRepository), result.UserId);

            return result;
        }

        public void Delete(int id)
        {
            BllTask item = repository.GetById(id);

            item.IsDeleted = true;

            repository.Update(item);

            BllAction action = actionRepository.Create(new BllAction
            {
                ActionId = (int)BllActionEnum.Delete,
                TaskId = item.Id
            });

            WorkerManager.AddWork(new DeleteTask(item.Id, repository, action.Id, actionRepository), item.UserId);
        }

        public void Update(BllTask item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            repository.Update(item);

            BllAction action = actionRepository.Create(new BllAction
            {
                ActionId = (int)BllActionEnum.Update,
                TaskId = item.Id
            });

            WorkerManager.AddWork(new UpdateTask(item.Id, repository, action.Id, actionRepository), item.UserId);
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

            if (!result.Any())
            {
                result = ToDoService.GetItems(userId);
            }

            return result;
        }
    }
}

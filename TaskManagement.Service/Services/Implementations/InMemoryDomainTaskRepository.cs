using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using TaskManagement.Service.DataBase;
using TaskManagement.Service.Exceptions;
using TaskManagement.Service.Models;
using TaskManagement.Service.Services.Abstractions;
using TaskManagement.Service.Transform;

namespace TaskManagement.Service.Services.Implementations
{
    public class InMemoryDomainTaskRepository : IInMemoryDomainTaskRepository
    {
        private readonly InMemoryDataBase _inMemoryDb;
        private readonly DomainTaskTransform _taskTransform = new();
        
        

        public InMemoryDomainTaskRepository(InMemoryDataBase inMemoryDataBase)
        {
            _inMemoryDb = inMemoryDataBase ?? throw new ArgumentNullException(nameof(inMemoryDataBase));
        }

        public bool ValidateCreateDomainTask(DomainTask task)
        {
            if (_inMemoryDb.Tasks.Count > 0)
            {
                if (_inMemoryDb.Tasks.Any(p => p.Id == task.Id))
                    throw new OwnValidationException(" task Id already exists ");
            }

            if (task.Title.Length < 1 || task.Title.Length > 100)
                throw new OwnValidationException(" task title must contain minimum 1 symbol and maximum 100 symbol ");

            if (task.Description.Length is < 1 or > 4000)
                throw new OwnValidationException(" task description must contain minimum 1 symbol and maximum 4000 symbol ");

            if (_inMemoryDb.Users.TrueForAll(u => u.Id != task.CreatedByUserId))
                throw new OwnValidationException($" user with this Id {task.CreatedByUserId} is not present in user base ");
           
            if (_inMemoryDb.Projects.TrueForAll(p => p.Id != task.ProjectId))
                throw new OwnValidationException($" project with id : {task.ProjectId} was not found ");

            if (task.AssignedUsers.TrueForAll(assignedUser => _inMemoryDb.Users.TrueForAll(user => user.Id != assignedUser.Id)))
                throw new OwnValidationException(" assigned user was not found in users ");

            if (task.DeadLine < task.StartDate)
                throw new OwnValidationException(" task deadline must not be less than than task start date ");


                
            return true;
        }

        public void CreateDomainTask(DomainTask taskToCreate)
        {
            if (ValidateCreateDomainTask(taskToCreate))
            {
                if (taskToCreate.Id == 0)
                {
                    taskToCreate.Id = _inMemoryDb.Tasks.Count > 0 ? _inMemoryDb.Tasks.Max(u => u.Id) + 1 : 1;
                }
                _inMemoryDb.Tasks.Add(taskToCreate);
            }

        }

        public IEnumerable<DomainTask> GetAllTasks()
        {
            return _inMemoryDb.Tasks;
        }

        public DomainTask GetDomainTask(int id)
        {
            return _inMemoryDb.Tasks.FirstOrDefault(t => t.Id == id)!;
        }

        public void UpdateDomainTask(UpdateDomainTask updateTask)
        {
            var requestedTaskExist = _inMemoryDb.Tasks.Find(u => u.Id == updateTask.Id);
            if (requestedTaskExist == null)
            {
                throw new OwnValidationException($" task with id = {updateTask.Id} doesn't exists");
            }

            if (updateTask.Validate())
            {
                _taskTransform.TransformFromModelToRepositoryModel(updateTask, requestedTaskExist);
            }
        }

        public void DeleteDomainTask(int id)
        {
            var taskToDelete = _inMemoryDb.Tasks.Find(x => x.Id == id);
            if (taskToDelete == null)
            {
                throw new OwnValidationException($" task with Id = {id} doesn't exists");
            }

            _inMemoryDb.Tasks.Remove(taskToDelete);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Service.DataBase;
using TaskManagement.Service.Exceptions;
using TaskManagement.Service.Models;
using TaskManagement.Service.Transform;

namespace TaskManagement.Service.Services.Implementations
{
    public class DomainTaskService
    {
        private readonly InMemoryDataBase _base;
        

        public DomainTaskService(InMemoryDataBase inMemoryDataBase)
        {
            _base = inMemoryDataBase ?? throw new ArgumentNullException(nameof(inMemoryDataBase));
        }

        public bool ValidateCreateDomainTask(DomainTask task)
        {
            if (_base.Tasks.Count > 0)
            {
                if (_base.Tasks.Any(p => p.Id == task.Id))
                    throw new OwnValidationException(" task Id already exists ");
            }

            if (task.Title.Length < 1 || task.Title.Length > 100)
                throw new OwnValidationException(" task title must contain minimum 1 symbol and maximum 100 symbol ");

            if (task.Description.Length is < 1 or > 4000)
                throw new OwnValidationException(" task description must contain minimum 1 symbol and maximum 4000 symbol ");

            if (_base.Users.TrueForAll(u => u.Id != task.CreatedByUserId))
                throw new OwnValidationException($" user with this Id {task.CreatedByUserId} is not present in user base ");
           
            if (_base.Projects.TrueForAll(p => p.Id != task.ProjectId))
                throw new OwnValidationException($" project with id : {task.ProjectId} was not found ");

            if (task.AssignedUsers.Any(assignedUser => !_base.Users.TrueForAll(user => user.Id == assignedUser.Id)))
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
                    taskToCreate.Id = _base.Tasks.Count > 0 ? _base.Tasks.Max(u => u.Id) + 1 : 1;
                }
                _base.Tasks.Add(taskToCreate);
            }

        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Service.Exceptions;
using TaskManagement.Service.Models;

namespace TaskManagement.Service.Services.Abstractions
{
    public interface IInMemoryDomainTaskRepository
    {

        public void CreateDomainTask(DomainTask taskToCreate);


        public IEnumerable<DomainTask> GetAllTasks();

        public DomainTask GetDomainTask(int id);


        public void UpdateDomainTask(UpdateDomainTask updateTask);


        public void DeleteDomainTask(int id);

    }
}

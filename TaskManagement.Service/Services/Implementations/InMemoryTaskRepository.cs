using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Service.Models;

namespace TaskManagement.Service.Services
{
    public class InMemoryTaskRepository
    {
        private readonly List<DomainTask> _tasks;
        public InMemoryTaskRepository()
        {
            _tasks = new List<DomainTask>
            {
             new DomainTask
             { 
                 
                
                
                 
             },

                


            };
        }
    }
}

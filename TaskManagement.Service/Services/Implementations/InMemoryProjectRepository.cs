using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Service.Models;

namespace TaskManagement.Service.Services
{
    internal class InMemoryProjectRepository
    {
        private readonly List<Project> _projects;
        public InMemoryProjectRepository()
        {
            _projects = new List<Project>
            {
                new Project
                {
                    Id = 1,
                    Name = "Marketing Project",
                    Description = "Managing Marketing strategies",
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today.AddMonths(1),
                    Status = Status.ToDo,
                    CreatedByUserId = 1
                },

                 new Project
                {
                    Id = 1,
                    Name = "Business Project",
                    Description = "Managing Business strategies",
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today.AddMonths(2),
                    Status = Status.ToDo,
                    CreatedByUserId = 4
                },
            };
        }
    }
}

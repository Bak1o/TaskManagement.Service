using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Service.Models;

namespace TaskManagement.Service.Services.Abstractions
{
    public interface IInMemoryProjectRepository
    {
        public void CreateProject(Project projectToCreate);
        public IEnumerable<Project> GetAllProjects();
        public void UpdateProject(UpdateProject updateProject);
        public Project GetProject(int id);
    }
}

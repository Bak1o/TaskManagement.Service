using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Service.DataBase;
using TaskManagement.Service.Exceptions;
using TaskManagement.Service.Models;
using TaskManagement.Service.Transform;

namespace TaskManagement.Service.Services.Implementations
{
    public class ProjectService
    {
        private readonly InMemoryDataBase _base;
        private readonly ProjectTransform _projectTransform = new();

        public ProjectService(InMemoryDataBase inMemoryDataBase)
        {
            _base = inMemoryDataBase ?? throw new ArgumentNullException(nameof(inMemoryDataBase));
        }

        public bool ValidateCreateProject(Project project)
        {
            if (_base.Projects.Count > 0)
            {
                if (_base.Projects.Any(p => p.Id == project.Id))
                    throw new OwnValidationException(" project Id already exists ");
            }

            if (project.Name.Length < 1 || project.Name.Length > 100)
                throw new OwnValidationException(" project name must contain minimum 1 symbol and maximum 100 symbol ");

            if(project.Description.Length is < 1 or > 4000)
                throw new OwnValidationException(" project description must contain minimum 1 symbol and maximum 4000 symbol ");
           
            if (_base.Users.TrueForAll(u => u.Id != project.CreatedByUserId))
                throw new OwnValidationException($" user with this Id {project.CreatedByUserId} is not present in user base ");


            return true;
        }

        public void CreateProject(Project projectToCreate)
        {
            if (ValidateCreateProject(projectToCreate))

            {
                if (projectToCreate.Id == 0)
                {
                    projectToCreate.Id = _base.Projects.Count > 0 ? _base.Projects.Max(u => u.Id) + 1 : 1;
                }

                _base.Projects.Add(projectToCreate);
            }
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return _base.Projects;
        }

        public Project GetProject(int id)
        {
            return _base.Projects.FirstOrDefault(p => p.Id == id);
        }

        public void UpdateProject(UpdateProject updateProject)
        {
            var requestedProjectExist = _base.Projects.Find(u => u.Id == updateProject.Id);
            if (requestedProjectExist == null)
            {
                throw new OwnValidationException($" Project with id = {updateProject.Id} doesn't exists");
            }

            if (updateProject.Validate())

                _projectTransform.TransformFromModelToRepositoryModel(updateProject, requestedProjectExist);

        }


        
    }
}

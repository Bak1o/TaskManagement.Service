using TaskManagement.Service.Models;

namespace InMemoryDb
{
    public class InMemoryDataBase
    {
        public List<User> Users = new();
        public List<Project> Projects = new();
        public List<DomainTask> Tasks = new();
    }
}

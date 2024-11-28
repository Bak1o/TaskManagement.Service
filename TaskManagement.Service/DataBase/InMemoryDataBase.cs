using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Service.Models;

namespace TaskManagement.Service.DataBase
{
    public class InMemoryDataBase
    {
        public List<User> Users = new();
        public List<Project> Projects = new();
        public List<DomainTask> Tasks = new();
    }

    //public interface IUserRepository
    //{
    //    void Add(User user);
    //    void Delete(int userId);
    //}

    //public class UserRepository : IUserRepository
    //{
    //    public List<User> Users = new();

    //    public void Add(User user)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Delete(int userId)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Update(User user)
    //    {
    //       var oldUser =  Users.FirstOrDefault(x => x.Id == user.Id);
    //       if (oldUser is null)
    //           throw new NotFoundException();

    //       oldUser.Email = user.Email;
    //    }

    //}
}

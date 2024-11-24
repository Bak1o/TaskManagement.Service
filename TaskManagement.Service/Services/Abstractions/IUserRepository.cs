using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Service.Models;

namespace TaskManagement.Service.Services.Abstractions
{
    public interface IUserRepository
    {
        void CreateUser(User userToCreate);
        IEnumerable<User> GetAllUsers(); 
        User GetUser(int id);
        User GetUser(string name);
        void UpdateUser(UpdateUser updateUser);
        void DeleteUser(int id);
        void SaveUser(User user);

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using TaskManagement.Service.DataBase;
using TaskManagement.Service.Models;
using TaskManagement.Service.Services.Abstractions;

namespace TaskManagement.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IInMemoryUserRepository _repository;
        
        public UsersController(IInMemoryUserRepository repository)
        {
           _repository = repository;
           
        }

        [HttpGet("{id}")]
        public User GetUser(int id)
        {
            var user = _repository.GetUser(id);
            return user;

        }

        [HttpPost]

        public User PostUser(User user)
        {
             _repository.CreateUser(user);
            return user;
        }
    }
}

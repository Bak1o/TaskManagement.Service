

using TaskManagement.Service.DataBase;
using TaskManagement.Service.Enums;
using TaskManagement.Service.Exceptions;
using TaskManagement.Service.Models;
using TaskManagement.Service.Services;
using TaskManagement.Service.Services.Abstractions;
using TaskManagement.Service.Services.Implementations;

namespace TaskManagement.Service.ConsoleApp;
internal class Program
{
    public static void Main(string[] args)
    {
        var dataBase = new InMemoryDataBase();
        var userRepository = new UserService(dataBase);

        var projectRepository = new ProjectService(dataBase);
       
        try 
        { 
       
            var user1 = new User
        {
            Email = "dgF4@gmail.com",
            Password = "password",
            Role = Role.Admin,
            UserName = "Bako"

        };
        userRepository.CreateUser(user1);
        Console.WriteLine(" user was added succesfully");
        var user2 = new User
        {
            Email = "dgFgg4@gmail.com",
            Password = "password",
            Role = Role.TeamMember,
            UserName = "Niko"

        };
        userRepository.CreateUser(user2);
            Console.WriteLine(" user was added succesfully");
       
        var user3 = new User
        {
            Email = "dhFyuyg4@gmail.com",
            Password = "password",
            Role = Role.TeamMember,
            UserName = "Nino"

        };
        userRepository.CreateUser(user3); 
        Console.WriteLine(" user was added succesfully");

        var user4 = new User
        {
            Email = "dsssgF4@gmail.com",
            Password = "password",
            Role = Role.TeamMember,
            UserName = "Natia"

        };
        var updateUser4 = new UpdateUser
        {
            Id = 4,
            Email = "dsssgF4@gmail.com",
            Password = "passwordupdate",
            Role = Role.TeamMember,
            UserName = "NatiaUpdate"

        };
        userRepository.CreateUser(user4);
            Console.WriteLine(" user was added succesfully");
            userRepository.UpdateUser(updateUser4);

            var project1 = new Project
            {
                Id = 1,
                Name = "Marketing Project",
                Description = "Managing Marketing strategies",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddMonths(1),
                Status = Status.ToDo,
                CreatedByUserId = 1

            };
            projectRepository.CreateProject(project1);
            Console.WriteLine(" project was added sucesfully");

            var project2 = new Project
            {
                Id = 2,
                Name = "Business Project",
                Description = "Managing Business strategies",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddMonths(2),
                Status = Status.ToDo,
                CreatedByUserId = 4
            };
            projectRepository.CreateProject(project2);
            Console.WriteLine(" project was added succesfully ");




        }
        catch (OwnValidationException ex)
        {
            Console.WriteLine(ex);
        }



        foreach (var user in userRepository.GetAllUsers())
        {
            Console.WriteLine($" user id is {user.Id}, name {user.UserName}");
        }

        foreach (var project in projectRepository.GetAllProjects())
        {
            Console.WriteLine($"project id is {project.Id}, name {project.Name}");
        }

    }
}
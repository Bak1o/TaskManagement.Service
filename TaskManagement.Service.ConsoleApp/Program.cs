

using System.Collections.Concurrent;
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
        var taskRepository = new DomainTaskService(dataBase);
       
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
            Role = Role.Admin,
            UserName = "Natia"

        };
        userRepository.CreateUser(user4);
        Console.WriteLine(" user was added succesfully");

        var user5 = new User
        {
            Email = "dsNyuussgF4@gmail.com",
            Password = "password",
            Role = Role.TeamMember,
            UserName = "Gela"

        };
        userRepository.CreateUser(user5);
        Console.WriteLine(" user was added succesfully");

        var user6 = new User
        {
            Email = "dssSweyttsgF4@gmail.com",
            Password = "password",
            Role = Role.Admin,
            UserName = "Ana"

        };
        userRepository.CreateUser(user6);
        Console.WriteLine(" user was added succesfully");



            var updateUser4 = new UpdateUser
        {
            Id = 4,
            Email = "dsssgF4@gmail.com",
            Password = "passwordupdate",
            Role = Role.Admin,
            UserName = "NatiaUpdate"

        };
      
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

            var project3 = new Project
            {
                Id = 3,
                Name = "Communications Project",
                Description = "Managing Communications strategies",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddMonths(3),
                Status = Status.ToDo,
                CreatedByUserId = 6
            };
            projectRepository.CreateProject(project3);
            Console.WriteLine(" project was added succesfully ");

            var updateProject2 = new UpdateProject
            {
                Id = 2,
                Name = "Update Business Project",
                Description = "Managing Business strategies",

                EndDate = DateTime.Today.AddMonths(2),
                Status = Status.InProgress,


            };
            projectRepository.UpdateProject(updateProject2);

            var task1 = new DomainTask
            {
                CreatedByUserId = 1,
                Id = 1,
                AssignedUsers = new List<User>
                {
                    new User()
                    {
                        Id = 2,
                        Email = "dgFgg4@gmail.com",
                        Password = "password",
                        Role = Role.TeamMember,
                        UserName = "Niko"
                    },
                    new User()
                    {
                        Id = 3,
                        Email = "dhFyuyg4@gmail.com",
                        Password = "password",
                        Role = Role.TeamMember,
                        UserName = "Nino"

                    }
                },
                DeadLine = DateTime.Today.AddMonths(2),
                Description = "TestDescription1",
                Priority = Priority.High,
                ProjectId = 1,
                Status = Status.ToDo,
                Title = " testTitle1",
                StartDate = DateTime.Today

            };
            taskRepository.CreateDomainTask(task1);
            Console.WriteLine(" task was created successfully ");
           
            var task2 = new DomainTask
            {
                CreatedByUserId = 4,
                Id = 2,
                AssignedUsers = new List<User>
                {
                    new User()
                    {
                        Id = 5,
                        Email = "dsNyssgF4@gmail.com",
                        Password = "password",
                        Role = Role.TeamMember,
                        UserName = "Gela"
                    }
                    
                   
                },
                DeadLine = DateTime.Today.AddMonths(3),
                Description = "TestDescription2",
                Priority = Priority.Medium,
                ProjectId = 2,
                Status = Status.ToDo,
                Title = " testTitle2",
                StartDate = DateTime.Today

            };
            taskRepository.CreateDomainTask(task2);
            Console.WriteLine(" task was created successfully ");

            var updateTask2 = new UpdateDomainTask
            {
                Id = 2,
                AssignedUsers = new List<User>
                {
                    new User()
                    {
                        Id = 5,
                        Email = "dsNyssgF4@gmail.com",
                        Password = "password",
                        Role = Role.TeamMember,
                        UserName = "Gela"
                    }


                },
                DeadLine = DateTime.Today.AddMonths(3),
                Description = "UpdateTestDescription2",
                Priority = Priority.Medium,

                Status = Status.InProgress,
                Title = "UpdatetestTitle2",
            };
            taskRepository.UpdateDomainTask(updateTask2);





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

        foreach (var domainTasks in taskRepository.GetAllTasks())
        {
            Console.WriteLine($" task id is {domainTasks.Id}, title {domainTasks.Title}");
            
        }

    }
}
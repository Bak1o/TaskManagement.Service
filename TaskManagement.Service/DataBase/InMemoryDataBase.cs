using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Service.Enums;
using TaskManagement.Service.Models;

namespace TaskManagement.Service.DataBase
{
    public class InMemoryDataBase
    {
        public List<User> Users = new();
        public List<Project> Projects = new();
        public List<DomainTask> Tasks = new();

        //public InMemoryDataBase()
        //{
        //    var user1 = new User
        //    {
        //        Email = "dgF4@gmail.com",
        //        Password = "password",
        //        Role = Role.Admin,
        //        UserName = "Bako"

        //    };
            
        //    var user2 = new User
        //    {
        //        Email = "dgFgg4@gmail.com",
        //        Password = "password",
        //        Role = Role.TeamMember,
        //        UserName = "Niko"

        //    };
           

        //    var user3 = new User
        //    {
        //        Email = "dhFyuyg4@gmail.com",
        //        Password = "password",
        //        Role = Role.TeamMember,
        //        UserName = "Nino"

        //    };
            

        //    var user4 = new User
        //    {
        //        Email = "dsssgF4@gmail.com",
        //        Password = "password",
        //        Role = Role.Admin,
        //        UserName = "Natia"

        //    };
           

        //    var user5 = new User
        //    {
        //        Email = "dsNyuussgF4@gmail.com",
        //        Password = "password",
        //        Role = Role.TeamMember,
        //        UserName = "Gela"

        //    };
      

        //    var user6 = new User
        //    {
        //        Email = "dssSweyttsgF4@gmail.com",
        //        Password = "password",
        //        Role = Role.Admin,
        //        UserName = "Ana"

        //    };
        //    Users.Add(user1);
        //    Users.Add(user2);
        //    Users.Add(user3);
        //    Users.Add(user4);
        //    Users.Add(user5);
        //    Users.Add(user6);

        //    var project1 = new Project
        //    {
        //        Id = 1,
        //        Name = "Marketing Project",
        //        Description = "Managing Marketing strategies",
        //        StartDate = DateTime.Today,
        //        EndDate = DateTime.Today.AddMonths(1),
        //        Status = Status.ToDo,
        //        CreatedByUserId = 1

        //    };
            

        //    var project2 = new Project
        //    {
        //        Id = 2,
        //        Name = "Business Project",
        //        Description = "Managing Business strategies",
        //        StartDate = DateTime.Today,
        //        EndDate = DateTime.Today.AddMonths(2),
        //        Status = Status.ToDo,
        //        CreatedByUserId = 4
        //    };
           

        //    var project3 = new Project
        //    {
        //        Id = 3,
        //        Name = "Communications Project",
        //        Description = "Managing Communications strategies",
        //        StartDate = DateTime.Today,
        //        EndDate = DateTime.Today.AddMonths(3),
        //        Status = Status.ToDo,
        //        CreatedByUserId = 6
        //    };
        //    Projects.Add(project1);
        //    Projects.Add(project2);
        //    Projects.Add(project3);

        //    var task1 = new DomainTask
        //    {
        //        CreatedByUserId = 1,
        //        Id = 1,
        //        AssignedUsers = new List<User>
        //        {
        //            new User()
        //            {
        //                Id = 2,
        //                Email = "dgFgg4@gmail.com",
        //                Password = "password",
        //                Role = Role.TeamMember,
        //                UserName = "Niko"
        //            },
        //            new User()
        //            {
        //                Id = 3,
        //                Email = "dhFyuyg4@gmail.com",
        //                Password = "password",
        //                Role = Role.TeamMember,
        //                UserName = "Nino"

        //            }
        //        },
        //        DeadLine = DateTime.Today.AddMonths(2),
        //        Description = "TestDescription1",
        //        Priority = Priority.High,
        //        ProjectId = 1,
        //        Status = Status.ToDo,
        //        Title = " testTitle1",
        //        StartDate = DateTime.Today

        //    };
           

        //    var task2 = new DomainTask
        //    {
        //        CreatedByUserId = 4,
        //        Id = 2,
        //        AssignedUsers = new List<User>
        //        {
        //            new User()
        //            {
        //                Id = 5,
        //                Email = "dsNyssgF4@gmail.com",
        //                Password = "password",
        //                Role = Role.TeamMember,
        //                UserName = "Gela"
        //            }


        //        },
        //        DeadLine = DateTime.Today.AddMonths(3),
        //        Description = "TestDescription2",
        //        Priority = Priority.Medium,
        //        ProjectId = 2,
        //        Status = Status.ToDo,
        //        Title = " testTitle2",
        //        StartDate = DateTime.Today

        //    };

        //    Tasks.Add(task1);
        //    Tasks.Add(task2);


        //}
    }

//    public interface IUserRepository
//    {
//        void Add(User user);
//        void Delete(int userId);
//    }

//    public class UserRepository : IUserRepository
//    {
//        public List<User> Users = new();

//        public void Add(User user)
//        {
//            throw new NotImplementedException();
//        }

//        public void Delete(int userId)
//        {
//            throw new NotImplementedException();
//        }

//        public void Update(User user)
//        {
//            var oldUser = Users.FirstOrDefault(x => x.Id == user.Id);
//            if (oldUser is null)
//                throw new NotFoundException();

//            oldUser.Email = user.Email;
//        }

//    }
}

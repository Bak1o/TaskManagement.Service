﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using TaskManagement.Service.DataBase;
using TaskManagement.Service.Enums;
using TaskManagement.Service.Exceptions;
using TaskManagement.Service.Models;
using TaskManagement.Service.Services.Abstractions;
using TaskManagement.Service.Transform;

namespace TaskManagement.Service.Services.Implementations
{
    public class InMemoryUserRepository : IInMemoryUserRepository
    {
        private readonly InMemoryDataBase _inMemoryDb;
        

        public InMemoryUserRepository(InMemoryDataBase inMemoryDb)
        {
            _inMemoryDb = inMemoryDb ?? throw new ArgumentNullException(nameof(inMemoryDb));
            var user1 = new User
            {
                Email = "dgF4@gmail.com",
                Password = "password",
                Role = Role.Admin,
                UserName = "Bako"

            };
            CreateUser(user1);
            
            var user2 = new User
            {
                Email = "dgFgg4@gmail.com",
                Password = "password",
                Role = Role.TeamMember,
                UserName = "Niko"

            };
            CreateUser(user2);
            

            var user3 = new User
            {
                Email = "dhFyuyg4@gmail.com",
                Password = "password",
                Role = Role.TeamMember,
                UserName = "Nino"

            };
            CreateUser(user3);
            

            var user4 = new User
            {
                Email = "dsssgF4@gmail.com",
                Password = "password",
                Role = Role.Admin,
                UserName = "Natia"

            };
            CreateUser(user4);
            

            var user5 = new User
            {
                Email = "dsNyuussgF4@gmail.com",
                Password = "password",
                Role = Role.TeamMember,
                UserName = "Gela"

            };
            CreateUser(user5);
            

            var user6 = new User
            {
                Email = "dssSweyttsgF4@gmail.com",
                Password = "password",
                Role = Role.Admin,
                UserName = "Ana"

            };
            CreateUser(user6);
            

        }



        public bool ValidateCreateUser(User user)
        {
            // Check if the email already exists



            if (_inMemoryDb.Users.Count > 0)

            {
                if (_inMemoryDb.Users.Any(u => u.Email.Equals(user.Email)))
                {
                    throw new OwnValidationException("Email already exists.");
                }

                if (_inMemoryDb.Users.Any(i => i.Id == user.Id))
                {
                    throw new OwnValidationException(" Id already exists. ");
                }
            }





            if (user.UserName.Length < 1 || user.UserName.Length > 100)
                throw new OwnValidationException(" User name must contain minimum on1 symbol and maximum 100 symbol ");

            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(emailPattern);

            if (!regex.IsMatch(user.Email))
                throw new OwnValidationException(" enter correct email format ");


            if (string.IsNullOrWhiteSpace(user.Email))
                throw new ValidationException("Email must not be empty");


            if (user.Password.Length < 8 || user.Password.Length > 16)
                throw new OwnValidationException(" password must contain minimum 8 symbols and maximum 16 symbols ");


            return true;
        }
        public void CreateUser(User userToCreate)
        {
            if (ValidateCreateUser(userToCreate))
            {
                if (userToCreate.Id == 0)
                {
                    userToCreate.Id = _inMemoryDb.Users.Count > 0 ? _inMemoryDb.Users.Max(u => u.Id) + 1 : 1;
                }
                 _inMemoryDb.Users.Add(userToCreate);
            }

        }
        public IEnumerable<User> GetAllUsers()
        {
            return _inMemoryDb.Users;
        }

       
        public User GetUser(int id)
        {
            return _inMemoryDb.Users.FirstOrDefault(user => user.Id == id)!;
        }
        public User GetUser(string userName)
        {
            return _inMemoryDb.Users.FirstOrDefault(user => user.UserName == userName)!;
        }

        public void UpdateUser(UpdateUser updateUser)
        {
            var requestedUserExist = _inMemoryDb.Users.Find(u => u.Id == updateUser.Id);
            if (requestedUserExist == null)
            {
                throw new OwnValidationException($" user with id = {updateUser.Id} doesn't exists");
            }

            updateUser.Validate();
                UserTransform.TransformFromModelToRepositoryModel(updateUser,requestedUserExist);
            

        }
        public void DeleteUser(int id)
        {
            var userToDelete = _inMemoryDb.Users.Find(x => x.Id == id);
            if (userToDelete == null)
            {
                throw new OwnValidationException($" user with Id = {id} doesn't exists");
            }

            _inMemoryDb.Users.Remove(userToDelete);
        }
        public void SaveUser(User user)
        {

        }

       
    }
}

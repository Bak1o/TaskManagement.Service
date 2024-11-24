using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using TaskManagement.Service.Exceptions;
using TaskManagement.Service.Models;
using TaskManagement.Service.Services.Abstractions;
using TaskManagement.Service.Transform;

namespace TaskManagement.Service.Services.Implementations
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly  Base _base = new();
        private readonly UserTransform _userTransform = new();

        //public InMemoryUserRepository(Base userBase)
        //{
        //    _base = userBase;

        //}

        public bool ValidateCreateUser(User user)
        {
            // Check if the email already exists



            if (_base.Users.Count > 0)

            {
                if (_base.Users.Any(u => u.Email.Equals(user.Email)))
                {
                    throw new OwnValidationException("Email already exists.");
                }

                if (_base.Users.Any(i => i.Id == user.Id))
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
                    userToCreate.Id = _base.Users.Count > 0 ? _base.Users.Max(u => u.Id) + 1 : 1;
                }
                _base.Users.Add(userToCreate);
            }

        }
        public IEnumerable<User> GetAllUsers()
        {
            return _base.Users;
        }

       
        public User GetUser(int id)
        {
            return _base.Users.FirstOrDefault(user => user.Id == id);
        }
        public User GetUser(string userName)
        {
            return _base.Users.FirstOrDefault(user => user.UserName == userName);
        }
        public void UpdateUser(UpdateUser updateUser)
        {
            var requestedUserExist = _base.Users.Find(u => u.Id == updateUser.Id);
            if (requestedUserExist == null)
            {
                throw new OwnValidationException($" user with id = {updateUser.Id} doesn't exists");
            }

            if (updateUser.Validate())
            
                _userTransform.TransformFromModelToRepositoryModel(updateUser,requestedUserExist);
            

        }
        public void DeleteUser(int id)
        {
            var userToDelete = _base.Users.Find(x => x.Id == id);
            if (userToDelete == null)
            {
                throw new OwnValidationException($" user with Id = {id} doesn't exists");
            }

            _base.Users.Remove(userToDelete);
        }
        public void SaveUser(User user)
        {

        }

       
    }
}

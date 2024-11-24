using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using TaskManagement.Service.Exceptions;
using TaskManagement.Service.Models;
using TaskManagement.Service.Transform;

namespace TaskManagement.Service.Services.Implementations
{
    public class InMemoryUserRepository
    {
        private readonly  List<User> _users = new();
        private readonly UserTransform _userTransform = new();

        public bool ValidateCreateUser(User user)
        {
            // Check if the email already exists



            if (_users.Count > 0)

            {
                if (_users.Any(u => u.Email.Equals(user.Email)))
                {
                    throw new OwnValidationException("Email already exists.");
                }

                if (_users.Any(i => i.Id == user.Id))
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
                    userToCreate.Id = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
                }
                _users.Add(userToCreate);
            }

        }
        public IEnumerable<User> GetAllUsers()
        {
            return _users;
        }

        public User GetUser(int id)
        {
            return _users.FirstOrDefault(user => user.Id == id);
        }
        public User GetUser(string userName)
        {
            return _users.FirstOrDefault(user => user.UserName == userName);
        }

        public void UpdateUser(UpdateUser updateUser)
        {
            var requestedUserExist = _users.Find(u => u.Id == updateUser.Id);
            if (requestedUserExist == null)
            {
                throw new OwnValidationException($" user with id = {updateUser.Id} doesn't exists");
            }

            if (updateUser.Validate())
            
                _userTransform.TransformFromModelToRepositoryModel(updateUser,requestedUserExist);
            

        }

        public void DeleteUser(int id)
        {
            var userToDelete = _users.Find(x => x.Id == id);
            if (userToDelete == null)
            {
                throw new OwnValidationException($" user with Id = {id} doesn't exists");
            }

            _users.Remove(userToDelete);
        }

        public void SaveUser(User user)
        {

        }
    }
}

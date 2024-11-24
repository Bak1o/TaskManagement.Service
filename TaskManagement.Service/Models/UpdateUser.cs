using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TaskManagement.Service.Exceptions;

namespace TaskManagement.Service.Models
{
    public class UpdateUser
    {
        public required int Id { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public Role Role { get; set; }

        public bool Validate()
        {
            if (UserName.Length < 1 || UserName.Length > 100)
                throw new OwnValidationException(" User name must contain minimum on1 symbol and maximum 100 symbol ");

            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(emailPattern);

            if (!regex.IsMatch(Email))
                throw new OwnValidationException(" enter correct email format ");


            if (string.IsNullOrWhiteSpace(Email))
                throw new ValidationException("Email must not be empty");


            if (Password.Length < 8 || Password.Length > 16)
                throw new OwnValidationException(" password must contain minimum 8 symbols and maximum 16 symbols ");


            return true;


        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using TaskManagement.Service.Exceptions;
using TaskManagement.Service.Enums;

namespace TaskManagement.Service.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string  UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public Role Role { get; set; }

        


    }
}

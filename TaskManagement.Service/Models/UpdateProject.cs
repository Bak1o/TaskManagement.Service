using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Service.Enums;
using TaskManagement.Service.Exceptions;

namespace TaskManagement.Service.Models
{
    public class UpdateProject
    {
        public required int Id { get; set; }  
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
        public required Status Status { get; set; }

        public void Validate()
        {
            if (Name!.Length is < 1 or > 100)
                throw new OwnValidationException(" project name must contain minimum 1 symbol and maximum 100 symbol ");

            if (Description!.Length is < 1 or > 4000)
                throw new OwnValidationException(" project description must contain minimum 1 symbol and maximum 4000 symbol ");
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskManagement.Service.Enums;
using TaskManagement.Service.Exceptions;

namespace TaskManagement.Service.Models
{
    public class UpdateDomainTask
    {
        public required int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<User> AssignedUsers { get; set; }
        public Status Status { get; set; } 
        public Priority Priority { get; set; }
        public DateTime DeadLine { get; set; }

        public void Validate()
        {
            if (Title!.Length is < 1 or > 100)
                throw new OwnValidationException(" project name must contain minimum 1 symbol and maximum 100 symbol ");

            if (Description!.Length is < 1 or > 4000)
                throw new OwnValidationException(" project description must contain minimum 1 symbol and maximum 4000 symbol ");

            if (Status == Status.Done)
            {
                DeadLine = DateTime.Today;
            }

            
        }

    }
}

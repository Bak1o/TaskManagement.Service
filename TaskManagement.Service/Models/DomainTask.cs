using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Service.Enums;

namespace TaskManagement.Service.Models
{
    public class DomainTask
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; }
        public required int ProjectId { get; set; }
        public  List<User> AssignedUsers { get; set; }
        public Status Status { get; set; } = Status.ToDo;
        public required Priority Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DeadLine { get; set; }
        public required int CreatedByUserId { get; set; }


        
        
            
       




    }
}

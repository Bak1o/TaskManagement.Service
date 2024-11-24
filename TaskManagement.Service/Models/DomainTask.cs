using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Service.Models
{
    public class DomainTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public  List<User> AssignedUsers { get; set; } 
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public DateTime DeadLine { get; set; }
        public int CreatedByUserId { get; set; }


        
        
            
       




    }
}

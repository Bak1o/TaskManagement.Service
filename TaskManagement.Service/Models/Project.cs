using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Service.Enums;

namespace TaskManagement.Service.Models
{
    public class Project
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; }
        public required DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
        public required int CreatedByUserId { get; set; }



    }
}

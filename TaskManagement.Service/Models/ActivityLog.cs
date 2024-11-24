using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Service.Models
{
    internal class ActivityLog
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedByUserId { get; set; }

    }
}

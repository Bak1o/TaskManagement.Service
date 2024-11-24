using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Service.Exceptions
{
    public class OwnValidationException : DomainException
    {
        public OwnValidationException(string message) : base(message)
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Application.Exceptions
{
    internal class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key) : base($"{name} {key} not found")
        {
            
        }
    }
}

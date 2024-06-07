using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyERP.Business.Exceptions
{
    public class DepartmentNotFoundException : Exception
    {
        public DepartmentNotFoundException()
        {
        }

        public DepartmentNotFoundException(string? message) : base(message)
        {
        }
    }
}

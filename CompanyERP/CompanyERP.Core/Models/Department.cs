using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyERP.Core.Models
{
    public class Department :BaseModel
    {
       private static int _id;
        public Department() {
            ++_id;
            ID = _id;
        
        }
        public int EmployeeLimit { get; set; }
        public double Budget { get; set; }
        public int RequiredExperience { get; set; }
        public bool? IsBachelorDegreeRequired { get; set; }
        public List<Employee> Employees = new List<Employee>();
        public override string ToString()
        {
            return $"{Name}- {EmployeeLimit} -{Budget}";
        }
    }
}

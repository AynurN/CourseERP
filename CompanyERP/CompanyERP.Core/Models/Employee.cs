using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CompanyERP.Core.Models
{
    public class Employee :BaseModel
    {

        private  static int _id;
        public Employee()
        {
            ++_id;
            ID = _id;

        }
        public string Surname { get; set; }
        public double Salary { get; set; }
        public int Experience { get; set; }
        public bool? HasBachelorDegree { get; set; }
        public Department Department { get; set; }
        public override string ToString()
        {
            if(Department != null) 
            return $"{Name}-{Surname}-{Salary}- {Experience}- {Department.Name}";
            else 
                return $"{Name}-{Surname}-{Salary}- {Experience}";

        }
    }
}

using CompanyERP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyERP.Business.Interfaces
{
    public interface IDepartmentService
    {
        public void Add(Department department);
       public void Delete(int id);
        public void AddEmployee(int departmentId, int employeeId);
        public List<Department> GetAll();
        public Department Get(int id);  
       
    }
}

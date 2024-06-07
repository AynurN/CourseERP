using CompanyERP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyERP.Business.Interfaces
{
    public interface IEmployeeService
    {
        public void Add(Employee employee);
        public void Delete(int id);
        public List<Employee> GetAll();
        public Employee Get(int id);

    }
}

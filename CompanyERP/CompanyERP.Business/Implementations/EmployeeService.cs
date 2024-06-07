using CompanyERP.Business.Exceptions;
using CompanyERP.Business.Interfaces;
using CompanyERP.Core.Models;
using CompanyERP.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyERP.Business.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        public void Add(Employee employee)
        {
            CompanyDataBase<Employee>.CompanyData.Add(employee);
        }

        public void Delete(int id)
        {   IDepartmentService departmentService = new DepartmentService();
            Employee? wanted = CompanyDataBase<Employee>.CompanyData.Find(x => x.ID == id);
            if (wanted != null)
            {
                Department? depwanted = departmentService.GetAll().Find(x => x.ID == wanted.Department?.ID);
                if (depwanted != null)
                {
                    depwanted.Employees.Remove(wanted);
                }
                CompanyDataBase<Employee>.CompanyData.Remove(wanted);
            }
            else
            {
                throw new EmployeeNotFoundException("Employee could not be found!");
            }
        }

        public List<Employee> GetAll()
        {
            return CompanyDataBase<Employee>.CompanyData;
        }
        public Employee Get(int id)
        {
            Employee? wanted = CompanyDataBase<Employee>.CompanyData.Find(x => x.ID == id);
            if (wanted != null)
            {
                return wanted;
            }
            throw new EmployeeNotFoundException(" Employee could not be found!");
        }
    }

       
    }


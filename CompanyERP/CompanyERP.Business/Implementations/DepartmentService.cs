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
    public class DepartmentService : IDepartmentService
    {
        public void Add(Department department)
        {
           CompanyDataBase<Department>.CompanyData.Add(department);
        }

        public void AddEmployee(int departmentId, int employeeId )
        {
            IEmployeeService employeeService = new EmployeeService();
            Employee? wanted = employeeService.GetAll().Find(x => x.ID == employeeId);
           Department? wantedD= CompanyDataBase<Department>.CompanyData.Find(x => x.ID == departmentId);
            double sumOfSalary = 0;
            foreach (Employee e in wantedD.Employees)
            {
                sumOfSalary += e.Salary;
            }
            if (wantedD != null && wanted != null)
            {

                if (wanted?.Department == null && wanted.HasBachelorDegree == wantedD.IsBachelorDegreeRequired && wantedD.Employees.Count + 1 <= wantedD.EmployeeLimit && wantedD.RequiredExperience <= wanted.Experience && wanted.Salary + sumOfSalary < wantedD.Budget)
                {

                    wantedD?.Employees.Add(wanted);
                    wanted.Department = wantedD;
                }
                else
                    throw new Exception("Employee could not be added!");
            }
            else
                throw new Exception("Employee or Department could not be found");


        }

        public void Delete(int id)
        {
           Department? wanted= CompanyDataBase<Department>.CompanyData.Find(x=> x.ID==id);
            if (wanted!=null)
            {
                IEmployeeService employeeService = new EmployeeService();
               
                foreach (var item in employeeService.GetAll().FindAll(x => x.Department?.ID==id ))
                {
                    item.Department = null;
                };
              wanted.Employees.Clear();
                CompanyDataBase<Department>.CompanyData.Remove(wanted);

            }
            else
            {
                throw new DepartmentNotFoundException("Department could not be found!");
            }
        }

        public Department Get(int id)
        {
            Department? wanted = CompanyDataBase<Department>.CompanyData.Find(x => x.ID == id);
           if(wanted!=null)
            {
                return wanted;
            }
            throw new DepartmentNotFoundException(" Department could not be found!");
        }

        public List<Department> GetAll()
        {
            return CompanyDataBase<Department>.CompanyData;
        }
    }
}

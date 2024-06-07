using CompanyERP.Business.Implementations;
using CompanyERP.Business.Interfaces;
using CompanyERP.Core.Models;
using System.Threading.Channels;

namespace CompanyERP.CA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDepartmentService departmentService=new DepartmentService();
            IEmployeeService employeeService=new EmployeeService();
            Department d1 = new Department() { Name = "D1", Budget = 2000, EmployeeLimit = 3, IsBachelorDegreeRequired = false };
            Department d2 = new Department() { Name = "D2", Budget = 1500, EmployeeLimit = 4, IsBachelorDegreeRequired = true };
            departmentService.Add(d1);
            departmentService.Add(d2);
            Employee e1 = new Employee() { Name="E1",Surname="S1",Salary=400, Experience=2, HasBachelorDegree=false};
            Employee e2 = new Employee() { Name = "E2", Surname = "S2", Salary = 400, Experience = 2, HasBachelorDegree = false };
            Employee e3 = new Employee() { Name = "E3", Surname = "S3", Salary = 500, Experience = 3 , HasBachelorDegree = false };
            Employee e4 = new Employee() { Name = "E4", Surname = "S4", Salary = 600, Experience = 4 , HasBachelorDegree = false };
            Employee e5 = new Employee() { Name = "E5", Surname = "S5", Salary = 900, Experience = 2 , HasBachelorDegree = false };
            Employee e6 = new Employee() { Name = "E6", Surname = "S6", Salary = 200, Experience = 2 , HasBachelorDegree = false };


            employeeService.Add(e1);
            employeeService.Add(e2);
            employeeService.Add(e3);
            employeeService.Add(e4);
            employeeService.Add(e5);
            employeeService.Add(e6);
            departmentService.AddEmployee(1, 1);
            departmentService.AddEmployee(1, 2);
            departmentService.AddEmployee(1, 3);
            employeeService.Delete(1);
            //departmentService.AddEmployee(2, 4);
            //departmentService.AddEmployee(2, 5);
            //departmentService.AddEmployee(2, 6);
            foreach (var item in employeeService.GetAll())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("================================");
            departmentService.Get(1).Employees.ForEach(e => Console.WriteLine(e));
           
            //foreach (var item in departmentService.Get(1).Employees)
            //{
            //    Console.WriteLine(item);
            //}
         
            //Console.WriteLine("==============================");
            //foreach (var item in employeeService.GetAll())
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}

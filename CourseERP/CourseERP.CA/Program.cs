using CourseERP.Business.Implementations;
using CourseERP.Business.Interfaces;
using CourseERP.Core.Models;

namespace CourseERP.CA
{
 
    internal class Program
    {
        static void Main(string[] args)
        {
            IStudentServices studentService = new StudentService();
            IGroupServices groupService = new GroupService();
             Group group1 = new Group() { Name="Information Tecnologies"};
             Group group2 = new Group() { Name="Computer Engineering"};
            groupService.Create(group1);
            groupService.Create(group2);
            Student s1 = new Student() { FullName = "Aytac Ehmedli", Grade = 60, Group=group1 };
            Student s2 = new Student() { FullName = "Aydan Mecidova", Grade = 70, Group=group1 };
            Student s3 = new Student() { FullName = "Sefer Muradov", Grade = 90, Group=group2 };
            Student s4 = new Student() { FullName = "Tahir Salahov", Grade = 85, Group=group2};
            studentService.Create(s1);
            studentService.Create(s2);
            studentService.Create(s3);
            studentService.Create(s4);
            foreach (var item in group1.Students)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("=============================");
            studentService.Remove(2);
            foreach (var item in group1.Students)
            {
                Console.WriteLine(item);
            }
        }
    }
}

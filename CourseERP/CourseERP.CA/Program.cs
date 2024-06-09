using CourseERP.Business.Implementations;
using CourseERP.Business.Interfaces;
using CourseERP.Core.Models;
using System.ComponentModel.Design;
using System.Net.Http.Headers;

namespace CourseERP.CA
{

    internal class Program
    {
        static void Main(string[] args)
        {
            IStudentServices studentService = new StudentService();
            IGroupServices groupService = new GroupService();
            //Group group1 = new Group() { Name = "Information Tecnologies" };
            //Group group2 = new Group() { Name = "Computer Engineering" };
            //groupService.Create(group1);
            //groupService.Create(group2);
            //Student s1 = new Student() { FullName = "Aytac Ehmedli", Grade = 60, Group = group1 };
            //Student s2 = new Student() { FullName = "Aydan Mecidova", Grade = 70, Group = group1 };
            //Student s3 = new Student() { FullName = "Sefer Muradov", Grade = 90, Group = group2 };
            //Student s4 = new Student() { FullName = "Tahir Salahov", Grade = 85, Group = group2 };
            //studentService.Create(s1);
            //studentService.Create(s2);
            //studentService.Create(s3);
            //studentService.Create(s4);
            //foreach (var item in group1.Students)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("=============================");
            //studentService.Remove(2);
            //foreach (var item in group1.Students)
            //{
            //    Console.WriteLine(item);
            //}
            label2:
            Console.WriteLine("1. Group opeartions");
            Console.WriteLine("2. Student opeartions");
            Console.WriteLine("3. Add student to the group");
            Console.WriteLine("0. Exit");
            int choice = Convert.ToInt32(Console.ReadLine());
            if(choice == 0)
            { 
                Console.WriteLine("Program exit");

            }
            else if (choice == 1)
            {
            label1:
                Console.WriteLine("1. Create Group");
                Console.WriteLine("2. Get Group");
                Console.WriteLine("3. GetAll Group");
                Console.WriteLine("4. Remove Group");
                Console.WriteLine("5. Exit");
               
                int choice1 = Convert.ToInt32(Console.ReadLine());
                switch(choice1)
                {
                    case 1:
                        Console.WriteLine("Enter Name:");
                        string name = Console.ReadLine();
                        groupService.Create(new Group() { Name = name });
                        Console.WriteLine("Group created");
                        goto label1;
                    case 2:
                        Console.WriteLine("Enter ID:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(groupService.Get(id));
                            goto label1;
                    case 3:
                        groupService.GetAll().ForEach(x => Console.WriteLine(x));
                        goto label1;

                    case 4:
                        Console.WriteLine("Enter ID:");
                        int id1 = Convert.ToInt32(Console.ReadLine());
                        groupService.Remove(id1);
                        goto label1;
                    case 5:
                        Console.WriteLine("Program exit");
                        goto label2;

                }

            }
            else if (choice == 2)
            {
            label3:
                Console.WriteLine("1. Create Student");
                Console.WriteLine("2. Get Student");
                Console.WriteLine("3. GetAll Students");
                Console.WriteLine("4. Remove Student");
                Console.WriteLine("5. Exit");

                int choice2 = Convert.ToInt32(Console.ReadLine());
                switch (choice2)
                {
                    case 1:
                        Console.WriteLine("Enter FullName:");
                        string fullName = Console.ReadLine();
                        Console.WriteLine("Enter Grade:");
                        int grade = Convert.ToInt32(Console.ReadLine());
                        studentService.Create(new Student() { FullName=fullName, Grade=grade });
                        Console.WriteLine("Student created");
                        goto label3;
                    case 2:
                        Console.WriteLine("Enter ID:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(studentService.Get(id));
                        goto label3;
                    case 3:
                        studentService.GetAll().ForEach(x => Console.WriteLine(x));
                        goto label3;

                    case 4:
                        Console.WriteLine("Enter ID:");
                        int id1 = Convert.ToInt32(Console.ReadLine());
                        studentService.Remove(id1);
                        goto label3;
                    case 5:
                        Console.WriteLine("Program exit");
                        goto label2;

                }
              


            }
            else if (choice == 3)
            {
                Console.WriteLine("Choose group:");
                groupService.GetAll().ForEach(x => Console.WriteLine($"{x.ID}- {x.Name}"));
                int groupId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Choose student:");
                studentService.GetAll().FindAll(x=> x.Group==null).ForEach(x => Console.WriteLine($"{x.ID}- {x.FullName}"));
                int studentId = Convert.ToInt32(Console.ReadLine());
                groupService.AddStudent(studentId, groupId);
                Console.WriteLine($"Student added to the group");
                goto label2;

            }

           

           

        }
    }
}

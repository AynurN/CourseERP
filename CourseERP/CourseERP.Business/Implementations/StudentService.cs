using CourseERP.Business.Exceptions;
using CourseERP.Business.Interfaces;
using CourseERP.Core.Models;
using CourseERP.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseERP.Business.Implementations
{
    public class StudentService : IStudentServices
    {
        public void Create(Student student)
        {
            CourseDataBase<Student>.CourseData.Add(student);
            student.Group?.Students.Add(student);
        }

        public Student? Get(int id)
        {
           Student? wanted= CourseDataBase<Student>.CourseData.Find(x => x.ID == id);
            if (wanted != null) return wanted;

            throw new StudentNotFoundException("Student could not be found!");
        }

        public List<Student> GetAll()
        {
           return CourseDataBase<Student>.CourseData;
        }

        public void Remove(int id)
        {
            IGroupServices groupServices=new GroupService();
            Student? wanted = CourseDataBase<Student>.CourseData.Find(x=> x.ID == id);
            if (wanted != null)
            {
                
                Group? groupwanted= groupServices.GetAll().Find(group => group.ID == wanted.Group?.ID);
                if(groupwanted != null)
                {
                    groupwanted.Students.Remove(wanted);
                }
              
                CourseDataBase<Student>.CourseData.Remove(wanted);

            }
               
            else
                throw new StudentNotFoundException("Student could not be found!");
        }
    }
}

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
    public class GroupService : IGroupServices
    {
     
        public void Create(Group group)
        {
            CourseDataBase<Group>.CourseData.Add(group);
        }

        public Group? Get(int id)
        {
            Group? wanted = CourseDataBase<Group>.CourseData.Find(x => x.ID == id);
            if (wanted != null) return wanted;

            throw new GroupNotFoundException("Student could not be found!");
        }

        public List<Group> GetAll()
        {
            return CourseDataBase<Group>.CourseData;
        }

        public void Remove(int id)
        {
            Group? wanted = CourseDataBase<Group>.CourseData.Find(x => x.ID == id);
            if (wanted != null)
            {
                CourseDataBase<Group>.CourseData.Remove(wanted);
                foreach (var student in CourseDataBase<Student>.CourseData.FindAll(x => x.Group?.ID == id))
                {
                    student.Group = null;
                }
            }
               
            else
                throw new GroupNotFoundException("Group could not be found!");
        }
        public void AddStudent(int studentid, int groupid)
        {
            IStudentServices student = new StudentService();
            Student? st = student.Get(studentid);
            Group? gr = CourseDataBase<Group>.CourseData.Find(x => x.ID == groupid);
            if (st != null && gr != null)
            {
                gr.Students.Add(st);
                st.Group = gr;
            }
            else
                throw new Exception("Student could not be added");
        }



    }
}

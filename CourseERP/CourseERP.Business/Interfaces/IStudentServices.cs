using CourseERP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseERP.Business.Interfaces
{
    public interface IStudentServices
    {
        void Create(Student student);
        void Remove(int id);    
        Student? Get(int id);
        List<Student> GetAll();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseERP.Core.Models
{
    public  class Student :BaseModel
    {
        private static int _id=0;
        public Student() {
            ++_id;
            ID = _id;
        }
        public string FullName { get; set; }
        public double Grade { get; set; }
        public Group? Group { get; set; }
        public override string ToString()
        {
            return Group != null ? $"{FullName} - {Group.Name} -{Grade}" : $"{FullName}  -{Grade}- Teacher hasn't been assigned";


        }

    }
}

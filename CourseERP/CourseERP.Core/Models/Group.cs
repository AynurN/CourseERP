using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseERP.Core.Models
{
    public class Group :BaseModel
    {
        private static int _id = 0;
        public Group()
        {
            ++_id;
            ID = _id;
            
        }
        public List<Student> Students { get; set; }

        public string Name { get; set; }
        public string Code { get { return $"{Name.Substring(0, 2).ToUpper() + ID}"; } }
        public override string ToString()
        {
            return $"{Name} -{Code}";
        }
    }
}

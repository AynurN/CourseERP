using CourseERP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseERP.Business.Interfaces
{
    public interface IGroupServices
    {
        void Create(Group group);
        void Remove(int id);
        Group? Get(int id);
        List<Group> GetAll();
    }
}

using RCTC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCTC.BLL.Interfaces
{
    interface StudentCRUD
    {
        public List<Student> FindAll();
        public bool Save(Student student);
        public Student FindByID(int UserID);
        public bool UpdateByID(Student student);
        public bool DeteteByID(int UserID);
        public List<Student> PaidStudents();
        public List<Student> UnpaidStudents();

    }
}

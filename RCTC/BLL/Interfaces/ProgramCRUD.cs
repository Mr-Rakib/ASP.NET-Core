using RCTC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCTC.BLL.Interfaces
{
    interface ProgramCRUD
    {
        public List<Programs> FindAll();
        public bool Save(Programs programs);
        public Programs FindByID(int PID);
        public bool UpdateByID(Programs programs);
        public bool DeteteByID(int PID);
    }
}

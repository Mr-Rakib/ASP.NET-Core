using RCTC.BLL.Interfaces;
using RCTC.DAL;
using RCTC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCTC.BLL.Services
{
    public class ProgramService : ProgramCRUD
    {

        ProgramRepository programRepository = new ProgramRepository();
        
        public List<Programs> FindAll()
        {
            return programRepository.FindAll().OrderBy(program => program.PName).ToList();
        }

        public Programs FindByID(int PID)
        {
            Programs program = FindAll().Find(program => program.PID == PID);
            return program;
        }

        public bool Save(Programs program)
        {
            if (FindByID(program.PID) == null)
            {
                return (programRepository.Save(program) != null) ? true : false;
            }
            else return false;
        }

        internal List<Programs> SearchAll(string value)
        {
            value = value.ToLower();

            List<Programs> programList = FindAll().Where(program => program.PID.ToString().Contains(value) || program.PName.ToLower().Contains(value)
             || program.PDescriptions.ToLower().Contains(value) || program.Cost.ToString().Contains(value) || program.Period.Contains(value)).ToList();

            return programList;
        }

        public bool UpdateByID(Programs program)
        {
            if (FindByID(program.PID) != null)
            {
                return (programRepository.Upadate(program) != null) ? true : false;
            }
            else return false;
        }

        public bool DeteteByID(int PID)
        {
            if (FindByID(PID) != null)
            {
                return (programRepository.Delete(PID)) ? true : false;
            }
            else return false;
        }

    }
}

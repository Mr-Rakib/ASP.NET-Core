using Microsoft.Data.SqlClient;
using RCTC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCTC.DAL
{
    public class ProgramRepository
    {

        DBConnection Database = new DBConnection();
        SQLCommands Sql = new SQLCommands();
        SqlConnection Connection;

        SqlCommand Command;
        SqlDataReader Reader;


        public List<Programs> FindAll()
        {
            List<Programs> programs = new List<Programs>();
            using (Connection = Database.Connect())
            {
                Command = new SqlCommand(Sql.Programs, Connection);
                using (Command)
                {
                    Connection.Open();
                    Reader = Command.ExecuteReader();
                    while (Reader.Read())
                    {
                        Programs program = new Programs();

                        program.PID             = Convert.ToInt32(Reader["PID"]);
                        program.PName           = Reader["Name"].ToString();
                        program.PDescriptions   = Reader["Descriptions"].ToString();
                        program.Cost            = Convert.ToInt32(Reader["Cost"]);
                        program.Period          = Reader["Period"].ToString();
                        

                        programs.Add(program);
                    }
                }
            }
            return programs;
        }



        internal Programs Save(Programs program )
        {
            //Student student = new Student();

            using (Connection = Database.Connect())
            {
                string query = Sql.InsertProgram(program);
                Command = new SqlCommand(query, Connection);
                using (Command)
                {
                    Connection.Open();
                    program = (Command.ExecuteNonQuery() > 0) ? program : null;
                }
            }
            return program;

        }

        internal Programs Upadate(Programs program)
        {
            using (Connection = Database.Connect())
            {
                string query = Sql.UpdateProgram(program);
                Command = new SqlCommand(query, Connection);
                using (Command)
                {
                    Connection.Open();
                    program = (Command.ExecuteNonQuery() > 0) ? program : null;
                }
            }
            return program;

        }



        internal bool Delete(int PID)
        {
            using (Connection = Database.Connect())
            {
                string query = Sql.DeleteProgram(PID);
                Command = new SqlCommand(query, Connection);
                using (Command)
                {
                    Connection.Open();
                    return (Command.ExecuteNonQuery() > 0) ? true : false;
                }
            }

        }
    }
}

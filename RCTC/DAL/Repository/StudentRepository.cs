using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RCTC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RCTC.DAL
{
    public class StudentRepository
    {
        DBConnection Database = new DBConnection();
        SQLCommands Sql = new SQLCommands();
        SqlConnection Connection;

        SqlCommand Command;
        SqlDataReader Reader;
        

        public List<Student> FindAll()
        {
            List<Student> Students = new List<Student>();
            using (Connection = Database.Connect())
            {
                Command = new SqlCommand(Sql.Students, Connection);
                using (Command)
                {
                    Connection.Open();
                    Reader = Command.ExecuteReader();
                    while (Reader.Read())
                    {
                        Student student = new Student();
                        student.UserID      = Convert.ToInt32(Reader["UserID"]);
                        student.FullName    = Reader["Name"].ToString();
                        student.FathersName = Reader["FName"].ToString();
                        student.MothersName = Reader["MName"].ToString();
                        student.Profession  = Reader["Profession"].ToString();
                        student.Profession  = Reader["Profession"].ToString();
                        student.Gender      = Reader["Gender"].ToString();
                        student.DateofBirth = DateTime.Parse( Reader["DateofBirth"].ToString());
                        student.Program     = Reader["Program"].ToString();
                        student.Cost        = Convert.ToInt32(Reader["Cost"]);
                        student.Paid        = Convert.ToInt32(Reader["Paid"]);
                        student.Contact     = Reader["Contact"].ToString();
                        student.Image       = Reader["Image"].ToString();
                        student.Address     = Reader["Address"].ToString();

                        Students.Add(student);
                    }
                }
            }
                return Students;
        }

        

        internal Student Save(Student student)
        {
            //Student student = new Student();

            using (Connection = Database.Connect())
            {
                string query = Sql.InsertStudent(student);
                Command = new SqlCommand(query, Connection);
                using (Command)
                {
                    Connection.Open();
                    student = (Command.ExecuteNonQuery() > 0) ? student : null;
                }
            }
            return student;

        }

        internal Student Upadate(Student student)
        {
            using (Connection = Database.Connect())
            {
                string query = Sql.UpdateStudent(student);
                Command = new SqlCommand(query, Connection);
                using (Command)
                {
                    Connection.Open();
                    student = (Command.ExecuteNonQuery() > 0) ? student : null;
                }
            }
            return student;

        }



        internal bool Delete(int UserID)
        {
            using (Connection = Database.Connect())
            {
                string query = Sql.DeleteStudent(UserID);
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

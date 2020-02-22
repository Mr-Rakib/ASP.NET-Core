using RCTC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCTC.DAL
{
    public class SQLCommands
    {
        // @Name, @FName, @MName, @Profession, @Gender, @DateofBirth, @Program, @Cost, @Paid, @Contact, @Image, @Address)


        public string Students = "select * from Students";
        public string Programs = "select * from Programs";


        public string InsertStudent (Student student)
        {
           string query =  "insert into Students values( '" + student.FullName + "','" + student.FathersName + "','" + student.MothersName + "','" + 
                            student.Profession + "','" + student.Gender + "','" + student.DateofBirth + "','" + student.Program + "'," + student.Cost 
                            + "," + student.Paid + ",'" + student.Contact + "','" + student.Image + "','" + student.Address + "' ) ";
            return query;
        }
        public string UpdateStudent(Student student)
        {
            string query = "Update Students set  Name='" + student.FullName + "', FName='" + student.FathersName + "',MName='" + student.MothersName +
                            "', Profession='" + student.Profession + "',Gender='" + student.Gender + "',DateofBirth='" + student.DateofBirth +
                            "',Program='" + student.Program + "',Cost=" + student.Cost + ",Paid=" + student.Paid + ",Contact='" + student.Contact +
                            "',Image='" + student.Image + "',Address='" + student.Address + "' where UserID = " + student.UserID;
            return query;
        }

        internal string DeleteStudent(int UserID)
        {
            return "Delete from Students where UserID =" + UserID;
        }

        internal string InsertProgram(Programs program)
        {
            string query = "insert into Programs values('"+ program.PName+"','"+program.PDescriptions+"',"+program.Cost
                                                                                                +",'"+program.Period+"')";
            return query;
        }

        internal string UpdateProgram(Programs program)
        {
            string query = "update Programs set Name= '" + program.PName + "', Descriptions='" + program.PDescriptions +
                "',Cost=" + program.Cost+ ",Period='" + program.Period + "' where PID="+program.PID;
            return query;
        }

        internal string DeleteProgram(int PID)
        {
            return "Delete from Programs where PID =" + PID;
        }
    }
}

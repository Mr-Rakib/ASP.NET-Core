using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using RCTC.BLL.Interfaces;
using RCTC.DAL;
using RCTC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RCTC.BLL
{
    public class StudentService : StudentCRUD
    {
        private StudentRepository studentRepository = new StudentRepository();
        private string FileDir = "wwwroot/";
        public List<Student> FindAll()
        {
            List<Student> Students = studentRepository.FindAll().OrderBy(student => student.FullName).ToList();
            return Students;
        }

        public Student FindByID(int UserID)
        {
            Student Student = FindAll().Find(student => student.UserID == UserID); 
            return Student;
        }

        public bool UpdateByID(Student student)
        {
            if (FindByID(student.UserID) != null)
            {
               if(student.ImageFile != null)
                {
                    if (student.Image != "demo.jpg")
                    {
                        deleteImage(student.Image);
                        student.Image = saveImage(student);
                    }

                }
                return (studentRepository.Upadate(student) != null ) ? true : false;
            }
            else return false;
        }

        internal List<Student> SearchAll(string value)
        {
            value = value.ToLower();

            List<Student> searchList = FindAll().Where(student => student.UserID.ToString().Contains(value) || student.FullName.ToLower().Contains(value)
          || student.FathersName.ToLower().Contains(value) || student.MothersName.ToLower().Contains(value) || student.Contact.Contains(value)
          || student.Address.ToLower().Contains(value) || student.Address.ToLower().Contains(value) || student.Cost.ToString().Contains(value)
          || student.Program.ToLower().Contains(value)).ToList();
            return searchList;
        }

        public bool DeteteByID(int UserID)
        {

            if (FindByID(UserID) != null)
            {
                string image = FindByID(UserID).Image;
                if ( image != "demo.jpg")
                {
                    deleteImage(image);
                }

                return (studentRepository.Delete(UserID)) ? true : false;
            }
            else return false;
        }

        internal List<Student> PaidSearchAll(string value)
        {
            value = value.ToLower();

            List<Student> searchList = PaidStudents().Where(student => student.UserID.ToString().Contains(value) || student.FullName.ToLower().Contains(value)
          || student.FathersName.ToLower().Contains(value) || student.MothersName.ToLower().Contains(value) || student.Contact.Contains(value)
          || student.Address.ToLower().Contains(value) || student.Address.ToLower().Contains(value) || student.Cost.ToString().Contains(value)
          || student.Program.ToLower().Contains(value)).ToList();
            return searchList;
        }

        internal List<Student> UnpaidSearchAll(string value)
        {
            value = value.ToLower();

            List<Student> searchList = UnpaidStudents().Where(student => student.UserID.ToString().Contains(value) || student.FullName.ToLower().Contains(value)
          || student.FathersName.ToLower().Contains(value) || student.MothersName.ToLower().Contains(value) || student.Contact.Contains(value)
          || student.Address.ToLower().Contains(value) || student.Address.ToLower().Contains(value) || student.Cost.ToString().Contains(value)
          || student.Program.ToLower().Contains(value)).ToList();
            return searchList;
        }

        public List<Student> PaidStudents()
        {
            List<Student> Students = studentRepository.FindAll().FindAll(student => student.Cost <= student.Paid)
                                                                .OrderBy(student => student.FullName).ToList();
            return Students;
        }

        public List<Student> UnpaidStudents()
        {
            List<Student> Students = studentRepository.FindAll().FindAll(student => student.Cost > student.Paid)
                                                      .OrderBy(student => student.FullName).ToList();
            return Students;
        }

        public bool Save(Student std)
        {
            if (std != null)
            {
                std.Image = saveImage(std); /// Set the File Path 
                Student student = studentRepository.Save(std);
                return (student == null) ? false : true;
            }
            else return false;
        }

  
        public string saveImage(Student student)
        {
            string uniqueFileName;
            if (student.ImageFile != null)
            {
                string uploadFolder = Path.Combine(FileDir ,"images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + student.ImageFile.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                FileStream createFile = new FileStream(filePath, FileMode.Create);
                using (createFile)
                {
                    student.ImageFile.CopyTo(createFile);

                }
            }
            else uniqueFileName = "demo.jpg";

            
            return uniqueFileName;
        }

        public bool deleteImage(string imagePath)
        {
            string uploadImageUrl = Path.Combine(FileDir , "images" , imagePath);
            if (File.Exists(uploadImageUrl))
            {
                File.Delete(uploadImageUrl);
                return true;
            }
            else return false;
        }


    }
}

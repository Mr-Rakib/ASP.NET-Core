using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RCTC.Models
{
    public class Student
    {

        [DisplayName("User ID")]
        public int UserID { get; set; }

        [Required()]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [Required()]
        [DisplayName("Father's Name")]
        public string FathersName { get; set; }

        [DisplayName("Mother's Name")]
        public string MothersName { get; set; }

        [Required()]
        [DisplayName("Profession")]
        public string Profession { get; set; }

        [Required()]
        [DisplayName("Gender")]
        public string Gender { get; set; }

        [DisplayName("Date Of Birth")]
        public DateTime DateofBirth { get; set; }

        [Required()]
        [DisplayName("Program")]
        public string Program { get; set; }

        [Required()]
        [DisplayName("Cost")]
        public int Cost { get; set; }

        [Required()]
        [DisplayName("Paid")]
        public int Paid { get; set; }

        [Required()]
        [DisplayName("Contact")]
        public string Contact { get; set; }

        [DisplayName("Image")]
        public string Image { get; set; }

        [Required()]
        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("Image")]
        public IFormFile ImageFile { get; set; }

    }
}

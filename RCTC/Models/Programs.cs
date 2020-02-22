using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RCTC.Models
{
    public class Programs
    {
        [Required()]
        [DisplayName("Program ID")]
        public int PID { get; set; }

        [Required()]
        [DisplayName("Program Name")]
        public string PName { get; set; }

        [Required()]
        [DisplayName("Program Descriptions")]
        public string PDescriptions { get; set; }

        [Required()]
        [DisplayName("Cost")]
        public int Cost { get; set; }

        [Required()]
        [DisplayName("Period")]
        public string Period { get; set; }
    }
}

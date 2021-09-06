using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_School294.Models
{
    public class Teachers
    {
        [Key]
        public int teacherId { get; set; }
        [Required]
        [Display(Name = "Teacher's Surname")]
        public string teacherSurname { get; set; }
        [Required]
        [Display(Name = "Teacher's Name")]
        public string teacherName { get; set; }
        [Required]
        [Display(Name = "Teacher's Date Of Birth")]
        public DateTime teacherDob { get; set; }
        [Required]
        [Display(Name = "Teacher Contact")]
        public string teacherContacts { get; set; }
        [Required]
        [Display(Name = "Teacher Contact2")]
        public string studentContact2 { get; set; }
    }
}

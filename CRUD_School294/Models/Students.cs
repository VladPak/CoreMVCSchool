using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_School294.Models
{
    public class Students
    {
        [Key]
        public int studentId { get; set; }
        [Required]
        [Display(Name = "Surname")]
        public string studentSurname { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string studentName { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime studentDob { get; set; }
        [Required]
        [Display(Name = "Class Letter")]
        public string studentClass { get; set; }
        [Required]
        [Display(Name = "Contact")]
        public string studentContacts { get; set; }
        [Display(Name = "Contact2")]
        public string studentContact2 { get; set; }
        [Display(Name =  "Contact3")]
        public string studentContact3 { get; set; }
    }
}

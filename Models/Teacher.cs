using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
using System.Linq;
using System.Threading.Tasks;



namespace NEW_MVC.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId{get; set;}
        [Required]
        public string? Subject_Name {get; set;}
        [Required]
        public string? Syllabus {get; set;}
        // [ForeignKey("Teacher")]
        // [Display(Name="Subject")]
        [Range(1,5)]
        public int credits{get; set;}
        // public int SubjectId {get; set;}

        // public virtual Subject {get; set;}
    }
}
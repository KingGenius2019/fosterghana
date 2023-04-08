using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Child
    {
          [Key]
        public int ld { get; set; }

        
        [StringLength(15)]

        public string ChildCode { get; set; } = string.Empty;

        [Required]
       [StringLength(50)]
       public string FirstName { get; set; } = string.Empty;

       public string MiddleName { get; set; }= null;
       
       [Required]
       [StringLength(50)] public string SurName { get; set; } = string.Empty;

        public string KnownAs { get; set; } = null;
       
        [Required] [StringLength(50)] public string Sex { get; set; } = string.Empty;

        [NotMapped] public string FullName => $"{FirstName} {SurName}";
        // public string? PhotoPath { get; set; }
        // public string? StudyPath { get; set; }
        // public string PoliceReportPath { get; set; }

        [Required]
           public DateTime DateOfBirth { get; set; }
     
        // [Required] 
        //  [DataType(DataType.Date)]
        // public DateOnly  Rescued { get; set; } 

        // [Required] 
        // [DataType(DataType.Date)]
        // public DateTOnly Intake { get; set; }

         [Required] 
         [StringLength(100)]public string PlaceOfBirth { get; set; } = string.Empty;

        [Required]
        [StringLength(80)]
        public string LegalRep { get; set; } = string.Empty;


         
        [StringLength(50)]
        public string Religion { get; set; } = string.Empty;

        [Required]
        [StringLength(80)]
        public string Region { get; set; } = string.Empty;

        
        [Required]
        [StringLength(120)]
        public string District {get; set;} = string.Empty;
        
       
     
       
     
       
        //   public int GetAge()
        //  {
        //     return DateOfBirth.CalculategeAge();
        //  }
    }
}
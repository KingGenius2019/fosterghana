using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using API.Entities.Identity;
using API.Extensions;

namespace API.Entities
{
    public class Child : NumberSequences
    {
        [Key]
        public int ld { get; set; }
        
        [StringLength(15)]
        public string DefaultCode { get; set; } = "FC";
        public string ChildCode => $"{DefaultCode}{SequenceNumbers}";
        [Required]
         public string FirstName { get; set; } = string.Empty;

        [StringLength(50)] 
        public string MiddleName { get; set; } = null;
        
        [StringLength(50)] 
        public string SurName { get; set; } = string.Empty;
        public string KnownAs { get; set; } = null;

        [StringLength(50)] public string Sex { get; set; } = string.Empty;

        public int Age {get; set;}

        [NotMapped] public string FullName => $"{FirstName} {SurName}";
        public string PhotoPath { get; set; }
             
         [DataType(DataType.Date)] public DateTime DateOfBirth { get; set; }

       
        [DataType(DataType.Date)]
        public DateTime DateFound { get; set; }

        [StringLength(50)]
        public string Religion { get; set; } = string.Empty;

        [StringLength(50)]
        public string PlaceOfBirth { get; set; } = string.Empty;

        [StringLength(80)]
        public string Region { get; set; } = string.Empty;

       
        [StringLength(150)]
        public string District { get; set; } = string.Empty;
        
        //   public int GetAge()
        //  {
        //     return DateOfBirth.CalculategeAge();
        //  }

        public ICollection<ChildPhotos> ChildPhotos {get; set;}
        public ICollection<ChildMedicalReport> ChildMedicalReports {get; set;}
        public ChildStudyReport ChildStudyReports {get; set;}
        public ICollection<ChildFamilyDetail> ChildFamilyDetails {get; set;}
        public ICollection<ReviewChild> ReviewChildren {get; set;}
        public ICollection<ChildApproval> ChildApprovals {get; set;}
    }
}
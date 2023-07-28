using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using API.Extensions;

namespace API.Data.Dtos
{
    public class ChildDto
    {
        public int ld { get; set; }
       
        public string ChildCode { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;

        public string MiddleName { get; set; } = null;

        public string SurName { get; set; } = string.Empty;

        public string KnownAs { get; set; } = null;

        [Required]public string Sex { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public int Age {get; set;}
        public string FullName {get; set;}
        public string PhotoPath { get; set; }
        
        // [Required]
        // public int Age { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateFound { get; set; }

        [Required]
        [StringLength(80)]
        public string Region { get; set; } = string.Empty;

        public string PlaceOfBirth { get; set; } = string.Empty;
 

        [Required]
        [StringLength(150)]
        public string District { get; set; } = string.Empty;

        //   public int GetAge()
        //  {
        //     return DateOfBirth.CalculategeAge();
        //  }

        public ICollection<ChildPhotoDto> ChildPhotos {get; set;}
        public ChildStudyReportDto ChildStudyReports {get; set;}
  
        
    }
}
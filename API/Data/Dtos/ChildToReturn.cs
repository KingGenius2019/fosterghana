using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos
{
    public class ChildToReturn
    {
        public int ld { get; set; }
        [Required]
        public string ChildCode { get; set; } = string.Empty;
        [Required]
        public string FirstName { get; set; } = string.Empty;

        public string MiddleName { get; set; } = null;

        [Required]
        public string SurName { get; set; } = string.Empty;

        public string KnownAs { get; set; } = null;

        [Required] public string Sex { get; set; } = string.Empty;

        public string FullName { get; set; }
        public string PhotoPath { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
         public DateTime DateFound { get; set; }

         public string PlaceOfBirth { get; set; } = string.Empty;

         [Required]
        public string Region { get; set; } = string.Empty;

        [Required]
        public string District { get; set; } = string.Empty;

        public ICollection<ChildPhotoDto> ChildPhotos { get; set; }
         public ChildStudyReportDto ChildStudyReports {get; set;}
         public ICollection<ChildFamilyDetailDto> ChildFamilyDetails {get; set;}
         public ICollection<ReviewChildDto> ReviewChildren {get; set;}
           public ICollection<ChildApprovalDto> ChildApprovals {get; set;}
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using API.Entities.Identity;

namespace API.Entities
{
    public class FosterApplications 
    {
        [Key]
        public int AppId {get; set;}
         public string DefaultAppCode { get; set; } = "FPC";
         public int SequenceNumber {get; set;}
         public string ApplicationCode => $"{DefaultAppCode}{SequenceNumber}";
        // public string ApplicationCode => $"{DefaultApplicationCode}{SequenceNumbers}";
         public string NatureOfApplication {get; set;}
         

        [StringLength(80)]
        public string TypeOfFosterCare {get; set;}

        [Range(0, 18)]
        public int PreferredMinChildAge {get; set;}

         [Range(1, 18)]
        public int PreferredMaxChildAge {get; set;}

          [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage="Start with capital letter, and Only letters and spaces allows")]
          [Required]
        public string PreferredChildXtics {get; set;}
       
        [Range(1, 7,
        ErrorMessage = "You can foster maximum of seven(7) children in one household")]
         public int NumberOfChildren {get; set;}

         [StringLength(10)]
         public string ChildAgeRange => $"{PreferredMinChildAge} - {PreferredMaxChildAge}";

        public bool ReadyToLetGofChild {get; set;}
        public bool AcceptChildWithSpecialNeeds {get; set;}

        public string SpecifyChildWithSpecialNeeds {get; set;}

        //This is use to get the details of the applicant
         [StringLength(150)]
         public string ApplicantUserName {get; set;}
         public string IsApplocationReviewed {get; set;}= "Under Review";
         public bool IsApplicationApproved {get; set;}

         public string UserId {get; set;}
        public AppUser User {get; set;}

        public ICollection<AssessApplication> AssessApplications {get; set;}
        public ICollection<ApplicantPhotos> ApplicantPhotos {get; set;}
        public ApplicantHomeStudyReport ApplicantHomeStudyReports {get; set;}
       public ICollection<ApplicationApproval> ApplicationApprovals {get; set;}

    }
}
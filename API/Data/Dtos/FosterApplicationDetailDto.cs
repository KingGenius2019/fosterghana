using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos
{
    public class FosterApplicationDetailDto
    {
          [Key]
        public int AppId {get; set;}
        
         public string ApplicationCode {get; set;}
        
         public string NatureOfApplication {get; set;}
         

        [StringLength(80)]
        public string TypeOfFosterCare {get; set;}

        [Range(0, 18)]
        public int PreferredMinChildAge {get; set;}

         [Range(1, 18)]
        public int PreferredMaxChildAge {get; set;}

          
        public string PreferredChildXtics {get; set;}
       
        public int NumberOfChildren {get; set;}
        
         public string ChildAgeRange {get; set;}

        public string ReadyToLetGofChild {get; set;}
        public string AcceptChildWithSpecialNeeds {get; set;}

        public string SpecifyChildWithSpecialNeeds {get; set;}
        public string IsApplocationReviewed {get; set;}= "Under Review";
         public bool IsApplicationApproved {get; set;}
         public string UserId {get; set;}

        //This is use to get the details of the applicant
         [StringLength(150)]
         public string ApplicantUserName {get; set;}
         public ICollection<ApplicantPhotoDto> ApplicantPhotos {get; set;}
        public ApplicantHomeStudyReportDTo ApplicantHomeStudyReports {get; set;}
        public ICollection<AssessApplicationDto> AssessApplications {get; set;}
        public ICollection<ApplicationApprovalDto> ApplicationApprovals {get; set;}

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos
{
    public class FosterApplicationDto
    {
       
       [Required] public string TypeOfFosterCare {get; set;}
        [Required] public string NatureOfApplication {get; set;}

        public string ApplicationCode {get; set;}
         [Required]public string PreferredChildXtics {get; set;}
         public int NumberOfChildren {get; set;}
        public int PreferredMinChildAge {get; set;}
        
        public int PreferredMaxChildAge {get; set;}

         [StringLength(10)]
        public string ChildAgeRange {get; set;}
        public string ReadyToLetGofChild {get; set;}
        public string AcceptChildWithSpecialNeeds {get; set;}
        public string SpecifyChildWithSpecialNeeds {get; set;}
              
        public string ApplicantUserName {get; set;}

         public string UserId {get; set;}
    }
}
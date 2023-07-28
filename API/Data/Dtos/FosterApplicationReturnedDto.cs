using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos
{
    public class FosterApplicationReturnedDto
    {
          [Key]
        public int AppId {get; set;}
        // public string DefaultApplicationCode { get; set; } = "FPC";
        public string ApplicationCode { get; set; }

         public string NatureOfApplication {get; set;}
        
        [Required] public string TypeOfFosterCare {get; set;}

         [Required] public string PreferredChildXtics {get; set;}
       
         public int NumberOfChildren {get; set;}
         

         [StringLength(10)]
         [Required] public string ChildAgeRange {get; set;}
          public bool ReadyToLetGofChild {get; set;}
          public bool AcceptChildWithSpecialNeeds {get; set;}

         public string SpecifyChildWithSpecialNeeds {get; set;}
         public string ApplicantUserName {get; set;}
         

          public string UserName {get; set;}
         public string UserId {get; set;}
    }
}
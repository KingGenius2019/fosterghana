using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos
{
    public class ApplicantEmploymentHistoryDto
    {
    //     [Key]
      public int OccId {get; set;}
      [Required] public string Occupation {get; set;}
       [Required]public string  NameOfEmployer {get; set;}
       [Required]public string  LocationOfEmployer {get; set;}
       [Required]public DateTime DateStarted {get; set;}
       [Required]public DateTime DateExited {get; set;}
       public string Responsibilities {get; set;}

        [EmailAddress]
         public string ApplicantUserName {get; set;}
       public string UserId {get; set;}
    }
}
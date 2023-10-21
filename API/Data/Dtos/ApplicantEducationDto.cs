using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos
{
    public class ApplicantEducationDto
    {
    //      [Key]
    //    public int EduId {get; set;}
        [Required]
        public string InstitutionName {get; set;}
         [Required] public string  Course {get; set;}
         [Required] public string  Qualification {get; set;}
         [Required] public DateTime YearOfGraduation {get; set;}

          [EmailAddress]
         public string ApplicantUserName {get; set;}
       
        public string UserId {get; set;}
    }
}
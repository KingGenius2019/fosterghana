using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class EducationHistoryDto
    {
                [Key]
       public int EduId {get; set;}
        [Required] public string InstitutionName {get; set;}
        [Required] public string  Course {get; set;}
        [Required] public string  Qualification {get; set;}
        [Required] public DateTime YearOfGraduation {get; set;}
         public string AppUserId {get; set;}
    }
}
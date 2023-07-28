using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos
{
    public class ApplicantEducationDto
    {
    //      [Key]
    //    public int EduId {get; set;}
        public string InstitutionName {get; set;}
        public string  Course {get; set;}
        public string  Qualification {get; set;}
        public DateTime YearOfGraduation {get; set;}
        public string UserId {get; set;}
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using API.Entities.Identity;

namespace API.Entities
{
    public class EducationalHistory
    {
        [Key]
       public int EduId {get; set;}
        public string InstitutionName {get; set;}
        public string  Course {get; set;}
        public string  Qualification {get; set;}
        public DateTime YearOfGraduation {get; set;}
        public string AppUserId {get; set;}
        public AppUser User {get; set;}

    }
}
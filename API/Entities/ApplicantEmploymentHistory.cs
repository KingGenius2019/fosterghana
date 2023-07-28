using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using API.Entities.Identity;

namespace API.Entities
{
    public class ApplicantEmploymentHistory
    {
        [Key]
       public int OccId {get; set;}
       public string Occupation {get; set;}
       public string  NameOfEmployer {get; set;}
       public string  LocationOfEmployer {get; set;}
       public DateTime DateStarted {get; set;}
       public DateTime DateExited {get; set;}
       public string Responsibilities {get; set;}
       public string UserId {get; set;}
       public AppUser User {get; set;}
    }
}
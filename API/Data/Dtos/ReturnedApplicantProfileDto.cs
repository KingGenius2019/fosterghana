using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos
{
    public class ReturnedApplicantProfileDto
    {
         [Key]
        public int ProId {get; set;}

        [Required]
        public string FName { get; set; }
        [Required]
        public string SName { get; set; }
        
        public DateTime DateofBirth {get; set;} = DateTime.UtcNow;

         public string FullName {get; set;}

        public int Age {get; set;}
       [EmailAddress] public string UserName { get; set; }

        public string AppUserId {get; set;}
    }
}
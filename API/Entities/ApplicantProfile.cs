using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using API.Entities.Identity;
using API.Extensions;

namespace API.Entities
{
    public class ApplicantProfile
    {
        [Key]
        public int ProId {get; set;}

        [StringLength(80)]

        public string FName { get; set; }
        [StringLength(80)] public string MName { get; set; }
        [StringLength(80)] public string SName { get; set; }

        public string Gender { get; set; }
        
         [DataType(DataType.Date)]
        public DateTime DateofBirth {get; set;} 
         [NotMapped]
        public string FullName => $"{FName} {SName}";

         [EmailAddress]
        public string UserName { get; set; }
         public int GetAge()
         {
            return DateofBirth.CalculategeAge();
         }
        public string AppUserId {get; set;}
        public AppUser User {get; set;}

        // public Placement Placements {get; set;}

    }
}
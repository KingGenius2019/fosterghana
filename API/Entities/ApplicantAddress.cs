using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using API.Entities.Identity;

namespace API.Entities
{
    public class ApplicantAddress
    {
        [Key]
        public int AddIn {get; set;}
        [StringLength(50)] public string Nationality {get; set;}
        
        [StringLength(80)]public string TownOfResidence {get; set;}
        public string PermanentHomeAddress {get; set;}
        public string LandMark {get; set;}
     
        [StringLength(150)]public string District  {get; set;}

        [StringLength(150)]public string Region {get; set;}

         public string ApplicantUserName {get; set;}
  
         public string AppUserId {get; set;}
        public AppUser User {get; set;}

    //    public Placement Placements {get; set;}

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos
{
    public class ApplicantAddressDto
    {
       
        [Required] public string Nationality {get; set;}
        
        [Required] public string TownOfResidence {get; set;}
        [Required] public string PermanentHomeAddress {get; set;}
        [Required] public string LandMark {get; set;}
        // public string PostalAddress {get; set;}
        [Required] public string District  {get; set;}

        [Required] public string Region {get; set;}

        [EmailAddress]
        public string ApplicantUserName {get; set;}
       
         public string AppUserId {get; set;}

    }
}
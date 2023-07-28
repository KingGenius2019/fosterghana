using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using API.Entities.Identity;

namespace API.Entities
{
    public class ApplicantContact
    {   
        [Key]
        public int ContId {get; set;}

        [Phone]
        [RegularExpression("^\\(?([0-9]{3})\\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
        ErrorMessage= "Please input proper phone number")]

         public string PrimaryContactNo {get; set;}

      
        public string SecondaryContactNo {get; set;}
        public string EmailAddress {get; set;}

        // [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$",
        // ErrorMessage= "Preference Correpondence ")]
        [Required]
        // [StringLength(30)]
        public string PreferenceCorrepondence {get; set;}

        [StringLength(200, MinimumLength = 3)]
         public string PostalAddress {get; set;}
       
        public string UserId {get; set;}
        public AppUser User {get; set;}
        
    }
}
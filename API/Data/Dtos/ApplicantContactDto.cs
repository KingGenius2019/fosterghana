using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos
{
    public class ApplicantContactDto
    {
         [Key]
        public int ContId {get; set;}
        [Required]public string PrimaryContactNo {get; set;}
        public string SecondaryContactNo {get; set;}
      
        [EmailAddress]public string EmailAddress {get; set;}
        [Required]public string PreferenceCorrepondence {get; set;}
               
        public string UserId {get; set;}
    }
}
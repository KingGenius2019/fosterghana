using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos
{
    public class ApplicantContactReturnDto
    {
         [Key]
        public int ContId {get; set;}
        [Required]public string PrimaryContactNo {get; set;}
        [Required]public string SecondaryContactNo {get; set;}
      
        [Required]    
        [EmailAddress]public string EmailAddress {get; set;}
        [Required]public string PreferenceCorrepondence {get; set;}
    //    public string PostalAddress {get; set;}
       
    }
}
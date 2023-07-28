using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos
{
    public class ApplicantProfileDto
   {
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required] public string FName { get; set; }
        public string MName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage= "First letter must capital and only letters are allowed") ]
 
        [StringLength(80)]
        [Required] public string SName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$",
        ErrorMessage= "First letter must capital and only letters are allowed")]
         [StringLength(80)]
        [Required]public string Gender { get; set; }
        public DateTime DateofBirth {get; set;} = DateTime.UtcNow;
        [EmailAddress]
        public string UserName { get; set; }
        
        public string AppUserId {get; set;}
    }
}
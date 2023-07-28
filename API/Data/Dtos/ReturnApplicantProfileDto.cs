using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos
{
    public class ReturnApplicantProfileDto
    {
        [Key]
        public int ProId {get; set;}
        [Required] public string FName { get; set; }
        public string MName { get; set; }
        [Required] public string SName { get; set; }
        [Required]public string Gender { get; set; }
        public DateTime DateofBirth {get; set;} = DateTime.UtcNow;
        public int Age {get; set;}
    }
}
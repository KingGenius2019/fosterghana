using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class AssessApplication
    {
        [Key]
        public int AssessId {get; set;}
       
        [Required]
        public string Comment {get; set;}
        public bool CanFoster {get; set;}
        
        [Required] public string Assessedby {get; set;}
      

        [Required]   public DateTime AssesDate {get; set;}
         [Required]   public DateTime DateAssesed {get; set;}=DateTime.Now;

           public int ApplyId {get; set;}
        public FosterApplications FosterApplications {get; set;}
    }
}
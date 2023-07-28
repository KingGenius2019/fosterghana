using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos
{
    public class ApplicantHomeStudyReportDTo
    {
        
         [Key]
        public int HomeId { get; set;}
        
        public string HomeDocumentTitle {get; set;}

        [Required]        
        public string FileName {get; set;}

         [Required]      
        public string DocumentPath {get; set;}
         public int ApplyId {get; set;}
        
    }
}
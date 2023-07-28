using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos
{
    public class ChildStudyReportDto
    {
         [Key]
        public int StudyId { get; set;}
          
        public string DocumentTitle {get; set;}

        [Required]        
        public string FileName {get; set;}

         [Required]      
        public string DocumentPath {get; set;}
        public int ChildId {get; set;}
    }
}
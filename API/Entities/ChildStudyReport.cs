using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class ChildStudyReport
    {
         [Key]
        public int StudyId { get; set;}
     
        [StringLength(80)]    
        public string DocumentTitle {get; set;}

        [Required]        
        [StringLength(80)]    
        public string FileName {get; set;}

         
         [StringLength(100)] 
         [Required]      
        public string DocumentPath {get; set;}
         public int ChildId {get; set;}
        public  Child Child {get; set;}
        public DateTime UploadDate {get; set;}=DateTime.Now;
    }
}
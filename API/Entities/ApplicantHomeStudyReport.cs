using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class ApplicantHomeStudyReport
    {
         [Key]
        public int HomeId { get; set;}
     
        [StringLength(80)]    
        public string HomeDocumentTitle {get; set;}

        [Required]        
        [StringLength(80)]    
        public string FileName {get; set;}

         
         [StringLength(100)] 
         [Required]      
        public string DocumentPath {get; set;}
         public int ApplyId {get; set;}
        public  FosterApplications FosterApplications {get; set;}
        public DateTime UploadDate {get; set;}=DateTime.Now;
    }
}
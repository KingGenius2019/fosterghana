using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class ChildMedicalReport
    {
         [Key]
        public int StudyId { get; set;}
     
        [StringLength(80)]    
        public string TitleOfDocument {get; set;}

        [Required]        
        [StringLength(80)]    
        public string FileName {get; set;}

         
         [StringLength(100)] 
         [Required]      
        public string MedicalDocPath {get; set;}
         public int ChildId {get; set;}
        public  Child Child {get; set;}
        public DateTime UploadDate {get; set;}=DateTime.Now;
    }
}
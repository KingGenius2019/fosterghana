using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class ChildPhotos
    {
        [Key]
        public int PhotoId { get; set;}

        [Required]        
        [StringLength(80)]    
        public string FileName {get; set;}

         
         [StringLength(100)] 
         [Required]      
        public string PhotoPath {get; set;}
        public bool IsMain {get; set;}
        public int ChildId {get; set;}
        public  Child Child {get; set;}
        public DateTime UploadDate {get; set;}=DateTime.Now;
    }
}
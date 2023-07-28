using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos
{
    public class ApplicantPhotoDto
    {
         [Key]
        public int PhotoId { get; set;}

        [Required]        
        [StringLength(100)]    
        public string PhotoName {get; set;}

         
         [StringLength(120)] 
         [Required]      
        public string PhotoPath {get; set;}
      
        // [ForeignKey]
        public int AppId {get; set;}
        
    }
}
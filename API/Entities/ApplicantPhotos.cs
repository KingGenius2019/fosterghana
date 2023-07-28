using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using API.Entities.Identity;

namespace API.Entities
{
    public class ApplicantPhotos
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
        public FosterApplications FosterApplications {get; set;}
        public DateTime DateUploded {get; set;}=DateTime.Now;
    }
}
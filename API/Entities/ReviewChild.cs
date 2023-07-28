using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class ReviewChild
    {
         [Key]
        public int ReviewId {get; set;}


        [Required]        
        public string Comment {get; set;}

        public bool CanGoIntoFoster {get; set;}
        public int ChildId {get; set;}
        public virtual Child Child {get; set;} 
        public string ReviewBy {get; set;}

        public DateTime ReviewDate {get; set;}=DateTime.Now;
    }
}
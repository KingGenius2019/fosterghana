using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using API.Entities.Identity;

namespace API.Entities
{
    public class Placement
    {
         [Key]
        public int PlaceId { get; set; }
       
        [StringLength(200)]
        [Required] public string Comment {get; set;}
        public DateTime MatchedDate { get; set; } = DateTime.Now;
        public bool TheApplicationAcepted {get; set;}

        public int ApplyId {get; set;}
        public FosterApplications Applications { get; set; }
        public int Childid {get; set;}
        public Child Children {get; set;}

        public string PlacementBy { get; set; }
       
    }
}
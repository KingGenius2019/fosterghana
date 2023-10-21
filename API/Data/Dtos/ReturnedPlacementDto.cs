using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos;

namespace API.Data
{
    public class ReturnedPlacementDto
    {
         [Key]
        public int PlaceId { get; set; }
       
        [StringLength(200)]
        [Required] public string Comment {get; set;}
        public DateTime MatchedDate { get; set; } = DateTime.Now;
        public bool TheApplicationAcepted {get; set;}
        public int ApplyId {get; set;}
        public int Childid {get; set;}
        public string PlacementBy { get; set; }

        public FosterApplicationDetailDto Applications { get; set;}

         public ChildToReturn Children {get; set;}
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class RegionsInGhana
    {
        [Key]public int RegionId {get; set;}
         public string RegionCode {get; set;}

        [Required] public string RegionName {get; set;}
        public ICollection<Districts> Districts {get; set;}
    }
}
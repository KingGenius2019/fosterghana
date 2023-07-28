using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Data.Dtos
{
    public class RegionsDto
    {
        [Key] public string RegionCode {get; set;}

        [Required] public string RegionName {get; set;}
        public ICollection<DistrictsDto> Districts {get; set;}

        // public ICollection<DistrictsDto> Districts {get; set;}
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos
{
    public class DistrictsDto
    {
         [Key] public string DistrictCode {get; set;}

        [Required]
        public string Districtname {get; set;}

         public string RegionCode {get; set;}
    }
}
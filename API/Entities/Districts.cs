using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Districts
    {
        [Key]public int DisId {get; set;}

        public string DistrictCode {get; set;}

        [Required]
        public string Districtname {get; set;}

        [Required] public string RegionCode {get; set;}

         public int RegionId {get; set;}
        public RegionsInGhana RegionsGhana {get; set;}
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos
{
    public class SearchFosterApplicationDto
    {
           [Key]
        public int AppId {get; set;}
        
         public string ApplicationCode {get; set;}
        
         public string NatureOfApplication {get; set;}
         

        [StringLength(80)]
        public string TypeOfFosterCare {get; set;}

        [Range(0, 18)]
        public int PreferredMinChildAge {get; set;}

         [Range(1, 18)]
        public int PreferredMaxChildAge {get; set;}

        public string PreferredChildXtics {get; set;}
       

    }
}
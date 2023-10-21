using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class ApplicantParams : DefaultParams
    {
        private const int MaxPageSize = 50;
     
         public string NatureOfApplication { get; set; }
             
        public string TypeOfFosterCare {get; set;}
        // public int MinAge { get; set; } = 0;
        // public int MaxAge { get; set; } = 19;
        public string PreferredSex {get; set;}
    }
}
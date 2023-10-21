using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class ChildParams : DefaultParams
    {
        private const int MaxPageSize = 50;   
        public int MinAge { get; set; } = 0;
        public int MaxAge { get; set; } = 19;
        public string Sex {get; set;}
        public int Age {get; set;}
    }
}
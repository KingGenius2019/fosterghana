using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos
{
    public class ChildFamilyDetailDto
    {
        //  public int Id {get; set;}
        [Required] public string NameOfRelation {get; set;}
        [Required] public string Relationship {get; set;}
        [Required] public string Status {get; set;}
        public bool IsCareGiver {get; set;}

         public int ChildId {get; set;}
    }
}
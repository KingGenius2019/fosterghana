using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class ChildFamilyDetail
    {
        public int Id {get; set;}
        public string NameOfRelation {get; set;}
        public string Relationship {get; set;}
        public string Status {get; set;}
        public bool IsCareGiver {get; set;}

         public int ChildId {get; set;}
        public  Child Child {get; set;}



    }
}
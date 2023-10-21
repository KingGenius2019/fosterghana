using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos
{
    public class SelectedChildDto
    {
        public int Id { get; set; }

        public string ChildCode { get; set; }
     
        public string FirstName { get; set; }
         public string PhotoPath { get; set; }
         public int Age {get; set;}
         public ICollection<ChildPhotoDto> ChildPhotos { get; set; }
        
    }
}
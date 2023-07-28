using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos
{
    public class ChildPhotoDto
    {
        [Key]
        public int PhotoId { get; set;}
        public string Title {get; set;}
        public string FileName {get; set;}
        public string PhotoPath {get; set;}
        public bool IsMain {get; set;}
        public int ChildId {get; set;}
    }
}
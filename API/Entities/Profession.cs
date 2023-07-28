using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Profession
    {
        [Key]  public string ProCode {get; set;}
        [Required] public string NameOfProfession {get; set;}
    }
}
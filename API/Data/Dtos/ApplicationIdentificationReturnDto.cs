using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos
{
    public class ApplicationIdentificationReturnDto
    {
         public int IdentId {get; set;}
        [Required]public string NationalIdType {get; set;}
        [Required]public string NationalIdNo {get; set;}
        [Required]public string IdentityPicture {get; set;}
    }
}
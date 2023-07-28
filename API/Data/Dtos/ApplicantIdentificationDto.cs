using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos
{
    public class ApplicantIdentificationDto
    {
        [Required]
        public string NationalIdType {get; set;}
        [Required]
        public string NationalIdNo {get; set;}

        //  [MaxFileSize(2 * 1024 * 1024)]
        // [AllowedExtensions(new[] {".jpg", ".png", ".jpeg"})]
        public IFormFile IdentityPicture {get; set;}
    }
}
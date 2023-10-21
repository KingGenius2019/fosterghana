using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using API.Entities.Identity;

namespace API.Entities
{
    public class ApplicationIdentification
    {
          [Key]     
        public int IdentId {get; set;}
         [StringLength(100)]public string NationalIdType {get; set;}
         [StringLength(150)]public string NationalIdNo {get; set;}
        public string IdentityPicture {get; set;}

        [EmailAddress]
         public string ApplicantUserName {get; set;}

        public string UserId {get; set;}
        public AppUser User {get; set;}
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos
{
    public class RegisterDto
    {
        [Required] 
       public string DisplayName {get; set;}
        [Required] 
        [EmailAddress]
        public string Email {get; set;}
        [Required] 
        [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$",
        ErrorMessage= "Password must have at least one capital letter, one symbol, one lower case letter, and should be at least six charactors" )]
        public string Password {get; set;}
    }
}
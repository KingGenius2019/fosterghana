using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
         public static string RetrieveEmailFromPrincipal(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.Email);
        }

         public static string RetrieveIdFromPrincipal(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

          public static string RetrieveUserNameFromPrincipal(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.GivenName).Value;
        }
       
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class UserManagerExtensions
    {
          public static async Task<AppUser> FindUserByClaimsPrincipleWithAddressAsync(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            var email = user.FindFirstValue(ClaimTypes.Email);

            return await input.Users.Include(x => x.ApplicantAddress)    
            .SingleOrDefaultAsync(x => x.Email == email);
        }


         public static async Task<AppUser> FindByEmailFromClaimsPrinciple(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
              var email = user.FindFirstValue(ClaimTypes.Email);

            return await input.Users.SingleOrDefaultAsync(x => x.Email == email);
        }

            public static async Task<AppUser> FindUserByClaimsPrincipleWithApplicantProfileAsync(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            var email = user.FindFirstValue(ClaimTypes.Email);

            return await input.Users.Include(x => x.ApplicantProfiles).FirstOrDefaultAsync(x => x.Email == email);
        }

        //     public static async Task<AppUser> FindUserByClaimsPrincipleWithAddressAsync(this UserManager<AppUser> input, ClaimsPrincipal user)
        // {
        //     var email = user.FindFirstValue(ClaimTypes.Email);

        //     return await input.Users.Include(x => x.ApplicantProfiles).SingleOrDefaultAsync(x => x.Email == email);
        // }
            public static async Task<AppUser> FindUserByClaimsPrincipleWithApplicantContactAsync(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            var email = user.FindFirstValue(ClaimTypes.Email);

            return await input.Users.Include(x => x.ApplicantContacts).FirstOrDefaultAsync(x => x.Email == email);
        }


           public static async Task<AppUser> FindUserByClaimsPrincipleWithApplicantIdentityAsync(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            var email = user.FindFirstValue(ClaimTypes.Email);

            return await input.Users.Include(x => x.ApplicationIdentification).SingleOrDefaultAsync(x => x.Email == email);
        }

            public static async Task<AppUser> FindUserByClaimsPrincipleWithApplicantEducationAsync(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            var email = user.FindFirstValue(ClaimTypes.Email);

            return await input.Users.Include(x => x.ApplicantEducations).FirstOrDefaultAsync(x => x.Email == email);
        }

             public static async Task<AppUser> FindUserByClaimsPrincipleWithApplicantReferencesAsync(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            var email = user.FindFirstValue(ClaimTypes.Email);

            return await input.Users.Include(x => x.ApplicantReferences).FirstOrDefaultAsync(x => x.Email == email);
        }
      

        public static async Task<AppUser> FindUserByClaimsPrincipleWithApplicantHouseholdAsync(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            var email = user.FindFirstValue(ClaimTypes.Email);

            return await input.Users.Include(x => x.ApplicantHouseholds).FirstOrDefaultAsync(x => x.Email == email);
        }

         public static async Task<AppUser> FindUserByClaimsPrincipleWithApplicanEmploymentHistorydAsync(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            var email = user.FindFirstValue(ClaimTypes.Email);

            return await input.Users.Include(x => x.ApplicantEmploymentHistories).FirstOrDefaultAsync(x => x.Email == email);
        }

    }
}
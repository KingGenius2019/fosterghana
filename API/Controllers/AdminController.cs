using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Data.Dtos;
using API.Entities.Identity;
using API.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AdminController : BaseApiController
    {
         private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbConext _dbConext;
        private readonly IMapper _mapper;
         public AdminController(UserManager<AppUser> userManager, ApplicationDbConext dbConext, IMapper mapper)
        {
            _mapper = mapper;
            _dbConext = dbConext;
      
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet("users")]
        public async Task<ActionResult> GetUsersWithRoles()
        {
            
            var users = await _userManager.Users
                .Include(r => r.UserRoles)
                 .ThenInclude(r => r.Role)
                .OrderBy(u => u.UserName)
                .Select(u => new
                {
                    // u.Id,
                    Username = u.UserName,
                    DisplayName = u.DisplayName,
                    Roles = u.UserRoles.Select(r => r.Role.Name).ToList()
                })
                .ToListAsync();

             return Ok(users);
        }

         [HttpGet("userdetail")]
         [Authorize]
        public async Task<ActionResult<GetUserDetailsDto>> GetDetailsOfUSer(string email)
        {
            // var userWithDetails = await _userManager.Users
              var userWithDetails = await _dbConext.Users
            //    .Include(x => x.FosterApplications)
              .Include(x => x.ApplicantProfiles)
               .Include(x => x.ApplicantAddress)
               .Include(x => x.ApplicantContacts)
                .Include(x => x.ApplicantEducations)
              .SingleOrDefaultAsync(u => u.UserName == email);
              return _mapper.Map<GetUserDetailsDto>(userWithDetails);
            //   var userDetails = await _userManager.FindByEmailFromClaimsPrinciple(User)
            //   .ToListAsync();
            //  return Ok(userWithDetails);
           
        }
    }
}
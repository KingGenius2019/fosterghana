using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Data.Dtos;
using API.Entities;
using API.Entities.Identity;
using API.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class ApplicantProfileController : BaseApiController
    {
       
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ApplicationDbConext _context;
        public ApplicantProfileController(UserManager<AppUser> userManager,  IMapper mapper, ApplicationDbConext context)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost]
         [Authorize]
         public async Task<ActionResult<ApplicantProfileDto>> AddAppilcantProfile(ApplicantProfileDto applicantProfile)
        {
             var curentuser = await _userManager.FindByEmailFromClaimsPrinciple(User);         
            if(curentuser == null){
                  return NotFound("The Applicant was not found");
             }
              var  curentuserId = curentuser.Id;
               var emailfromUsermanager = curentuser.Email;

             var appProfile =new ApplicantProfile
        {
          
            FName = applicantProfile.FName,
             MName = applicantProfile.MName,
            SName = applicantProfile.SName,
            Gender = applicantProfile.Gender,
            DateofBirth = applicantProfile.DateofBirth,
            UserName = emailfromUsermanager,
            
            AppUserId = curentuserId

        };

        var newpplicantprofile = _mapper.Map<ApplicantProfileDto>(applicantProfile);
            var result = await _context.ApplicantProfiles.AddAsync(appProfile);
            await _context.SaveChangesAsync();

             return  new ApplicantProfileDto
        {
          
            FName = applicantProfile.FName,
             MName = applicantProfile.MName,
            SName = applicantProfile.SName,
            Gender = applicantProfile.Gender,
            DateofBirth = applicantProfile.DateofBirth,
            UserName = emailfromUsermanager,
            
            AppUserId = curentuserId

    
         };
         
        }


         [Authorize]
         [HttpGet]
         public async Task<ActionResult<ReturnApplicantProfileDto>> GetApplicationProfileAsync()
        {
            
             var applicntProfile = await _userManager.FindUserByClaimsPrincipleWithApplicantProfileAsync(User);
                 return _mapper.Map<ReturnApplicantProfileDto>(applicntProfile.ApplicantProfiles);
            //  return Ok(applicntProfile);
            //  _mapper.Map<ApplicantProfileDto>(userProfile);
        }
    }

}
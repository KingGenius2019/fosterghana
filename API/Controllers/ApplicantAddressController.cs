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

    public class ApplicantAddressController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbConext _context;
        private readonly IMapper _mapper;
        public ApplicantAddressController(UserManager<AppUser> userManager,  IMapper mapper, ApplicationDbConext context)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
        }

        [Authorize]
        [HttpPost]
         public async Task<ActionResult<ApplicantAddressDto>> AddAppilcantAddress(ApplicantAddressDto applicantAddress)
        {
             var curentuser = await _userManager.FindByEmailFromClaimsPrinciple(User);         
            if(curentuser == null){
                  return NotFound("The Applicant was not found");
             }
              var  curentuserId = curentuser.Id;
               var emailfromUsermanager = curentuser.Email;

            var newApplicantAddress = new ApplicantAddress
            {
                    Nationality = applicantAddress.Nationality,
                    TownOfResidence = applicantAddress.TownOfResidence,
                    PermanentHomeAddress = applicantAddress.PermanentHomeAddress,
                    LandMark = applicantAddress.LandMark,
                    // PostalAddress = applicantAddress.PostalAddress,
                    District = applicantAddress.District,
                    Region = applicantAddress.Region,
              
                    AppUserId = curentuserId,
         
            };

            // if (IsNullorEmpty curentuser.ApplicantAddress.Count == 1)
            // {

            // }
              var newAppAddress = _mapper.Map<ApplicantAddressDto>(applicantAddress);
            var result = await _context.ApplicantAddress.AddAsync(newApplicantAddress);
            await _context.SaveChangesAsync();

            return new ApplicantAddressDto
            {
                    Nationality = applicantAddress.Nationality,
                    TownOfResidence = applicantAddress.TownOfResidence,
                    PermanentHomeAddress = applicantAddress.PermanentHomeAddress,
                    LandMark = applicantAddress.LandMark,
                    // PostalAddress = applicantAddress.PostalAddress,
                    District = applicantAddress.District,
                    Region = applicantAddress.Region,
                    
                    AppUserId = curentuserId,
         
            };
        }

         [Authorize]
         [HttpGet]
         public async Task<ActionResult<ApplicantAddressDto>> GetApplicationAddressAsync()
        {
            
             var applicantAddresstoReturn = await _userManager.FindUserByClaimsPrincipleWithAddressAsync(User);
                 return _mapper.Map<ApplicantAddressDto>(applicantAddresstoReturn.ApplicantAddress);
          
        }
    }
}
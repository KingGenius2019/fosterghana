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

namespace API.Controllers
{
    public class ApplicantEducationController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ApplicationDbConext _context;
        public ApplicantEducationController(UserManager<AppUser> userManager,  IMapper mapper, ApplicationDbConext context)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

          [Authorize]
        [HttpPost]
         public async Task<ActionResult<ApplicantEducationDto>> AddAppilcantAddress(ApplicantEducationDto applicantEducation)
        {
             var curentuser = await _userManager.FindByEmailFromClaimsPrinciple(User);         
            if(curentuser == null){
                  return NotFound("The Applicant was not found");
             }
              var  curentuserId = curentuser.Id;
               var emailfromUsermanager = curentuser.Email;

            var newApplicantEdu = new ApplicantEducation
            {
                    InstitutionName = applicantEducation.InstitutionName,
                    Course = applicantEducation.Course,
                    Qualification = applicantEducation.Qualification,
                    YearOfGraduation = applicantEducation.YearOfGraduation,
                                
                    UserId = curentuserId,
         
            };

       
              var newAppAddress = _mapper.Map<ApplicantEducationDto>(applicantEducation);
            var result = await _context.ApplicantEducations.AddAsync(newApplicantEdu);
            await _context.SaveChangesAsync();

            return new ApplicantEducationDto
            {
                    InstitutionName = applicantEducation.InstitutionName,
                    Course = applicantEducation.Course,
                    Qualification = applicantEducation.Qualification,
                    YearOfGraduation = applicantEducation.YearOfGraduation,
                                
                    UserId = curentuserId,
         
            };
        }

         [Authorize]
         [HttpGet]
         public async Task<ActionResult<ApplicantEducationDto>> GetApplicationEducationAsync()
        {
            
             var applicantEducationtoReturn = await _userManager.FindUserByClaimsPrincipleWithApplicantEducationAsync(User);
                 var applicantEduc = _mapper.Map<IEnumerable<ApplicantEducationDto>>(applicantEducationtoReturn.ApplicantEducations);
                return Ok(applicantEduc);
        }

        
    }
}
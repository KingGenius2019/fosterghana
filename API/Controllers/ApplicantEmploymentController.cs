using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

    public class ApplicantEmploymentController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbConext _context;
        private readonly IMapper _mapper;
        public ApplicantEmploymentController(UserManager<AppUser> userManager,  IMapper mapper, ApplicationDbConext context)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
        }

         [HttpPost]
         [Authorize(Policy="ApplicationRole")]
         public async Task<ActionResult<ApplicantEmploymentHistoryDto>> AddAppilcantEmployement(ApplicantEmploymentHistoryDto employment)
        {
            //  var curentuser = await _userManager.FindByEmailFromClaimsPrinciple(User);         
            // if(curentuser == null){
            //       return NotFound("The Applicant was not found");
            //  }
              var  UserId  = HttpContext.User?.Claims?.FirstOrDefault(u =>u.Type == ClaimTypes.NameIdentifier)?.Value;
              var emailforUsername = HttpContext.User.RetrieveEmailFromPrincipal();

             var appEmployment =new ApplicantEmploymentHistory
        {
          
            Occupation = employment.Occupation,
             NameOfEmployer = employment.NameOfEmployer,
            LocationOfEmployer = employment.LocationOfEmployer,
            DateStarted = employment.DateStarted,
            DateExited = employment.DateExited,
            Responsibilities = employment.Responsibilities,
             ApplicantUserName =    emailforUsername,      
            UserId = UserId

        };

        var newEMploymentHistory = _mapper.Map<ApplicantEmploymentHistoryDto>(employment);
            var result = await _context.ApplicantEmploymentHistories.AddAsync(appEmployment);
            await _context.SaveChangesAsync();

       return new ApplicantEmploymentHistoryDto
        {
          
            Occupation = employment.Occupation,
             NameOfEmployer = employment.NameOfEmployer,
            LocationOfEmployer = employment.LocationOfEmployer,
            DateStarted = employment.DateStarted,
            DateExited = employment.DateExited,
            Responsibilities = employment.Responsibilities,
            ApplicantUserName =    emailforUsername,  
            UserId = UserId

        };
         
        }

  
         [HttpGet]
         [Authorize(Policy="CanAccessApplicantDataRole")]

         public async Task<ActionResult<IEnumerable<ApplicantEmploymentHistoryDto>>> GetApplicationEmploymentAsync()
        {
             var appEmployment = await _userManager.FindUserByClaimsPrincipleWithApplicanEmploymentHistorydAsync(User);
                 var employMent = _mapper.Map<IEnumerable<ApplicantEmploymentHistoryDto>>(appEmployment.ApplicantEmploymentHistories);
                return Ok(employMent);
                    
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Data.Dtos;
using API.Entities;
using API.Entities.Identity;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Authorize]
    public class FosterApplicationsController : BaseApiController
    {
       
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkInterface _unitOfWork;
        private readonly ApplicationDbConext _context;

        public FosterApplicationsController(UserManager<AppUser> userManager,  IMapper mapper, IUnitOfWorkInterface unitOfWork, ApplicationDbConext context)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            
        }

        [HttpPost]
        public async Task<ActionResult<FosterApplications>> AddNewApplication(FosterApplicationDto application)
        {
            
              var currentUser = await _userManager.FindByEmailFromClaimsPrinciple(User);
            if (currentUser == null)
            {
                return NotFound("The user details missing");
            }
            

            var curentuserId = currentUser.Id;
            var userEmail = currentUser.Email;

            var fosterApplications = new FosterApplications  
            {
                TypeOfFosterCare = application.TypeOfFosterCare,
                PreferredMinChildAge = application.PreferredMinChildAge,
                NatureOfApplication = application.NatureOfApplication,
                 PreferredMaxChildAge = application.PreferredMaxChildAge,
                 PreferredChildXtics = application.PreferredChildXtics,
                NumberOfChildren = application.NumberOfChildren,
                ReadyToLetGofChild = application.ReadyToLetGofChild,
                AcceptChildWithSpecialNeeds = application.AcceptChildWithSpecialNeeds,
                SpecifyChildWithSpecialNeeds = application.SpecifyChildWithSpecialNeeds,
                ApplicantUserName = userEmail,
                UserId = curentuserId,
            };

             var newapply = _mapper.Map<FosterApplicationDto>(application);
              await _context.FosterApplications.AddAsync(fosterApplications);
             
              await _context.SaveChangesAsync();

            return new FosterApplications  
            {
                TypeOfFosterCare = application.TypeOfFosterCare,
                PreferredMinChildAge = application.PreferredMinChildAge,
                NatureOfApplication = application.NatureOfApplication,
                 PreferredMaxChildAge = application.PreferredMaxChildAge,
                 PreferredChildXtics = application.PreferredChildXtics,
                NumberOfChildren = application.NumberOfChildren,
                ReadyToLetGofChild = application.ReadyToLetGofChild,
                AcceptChildWithSpecialNeeds = application.AcceptChildWithSpecialNeeds,
                SpecifyChildWithSpecialNeeds = application.SpecifyChildWithSpecialNeeds,
                ApplicantUserName = userEmail,
                UserId = curentuserId,
            };

        }
        
           [HttpGet]
          [Authorize]
         public async Task<ActionResult<IEnumerable<FosterApplicationReturnedDto>>> GetAllApplications()
        {
            var applications = await _unitOfWork.FosterApplicationRepository.GetApplicantsAsync();
                    
            var returnapplicants = _mapper.Map<IEnumerable<FosterApplicationReturnedDto>>(applications);
                   
            return Ok(returnapplicants);
            // .ToListAsync();

        }

        [HttpGet("getuserapp")]
         [Authorize]
        public async Task<ActionResult<List<FosterApplicationReturnedDto>>> GetUserFosterApplication( [FromQuery]string userId)
        { 
          
             var currentuser = await _userManager.FindByEmailFromClaimsPrinciple(User);  
                  if(currentuser == null){
                  return NotFound("The user was not found");
             }
             userId = currentuser.Id;
               if(userId == null)
               {
                return NotFound("User curentuserId not found");
               }

                         
           var application = await _unitOfWork.FosterApplicationRepository.GetUserApplicationAsync(userId);
            var applicantionhere =  _mapper.Map<List<FosterApplicationReturnedDto>>(application);
                    
 
             return Ok(applicantionhere);
        }

         [HttpGet("{applyid}")]
        [Authorize]
        public async Task<ActionResult<FosterApplicationDetailDto>> GetApplicationWithId(int applyid)
        {
            var applicantion = await _unitOfWork.FosterApplicationRepository.GetApplicantByIdAsync(applyid);
            var applicantionFoster =  _mapper.Map<FosterApplicationDetailDto>(applicantion);
            
            return Ok(applicantionFoster);
        }

            [HttpPut("{applyid:int}")]
              [Authorize]
        public async Task<ActionResult> UpdateApplicant(int applyid, FosterApplicationDto applicationUpdateDto)
        {
            
                 var appToUpdate = await _unitOfWork.FosterApplicationRepository.GetApplicantByIdAsync(applyid);

                if (appToUpdate == null)
                    return NotFound($"The Application with Id was  not found");
             
                _mapper.Map(applicationUpdateDto, appToUpdate);

                 _unitOfWork.FosterApplicationRepository.Update(appToUpdate);

                  if (await _unitOfWork.SaveAllAsync()) return NoContent();

                  return BadRequest("Failed to update the application");
        }
       
    }
}
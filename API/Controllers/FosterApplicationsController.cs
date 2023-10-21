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
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    
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
         [Authorize(Policy="ApplicationRole")]
        public async Task<ActionResult<FosterApplications>> AddNewApplication(FosterApplicationDto application)
        {
            
            //   var currentUser = await _userManager.FindByEmailFromClaimsPrinciple(User);
            // if (currentUser == null)
            // {
            //     return NotFound("The user details missing");
            // }
            

            var theUserId = HttpContext.User.RetrieveIdFromPrincipal();
            var userEmail = HttpContext.User.RetrieveEmailFromPrincipal();

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
                UserId = theUserId,
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
                UserId = theUserId,
            };

        }
        
        [HttpGet]
        [Authorize(Policy="CanAccessFosterParentDataRole")]
         public async Task<ActionResult<IEnumerable<FosterApplicationReturnedDto>>> GetAllApplications([FromQuery]ApplicantParams applicantParams)
        {
            var applications = await _unitOfWork.FosterApplicationRepository.GetApplicantsAsync(applicantParams);
                    
            var returnapplicants = _mapper.Map<IEnumerable<FosterApplicationReturnedDto>>(applications);
                   
            // return Ok(returnapplicants);
            // .ToListAsync();
             Response.AddPaginationHeader(applications.CurrentPage, applications.PageSize, applications.TotalCount, applications.TotalPages);
            return Ok(returnapplicants);

        }

      

        [HttpGet("getuserapp")]
         [Authorize(Policy="ApplicationRole")]
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
        [Authorize(Policy="CanAccessApplicantDataRole")]
        public async Task<ActionResult<FosterApplicationDetailDto>> GetApplicationWithId(int applyid)
        {
            var applicantion = await _unitOfWork.FosterApplicationRepository.GetApplicantByIdAsync(applyid);
            var applicantionFoster =  _mapper.Map<FosterApplicationDetailDto>(applicantion);
            
            return Ok(applicantionFoster);
        }

        [HttpPut("{applyid:int}")]
        [Authorize(Policy="CanAccessApplicantDataRole")]
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

        
          [HttpPost("search")]
           [Authorize(Policy ="CanDoPlacement")]
        public async Task<ActionResult<List<SearchFosterApplicationDto>>> SearchByName([FromBody] string name)
        {
              
            if (string.IsNullOrWhiteSpace(name)) { return new List<SearchFosterApplicationDto>(); }
           var searchapplicantion = await _unitOfWork.FosterApplicationRepository.SearchApplicationAsync(name);
           var selectedapp = _mapper.Map<List<SearchFosterApplicationDto>>(searchapplicantion);
           return Ok(selectedapp);
      
        }
       
    }
}
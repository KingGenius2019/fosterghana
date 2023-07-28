using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Data.Dtos;
using API.Entities;
using API.Entities.Identity;
using API.Errors;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/application/{applyid}/assessapplication")]
    public class AssessApplicationController : BaseApiController
    {
        private readonly IUnitOfWorkInterface _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public AssessApplicationController(IUnitOfWorkInterface unitOfWork, UserManager<AppUser> userManager, ApplicationDbConext dbcontext, IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<AssessApplicationDto>> ApplicationAsessment(AssessApplicationDto assessApplication, int applyid)
        {
            
            //  getting the current login user;
            var asessingUser = await _userManager.FindByEmailFromClaimsPrinciple(User); 

            
             if(asessingUser == null){
                return NotFound(new ApiResponse(404, "The details of the current user assessing was not found"));
                //   return NotFound("The login details of the current user was not found");
             }
             var  usertoAssess = asessingUser.DisplayName;

             //getting the application
             var getApplication = await _unitOfWork.FosterApplicationRepository.GetApplicantByIdAsync(applyid);
             var applicationId = getApplication.AppId;


            var newapplication = new AssessApplication
            {
                
                Comment = assessApplication.Comment,
                 CanFoster = assessApplication.CanFoster,
                 ApplyId = applicationId,
                Assessedby = usertoAssess

            };
            getApplication.AssessApplications.Add(newapplication);
            
             var result = await _unitOfWork.AssessApplicationRepository.AddApplicationAsessmentAsync(newapplication);
            //   await _context.SaveChangesAsync();
            //  if (await _unitOfWork.SaveAllAsync()) return Ok();
            //     {
            //         return BadRequest("Probelem Adding Assesment");
            //     }
            
                      
             return new AssessApplicationDto
             {
                
                Comment = assessApplication.Comment,
                 CanFoster = assessApplication.CanFoster,
                 ApplyId = applicationId,
                Assessedby = usertoAssess
               
             };

            
        }

         [HttpGet("{assessId}")]
        public async Task<ActionResult<AssessApplicationDto>> GetAssessApplication(int assessId)
        {
           
            var applySpouse = await _unitOfWork.AssessApplicationRepository.GetApplicationAssementByIdAsync(assessId);
             var spouseAplicant = _mapper.Map<AssessApplicationDto>(applySpouse);
            return Ok(applySpouse);
        }

        
    }
}
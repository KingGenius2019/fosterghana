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
[Route("api/application/{applyid}/applicationapproval")]
    public class ApplicationApprovalController : BaseApiController
    {
        private readonly IUnitOfWorkInterface _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbConext _dbcontext;
        private readonly IMapper _mapper;
        public ApplicationApprovalController(IUnitOfWorkInterface unitOfWork, UserManager<AppUser> userManager, ApplicationDbConext dbcontext, IMapper mapper)
        {
            _mapper = mapper;
            _dbcontext = dbcontext;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

            [Authorize]
        [HttpPost]
        public async Task<ActionResult<ApplicationApprovalDto>> AddApplicationApprovalAsync(ApplicationApprovalDto applicationApproval, int applyid)
        {
            
            //  getting the current login user;
            var approvingUser = await _userManager.FindByEmailFromClaimsPrinciple(User); 

            
             if(approvingUser == null){
                return NotFound(new ApiResponse(404, "The details of the current user assessing was not found"));
               
             }
             var  userNametoApproval = approvingUser.DisplayName;

             //getting the application
             var getApplicationToApproval = await _unitOfWork.FosterApplicationRepository.GetApplicantByIdAsync(applyid);
             var applyIdToApproved = getApplicationToApproval.AppId;


            var newapplication = new ApplicationApproval
            {
                
                Comment = applicationApproval.Comment,
                 FosterParentApproved = applicationApproval.FosterParentApproved,
                 ApplyId = applyIdToApproved,
                ApprovedBy = userNametoApproval

            };
             getApplicationToApproval.ApplicationApprovals.Add(newapplication);
            
             var result = await _unitOfWork.ApplicationApprovalRepository.AddApplicationApprovalAsync(newapplication);
            //   await _context.SaveChangesAsync();
            //  if (await _unitOfWork.SaveAllAsync()) return Ok();
            //     {
            //         return BadRequest("Probelem Adding Assesment");
            //     }
            
                      
             return new ApplicationApprovalDto
             {
                
                Comment = applicationApproval.Comment,
                 FosterParentApproved = applicationApproval.FosterParentApproved,
                 ApplyId = applyIdToApproved,
                ApprovedBy = userNametoApproval
               
             };
            
        }

        [Authorize]
        [HttpGet]
         public async Task<ActionResult<IEnumerable<ApplicationApprovalDto>>> GetAllApplicationApprovalsAsync()
        {
            var approvalsReturned = await _unitOfWork.ApplicationApprovalRepository.GetApplicationApprovalsAsync();
                var returnApprovals = _mapper.Map<IEnumerable<ApplicationApprovalDto>>(approvalsReturned);
            return Ok(returnApprovals);

        }
    }
}
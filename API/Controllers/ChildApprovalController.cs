using System;
using System.Collections.Generic;
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

namespace API.Controllers
{
     [Route("api/children/{id}/approval")]
    public class ChildApprovalController : BaseApiController
    {
        private readonly IUnitOfWorkInterface _unitOfWork;
        private readonly ApplicationDbConext _dbcontext;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        public ChildApprovalController(IUnitOfWorkInterface unitOfWork, UserManager<AppUser> userManager, ApplicationDbConext dbcontext, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _dbcontext = dbcontext;
            _unitOfWork = unitOfWork;

        }

         [Authorize(Policy="CanReviewAndApprove")]
        [HttpGet("{chld}")]
        public async Task<ActionResult<ChildApprovalDto>> GetChildApprovalById(int chld)
        {
            var thchildpproved = await _unitOfWork.ChildApprovalRepository.GetChildApprovalByIdAsync(chld);
            return _mapper.Map<ChildApprovalDto>(thchildpproved);
            // return Ok(mychild);
        }


         [Authorize(Policy="CanReviewAndApprove")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChildApprovalDto>>> GetAllChildrenApprovalsAsync()
        {
            var approvalsReturned = await _unitOfWork.ChildApprovalRepository.GetChildApprovalsAsync();
                var returnApprovals = _mapper.Map<IEnumerable<ChildApprovalDto>>(approvalsReturned);
            return Ok(returnApprovals);

        }
   

        [Authorize(Policy="CanReviewAndApprove")]
        [HttpPost]
         public async Task<ActionResult<ReviewChildDto>> AddReviewChild(int id, ChildApproval childApproval)
        {
            //Get the child to approved
             var childToApproval = await _unitOfWork.ChildRepository.GetChildByIdAsync(id);
                
            if (childToApproval == null)
            {
                 return NotFound("The Child to approved was not found");
            }
               
            var childId = childToApproval.Id;

            //get the logged in user doing the reviewing
            var approvedBy = await _userManager.FindByEmailFromClaimsPrinciple(User);
             if (approvedBy == null)
             {
                 return NotFound("The user doing the matching was not found");
                 
             }
                
             var displayName = approvedBy.DisplayName;
                   
              var addAchildpproval = new ChildApproval 
              {
                    Comment= childApproval.Comment, 
                    ApprovalDate = childApproval.ApprovalDate,
                    ApprovedDate = childApproval.ApprovedDate,
                    ChildId = childId,
                    ApprovedBy = displayName,
                    
              };
            childToApproval.ChildApprovals.Add(childApproval);
            await _dbcontext.SaveChangesAsync();
            
            var addApproval = _mapper.Map<ChildApproval, ChildApprovalDto>(addAchildpproval);
            return Ok(addApproval);
         
        }
    }
}
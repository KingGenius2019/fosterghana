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
       [Route("api/children/{id}/reviewchild")]
    public class ReviewChildController : BaseApiController
    {
        private readonly IUnitOfWorkInterface _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbConext _dbcontext;
        private readonly IMapper _mapper;
        public ReviewChildController( IUnitOfWorkInterface unitOfWork, UserManager<AppUser> userManager, ApplicationDbConext dbcontext, IMapper mapper)
        {
            _mapper = mapper;
            _dbcontext = dbcontext;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        [Authorize(Policy="CanReviewAndApprove")]
        [HttpGet("{chld}")]
        public async Task<ActionResult<ChildToReturn>> GetChildReviewById(int chld)
        {
            var thchildToReview = await _unitOfWork.ReviewChildRepository.GetReviewChildByIdAsync(chld);
            return _mapper.Map<ChildToReturn>(thchildToReview);
            // return Ok(mychild);
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewChildDto>>> GetAllChildrenReviewsAsync()
        {
            var reviewsReturned = await _unitOfWork.ReviewChildRepository.GetReviewChildAsync();
                var returnReviews = _mapper.Map<IEnumerable<ReviewChildDto>>(reviewsReturned);
            return Ok(returnReviews);

        }
   

         [Authorize(Policy="CanReviewAndApprove")]
        [HttpPost]
         public async Task<ActionResult<ReviewChildDto>> AddReviewChild(int id, ReviewChild reviewChild)
        {
            //Get the child under review
             var childtoreview = await _unitOfWork.ChildRepository.GetChildByIdAsync(id);
                
            if (childtoreview == null)
            {
                 return NotFound("The Child to review was not found");
            }
               
            var childId = childtoreview.Id;

            //get the logged in user doing the reviewing
            var reviewBy = await _userManager.FindByEmailFromClaimsPrinciple(User);
             if (reviewBy == null)
             {
                 return NotFound("The user doing the matching was not found");
               
             }
              var iamDoingTheReview = reviewBy.DisplayName;
                  
              var addreviewchild = new ReviewChild 
              {
                Comment= reviewChild.Comment, 
              CanGoIntoFoster = reviewChild.CanGoIntoFoster,
             ChildId = childId,
             ReviewBy = iamDoingTheReview,
             
              };
            childtoreview.ReviewChildren.Add(addreviewchild);
            await _dbcontext.SaveChangesAsync();
 
            
            var addreview = _mapper.Map<ReviewChild, ReviewChildDto>(addreviewchild);
            return Ok(addreview);
         
        }
    }
}
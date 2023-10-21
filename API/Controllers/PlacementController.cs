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

    public class PlacementController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkInterface _unitOfWork;
        private readonly ApplicationDbConext _context;
        public PlacementController(UserManager<AppUser> userManager,  IMapper mapper, IUnitOfWorkInterface unitOfWork, ApplicationDbConext context)
        {
             _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

         [HttpGet]
         [Authorize(Policy="CanDoPlacement")]
        public async Task<ActionResult<IEnumerable<ReturnedPlacementDto>>> GetPlacement()
        {
             var getPlacement = await _unitOfWork.PlacementRepository.GetPlacementsAsync();
             
            var returnchildToApplicants = _mapper.Map<IEnumerable<ReturnedPlacementDto>>(getPlacement);
            
            return Ok(returnchildToApplicants);
            // .ToListAsync();

        }

         [HttpPost]
        [Authorize(Policy="CanDoPlacement")]
        public async Task<ActionResult<PlacementDto>> AddChildAsync(Placement placement)
        {
                var newPlacement =  _mapper.Map<PlacementDto>(placement);

                 // get the user doing the placement
                 var currentUser = await _userManager.FindByEmailFromClaimsPrinciple(User);
            if (currentUser == null)
            {
                return NotFound("The user doing the matching was not found");
            }
           
            var userDoingThePlacement = currentUser.DisplayName;

            placement.PlacementBy = userDoingThePlacement;
        
             var childToParent = await _unitOfWork.PlacementRepository.AddPlacementAsync(placement);
         
            return Ok(newPlacement);
        }

        [HttpGet("commondata")]
        [Authorize(Policy="CanDoPlacement")]
         public async Task<ActionResult<IEnumerable<FosterApplicationReturnedDto>>> GetAllApplicationsForCommomData()
        {
            var applications = await _unitOfWork.FosterApplicationRepository.GetApplicantsWithoutParamsAsync();
                    
            var returnapplicants = _mapper.Map<IEnumerable<FosterApplicationReturnedDto>>(applications);
                   
            return Ok(returnapplicants);
            // .ToListAsync();
            

        }
    }
}
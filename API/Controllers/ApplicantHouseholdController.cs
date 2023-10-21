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
    
    public class ApplicantHouseholdController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ApplicationDbConext _context;
        public ApplicantHouseholdController(UserManager<AppUser> userManager, IMapper mapper, ApplicationDbConext context)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

         [HttpPost]
         [Authorize(Policy="ApplicationRole")]
        public async Task<ActionResult<ApplicantHouseholdDto>> AddApplicantHouseHold(ApplicantHouseholdDto householdDto)
        {
           
              var curentuserId = HttpContext.User.RetrieveIdFromPrincipal();
            var emailForUser = HttpContext.User.RetrieveEmailFromPrincipal();

            var appHousehold = new ApplicantHousehold
            {
                MaritalStatus = householdDto.MaritalStatus,
                NoOfChildrenMale = householdDto.NoOfChildrenMale,
                NoOfChildrenFemale = householdDto.NoOfChildrenFemale,
                NoOfAdultFemale = householdDto.NoOfAdultFemale,
                NoOfAdultMale = householdDto.NoOfAdultMale,
                AgesAdult = householdDto.AgesAdult,
                AgesChildren = householdDto.AgesChildren,
                ApplicantUserName = emailForUser,
              
                UserId = curentuserId,

            };

             var newHousehold =  _mapper.Map<ApplicantHouseholdDto>(appHousehold);
             var houseHold = await _context.ApplicantHouseholds.AddAsync(appHousehold);
            await _context.SaveChangesAsync();

            return   new ApplicantHouseholdDto
            {
                MaritalStatus = householdDto.MaritalStatus,
                NoOfChildrenMale = householdDto.NoOfChildrenMale,
                NoOfChildrenFemale = householdDto.NoOfChildrenFemale,
                NoOfAdultFemale = householdDto.NoOfAdultFemale,
                NoOfAdultMale = householdDto.NoOfAdultMale,
                AgesAdult = householdDto.AgesAdult,
                AgesChildren = householdDto.AgesChildren,
                ApplicantUserName = emailForUser,
              
                UserId = curentuserId,

            };
        }

          [HttpGet]
          [Authorize(Policy="CanAccessApplicantDataRole")]
         public async Task<ActionResult<IEnumerable<ApplicantHouseholdDto>>> GetApplicationHouseHoldAsync()
        {
            
             var appHouse = await _userManager.FindUserByClaimsPrincipleWithApplicantHouseholdAsync(User);
                   var returnapplicants = _mapper.Map<IEnumerable<ApplicantHouseholdDto>>(appHouse.ApplicantHouseholds);
                 return Ok(returnapplicants);
    
        }
    }
    }

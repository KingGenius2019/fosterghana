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

    public class ApplicantReferenceController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ApplicationDbConext _context;
        public ApplicantReferenceController(UserManager<AppUser> userManager,  IMapper mapper, ApplicationDbConext context)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        
        [HttpPost]
         [Authorize(Policy="ApplicationRole")]
         public async Task<ActionResult<ApplicantReferenceDto>> AddAppilcantReference(ApplicantReferenceDto references)
        {
           
            var userIdfromUserManager = HttpContext.User.RetrieveIdFromPrincipal();
            
             var appReferee =new ApplicantReferences
        {
          
            NameOfReferee = references.NameOfReferee,
             RelationshipWithReferee = references.RelationshipWithReferee,
            DateOfRelationship = references.DateOfRelationship,
            RefereePhoneNumber = references.RefereePhoneNumber,
            RefereeEmail = references.RefereeEmail,
           
            
            UserId = userIdfromUserManager

        };

        var newpplicantreferee = _mapper.Map<ApplicantReferenceDto>(references);
            var result = await _context.ApplicantReferences.AddAsync(appReferee);
            await _context.SaveChangesAsync();

       return new ApplicantReferenceDto
        {
          
            NameOfReferee = references.NameOfReferee,
             RelationshipWithReferee = references.RelationshipWithReferee,
            DateOfRelationship = references.DateOfRelationship,
            RefereePhoneNumber = references.RefereePhoneNumber,
            RefereeEmail = references.RefereeEmail,
            // UserName = emailfromUsermanager,
            
            UserId = userIdfromUserManager

        };
         
        }


        
         [HttpGet]
         [Authorize(Policy="CanAccessApplicantDataRole")]
         public async Task<ActionResult<IEnumerable<ApplicantReferenceReturnDTo>>> GetApplicationReferenceAsync()
        {
            
             var applicntRef = await _userManager.FindUserByClaimsPrincipleWithApplicantReferencesAsync(User);
                 var refercesApp = _mapper.Map<IEnumerable<ApplicantReferenceReturnDTo>>(applicntRef.ApplicantReferences);
                return Ok(refercesApp);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Data.Dtos;
using API.Entities.Identity;
using API.Entities;
using API.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
     [Authorize]
    public class ApplicantContactController : BaseApiController
    {
       
        private readonly ApplicationDbConext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public ApplicantContactController(UserManager<AppUser> userManager,  IMapper mapper, ApplicationDbConext context)
        {
            _mapper = mapper;
            _userManager = userManager;
            _context = context;
        }

         
        [HttpPost]
         public async Task<ActionResult<ApplicantContactDto>> AddAppilcantContact(ApplicantContactDto applicantContact)
        {
             var curentuser = await _userManager.FindByEmailFromClaimsPrinciple(User);         
            if(curentuser == null){
                  return NotFound("The user was not found");
             }
              var  curentuserId = curentuser.Id;
               var emailfromUsermanager = curentuser.Email;
                 if(emailfromUsermanager == null){
                  return NotFound("The email of the user was not found");
             }

            var newApplicantContact = new ApplicantContact
            {
                    PrimaryContactNo = applicantContact.PrimaryContactNo,
                    SecondaryContactNo = applicantContact.SecondaryContactNo,
                    EmailAddress = emailfromUsermanager,
                    PreferenceCorrepondence = applicantContact.PreferenceCorrepondence,
                    PostalAddress = applicantContact.PostalAddress,
                  
                    UserId = curentuserId,
         
            };


              var newAppContact = _mapper.Map<ApplicantContactDto>(applicantContact);
            var result = await _context.ApplicantContacts.AddAsync(newApplicantContact);
            await _context.SaveChangesAsync();

            return new ApplicantContactDto
            {
                    PrimaryContactNo = applicantContact.PrimaryContactNo,
                    SecondaryContactNo = applicantContact.SecondaryContactNo,
                    EmailAddress = emailfromUsermanager,
                    PreferenceCorrepondence = applicantContact.PreferenceCorrepondence,
                    PostalAddress = applicantContact.PostalAddress,
                    UserId = curentuserId,
         
            };
        }

       
         [HttpGet]
         public async Task<ActionResult<ApplicantContactReturnDto>> GetApplicationContactAsync()
        {
            
             var applicantContactReturn = await _userManager.FindUserByClaimsPrincipleWithApplicantContactAsync(User);
                 return _mapper.Map<ApplicantContactReturnDto>(applicantContactReturn.ApplicantContacts);
          
        }
    }
}
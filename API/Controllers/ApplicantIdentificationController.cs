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

    public class ApplicantIdentificationController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IFileStorageService _fileStorageService;
        private readonly IMapper _mapper;
        private readonly ApplicationDbConext _context;
        public ApplicantIdentificationController(UserManager<AppUser> userManager, IFileStorageService fileStorageService, IMapper mapper, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor, ApplicationDbConext context)
        {
            _context = context;
            _mapper = mapper;
            _fileStorageService = fileStorageService;
            _userManager = userManager;
        }

      
        [HttpPost]
        [Authorize(Policy="CanAccessApplicantDataRole")]
        public async Task<ActionResult> AddIdentification([FromForm]ApplicantIdentificationDto identificationDto)
        {
             var currentuser = await _userManager.FindByEmailFromClaimsPrinciple(User);         
            if(currentuser == null){
                  return NotFound("The Login Account was not found");
             }
            var containerName = "Identification";
            currentuser.ApplicationIdentification = _mapper.Map<ApplicationIdentification>(identificationDto);
            
            var filtosave = await _fileStorageService.SaveFile(containerName, identificationDto.IdentityPicture);
             if (identificationDto.IdentityPicture == null)
            {
                return NotFound("The file content is empty");
            }

            if (identificationDto.IdentityPicture != null)
            {
                currentuser.ApplicationIdentification.IdentityPicture = await _fileStorageService.SaveFile(containerName, identificationDto.IdentityPicture);
            }

            _context.Add(currentuser.ApplicationIdentification);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        
         [HttpGet]
         [Authorize(Policy="CanAccessApplicantDataRole")]
        public async Task<ActionResult<ApplicationIdentificationReturnDto>> GetIdentification()
        {
            
            var user = await _userManager.FindUserByClaimsPrincipleWithApplicantIdentityAsync(User);

            return _mapper.Map<ApplicationIdentificationReturnDto>(user.ApplicationIdentification);
            
            
        }
    }
}
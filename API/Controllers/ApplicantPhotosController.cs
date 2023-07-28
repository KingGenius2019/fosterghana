using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Data.Dtos;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/application/{applyid}/applicantphotos")]
    public class ApplicantPhotosController : BaseApiController
    {
        private readonly string[] AcceptedFiles = new[] { ".jpg", ".png", ".tif" };
        private readonly IWebHostEnvironment _host;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWorkInterface _unitOfWork;
        private readonly ApplicationDbConext _dbConext;
           public ApplicantPhotosController(IWebHostEnvironment host, IUnitOfWorkInterface unitOfWork, ApplicationDbConext dbConext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _dbConext = dbConext;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _host = host;
        }

           [HttpGet("{id}", Name = "GetApplicantPhoto")]
         public async Task<IActionResult> GetApplicantPhoto(int id)
        {
            var apphotoFromRepo = await _unitOfWork.FosterApplicationRepository.GetApplicantPhotoAsync(id);

            var appphoto = _mapper.Map<ApplicantPhotoDto>(apphotoFromRepo);

            return Ok(appphoto);
        }

         [HttpPost]
         public async Task<ActionResult<ApplicantPhotoDto>> AddPhoto(int applyid, [FromForm] IFormFile file)
        {
            var applicant = await _unitOfWork.FosterApplicationRepository.GetApplicantByIdAsync(applyid);
            if (applicant == null)
                return NotFound();

            var appId = applicant.AppId;

            var extension = Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            if (file == null) return BadRequest("Please Selecet a file");
            if (file.Length == 0) return BadRequest("The File Your Select is Empty");
             if (!AcceptedFiles.Any(s => s == Path.GetExtension(file.FileName))) return BadRequest("The Selected File is Not Allowed");
            var folderName = Path.Combine(_host.WebRootPath, "ApplicantImages");
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
            string photoPath = Path.Combine(folderName, fileName);

            using (var stream = new FileStream(photoPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var url = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
            var photoPathDb = Path.Combine(url, "ApplicantImages", fileName).Replace("\\", "/");
            var applicantphoto = new ApplicantPhotos { PhotoPath = photoPathDb, PhotoName = fileName, AppId=appId };

         
            applicant.ApplicantPhotos.Add(applicantphoto);
            
            
            // if (await _unitOfWork.SaveAllAsync()) return NoContent();

            // return BadRequest("Failed to set main photo");

            await _dbConext.SaveChangesAsync();
            // return Ok(_mapper.Map<Photo, PhotoDto>(photo)); 
            var photoToReturn = _mapper.Map<ApplicantPhotos, ApplicantPhotoDto>(applicantphoto);
            return CreatedAtRoute("GetApplicantPhoto", new { applyid = applicant.AppId, id = applicantphoto.PhotoId }, photoToReturn);


        }
    }
}
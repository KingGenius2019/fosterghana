using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Data.Dtos;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers

{
    [Route("api/application/{applyid}/homestudyreport")]
    public class ApplicantHomeStudyController : BaseApiController
    {
        
        private readonly string[] AcceptedFiles = new[] { ".pdf", ".doc"};
        private readonly IUnitOfWorkInterface _unitOfWork;
        private readonly ApplicationDbConext _dbConext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _host;
        public ApplicantHomeStudyController(IWebHostEnvironment host, IUnitOfWorkInterface unitOfWork, ApplicationDbConext dbConext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _host = host;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _dbConext = dbConext;
            _unitOfWork = unitOfWork;
        }

        [Authorize(Policy="CanDoFileUpload")]
        [HttpGet("{id}", Name = "gethomestudy")]
         public async Task<IActionResult> GetHomestudyReport(int homeid)
        {
            var apphotoFromRepo = await _unitOfWork.FosterApplicationRepository.GetApplicantHomeStudyAsync(homeid);

            var appphoto = _mapper.Map<ApplicantPhotoDto>(apphotoFromRepo);

            return Ok(appphoto);
        }


        [Authorize(Policy="CanDoFileUpload")]
         [HttpPost]
         public async Task<ActionResult<ApplicantHomeStudyReportDTo>> AddHomeStudyReport(int applyid, [FromForm] IFormFile file)
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
            var folderName = Path.Combine(_host.WebRootPath, "ApplicantHomeStudyReports");
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
            var photoPathDb = Path.Combine(url, "ApplicantHomeStudyReports", fileName).Replace("\\", "/");
            
            var applicantHomestudy = new ApplicantHomeStudyReport { DocumentPath = photoPathDb, FileName = fileName, ApplyId=appId };

         
        //     applicant.ApplicantPhotos.Add(applicantphoto);
            
            
            // if (await _unitOfWork.SaveAllAsync()) return NoContent();

            // return BadRequest("Failed to set main photo");

            // await _dbConext.SaveChangesAsync();

            var result = await _dbConext.ApplicantHomeStudyReports.AddAsync(applicantHomestudy);
         
               await _unitOfWork.SaveAllAsync();
          
            var photoToReturn = _mapper.Map<ApplicantHomeStudyReport, ApplicantHomeStudyReportDTo>(applicantHomestudy);
             return CreatedAtRoute("gethomestudy", new { applyid = applicant.AppId, id = applicantHomestudy.HomeId }, photoToReturn);

       
    }
 }
}
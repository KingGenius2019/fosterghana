using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
     [Route("api/children/{chld}/childstudyreport")]
    public class ChildStudyReportController : BaseApiController
    {
        private readonly IWebHostEnvironment _host;
        private readonly IChildInterface _childRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
      
         private readonly string[] AcceptedFiles = new[] { ".pdf", ".docx" };
        public ChildStudyReportController(IWebHostEnvironment host, IChildInterface childRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _childRepository = childRepository;
        
            _host = host;
        }

         [HttpGet("{id}", Name = "GetChildStudyReport")]
         [Authorize(Policy ="CanDoFileUpload")]
        public async Task<IActionResult> GetPhoto(int id)
        {
            var photoFromRepo = await _childRepository.GetPhotoAsync(id);

            var photo = _mapper.Map<ChildStudyReportDto>(photoFromRepo);

            return Ok(photo);
        }

        [HttpPost]
        [Authorize(Policy ="CanDoFileUpload")]
        public async Task<ActionResult<ChildStudyReportDto>> AddPhoto(int chld, [FromForm]IFormFile file)
        {
            //get the child
            var thechild = await _childRepository.GetChildByIdAsync(chld);
            if (thechild == null)
                return NotFound("The Child Adding his/her Photos was not found");

           var childid = thechild.Id;

            var extension = Path.GetExtension(file.FileName);
            // using guid to generate file names
           var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            
            if (file == null) return BadRequest("Please Select a file");
            if (file.Length == 0) return BadRequest("The File Your Select is Empty");

            // check your accepted files
            if (!AcceptedFiles.Any(s => s == Path.GetExtension(file.FileName)))
             return BadRequest("The Selected File is Not Allowed");

            // create folder to save the images if it doesnt exist
            var folderName = Path.Combine(_host.WebRootPath, "ChildStudyReports");
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
             string documentPath = Path.Combine(folderName, fileName);

              using (var stream = new FileStream(documentPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var url = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
            var dochPathtoDb = Path.Combine(url, "ChildStudyReports", fileName ).Replace("\\", "/");
            var childstudyreports = new ChildStudyReport {DocumentPath = dochPathtoDb, FileName = fileName, ChildId= childid};
     
              thechild.ChildStudyReports = _mapper.Map<ChildStudyReport>(childstudyreports);
   
              await _childRepository.SaveAllAsync();
   
            var documentToReturn = _mapper.Map<ChildStudyReport, ChildStudyReportDto>(childstudyreports);
            return CreatedAtRoute("GetChildStudyReport", new { chld = thechild.Id, id = childstudyreports.ChildId}, documentToReturn);
            

        }

    }
}
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
 [Route("api/children/{chld}/childphotos")] 
    public class ChildPhotosController : BaseApiController
    {
        
        private readonly IWebHostEnvironment _host;
        private readonly IChildInterface _childRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string[] AcceptedFiles = new[] { ".jpg", ".png", ".tif" };
        public ChildPhotosController(IWebHostEnvironment host, IChildInterface childRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _childRepository = childRepository;
            _host = host;
        }

         [HttpGet("{id}", Name = "GetPhoto")]
         [Authorize(Policy="CanDoFileUpload")]
        public async Task<IActionResult> GetPhoto(int id)
        {
            var photoFromRepo = await _childRepository.GetPhotoAsync(id);

            var photo = _mapper.Map<ChildPhotoDto>(photoFromRepo);

            return Ok(photo);
        }

        [HttpPost]
        [Authorize(Policy="CanDoFileUpload")]
        public async Task<ActionResult<ChildPhotos>> AddPhoto(int chld, [FromForm]IFormFile file)
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
            var folderName = Path.Combine(_host.WebRootPath, "ChildImages");
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
            var photoPathDb = Path.Combine(url, "ChildImages", fileName ).Replace("\\", "/");
            var photo = new ChildPhotos {PhotoPath = photoPathDb, FileName = fileName, ChildId= childid};
     

               if(thechild.ChildPhotos.Count == 0) {
                photo.IsMain = true;
            }
            thechild.ChildPhotos.Add(photo);

            await _childRepository.SaveAllAsync();
   
            var documentToReturn = _mapper.Map<ChildPhotos, ChildPhotoDto>(photo);
            return CreatedAtRoute("GetPhoto", new { chld = thechild.Id, id = photo.ChildId}, documentToReturn);
            

        }

    }
}
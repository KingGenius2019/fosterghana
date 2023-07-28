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
    [Route("api/children/{chld}/childfamilydetail")]
    public class ChildFamilyDetailController : BaseApiController
    {
        private readonly IUnitOfWorkInterface _unitOfWorkI;
        private readonly IMapper _mapper;
        public ChildFamilyDetailController(IUnitOfWorkInterface unitOfWorkI, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWorkI = unitOfWorkI;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ChildFamilyDetailDto>> AddNewDetailsOfChildAsync (ChildFamilyDetail childFamily)
        {
            var newchildfamily =  _mapper.Map<ChildFamilyDetailDto>(childFamily);
            var familyAdded = await _unitOfWorkI.ChildFamilyDetailRepository.AddChildFamilyDetailAsync(childFamily);
            return Ok(familyAdded);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ChildFamilyDetailDto>> GetChildFamilyByIdAsync(int id)
        {
            var familyById = await _unitOfWorkI.ChildFamilyDetailRepository.GetChildFamilyDetailByIdAsync(id);
            var familOfChild =  _mapper.Map<ChildFamilyDetailDto>(familyById);
            return Ok(familOfChild);
        }


    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    [Authorize]
    public class ChildrenController : BaseApiController
    {
        private readonly IChildInterface _childInterface;
        private readonly IMapper _mapper;
        private readonly ApplicationDbConext _context;
       public ChildrenController(IChildInterface childInterface, IMapper mapper, ApplicationDbConext context)
        {
            _context = context;
            _mapper = mapper;
            _childInterface = childInterface;
           
        }

         [HttpPost("addchild")]
        //  [Authorize(Policy = "ChildDataRole")]
        public async Task<ActionResult<ChildDto>> AddChildAsync(Child child)
        {
                var newchild =  _mapper.Map<ChildDto>(child);

                 // Child Age calculation
                 int age = DateTime.Today.Year - child.DateOfBirth.Year;
                if (child.DateOfBirth.Date > DateTime.Today.AddYears(-age))
                age--;
                child.Age = age;
        
             var ChildToAdd = await _childInterface.AddChildrenAsync(child);
         
           
            return Ok(newchild);
        }

               
        

          [HttpGet("{chld}")]
        //  [Authorize(Policy = "ChildDataRole")]
         public async Task<ActionResult<ChildToReturn>> GetChildById(int chld)
        {
            var mychild = await _childInterface.GetChildByIdAsync(chld);
            return _mapper.Map<ChildToReturn>(mychild);
            // return Ok(mychild);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChildToReturn>>> GetAllChildrenAsync()
        {
            var childrenReturned = await _childInterface.GetChildrenAsync();
                var returnchidren = _mapper.Map<IEnumerable<ChildToReturn>>(childrenReturned);
            return Ok(returnchidren);

        }
   
    }
}
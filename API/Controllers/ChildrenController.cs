using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{

    public class ChildrenController : BaseApiController
    {
        private readonly IChildInterface _childInterface;
       public ChildrenController(IChildInterface childInterface)
        {
            _childInterface = childInterface;
           
        }

         [HttpPost("addchild")]
        //  [Authorize(Policy = "ChildDataRole")]
        public async Task<ActionResult<Child>> AddChildAsync(Child child)
        {
            // var newchild =  _mapper.Map<ChildDto>(child);
            var newChild = await _childInterface.AddChildrenAsync(child);
            return Ok(newChild);
         
        }

          [HttpGet("{chld}")]
        //  [Authorize(Policy = "ChildDataRole")]
         public async Task<ActionResult<Child>> GetChildById(int chld)
        {
            var mychild = await _childInterface.GetChildByIdAsync(chld);
            //  return _mapper.Map<ChildDto>(mychild);
            return Ok(mychild);
        }

        [HttpGet]
        public async Task<ActionResult<Child>> GetAllChildrenAsync()
        {
            var childrenReturned = await _childInterface.GetChildrenAsync();
            return Ok(childrenReturned);

        }
   
    }
}
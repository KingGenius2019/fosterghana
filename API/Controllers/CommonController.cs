using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class CommonController : BaseApiController
    {
       
        private readonly IUnitOfWorkInterface _unitOfWork;
        private readonly ApplicationDbConext _context;
        public CommonController(IUnitOfWorkInterface unitOfWork, ApplicationDbConext context)
        {
            _context = context;
            _unitOfWork = unitOfWork;
         
        }

        // [HttpGet("common")]
        // public async Task<ActionResult<bool>> FindCommonValues([FromQuery] string email)
        // {
        //       var commonValues = await _context.Children
        //         .Where(a => _context.FosterApplications.Any(b => b.PreferredMaxChildAge == a.Age))
        //         .Select(a => a.Age)
        //         .ToListAsync();

        //          return Ok(commonValues);
        // }

          [HttpGet]
    public async Task<IActionResult> GetComparisonData(int childid)
    {
        var getChildData = await _unitOfWork.ChildRepository.GetChildByIdAsync(childid);
        var getFosterParentData = await _unitOfWork.FosterApplicationRepository.GetApplicantsWithoutParamsAsync();

        return Ok(new { childToLookForMatch = getChildData, fosterDataForCommonData = getFosterParentData });
    }

        
       
     
    }
}
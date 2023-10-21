using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class ProfessionsController : BaseApiController
    {
        private readonly ApplicationDbConext _dbConext;
      
        public ProfessionsController(ApplicationDbConext dbConext)
        {
            _dbConext = dbConext;
        }

        [HttpPost]
        public async Task<ActionResult<Profession>> AddProfession (Profession profession)
        {
            var occupation = _dbConext.Professions.AddAsync(profession);
            await _dbConext.SaveChangesAsync();
            return Ok(occupation);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllProfession ()
        {   var returnProfession = await _dbConext.Professions.ToListAsync();
          return Ok(returnProfession);
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class AssessApplicationRepository : IApplicationAssessment
    {
        private readonly ApplicationDbConext _dbconext;
        public AssessApplicationRepository(ApplicationDbConext dbconext)
        {
            _dbconext = dbconext;
        }

        public async Task<AssessApplication> AddApplicationAsessmentAsync(AssessApplication assessapplication)
        {
            var result = await _dbconext.AssessApplications.AddAsync(assessapplication);
            await _dbconext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<AssessApplication>> GetApplicationAsessmentAsync()
        {
            return await _dbconext.AssessApplications
            
            .ToListAsync();
        }

        public async Task<AssessApplication> GetApplicationAssementByIdAsync(int assesid)
        {
             return await _dbconext.AssessApplications
                
                .FirstOrDefaultAsync(a => a.AssessId == assesid);
        }
    }
}
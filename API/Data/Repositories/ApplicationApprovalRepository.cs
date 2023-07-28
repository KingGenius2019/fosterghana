using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Entities.Identity;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class ApplicationApprovalRepository : IApplicationApprovalInterface
    {
        private readonly ApplicationDbConext _dbcontext;
        public ApplicationApprovalRepository(ApplicationDbConext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async  Task<ApplicationApproval> AddApplicationApprovalAsync(ApplicationApproval applicationAprovals)
        {
            var result = await _dbcontext.AddAsync(applicationAprovals);
            await _dbcontext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ApplicationApproval> GetApplicantionApprovalByIdAsync()
        {
            return await _dbcontext.ApplicationApprovals
              
            //    .Where(p => p.Id  == approveId)
               .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<ApplicationApproval>> GetApplicationApprovalsAsync()
        {
            return await _dbcontext.ApplicationApprovals
             .ToListAsync();
        }
    }
}
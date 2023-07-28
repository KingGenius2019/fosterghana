using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class ChildApprovalRepository : IChildApprovals
    {
        private readonly ApplicationDbConext _dbconext;
        public ChildApprovalRepository(ApplicationDbConext dbconext)
        {
            _dbconext = dbconext;
        }

        public async Task<ChildApproval> AddReviewChildAsync(ChildApproval childApproval)
        {
           var result = await _dbconext.ChildApprovals.AddAsync(childApproval);
            await _dbconext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ChildApproval> GetChildApprovalByIdAsync(int appId)
        {
              return await _dbconext.ChildApprovals
                
                .FirstOrDefaultAsync(a => a.AppId == appId);
        }

        public async Task<IEnumerable<ChildApproval>> GetChildApprovalsAsync()
        {
           return await _dbconext.ChildApprovals
            .ToListAsync();
        }
    }
}
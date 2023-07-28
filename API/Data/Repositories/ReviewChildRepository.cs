using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class ReviewChildRepository : IReviewChild
    {
        private readonly ApplicationDbConext _dbconext;
        public ReviewChildRepository(ApplicationDbConext dbconext)
        {
            _dbconext = dbconext;
        }

        public async Task<ReviewChild> AddReviewChildAsync(ReviewChild reviewChild)
        {
           var result = await _dbconext.ReviewChildren.AddAsync(reviewChild);
            await _dbconext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<ReviewChild>> GetReviewChildAsync()
        {
            return await _dbconext.ReviewChildren
            
            .ToListAsync();
        }

        public async Task<ReviewChild> GetReviewChildByIdAsync(int rechildId)
        {
             return await _dbconext.ReviewChildren
                
                .FirstOrDefaultAsync(r => r.ReviewId == rechildId);
        }
    }
}
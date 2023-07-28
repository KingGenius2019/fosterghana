using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IReviewChild
    {
         Task<IEnumerable<ReviewChild>> GetReviewChildAsync();
    
         Task<ReviewChild> GetReviewChildByIdAsync(int rechildId);
        Task<ReviewChild> AddReviewChildAsync(ReviewChild reviewChild);
    }
}
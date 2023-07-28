using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IChildApprovals
    {
         Task<IEnumerable<ChildApproval>> GetChildApprovalsAsync();
    
         Task<ChildApproval> GetChildApprovalByIdAsync(int appId);
        Task<ChildApproval> AddReviewChildAsync(ChildApproval childApproval);
    }
}
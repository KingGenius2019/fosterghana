using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IApplicationApprovalInterface
    {
           Task<ApplicationApproval> GetApplicantionApprovalByIdAsync();
        
        // Task<PagedList<ApplicationApproval>> GetApplicationApprovalsAsync(ApprovalParams approvalParams);
        Task<ApplicationApproval> AddApplicationApprovalAsync(ApplicationApproval applicationAprovals);
        Task<IEnumerable<ApplicationApproval>> GetApplicationApprovalsAsync();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUnitOfWorkInterface
    {
         ChildFamilyDetailInterface ChildFamilyDetailRepository { get; }
        IRegionsAndDistrictsInterFace RegionsAndDistrictsRepository {get;}
        IFosterApplication FosterApplicationRepository {get;}
        IReviewChild ReviewChildRepository {get;}
        IChildInterface ChildRepository {get;}
        IChildApprovals ChildApprovalRepository {get;}
        IApplicationAssessment AssessApplicationRepository {get;}
        IApplicationApprovalInterface ApplicationApprovalRepository {get;}
        

         
        Task<bool> SaveAllAsync();
        // void Update(Child  child);
    }
}
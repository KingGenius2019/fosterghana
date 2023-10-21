using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;

namespace API.Data.Repositories
{

    public class UnitOfWork : IUnitOfWorkInterface
    {
        private readonly ApplicationDbConext _dbconext;
        public UnitOfWork(ApplicationDbConext dbconext)
        {
            _dbconext = dbconext;
        }

        public ChildFamilyDetailInterface ChildFamilyDetailRepository => new ChildFamilyDetailRepository(_dbconext);
        public IRegionsAndDistrictsInterFace RegionsAndDistrictsRepository => new RegionsAndDistrictsRepository(_dbconext);
        public IFosterApplication FosterApplicationRepository => new FosterApplicationRepository(_dbconext);
        public IReviewChild ReviewChildRepository => new ReviewChildRepository(_dbconext);
        public IChildInterface ChildRepository => new ChildRepository(_dbconext);
         public IChildApprovals ChildApprovalRepository => new ChildApprovalRepository(_dbconext);
        public IApplicationAssessment AssessApplicationRepository => new AssessApplicationRepository(_dbconext);
        public IApplicationApprovalInterface ApplicationApprovalRepository => new ApplicationApprovalRepository(_dbconext);

        public IPlacementInterface PlacementRepository => new PlacementRepository(_dbconext);

        // IChildInterface IUnitOfWorkInterface.ChildRepository => throw new NotImplementedException();

        public async Task<bool> SaveAllAsync()
        {
            return await _dbconext.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _dbconext.ChangeTracker.HasChanges();
        }

        // public void Update(Child child)
        // {
        //     _dbconext.Entry(child).State = EntityState.Modified;
        // }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class FosterApplicationRepository : IFosterApplication
    {
        private readonly ApplicationDbConext _dbconext;
        public FosterApplicationRepository(ApplicationDbConext dbconext)
        {
            _dbconext = dbconext;
        }

        public Task<FosterApplications> GetApplicantByCodeAsync(string applyCode)
        {
            throw new NotImplementedException();
        }

        public async Task<FosterApplications> GetApplicantByIdAsync(int applyid)
        {
             return await _dbconext.FosterApplications
              .Include(p => p.ApplicantPhotos)
              .Include(p => p.ApplicantHomeStudyReports)
              .Include(p => p.AssessApplications)
              .Include(p => p.ApplicationApprovals)
             .SingleOrDefaultAsync(p => p.AppId == applyid);
        }

        public async Task<PagedList<FosterApplications>> GetApplicantsAsync(ApplicantParams applicantParams)
        {
            var query = _dbconext.FosterApplications
        
           .AsNoTracking();    
            // return await _dbconext.FosterApplications
            //   .ToListAsync();
            // query = query.Where(x=> x.NatureOfApplication == applicantParams.NatureOfApplication);
            
             if(!string.IsNullOrEmpty(applicantParams.NatureOfApplication))
             {
               query = query.Where(x=> x.NatureOfApplication == applicantParams.NatureOfApplication);
            }
            
             if(!string.IsNullOrEmpty(applicantParams.TypeOfFosterCare))
            {
               query = query.Where(x =>x.TypeOfFosterCare== applicantParams.TypeOfFosterCare);
            }
            
            return await PagedList<FosterApplications>.CreateAsync(query.AsNoTracking(), applicantParams.PageNumber, applicantParams.PageSize);
        }

        public Task<FosterApplications> GetBirthCerificateAsync(int certId)
        {
            throw new NotImplementedException();
        }

          public async Task<ApplicantPhotos> GetApplicantPhotoAsync(int photoid)
        {
           var applicantphoto = await _dbconext.ApplicantPhotos.FirstOrDefaultAsync(q => q.PhotoId == photoid);
            return applicantphoto;
        }


        public async Task<List<FosterApplications>> GetUserApplicationAsync(string userId)
        {
            return await _dbconext.FosterApplications.Include(x => x.User)
           .Where(x => x.UserId == userId)
           .ToListAsync();
        }

          public async  Task<List<FosterApplications>> SearchApplicationAsync(string name)
        {
                  return await _dbconext.FosterApplications.Where(x => x.NatureOfApplication.Contains(name) || x.TypeOfFosterCare.Contains(name))
             .Select(x => new FosterApplications { AppId = x.AppId, NatureOfApplication=x.NatureOfApplication, TypeOfFosterCare = x.TypeOfFosterCare, PreferredMinChildAge = x.PreferredMinChildAge, PreferredMaxChildAge = x.PreferredMaxChildAge })
           .ToListAsync();
        }

          public void Update(FosterApplications fosterApplication)
        {
             _dbconext.Entry(fosterApplication).State = EntityState.Modified;
        }

        public async Task<ApplicantHomeStudyReport> GetApplicantHomeStudyAsync(int homeid)
        {
            var applicantphoto = await _dbconext.ApplicantHomeStudyReports.SingleOrDefaultAsync(h => h.HomeId == homeid);
            return applicantphoto;
        }

        public async Task<IEnumerable<FosterApplications>> GetApplicantsWithoutParamsAsync()
        {
             return await _dbconext.FosterApplications
              .ToListAsync();
        }
    }
}
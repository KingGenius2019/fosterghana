using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface IFosterApplication
    {
        Task<IEnumerable<FosterApplications>> GetApplicantsWithoutParamsAsync();
        Task<PagedList<FosterApplications>> GetApplicantsAsync( ApplicantParams applicantParams);
        Task<FosterApplications> GetApplicantByIdAsync(int applyid);
        Task<List<FosterApplications>> GetUserApplicationAsync(string userId);
        Task<FosterApplications> GetApplicantByCodeAsync(string applyCode);
       
        Task<FosterApplications> GetBirthCerificateAsync(int certId);

        // Task<List<Application>> SearchApplicationAsync(string name);
        Task<ApplicantPhotos> GetApplicantPhotoAsync(int id);
        Task<ApplicantHomeStudyReport> GetApplicantHomeStudyAsync(int homeid);
        Task<List<FosterApplications>> SearchApplicationAsync(string name);
 

        void Update(FosterApplications fosterApplication);
    }
}
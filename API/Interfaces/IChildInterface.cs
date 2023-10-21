using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface IChildInterface
    {
        Task<Child> AddChildrenAsync(Child child);
        // Task<IEnumerable<Child>> GetChildrenAsync();
          Task<PagedList<Child>> GetChildrenAsync(ChildParams childParams);
        Task<Child> GetChildByIdAsync(int chd);
        Task<Child> GetChildByCodeAsync(string chldcode);
         Task<ChildPhotos> GetPhotoAsync (int photoid);

        Task<ChildStudyReport> GetChildStudyReportAsync (int studyid);
        Task<List<Child>> SearchChildAsync(string searchItem);
         
        Task<bool> SaveAllAsync();
        void Update(Child  child);
    }
}
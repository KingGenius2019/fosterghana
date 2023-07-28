using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IChildStudyReportInterface
    {
         Task<ChildStudyReport> AddChildStudyReportAsync(ChildStudyReport childstudyreport);
        Task<IEnumerable<ChildStudyReport>> GetChildStudyReportAsync();
        Task<ChildStudyReport> GetChildStudyReportByIdAsync(int studyid);
        
    }
}
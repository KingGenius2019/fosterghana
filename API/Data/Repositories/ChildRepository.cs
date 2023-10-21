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
    public class ChildRepository : IChildInterface
    {
        private readonly ApplicationDbConext _dbconext;
        public ChildRepository(ApplicationDbConext dbconext)
        {
            _dbconext = dbconext;
        }

        public async Task<Child> AddChildrenAsync(Child child)
        {
           var result = await _dbconext.Children.AddAsync(child);
            await _dbconext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Child> GetChildByCodeAsync(string chldcode)
        {
                  return await _dbconext.Children
                .Include(p => p.ChildPhotos)
                 .Include(c =>c.ChildStudyReports)
                .Include(s =>s.ChildFamilyDetails)
                // .Include(c =>c.ReviewChildren)
                .FirstOrDefaultAsync(c => c.ChildCode == chldcode);
        }

        public async Task<Child> GetChildByIdAsync(int chd)
        {
             return await _dbconext.Children
                .Include(p => p.ChildPhotos)
                 .Include(c =>c.ChildStudyReports)
                .Include(s =>s.ChildFamilyDetails)
                 .Include(c =>c.ReviewChildren)
                  .Include(c =>c.ChildApprovals)
                .FirstOrDefaultAsync(c => c.Id == chd);
        }

        public async Task<PagedList<Child>> GetChildrenAsync(ChildParams childParams)
        { 
            var query =  _dbconext.Children.AsQueryable()
                 .Include(c => c.ChildPhotos)
                   .AsNoTracking();
            //  query = query.Where(c =>c.Age )
         var minDob = DateTime.Today.AddYears(-childParams.MaxAge- 1);
             
             var maxDob = DateTime.Today.AddYears(-childParams.MinAge);
            query = query.Where(u => u.DateOfBirth >= minDob && u.DateOfBirth <= maxDob);
            //  query = query.Where(x => x.Sex== childParams.Sex);

         return await PagedList<Child>.CreateAsync(query.AsNoTracking(), childParams.PageNumber, childParams.PageSize);
        }

        public async Task<ChildStudyReport> GetChildStudyReportAsync(int studyid)
        {
           var studyDocument = await _dbconext.ChildStudyReports.SingleOrDefaultAsync(s => s.StudyId == studyid);
             return studyDocument;
        }

        public async Task<ChildPhotos> GetPhotoAsync(int photoid)
        {
              var photo = await _dbconext.ChildPhotos.FirstOrDefaultAsync(q => q.PhotoId == photoid);
            return photo;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _dbconext.SaveChangesAsync() > 0;
        }

        public async Task<List<Child>> SearchChildAsync(string searchItem)
        {
             return await _dbconext.Children.Where(x => x.FirstName.Contains(searchItem) )
              .Include(c =>c.ChildPhotos)
             .Select(x => new Child { Id = x.Id, FirstName = x.FirstName, SurName = x.SurName, PhotoPath = x.PhotoPath, DefaultCode = x.ChildCode, SequenceNumbers = x.SequenceNumbers, Sex= x.Sex })
            
           .ToListAsync();
        }

        public void Update(Child child)
        {
            _dbconext.Entry(child).State = EntityState.Modified;
        }
      
       
    }
}
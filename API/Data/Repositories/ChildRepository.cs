using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
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
                .FirstOrDefaultAsync(c => c.ld == chd);
        }

        public async Task<IEnumerable<Child>> GetChildrenAsync()
        {
           return await _dbconext.Children
           .Include(c => c.ChildPhotos)

           .ToListAsync();
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

        public void Update(Child child)
        {
            _dbconext.Entry(child).State = EntityState.Modified;
        }
      
       
    }
}
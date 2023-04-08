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

        public Task<Child> GetChildByCodeAsync(string chldcode)
        {
            throw new NotImplementedException();
        }

        public async Task<Child> GetChildByIdAsync(int chd)
        {
             return await _dbconext.Children
                // .Include(p => p.ChildPhotos)
                // .Include(c =>c.ChildStudyReports)
                // .Include(s =>s.ChildPoliceReports)
                // .Include(c =>c.ReviewChildren)
                .FirstOrDefaultAsync(c => c.ld == chd);
        }

        public async Task<IEnumerable<Child>> GetChildrenAsync()
        {
           return await _dbconext.Children
           .ToListAsync();
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class ChildFamilyDetailRepository : ChildFamilyDetailInterface
    {
        private readonly ApplicationDbConext _dbconext;
        public ChildFamilyDetailRepository(ApplicationDbConext dbconext)
        {
            _dbconext = dbconext;
        }

        public async Task<ChildFamilyDetail> AddChildFamilyDetailAsync(ChildFamilyDetail childfamilyDetail)
        {
            var result = await _dbconext.ChildFamilyDetails.AddAsync(childfamilyDetail);
            await _dbconext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<ChildFamilyDetail>> GetChildFamilyDetailAsync()
        {
            return await _dbconext.ChildFamilyDetails
        //    .Include(c => c.ChildPhotos)
           .ToListAsync();
        }

        public async Task<ChildFamilyDetail> GetChildFamilyDetailByIdAsync(int childfamId)
        {
            return await _dbconext.ChildFamilyDetails.SingleOrDefaultAsync(f => f.Id == childfamId);
           
        }
    }
}
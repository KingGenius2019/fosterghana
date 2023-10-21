using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class RegionsAndDistrictsRepository : IRegionsAndDistrictsInterFace
    {
        private readonly ApplicationDbConext _dbconext;
        public RegionsAndDistrictsRepository(ApplicationDbConext dbconext)
        {
            _dbconext = dbconext;
        }

        public async Task<Districts> AddDistrictAsync(Districts districts)
        {
            var result = await _dbconext.Districts.AddAsync(districts);
            await _dbconext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<RegionsInGhana> AddRegionAsync(RegionsInGhana regionsInGhana)
        {
            var result = await _dbconext.RegionsInGhana.AddAsync(regionsInGhana);
            await _dbconext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Districts> GetDistrictByCodeAsync(string dcode)
        {
            return await _dbconext.Districts
            .FirstOrDefaultAsync(c => c.DistrictCode == dcode);
        }

        public async Task<IEnumerable<Districts>> GetDistrictsAsync()
        {
             return await _dbconext.Districts
             .ToListAsync();
        }

        // public async Task<IEnumerable<Districts>> GetDistrictsByRegionCodeAsync(string rcode)
        // {
        //      return await _dbconext.Districts
        //         // .Include(p => p.RegionsGhana)
        //         .FirstOrDefaultAsync(c => c.RegionCode == rcode);
        // }

        public async Task<RegionsInGhana> GetRegionByCodeAsync(string rcode)
        {
              return await _dbconext.RegionsInGhana
                .Include(p => p.Districts)
                .FirstOrDefaultAsync(c => c.RegionCode == rcode);
        }

        public async Task<IEnumerable<RegionsInGhana>> GetRegionsAsync()
        {
            return await _dbconext.RegionsInGhana
           .Include(c => c.Districts)
           .ToListAsync();
        }

     

      
    }
}
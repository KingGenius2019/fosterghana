using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class PlacementRepository : IPlacementInterface
    {
        private readonly ApplicationDbConext _dbconext;
        public PlacementRepository(ApplicationDbConext dbconext)
        {
            _dbconext = dbconext;
        }

        public async Task<Placement> AddPlacementAsync(Placement placement)
        {
            var result = await _dbconext.Placements.AddAsync(placement);
            await _dbconext.SaveChangesAsync();
            return result.Entity;
        }

        // public async Task<Placement> AddPlacementAsync(Placement placement)
        // {
        //  var result = await dbconext.place AddAsync(matching);
        // await _context.SaveChangesAsync();
        // return result.Entity;
        // }

        public async  Task<Placement> GetPlacementByIdAsync(int id)
        {
             return await _dbconext.Placements
             .Include(p => p.Children)
              .Include(p => p.Applications)
                 
                .FirstOrDefaultAsync(p => p.PlaceId == id);
        }

        public async Task<IEnumerable<Placement>> GetPlacementsAsync()
        {
           return await _dbconext.Placements
                    .Include(p => p.Children)
                    .Include(p => p.Applications)
                    .ToListAsync();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IPlacementInterface
    {
        Task<IEnumerable<Placement>> GetPlacementsAsync();
        Task<Placement> GetPlacementByIdAsync(int id);
          
        Task<Placement> AddPlacementAsync(Placement placement);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IRegionsAndDistrictsInterFace
    {
        Task<RegionsInGhana> GetRegionByCodeAsync(string rcode);
     
        Task<IEnumerable<RegionsInGhana>> GetRegionsAsync();
        Task<RegionsInGhana> AddRegionAsync(RegionsInGhana regionsInGhana);
        Task<Districts> GetDistrictByCodeAsync(string dcode);
        Task<IEnumerable<Districts>> GetDistrictsAsync();
        Task<Districts> AddDistrictAsync(Districts districts);
        // Task<IEnumerable<Districts>> GetDistrictsByRegionCodeAsync(string rcode);
    }
}
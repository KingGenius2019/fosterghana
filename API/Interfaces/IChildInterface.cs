using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IChildInterface
    {
        Task<Child> AddChildrenAsync(Child child);
        Task<IEnumerable<Child>> GetChildrenAsync();
        Task<Child> GetChildByIdAsync(int chd);
        Task<Child> GetChildByCodeAsync(string chldcode);
         
        Task<bool> SaveAllAsync();
        void Update(Child  child);
    }
}
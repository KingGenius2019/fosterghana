using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface ChildFamilyDetailInterface
    {
        Task<ChildFamilyDetail> AddChildFamilyDetailAsync(ChildFamilyDetail childfamilyDetail);
        Task<IEnumerable<ChildFamilyDetail>> GetChildFamilyDetailAsync();
        Task<ChildFamilyDetail> GetChildFamilyDetailByIdAsync(int childfamId);
    }
}
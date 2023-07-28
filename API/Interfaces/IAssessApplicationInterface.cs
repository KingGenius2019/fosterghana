using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IAssessApplicationInterface
    {
        Task<IEnumerable<AssessApplication>> GetApplicationAsessmentAsync();

        Task<AssessApplication> GetApplicationAssementByIdAsync(int assesid);
        Task<AssessApplication> AddApplicationAsessmentAsync(AssessApplication assessapplication);
    }
}
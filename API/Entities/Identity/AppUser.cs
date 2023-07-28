using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace API.Entities.Identity
{
    public class AppUser : IdentityUser
    {
    public string DisplayName { get; set;}

     public ICollection<AppUserRole> UserRoles { get; set;}
    public ICollection<FosterApplications> FosterApplications { get; set;}
    public ICollection<ApplicantEducation> ApplicantEducations { get; set;}
     public ApplicantProfile ApplicantProfiles {get; set;}
     public ApplicantAddress ApplicantAddress {get; set;}
      public ApplicantContact ApplicantContacts {get; set;}
    public ApplicationIdentification ApplicationIdentification {get; set;}
    public ICollection<ApplicantEmploymentHistory> ApplicantEmploymentHistories { get; set;}
     public ICollection<EducationalHistory> EducationalHistory { get; set;}
     public ICollection<ApplicantReferences> ApplicantReferences { get; set;}
  

     public ICollection<ApplicantHousehold> ApplicantHouseholds { get; set;}
    }
}
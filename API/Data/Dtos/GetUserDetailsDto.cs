using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Data.Dtos
{
    public class GetUserDetailsDto
    {
        public string Email {get; set;}
        public string DisplayName {get; set;}

         public ICollection<FosterApplicationDto> FosterApplications { get; set;}
    
      public ReturnApplicantProfileDto ApplicantProfiles {get; set;}
      public ApplicantAddressDto ApplicantAddress {get; set;}
      public ApplicantContactReturnDto ApplicantContacts {get; set;}
    // public ApplicationIdentification ApplicationIdentification {get; set;}
    // public ICollection<ApplicantEmploymentHistory> ApplicantEmploymentHistories { get; set;}
     public ICollection<ApplicantEducationDto> ApplicantEducations{ get; set;}
    //  public ICollection<ApplicantReferences> ApplicantReferences { get; set;}
    }
}
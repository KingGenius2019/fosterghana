using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Data.Dtos;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // CreateMap<AppUser, UserDto>();
                CreateMap<ChildDto, Child>().ReverseMap();
                
                CreateMap<ChildPhotos, ChildPhotoDto >().ReverseMap();
                CreateMap<Child, ChildToReturn>()
                .ForMember(dest => dest.PhotoPath, opt => opt.MapFrom(src =>src.ChildPhotos.FirstOrDefault(x => x.IsMain).PhotoPath));
                CreateMap<ChildStudyReportDto, ChildStudyReport>().ReverseMap();
                CreateMap<ChildFamilyDetailDto, ChildFamilyDetail>().ReverseMap();
                CreateMap<RegionsDto, RegionsInGhana>().ReverseMap();
                CreateMap<DistrictsDto, Districts>().ReverseMap();
                CreateMap<ApplicantProfileDto, ApplicantProfile>().ReverseMap();
                CreateMap<ApplicantProfile, ReturnApplicantProfileDto>();
                CreateMap<ApplicantAddressDto, ApplicantAddress>().ReverseMap();
                CreateMap<ApplicantProfile, ReturnApplicantProfileDto>();
                CreateMap<FosterApplicationDto, FosterApplications>().ReverseMap();
                CreateMap<FosterApplications, FosterApplicationDetailDto>();
                CreateMap<FosterApplications, FosterApplicationReturnedDto>();
                CreateMap<EducationalHistory, EducationHistoryDto>().ReverseMap();
                CreateMap<EducationHistoryDto, EducationalHistory>().ReverseMap();
                CreateMap<ApplicantEmploymentHistoryDto, ApplicantEmploymentHistory>();
                CreateMap<ApplicantEmploymentHistory, ApplicantEmploymentHistoryDto>();
                CreateMap<ReviewChildDto, ReviewChild>().ReverseMap();
                CreateMap<ChildApprovalDto, ChildApproval>().ReverseMap();
                CreateMap<ApplicantContactDto, ApplicantContact>();
                CreateMap<ApplicantContact, ApplicantContactReturnDto>();
                CreateMap<ApplicantHouseholdDto, ApplicantHousehold>().ReverseMap(); 
                CreateMap<ApplicantReferenceDto, ApplicantReferences>().ReverseMap();   
                 CreateMap<ApplicantReferences, ApplicantReferenceReturnDTo>().ReverseMap();             
                CreateMap<ApplicantEducationDto, ApplicantEducation>().ReverseMap();
                CreateMap<ApplicantPhotoDto, ApplicantPhotos>().ReverseMap();    
                CreateMap<ApplicantHomeStudyReportDTo, ApplicantHomeStudyReport>().ReverseMap();  
                CreateMap<AssessApplicationDto, AssessApplication>().ReverseMap(); 
                CreateMap<ApplicationApprovalDto, ApplicationApproval>().ReverseMap();      
      
        }
    }
}
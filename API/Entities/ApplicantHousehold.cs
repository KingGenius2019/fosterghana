using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using API.Entities.Identity;

namespace API.Entities
{
    public class ApplicantHousehold
    {
        [Key] public int FamilyId {get; set;}
        public string MaritalStatus {get; set;}
        public int NoOfChildrenMale {get; set;}
        public int NoOfChildrenFemale {get; set;}
        public int NoOfAdultFemale {get; set;}
        public int NoOfAdultMale {get; set;}
         public string ApplicantUserName {get; set;}
        public string AgesAdult {get; set;}
        public string AgesChildren {get; set;}
        public string UserId {get; set;}
        public AppUser User {get; set;}
    }
}
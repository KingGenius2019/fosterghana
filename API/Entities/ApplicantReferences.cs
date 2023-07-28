using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using API.Entities.Identity;

namespace API.Entities
{
    public class ApplicantReferences
    {

       [Key]   public int RefId {get; set;}
       [Required] public string NameOfReferee {get; set;}
       [Required] public string RelationshipWithReferee {get; set;}

       public DateTime DateOfRelationship {get; set;}
       [Required]  public string RefereePhoneNumber {get; set;}
        
        [EmailAddress]
       public string  RefereeEmail {get; set;}

        public string UserId {get; set;}
        public AppUser User {get; set;}
    }
}
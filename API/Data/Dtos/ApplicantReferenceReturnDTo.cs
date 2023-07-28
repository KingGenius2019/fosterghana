using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos
{
    public class ApplicantReferenceReturnDTo
    {
          public int RefId {get; set;}
       public string NameOfReferee {get; set;}
      public string RelationshipWithReferee {get; set;}

       public DateTime DateOfRelationship {get; set;}
        public string RefereePhoneNumber {get; set;}
       public string  RefereeEmail {get; set;}
    }
}
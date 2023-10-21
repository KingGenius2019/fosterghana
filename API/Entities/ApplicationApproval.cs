using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using API.Entities.Identity;

namespace API.Entities
{
    public class ApplicationApproval
    {
         public int Id {get; set;}
         public string Comment {get; set;}
        [Required] public string FosterParentApproved {get; set;}
        
        [Required] public string ApprovedBy {get; set;}
      

        [Required]   public DateTime ApprovalDate {get; set;}
         [Required]   public DateTime DateApprovalWasDone {get; set;}=DateTime.Now;
         public int ApplyId {get; set;}
        public FosterApplications FosterApplications {get; set;}
      
    }
}
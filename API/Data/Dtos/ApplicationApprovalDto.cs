using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos
{
    public class ApplicationApprovalDto
    {
         public int Id {get; set;}
         public string Comment {get; set;}
        public bool FosterParentApproved {get; set;}
        public string ApprovedBy {get; set;}
        [Required]   public DateTime ApprovalDate {get; set;}
        [Required]   public DateTime DateApprovalWasDone {get; set;}=DateTime.Now;
        public int ApplyId {get; set;}
    }
}
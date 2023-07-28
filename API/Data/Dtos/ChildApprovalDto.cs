using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos
{
    public class ChildApprovalDto
    {
            
        [Required] public string Comment {get; set;}
        public int ChildId {get; set;}
         [Required] public string ApprovedBy {get; set;}
        public DateTime ApprovalDate {get; set;}

        public DateTime ApprovedDate {get; set;}=DateTime.Now;
    }
}
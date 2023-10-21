using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class ChildApproval
    {
         [Key]
        public int AppId {get; set;}


        [Required]        
        public string Comment {get; set;}
        public int ChildId {get; set;}
        public virtual Child Child {get; set;} 
        public string ApprovedBy {get; set;}

        
        public DateTime ApprovalDate {get; set;}

        public DateTime ApprovedDate {get; set;}=DateTime.Now;
    }
}
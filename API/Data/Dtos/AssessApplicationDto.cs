using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos
{
    public class AssessApplicationDto
    {
        [Key]
        public int AssessId { get; set; }

        [Required]
        public string Comment { get; set; }
        public bool CanFoster { get; set; }
         public string Assessedby { get; set; }
        [Required] public DateTime AssesDate { get; set; }
        [Required] public DateTime DateAssesed { get; set; } = DateTime.Now;
        public int ApplyId { get; set; }
      
    }
}
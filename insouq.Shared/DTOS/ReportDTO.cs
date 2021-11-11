using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS
{
    public class ReportDTO
    {
        [Required]
        public string Reason { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int AdId { get; set; }
    }
}

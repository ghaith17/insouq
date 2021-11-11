using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS.AccountsDTOS
{
    public class VerifySmsCodeDTO
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string MobileNumber { get; set; }
    }
}

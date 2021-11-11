using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS.AccountsDTOS
{
    public class SendSmsCodeDTO
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string MobileNumber { get; set; }
    }
}

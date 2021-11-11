using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS.AccountsDTOS
{
    public class ForgotPasswordDTO
    {
        [Required]
        public string Email { get; set; }
    }
}

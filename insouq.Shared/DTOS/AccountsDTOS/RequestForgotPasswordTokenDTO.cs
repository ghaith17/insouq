using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS.AccountsDTOS
{
    public class RequestForgotPasswordTokenDTO
    {
        [Required]
        public string MobileNumber { get; set; }
    }
}

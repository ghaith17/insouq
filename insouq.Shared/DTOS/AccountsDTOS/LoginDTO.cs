using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS.AccountsDTOS
{
    public class LoginDTO
    {
        [Required]
        public string EmailOrPhone { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

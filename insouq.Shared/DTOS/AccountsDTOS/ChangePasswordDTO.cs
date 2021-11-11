using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS.AccountsDTOS
{
    public class ChangePasswordDTO
    {
        [Required]
        public string CurrentPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Passwords Don't match")]
        public string ConfirmNewPassword { get; set; }
    }
}

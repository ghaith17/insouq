using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS.AccountsDTOS
{
    public class ResetPasswordDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string ResetPasswordToken { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        [Compare("NewPassword", ErrorMessage = "Passwords Don't match")]
        public string ConfirmNewPassword { get; set; }
    }

    public class ResetMobilePasswordDTO
    {
        [Required]
        public string MobileNumber { get; set; }

        [Required]
        public string ResetPasswordToken { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        [Compare("NewPassword", ErrorMessage = "Passwords Don't match")]
        public string ConfirmNewPassword { get; set; }
    }
}

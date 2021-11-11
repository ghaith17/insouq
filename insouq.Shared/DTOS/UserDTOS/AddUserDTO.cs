using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS.UserDTOS
{
    public class AddUserDTO
    {
        [Required]
        [MaxLength(256)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(256)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(256)]
        public string MobileNumber { get; set; }

        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required]
        [MaxLength(256)]
        public string Password { get; set; }
    }
}

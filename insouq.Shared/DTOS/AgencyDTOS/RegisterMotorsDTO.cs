using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS.AgencyDTOS
{
    public class RegisterMotorsDTO
    {
        [Required]
        [MaxLength(256)]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(256)]
        public string LicenseIssuingAuthority { get; set; }

        [Required]
        [MaxLength(256)]
        public string TradeLicenseCopyPath { get; set; }

        [Required]
        [MaxLength(256)]
        public string ShowroomAddress { get; set; }

        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required]
        [MaxLength(256)]
        public string Password { get; set; }

        [Required]
        [MaxLength(256)]
        public string MobileNumber { get; set; }

       
    }
}

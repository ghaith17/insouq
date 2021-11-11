using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS.UserDTOS
{
    public class UpdateCompanyProfileDTO
    {
        [MaxLength(256)]
        public string Name { get; set; }

        [EmailAddress]
        [MaxLength(256)]
        public string Email { get; set; }

        [MaxLength(400)]
        public string Description { get; set; }

        [MaxLength(256)]
        public string TradeLicenseNumber { get; set; }

        [Phone]
        public string ContactNumber { get; set; }

        [MaxLength(256)]
        public string Size { get; set; }

        [Url]
        public string Website { get; set; }

        [MaxLength(256)]
        public string Location { get; set; }

        public IFormFile TradeLicenseFile { get; set; }

        public IFormFile ProfilePicture { get; set; }
    }
}

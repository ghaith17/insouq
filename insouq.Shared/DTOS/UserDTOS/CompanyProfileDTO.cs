using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS.UserDTOS
{
    public class CompanyProfileDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public string TradeLicenseNumber { get; set; }

        public string TradeLicenseCopy { get; set; }

        public string ContactNumber { get; set; }

        public string Size { get; set; }

        public string Industry { get; set; }

        public string Website { get; set; }

        public string Location { get; set; }

        public string ProfileStatus { get; set; }

        public string Picture { get; set; }
    }
}

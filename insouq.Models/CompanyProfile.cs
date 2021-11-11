using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models
{
    public class CompanyProfile
    {
        public int Id { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        [EmailAddress]
        [MaxLength(256)]
        public string Email { get; set; }

        [MaxLength(400)]
        public string Description { get; set; }

        [MaxLength(256)]
        public string TradeLicenseNumber { get; set; }

        public string TradeLicenseCopy { get; set; }  // Image

        [Phone]
        public string ContactNumber { get; set; }

        [MaxLength(256)]
        public string Size { get; set; }

        [Url]
        public string Website { get; set; }

        [MaxLength(256)]
        public string Location { get; set; }

        public string Picture { get; set; }

        // relations

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}

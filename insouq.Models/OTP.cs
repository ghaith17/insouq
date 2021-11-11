using insouq.Models.IdentityConfiguration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models
{
    public class OTP
    {
        public int Id { get; set; }

        [MaxLength(6)]
        public string Code { get; set; }

        // relations

        public int UserId { get; set; }

        [Phone]
        [MaxLength(100)]
        public string MobileNumber { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

    }
}

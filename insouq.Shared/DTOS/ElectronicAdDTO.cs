using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS
{
    public class ElectronicAdDTO : CommonAd
    {
        public List<IFormFile> Pictures { get; set; }

        public string MainPhoto { get; set; }

        [Required]
        [MaxLength(256)]
        public string Age { get; set; }

        [Required]
        [MaxLength(256)]
        public string Usage { get; set; }

        [Required]
        public double? Price { get; set; } // min 1000

        [Required]
        [MaxLength(256)]
        public string Color { get; set; }

        [Required]
        public bool? Warranty { get; set; }

        public int? SubCategoryId { get; set; }

        public string OtherSubCategory { get; set; }

        public int? SubTypeId { get; set; }

        public string OtherSubType { get; set; }

        public string PhoneNumber { get; set; }
    }
}

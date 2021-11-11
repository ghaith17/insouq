using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS
{
    public class NumberAdDTO : CommonAd
    {
        public string Emirate { get; set; }

        public string PlateType { get; set; }

        public string PlateCode { get; set; }

        [Required]
        public int? Number { get; set; }

        public string Operator { get; set; }

        public string Code { get; set; }

        public string MobileNumberPlan { get; set; }

        [Required]
        public double? Price { get; set; }

        public string PhoneNumber { get; set; }
    }
}

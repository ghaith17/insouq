using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models
{
    public class NumberAd
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(256)]
        public string En_Emirate { get; set; }

        [MaxLength(256)]
        public string Ar_Emirate { get; set; }

        [MaxLength(256)]
        public string En_PlateType { get; set; } 
        
        [MaxLength(256)]
        public string Ar_PlateType { get; set; }

        [MaxLength(256)]
        public string PlateCode { get; set; }

        [MaxLength(256)]
        public string En_Operator { get; set; }

        [MaxLength(256)]
        public string Ar_Operator { get; set; }

        [MaxLength(256)]
        public string MobileCode { get; set; }

        [MaxLength(256)]
        public string En_MobileNumberPlan { get; set; }

        [MaxLength(256)]
        public string Ar_MobileNumberPlan { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public double Price { get; set; }

        public string Photo { get; set; }

        public string Photo2 { get; set; }

        public int AdId { get; set; }

        [ForeignKey(nameof(AdId))]
        public Ad Ad { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models
{
    public class ElectronicAd
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string En_Age { get; set; }

        [Required]
        [MaxLength(256)]
        public string Ar_Age { get; set; }

        [Required]
        [MaxLength(256)]
        public string En_Usage { get; set; }

        [Required]
        [MaxLength(256)]
        public string Ar_Usage { get; set; }

        public double Price { get; set; } // min 1000

        [Required]
        [MaxLength(256)]
        public string En_Color { get; set; }

        [Required]
        [MaxLength(256)]
        public string Ar_Color { get; set; }

        [Required]
        public bool Warranty { get; set; }

        public int? SubCategoryId { get; set; }

        [ForeignKey(nameof(SubCategoryId))]
        public SubCategory SubCategory { get; set; }

        public string OtherSubCategory { get; set; }

        public int? SubTypeId { get; set; }

        [ForeignKey(nameof(SubTypeId))]
        public SubType SubType { get; set; }

        public string OtherSubType { get; set; }

        public int AdId { get; set; }

        [ForeignKey(nameof(AdId))]
        public Ad Ad { get; set; }
    }
}

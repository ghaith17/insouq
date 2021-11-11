using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models
{
    public class ClassifiedAd
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(256)]
        public string En_Age { get; set; }

        [MaxLength(256)]
        public string Ar_Age { get; set; }

        [MaxLength(256)]
        public string En_Usage { get; set; }

        [MaxLength(256)]
        public string Ar_Usage { get; set; }

        public double Price { get; set; } // min 1000

        [MaxLength(256)]
        public string En_Condition { get; set; }

        [MaxLength(256)]
        public string Ar_Condition { get; set; }

        [MaxLength(256)]
        public string En_Brand { get; set; }

        [MaxLength(256)]
        public string Ar_Brand { get; set; }


        //relations

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

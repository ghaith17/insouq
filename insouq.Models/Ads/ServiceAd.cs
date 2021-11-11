using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models
{
    public class ServiceAd
    {
        [Key]
        public int Id { get; set; }

        public int? SubCategoryId { get; set; }

        [ForeignKey(nameof(SubCategoryId))]
        public SubCategory SubCategory { get; set; }

        public string OtherSubCategory { get; set; }

        public string CarLiftFrom { get; set; }

        public string CarLiftTo { get; set; }

        //[Required]
        //public double Price { get; set; }

        public int AdId { get; set; }

        [ForeignKey(nameof(AdId))]
        public Ad Ad { get; set; }
    }
}

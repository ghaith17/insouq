using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models
{
    public class BussinesAd
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(256)]
        public string OtherCategoryName { get; set; }


        [Required]
        public double Price { get; set; }

        public int AdId { get; set; }

        [ForeignKey(nameof(AdId))]
        public Ad Ad { get; set; }

        public int? SubCategoryId { get; set; }

        public string OtherSubCategoryName { get; set; }

        [ForeignKey(nameof(SubCategoryId))]
        public SubCategory SubCategory { get; set; }
    }
}

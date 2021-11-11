using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models
{
    public class SubType
    {
        public int Id { get; set; }

        public string Ar_Name { get; set; }

        public string En_Name { get; set; }

        //relation

        public int SubCategoryId { get; set; }

        [ForeignKey(nameof(SubCategoryId))]
        public SubCategory SubCategory { get; set; }

        public int Status { get; set; }
    }
}

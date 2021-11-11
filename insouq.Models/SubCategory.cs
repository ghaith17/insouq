using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models
{
    public class SubCategory
    {
        public int Id { get; set; }

        public string Ar_Name { get; set; }

        public string En_Name { get; set; }

        //relation

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        public int Status { get; set; }
    }
}

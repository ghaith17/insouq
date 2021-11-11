using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace insouq.Models
{
    public class Type
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Ar_Name { get; set; }

        public string En_Name { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<Ad> Ads { get; set; }

        public int Status { get; set; }
    }
}

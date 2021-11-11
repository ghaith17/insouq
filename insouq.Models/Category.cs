using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace insouq.Models
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Ar_Name { get; set; }

        public string En_Name { get; set; }

        public string FirstImage { get; set; }

        public string SecondImage { get; set; }

        public int NumberOfAds { get; set; }

        //relation

        public int TypeId { get; set; }

        [ForeignKey(nameof(TypeId))]
        public Type Type { get; set; }

        public int Status { get; set; }
    }
}

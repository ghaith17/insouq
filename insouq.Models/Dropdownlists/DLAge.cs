using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models.Dropdownlists
{
    public class DLAge
    {
        public int Id { get; set; }

        public string Ar_Text { get; set; }

        public string En_Text { get; set; }

        public int? CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        public int? TypeId { get; set; }

        [ForeignKey(nameof(TypeId))]
        public Type Type { get; set; }
    }
}

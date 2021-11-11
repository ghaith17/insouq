using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models.Dropdownlists
{
    public class DLPart
    {
        public int Id { get; set; }

        public string Ar_Text { get; set; }

        public string En_Text { get; set; }

        public int SubTypeId { get; set; }

        [ForeignKey(nameof(SubTypeId))]
        public SubType SubType { get; set; }
    }
}

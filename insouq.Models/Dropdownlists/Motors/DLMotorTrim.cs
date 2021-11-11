using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models.Dropdownlists
{
    public class DLMotorTrim
    {
        public int Id { get; set; }

        public string Ar_Text { get; set; }

        public string En_Text { get; set; }

        public int ModelId { get; set; }

        [ForeignKey(nameof(ModelId))]
        public DLMotorModel Model { get; set; }
    }
}

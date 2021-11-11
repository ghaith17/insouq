using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models.Dropdownlists
{
    public class DLMotorModel
    {
        public int Id { get; set; }

        public string Ar_Text { get; set; }

        public string En_Text { get; set; }

        public int MakerId { get; set; }

        [ForeignKey(nameof(MakerId))]
        public DLMotorMaker Maker { get; set; }
    }
}

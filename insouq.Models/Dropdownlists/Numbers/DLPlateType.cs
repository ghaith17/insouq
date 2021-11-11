using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models.Dropdownlists
{
    public class DLPlateType
    {
        public int Id { get; set; }

        public string Ar_Text { get; set; }

        public string En_Text { get; set; }

        public int EmirateId { get; set; }

        [ForeignKey(nameof(EmirateId))]
        public DLEmirate Emirate { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models.Dropdownlists
{
    public class DLPlateDesign
    {
        public int Id { get; set; }

        public string Ar_Text { get; set; }

        public string En_Text { get; set; }

        public int PlateTypeId { get; set; }

        [ForeignKey(nameof(PlateTypeId))]
        public DLPlateType PlateType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models.Dropdownlists
{
    public class DLPlateCode
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public int PlateTypeId { get; set; }

        [ForeignKey(nameof(PlateTypeId))]
        public DLPlateType PlateType { get; set; }
    }
}

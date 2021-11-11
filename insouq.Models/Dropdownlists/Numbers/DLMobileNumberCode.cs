using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models.Dropdownlists
{
    public class DLMobileNumberCode
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public int OperatorId { get; set; }

        [ForeignKey(nameof(OperatorId))]
        public DLOperator Operator { get; set; }
    }
}

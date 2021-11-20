using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS.CMS
{
    public class ValueDropDownDTO
    {
        public int Id { get; set; }

        [Required]
        public string Value { get; set; }
    }
}

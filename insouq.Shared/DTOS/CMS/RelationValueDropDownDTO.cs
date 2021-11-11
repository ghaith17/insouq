using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS.CMS
{
    public class RelationValueDropDownDTO
    {
        public int Id { get; set; }

        [Required]
        public int ParentId { get; set; }

        [Required]
        public string Value { get; set; }
    }
}

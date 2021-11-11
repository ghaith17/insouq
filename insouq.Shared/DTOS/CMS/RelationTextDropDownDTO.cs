using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS.CMS
{
    public class RelationTextDropDownDTO
    {
        public int Id { get; set; }

        [Required]
        public int ParentId { get; set; }

        [Required]
        public string EnglishTitle { get; set; }

        [Required]
        public string ArabicTitle { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS.CMS
{
    public class PartDropDownDTO
    {
        public int Id { get; set; }

        public int SubTypeId { get; set; }

        [Required]
        public string EnglishTitle { get; set; }

        [Required]
        public string ArabicTitle { get; set; }
    }
}

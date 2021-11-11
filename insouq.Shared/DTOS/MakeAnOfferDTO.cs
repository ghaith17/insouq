using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS
{
    public class MakeAnOfferDTO
    {
        [Required]
        public double? Price { get; set; }

        [Required]
        public int AdId { get; set; }

        public int TypeId { get; set; }
        
    }
}

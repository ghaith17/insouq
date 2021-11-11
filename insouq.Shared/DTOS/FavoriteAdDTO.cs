using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS
{
    public class FavoriteAdDTO
    {
        [Required]
        public int AdId { get; set; }
    }
}

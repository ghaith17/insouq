using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS
{
    public class GetAdsDTO
    {
        [Required]
        public int TypeId { get; set; }

        public int CategoryId { get; set; }
        
        public string SearchText { get; set; }
        public string Location { get; set; }
        public int MaxKm { get; set; }
        public int MinKm { get; set; }
        public int MinYear { get; set; }
        public int MaxYear { get; set; }
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
        public string Maker { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }
    }
}

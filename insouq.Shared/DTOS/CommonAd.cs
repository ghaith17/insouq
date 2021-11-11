using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS
{
    public class CommonAd
    {
        public int Id { get; set; }

        public int AdId { get; set; }

        // General Info
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]

        public string Location { get; set; }

        [Required]
        public string Lat { get; set; }

        [Required]
        public string Lng { get; set; }

        public int CategoryId { get; set; }
    }
}

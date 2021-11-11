using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS
{
    public class ClassifiedAdDTO
    {
        public int AdId { get; set; }

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

        public List<IFormFile> Pictures { get; set; }

        public string MainPhoto { get; set; }

        [Required]
        public double Price { get; set; }

        public string Age { get; set; }

        public string Usage { get; set; }

        public string Condition { get; set; }

        public string Brand { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}

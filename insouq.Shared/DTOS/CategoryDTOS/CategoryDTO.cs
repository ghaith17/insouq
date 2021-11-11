using insouq.Shared.DTOS.TypeDTOS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS.CategoryDTOS
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Ar_Name { get; set; }

        public string En_Name { get; set; }

        public string FirstImage { get; set; }

        public string SecondImage { get; set; }

        public int NumberOfAds { get; set; }

        public int TypeId { get; set; }

        public TypeDTO Types { get; set; }

        public int Status { get; set; }
    }
}

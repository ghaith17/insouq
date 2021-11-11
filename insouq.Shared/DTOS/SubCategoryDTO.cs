using insouq.Shared.DTOS.CategoryDTOS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS
{
    public class SubCategoryDTO
    {
        public int Id { get; set; }

        public string Ar_Name { get; set; }

        public string En_Name { get; set; }

        public int CategoryId { get; set; }

        public CategoryDTO Category { get; set; }

        public int Status { get; set; }
    }
}

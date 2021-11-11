using insouq.Shared.DTOS.CategoryDTOS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS
{
    public class SubTypeDTO
    {
        public int Id { get; set; }

        public string Ar_Name { get; set; }

        public string En_Name { get; set; }

        public int SubCategoryId { get; set; }

        public SubCategoryDTO SubCategory { get; set; }

        public int Status { get; set; }
    }
}

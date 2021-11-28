using insouq.Shared.DTOS;
using insouq.Shared.DTOS.CategoryDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsouqWebCMS.Models
{
    public class SubCategoryVM
    {
        public List<CategoryDTO> Categories { get; set; }

        public List<SubCategoryDTO> SubCategories { get; set; }
    }
}

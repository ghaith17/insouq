﻿using insouq.Shared.DTOS;
using insouq.Shared.DTOS.CategoryDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsouqWebCMS.Models
{
    public class SubTypeVM
    {
        public List<SubCategoryDTO> SubCategories { get; set; }

        public List<SubTypeDTO> SubTypes { get; set; }
    }
}

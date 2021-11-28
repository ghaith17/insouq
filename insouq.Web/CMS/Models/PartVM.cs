using insouq.Models.Dropdownlists;
using insouq.Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsouqWebCMS.Models
{
    public class PartVM
    {
        public List<SubCategoryDTO> SubCategories { get; set; }

        public List<SubTypeDTO> SubTypes { get; set; }

        public List<DLPart> Parts { get; set; }
    }
}

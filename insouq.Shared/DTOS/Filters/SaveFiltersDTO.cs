using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Shared.DTOS.Filters
{
    public class SaveFiltersDTO
    {

        public string Location { get; set; }
        public int CategoryId { get; set; }
        public int TypeId { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Shared.DTOS.Filters
{
    public class ServiceFilters
    {
        public int CategoryId { get; set; }

        public int SubCategoryId { get; set; }

        public int? PostedIn { get; set; }

        public int SortBy { get; set; }

        public string Location { get; set; }

        public string Keyword { get; set; }
    }
}

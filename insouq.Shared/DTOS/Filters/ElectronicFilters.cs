using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Shared.DTOS.Filters
{
    public class ElectronicFilters
    {
        public double FromPrice { get; set; }

        public double ToPrice { get; set; }

        public int CategoryId { get; set; }

        public int? SubCategoryId { get; set; }

        public int? SubTypeId { get; set; }

        public string Age { get; set; }

        public int? PostedIn { get; set; }

        public int SortBy { get; set; }

        public bool? Warranty { get; set; }

        public string Location { get; set; }

        //public string Keyword { get; set; }
    }
}

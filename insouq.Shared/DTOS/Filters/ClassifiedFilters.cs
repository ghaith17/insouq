using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Shared.DTOS.Filters
{
    public class ClassifiedFilters
    {
        public double FromPrice { get; set; }

        public double ToPrice { get; set; }

        public string Age { get; set; }

        public string Usage { get; set; }

        public string Brand { get; set; }

        public string Location { get; set; }

        //public string Keyword { get; set; }

        public int CategoryId { get; set; }

        public int? SubCategoryId { get; set; }

        public int? SubTypeId { get; set; }

        public int SortBy { get; set; }
    }
}

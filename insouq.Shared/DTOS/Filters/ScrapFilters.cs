using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Shared.DTOS.Filters
{
    public class ScrapFilters
    {
        public double FromPrice { get; set; }

        public double ToPrice { get; set; }

        public int FromYear { get; set; }

        public int ToYear { get; set; }

        public string Maker { get; set; }

        public string Model { get; set; }

        public string Trim { get; set; }

        public string Color { get; set; }

        public string Location { get; set; }

        public string Keyword { get; set; }

        public int CategoryId { get; set; }

        public int SortBy { get; set; }
    }
}

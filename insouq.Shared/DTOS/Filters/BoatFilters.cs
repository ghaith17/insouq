using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Shared.DTOS.Filters
{
    public class BoatFilters
    {
        public double FromPrice { get; set; }

        public double ToPrice { get; set; }

        public string Age { get; set; }

        public string Usage { get; set; }

        public bool Warranty { get; set; }

        public string Location { get; set; }

        public string Keyword { get; set; }

        public int CategoryId { get; set; }

        public int SortBy { get; set; }

    }
}

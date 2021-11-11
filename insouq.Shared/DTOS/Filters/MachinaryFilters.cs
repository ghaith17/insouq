using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Shared.DTOS.Filters
{
    public class MachinaryFilters
    {
        public double FromPrice { get; set; }

        public double ToPrice { get; set; }

        public int FromYear { get; set; }

        public int ToYear { get; set; }

        public double FromKilometers { get; set; }

        public double ToKilometers { get; set; }

        public string Maker { get; set; }

        public string Model { get; set; }

        public bool Warranty { get; set; }

        public string Horsepower { get; set; }

        public string Capacity { get; set; }

        public string FuelType { get; set; }

        public string Location { get; set; }

        public string Keyword { get; set; }

        public int CategoryId { get; set; }

        public int SortBy { get; set; }
    }
}

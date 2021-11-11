using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Shared.DTOS.Filters
{
    public class NumberFilters
    {
        public double FromPrice { get; set; }

        public double ToPrice { get; set; }

        public string Emirate { get; set; }

        public string Operator { get; set; }

        public string MobileCode { get; set; }

        public string NumberPlan { get; set; }

        public string PlateType { get; set; }

        public string PlateCode { get; set; }

        public string Location { get; set; }

        public string Keyword { get; set; }

        public int CategoryId { get; set; }

        public int SortBy { get; set; }

        //

        public bool? AllMobileDigits { get; set; }

        public int? MobileDigits3 { get; set; }

        public int? MobileDigits4 { get; set; }

        public int? MobileDigits5 { get; set; }

        public int? MobileDigits6 { get; set; }

        public int? MobileDigits7 { get; set; }


        public int? PlateDigits1 { get; set; }

        public int? PlateDigits2 { get; set; }

        public int? PlateDigits3 { get; set; }

        public int? PlateDigits4 { get; set; }

        public int? PlateDigits5 { get; set; }

    }
}

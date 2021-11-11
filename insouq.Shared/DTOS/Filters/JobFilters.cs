using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Shared.DTOS.Filters
{
    public class JobFilters
    {
        public int? PostedIn { get; set; }

        public string Commitment { get; set; }

        public string JobType { get; set; }

        public string WorkExperience { get; set; }

        public string EducationLevel { get; set; }

        public string Location { get; set; }

        public string Keyword { get; set; }

        public int CategoryId { get; set; }

        public int SortBy { get; set; }
    }
}

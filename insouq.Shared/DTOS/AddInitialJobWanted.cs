using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Shared.DTOS
{
    public class AddInitialJobWanted
    {
        public string Title { get; set; }

        public string JobTitle { get; set; }

        public string JobType { get; set; }

        public string OtherJobType { get; set; }

        public string PhoneNumber { get; set; }
    }
}

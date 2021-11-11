using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Models
{
    public class Agency
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Website { get; set; }

        public string TradeLicenseNumber { get; set; }

        public string CompanyTradeLicenseCopy { get; set; }  // Image

        public string BrokerNo { get; set; }

        public string BrokerCardCopy { get; set; } // Image

        public string Location { get; set; } // Image

        public bool ReciveSmsAndEmails { get; set; }

        public DateTime MemberSince { get; set; }

        public int Status { get; set; }

    }
}

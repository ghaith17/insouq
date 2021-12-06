using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS.AgencyDTOS
{
    public class RegisterAgencyDTO
    {
       
        public string CompanyName { get; set; }

        
        public string LicenseIssuingAuthority { get; set; }

       
        public string TradeLicenseCopyPath { get; set; }

       
        public string ShowroomAddress { get; set; }

        
        public string Email { get; set; }

        
        public string Password { get; set; }

        
        public string MobileNumber { get; set; }

        
        public string BrokerNo { get; set; }

        
        public string BrokerIdCopyPath { get; set; }

        
        public string ReraListerCompanyName { get; set; }

        public string ReraPermitNumber { get; set; }

        public string ReraAgentName { get; set; }
    }
}

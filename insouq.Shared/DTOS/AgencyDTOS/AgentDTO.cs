using insouq.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Shared.DTOS.AgencyDTOS
{
    public class AgentDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }


        public string Picture { get; set; }

        public IFormFile PicturePath { get; set; }

        public string MobileNumber { get; set; }

        public string MobileNumberCode { get; set; }

        public string Gender { get; set; }

        public string BrokerNo { get; set; }

        public string WorkNumber { get; set; }
        public string WorkNumberCode { get; set; }


        public string Language { get; set; }

        public string Password { get; set; }

        public bool ShowInformation { get; set; }

        public int Status { get; set; } // { disabled, active }


        public int AgencyId { get; set; }

        public Agency Agency { get; set; }
    }
}

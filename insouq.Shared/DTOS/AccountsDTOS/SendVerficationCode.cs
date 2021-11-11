using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Shared.DTOS.AccountsDTOS
{
    public class SendVerficationCodeDTO
    {
        [Phone]
        public string PhoneNumber { get; set; }

        public string Type { get; set; } // Email or Sms
    }
}

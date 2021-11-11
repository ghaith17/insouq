using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Shared.DTOS.AccountsDTOS
{
    public class VerifyEmailCodeDTO
    {
        public string Email { get; set; }

        public string Code { get; set; }
    }
}

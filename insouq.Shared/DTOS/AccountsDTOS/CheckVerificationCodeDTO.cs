using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Shared.DTOS.AccountsDTOS
{
    public class CheckVerificationCodeDTO
    {
        public string Code { get; set; }

        public int UserId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Shared.Responses
{
    public class VerifyForgotPasswordCodeResponse : BaseResponse
    {
        public string ResetPasswordToken { get; set; }

        public string Username { get; set; }
    }
}

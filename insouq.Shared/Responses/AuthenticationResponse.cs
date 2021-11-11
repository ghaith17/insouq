using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Shared.Responses
{
    public class AuthenticationResponse : BaseResponse
    {
        public string Token { get; set; }

        public int UserId { get; set; }

        public int Status { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Shared.Responses
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}

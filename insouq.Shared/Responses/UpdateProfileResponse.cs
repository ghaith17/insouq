using insouq.Shared.DTOS.UserDTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Shared.Responses
{
    public class UpdateProfileResponse : BaseResponse
    {
        public UserDTO User { get; set; }
    }
}

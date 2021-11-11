using insouq.Shared.DTOS.UserDTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Shared.Responses
{
    public class UpdateCompanyProfileResponse : BaseResponse
    {
        public CompanyProfileDTO CompanyProfile { get; set; }
    }
}

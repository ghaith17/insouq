using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using insouq.Shared.Responses;
using insouq.Shared.DTOS.AgencyDTOS;

namespace insouq.Services.IServices.Agency
{
   public interface IAgencyAccountService
    {
        Task<AuthenticationResponse> RegisterMotors(RegisterMotorsDTO model);
    }
}

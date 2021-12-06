using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using insouq.Shared.Responses;
using insouq.Shared.DTOS.AgencyDTOS;
using insouq.Shared.DTOS.AccountsDTOS;

namespace insouq.Services.IServices.Agency
{
   public interface IAgencyAccountService
    {
        Task<AuthenticationResponse> RegisterPropoerty(RegisterAgencyDTO model);
        Task<AuthenticationResponse> RegisterMotors(RegisterAgencyDTO model);
        Task<AuthenticationResponse> Login(LoginDTO model);
    }
}

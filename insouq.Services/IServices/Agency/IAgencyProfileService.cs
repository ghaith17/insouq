using insouq.Models;
using insouq.Shared.DTOS.AgencyDTOS;
using insouq.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services.IServices.Agency
{
    public interface IAgencyProfileService
    {
        Task<AuthenticationResponse> RegisterAgent(AgentDTO model);
        

        Task<BaseResponse> RemoveAgent(int agentId);
  

        Task<BaseResponse> ActivateAgent(int agentId);
        
        Task<BaseResponse> DisableAgent(int agentId);
        Task<List<Agent>> GetAllAgentsByAgency(int agencyId);

    }
}

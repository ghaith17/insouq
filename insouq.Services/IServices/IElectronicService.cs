using insouq.Shared.DTOS;
using insouq.Shared.DTOS.Filters;
using insouq.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services.IServices
{
    public interface IElectronicService
    {
        Task<BaseResponse> AddElectronicAd(int userId, ElectronicAdDTO model,string host);

        //Task<BaseResponse> UpdateElectronicAd(int userId, ElectronicAdDTO model);

        Task<List<GetElectronicAd>> FilterElectronics(ElectronicFilters model);

        Task<UpdateElectronicsDTO> GetElectronicAd(int adId);

        Task<BaseResponse> UpdateElectronicAd(int userId, UpdateElectronicsDTO model,string host);

    }
}

using insouq.Shared.DTOS;
using insouq.Shared.DTOS.Filters;
using insouq.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services.IServices
{
    public interface IServiceAdsService
    {
        Task<BaseResponse> AddServiceAd(int userId, ServiceAdDTO model, string host);

        //Task<BaseResponse> UpdateServiceAd(int userId, ServiceAdDTO model);

        Task<List<GetServiceAdDTO>> FilterServices(ServiceFilters model);

        Task<GetServiceAdDTO> GetServiceAd(int adId);

        Task<BaseResponse> UpdateServiceAd(int userId, ServiceAdDTO model, string host);
    }
}

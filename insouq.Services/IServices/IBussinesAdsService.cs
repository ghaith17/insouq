using insouq.Shared.DTOS;
using insouq.Shared.DTOS.Filters;
using insouq.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services.IServices
{
    public interface IBussinesAdsService
    {
        Task<BaseResponse> AddBussinesAd(int userId, BussinesAdDTO model,string host);

        Task<BaseResponse> UpdateBussinesAd(int userId, UpdateBusinessAdDTO model, string host);

        Task<List<GetBussinesAdDTO>> FilterBusiness(BusinessFilters model);

        Task<UpdateBusinessAdDTO> GetBusinessAd(int adId);
    }
}

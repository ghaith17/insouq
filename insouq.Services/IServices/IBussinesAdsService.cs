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
        Task<BaseResponse> AddBussinesAd(int userId, BussinesAdDTO model);

        Task<BaseResponse> UpdateBussinesAd(int userId, UpdateBusinessAdDTO model);

        Task<List<GetBussinesAdDTO>> FilterBusiness(BusinessFilters model);

        Task<UpdateBusinessAdDTO> GetBusinessAd(int adId);
    }
}

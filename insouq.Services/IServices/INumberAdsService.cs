using insouq.Shared.DTOS;
using insouq.Shared.DTOS.Filters;
using insouq.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services.IServices
{
    public interface INumberAdsService
    {

        Task<NumberAdDTO> GetNumberAd(int adId);

        Task<BaseResponse> Add(int userId, NumberAdDTO model,string host);

        Task<List<GetNumberAdDTO>> FilterNumbers(NumberFilters model);

        Task<BaseResponse> Update(int userId, NumberAdDTO model, string host);

        //Task<BaseResponse> Update(int userId, NumberAdDTO model);
    }
}

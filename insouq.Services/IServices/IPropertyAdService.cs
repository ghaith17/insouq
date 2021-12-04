using insouq.Shared.DTOS;
using insouq.Shared.DTOS.Filters;
using insouq.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services.IServices
{
    public interface IPropertyAdService
    {
        Task<UpdatePropertyAdDTO> GetPropertyAd(int adId);

        Task<BaseResponse> Add(int userId, PropertyAdDTO model , string host);

        Task<BaseResponse> Update(int userId, UpdatePropertyAdDTO model, string host);

        Task<List<GetPropertyAdDTO>> FilterProperities(PropertyFilters model);

        //Task<BaseResponse> Update(int userId, PropertyAdDTO model);
    }
}

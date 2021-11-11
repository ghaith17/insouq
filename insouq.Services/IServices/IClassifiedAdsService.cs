using insouq.Shared.DTOS;
using insouq.Shared.DTOS.Filters;
using insouq.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services.IServices
{
    public interface IClassifiedAdsService
    {
        Task<BaseResponse> AddClassifiedAd(int userId, ClassifiedAdDTO model);
        
        Task<AddInitialDataResponse> AddInitialClassified(int userId, AddInitialClassified model);

        Task<BaseResponse> UpdateClassifiedAd(int userId, UpdateClassifiedDTO model);

        Task<List<GetClassifiedAdDTO>> FilterClassifieds(ClassifiedFilters model);

        Task<UpdateClassifiedDTO> GetClassifiedAd(int adId);
    }
}

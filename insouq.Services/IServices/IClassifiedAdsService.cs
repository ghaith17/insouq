﻿using insouq.Shared.DTOS;
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
        Task<BaseResponse> AddClassifiedAd(int userId, ClassifiedAdDTO model,string host);
        
        Task<AddInitialDataResponse> AddInitialClassified(int userId, AddInitialClassified model,string host);

        Task<BaseResponse> UpdateClassifiedAd(int userId, UpdateClassifiedDTO model, string host);

        Task<List<GetClassifiedAdDTO>> FilterClassifieds(ClassifiedFilters model);

        Task<UpdateClassifiedDTO> GetClassifiedAd(int adId);
    }
}

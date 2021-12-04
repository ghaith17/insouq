using insouq.Shared.DTOS;
using insouq.Shared.DTOS.Filters;
using insouq.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services.IServices
{
    public interface IJobAdsService
    {
        //Task<BaseResponse> AddJobOpeningAd(int userId, JobOpeningAdDTO model);

        //Task<BaseResponse> UpdateJobOpeningAd(int userId, JobOpeningAdDTO model);

        //Task<BaseResponse> AddJobWantedAd(int userId, JobWantedAdDTO model);

        //Task<BaseResponse> UpdateJobWantedAd(int userId, JobWantedAdDTO model);

        Task<JobAdDTO> GetJobAd(int adId);

        Task<BaseResponse> Add(int userId, JobAdDTO model,string host);

        Task<AddInitialJobWantedResponse> AddInitialJobWanted(int userId, AddInitialJobWanted model, string host);

        Task<BaseResponse> AddJobWanted(int userId, AddJobWanted model,string host);

        Task<BaseResponse> Update(int userId, JobAdDTO model, string host);

        Task<List<GetJobAdDTO>> FilterJobs(JobFilters model);

        //Task<BaseResponse> Update(int userId, JobAdDTO model);
    }
}

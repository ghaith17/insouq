using insouq.Shared.DTOS;
using insouq.Shared.DTOS.Filters;
using insouq.Shared.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services.IServices
{
    public interface IMotorsService
    {
        //Task<BaseResponse> AddUsedCarAd(int userId, UsedCarAdDTO model);

        //Task<BaseResponse> UpdateUsedCarAd(int userId, UsedCarAdDTO model);

        //Task<BaseResponse> AddBoatAd(int userId, BoatAdDTO model);

        //Task<BaseResponse> UpdateBoatAd(int userId, BoatAdDTO model);

        //Task<BaseResponse> AddMachineryAd(int userId, MachineryAdDTO model);

        //Task<BaseResponse> UpdateMachineryAd(int userId, MachineryAdDTO model);

        //Task<BaseResponse> AddPartAd(int userId, PartAdDTO model);

        //Task<BaseResponse> UpdatePartAd(int userId, PartAdDTO model);

        //Task<BaseResponse> AddBikeAd(int userId, BikeAdDTO model);

        //Task<BaseResponse> UpdateBikeAd(int userId, BikeAdDTO model);

        //Task<BaseResponse> AddScrapAd(int userId, ScrapAdDTO model);

        //Task<BaseResponse> UpdateScrapAd(int userId, ScrapAdDTO model);

        Task<UpdateMotorsDTO> GetMotorAd(int adId);

        Task<BaseResponse> Add(int userId, MotorsAdDTO model,string host);

        Task<AddInitialDataResponse> AddInitialMotor(int userId, AddInitalMotor model);

        Task<BaseResponse> Update(int userId, UpdateMotorsDTO model);

        //Task<List<GetMotorAdDTO>> FilterUsedCars(UsedCarsFilter model);
        //Task<List<GetMotorAdDTO>> FilterBoats(BoatFilters model);
        //Task<List<GetMotorAdDTO>> FilterMachinaries(MachinaryFilters model);
        //Task<List<GetMotorAdDTO>> FilterParts(PartFilters model);
        //Task<List<GetMotorAdDTO>> FilterBikes(BikeFilters model);
        //Task<List<GetMotorAdDTO>> FilterScraps(ScrapFilters model);

        Task<List<GetMotorAdDTO>> FilterMotors(MotorFilters model);

        //Task<BaseResponse> Update(int userId, MotorsAdDTO model);

        Task UploadImage(IFormFile file);
    }
}

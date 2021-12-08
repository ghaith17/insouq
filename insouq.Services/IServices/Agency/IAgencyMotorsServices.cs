using insouq.Shared.DTOS;
using insouq.Shared.DTOS.AgencyDTOS;
using insouq.Shared.DTOS.Filters;
using insouq.Shared.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services.IServices.Agency
{
   public interface IAgencyMotorsServices
    {
        Task<UpdateMotorsDTO> GetMotorAd(int adId);

        Task<BaseResponse> Add(int userId, Shared.DTOS.AgencyDTOS.MotorsAdDTO model, string host);

       // Task<AddInitialDataResponse> AddInitialMotor(int userId, AddInitalMotor model, string host);

        Task<BaseResponse> Update(int userId, UpdateMotorsDTO model, string host);

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

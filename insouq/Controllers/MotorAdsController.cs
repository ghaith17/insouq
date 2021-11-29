using insouq.Configuration;
using insouq.Services.IServices;
using insouq.Shared.DTOS;
using insouq.Shared.DTOS.Filters;
using insouq.Shared.Responses;
using insouq.Shared.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace insouq.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotorAdsController : ControllerBase
    {
        private readonly IMotorsService _motorsService;

        private readonly JwtConfig _jwtConfig;

        public MotorAdsController(IMotorsService usedCarsAdsService, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _motorsService = usedCarsAdsService;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        [HttpGet]
        [Route("GetMotorAd")]
        public async Task<IActionResult> GetMotorAd([FromQuery] int adId)
        {
            var ad = await _motorsService.GetMotorAd(adId);

            if (ad == null)
            {
                return Ok(new BaseResponse { IsSuccess = false, Message = "0" });
            }

            return Ok(ad);
        }

        [HttpPost]
        [Route("AddInitialMotor")]
        public async Task<IActionResult> AddInitialMotor([FromBody] AddInitalMotor dataModel)
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            var userId = HelperFunctions.ValidateJwtToken(token, _jwtConfig.Secret);

            if (userId == null)
            {
                return Unauthorized(new BaseResponse
                {
                    IsSuccess = false,
                    Message = StaticData.Unauthorized_Message
                });
            }

            var response = await _motorsService.AddInitialMotor((int)userId, dataModel);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response);
        }

        [HttpPost]
        [Route("AddFullMotor")]
        public async Task<IActionResult> AddFullMotor([FromForm] MotorsAdDTO dataModel)
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            var userId = HelperFunctions.ValidateJwtToken(token, _jwtConfig.Secret);

            if (userId == null)
            {
                return Unauthorized(new BaseResponse
                {
                    IsSuccess = false,
                    Message = StaticData.Unauthorized_Message
                });
            }

            var response = await _motorsService.Add((int)userId, dataModel);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response);
        }

        [HttpPost]
        [Route("FilterMotors")]
        public async Task<IActionResult> FilterMotors([FromForm] MotorFilters dataModel)
        {
            var response = await _motorsService.FilterMotors(dataModel);

            return Ok(response);
        }

        //[HttpPost]
        //[Route("FilterBoats")]
        //public async Task<IActionResult> FilterBoats([FromBody] BoatFilters dataModel)
        //{
        //    var response = await _motorsService.FilterBoats(dataModel);

        //    return Ok(response);
        //}

        //[HttpPost]
        //[Route("FilterMachinaries")]
        //public async Task<IActionResult> FilterMachinaries([FromBody] MachinaryFilters dataModel)
        //{
        //    var response = await _motorsService.FilterMachinaries(dataModel);

        //    return Ok(response);
        //}

        //[HttpPost]
        //[Route("FilterBikes")]
        //public async Task<IActionResult> FilterBikes([FromBody] BikeFilters dataModel)
        //{
        //    var response = await _motorsService.FilterBikes(dataModel);

        //    return Ok(response);
        //}

        //[HttpPost]
        //[Route("FilterParts")]
        //public async Task<IActionResult> FilterParts([FromBody] PartFilters dataModel)
        //{
        //    var response = await _motorsService.FilterParts(dataModel);

        //    return Ok(response);
        //}

        //[HttpPost]
        //[Route("FilterScraps")]
        //public async Task<IActionResult> FilterScraps([FromBody] ScrapFilters dataModel)
        //{
        //    var response = await _motorsService.FilterScraps(dataModel);

        //[HttpPost]
        //[Route("FilterUsedCars")]
        //public async Task<IActionResult> FilterUsedCars([FromBody] UsedCarsFilter dataModel)
        //{
        //    var response = await _motorsService.FilterUsedCars(dataModel);

        //    return Ok(response);
        //}

        //[HttpPost]
        //[Route("FilterBoats")]
        //public async Task<IActionResult> FilterBoats([FromBody] BoatFilters dataModel)
        //{
        //    var response = await _motorsService.FilterBoats(dataModel);

        //    return Ok(response);
        //}

        //[HttpPost]
        //[Route("FilterMachinaries")]
        //public async Task<IActionResult> FilterMachinaries([FromBody] MachinaryFilters dataModel)
        //{
        //    var response = await _motorsService.FilterMachinaries(dataModel);

        //    return Ok(response);
        //}

        //[HttpPost]
        //[Route("FilterBikes")]
        //public async Task<IActionResult> FilterBikes([FromBody] BikeFilters dataModel)
        //{
        //    var response = await _motorsService.FilterBikes(dataModel);

        //    return Ok(response);
        //}

        //[HttpPost]
        //[Route("FilterParts")]
        //public async Task<IActionResult> FilterParts([FromBody] PartFilters dataModel)
        //{
        //    var response = await _motorsService.FilterParts(dataModel);

        //    return Ok(response);
        //}

        //[HttpPost]
        //[Route("FilterScraps")]
        //public async Task<IActionResult> FilterScraps([FromBody] ScrapFilters dataModel)
        //{
        //    var response = await _motorsService.FilterScraps(dataModel);

        //    return Ok(response);
        //}

        //[Authorize]
        //[HttpPost]
        //[Route("Update")]
        //public async Task<IActionResult> Update([FromForm] MotorsAdDTO dataModel)
        //{
        //    var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        //    var userId = HelperFunctions.ValidateJwtToken(token, _jwtConfig.Secret);

        //    if (userId == null)
        //    {
        //        return Unauthorized(new BaseResponse
        //        {
        //            IsSuccess = false,
        //            Message = StaticData.Unauthorized_Message
        //        });
        //    }

        //    var response = await _motorsService.Update((int)userId, dataModel);

        //    if (response.IsSuccess) return Ok(response);

        //    return BadRequest(response);
        //}

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] abc aa)
        {
            await _motorsService.UploadImage(aa.file);

            return Ok();
        }

        public class abc
        {
            public IFormFile file { get; set; }
        }
    }
}

using insouq.Configuration;
using insouq.Services.IServices;
using insouq.Shared.DTOS;
using insouq.Shared.DTOS.Filters;
using insouq.Shared.Responses;
using insouq.Shared.Utility;
using Microsoft.AspNetCore.Authorization;
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
    public class JobAdsController : ControllerBase
    {
        private readonly IJobAdsService _jobAdsService;

        private readonly JwtConfig _jwtConfig;

        public JobAdsController(IJobAdsService jobAdsService, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _jobAdsService = jobAdsService;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        [HttpGet]
        [Route("GetJobAd")]
        public async Task<IActionResult> GetJobAd([FromQuery] int adId)
        {
            var ad = await _jobAdsService.GetJobAd(adId);

            if (ad == null)
            {
                return Ok(new BaseResponse { IsSuccess = false, Message = "0" });
            }

            return Ok(ad);
        }


        [HttpPost]
        [Route("AddInitialJobWanted")]
        public async Task<IActionResult> AddInitialJobWanted([FromBody] AddInitialJobWanted dataModel)
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

            var response = await _jobAdsService.AddInitialJobWanted((int)userId, dataModel);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response);
        }

        [HttpPost]
        [Route("AddFullJobWanted")]
        public async Task<IActionResult> AddFullJobWanted([FromForm] AddJobWanted dataModel)
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

            var response = await _jobAdsService.AddJobWanted((int)userId, dataModel);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response);
        }

        [HttpPost]
        [Route("AddJobOpening")]
        public async Task<IActionResult> AddJobOpening([FromForm] JobAdDTO dataModel)
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

            var response = await _jobAdsService.Add((int)userId, dataModel);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response);
        }

        [HttpPost]
        [Route("FilterJobs")]
        public async Task<IActionResult> FilterJobs([FromForm] JobFilters dataModel) {

            var response = await _jobAdsService.FilterJobs(dataModel);

           return Ok(response);

        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update([FromForm] JobAdDTO dataModel)
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

            var response = await _jobAdsService.Update((int)userId, dataModel);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response);
        }
    }
}

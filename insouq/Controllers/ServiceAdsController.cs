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
    public class ServiceAdsController : ControllerBase
    {
        private readonly IServiceAdsService _serviceAdsService;

        private readonly JwtConfig _jwtConfig;

        public ServiceAdsController(IServiceAdsService serviceAdsService, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _serviceAdsService = serviceAdsService;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        [HttpGet]
        [Route("GetServiceAd")]
        public async Task<IActionResult> GetServiceAd([FromQuery] int adId)
        {
            var ad = await _serviceAdsService.GetServiceAd(adId);

            if (ad == null)
            {
                return Ok(new BaseResponse { IsSuccess = false, Message = "0" });
            }

            return Ok(ad);
        }

        [Authorize]
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromForm] ServiceAdDTO dataModel)
        {
            if (!ModelState.IsValid)
            {
                var Errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return BadRequest(new BaseResponse { IsSuccess = false, Message = Errors });
            }

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

            var response = await _serviceAdsService.AddServiceAd((int)userId, dataModel);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response);
        }
        
        [HttpPost]
        [Route("FilterServices")]
        public async Task<IActionResult> FilterServices([FromBody] ServiceFilters dataModel)
        {
            var response = await _serviceAdsService.FilterServices(dataModel);

            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update([FromForm] ServiceAdDTO dataModel)
        {
            if (!ModelState.IsValid)
            {
                var Errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return BadRequest(new BaseResponse { IsSuccess = false, Message = Errors });
            }

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

            var response = await _serviceAdsService.UpdateServiceAd((int)userId, dataModel);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response);
        }
    }
}

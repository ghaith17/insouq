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
    public class PropertyAdsController : ControllerBase
    {
        private readonly IPropertyAdService _propertyService;

        private readonly JwtConfig _jwtConfig;

        public PropertyAdsController(IPropertyAdService propertyService, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _propertyService = propertyService;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        [HttpGet]
        [Route("GetPropertyAd")]
        public async Task<IActionResult> GetPropertyAd([FromQuery] int adId)
        {
            var ad = await _propertyService.GetPropertyAd(adId);

            if (ad == null)
            {
                return Ok(new BaseResponse { IsSuccess = false, Message = "0" });
            }

            return Ok(ad);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromForm] PropertyAdDTO dataModel)
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
            var hostName = $"{this.Request.Scheme}://{this.Request.Host}";
            var response = await _propertyService.Add((int)userId, dataModel,hostName);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response);
        }
        
        [HttpPost]
        [Route("FilterProperities")]
        public async Task<IActionResult> FilterProperities([FromForm] PropertyFilters dataModel)
        {
            var response = await _propertyService.FilterProperities(dataModel);

            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update([FromForm] UpdatePropertyAdDTO dataModel)
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
            var hostName = $"{this.Request.Scheme}://{this.Request.Host}";
            var response = await _propertyService.Update((int)userId, dataModel, hostName);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response);
        }

    }
}

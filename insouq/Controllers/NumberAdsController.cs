using insouq.Configuration;
using insouq.Services.IServices;
using insouq.Shared.DTOS;
using insouq.Shared.DTOS.Filters;
using insouq.Shared.Responses;
using insouq.Shared.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;

namespace insouq.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NumberAdsController : ControllerBase
    {
        private readonly INumberAdsService _numberAdsService;

        private readonly JwtConfig _jwtConfig;

        public NumberAdsController(INumberAdsService numberAdsService, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _numberAdsService = numberAdsService;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        [HttpGet]
        [Route("GetNumberAd")]
        public async Task<IActionResult> GetNumberAd([FromQuery] int adId)
        {
            var ad = await _numberAdsService.GetNumberAd(adId);

            if (ad == null)
            {
                return Ok(new BaseResponse { IsSuccess = false, Message = "0" });
            }

            return Ok(ad);
        }

        [Authorize]
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] NumberAdDTO dataModel)
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
            var response = await _numberAdsService.Add((int)userId, dataModel,hostName);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response);
        }

        [HttpPost]
        [Route("FilterNumbers")]
        public async Task<IActionResult> FilterNumbers([FromForm] NumberFilters dataModel)
        {
            var response = await _numberAdsService.FilterNumbers(dataModel);

            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] NumberAdDTO dataModel)
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
            var response = await _numberAdsService.Update((int)userId, dataModel,hostName);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response);
        }
    }
}

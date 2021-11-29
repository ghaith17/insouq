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
using System.Linq;
using System.Threading.Tasks;

namespace insouq.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BussinesAdsController : ControllerBase
    {
        private readonly IBussinesAdsService _bussinesAdsService;

        private readonly JwtConfig _jwtConfig;

        public BussinesAdsController(IBussinesAdsService bussinesAdsService, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _bussinesAdsService = bussinesAdsService;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        [HttpGet]
        [Route("GetBussinesAd")]
        public async Task<IActionResult> GetBussinesAd([FromQuery] int adId)
        {
            var ad = await _bussinesAdsService.GetBusinessAd(adId);

            if (ad == null)
            {
                return Ok(new BaseResponse { IsSuccess = false, Message = "0" });
            }

            return Ok(ad);
        }

        [Authorize]
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromForm] BussinesAdDTO dataModel)
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

            var response = await _bussinesAdsService.AddBussinesAd((int)userId, dataModel);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response);
        }

        [HttpPost]
        [Route("FilterBusiness")]
        public async Task<IActionResult> FilterBusiness([FromForm] BusinessFilters dataModel)
        {
            var response = await _bussinesAdsService.FilterBusiness(dataModel);

            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update([FromForm] UpdateBusinessAdDTO dataModel)
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

            var response = await _bussinesAdsService.UpdateBussinesAd((int)userId, dataModel);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response);
        }
    }
}

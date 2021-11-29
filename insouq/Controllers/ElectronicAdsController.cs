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
    public class ElectronicAdsController : ControllerBase
    {
        private readonly IElectronicService _electronicService;

        private readonly JwtConfig _jwtConfig;

        public ElectronicAdsController(IElectronicService electronicService, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _electronicService = electronicService;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        [HttpGet]
        [Route("GetElectronicAd")]
        public async Task<IActionResult> GetElectronicAd([FromQuery] int adId)
        {
            var ad = await _electronicService.GetElectronicAd(adId);

            if (ad == null)
            {
                return Ok(new BaseResponse { IsSuccess = false, Message = "0" });
            }

            return Ok(ad);
        }

        [Authorize]
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromForm] ElectronicAdDTO dataModel)
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

            var response = await _electronicService.AddElectronicAd((int)userId, dataModel);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response);
        }

        [HttpPost]
        [Route("FilterElectronics")]
        public async Task<IActionResult> FilterElectronics([FromForm] ElectronicFilters dataModel)
        {
            var response = await _electronicService.FilterElectronics(dataModel);

            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update([FromForm] UpdateElectronicsDTO dataModel)
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

            var response = await _electronicService.UpdateElectronicAd((int)userId, dataModel);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response);
        }
    }
}

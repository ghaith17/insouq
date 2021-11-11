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
    public class ClassifiedAdsController : ControllerBase
    {
        private readonly IClassifiedAdsService _classifiedAdsService;

        private readonly JwtConfig _jwtConfig;

        public ClassifiedAdsController(IClassifiedAdsService classifiedAdsService, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _classifiedAdsService = classifiedAdsService;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        [HttpGet]
        [Route("GetClassifiedAd")]
        public async Task<IActionResult> GetClassifiedAd([FromQuery] int adId)
        {
            var ad = await _classifiedAdsService.GetClassifiedAd(adId);

            if (ad == null)
            {
                return Ok(new BaseResponse { IsSuccess = false, Message = "0" });
            }

            return Ok(ad);
        }


        [Authorize]
        [HttpPost]
        [Route("AddInitialClassified")]
        public async Task<IActionResult> AddInitialClassified([FromBody] AddInitialClassified dataModel)
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

            var response = await _classifiedAdsService.AddInitialClassified((int)userId, dataModel);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response);
        }

        [Authorize]
        [HttpPost]
        [Route("AddFullClassified")]
        public async Task<IActionResult> AddFullClassified([FromForm] ClassifiedAdDTO dataModel)
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

            var response = await _classifiedAdsService.AddClassifiedAd((int)userId, dataModel);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response);
        }  
        
        [HttpPost]
        [Route("FilterClassifieds")]
        public async Task<IActionResult> FilterClassifieds([FromBody] ClassifiedFilters dataModel)
        {
            var response = await _classifiedAdsService.FilterClassifieds(dataModel);

            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update([FromForm] UpdateClassifiedDTO dataModel)
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

            var response = await _classifiedAdsService.UpdateClassifiedAd((int)userId, dataModel);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response);
        }
    }
}

using insouq.Configuration;
using insouq.Services.IServices;
using insouq.Shared.DTOS;
using insouq.Shared.DTOS.TypeDTOS;
using insouq.Shared.Responses;
using insouq.Shared.Utility;
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
    public class AdsController : ControllerBase
    {
        private readonly IAdsService _adsService;

        private readonly IUsersService _usersService;

        private readonly JwtConfig _jwtConfig;


        public AdsController(IAdsService adsService, IOptionsMonitor<JwtConfig> optionsMonitor, IUsersService usersService)
        {
            _adsService = adsService;
            _jwtConfig = optionsMonitor.CurrentValue;
            _usersService = usersService;
        }

        [HttpPost]
        [Route("GetAds")]
        public async Task<IActionResult> GetAds([FromBody] GetAdsDTO getAdsDTO)
        {
            var ads = await _adsService.GetAdsByCategoryId(getAdsDTO.TypeId, getAdsDTO.CategoryId , getAdsDTO.SearchText, getAdsDTO.Location, getAdsDTO.MaxKm == null ? 0 : getAdsDTO.MaxKm, getAdsDTO.MinKm == null ? 0 : getAdsDTO.MinKm, getAdsDTO.MaxYear == null ? 0 : getAdsDTO.MaxYear, getAdsDTO.MinYear , getAdsDTO.MaxPrice,getAdsDTO.MinPrice, getAdsDTO.Maker, getAdsDTO.Model, getAdsDTO.Trim);

            return Ok(ads);

        }

        [HttpGet]
        [Route("GetAd")]
        public async Task<IActionResult> GetAd([FromQuery] int adId, [FromQuery] int typeId)
        {
            var ad = await _adsService.GetAd(adId, typeId);

            if (ad == null)
            {
                return Ok(new BaseResponse { IsSuccess = false, Message = "0" });
            }

            return Ok(ad);
        }

        [HttpGet]
        [Route("GetMyAds")]
        public async Task<IActionResult> GetMyAds([FromQuery] int typeId)
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

            var ads = await _adsService.GetUserAds((int)userId, typeId, true);

            return Ok(ads);
        }

        [HttpGet]
        [Route("GetMyFavoriteAds")]
        public async Task<IActionResult> GetMyFavoriteAds([FromQuery] int typeId)
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

            var ads = await _adsService.GetMyFavoriteAds((int)userId, typeId);

            return Ok(ads);
        }

        [HttpGet]
        [Route("GetMyFavoriteAdsCount")]
        public async Task<IActionResult> GetMyFavoriteAdsCount()
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

            var ads = await _adsService.GetMyFavoriteAdsCount((int)userId);

            return Ok(ads);
        }

        [HttpGet]
        [Route("GetSavedSearchCount")]
        public async Task<IActionResult> GetSavedSearchCount()
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

            var ads = await _adsService.GetSavedSearchCount((int)userId);

            return Ok(ads);
        }


        [HttpGet]
        [Route("GetSavedSearches")]
        public async Task<IActionResult> GetSavedSearches(int typeId)
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

            var ads = await _usersService.getSavedSearches((int)userId, typeId);

            return Ok(ads);
        }

        [HttpPost]
        [Route("DeleteSavedSearch")]
        public async Task<IActionResult> DeleteSavedSearch(SavedSearchDTO savedSearchDTO)
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

            var ads = await _adsService.DeleteSavedSearch((int)userId, savedSearchDTO.SearchId);

            return Ok(ads);
        }

        [HttpGet]
        [Route("IsInFavorite")]
        public async Task<IActionResult> IsInFavorite([FromQuery] int adId)
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

            var value = await _adsService.IsInFavorite((int)userId, adId);

            var response =  new BooleanResponse() { Result = value, IsSuccess = true };

            return Ok(response);
        }

        [HttpGet]
        [Route("IsOfferMaked")]
        public async Task<IActionResult> IsOfferMaked([FromQuery] int adId)
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

            var value = await _adsService.IsOfferMaked((int)userId, adId);

            var response = new BooleanResponse() { Result = value, IsSuccess = true };

            return Ok(response);
        }

        [HttpGet]
        [Route("IsJobApplicationApplied")]
        public async Task<IActionResult> IsJobApplicationApplied([FromQuery] int adId)
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

            var value = await _adsService.IsJobApplicationApplied((int)userId, adId);

            var response = new BooleanResponse() { Result = value, IsSuccess = true };

            return Ok(response);
        }

        [HttpGet]
        [Route("GetUserAds")]
        public async Task<IActionResult> GetUserAds([FromQuery] int userId, [FromQuery] int typeId)
        {
            var ads = await _adsService.GetUserAds(userId, typeId, false);

            return Ok(ads);
        }

        [HttpGet]
        [Route("GetSimilarAds")]
        public async Task<IActionResult> GetSimilarAds([FromQuery] int typeId, [FromQuery] int categoryId, [FromQuery] int currentAdId)
        {
            var ads = await _adsService.GetSimilarAds(typeId, categoryId, currentAdId);

            return Ok(ads);
        }

        [HttpGet]
        [Route("GetUserAdsCount")]
        public async Task<IActionResult> GetUserAdsCount([FromQuery] int userId)
        {
            var ads = await _adsService.GetUserAdsCount(userId, false);

            return Ok(ads);
        }

        [HttpGet]
        [Route("GetMyAdsCount")]
        public async Task<IActionResult> GetMyAdsCount()
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
            var ads = await _adsService.GetUserAdsCount((int)userId, true);

            return Ok(ads);
        }

        [HttpGet]
        [Route("GetLatestAds")]
        public async Task<IActionResult> GetLatestAds([FromQuery] int typeId)
        {
            var ads = await _adsService.GetLatestAds(typeId);

            return Ok(ads);
        }

        //[HttpGet]
        //[Route("GetAdsByCategoryId")]
        //public async Task<IActionResult> GetAdsByCategoryId([FromQuery] int typeId, [FromQuery] int categoryId)
        //{
        //    var ads = await _adsService.GetAdsByCategoryId(typeId, categoryId, "", "");

        //    return Ok(ads);
        //}

        [HttpPost]
        [Route("MakeAnOffer")]
        public async Task<IActionResult> MakeAnOffer([FromBody] MakeAnOfferDTO model)
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

            var response = await _adsService.MakeAnOffer((int)userId, model);

            return Ok(response);
        }

        [HttpPost]
        [Route("DeleteAd")]
        public async Task<IActionResult> DeleteAd([FromBody] DeleteAdDTO model)
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

            var response = await _adsService.DeleteAd((int)userId, model.AdId);

            return Ok(response);
        }

        [HttpPost]
        [Route("ReportAd")]
        public async Task<IActionResult> ReportAd([FromBody] ReportDTO model)
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

            var response = await _adsService.ReportAd((int)userId, model);

            return Ok(response);
        }



        [HttpPost]
        [Route("AddToFavorite")]
        public async Task<IActionResult> AddToFavorite([FromBody] FavoriteAdDTO model)
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

            var response = await _adsService.AddToFavorite((int)userId, model);

            return Ok(response);
        }

        [HttpPost]
        [Route("RemoveFromFavorite")]
        public async Task<IActionResult> RemoveFromFavorite([FromBody] FavoriteAdDTO model)
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

            var response = await _adsService.RemoveFromFavorite((int)userId, model);

            return Ok(response);
        }

        [HttpPost]
        [Route("ApplyForJob")]
        public async Task<IActionResult> ApplyForJob([FromForm] ApplyJobDTO model)
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

            var response = await _adsService.ApplyForJob((int)userId, model);

            return Ok(response);
        }
    }
}

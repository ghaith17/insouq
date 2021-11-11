using insouq.Configuration;
using insouq.Services.IServices;
using insouq.Shared.DTOS.UserDTOS;
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
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _userService;

        private readonly JwtConfig _jwtConfig;

        public UsersController(IUsersService userService, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _userService = userService;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        // Done
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var user = await _userService.GetById(id);

            if(user == null)
            {
                return Ok(new BaseResponse { IsSuccess = false, Message = "0" });
            }

            return Ok(user);
        }

        //Done
        [HttpGet]
        [Route("GetByEmailOrPhone")]
        public async Task<IActionResult> GetByEmailOrPhone([FromQuery] string value)
        {
            var user = await _userService.GetByEmailOrPhone(value);

            if (user == null)
            {
                return Ok(new BaseResponse { IsSuccess = false, Message = "0" });
            }

            return Ok(user);
        }

        // Done
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] AddUserDTO model)
        {
            if (!ModelState.IsValid)
            {
                var Errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return BadRequest(new BaseResponse { IsSuccess = false, Message = Errors });
            }

            var resposne = await _userService.Add(model, "Mobile");

            if (resposne.IsSuccess) return Ok(resposne);

            return BadRequest(resposne);
        }

        //Done (Need to check if we need to upload photo first or upload the whole form directly)
        [Authorize]
        [HttpPost]
        [Route("UpdateProfile")]
        public async Task<IActionResult> UpdateProfile([FromForm] UpdateProfileDTO model)
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

            var response = await _userService.UpdateProfile((int)userId, model);

            if (response.IsSuccess) return Ok(response);

            if (response.Message == StaticData.Unauthorized_Message) return Unauthorized(response);

            return BadRequest(response);
        }

        //Done (Need to check if we need to upload photo first or upload the whole form directly)
        [HttpPost]
        [Route("UpdateCompanyProfile")]
        public async Task<IActionResult> UpdateCompanyProfile([FromForm] UpdateCompanyProfileDTO model)
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

            var response = await _userService.UpdateCompanyProfile((int)userId, model);

            if (response.IsSuccess) return Ok(response);

            if (response.Message == StaticData.Unauthorized_Message) return Unauthorized(response);

            return BadRequest(response);
        }
    }
}

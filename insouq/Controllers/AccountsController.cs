using insouq.Configuration;
using insouq.Services.IServices;
using insouq.Shared.DTOS.AccountsDTOS;
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
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService _accountsService;

        private readonly JwtConfig _jwtConfig;

        public AccountsController(IAccountsService accountsService, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _accountsService = accountsService;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        //[Authorize]
        [HttpPost]
        [Route("SendEmailCode")]
        public async Task<IActionResult> SendEmailCode([FromBody] SendEmailCodeDTO model)
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
            var response = await _accountsService.SendEmailCode((int)userId, model);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response);
        }

        //[Authorize]
        [HttpPost]
        [Route("VerifyEmailCode")]
        public async Task<IActionResult> VerifyEmailCode([FromBody] VerifyEmailCodeDTO model)
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

            var response = await _accountsService.VerifyEmailCode((int)userId, model);

            if (response.IsSuccess) return Ok(response);

            if (response.Message == StaticData.Unauthorized_Message) return Unauthorized(response);

            return BadRequest(response);
        }

        //[Authorize]
        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO model)
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

            var response = await _accountsService.ChangePassword((int)userId, model);

            if (response.IsSuccess) return Ok(response);

            if (response.Message == StaticData.Unauthorized_Message) return Unauthorized(response);

            return BadRequest(response);
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDTO model)
        {
            if (!ModelState.IsValid)
            {
                var Errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return BadRequest(new BaseResponse { IsSuccess = false, Message = Errors });
            }

            var response = await _accountsService.ForgotPassword(model);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response);
        }


        [HttpPost]
        [Route("VerifyForgotPasswordCode")]
        public async Task<IActionResult> VerifyForgotPasswordCode([FromBody] VerifyEmailCodeDTO model)
        {
            if (!ModelState.IsValid)
            {
                var Errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return BadRequest(new BaseResponse { IsSuccess = false, Message = Errors });
            }

            var response = await _accountsService.VerifyForgotPasswordCode(model);

            if (response.IsSuccess) return Ok(response);

            if (response.Message == StaticData.Unauthorized_Message) return Unauthorized(response);

            return BadRequest(new BaseResponse { IsSuccess = false, Message = response.Message });
        }

        [HttpPost]
        [Route("ResetPasswordEmail")]
        public async Task<IActionResult> ResetPasswordEmail([FromBody] ResetPasswordDTO model)
        {
            if (!ModelState.IsValid)
            {
                var Errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return BadRequest(new BaseResponse { IsSuccess = false, Message = Errors });
            }

            var response = await _accountsService.ResetPassword(model);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response);
        }

        //[Authorize]
        [HttpPost]
        [Route("ConfirmMobileNumber")]
        public async Task<IActionResult> ConfirmMobileNumber([FromBody] ConfirmMobileNumberDTO model)
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

            var response = await _accountsService.ConfirmMobileNumber((int)userId, model);

            if (response.IsSuccess) return Ok(response);

            if (response.Message == StaticData.Unauthorized_Message) return Unauthorized(response);

            return BadRequest(response);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                var Errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return BadRequest(new BaseResponse { IsSuccess = false, Message = Errors });
            }

            var response = await _accountsService.Login(model);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(new BaseResponse { IsSuccess = false, Message = response.Message });
        }

        [HttpPost]
        [Route("FacebookLogin")]
        public async Task<IActionResult> FacebookLogin([FromBody] ExternalLoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                var Errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return BadRequest(new BaseResponse { IsSuccess = false, Message = Errors });
            }

            var response = await _accountsService.FacebookLogin(model.Token, "API");

            if (response.IsSuccess) return Ok(response);

            return BadRequest(new BaseResponse { IsSuccess = false, Message = response.Message });

        }

        [HttpPost]
        [Route("GmailLogin")]
        public async Task<IActionResult> GmailLogin([FromBody] ExternalLoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                var Errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return BadRequest(new BaseResponse { IsSuccess = false, Message = Errors });
            }

            var response = await _accountsService.GmailLogin(model.Token, "API");

            if (response.IsSuccess) return Ok(response);

            return BadRequest(new BaseResponse { IsSuccess = false, Message = response.Message });

        }

        [HttpPost]
        [Route("RequestForgotPasswordToken")]
        public async Task<IActionResult> RequestForgotPasswordToken([FromBody] RequestForgotPasswordTokenDTO model)
        {
            if (!ModelState.IsValid)
            {
                var Errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return BadRequest(new BaseResponse { IsSuccess = false, Message = Errors });
            }

            var response = await _accountsService.RequestForgotPasswordToken(model.MobileNumber);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);

        }

        [HttpPost]
        [Route("ResetPasswordMobile")]
        public async Task<IActionResult> ResetPasswordMobile([FromBody] ResetMobilePasswordDTO model)
        {
            if (!ModelState.IsValid)
            {
                var Errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return BadRequest(new BaseResponse { IsSuccess = false, Message = Errors });
            }

            var response = await _accountsService.ResetPasswordMobile(model);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);

        }
    }
}

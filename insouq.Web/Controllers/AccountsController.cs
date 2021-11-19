using insouq.Models.IdentityConfiguration;
using insouq.Services.IServices;
using insouq.Shared.DTOS.AccountsDTOS;
using insouq.Shared.DTOS.UserDTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace insouq.Web.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAccountsService _accountService;
        private readonly IUsersService _userService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountsController(
            IAccountsService accountService,
            IUsersService userService,
            SignInManager<ApplicationUser> signInManager)
        {
            _accountService = accountService;
            _userService = userService;
            _signInManager = signInManager;
        }

        private int getUserId()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return Int32.Parse(claims.Value);
        }
        public IActionResult Index()
        {
            return View();
        }


        #region API_CALLS

        [HttpPost]
        public async Task<JsonResult> Register([FromBody] AddUserDTO model)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return Json(new { isSuccess = false, message = errors });
            }

            var addUserResponse = await _userService.Add(model, "Web");

            if(!addUserResponse.IsSuccess)
            {
                return Json(addUserResponse);
            }

            var sendSmsCodeDTO = new SendSmsCodeDTO
            {
                MobileNumber = model.MobileNumber,
                UserId = addUserResponse.UserId
            };

            var sendCodeResponse = await _accountService.SendSmsCode(sendSmsCodeDTO);

            if (!sendCodeResponse.IsSuccess)
            {
                return Json(sendCodeResponse);
            }

            return Json(new { isSuccess = true, message = "User Registered Successfully", userId = addUserResponse.UserId });
        }

        [HttpPost]
        public async Task<JsonResult> VerifySmsCode([FromBody] VerifySmsCodeDTO model)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return Json(new { isSuccess = false, message = errors });
            }

            var response = await _accountService.VerifySmsCode(model);

            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> SendSmsCode([FromBody] SendSmsCodeDTO model)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return Json(new { isSuccess = false, message = errors });
            }

            var response = await _accountService.SendSmsCode(model);

            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> Login([FromBody] LoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return Json(new { isSuccess = false, message = errors });
            }

            var response = await _accountService.WebLogin(model);

            return Json(response);
        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> ChangePassword([FromBody] ChangePasswordDTO model)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return Json(new { isSuccess = false, message = errors });
            }

            var response = await _accountService.ChangePassword(getUserId(), model);

            return Json(response);
        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> SendEmailCode([FromBody] SendEmailCodeDTO model)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return Json(new { isSuccess = false, message = errors });
            }

            var response = await _accountService.SendEmailCode(getUserId(), model);

            return Json(response);

        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> VerifyEmailCode([FromBody] VerifyEmailCodeDTO model)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return Json(new { isSuccess = false, message = errors });
            }

            var response = await _accountService.VerifyEmailCode(getUserId(), model);

            return Json(response);

        }


        [HttpPost]
        public async Task<JsonResult> ForgotPassword([FromBody] ForgotPasswordDTO model)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return Json(new { isSuccess = false, message = errors });
            }

            var response = await _accountService.ForgotPassword(model);

            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> VerifyForgotPasswordCode([FromBody] VerifyEmailCodeDTO model)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return Json(new { isSuccess = false, message = errors });
            }

            var response = await _accountService.VerifyForgotPasswordCode(model);

            return Json(response);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO model)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return Json(new { isSuccess = false, message = errors });
            }

            var response = await _accountService.ResetPassword(model);

            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> FacebookLogin(string accessToken)
        {
            var response = await _accountService.FacebookLogin(accessToken, "Web");

            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> GmailLogin(string idToken)
        {
            var response = await _accountService.GmailLogin(idToken, "Web");

            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> LoginAfterReg(string email)
        {
            var response = await _accountService.LoginAfterReg(email);

            return Json(response);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}

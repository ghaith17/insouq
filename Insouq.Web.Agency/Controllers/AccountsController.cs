using insouq.Models.IdentityConfiguration;
using insouq.Services.Agency;
using insouq.Services.IServices;
using insouq.Services.IServices.Agency;
using insouq.Shared.DTOS.AccountsDTOS;
using insouq.Shared.DTOS.AgencyDTOS;
using insouq.Shared.DTOS.UserDTOS;
using insouq.Shared.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Insouq.Web.Agency.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAccountsService _accountService;
        private readonly IAgencyAccountService _agencyAccounttService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountsController(
            IAccountsService accountService,
            IAgencyAccountService agencyAccounttService,
            SignInManager<ApplicationUser> signInManager)
        {
            _accountService = accountService;
            _agencyAccounttService = _agencyAccounttService;
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
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MotorRegister()
        {
            return View();
        }
        [HttpGet]
        public IActionResult PrpoertyRegister()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Registration([FromForm] RegisterMotorsDTO model)
        {
            HttpContext.Session.SetObjectAsJson("CompanyData", model);
            return View();
        }


        [HttpPost]
        public async Task<JsonResult> RegisterMotors([FromForm] RegisterMotorsDTO model)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return Json(new { isSuccess = false, message = errors });
            }

            var addUserResponse = await _agencyAccounttService.RegisterMotors(model);

            if (!addUserResponse.IsSuccess)
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
        [HttpGet]
        public  IActionResult Login()
        {
            return View();
;        }
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

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
            _agencyAccounttService = agencyAccounttService;
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
      
        
        [HttpGet] // to return view
        public IActionResult MotorRegister([FromQuery] RegisterAgencyDTO model)
        {
            HttpContext.Session.SetObjectAsJson("CompanyData", model);
            return View();
        }
        [HttpGet] // to return view
        public IActionResult PropertyRegister()
        {
            return View();
        }
       
        [HttpGet] // to save in session
        public IActionResult RegisterFullMotors([FromQuery] RegisterAgencyDTO model)
        {
           
            HttpContext.Session.SetObjectAsJson("CompanyData", model);
            return View(model);
        }
        [HttpGet] // to save in session
        public IActionResult RegisterFullProperty([FromQuery] RegisterAgencyDTO model)
        {
            HttpContext.Session.SetObjectAsJson("CompanyData", model);
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddFullMotors([FromForm] RegisterAgencyDTO model)
        {
            var CompanyDetails = HttpContext.Session.GetObjectFromJson<RegisterAgencyDTO>("CompanyData");
            model.MobileNumber ="00"+ model.PhoneCode.Remove(0,1)+ model.MobileNumber;
            model.CompanyName= CompanyDetails.CompanyName;
            model.LicenseIssuingAuthority= CompanyDetails.LicenseIssuingAuthority;
            model.TradeLicenseCopyPath= CompanyDetails.TradeLicenseCopyPath;
            model.ShowroomAddress= CompanyDetails.ShowroomAddress;

            //if (!ModelState.IsValid)
            //{
            //    var errors = string.Join(Environment.NewLine,
            //        ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

            //    return Json(new { isSuccess = false, message = errors });
            //}
            

            var registerMotorsResponse = await _agencyAccounttService.RegisterMotors(model);

            if (!registerMotorsResponse.IsSuccess)
            {
                TempData["Message"]= registerMotorsResponse.Message;
                return View("RegisterFullMotors");
            }

            var sendSmsCodeDTO = new SendSmsCodeDTO
            {
                MobileNumber = model.MobileNumber,
                UserId = registerMotorsResponse.UserId
            };

            var sendCodeResponse = await _accountService.SendSmsCode(sendSmsCodeDTO);

            if (!sendCodeResponse.IsSuccess)
            {
                TempData["Message"] = sendCodeResponse.Message;
                return View("RegisterFullMotors");
            }



            return RedirectToAction("Verify");
        }
        [HttpPost]
        public async Task<IActionResult> AddFullProperty([FromForm] RegisterAgencyDTO model)
        {
            var CompanyDetails = HttpContext.Session.GetObjectFromJson<RegisterAgencyDTO>("CompanyData");
            model.MobileNumber = "00" + model.PhoneCode.Remove(0, 1) + model.MobileNumber;
            model.CompanyName = CompanyDetails.CompanyName;
            model.LicenseIssuingAuthority = CompanyDetails.LicenseIssuingAuthority;
            model.TradeLicenseCopyPath = CompanyDetails.TradeLicenseCopyPath;
            model.BrokerNo = CompanyDetails.BrokerNo;
            model.BrokerIdCopyPath= CompanyDetails.BrokerIdCopyPath;
            model.ReraListerCompanyName = CompanyDetails.ReraListerCompanyName;
            model.ReraPermitNumber = CompanyDetails.ReraPermitNumber;
            model.ReraAgentName = CompanyDetails.ReraAgentName;

           

            var registerMotorsResponse = await _agencyAccounttService.RegisterPropoerty(model);

            if (!registerMotorsResponse.IsSuccess)
            {
                TempData["Message"] = registerMotorsResponse.Message;
                return View("RegisterFullProperty");
            }

            var sendSmsCodeDTO = new SendSmsCodeDTO
            {
                MobileNumber = model.MobileNumber,
                UserId = registerMotorsResponse.UserId
            };

            var sendCodeResponse = await _accountService.SendSmsCode(sendSmsCodeDTO);

            if (!sendCodeResponse.IsSuccess)
            {
                TempData["Message"] = sendCodeResponse.Message;
                return View("RegisterFullProperty");
            }



            return RedirectToAction("Verify");
        }
        [HttpGet] // to return view
        public IActionResult Verify()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> Verify([FromBody] VerifySmsCodeDTO model)
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
        public async Task<JsonResult> SendSmsCode(SendSmsCodeDTO model)
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
        public async Task<IActionResult> Login([FromForm] LoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return Json(new { isSuccess = false, message = errors });
            }

            var response = await _agencyAccounttService.Login(model);
            if (!response.IsSuccess)
            {
                TempData["Message"] = response.Message;
                return View();
            }
            return RedirectToAction("index","Motors");
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
        [HttpGet]
        public async Task<IActionResult> Review()
        {
            return View();
        }
        #endregion
    }
}

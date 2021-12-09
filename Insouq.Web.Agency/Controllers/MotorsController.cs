using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using insouq.Services.IServices;
using insouq.Services.IServices.Agency;
using insouq.Shared.DTOS;
using insouq.Shared.DTOS.Filters;
using insouq.Shared.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insouq.Web.Agency.Controllers
{
    public class MotorsController : Controller
    {
        private readonly IAccountsService _accountService;
        private readonly IAgencyAccountService _agencyAccountService;
        private readonly IAgencyMotorsServices _AgencyMotorsService;
        private readonly IUsersService _usersService;
        private readonly IDropDownService _dropDownService;

        public MotorsController(IAccountsService accountService, IAgencyAccountService agencyAccountService, IAgencyMotorsServices agencyMotorsService, IUsersService usersService, IDropDownService dropDownService)
        {
            _accountService = accountService;
            _AgencyMotorsService = agencyMotorsService;
            _usersService = usersService;
            _dropDownService = dropDownService;
            _agencyAccountService = agencyAccountService;
        }

        private int getUserId()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return Int32.Parse(claims.Value);
        }
        private async Task<insouq.Models.User> getUser()
        {
            var user = await _agencyAccountService.GetUserById(getUserId());
            return user;
        }
        private async Task<insouq.Models.Agent> getAgent()
        {
            var agent = await _agencyAccountService.GetAgentByUserId(getUserId());
            return agent;
        }

        public async Task<IActionResult> index()
        {
            ViewBag.phoneNumber = await _usersService.GetPhoneNumber(getUserId());
            var agency = await _agencyAccountService.GetAgencyByUserId(getUserId());
            //HttpContext.Session.SetObjectAsJson("agency", agency);
            HttpContext.Session.SetString("SessionAgencyName", agency.Name);
            var user = await getUser();
            HttpContext.Session.SetString("SessionAgencyPicture", user.ProfilePicture);
            var agent = await getAgent();
            HttpContext.Session.SetString("SessionMobileNumberWithCode", user.MobileNumber);
            HttpContext.Session.SetString("SessionWorkNumber", agent.WorkNumber);
            return View();
        }

        public ActionResult PostMotorsAd()
        {
            return View();
        }
        public async Task<IActionResult> Add(int categoryId)
        {
            //if (categoryId == 0)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            categoryId = 2;
            
            //HttpContext.Session.SetString("agencyName", agency.Name);
            var dto = new insouq.Shared.DTOS.AgencyDTOS.MotorsAdDTO
            {
                CategoryId = categoryId,
            };
            return View(dto);
        }

        //[HttpPost]
        //[AutoValidateAntiforgeryToken]
        //public async Task<IActionResult> AddInitalMotor(AddInitalMotor dto)
        //{
        //    var hostName = $"https://{this.Request.Host}";
        //    var response = await _motorsService.AddInitialMotor(getUserId(), dto, hostName);

        //    if (!response.IsSuccess)
        //    {
        //        ModelState.AddModelError(string.Empty, response.Message);
        //        return View(dto);
        //    }

        //    return RedirectToAction(nameof(Add), new { id = response.Id, categoryId = dto.CategoryId, });
        //}

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Add(insouq.Shared.DTOS.AgencyDTOS.MotorsAdDTO dto)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(dto);
            //}
            var hostName = $"https://{this.Request.Host}";
            var response = await _AgencyMotorsService.Add(getUserId(), dto, hostName);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);
                return View(dto);
            }

            return RedirectToAction("PackagesSubsicription", "Ads");
        }



        public async Task<IActionResult> Update(int adId)
        {
            var ad = await _AgencyMotorsService.GetMotorAd(adId);

            if (ad == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(ad);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(UpdateMotorsDTO dto)
        {
            var hostName = $"https://{this.Request.Host}";
            var response = await _AgencyMotorsService.Update(getUserId(), dto, hostName);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);
                return View(dto);
            }

            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public async Task<IActionResult> FilterMotors([FromBody] MotorFilters dto)
        {
            var list = await _AgencyMotorsService.FilterMotors(dto);

            return PartialView("~/Views/Partials/_UserAd.cshtml", list);

        }

        public IActionResult GetData(int categoryId)
        {
            return PartialView("~/Views/Partials/_MotorData.cshtml", categoryId);
        }
    }
}

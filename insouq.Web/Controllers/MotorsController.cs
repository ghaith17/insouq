using insouq.Services.IServices;
using insouq.Shared.DTOS;
using insouq.Shared.DTOS.Filters;
using insouq.Shared.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace insouq.Web.Controllers
{
    public class MotorsController : Controller
    {
        private readonly IMotorsService _motorsService;
        private readonly IUsersService _usersService;
        private readonly IDropDownService _dropDownService;

        public MotorsController(IMotorsService motorsService, IUsersService usersService, IDropDownService dropDownService)
        {
            _motorsService = motorsService;
            _usersService = usersService;
            _dropDownService = dropDownService;
        }

        private int getUserId()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return Int32.Parse(claims.Value);
        }

        public async Task<IActionResult> Add(int id, int categoryId)
        {
            if (categoryId == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.phoneNumber = await _usersService.GetPhoneNumber(getUserId());

            var dto = new MotorsAdDTO
            {
                AdId = id,
                CategoryId = categoryId,
            };

            return View(dto);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddInitalMotor(AddInitalMotor dto)
        {
            var hostName = $"https://{this.Request.Host}";
            var response = await _motorsService.AddInitialMotor(getUserId(), dto, hostName);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);
                return View(dto);
            }

            return RedirectToAction(nameof(Add), new { id = response.Id, categoryId = dto.CategoryId, });
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Add(MotorsAdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var hostName = $"https://{this.Request.Host}";
            var response = await _motorsService.Add(getUserId(), dto , hostName);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);
                return View(dto);
            }

            return RedirectToAction("PackagesSubsicription", "Ads");
        }



        public async Task<IActionResult> Update(int adId)
        {
            var ad = await _motorsService.GetMotorAd(adId);

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
            var response = await _motorsService.Update(getUserId(), dto, hostName);

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
            var list = await _motorsService.FilterMotors(dto);

            return PartialView("~/Views/Partials/_UserAd.cshtml", list);

        }

        public IActionResult GetData(int categoryId)
        {
            return PartialView("~/Views/Partials/_MotorData.cshtml", categoryId);
        }
    }
}

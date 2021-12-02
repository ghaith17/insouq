using insouq.Services.IServices;
using insouq.Shared.DTOS;
using insouq.Shared.DTOS.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace insouq.Web.Controllers
{
    public class NumbersController : Controller
    {
        private readonly INumberAdsService _numberAdsService;

        private readonly IUsersService _usersService;

        public NumbersController(INumberAdsService numberAdsService, IUsersService usersService)
        {
            _numberAdsService = numberAdsService;
            _usersService = usersService;
        }

        private int getUserId()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return Int32.Parse(claims.Value);
        }

        public async Task<IActionResult> Add(int categoryId)
        {
            if(categoryId == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.phoneNumber = await _usersService.GetPhoneNumber(getUserId());

            var dto = new NumberAdDTO
            {
                CategoryId = categoryId,
            };

            return View(dto);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Add(NumberAdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var hostName = $"{this.Request.Scheme}://{this.Request.Host}";
            var response = await _numberAdsService.Add(getUserId(), dto ,hostName);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);
                return View(dto);
            }

            return RedirectToAction("PackagesSubsicription", "Ads");
        }
       


        public async Task<IActionResult> Update(int adId)
        {
            var ad = await _numberAdsService.GetNumberAd(adId);

            if (ad == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(ad);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(NumberAdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var response = await _numberAdsService.Update(getUserId(), dto);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);
                return View(dto);
            }

            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public async Task<IActionResult> FilterNumbers([FromBody] NumberFilters dto)
        {
            var list = await _numberAdsService.FilterNumbers(dto);

            return PartialView("~/Views/Partials/_UserAd.cshtml", list);

        }
    }
}

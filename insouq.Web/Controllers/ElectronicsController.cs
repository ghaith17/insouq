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
    public class ElectronicsController : Controller
    {
        private readonly IElectronicService _electronicService;

        private readonly IUsersService _usersService;

        public ElectronicsController(IElectronicService electronicService, IUsersService usersService)
        {
            _electronicService = electronicService;
            _usersService = usersService;
        }


        private int getUserId()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return Int32.Parse(claims.Value);
        }

        public async Task<ViewResult> Add(int categoryId)
        {
            ViewBag.phoneNumber = await _usersService.GetPhoneNumber(getUserId());

            var electronicAdDTO = new ElectronicAdDTO
            {
                CategoryId = categoryId
            };

            return View(electronicAdDTO);
        }

        [HttpPost]
        public async Task <IActionResult> Add(ElectronicAdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var response = await _electronicService.AddElectronicAd(getUserId(), dto);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);

                return View();
            }

            return RedirectToAction("PackagesSubsicription", "Ads");
        }


        public async Task<IActionResult> Update(int adId)
        {
            var updateElectronicsDTO = await _electronicService.GetElectronicAd(adId);

            if (updateElectronicsDTO == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(updateElectronicsDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateElectronicsDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var response = await _electronicService.UpdateElectronicAd(getUserId(), dto);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);

                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<PartialViewResult> FilterElectronics([FromBody] ElectronicFilters dto)
        {
            var list = await _electronicService.FilterElectronics(dto);

            return PartialView("~/Views/Partials/_UserAd.cshtml", list);
        }
    }
}

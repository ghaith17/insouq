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
    public class BusinessController : Controller
    {
        private readonly IBussinesAdsService _bussinesAdsService;

        private readonly ICategoryService _categoryService;

        private readonly IUsersService _usersService;

        public BusinessController(
            IBussinesAdsService bussinesAdsService,
            ICategoryService categoryService,
            IUsersService usersService)
        {
            _bussinesAdsService = bussinesAdsService;
            _categoryService = categoryService;
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
            var category = await _categoryService.GetById(categoryId);

            if (category == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.phoneNumber = await _usersService.GetPhoneNumber(getUserId());

            var bussinesAdDTO = new BussinesAdDTO
            {
                CategoryId = categoryId,
            };

            return View(bussinesAdDTO);
        }

        [HttpPost]
        public async Task <IActionResult> Add(BussinesAdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var response = await _bussinesAdsService.AddBussinesAd(getUserId(), dto);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);

                return View();
            }

            return RedirectToAction("PackagesSubsicription", "Ads");
        }


        public async Task<IActionResult> Update(int adId)
        {
            var updateBusinessAdDTO = await _bussinesAdsService.GetBusinessAd(adId);

            if (updateBusinessAdDTO == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(updateBusinessAdDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBusinessAdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var response = await _bussinesAdsService.UpdateBussinesAd(getUserId(), dto);

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
        public async Task<IActionResult> FilterBusiness([FromBody] BusinessFilters dto)
        {
            var list = await _bussinesAdsService.FilterBusiness(dto);

            return PartialView("~/Views/Partials/_UserAd.cshtml", list);

        }
    }
}

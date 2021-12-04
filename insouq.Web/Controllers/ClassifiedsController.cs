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
    public class ClassifiedsController : Controller
    {
        private readonly IClassifiedAdsService _classifiedAdsService;

        private readonly IUsersService _usersService;

        public ClassifiedsController(IClassifiedAdsService classifiedAdsService, IUsersService usersService)
        {
            _classifiedAdsService = classifiedAdsService;
            _usersService = usersService;
        }


        private int getUserId()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return Int32.Parse(claims.Value);
        }

        public async Task<ViewResult> Add(int id, int categoryId)
        {
            ViewBag.phoneNumber = await _usersService.GetPhoneNumber(getUserId());

            var ClassifiedAdDTO = new ClassifiedAdDTO
            {
                AdId = id,
                CategoryId = categoryId
            };

            return View(ClassifiedAdDTO);
        }

        [HttpPost]
        public async Task <IActionResult> Add(ClassifiedAdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var hostName = $"{this.Request.Scheme}://{this.Request.Host}";
            var response = await _classifiedAdsService.AddClassifiedAd(getUserId(), dto, hostName);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);

                return View();
            }

            return RedirectToAction("PackagesSubsicription", "Ads");
        }


        [HttpPost]
        public async Task<IActionResult> AddInitalClassified(AddInitialClassified dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var hostName = $"{this.Request.Scheme}://{this.Request.Host}";
            var response = await _classifiedAdsService.AddInitialClassified(getUserId(), dto, hostName);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);

                return View();
            }

            return RedirectToAction(nameof(Add), new { id = response.Id, categoryId = dto.CategoryId, });
        }


        public async Task<IActionResult> Update(int adId)
        {
            var updateClassifiedDTO = await _classifiedAdsService.GetClassifiedAd(adId);

            if (updateClassifiedDTO == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(updateClassifiedDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateClassifiedDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var hostName = $"{this.Request.Scheme}://{this.Request.Host}";
            var response = await _classifiedAdsService.UpdateClassifiedAd(getUserId(), dto, hostName);

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
        public async Task<IActionResult> FilterClassifieds([FromBody] ClassifiedFilters dto)
        {
            var list = await _classifiedAdsService.FilterClassifieds(dto);

            return PartialView("~/Views/Partials/_UserAd.cshtml", list);

        }

        public PartialViewResult GetInitialClassifiedData()
        {
            return PartialView("~/Views/Partials/_ClassifiedData.cshtml");
        }
    }
}

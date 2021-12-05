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
    public class ServicesController : Controller
    {
        private readonly IServiceAdsService _serviceAdsService;

        private readonly IUsersService _usersService;

        public ServicesController(IServiceAdsService serviceAdsService, IUsersService usersService)
        {
            _serviceAdsService = serviceAdsService;
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

            var serviceAdDTO = new ServiceAdDTO
            {
                CategoryId = categoryId,
            };

            return View(serviceAdDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ServiceAdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var hostName = $"https://{this.Request.Host}";
            var response = await _serviceAdsService.AddServiceAd(getUserId(), dto,hostName);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);

                return View();
            }

            return RedirectToAction("PackagesSubsicription", "Ads");
        }


        public async Task<ViewResult> Update(int adId)
        {
            var ad = await _serviceAdsService.GetServiceAd(adId);

            var serviceAdDTO = new ServiceAdDTO
            {
                Title = ad.Title,
                AdId = ad.Id,
                CarLiftFrom = ad.CarLiftFrom,
                CarLiftTo = ad.CarLiftTo,
                CategoryId = ad.CategoryId,
                Description = ad.Description,
                Lat = ad.Lat,
                Lng = ad.Lng,
                Location = ad.En_Location + "-" + ad.Ar_Location,
                OtherSubCategory = ad.OtherServiceType,
                PhoneNumber = ad.PhoneNumber,
                SubCategoryId = ad.ServiceTypeId,
            };

            return View(serviceAdDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ServiceAdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var hostName = $"https://{this.Request.Host}";
            var response = await _serviceAdsService.UpdateServiceAd(getUserId(), dto, hostName);

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
        public async Task<IActionResult> FilterServices([FromBody] ServiceFilters dto)
        {
            var list = await _serviceAdsService.FilterServices(dto);

            return PartialView("~/Views/Partials/_UserAd.cshtml", list);

        }

        public async Task<PartialViewResult> GetServiceData(int categoryId)
        {
            ViewBag.phoneNumber = await _usersService.GetPhoneNumber(getUserId());

            return PartialView("~/Views/Partials/_ServiceData.cshtml", categoryId);

        }
    }
}

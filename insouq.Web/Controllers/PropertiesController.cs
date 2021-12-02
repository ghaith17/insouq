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
    public class PropertiesController : Controller
    {
        private readonly IPropertyAdService _propertyAdService;

        public PropertiesController(IPropertyAdService propertyAdService)
        {
            _propertyAdService = propertyAdService;
        }

        private int getUserId()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return Int32.Parse(claims.Value);
        }

        public IActionResult Add(int categoryId)
        {
            if(categoryId == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            var dto = new PropertyAdDTO
            {
                CategoryId = categoryId,
                ReadyBy = null,
            };

            return View(dto);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Add(PropertyAdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var hostName = $"{this.Request.Scheme}://{this.Request.Host}";
            var response = await _propertyAdService.Add(getUserId(), dto ,hostName);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);
                return View(dto);
            }

            return RedirectToAction("PackagesSubsicription", "Ads");
        }


        public async Task<IActionResult> Update(int adId)
        {
            var ad = await _propertyAdService.GetPropertyAd(adId);

            if (ad == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(ad);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(UpdatePropertyAdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var response = await _propertyAdService.Update(getUserId(), dto);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);
                return View(dto);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<PartialViewResult> FilterProperities([FromBody] PropertyFilters dto)
        {
            var ads = await _propertyAdService.FilterProperities(dto);

            return PartialView("~/Views/Partials/_UserAd.cshtml", ads);

        }
    }
}

using insouq.Services.IServices.CMS;
using insouq.Shared.DTOS.CMS;
using insouq.Shared.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsouqWebCMS.Controllers
{
    [Authorize(Roles = StaticData.Admin_Role)]
    public class CommonDLController : Controller
    {
        private readonly ICMSDropDownService _cmsDropDownService;

        public CommonDLController(ICMSDropDownService cmsDropDownService)
        {
            _cmsDropDownService = cmsDropDownService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Locations()
        {
            var list = await _cmsDropDownService.GetAllLocation();

            return View(list);
        }

        public async Task<IActionResult> AdvertisingBudjets()
        {
            var list = await _cmsDropDownService.GetAllAdvertisingBudjet();

            return View(list);
        }

        #region API_CALLS

        #region LOCATION_DL


        [HttpPost]
        public async Task<IActionResult> AddLocation(TextDropDownDTO model)
        {
            var response = await _cmsDropDownService.AddLocation(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Locations));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLocation(TextDropDownDTO model)
        {
            var response = await _cmsDropDownService.UpdateLocation(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Locations));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteLocation(int id)
        {
            var response = await _cmsDropDownService.DeleteLocation(id);

            return Json(response);
        }


        #endregion

        #region LOCATION_DL


        [HttpPost]
        public async Task<IActionResult> AddAdvertisingBudjet(TextDropDownDTO model)
        {
            var response = await _cmsDropDownService.AddAdvertisingBudjet(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(AdvertisingBudjets));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAdvertisingBudjet(TextDropDownDTO model)
        {
            var response = await _cmsDropDownService.UpdateAdvertisingBudjet(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(AdvertisingBudjets));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteAdvertisingBudjet(int id)
        {
            var response = await _cmsDropDownService.DeleteAdvertisingBudjet(id);

            return Json(response);
        }

        #endregion

        #endregion
    }
}
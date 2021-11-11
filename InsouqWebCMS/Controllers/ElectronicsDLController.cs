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
    public class ElectronicsDLController : Controller
    {
        private readonly ICMSDropDownService _dropDownService;

        public ElectronicsDLController(ICMSDropDownService dropDownService)
        {
            _dropDownService = dropDownService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Ages(int typeId)
        {
            var list = await _dropDownService.GetAllAgeByTypeId(typeId);

            ViewBag.TypeId = typeId;

            return View(list);
        }

        public async Task<IActionResult> Usages(int typeId)
        {
            var list = await _dropDownService.GetAllUsageByTypeId(typeId);

            ViewBag.TypeId = typeId;

            return View(list);
        }

        public async Task<IActionResult> Colors()
        {
            var list = await _dropDownService.GetAllColor();

            return View(list);
        }

        #region API_CALLS

        #region AGE_APIS

        [HttpPost]
        public async Task<IActionResult> AddAge(CategoryTextDropDownDTO model)
        {
            var response = await _dropDownService.AddAge(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Ages), new { typeId = model.TypeId });
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAge(CategoryTextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateAge(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Ages), new { typeId = model.TypeId });
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteAge(int id)
        {
            var response = await _dropDownService.DeleteAge(id);

            return Json(response);
        }

        #endregion

        #region USAGE_APIS

        [HttpPost]
        public async Task<IActionResult> AddUsage(CategoryTextDropDownDTO model)
        {
            var response = await _dropDownService.AddUsage(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Usages), new { typeId = model.TypeId });
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUsage(CategoryTextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateUsage(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Usages), new { typeId = model.TypeId });
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteUsage(int id)
        {
            var response = await _dropDownService.DeleteUsage(id);

            return Json(response);
        }

        #endregion

        #region COLOR_APIS

        [HttpPost]
        public async Task<IActionResult> AddColor(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddColor(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Colors));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateColor(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateColor(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Colors));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteColor(int id)
        {
            var response = await _dropDownService.DeleteColor(id);

            return Json(response);
        }

        #endregion

        #endregion
    }
}
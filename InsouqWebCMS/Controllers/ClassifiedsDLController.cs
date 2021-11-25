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
    public class ClassifiedsDLController : Controller
    {
        private readonly ICMSDropDownService _dropDownService;

        public ClassifiedsDLController(ICMSDropDownService dropDownService)
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

        public async Task<IActionResult> Conditions(int typeId)
        {
            var list = await _dropDownService.GetAllConditionByTypeId(typeId);

            ViewBag.TypeId = typeId;

            return View(list);
        }

        public async Task<IActionResult> Brands()
        {
            var list = await _dropDownService.GetAllClassifiedBrand();

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

        #region CONDITION_APIS

        [HttpPost]
        public async Task<IActionResult> AddCondition(CategoryTextDropDownDTO model)
        {
            var response = await _dropDownService.AddCondition(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Conditions), new { typeId = model.TypeId });
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCondition(CategoryTextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateCondition(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Conditions), new { typeId = model.TypeId });
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteCondition(int id)
        {
            var response = await _dropDownService.DeleteCondition(id);

            return Json(response);
        }

        #endregion

        #endregion

        #region BRAND_APIS
        [HttpPost]
        public async Task<IActionResult> AddClassifiedBrand(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddClassifiedBrand(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Brands));
            }

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> UpdateClassifiedBrand(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateClassifiedBrand(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Brands));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteClassifiedBrand(int id)
        {
            var response = await _dropDownService.DeleteClassifiedBrand(id);

            return Json(response);
        }
        #endregion
    }
}
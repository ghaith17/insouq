using insouq.Services.IServices;
using insouq.Services.IServices.CMS;
using insouq.Shared.DTOS;
using insouq.Shared.DTOS.CMS;
using insouq.Shared.Utility;
using InsouqWebCMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsouqWebCMS.Controllers
{
    [Authorize(Roles = StaticData.Admin_Role)]
    public class SubTypeController : Controller
    {
        private readonly ISubTypeService _subTypeService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly ICategoryService _categoryService;

        public SubTypeController(
            ISubTypeService subTypeService, 
            ISubCategoryService subCategoryService,
            ICategoryService categoryService)
        {
            _subTypeService = subTypeService;
            _subCategoryService = subCategoryService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(int categoryId)
        {
            var subTypeVM = new SubTypeVM
            {
                SubCategories = await _subCategoryService.GetByCategoryId(categoryId),
                SubTypes = await _subTypeService.GetByCategoryId(categoryId)
            };

            ViewBag.CategoryId = categoryId;

            return View(subTypeVM);
        }

        public async Task<IActionResult> WithCategory(int typeId)
        {

            var subTypeWithCatVM = new SubTypeWithCatVM
            {
                Categories = await _categoryService.GetByTypeId(typeId),
                SubCategories = await _subCategoryService.GetByTypeId(typeId),
                SubTypes = await _subTypeService.GetByTypeId(typeId)
            };

            ViewBag.TypeId = typeId;


            return View(subTypeWithCatVM);
        }

        #region API_CALLS

        [HttpPost]
        public async Task<IActionResult> AddSubType(UpsertSubTypeDTO model)
        {
            var response = await _subTypeService.AddSubType(model);

            if (response.IsSuccess)
            {
                if (model.TypeId != null)
                {
                    return RedirectToAction(nameof(WithCategory), new { typeId = model.TypeId });
                }
                return RedirectToAction(nameof(Index), new { categoryId = model.CategoryId });
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSubType(UpsertSubTypeDTO model)
        {
            var response = await _subTypeService.UpdateSubType(model);

            if (response.IsSuccess)
            {
                if (model.TypeId != null)
                {
                    return RedirectToAction(nameof(WithCategory), new { typeId = model.TypeId });
                }
                return RedirectToAction(nameof(Index), new { categoryId = model.CategoryId });
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteSubType(int id)
        {
            var response = await _subTypeService.DeleteSubType(id);

            return Json(response);
        }

        #endregion

    }
}

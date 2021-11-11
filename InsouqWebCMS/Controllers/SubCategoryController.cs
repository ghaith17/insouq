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
    public class SubCategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        private readonly ISubCategoryService _subCategoryService;

        public SubCategoryController(ICategoryService categoryService, ISubCategoryService subCategoryService)
        {
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
        }

        public async Task<IActionResult> Index(int categoryId)
        {
            var list = await _subCategoryService.GetByCategoryId(categoryId);

            ViewBag.CategoryId = categoryId;

            return View(list);
        }

        public async Task<IActionResult> WithCategory(int typeId)
        {
            var categories = await _categoryService.GetByTypeId(typeId);

            categories = categories.Where(c => c.Id != StaticData.CarLift_ID).ToList();

            var subCategoryVM = new SubCategoryVM
            {
                Categories = categories,
                SubCategories = await _subCategoryService.GetByTypeId(typeId)
            };

            ViewBag.TypeId = typeId;


            return View(subCategoryVM);
        }

        #region API_CALLS

        [HttpGet]
        public async Task<JsonResult> GetSubCategory(int categoryId)
        {
            var list = await _subCategoryService.GetByCategoryId(categoryId);

            return Json(list);
        }

        [HttpPost]
        public async Task<IActionResult> AddSubCategory(SubCategoryModel model)
        {
            var subcategoryDTO = new SubCategoryDTO
            {
                Ar_Name = model.Ar_Name,
                En_Name = model.En_Name,
                CategoryId = model.CategoryId,
            };

            var response = await _subCategoryService.AddSubCategory(subcategoryDTO);

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
        public async Task<IActionResult> UpdateSubCategory(SubCategoryModel model)
        {
            var subcategoryDTO = new SubCategoryDTO
            {
                Ar_Name = model.Ar_Name,
                En_Name = model.En_Name,
                CategoryId = model.CategoryId,
                Id = model.Id
            };

            var response = await _subCategoryService.UpdateSubCategory(subcategoryDTO);

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
        public async Task<JsonResult> DeleteSubCategory(int id)
        {
            var response = await _subCategoryService.DeleteSubCategory(id);

            return Json(response);
        }

        #endregion

    }
}

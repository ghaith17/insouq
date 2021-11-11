using insouq.Services.IServices;
using insouq.Services.IServices.CMS;
using insouq.Shared.DTOS;
using insouq.Shared.DTOS.CategoryDTOS;
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
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(int typeId)
        {
            var list = await _categoryService.GetByTypeId(typeId);

            ViewBag.TypeId = typeId;

            return View(list);
        }

        #region API_CALLS

        [HttpPost]
        public async Task<IActionResult> AddCategory(UpsertCategoryDTO upsertCategoryDTO)
        {
            var response = await _categoryService.Add(upsertCategoryDTO);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Index), new { typeId = upsertCategoryDTO.TypeId });
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpsertCategoryDTO upsertCategoryDTO)
        {
            var response = await _categoryService.Update(upsertCategoryDTO);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Index), new { typeId = upsertCategoryDTO.TypeId });
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteCategory(int id)
        {
            var response = await _categoryService.Delete(id);

            return Json(response);
        }

        #endregion

    }
}

using insouq.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace insouq.Web.Controllers
{
    public class SubCategoriesController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;

        public SubCategoriesController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        public IActionResult Index()
        {
            return View();
        }


        #region API_CALLS

        public async Task<JsonResult> GetSubCategories(int categoryId)
        {
            var items = await _subCategoryService.GetByCategoryId(categoryId);

            return Json(new { items = items });
        }

        #endregion
    }
}

using insouq.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace insouq.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }


        #region API_CALLS

        public async Task<JsonResult> GetCategories(int typeId)
        {
            var items = await _categoryService.GetByTypeId(typeId);

            return Json(new { count = items.Count, items = items });
        }

        #endregion
    }
}

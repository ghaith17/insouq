using insouq.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace insouq.Web.Controllers
{
    public class SubTypesController : Controller
    {
        private readonly ISubTypeService _subTypeService;

        public SubTypesController(ISubTypeService subTypeService)
        {
            _subTypeService = subTypeService;
        }

        public IActionResult Index()
        {
            return View();
        }


        #region API_CALLS

        public async Task<JsonResult> GetSubTypes(int subCategoryId)
        {
            var items = await _subTypeService.GetBySubCategoryId(subCategoryId);

            return Json(new { items = items });
        }

        #endregion
    }
}

using insouq.Services.IServices;
using insouq.Shared.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace insouq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {

        private readonly ISubCategoryService _subcategoryService;

        public SubCategoryController(ISubCategoryService subcategoryService)
        {
            _subcategoryService = subcategoryService;
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var subCategory = await _subcategoryService.GetById(id);

            if (subCategory == null)
            {
                return Ok(new BaseResponse { IsSuccess = false, Message = "0" });
            }

            return Ok(subCategory);
        }

        [HttpGet]
        [Route("GetByName")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            var subCategory = await _subcategoryService.GetByName(name);

            if (subCategory == null)
            {
                return Ok(new BaseResponse { IsSuccess = false, Message = "0" });
            }

            return Ok(subCategory);
        }

        [HttpGet]
        [Route("GetByCategoryId")]
        public async Task<IActionResult> GetByCategoryId([FromQuery] int categoryId)
        {
            var subCategory = await _subcategoryService.GetByCategoryId(categoryId);

            if (subCategory == null)
            {
                return Ok(new BaseResponse { IsSuccess = false, Message = "0" });
            }

            return Ok(subCategory);
        }
    }
}

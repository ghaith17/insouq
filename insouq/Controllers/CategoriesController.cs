using insouq.Services.IServices;
using insouq.Shared.DTOS.CategoryDTOS;
using insouq.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace insouq.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var category = await _categoryService.GetById(id);

            if (category == null)
            {
                return Ok(new BaseResponse { IsSuccess = false, Message = "0" });
            }

            return Ok(category);
        }

        [HttpGet]
        [Route("GetByName")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            var category = await _categoryService.GetByName(name);

            if (category == null)
            {
                return Ok(new BaseResponse { IsSuccess = false, Message = "0" });
            }

            return Ok(category);
        }

        [HttpGet]
        [Route("GetByTypeId")]
        public async Task<IActionResult> GetByTypeId([FromQuery] int id)
        {
            var category = await _categoryService.GetByTypeId(id);

            if (category == null)
            {
                return Ok(new BaseResponse { IsSuccess = false, Message = "0" });
            }

            return Ok(category);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] UpsertCategoryDTO model)
        {
            if (!ModelState.IsValid)
            {
                var Errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return BadRequest(new BaseResponse { IsSuccess = false, Message = Errors });
            }
            var hostName = $"https://{this.Request.Host}";
            var resposne = await _categoryService.Add(model, hostName);

            if (resposne.IsSuccess) return Ok(resposne);

            return BadRequest(resposne);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] UpsertCategoryDTO model)
        {
            if (!ModelState.IsValid)
            {
                var Errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return BadRequest(new BaseResponse { IsSuccess = false, Message = Errors });
            }
            var hostName = $"https://{this.Request.Host}";
            var resposne = await _categoryService.Update(model, hostName);

            if (resposne.IsSuccess) return Ok(resposne);

            return BadRequest(resposne);
        }
    }
}

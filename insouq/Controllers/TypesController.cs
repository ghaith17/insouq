using insouq.Services.IServices;
using insouq.Shared.DTOS.TypeDTOS;
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
    public class TypesController : ControllerBase
    {
        private readonly ITypeService _typeService;

        public TypesController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var type = await _typeService.GetById(id);

            if (type == null)
            {
                return Ok(new BaseResponse { IsSuccess = false, Message = "0" });
            }

            return Ok(type);
        }

        [HttpGet]
        [Route("GetByIdWithCategories")]
        public async Task<IActionResult> GetByIdWithCategories([FromQuery] int id)
        {
            var type = await _typeService.GetByIdWithCategories(id);

            if (type == null)
            {
                return Ok(new BaseResponse { IsSuccess = false, Message = "0" });
            }

            return Ok(type);
        }

        [HttpGet]
        [Route("GetByName")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            var type = await _typeService.GetByName(name);

            if (type == null)
            {
                return Ok(new BaseResponse { IsSuccess = false, Message = "0" });
            }

            return Ok(type);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var types = await _typeService.GetAll();

            return Ok(types);
        }

        [HttpGet]
        [Route("GetAllWithCategories")]
        public async Task<IActionResult> GetAllWithCategories()
        {
            var types = await _typeService.GetAllWithCategories();

            return Ok(types);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] AddTypeDTO model)
        {
            if (!ModelState.IsValid)
            {
                var Errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return BadRequest(new BaseResponse { IsSuccess = false, Message = Errors });
            }
            var hostName = $"https://{this.Request.Host}";
            var resposne = await _typeService.Add(model, hostName);

            if (resposne.IsSuccess) return Ok(resposne);

            return BadRequest(resposne);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] AddTypeDTO model)
        {
            if (!ModelState.IsValid)
            {
                var Errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return BadRequest(new BaseResponse { IsSuccess = false, Message = Errors });
            }
            var hostName = $"https://{this.Request.Host}";
            var resposne = await _typeService.Update(id, model, hostName);

            if (resposne.IsSuccess) return Ok(resposne);

            return BadRequest(resposne);
        }
    }
}

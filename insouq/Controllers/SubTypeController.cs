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
    public class SubTypeController : ControllerBase
    {
        private readonly ISubTypeService _subTypeService;

        public SubTypeController(ISubTypeService subTypeService)
        {
            _subTypeService = subTypeService;
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var subTpye = await _subTypeService.GetById(id);

            if (subTpye == null)
            {
                return Ok(new BaseResponse { IsSuccess = false, Message = "0" });
            }

            return Ok(subTpye);
        }

        [HttpGet]
        [Route("GetByName")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            var subTpye = await _subTypeService.GetByName(name);

            if (subTpye == null)
            {
                return Ok(new BaseResponse { IsSuccess = false, Message = "0" });
            }

            return Ok(subTpye);
        }

        [HttpGet]
        [Route("GetBySubCategoryId")]
        public async Task<IActionResult> GetBySubCategoryId([FromQuery] int subCategoryId)
        {
            var subTpye = await _subTypeService.GetBySubCategoryId(subCategoryId);

            if (subTpye == null)
            {
                return Ok(new BaseResponse { IsSuccess = false, Message = "0" });
            }

            return Ok(subTpye);
        }
    }
}

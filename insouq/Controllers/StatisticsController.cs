using insouq.Configuration;
using insouq.Services.IServices;
using insouq.Shared.DTOS;
using insouq.Shared.Responses;
using insouq.Shared.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace insouq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly JwtConfig _jwtConfig;

        public StatisticsController(IUsersService usersService, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _usersService = usersService;
            _jwtConfig = optionsMonitor.CurrentValue;

        }

        [HttpPost]
        [Route("GetUserStatistics")]
        public IActionResult GetUserStatistics(StatisticDTO statisticDTO)
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            var userId = HelperFunctions.ValidateJwtToken(token, _jwtConfig.Secret);

            if (userId == null)
            {
                return Unauthorized(new BaseResponse
                {
                    IsSuccess = false,
                    Message = StaticData.Unauthorized_Message
                });
            }

            string statistics = _usersService.getUserStatistics((int)userId, statisticDTO.AdId, (StatisticTypes)statisticDTO.Type, (StatisticPeriod)statisticDTO.Period);

            return Ok(statistics);
        }
    }
}

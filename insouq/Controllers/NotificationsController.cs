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
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationsService _notificationsService;
        private readonly JwtConfig _jwtConfig;

        public NotificationsController(INotificationsService notificationsService, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _notificationsService = notificationsService;
            _jwtConfig = optionsMonitor.CurrentValue;

        }

        [HttpGet]
        [Route("GetNotifications")]
        public IActionResult GetNotifications()
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

            var ads = _notificationsService.GetNotifications((int)userId);

            return Ok(ads);
        }

        [HttpPost]
        [Route("DeleteNotification")]
        public IActionResult DeleteNotification(NotificationDTO notificationDTO)
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

            var ads = _notificationsService.DeleteNotification(notificationDTO.NotificationId, (int)userId);

            return Ok(ads);
        }

        [HttpGet]
        [Route("HasUnOpendNotifications")]
        public IActionResult HasUnOpendNotifications()
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

            var value = _notificationsService.HasUnOpendNotifications((int)userId);

            var response = new BooleanResponse() { Result = value, IsSuccess = true };

            return Ok(response);
        }
    }
}

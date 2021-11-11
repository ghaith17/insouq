using insouq.Models;
using insouq.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services.IServices
{
    public interface INotificationsService
    {
        BaseResponse DeleteNotification(int id, int userId);
        List<Notification> GetNotifications(int userId);

  //      Task<BaseResponse> DeleteNotification(int id, int userId);
        bool HasUnOpendNotifications(int userId);
    }
}

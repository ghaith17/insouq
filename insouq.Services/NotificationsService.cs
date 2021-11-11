using insouq.EntityFramework;
using insouq.Models;
using insouq.Services.IServices;
using insouq.Shared.Responses;
using insouq.Shared.Utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services
{
    public class NotificationsService : INotificationsService
    {
        private readonly ApplicationDbContext _db;

        public NotificationsService(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Notification> GetNotifications(int userId)
        {
            var Notifications= _db.Notifications.Where(n => n.UserId == userId).Include(a => a.Ad).ToList();

            return UpdateToOpend(Notifications);
        }

        public bool HasUnOpendNotifications(int userId)
        {
            var Notifications = _db.Notifications.Where(n => n.UserId == userId && n.Status== NotificationStatus.NOT_VIEWD)
                .Include(a => a.Ad).ToList();

            return Notifications.Count >0 ? true : false;
        }

        public  BaseResponse DeleteNotification(int id,int userId) 
        {
            var response = new BaseResponse();
            try
            {
                var noti = _db.Notifications.Where(n => n.Id == id).FirstOrDefault();

                if (noti == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not Found";
                    return response;
                }

                _db.Notifications.Remove(noti);
                _db.SaveChanges();


                response.IsSuccess = true;
                response.Message ="("+ _db.Notifications.Where(n => n.UserId == userId).ToList().Count().ToString()+")";
                return response;

            }
            catch (Exception E)
            {
                response.IsSuccess = false;
                response.Message = StaticData.ServerError_Message;
                return response;
            }


        }

        public List<Notification>  UpdateToOpend(List<Notification> Notifications)
        {
            foreach(var noti in Notifications)
            {
                noti.Status =NotificationStatus.VIEWD;
            }
            _db.Notifications.UpdateRange(Notifications);
            _db.SaveChanges();
            return Notifications;
        }

    }
}

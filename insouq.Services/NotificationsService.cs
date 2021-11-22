using insouq.EntityFramework;
using insouq.Models;
using insouq.Services.IServices;
using insouq.Shared.Responses;
using insouq.Shared.Utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.Json;
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

        public List<dynamic> GetNotifications(int userId)
        {
            var Notifications= _db.Notifications.Where(n => n.UserId == userId).Include(a => a.Ad)
                .ThenInclude(a=>a.Pictures.Where(p=>p.MainPicture==true))
                .ToList();
            dynamic ad = new ExpandoObject();

            List<dynamic> dynamic_list = new List<dynamic>();
            foreach (var old_ad in Notifications)
            {
                ad.Ad = old_ad.Ad;
                ad.AdId = old_ad.AdId;
                ad.Agent = old_ad.Agent;
                ad.AgentId = old_ad.AgentId;
                ad.Category = old_ad.Category;
                ad.CategoryId = old_ad.CategoryId;
                ad.Code = old_ad.Code;
                ad.Date = old_ad.Date;
                ad.En_Emirate = old_ad.En_Emirate;
                ad.En_PlateType = old_ad.En_PlateType;
                ad.Id = old_ad.Id;
                ad.ImageUrl = old_ad.ImageUrl;
                ad.JobApplication = old_ad.JobApplication;
                ad.JobApplicationId = old_ad.JobApplicationId;
                ad.Number = old_ad.Number;
                ad.Offer = old_ad.Offer;
                ad.OfferId = old_ad.OfferId;
                ad.PlateCode = old_ad.PlateCode;
                ad.Status = old_ad.Status;
                ad.User = old_ad.User;
                ad.UserId = old_ad.UserId;
                ad.spent_time = HelperFunctions.GetTime(old_ad.Date);
             //   object newObj = ad;
                dynamic_list.Add(ad);
            }
            

            return UpdateToOpend(dynamic_list,userId);
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

        public List<dynamic>  UpdateToOpend( List<dynamic> Notifications,int userId)
        {
            var notifications = _db.Notifications.Where(n => n.UserId == userId).Include(a => a.Ad)
                   .ThenInclude(a => a.Pictures.Where(p => p.MainPicture == true))
                   .ToList();

            //   var notifications= Notifications.Cast<Notification>().ToList();
            // var Notifications = JsonSerializer.Deserialize<List<dynamic>>(json.ToString());
            foreach (var noti in notifications)
            {
                noti.Status = NotificationStatus.VIEWD;
            }
            foreach (var noti in Notifications)
            {
                noti.Status = NotificationStatus.VIEWD;
            }
            _db.Notifications.UpdateRange(notifications);
            _db.SaveChanges();
            return Notifications;
        }

    }
}

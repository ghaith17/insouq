using insouq.EntityFramework;
using insouq.Models;
using insouq.Services.IServices;
using insouq.Shared.Utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace insouq.Services
{
    public class CMSAds : ICMSAds
    {
        private readonly ApplicationDbContext _db;
        public CMSAds(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<Ad> GetAllAds()
        {
            var AdsList = _db.Ads.Where(ad => ad.Status == 2 || ad.Status == 1).Include(a=>a.Category).Include(x=>x.Pictures.Where(u=>u.MainPicture == true)).ToList();
            foreach(var ad in AdsList)
            {
                var price = getPrice(ad.Id, ad.TypeId);
                ad.Price = (double)(price == null ? -1 : price);
            }

            return AdsList;
        }


        private double? getPrice(int AdId ,int TypeId)
        {
            if(TypeId == StaticData.Motors_ID)
            {
                return _db.MotorAds.Where(m => m.AdId == AdId).Select(a=>a.Price).FirstOrDefault();
            }

            if (TypeId == StaticData.Electronics_ID)
            {
                return _db.ElectronicAds.Where(m => m.AdId == AdId).Select(a => a.Price).FirstOrDefault();
            }
            if (TypeId == StaticData.Jobs_ID)
            {
                return null;
            }

            if (TypeId == StaticData.Classifieds_ID)
            {
                return _db.ClassifiedAds.Where(m => m.AdId == AdId).Select(a => a.Price).FirstOrDefault();
            }
            if (TypeId == StaticData.Numbers_ID)
            {
                return _db.NumberAds.Where(m => m.AdId == AdId).Select(a => a.Price).FirstOrDefault();
            }
            if (TypeId == StaticData.Properties_ID)
            {
                return _db.PropertyAds.Where(m => m.AdId == AdId).Select(a => a.Price).FirstOrDefault();
            }
            if (TypeId == StaticData.Business_ID)
            {
                return _db.BussinesAds.Where(m => m.AdId == AdId).Select(a => a.Price).FirstOrDefault();
            }

            if (TypeId == StaticData.Services_ID)
            {
                return null;
            }




            return -1;
        }



        public bool updateAdStatus(int adId,int status)
        {
            try
            {

                var ad = _db.Ads.Where(ad => ad.Id == adId).FirstOrDefault();
                ad.Status = status;
                _db.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }

        }

    }
}
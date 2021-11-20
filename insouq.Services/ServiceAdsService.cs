using AutoMapper;
using insouq.EntityFramework;
using insouq.Models;
using insouq.Services.IServices;
using insouq.Shared.DTOS;
using insouq.Shared.DTOS.AdPictureDTOS;
using insouq.Shared.DTOS.Filters;
using insouq.Shared.Responses;
using insouq.Shared.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services
{
    public class ServiceAdsService : IServiceAdsService
    {
        private readonly ApplicationDbContext _db;

        public ServiceAdsService(ApplicationDbContext db, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
        }

        public async Task<BaseResponse> AddServiceAd(int userId, ServiceAdDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var category = await _db.Categories.FirstOrDefaultAsync(a => a.Id == model.CategoryId);

                if (category == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Category not found";
                    return response;
                }

                var locationArray = model.Location.Split('-');

                var en_location = locationArray[0].Trim();

                var ar_location = locationArray[1].Trim();

                var adPictures = new List<AdPicture>();


                var adPicture = new AdPicture()
                {
                    ImageURL = @"\images\defaultAdImage.png",
                    MainPicture = true
                };

                adPictures.Add(adPicture);


                var ad = new Ad()
                {
                    Title = model.Title,
                    Description = model.Description,
                    En_Location = en_location,
                    Ar_Location = ar_location,
                    PostDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    Lat = model.Lat,
                    Lng = model.Lng,
                    UserId = userId,
                    Status = 2,
                    CategoryId = model.CategoryId,
                    TypeId = StaticData.Services_ID,
                    PhoneNumber = model.PhoneNumber,
                    Pictures = adPictures
                };


                await _db.Ads.AddAsync(ad);

                category.NumberOfAds++;

                await _db.SaveChangesAsync();

                var serviceAd = new ServiceAd()
                {
                    SubCategoryId = model.SubCategoryId != 0 ? model.SubCategoryId : null,
                    OtherSubCategory = model.OtherSubCategory,
                    CarLiftFrom = model.CarLiftFrom,
                    CarLiftTo = model.CarLiftTo,
                    AdId = ad.Id
                };

                await _db.ServiceAds.AddAsync(serviceAd);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<List<GetServiceAdDTO>> FilterServices(ServiceFilters model)
        {
            var en_location = "";

            if (!string.IsNullOrEmpty(model.Location))
            {
                en_location = model.Location.Split('-')[0].Trim();
            }

            var query = _db.ServiceAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.SubCategory).Include(a => a.Ad.User)
                .Where(a => a.Ad.Status == 1);

            if (model.SubCategoryId != 0)
            {
                query = query.Where(a => a.SubCategoryId == model.SubCategoryId);
            }

            if (model.PostedIn != null)
            {
                if (model.PostedIn == StaticData.Posted_Today)
                {
                    query = query.Where(a => a.Ad.PostDate.Date == DateTime.Today);
                }

                //else if (model.PostedIn == StaticData.Posted_ThisWeek)
                //{
                //    query = query.Where(a => a.Ad.PostDate.Date == DateTime.);
                //}
            }

            else if (model.SortBy == StaticData.Newest_To_Oldest)
            {
                query = query.OrderByDescending(m => m.Ad.PostDate);
            }
            else if (model.SortBy == StaticData.Oldest_To_Newest)
            {
                query = query.OrderBy(m => m.Ad.PostDate);
            }

            if (!string.IsNullOrEmpty(model.Keyword))
            {
                query = query.Where(a => a.Ad.Title.Contains(model.Keyword));
            }

            if (en_location != "")
            {
                query = query.Where(a => a.Ad.En_Location == en_location);
            }

            var ads = await query.Select(service => new GetServiceAdDTO
            {
                TypeId = service.Ad.TypeId,
                Id = service.Ad.Id,
                ServiceTypeId = service.SubCategoryId,
                ServiceTypeEn_Name = service.SubCategory.En_Name,
                ServiceTypeAr_Name = service.SubCategory.Ar_Name,
                OtherServiceType = service.OtherSubCategory,
                UserImage = service.Ad.User.ProfilePicture,
                AgentId = service.Ad.AgentId,
                CategoryId = service.Ad.CategoryId,
                CategoryArName = service.Ad.Category.Ar_Name,
                CategoryEnName = service.Ad.Category.En_Name,
                Description = service.Ad.Description,
                Lat = service.Ad.Lat,
                Lng = service.Ad.Lng,
                En_Location = service.Ad.En_Location,
                Ar_Location = service.Ad.Ar_Location,
                UserId = service.Ad.UserId,
                PostDate = service.Ad.PostDate,
                Title = service.Ad.Title,
                Status = service.Ad.Status,
                Pictures = service.Ad.Pictures.Select(p => new AdPictureDTO
                {
                    Id = p.Id,
                    ImageURL = p.ImageURL,
                    MainPicture = p.MainPicture
                }).ToList()
            }
            ).AsNoTracking().ToListAsync();

            return ads;
        }

        public async Task<BaseResponse> UpdateServiceAd(int userId, ServiceAdDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var ad = await _db.ServiceAds.Include(a => a.Ad)
                    .FirstOrDefaultAsync(a => a.AdId == model.AdId && a.Ad.UserId == userId);

                if (ad == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not Found";
                    return response;
                }

                var locationArray = model.Location.Split('-');

                var en_location = locationArray[0].Trim();

                var ar_location = locationArray[1].Trim();

                ad.Ad.Description = model.Description;
                ad.Ad.Title = model.Title;
                ad.Ad.En_Location = en_location;
                ad.Ad.Ar_Location = ar_location;
                ad.Ad.Lat = model.Lat;
                ad.Ad.Lng = model.Lng;
                ad.Ad.LastUpdatedDate = DateTime.Now;

                ad.SubCategoryId = model.SubCategoryId != 0 ? model.SubCategoryId : null;
                ad.OtherSubCategory = model.OtherSubCategory;
                ad.CarLiftFrom = model.CarLiftFrom;
                ad.CarLiftTo = model.CarLiftTo;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = StaticData.ServerError_Message;
                return response;
            }

        }


        public async Task<GetServiceAdDTO> GetServiceAd(int adId)
        {

            var ad = await _db.ServiceAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                .Include(a => a.SubCategory)
                .Where(a => a.Ad.Id == adId && a.Ad.Status == 1 || a.Ad.Status == 2)
                .Select(service => new GetServiceAdDTO
                {
                    TypeId = StaticData.Services_ID,
                    Id = service.Ad.Id,
                    PhoneNumber = service.Ad.PhoneNumber,
                    ServiceTypeId = service.SubCategoryId,
                    OtherServiceType = service.OtherSubCategory,
                    ServiceTypeEn_Name = service.SubCategory.En_Name,
                    ServiceTypeAr_Name = service.SubCategory.Ar_Name,
                    AgentId = service.Ad.AgentId,
                    CategoryId = service.Ad.CategoryId,
                    CategoryArName = service.Ad.Category.Ar_Name,
                    CategoryEnName = service.Ad.Category.En_Name,
                    Description = service.Ad.Description,
                    Lat = service.Ad.Lat,
                    Lng = service.Ad.Lng,
                    En_Location = service.Ad.En_Location,
                    Ar_Location = service.Ad.Ar_Location,
                    UserId = service.Ad.UserId,
                    PostDate = service.Ad.PostDate,
                    Title = service.Ad.Title,
                    Status = service.Ad.Status,
                    Pictures = service.Ad.Pictures.Select(p => new AdPictureDTO
                    {
                        Id = p.Id,
                        ImageURL = p.ImageURL,
                        MainPicture = p.MainPicture
                    }).ToList()
                }).AsNoTracking().FirstOrDefaultAsync(a => a.Id == adId);

            return ad;
        }
    }
}

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
    public class BussinesAdsService : IBussinesAdsService
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IAdsService _adsService;

        public BussinesAdsService(
            ApplicationDbContext db,
            IWebHostEnvironment hostEnvironment,
            IAdsService adsService)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
            _adsService = adsService;
        }

        public async Task<BaseResponse> AddBussinesAd(int userId, BussinesAdDTO model,string host)
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

                var pictures = new List<AdPicture>();

                var imgNumber = 1;

                if (model.Pictures.Count != 0)
                {
                    var webRootPath = _hostEnvironment.WebRootPath;

                    var folderPath = Path.Combine(webRootPath, "images");

                    foreach (var picture in model.Pictures)
                    {
                        var imageUrl = await HelperFunctions.UploadImage(folderPath, picture, "ads", host);

                        var isMain = false;

                        if (model.MainPhoto == null)
                        {
                            if (imgNumber == 1)
                            {
                                isMain = true;
                            }
                        }
                        else
                        {
                            isMain = model.MainPhoto.Trim() == picture.FileName.Trim();
                        }

                        var adPicture = new AdPicture()
                        {
                            ImageURL = imageUrl,
                            MainPicture = isMain
                        };

                        imgNumber++;

                        pictures.Add(adPicture);
                    }
                }

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
                    Status = 2, //pending
                    CategoryId = model.CategoryId,
                    Pictures = pictures,
                    TypeId = StaticData.Business_ID,
                    PhoneNumber = model.PhoneNumber,
                };


                await _db.Ads.AddAsync(ad);

                category.NumberOfAds++;

                await _db.SaveChangesAsync();

                var bussinesAd = new BussinesAd()
                {
                    OtherCategoryName = model.OtherCategoryName,
                    SubCategoryId = model.SubCategoryId != 0 ? model.SubCategoryId : null,
                    OtherSubCategoryName = model.OtherSubCategoryName,
                    Price = model.Price,
                    AdId = ad.Id
                };

                await _db.BussinesAds.AddAsync(bussinesAd);

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

        public async Task<List<GetBussinesAdDTO>> FilterBusiness(BusinessFilters model)
        {
            var en_location = "";

            if (!string.IsNullOrEmpty(model.Location))
            {
                en_location = model.Location.Split('-')[0].Trim();
            }

            var query = _db.BussinesAds.Include(a => a.Ad).Include(a => a.SubCategory).Include(a => a.Ad.Pictures).Include(a => a.Ad.User)
                .Where(a => a.Ad.CategoryId == model.CategoryId && a.Price >= model.FromPrice && a.Price <= model.ToPrice
                && a.Ad.Status == 1);

            if (model.SubCategoryId != null)
            {
                query = query.Where(a => a.SubCategoryId == model.SubCategoryId);
            }

            //if (!string.IsNullOrEmpty(model.CategoryName))
            //{
            //    query = query.Where(a => a.OtherCategoryName.Contains(model.CategoryName));
            //}


            //if (!string.IsNullOrEmpty(model.Keyword))
            //{
            //    query = query.Where(a => a.Ad.Title.Contains(model.Keyword));
            //}

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

            if (en_location != "")
            {
                query = query.Where(a => a.Ad.En_Location == en_location);
            }

            if (model.SortBy == StaticData.Price_Heighest_To_Lowest)
            {
                query = query.OrderByDescending(m => m.Price);
            }
            else if (model.SortBy == StaticData.Price_Lowest_To_Heighest)
            {
                query = query.OrderBy(m => m.Price);
            }
            else if (model.SortBy == StaticData.Newest_To_Oldest)
            {
                query = query.OrderByDescending(m => m.Ad.PostDate);
            }
            else if (model.SortBy == StaticData.Oldest_To_Newest)
            {
                query = query.OrderBy(m => m.Ad.PostDate);
            }

            var ads = await query.Select(business => new GetBussinesAdDTO
            {
                TypeId = business.Ad.TypeId,
                Id = business.Ad.Id,
                Price = business.Price,
                PhoneNumber = business.Ad.PhoneNumber,
                OtherCategoryName = business.OtherCategoryName,
                SubCategoryId = business.SubCategoryId,
                SubCategoryArName = business.SubCategory.Ar_Name,
                SubCategoryEnName = business.SubCategory.En_Name,
                OtherSubCategoryName = business.OtherSubCategoryName,
                UserImage = business.Ad.User.ProfilePicture,
                AgentId = business.Ad.AgentId,
                CategoryId = business.Ad.CategoryId,
                CategoryArName = business.Ad.Category.Ar_Name,
                CategoryEnName = business.Ad.Category.En_Name,
                Description = business.Ad.Description,
                Lat = business.Ad.Lat,
                Lng = business.Ad.Lng,
                En_Location = business.Ad.En_Location,
                Ar_Location = business.Ad.Ar_Location,
                UserId = business.Ad.UserId,
                Pictures = business.Ad.Pictures.Select(p => new AdPictureDTO
                {
                    Id = p.Id,
                    ImageURL = p.ImageURL,
                    MainPicture = p.MainPicture

                }).OrderByDescending(p => p.MainPicture).ToList(),
                PostDate = business.Ad.PostDate,
                Title = business.Ad.Title,
                Status = business.Ad.Status
            }
            ).AsNoTracking().ToListAsync();

            return ads;
        }

        // get for update only !!!!!!
        public async Task<UpdateBusinessAdDTO> GetBusinessAd(int adId)
        {
            var ad = await _db.BussinesAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                .Where(a => a.Ad.Status == 1 || a.Ad.Status == 2)
               .Select(business => new GetBussinesAdDTO
               {
                   TypeId = StaticData.Business_ID,
                   Id = business.Ad.Id,
                   Price = business.Price,
                   PhoneNumber = business.Ad.PhoneNumber,
                   OtherCategoryName = business.OtherCategoryName,
                   SubCategoryId = business.SubCategoryId,
                   SubCategoryArName = business.SubCategory.Ar_Name,
                   SubCategoryEnName = business.SubCategory.En_Name,
                   OtherSubCategoryName = business.OtherSubCategoryName,
                   AgentId = business.Ad.AgentId,
                   CategoryId = business.Ad.CategoryId,
                   CategoryArName = business.Ad.Category.Ar_Name,
                   CategoryEnName = business.Ad.Category.En_Name,
                   Description = business.Ad.Description,
                   Lat = business.Ad.Lat,
                   Lng = business.Ad.Lng,
                   En_Location = business.Ad.En_Location,
                   Ar_Location = business.Ad.Ar_Location,
                   UserId = business.Ad.UserId,
                   Pictures = business.Ad.Pictures.Select(p => new AdPictureDTO
                   {
                       Id = p.Id,
                       ImageURL = p.ImageURL,
                       MainPicture = p.MainPicture

                   }).OrderByDescending(p => p.MainPicture).ToList(),
                   PostDate = business.Ad.PostDate,
                   Title = business.Ad.Title,
                   Status = business.Ad.Status
               }).AsNoTracking().FirstOrDefaultAsync(a => a.Id == adId);

            if(ad == null)
            {
                return null;
            }

            var updateBusinessAdDTO = new UpdateBusinessAdDTO
            {
                AdId = ad.Id,
                CategoryId = ad.CategoryId,
                Description = ad.Description,
                Lat = ad.Lat,
                Lng = ad.Lng,
                Location = ad.En_Location + "-" + ad.Ar_Location,
                OtherCategoryName = ad.OtherCategoryName,
                OtherSubCategoryName = ad.OtherSubCategoryName,
                PhoneNumber = ad.PhoneNumber,
                Photos = ad.Pictures,
                Price = ad.Price,
                SubCategoryId = ad.SubCategoryId,
                Title = ad.Title,
            };

            return updateBusinessAdDTO;
        }

        public async Task<BaseResponse> UpdateBussinesAd(int userId, UpdateBusinessAdDTO model, string host)
        {
            var response = new BaseResponse();

            try
            {
                var ad = await _db.BussinesAds.Include(a => a.Ad).Include(a => a.Ad.Pictures)
                    .FirstOrDefaultAsync(a => a.AdId == model.AdId && a.Ad.UserId == userId);

                if (ad == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                var locationArray = model.Location.Split('-');

                var en_location = locationArray[0].Trim();

                var ar_location = locationArray[1].Trim();




                if (!string.IsNullOrEmpty(model.ImagesToDelete))
                {
                    model.ImagesToDelete = model.ImagesToDelete.TrimEnd(',');

                    var imagesToDelete = model.ImagesToDelete.Split(",");

                    if (ad.Ad.Pictures.Count == imagesToDelete.Length && model.Pictures.Count == 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Ad can't exists without any photo";
                        return response;
                    }

                    foreach (var imgId in imagesToDelete)
                    {
                        var adPicture = await _db.AdPictures.FirstOrDefaultAsync(a => a.Id.ToString() == imgId && a.AdId == model.AdId);

                        _db.AdPictures.Remove(adPicture);

                        await _db.SaveChangesAsync();

                        string webRootPath = _hostEnvironment.WebRootPath;
                        var imagePath = Path.Combine(webRootPath, adPicture.ImageURL.TrimStart('\\'));
                        if (File.Exists(imagePath))
                        {
                            File.Delete(imagePath);
                        }
                    }

                }

                var oldAdPictures = ad.Ad.Pictures.ToList();

                var imgCount = 1;

                if (model.Pictures != null)
                {
                    if (model.Pictures.Count != 0)
                    {
                        var webRootPath = _hostEnvironment.WebRootPath;

                        var folderPath = Path.Combine(webRootPath, "images");


                        foreach (var picture in model.Pictures)
                        {
                            var imageUrl = await HelperFunctions.UploadImage(folderPath, picture, "ads", host);

                            var adPicture = new AdPicture()
                            {
                                AdId = ad.AdId,
                                ImageURL = imageUrl,
                            };

                            if (model.MainPhoto == null)
                            {
                                if (imgCount == 1)
                                {
                                    adPicture.MainPicture = true;
                                }
                                else
                                {
                                    adPicture.MainPicture = false;
                                }
                            }
                            else
                            {
                                adPicture.MainPicture = model.MainPhoto.Trim() == picture.FileName.Trim();
                            }

                            await _db.AdPictures.AddAsync(adPicture);

                            imgCount++;

                        }
                    }
                }

                //change main photo

                var oldImgCount = 1;


                foreach (var adPicture in oldAdPictures)
                {
                    if (model.MainPhoto == null)
                    {
                        if (oldImgCount == 1)
                        {
                            adPicture.MainPicture = true;

                        }
                        else
                        {
                            adPicture.MainPicture = false;

                        }
                    }

                    else if (adPicture.ImageURL.Trim() == model.MainPhoto.Trim())
                    {
                        adPicture.MainPicture = true;
                    }
                    else
                    {
                        adPicture.MainPicture = false;
                    }

                    oldImgCount++;

                }

                if(oldAdPictures.Count != 0)
                {
                    _db.AdPictures.UpdateRange(oldAdPictures);
                }

                ad.Ad.Title = model.Title;
                ad.Ad.Description = model.Description;
                ad.Ad.En_Location = en_location;
                ad.Ad.Ar_Location = ar_location;
                ad.Ad.LastUpdatedDate = DateTime.Now;
                ad.Ad.Lat = model.Lat;
                ad.Ad.Lng = model.Lng;
                ad.Ad.CategoryId = model.CategoryId;
                ad.Ad.PhoneNumber = model.PhoneNumber;


                ad.OtherCategoryName = model.OtherCategoryName;
                ad.SubCategoryId = model.SubCategoryId != 0 ? model.SubCategoryId : null;
                ad.OtherSubCategoryName = model.OtherSubCategoryName;
                ad.Price = model.Price;

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
    }
}

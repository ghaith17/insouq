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
    public class ClassifiedAdsService : IClassifiedAdsService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ClassifiedAdsService(ApplicationDbContext db, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<BaseResponse> AddClassifiedAd(int userId, ClassifiedAdDTO model)
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

                var ad = await _db.ClassifiedAds.Include(a => a.Ad).FirstOrDefaultAsync(a => a.AdId == model.AdId);

                if (ad == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Ad not found";
                    return response;
                }

                var en_condition = "";

                var ar_condition = "";

                if (model.Condition != null)
                {
                    var conditionArray = model.Condition.Split('-');
                    en_condition = conditionArray[0].Trim();
                    ar_condition = conditionArray[1].Trim();
                }

                var en_age = "";

                var ar_age = "";

                if (model.Age != null)
                {
                    var ageArray = model.Age.Split('^');
                    en_age = ageArray[0].Trim();
                    ar_age = ageArray[1].Trim();
                }

                var en_brand = "";

                var ar_brand = "";

                if (model.Brand != null)
                {
                    var brandArray = model.Brand.Split('-');
                    en_brand = brandArray[0].Trim();
                    ar_brand = brandArray[1].Trim();
                }

                var en_usage = "";

                var ar_usage = "";

                if (model.Usage != null)
                {
                    var usageArray = model.Usage.Split('-');
                    en_usage = usageArray[0].Trim();
                    ar_usage = usageArray[1].Trim();
                }

                var locationArray = model.Location.Split('-');

                var en_location = locationArray[0].Trim();

                var ar_location = locationArray[1].Trim();

                var pictures = new List<AdPicture>();

                var imgNumber = 1;

                if (model.Pictures.Count != 0)
                {
                    var ContentRootPath = _hostEnvironment.ContentRootPath;

                    var folderPath = Path.Combine(ContentRootPath, "MyStaticFiles\\images");

                    foreach (var picture in model.Pictures)
                    {
                        var imageUrl = await HelperFunctions.UploadImage(folderPath, picture, "ads");

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


                ad.Ad.Description = model.Description;
                ad.Ad.En_Location = en_location;
                ad.Ad.Ar_Location = ar_location;
                ad.Ad.Lat = model.Lat;
                ad.Ad.Lng = model.Lng;
                ad.Ad.Pictures = pictures;
                ad.Ad.PhoneNumber = model.PhoneNumber;
                ad.Ad.Status = 2;

                ad.Price = model.Price;
                ad.En_Age = en_age != "" ? en_age : null;
                ad.Ar_Age = ar_age != "" ? ar_age : null;
                ad.En_Usage = en_usage != "" ? en_usage : null;
                ad.Ar_Usage = ar_usage != "" ? ar_usage : null;
                ad.En_Brand = en_brand != "" ? en_brand : null;
                ad.Ar_Brand = ar_brand != "" ? ar_brand : null;
                ad.En_Condition = en_condition != "" ? en_condition : null;
                ad.Ar_Condition = ar_condition != "" ? ar_condition : null;


                category.NumberOfAds++;


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

        public async Task<AddInitialDataResponse> AddInitialClassified(int userId, AddInitialClassified model)
        {

            var response = new AddInitialDataResponse();

            try
            {
                var ad = new Ad()
                {
                    Title = model.Title,
                    PostDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    UserId = userId,
                    Status = 0,
                    CategoryId = model.CategoryId,
                    TypeId = StaticData.Classifieds_ID,
                };


                await _db.Ads.AddAsync(ad);

                await _db.SaveChangesAsync();

                var classifiedAd = new ClassifiedAd()
                {
                    SubCategoryId = model.SubCategoryId != 0 ? model.SubCategoryId : null,
                    OtherSubCategory = model.OtherSubCategory,
                    SubTypeId = model.SubTypeId != 0 ? model.SubTypeId : null,
                    OtherSubType = model.OtherSubType,
                    AdId = ad.Id
                };

                await _db.ClassifiedAds.AddAsync(classifiedAd);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                response.Id = ad.Id;
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<List<GetClassifiedAdDTO>> FilterClassifieds(ClassifiedFilters model)
        {
            var en_location = "";
            var en_age = "";
            var en_usage = "";
            var en_brand = "";

            if (!string.IsNullOrEmpty(model.Age))
            {
                en_age = model.Age.Split('^')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.Usage))
            {
                en_usage = model.Usage.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.Brand))
            {
                en_brand = model.Brand.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.Location))
            {
                en_location = model.Location.Split('-')[0].Trim();
            }


            var query = _db.ClassifiedAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.User)
                .Where(a => a.Ad.Status == 1 && a.Ad.CategoryId == model.CategoryId && a.Price >= model.FromPrice && a.Price <= model.ToPrice);


            //if (!string.IsNullOrEmpty(model.Keyword))
            //{
            //    query = query.Where(a => a.Ad.Title.Contains(model.Keyword));
            //}

            if (model.SubCategoryId != null)
            {
                query = query.Where(a => a.SubCategoryId == model.SubCategoryId);
            }

            if (model.SubTypeId != null)
            {
                query = query.Where(a => a.SubTypeId == model.SubTypeId);
            }

            if (en_age != "")
            {
                query = query.Where(a => a.En_Age == en_age);
            }

            if (en_usage != "")
            {
                query = query.Where(a => a.En_Usage == en_usage);
            }

            if (en_brand != "")
            {
                query = query.Where(a => a.En_Brand == en_brand);
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

            var ads = await query.Select(classified => new GetClassifiedAdDTO
            {
                TypeId = classified.Ad.TypeId,
                Id = classified.Ad.Id,
                Price = classified.Price,
                En_Age = classified.En_Age,
                Ar_Age = classified.Ar_Age,
                En_Brand = classified.En_Brand,
                Ar_Brand = classified.Ar_Brand,
                PhoneNumber = classified.Ad.PhoneNumber,
                En_Usage = classified.En_Usage,
                Ar_Usage = classified.Ar_Usage,
                En_Condition = classified.En_Condition,
                Ar_Condition = classified.Ar_Condition,
                SubCategoryId = classified.SubCategoryId,
                SubCategoryAr_Name = classified.SubCategory.Ar_Name,
                SubCategoryEn_Name = classified.SubCategory.En_Name,
                SubTypeId = classified.SubTypeId,
                SubTypeAr_Name = classified.SubType.En_Name,
                SubTypeEn_Name = classified.SubType.Ar_Name,
                OtherSubCategory = classified.OtherSubCategory,
                OtherSubType = classified.OtherSubType,
                UserImage = classified.Ad.User.ProfilePicture,
                AgentId = classified.Ad.AgentId,
                CategoryId = classified.Ad.CategoryId,
                CategoryArName = classified.Ad.Category.Ar_Name,
                CategoryEnName = classified.Ad.Category.En_Name,
                Description = classified.Ad.Description,
                Lat = classified.Ad.Lat,
                Lng = classified.Ad.Lng,
                En_Location = classified.Ad.En_Location,
                Ar_Location = classified.Ad.Ar_Location,
                UserId = classified.Ad.UserId,
                PostDate = classified.Ad.PostDate,
                Title = classified.Ad.Title,
                Status = classified.Ad.Status,
                Pictures = classified.Ad.Pictures.Select(p => new AdPictureDTO
                {
                    Id = p.Id,
                    ImageURL = p.ImageURL,
                    MainPicture = p.MainPicture

                }).OrderByDescending(p => p.MainPicture).ToList(),
            }
            ).AsNoTracking().ToListAsync();

            return ads;
        }

        public async Task<BaseResponse> UpdateClassifiedAd(int userId, UpdateClassifiedDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var ad = await _db.ClassifiedAds.Include(a => a.Ad).Include(a => a.Ad.Pictures)
                    .FirstOrDefaultAsync(a => a.AdId == model.AdId && a.Ad.UserId == userId);

                if (ad == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not Found";
                    return response;
                }

                var en_condition = "";

                var ar_condition = "";

                if (model.Condition != null)
                {
                    var conditionArray = model.Condition.Split('-');
                    en_condition = conditionArray[0].Trim();
                    ar_condition = conditionArray[1].Trim();
                }

                var en_age = "";

                var ar_age = "";

                if (model.Age != null)
                {
                    var ageArray = model.Age.Split('^');
                    en_age = ageArray[0].Trim();
                    ar_age = ageArray[1].Trim();
                }

                var en_brand = "";

                var ar_brand = "";

                if (model.Brand != null)
                {
                    var brandArray = model.Brand.Split('-');
                    en_brand = brandArray[0].Trim();
                    ar_brand = brandArray[1].Trim();
                }

                var en_usage = "";

                var ar_usage = "";

                if (model.Usage != null)
                {
                    var usageArray = model.Usage.Split('-');
                    en_usage = usageArray[0].Trim();
                    ar_usage = usageArray[1].Trim();
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
                            var imageUrl = await HelperFunctions.UploadImage(folderPath, picture, "ads");

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

                if (oldAdPictures.Count != 0)
                {
                    _db.AdPictures.UpdateRange(oldAdPictures);
                }

                ad.Ad.Title = model.Title;
                ad.Ad.Description = model.Description;
                ad.Ad.En_Location = en_location;
                ad.Ad.Ar_Location = ar_location;
                ad.Ad.Lat = model.Lat;
                ad.Ad.Lng = model.Lng;
                ad.Ad.PhoneNumber = model.PhoneNumber;
                ad.Ad.LastUpdatedDate = DateTime.Now;

                ad.Price = model.Price;
                ad.En_Age = en_age != "" ? en_age : null;
                ad.Ar_Age = ar_age != "" ? ar_age : null;
                ad.En_Usage = en_usage != "" ? en_usage : null;
                ad.Ar_Usage = ar_usage != "" ? ar_usage : null;
                ad.En_Brand = en_brand != "" ? en_brand : null;
                ad.Ar_Brand = ar_brand != "" ? ar_brand : null;
                ad.En_Condition = en_condition != "" ? en_condition : null;
                ad.Ar_Condition = ar_condition != "" ? ar_condition : null;
                ad.SubCategoryId = model.SubCategoryId != 0 ? model.SubCategoryId : null;
                ad.OtherSubCategory = model.OtherSubCategory;
                ad.SubTypeId = model.SubTypeId != 0 ? model.SubTypeId : null;
                ad.OtherSubType = model.OtherSubType;


                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        // get for update only !!!
        public async Task<UpdateClassifiedDTO> GetClassifiedAd(int adId)
        {
            var ad = await _db.ClassifiedAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                .Include(a => a.SubCategory).Include(a => a.SubType)
                .Where(a => a.Ad.Status == 1 || a.Ad.Status == 2)
                .Select(classified => new GetClassifiedAdDTO
                {
                    TypeId = StaticData.Classifieds_ID,
                    Id = classified.Ad.Id,
                    Price = classified.Price,
                    En_Age = classified.En_Age,
                    Ar_Age = classified.Ar_Age,
                    En_Brand = classified.En_Brand,
                    Ar_Brand = classified.Ar_Brand,
                    PhoneNumber = classified.Ad.PhoneNumber,
                    En_Usage = classified.En_Usage,
                    Ar_Usage = classified.Ar_Usage,
                    En_Condition = classified.En_Condition,
                    Ar_Condition = classified.Ar_Condition,
                    SubCategoryId = classified.SubCategoryId,
                    SubCategoryAr_Name = classified.SubCategory.Ar_Name,
                    SubCategoryEn_Name = classified.SubCategory.En_Name,
                    SubTypeId = classified.SubTypeId,
                    SubTypeAr_Name = classified.SubType.En_Name,
                    SubTypeEn_Name = classified.SubType.Ar_Name,
                    OtherSubCategory = classified.OtherSubCategory,
                    OtherSubType = classified.OtherSubType,
                    AgentId = classified.Ad.AgentId,
                    CategoryId = classified.Ad.CategoryId,
                    CategoryArName = classified.Ad.Category.Ar_Name,
                    CategoryEnName = classified.Ad.Category.En_Name,
                    Description = classified.Ad.Description,
                    Lat = classified.Ad.Lat,
                    Lng = classified.Ad.Lng,
                    En_Location = classified.Ad.En_Location,
                    Ar_Location = classified.Ad.Ar_Location,
                    UserId = classified.Ad.UserId,
                    PostDate = classified.Ad.PostDate,
                    Title = classified.Ad.Title,
                    Status = classified.Ad.Status,
                    Pictures = classified.Ad.Pictures.Select(p => new AdPictureDTO
                    {
                        Id = p.Id,
                        ImageURL = p.ImageURL,
                        MainPicture = p.MainPicture

                    }).OrderByDescending(p => p.MainPicture).ToList(),
                }).AsNoTracking().FirstOrDefaultAsync(a => a.Id == adId);


            if (ad == null) return null;

            var updateClassifiedDTO = new UpdateClassifiedDTO
            {
                Title = ad.Title,
                AdId = ad.Id,
                CategoryId = ad.CategoryId,
                SubCategoryId = ad.SubCategoryId,
                OtherSubCategory = ad.OtherSubCategory,
                SubTypeId = ad.SubTypeId,
                OtherSubType = ad.OtherSubType,
                Description = ad.Description,
                Lat = ad.Lat,
                Lng = ad.Lng,
                Location = ad.En_Location + "-" + ad.Ar_Location,
                PhoneNumber = ad.PhoneNumber,
                Age = ad.En_Age + "^" + ad.Ar_Age,
                Brand = ad.En_Brand + "-" + ad.Ar_Brand,
                Condition = ad.En_Condition + "-" + ad.Ar_Condition,
                Price = ad.Price,
                Usage = ad.En_Usage + "-" + ad.Ar_Usage,
                Photos = ad.Pictures
            };

            return updateClassifiedDTO;
        }
    }
}

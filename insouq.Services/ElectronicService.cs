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
    public class ElectronicService : IElectronicService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ElectronicService(ApplicationDbContext db, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
        }

        // get just for update !!!
        public async Task<UpdateElectronicsDTO> GetElectronicAd(int adId)
        {
            var ad = await _db.ElectronicAds.Include(a => a.Ad).Include(a => a.Ad.Pictures)
                .Include(a => a.Ad.Category).Include(a => a.SubCategory).Include(a => a.SubType)
                .Where(a => a.Ad.Status == 1 || a.Ad.Status == 2)
                .Select(electronic => new GetElectronicAd
                {
                    TypeId = StaticData.Electronics_ID,
                    Id = electronic.Ad.Id,
                    PhoneNumber = electronic.Ad.PhoneNumber,
                    En_Age = electronic.En_Age,
                    Ar_Age = electronic.Ar_Age,
                    En_Color = electronic.En_Color,
                    Ar_Color = electronic.Ar_Color,
                    En_Usage = electronic.En_Usage,
                    Ar_Usage = electronic.Ar_Usage,
                    Price = electronic.Price,
                    Warranty = electronic.Warranty,
                    SubCategoryId = electronic.SubCategoryId,
                    SubCategoryAr_Name = electronic.SubCategory.Ar_Name,
                    SubCategoryEn_Name = electronic.SubCategory.En_Name,
                    OtherSubCategory = electronic.OtherSubCategory,
                    SubTypeId = electronic.SubTypeId,
                    SubTypeAr_Name = electronic.SubType.Ar_Name,
                    SubTypeEn_Name = electronic.SubType.En_Name,
                    OtherSubType = electronic.OtherSubType,
                    AgentId = electronic.Ad.AgentId,
                    CategoryId = electronic.Ad.CategoryId,
                    CategoryArName = electronic.Ad.Category.Ar_Name,
                    CategoryEnName = electronic.Ad.Category.En_Name,
                    Description = electronic.Ad.Description,
                    Lat = electronic.Ad.Lat,
                    Lng = electronic.Ad.Lng,
                    En_Location = electronic.Ad.En_Location,
                    Ar_Location = electronic.Ad.Ar_Location,
                    UserId = electronic.Ad.UserId,
                    Pictures = electronic.Ad.Pictures.Select(p => new AdPictureDTO
                    {
                        Id = p.Id,
                        ImageURL = p.ImageURL,
                        MainPicture = p.MainPicture

                    }).OrderByDescending(p => p.MainPicture).ToList(),
                    PostDate = electronic.Ad.PostDate,
                    Title = electronic.Ad.Title,
                    Status = electronic.Ad.Status
                }).AsNoTracking().FirstOrDefaultAsync(a => a.Id == adId);

            if (ad == null) return null;

            var updateElectronicsDTO = new UpdateElectronicsDTO
            {
                AdId = ad.Id,
                Age = ad.En_Age + "-" + ad.Ar_Age,
                CategoryId = ad.CategoryId,
                Color = ad.En_Color + "-" + ad.Ar_Color,
                Lat = ad.Lat,
                Lng = ad.Lng,
                Location = ad.En_Location + "-" + ad.Ar_Location,
                OtherSubCategory = ad.OtherSubCategory,
                OtherSubType = ad.OtherSubType,
                Description = ad.Description,
                PhoneNumber = ad.PhoneNumber,
                Photos = ad.Pictures,
                Price = ad.Price,
                SubCategoryId = ad.SubCategoryId,
                SubTypeId = ad.SubTypeId,
                Title = ad.Title,
                Usage = ad.En_Usage + "-" + ad.Ar_Usage,
                Warranty = ad.Warranty
            };

            return updateElectronicsDTO;
        }

        public async Task<BaseResponse> AddElectronicAd(int userId, ElectronicAdDTO model,string host)
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

                var en_color = "";

                var ar_color = "";

                if (model.Color != null)
                {
                    var colorArray = model.Color.Split('-');
                    en_color = colorArray[0].Trim();
                    ar_color = colorArray[1].Trim();
                }

                var en_age = "";

                var ar_age = "";

                if (model.Age != null)
                {
                    var ageArray = model.Age.Split('-');
                    en_age = ageArray[0].Trim();
                    ar_age = ageArray[1].Trim();
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
                    var webRootPath = _hostEnvironment.WebRootPath;

                    var folderPath = Path.Combine(webRootPath, "images");

                    foreach (var picture in model.Pictures)
                    {
                        var imageUrl = await HelperFunctions.UploadImage(folderPath, picture, "ads", webRootPath);

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
                    Status = 2,
                    CategoryId = model.CategoryId,
                    Pictures = pictures,
                    TypeId = StaticData.Electronics_ID,
                    PhoneNumber = model.PhoneNumber,
                };


                await _db.Ads.AddAsync(ad);

                category.NumberOfAds++;

                await _db.SaveChangesAsync();

                var electronicAd = new ElectronicAd()
                {
                    En_Age = en_age,
                    Ar_Age = ar_age,
                    En_Color = en_color,
                    Ar_Color = ar_color,
                    En_Usage = en_usage,
                    Ar_Usage = ar_usage,
                    Price = (double)model.Price,
                    Warranty = (bool)model.Warranty,
                    SubCategoryId = model.SubCategoryId == 0 ? null : model.SubCategoryId,
                    OtherSubCategory = model.OtherSubCategory,
                    SubTypeId = model.SubTypeId == 0 ? null : model.SubTypeId,
                    OtherSubType = model.OtherSubType,
                    AdId = ad.Id
                };

                await _db.ElectronicAds.AddAsync(electronicAd);

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

        public async Task<List<GetElectronicAd>> FilterElectronics(ElectronicFilters model)
        {
            var en_location = "";

            var en_age = "";

            if (!string.IsNullOrEmpty(model.Age))
            {
                en_age = model.Age.Split('^')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.Location))
            {
                en_location = model.Location.Split('-')[0].Trim();
            }

            var query = _db.ElectronicAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.User)
                .Where(a => a.Ad.CategoryId == model.CategoryId && a.Price >= model.FromPrice && a.Price <= model.ToPrice
                && a.Ad.Status == 1);

            if (model.SubCategoryId != 0)
            {
                query = query.Where(a => a.SubCategoryId == model.SubCategoryId);

                if (model.SubTypeId != 0)
                {
                    query = query.Where(a => a.SubTypeId == model.SubTypeId);
                }
            }


            //if (!string.IsNullOrEmpty(model.Keyword))
            //{
            //    query = query.Where(a => a.Ad.Title.Contains(model.Keyword));
            //}

            if (model.Warranty != null)
            {
                query = query.Where(a => a.Warranty == model.Warranty);
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

            if (en_age != "")
            {
                query = query.Where(a => a.En_Age == en_age);
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

            var ads = await query.Select(electronic => new GetElectronicAd
            {
                TypeId = electronic.Ad.TypeId,
                Id = electronic.Ad.Id,
                PhoneNumber = electronic.Ad.PhoneNumber,
                En_Age = electronic.En_Age,
                Ar_Age = electronic.Ar_Age,
                En_Color = electronic.En_Color,
                Ar_Color = electronic.Ar_Color,
                En_Usage = electronic.En_Usage,
                Ar_Usage = electronic.Ar_Usage,
                Warranty = electronic.Warranty,
                SubCategoryId = electronic.SubCategoryId,
                SubCategoryAr_Name = electronic.SubCategory.Ar_Name,
                SubCategoryEn_Name = electronic.SubCategory.En_Name,
                OtherSubCategory = electronic.OtherSubCategory,
                SubTypeId = electronic.SubTypeId,
                SubTypeAr_Name = electronic.SubType.Ar_Name,
                SubTypeEn_Name = electronic.SubType.En_Name,
                OtherSubType = electronic.OtherSubType,
                Price = electronic.Price,
                UserImage = electronic.Ad.User.ProfilePicture,
                AgentId = electronic.Ad.AgentId,
                CategoryId = electronic.Ad.CategoryId,
                CategoryEnName = electronic.Ad.Category.En_Name,
                CategoryArName = electronic.Ad.Category.Ar_Name,
                Description = electronic.Ad.Description,
                Lat = electronic.Ad.Lat,
                Lng = electronic.Ad.Lng,
                En_Location = electronic.Ad.En_Location,
                Ar_Location = electronic.Ad.Ar_Location,
                UserId = electronic.Ad.UserId,
                Pictures = electronic.Ad.Pictures.Select(p => new AdPictureDTO
                {
                    Id = p.Id,
                    ImageURL = p.ImageURL,
                    MainPicture = p.MainPicture

                }).OrderByDescending(p => p.MainPicture).ToList(),
                PostDate = electronic.Ad.PostDate,
                Title = electronic.Ad.Title,
                Status = electronic.Ad.Status
            }
            ).AsNoTracking().ToListAsync();

            return ads;
        }

        public async Task<BaseResponse> UpdateElectronicAd(int userId, UpdateElectronicsDTO model, string host)
        {
            var response = new BaseResponse();

            try
            {
                var ad = await _db.ElectronicAds.Include(a => a.Ad).Include(a => a.Ad.Pictures)
                    .FirstOrDefaultAsync(a => a.AdId == model.AdId && a.Ad.UserId == userId);

                if (ad == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not Found";
                    return response;
                }

                var en_color = "";

                var ar_color = "";

                if (model.Color != null)
                {
                    var colorArray = model.Color.Split('-');
                    en_color = colorArray[0].Trim();
                    ar_color = colorArray[1].Trim();
                }

                var en_age = "";

                var ar_age = "";

                if (model.Age != null)
                {
                    var ageArray = model.Age.Split('-');
                    en_age = ageArray[0].Trim();
                    ar_age = ageArray[1].Trim();
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
                            var imageUrl = await HelperFunctions.UploadImage(folderPath, picture, "ads", webRootPath);

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
                ad.Ad.LastUpdatedDate = DateTime.Now;
                ad.Ad.Lat = model.Lat;
                ad.Ad.Lng = model.Lng;
                ad.Ad.PhoneNumber = model.PhoneNumber;


                ad.En_Age = en_age;
                ad.Ar_Age = ar_age;
                ad.En_Color = en_color;
                ad.Ar_Color = ar_color;
                ad.En_Usage = en_usage;
                ad.Ar_Usage = ar_usage;
                ad.Price = (double)model.Price;
                ad.Warranty = (bool)model.Warranty;
                ad.SubCategoryId = model.SubCategoryId == 0 ? null : model.SubCategoryId;
                ad.OtherSubCategory = model.OtherSubCategory;
                ad.SubTypeId = model.SubTypeId == 0 ? null : model.SubTypeId;
                ad.OtherSubType = model.OtherSubType;

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

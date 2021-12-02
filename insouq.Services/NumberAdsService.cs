using insouq.EntityFramework;
using insouq.Models;
using insouq.Services.IServices;
using insouq.Shared.DTOS;
using insouq.Shared.DTOS.Filters;
using insouq.Shared.Responses;
using insouq.Shared.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services
{
    public class NumberAdsService : INumberAdsService
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;

        public NumberAdsService(ApplicationDbContext db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<NumberAdDTO> GetNumberAd(int adId)
        {
            var ad = await _db.NumberAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                .Where(a => a.Ad.Status == 1 || a.Ad.Status == 2)
                .Select(number => new GetNumberAdDTO
                {
                    TypeId = StaticData.Numbers_ID,
                    Id = number.Ad.Id,
                    Price = number.Price,
                    PhoneNumber = number.Ad.PhoneNumber,
                    En_Operator = number.En_Operator,
                    Ar_Operator = number.Ar_Operator,
                    Code = number.MobileCode,
                    Number = number.Number,
                    En_MobileNumberPlan = number.En_MobileNumberPlan,
                    Ar_MobileNumberPlan = number.Ar_MobileNumberPlan,
                    En_Emirate = number.En_Emirate,
                    Ar_Emirate = number.Ar_Emirate,
                    PlateCode = number.PlateCode,
                    En_PlateType = number.En_PlateType,
                    Ar_PlateType = number.Ar_PlateType,
                    Photo = number.Photo,
                    Photo2 = number.Photo2,
                    AgentId = number.Ad.AgentId,
                    CategoryId = number.Ad.CategoryId,
                    CategoryArName = number.Ad.Category.Ar_Name,
                    CategoryEnName = number.Ad.Category.En_Name,
                    Description = number.Ad.Description,
                    Lat = number.Ad.Lat,
                    Lng = number.Ad.Lng,
                    En_Location = number.Ad.En_Location,
                    Ar_Location = number.Ad.Ar_Location,
                    UserId = number.Ad.UserId,
                    PostDate = number.Ad.PostDate,
                    Title = number.Ad.Title,
                    Status = number.Ad.Status
                }).AsNoTracking().FirstOrDefaultAsync(a => a.Id == adId);

            if (ad == null) return null;

            var dto = new NumberAdDTO
            {
                AdId = ad.Id,
                Code = ad.Code,
                CategoryId = ad.CategoryId,
                Description = ad.Description,
                Emirate = ad.En_Emirate + "-" + ad.Ar_Emirate,
                Lat = ad.Lat,
                Lng = ad.Lng,
                Location = ad.En_Location + "-" + ad.Ar_Location,
                MobileNumberPlan = ad.En_MobileNumberPlan + "-" + ad.Ar_MobileNumberPlan,
                Number = ad.Number,
                Operator = ad.En_Operator + "-" + ad.Ar_Operator,
                PhoneNumber = ad.PhoneNumber,
                PlateCode = ad.PlateCode,
                PlateType = ad.En_PlateType + "-" + ad.Ar_PlateType,
                Price = ad.Price,
                Title = ad.Title,
            };

            return dto;
        }

        public async Task<BaseResponse> Add(int userId, NumberAdDTO model, string host)
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

                var en_operator = "";

                var ar_operator = "";

                if (model.Operator != null)
                {
                    var operatorArray = model.Operator.Split('-');
                    en_operator = operatorArray[0].Trim();
                    ar_operator = operatorArray[1].Trim();
                }


                var en_emirate = "";

                var ar_emirate = "";

                if (model.Emirate != null)
                {
                    var emirateArray = model.Emirate.Split('-');
                    en_emirate = emirateArray[0].Trim();
                    ar_emirate = emirateArray[1].Trim();
                }

                var en_plateType = "";

                var ar_plateType = "";

                if (model.PlateType != null)
                {
                    var plateTypeArray = model.PlateType.Split('-');
                    en_plateType = plateTypeArray[0].Trim();
                    ar_plateType = plateTypeArray[1].Trim();
                }

                var en_mobileNumberPlan = "";

                var ar_mobileNumberPlan = "";

                if (model.MobileNumberPlan != null)
                {
                    var MobileNumberPlanArray = model.MobileNumberPlan.Split('-');
                    en_mobileNumberPlan = MobileNumberPlanArray[0].Trim();
                    ar_mobileNumberPlan = MobileNumberPlanArray[1].Trim();
                }

                var photo = "";
                var photo2 = "";

                if (model.CategoryId == StaticData.PlateNumbers_ID)
                {
                    photo = @"\images\plates\" + en_emirate + "-" + en_plateType + ".png";

                    if (en_plateType.ToLower().Contains("private"))
                    {
                        photo2 = @"\images\plates\" + en_emirate + "-" + en_plateType + "2.png";
                    }
                }

                else if (model.CategoryId == StaticData.MobileNumbers_ID)
                {
                    photo = @"\images\" + en_operator.Trim().Substring(0, 1).ToUpper() + "Number.png";
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
                    TypeId = StaticData.Numbers_ID,
                    PhoneNumber = model.PhoneNumber,
                };


                await _db.Ads.AddAsync(ad);

                category.NumberOfAds++;

                await _db.SaveChangesAsync();

                var numberAd = new NumberAd()
                {
                    En_Operator = en_operator != "" ? en_operator : null,
                    Ar_Operator = ar_operator != "" ? ar_operator : null,
                    MobileCode = model.Code,
                    Number = (int)model.Number,
                    En_MobileNumberPlan = en_mobileNumberPlan != "" ? en_mobileNumberPlan : null,
                    Ar_MobileNumberPlan = ar_mobileNumberPlan != "" ? ar_mobileNumberPlan : null,
                    En_Emirate = en_emirate != "" ? en_emirate : null,
                    Ar_Emirate = ar_emirate != "" ? ar_emirate : null,
                    PlateCode = model.PlateCode,
                    En_PlateType = en_plateType != "" ? en_plateType : null,
                    Ar_PlateType = ar_plateType != "" ? ar_plateType : null,
                    Photo = photo,
                    Photo2 = photo2,
                    Price = (double)model.Price,
                    AdId = ad.Id
                };

                await _db.NumberAds.AddAsync(numberAd);

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

        public async Task<List<GetNumberAdDTO>> FilterNumbers(NumberFilters model)
        {
            var en_emirate = "";
            var en_operator = "";
            var en_numberPlan = "";
            var en_plateType = "";
            var en_location = "";


            if (!string.IsNullOrEmpty(model.Emirate))
            {
                en_emirate = model.Emirate.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.Operator))
            {
                en_operator = model.Operator.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.PlateType))
            {
                en_plateType = model.PlateType.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.NumberPlan))
            {
                en_numberPlan = model.NumberPlan.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.Location))
            {
                en_location = model.Location.Split('-')[0].Trim();
            }


            var query = _db.NumberAds.Include(a => a.Ad).Include(a => a.Ad.User)
                .Where(a => a.Ad.CategoryId == model.CategoryId && a.Price >= model.FromPrice && a.Price <= model.ToPrice
                && a.Ad.Status == 1);


            if (!string.IsNullOrEmpty(model.Keyword))
            {
                query = query.Where(a => a.Ad.Title.Contains(model.Keyword));
            }

            if (!string.IsNullOrEmpty(model.MobileCode))
            {
                query = query.Where(a => a.MobileCode == model.MobileCode);
            }

            if (!string.IsNullOrEmpty(model.PlateCode))
            {
                query = query.Where(a => a.PlateCode == model.PlateCode);
            }

            //if (model.CategoryId == StaticData.MobileNumbers_ID)
            //{
            //   query = query.Where(a => checkSimilarDigits(a.Number, model.MobileDigits7, model.MobileDigits6, model.MobileDigits5, model.MobileDigits4, model.MobileDigits3) == true);
            //}

            if (model.CategoryId == StaticData.PlateNumbers_ID)
            {
                if (model.PlateDigits5 != null || model.PlateDigits4 != null || model.PlateDigits3 != null || model.PlateDigits2 != null || model.PlateDigits1 != null)
                {
                    query = query.Where(a => a.Number.ToString().Length == model.PlateDigits1 ||
a.Number.ToString().Length == model.PlateDigits2 || a.Number.ToString().Length == model.PlateDigits3
|| a.Number.ToString().Length == model.PlateDigits4 || a.Number.ToString().Length == model.PlateDigits5);
                }

            }

            if (en_emirate != "")
            {
                query = query.Where(a => a.En_Emirate == en_emirate);
            }

            if (en_operator != "")
            {
                query = query.Where(a => a.En_Operator == en_operator);
            }

            if (en_plateType != "")
            {
                query = query.Where(a => a.En_PlateType == en_plateType);
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

            var list = await query.Select(number => new GetNumberAdDTO
            {
                TypeId = number.Ad.TypeId,
                Id = number.Ad.Id,
                Price = number.Price,
                PhoneNumber = number.Ad.PhoneNumber,
                En_Operator = number.En_Operator,
                Ar_Operator = number.Ar_Operator,
                Code = number.MobileCode,
                Number = number.Number,
                En_MobileNumberPlan = number.En_MobileNumberPlan,
                Ar_MobileNumberPlan = number.Ar_MobileNumberPlan,
                En_Emirate = number.En_Emirate,
                Ar_Emirate = number.Ar_Emirate,
                PlateCode = number.PlateCode,
                En_PlateType = number.En_PlateType,
                Ar_PlateType = number.Ar_PlateType,
                Photo = number.Photo,
                Photo2 = number.Photo2,
                UserImage = number.Ad.User.ProfilePicture,
                AgentId = number.Ad.AgentId,
                CategoryId = number.Ad.CategoryId,
                CategoryArName = number.Ad.Category.Ar_Name,
                CategoryEnName = number.Ad.Category.En_Name,
                Description = number.Ad.Description,
                Lat = number.Ad.Lat,
                Lng = number.Ad.Lng,
                En_Location = number.Ad.En_Location,
                Ar_Location = number.Ad.Ar_Location,
                UserId = number.Ad.UserId,
                PostDate = number.Ad.PostDate,
                Title = number.Ad.Title,
                Status = number.Ad.Status
            }).AsNoTracking().ToListAsync();

            if (model.CategoryId == StaticData.MobileNumbers_ID)
            {
                if (model.MobileDigits7 != null || model.MobileDigits6 != null || model.MobileDigits5 != null || model.MobileDigits4 != null || model.MobileDigits3 != null)
                {
                    list = list.Where(a => checkSimilarDigits(a.Number, model.MobileDigits7, model.MobileDigits6, model.MobileDigits5, model.MobileDigits4, model.MobileDigits3) == true).ToList();

                }
            }

            return list;
        }

        public async Task<BaseResponse> Update(int userId, NumberAdDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var ad = await _db.NumberAds.Include(a => a.Ad)
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

                var en_operator = "";

                var ar_operator = "";

                if (model.Operator != null)
                {
                    var operatorArray = model.Operator.Split('-');
                    en_operator = operatorArray[0].Trim();
                    ar_operator = operatorArray[1].Trim();
                }


                var en_emirate = "";

                var ar_emirate = "";

                if (model.Emirate != null)
                {
                    var emirateArray = model.Emirate.Split('-');
                    en_emirate = emirateArray[0].Trim();
                    ar_emirate = emirateArray[1].Trim();
                }

                var en_plateType = "";

                var ar_plateType = "";

                if (model.PlateType != null)
                {
                    var plateTypeArray = model.PlateType.Split('-');
                    en_plateType = plateTypeArray[0].Trim();
                    ar_plateType = plateTypeArray[1].Trim();
                }

                var en_mobileNumberPlan = "";

                var ar_mobileNumberPlan = "";

                if (model.MobileNumberPlan != null)
                {
                    var MobileNumberPlanArray = model.MobileNumberPlan.Split('-');
                    en_mobileNumberPlan = MobileNumberPlanArray[0].Trim();
                    ar_mobileNumberPlan = MobileNumberPlanArray[1].Trim();
                }

                var photo = "";
                var photo2 = "";

                if (model.CategoryId == StaticData.PlateNumbers_ID)
                {
                    photo = @"\images\plates\" + en_emirate + "-" + en_plateType + ".png";

                    if (en_plateType.ToLower().Contains("private"))
                    {
                        photo2 = @"\images\plates\" + en_emirate + "-" + en_plateType + "2.png";
                    }
                }

                else if (model.CategoryId == StaticData.MobileNumbers_ID)
                {
                    photo = @"\images\" + en_operator.Trim().Substring(0, 1).ToUpper() + "Number.png";
                }


                ad.Ad.Title = model.Title;
                ad.Ad.Description = model.Description;
                ad.Ad.En_Location = en_location;
                ad.Ad.Ar_Location = ar_location;
                ad.Ad.LastUpdatedDate = DateTime.Now;
                ad.Ad.Lat = model.Lat;
                ad.Ad.Lng = model.Lng;
                ad.Ad.UserId = userId;
                ad.Ad.PhoneNumber = model.PhoneNumber;


                ad.En_Operator = en_operator != "" ? en_operator : null;
                ad.Ar_Operator = ar_operator != "" ? ar_operator : null;
                ad.MobileCode = model.Code;
                ad.Number = (int)model.Number;
                ad.En_MobileNumberPlan = en_mobileNumberPlan != "" ? en_mobileNumberPlan : null;
                ad.Ar_MobileNumberPlan = ar_mobileNumberPlan != "" ? ar_mobileNumberPlan : null;
                ad.En_Emirate = en_emirate != "" ? en_emirate : null;
                ad.Ar_Emirate = ar_emirate != "" ? ar_emirate : null;
                ad.PlateCode = model.PlateCode;
                ad.En_PlateType = en_plateType != "" ? en_plateType : null;
                ad.Ar_PlateType = ar_plateType != "" ? ar_plateType : null;
                ad.Photo = photo;
                ad.Photo2 = photo2;
                ad.Price = (double)model.Price;


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


        public static bool checkSimilarDigits(int number, int? MobileDigits7, int? MobileDigits6, int? MobileDigits5, int? MobileDigits4, int? MobileDigits3)
        {
            int?[] array = new int?[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            while (number != 0)
            {
                var digit = number % 10;
                number = number / 10;
                array[digit]++;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == MobileDigits7 || array[i] == MobileDigits6 || array[i] == MobileDigits5 || array[i] == MobileDigits4 || array[i] == MobileDigits3)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

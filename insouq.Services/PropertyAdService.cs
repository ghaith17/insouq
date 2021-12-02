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
    public class PropertyAdService : IPropertyAdService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PropertyAdService(ApplicationDbContext db, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
        }

        //get just for update !!!
        public async Task<UpdatePropertyAdDTO> GetPropertyAd(int adId)
        {
            var ad = await _db.PropertyAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                .Include(a => a.SubCategory)
                .Where(a => a.Ad.Status == 1 || a.Ad.Status == 2)
                .Select(property => new GetPropertyAdDTO
                {
                    TypeId = StaticData.Properties_ID,
                    Id = property.Ad.Id,
                    AnnualCommunityFee = property.AnnualCommunityFee,
                    AvailableNetworked = property.AvailableNetworked,
                    ConferenceRoom = property.ConferenceRoom,
                    DiningInBuilding = property.DiningInBuilding,
                    Price = property.Price,
                    RetailInBuilding = property.RetailInBuilding,
                    TotalClosingFee = property.TotalClosingFee,
                    En_Furnishing = property.En_Furnishing,
                    Ar_Furnishing = property.Ar_Furnishing,
                    BedRooms = property.BedRooms,
                    BathRooms = property.BathRooms,
                    Size = property.Size,
                    Balcony = property.Balcony,
                    BuiltInKitchenAppliances = property.BuiltInKitchenAppliances,
                    BuildInWardrobes = property.BuildInWardrobes,
                    WalkInCloset = property.WalkInCloset,
                    CentralACAndHeating = property.CentralACAndHeating,
                    ConceirgeService = property.ConceirgeService,
                    CoveredParking = property.CoveredParking,
                    MaidService = property.MaidService,
                    MaidsRoom = property.MaidsRoom,
                    PetsAllowed = property.PetsAllowed,
                    PrivateGarden = property.PrivateGarden,
                    PrivateGym = property.PrivateGym,
                    PrivateJacuzzi = property.PrivateJacuzzi,
                    PrivatePool = property.PrivatePool,
                    Security = property.Security,
                    SharedGym = property.SharedGym,
                    SharedPool = property.SharedPool,
                    SharedSpa = property.SharedSpa,
                    StudyRoom = property.StudyRoom,
                    ViewOfLandmark = property.ViewOfLandmark,
                    ViewOfWater = property.ViewOfWater,
                    AnnualRent = property.AnnualRent,
                    En_RentPaidIn = property.En_RentPaidIn,
                    Ar_RentPaidIn = property.Ar_RentPaidIn,
                    Developer = property.Developer,
                    ReadyBy = property.ReadyBy,
                    PropertyReferenceID = property.PropertyReferenceID,
                    ListedBy = property.ListedBy,
                    RERALandlordName = property.RERALandlordName,
                    En_PropertyStatus = property.En_PropertyStatus,
                    Ar_PropertyStatus = property.Ar_PropertyStatus,
                    RERATitleDeedNumber = property.RERATitleDeedNumber,
                    RERAPreRegistrationNumber = property.RERAPreRegistrationNumber,
                    RERABrokerIDNumber = property.RERABrokerIDNumber,
                    RERAListerCompanyName = property.RERAListerCompanyName,
                    RERAPermitNumber = property.RERAPermitNumber,
                    RERAAgentName = property.RERAAgentName,
                    Building = property.Building,
                    Neighborhood = property.Neighborhood,
                    SubCategoryId = property.SubCategoryId,
                    SubCategoryAr_Name = property.SubCategory.Ar_Name,
                    SubCategoryEn_Name = property.SubCategory.En_Name,
                    AgentId = property.Ad.AgentId,
                    CategoryId = property.Ad.CategoryId,
                    CategoryArName = property.Ad.Category.Ar_Name,
                    CategoryEnName = property.Ad.Category.En_Name,
                    Description = property.Ad.Description,
                    Lat = property.Ad.Lat,
                    Lng = property.Ad.Lng,
                    En_Location = property.Ad.En_Location,
                    Ar_Location = property.Ad.Ar_Location,
                    UserId = property.Ad.UserId,
                    Pictures = property.Ad.Pictures.Select(p => new AdPictureDTO
                    {
                        Id = p.Id,
                        ImageURL = p.ImageURL,
                        MainPicture = p.MainPicture

                    }).OrderByDescending(p => p.MainPicture).ToList(),
                    PostDate = property.Ad.PostDate,
                    Title = property.Ad.Title,
                    Status = property.Ad.Status
                }).AsNoTracking().FirstOrDefaultAsync(a => a.Id == adId);

            if (ad == null) return null;

            var dto = new UpdatePropertyAdDTO
            {
                AdId = ad.Id,
                AnnualCommunityFee = ad.AnnualCommunityFee,
                Id = ad.Id,
                AnnualRent = ad.AnnualRent,
                AvailableNetworked = ad.AvailableNetworked,
                Balcony = ad.Balcony,
                BathRooms = ad.BathRooms,
                BedRooms = ad.BedRooms,
                Building = ad.Building,
                BuildInWardrobes = ad.BuildInWardrobes,
                BuiltInKitchenAppliances = ad.BuiltInKitchenAppliances,
                CategoryId = ad.CategoryId,
                CentralACAndHeating = ad.CentralACAndHeating,
                ConceirgeService = ad.ConceirgeService,
                ConferenceRoom = ad.ConferenceRoom,
                CoveredParking = ad.CoveredParking,
                PetsAllowed = ad.PetsAllowed,
                Description = ad.Description,
                Developer = ad.Developer,
                DiningInBuilding = ad.DiningInBuilding,
                Furnishing = ad.En_Furnishing + "-" + ad.Ar_Furnishing,
                Lat = ad.Lat,
                ListedBy = ad.ListedBy,
                Lng = ad.Lng,
                Location = ad.En_Location + "-" + ad.Ar_Location,
                MaidService = ad.MaidService,
                MaidsRoom = ad.MaidsRoom,
                Neighborhood = ad.Neighborhood,
                Photos = ad.Pictures,
                Price = ad.Price,
                PrivateGarden = ad.PrivateGarden,
                PrivateGym = ad.PrivateGym,
                PrivateJacuzzi = ad.PrivateJacuzzi,
                PrivatePool = ad.PrivatePool,
                PropertyReferenceID = ad.PropertyReferenceID,
                PropertyStatus = ad.En_PropertyStatus + "-" + ad.Ar_PropertyStatus,
                ReadyBy = ad.ReadyBy,
                RentPaidIn = ad.En_RentPaidIn + "-" + ad.Ar_RentPaidIn,
                RERAAgentName = ad.RERAAgentName,
                RERABrokerIDNumber = ad.RERABrokerIDNumber,
                RERALandlordName = ad.RERALandlordName,
                RERAListerCompanyName = ad.RERAListerCompanyName,
                RERAPermitNumber = ad.RERAPermitNumber,
                RERAPreRegistrationNumber = ad.RERAPreRegistrationNumber,
                RERATitleDeedNumber = ad.RERATitleDeedNumber,
                RetailInBuilding = ad.RetailInBuilding,
                Security = ad.Security,
                SharedGym = ad.SharedGym,
                SharedPool = ad.SharedPool,
                SharedSpa = ad.SharedSpa,
                Size = ad.Size,
                StudyRoom = ad.StudyRoom,
                SubCategoryId = ad.SubCategoryId,
                Title = ad.Title,
                TotalClosingFee = ad.TotalClosingFee,
                ViewOfLandmark = ad.ViewOfLandmark,
                ViewOfWater = ad.ViewOfWater,
                WalkInCloset = ad.WalkInCloset,
            };

            return dto;
        }

        public async Task<BaseResponse> Add(int userId, PropertyAdDTO model , string host)
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


                var furnishingArray = model.Furnishing.Split('-');

                var en_furnishing = furnishingArray[0].Trim();

                var ar_furnishing = furnishingArray[1].Trim();



                var en_propertyStatus = "";
                var ar_propertyStatus = "";

                if (model.PropertyStatus != null)
                {
                    var propertyStatusArray = model.PropertyStatus.Split('-');

                    en_propertyStatus = propertyStatusArray[0].Trim();

                    ar_propertyStatus = propertyStatusArray[1].Trim();
                }

                var en_rentPaidIn = "";
                var ar_rentPaidIn = "";

                if (model.RentPaidIn != null)
                {
                    var rentPaidInArray = model.RentPaidIn.Split('-');

                    en_rentPaidIn = rentPaidInArray[0].Trim();

                    ar_rentPaidIn = rentPaidInArray[1].Trim();
                }


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
                    TypeId = StaticData.Properties_ID
                };


                await _db.Ads.AddAsync(ad);

                category.NumberOfAds++;

                await _db.SaveChangesAsync();

                var propertyAd = new PropertyAd()
                {
                    AnnualCommunityFee = model.AnnualCommunityFee,
                    AvailableNetworked = model.AvailableNetworked,
                    ConferenceRoom = model.ConferenceRoom,
                    DiningInBuilding = model.DiningInBuilding,
                    Price = model.Price,
                    RetailInBuilding = model.RetailInBuilding,
                    TotalClosingFee = model.TotalClosingFee,
                    En_Furnishing = en_furnishing,
                    Ar_Furnishing = ar_furnishing,
                    BedRooms = model.BedRooms,
                    BathRooms = model.BathRooms,
                    Size = model.Size,
                    Balcony = model.Balcony,
                    BuiltInKitchenAppliances = model.BuiltInKitchenAppliances,
                    BuildInWardrobes = model.BuildInWardrobes,
                    WalkInCloset = model.WalkInCloset,
                    CentralACAndHeating = model.CentralACAndHeating,
                    ConceirgeService = model.ConceirgeService,
                    CoveredParking = model.CoveredParking,
                    MaidService = model.MaidService,
                    MaidsRoom = model.MaidsRoom,
                    PetsAllowed = model.PetsAllowed,
                    PrivateGarden = model.PrivateGarden,
                    PrivateGym = model.PrivateGym,
                    PrivateJacuzzi = model.PrivateJacuzzi,
                    PrivatePool = model.PrivatePool,
                    Security = model.Security,
                    SharedGym = model.SharedGym,
                    SharedPool = model.SharedPool,
                    SharedSpa = model.SharedSpa,
                    StudyRoom = model.StudyRoom,
                    ViewOfLandmark = model.ViewOfLandmark,
                    ViewOfWater = model.ViewOfWater,
                    AnnualRent = model.AnnualRent,
                    En_RentPaidIn = en_rentPaidIn != "" ? en_rentPaidIn : null,
                    Ar_RentPaidIn = ar_rentPaidIn != "" ? ar_rentPaidIn : null,
                    Developer = model.Developer,
                    ReadyBy = model.ReadyBy,
                    PropertyReferenceID = model.PropertyReferenceID,
                    ListedBy = model.ListedBy,
                    RERALandlordName = model.RERALandlordName,
                    En_PropertyStatus = en_propertyStatus != "" ? en_propertyStatus : null,
                    Ar_PropertyStatus = ar_propertyStatus != "" ? ar_propertyStatus : null,
                    RERATitleDeedNumber = model.RERATitleDeedNumber,
                    RERAPreRegistrationNumber = model.RERAPreRegistrationNumber,
                    RERABrokerIDNumber = model.RERABrokerIDNumber,
                    RERAListerCompanyName = model.RERAListerCompanyName,
                    RERAPermitNumber = model.RERAPermitNumber,
                    RERAAgentName = model.RERAAgentName,
                    Building = model.Building,
                    Neighborhood = model.Neighborhood,
                    SubCategoryId = model.SubCategoryId,
                    AdId = ad.Id
                };

                await _db.PropertyAds.AddAsync(propertyAd);

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

        public async Task<List<GetPropertyAdDTO>> FilterProperities(PropertyFilters model)
        {
            var en_furnishing = "";
            var en_location = "";

            if (!string.IsNullOrEmpty(model.Furnishing))
            {
                en_furnishing = model.Furnishing.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.Location))
            {
                en_location = model.Location.Split('-')[0].Trim();
            }

            var query = _db.PropertyAds.Include(a => a.Ad).Include(a => a.Ad.User).Where(a => a.Ad.CategoryId == model.CategoryId
            && a.Ad.Status == 1);

            if(model.CategoryId == StaticData.CommercialForRent_ID || model.CategoryId == StaticData.CommercialForSale_ID)
            {
                query = query.Where(a => a.Price >= model.FromPrice && a.Price <= model.ToPrice);

                if (model.SortBy == StaticData.Price_Heighest_To_Lowest)
                {
                    query = query.OrderByDescending(m => m.Price);
                }
                else if (model.SortBy == StaticData.Price_Lowest_To_Heighest)
                {
                    query = query.OrderBy(m => m.Price);
                }
            }

            else if(model.CategoryId == StaticData.ResidentialForRent_ID || model.CategoryId == StaticData.ResidentialForSale_ID)
            {
                query = query.Where(a => a.AnnualRent >= model.FromAnnualRent && a.AnnualRent <= model.ToAnnualRent);

                if (model.SortBy == StaticData.Price_Heighest_To_Lowest)
                {
                    query = query.OrderByDescending(m => m.AnnualRent);
                }
                else if (model.SortBy == StaticData.Price_Lowest_To_Heighest)
                {
                    query = query.OrderBy(m => m.AnnualRent);
                }
            }

            if (model.SortBy == StaticData.Newest_To_Oldest)
            {
                query = query.OrderByDescending(m => m.Ad.PostDate);
            }
            else if (model.SortBy == StaticData.Oldest_To_Newest)
            {
                query = query.OrderBy(m => m.Ad.PostDate);
            }

            if (model.ListedBy != "")
            {
                query = query.Where(a => a.ListedBy == model.ListedBy);
            }

            #region SERVICES_FILTERS

            if (model.Balcony)
            {
                query = query.Where(a => a.Balcony == model.Balcony);
            }

            if (model.BuiltInKitchenAppliances)
            {
                query = query.Where(a => a.BuiltInKitchenAppliances == model.BuiltInKitchenAppliances);
            }

            if (model.BuildInWardrobes)
            {
                query = query.Where(a => a.BuildInWardrobes == model.BuildInWardrobes);
            }

            if (model.WalkInCloset)
            {
                query = query.Where(a => a.WalkInCloset == model.WalkInCloset);
            }

            if (model.CentralACAndHeating)
            {
                query = query.Where(a => a.CentralACAndHeating == model.CentralACAndHeating);
            }

            if (model.ConceirgeService)
            {
                query = query.Where(a => a.ConceirgeService == model.ConceirgeService);
            }

            if (model.CoveredParking)
            {
                query = query.Where(a => a.CoveredParking == model.CoveredParking);
            }

            if (model.MaidService)
            {
                query = query.Where(a => a.MaidService == model.MaidService);
            }

            if (model.MaidsRoom)
            {
                query = query.Where(a => a.MaidsRoom == model.MaidsRoom);
            }

            if (model.PetsAllowed)
            {
                query = query.Where(a => a.PetsAllowed == model.PetsAllowed);
            }

            if (model.PrivateGarden)
            {
                query = query.Where(a => a.PrivateGarden == model.PrivateGarden);
            }

            if (model.PrivateGym)
            {
                query = query.Where(a => a.PrivateGym == model.PrivateGym);
            }

            if (model.PrivateJacuzzi)
            {
                query = query.Where(a => a.PrivateJacuzzi == model.PrivateJacuzzi);
            }

            if (model.PrivatePool)
            {
                query = query.Where(a => a.PrivatePool == model.PrivatePool);
            }

            if (model.Security)
            {
                query = query.Where(a => a.Security == model.Security);
            }

            if (model.SharedGym)
            {
                query = query.Where(a => a.SharedGym == model.SharedGym);
            }

            if (model.SharedPool)
            {
                query = query.Where(a => a.SharedPool == model.SharedPool);
            }

            if (model.SharedSpa)
            {
                query = query.Where(a => a.SharedSpa == model.SharedSpa);
            }

            if (model.StudyRoom)
            {
                query = query.Where(a => a.StudyRoom == model.StudyRoom);
            }

            if (model.ViewOfLandmark)
            {
                query = query.Where(a => a.ViewOfLandmark == model.ViewOfLandmark);
            }

            if (model.ViewOfWater)
            {
                query = query.Where(a => a.ViewOfWater == model.ViewOfWater);
            }

            if (model.AvailableNetworked)
            {
                query = query.Where(a => a.AvailableNetworked == model.AvailableNetworked);
            }

            if (model.ConferenceRoom)
            {
                query = query.Where(a => a.ConferenceRoom == model.ConferenceRoom);
            }

            if (model.DiningInBuilding)
            {
                query = query.Where(a => a.DiningInBuilding == model.DiningInBuilding);
            }

            if (model.RetailInBuilding)
            {
                query = query.Where(a => a.RetailInBuilding == model.RetailInBuilding);
            }

            #endregion

            if (!string.IsNullOrEmpty(model.Keyword))
            {
                query = query.Where(a => a.Ad.Title.Contains(model.Keyword));
            }

            if (en_furnishing != "")
            {
                query = query.Where(a => a.En_Furnishing == en_furnishing);
            }

            if (en_location != "")
            {
                query = query.Where(a => a.Ad.En_Location == en_location);
            }

            var list = await query.Select(property => new GetPropertyAdDTO
            {
                TypeId = property.Ad.TypeId,
                Id = property.Ad.Id,
                AnnualCommunityFee = property.AnnualCommunityFee,
                AvailableNetworked = property.AvailableNetworked,
                ConferenceRoom = property.ConferenceRoom,
                DiningInBuilding = property.DiningInBuilding,
                Price = property.Price,
                RetailInBuilding = property.RetailInBuilding,
                TotalClosingFee = property.TotalClosingFee,
                En_Furnishing = property.En_Furnishing,
                Ar_Furnishing = property.Ar_Furnishing,
                BedRooms = property.BedRooms,
                BathRooms = property.BathRooms,
                Size = property.Size,
                Balcony = property.Balcony,
                BuiltInKitchenAppliances = property.BuiltInKitchenAppliances,
                BuildInWardrobes = property.BuildInWardrobes,
                WalkInCloset = property.WalkInCloset,
                CentralACAndHeating = property.CentralACAndHeating,
                ConceirgeService = property.ConceirgeService,
                CoveredParking = property.CoveredParking,
                MaidService = property.MaidService,
                MaidsRoom = property.MaidsRoom,
                PetsAllowed = property.PetsAllowed,
                PrivateGarden = property.PrivateGarden,
                PrivateGym = property.PrivateGym,
                PrivateJacuzzi = property.PrivateJacuzzi,
                PrivatePool = property.PrivatePool,
                Security = property.Security,
                SharedGym = property.SharedGym,
                SharedPool = property.SharedPool,
                SharedSpa = property.SharedSpa,
                StudyRoom = property.StudyRoom,
                ViewOfLandmark = property.ViewOfLandmark,
                ViewOfWater = property.ViewOfWater,
                AnnualRent = property.AnnualRent,
                En_RentPaidIn = property.En_RentPaidIn,
                Ar_RentPaidIn = property.Ar_RentPaidIn,
                Developer = property.Developer,
                ReadyBy = property.ReadyBy,
                PropertyReferenceID = property.PropertyReferenceID,
                ListedBy = property.ListedBy,
                RERALandlordName = property.RERALandlordName,
                En_PropertyStatus = property.En_PropertyStatus,
                Ar_PropertyStatus = property.Ar_PropertyStatus,
                RERATitleDeedNumber = property.RERATitleDeedNumber,
                RERAPreRegistrationNumber = property.RERAPreRegistrationNumber,
                RERABrokerIDNumber = property.RERABrokerIDNumber,
                RERAListerCompanyName = property.RERAListerCompanyName,
                RERAPermitNumber = property.RERAPermitNumber,
                RERAAgentName = property.RERAAgentName,
                Building = property.Building,
                Neighborhood = property.Neighborhood,
                SubCategoryId = property.SubCategoryId,
                SubCategoryAr_Name = property.SubCategory.Ar_Name,
                SubCategoryEn_Name = property.SubCategory.En_Name,
                UserImage = property.Ad.User.ProfilePicture,
                AgentId = property.Ad.AgentId,
                CategoryId = property.Ad.CategoryId,
                CategoryArName = property.Ad.Category.Ar_Name,
                CategoryEnName = property.Ad.Category.En_Name,
                Description = property.Ad.Description,
                Lat = property.Ad.Lat,
                Lng = property.Ad.Lng,
                En_Location = property.Ad.En_Location,
                Ar_Location = property.Ad.Ar_Location,
                UserId = property.Ad.UserId,
                Pictures = property.Ad.Pictures.Select(p => new AdPictureDTO
                {
                    Id = p.Id,
                    ImageURL = p.ImageURL,
                    MainPicture = p.MainPicture

                }).OrderByDescending(p => p.MainPicture).ToList(),
                PostDate = property.Ad.PostDate,
                Title = property.Ad.Title,
                Status = property.Ad.Status
            }).AsNoTracking().ToListAsync();

            return list;

        }

        public async Task<BaseResponse> Update(int userId, UpdatePropertyAdDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var ad = await _db.PropertyAds.Include(a => a.Ad).Include(a => a.Ad.Pictures)
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


                var furnishingArray = model.Furnishing.Split('-');

                var en_furnishing = furnishingArray[0].Trim();

                var ar_furnishing = furnishingArray[1].Trim();



                var en_propertyStatus = "";
                var ar_propertyStatus = "";

                if (model.PropertyStatus != null)
                {
                    var propertyStatusArray = model.PropertyStatus.Split('-');

                    en_propertyStatus = propertyStatusArray[0].Trim();

                    ar_propertyStatus = propertyStatusArray[1].Trim();
                }

                var en_rentPaidIn = "";
                var ar_rentPaidIn = "";

                if (model.RentPaidIn != null)
                {
                    var rentPaidInArray = model.RentPaidIn.Split('-');

                    en_rentPaidIn = rentPaidInArray[0].Trim();

                    ar_rentPaidIn = rentPaidInArray[1].Trim();
                }



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
                //ad.Ad.PhoneNumber = model.PhoneNumber;

                ad.AnnualCommunityFee = model.AnnualCommunityFee;
                ad.AvailableNetworked = model.AvailableNetworked;
                ad.ConferenceRoom = model.ConferenceRoom;
                ad.DiningInBuilding = model.DiningInBuilding;
                ad.Price = model.Price;
                ad.RetailInBuilding = model.RetailInBuilding;
                ad.TotalClosingFee = model.TotalClosingFee;
                ad.En_Furnishing = en_furnishing;
                ad.Ar_Furnishing = ar_furnishing;
                ad.BedRooms = model.BedRooms;
                ad.BathRooms = model.BathRooms;
                ad.Size = model.Size;
                ad.Balcony = model.Balcony;
                ad.BuiltInKitchenAppliances = model.BuiltInKitchenAppliances;
                ad.BuildInWardrobes = model.BuildInWardrobes;
                ad.WalkInCloset = model.WalkInCloset;
                ad.CentralACAndHeating = model.CentralACAndHeating;
                ad.ConceirgeService = model.ConceirgeService;
                ad.CoveredParking = model.CoveredParking;
                ad.MaidService = model.MaidService;
                ad.MaidsRoom = model.MaidsRoom;
                ad.PetsAllowed = model.PetsAllowed;
                ad.PrivateGarden = model.PrivateGarden;
                ad.PrivateGym = model.PrivateGym;
                ad.PrivateJacuzzi = model.PrivateJacuzzi;
                ad.PrivatePool = model.PrivatePool;
                ad.Security = model.Security;
                ad.SharedGym = model.SharedGym;
                ad.SharedPool = model.SharedPool;
                ad.SharedSpa = model.SharedSpa;
                ad.StudyRoom = model.StudyRoom;
                ad.ViewOfLandmark = model.ViewOfLandmark;
                ad.ViewOfWater = model.ViewOfWater;
                ad.AnnualRent = model.AnnualRent;
                ad.En_RentPaidIn = en_rentPaidIn != "" ? en_rentPaidIn : null;
                ad.Ar_RentPaidIn = ar_rentPaidIn != "" ? ar_rentPaidIn : null;
                ad.Developer = model.Developer;
                ad.ReadyBy = model.ReadyBy;
                ad.PropertyReferenceID = model.PropertyReferenceID;
                ad.ListedBy = model.ListedBy;
                ad.RERALandlordName = model.RERALandlordName;
                ad.En_PropertyStatus = en_propertyStatus != "" ? en_propertyStatus : null;
                ad.Ar_PropertyStatus = ar_propertyStatus != "" ? ar_propertyStatus : null;
                ad.RERATitleDeedNumber = model.RERATitleDeedNumber;
                ad.RERAPreRegistrationNumber = model.RERAPreRegistrationNumber;
                ad.RERABrokerIDNumber = model.RERABrokerIDNumber;
                ad.RERAListerCompanyName = model.RERAListerCompanyName;
                ad.RERAPermitNumber = model.RERAPermitNumber;
                ad.RERAAgentName = model.RERAAgentName;
                ad.Building = model.Building;
                ad.Neighborhood = model.Neighborhood;
                ad.SubCategoryId = model.SubCategoryId;

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

    }
}

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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace insouq.Services
{
    public class AdsService : IAdsService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ITypeService _typeService;
        private readonly IWebHostEnvironment _hostEnvironment;


        public AdsService(
            ApplicationDbContext db,
            IMapper mapper,
            ITypeService typeService,
            IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _mapper = mapper;
            _typeService = typeService;
            _hostEnvironment = hostEnvironment;
        }

        //public async Task<dynamic> GetMyAds(int userId)
        //{
        //    //var ads = await _db.Ads.Where(a => a.UserId == userId)
        //    //    .Select(a => new { typeId = a.TypeId, Id = a.Id  }).ToListAsync();

        //    //foreach (var item in ads)
        //    //{
        //    //    if(item.typeId == )
        //    //}

        //    return "";
        //}

        private void AddSearchStatistic(int adId, int UserId)
        {
            try
            {
                AdStatistic s = new AdStatistic
                {
                    AdId = adId,
                    Date = DateTime.Now,
                    Type = (int)StatisticTypes.Search,
                    UserId = UserId

                };
                _db.AdStatistics.Add(s);
                _db.SaveChanges();
            }
            catch (Exception e)
            {

            }
        }

        public async Task<dynamic> GetUserAds(int userId, int typeId, bool isOwner)
        {
            if (typeId == StaticData.Motors_ID)
            {
                var ads = await _db.MotorAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.Ad.User)
                    .Include(a => a.SubCategory).Include(a => a.SubType)
                    .Where(a => a.Ad.UserId == userId)
                    .Select(motor => new GetMotorAdDTO
                    {
                        Views = _db.AdStatistics.Where(s => s.UserId == userId && s.Type == (int)StatisticTypes.Views).ToList().Count,
                        Chates = _db.AdStatistics.Where(s => s.UserId == userId && s.Type == (int)StatisticTypes.Chat).ToList().Count,
                        Id = motor.Ad.Id,
                        TypeId = typeId,
                        PhoneNumber = motor.Ad.PhoneNumber,
                        NameOfPart = motor.NameOfPart,
                        En_PartName = motor.Ar_PartName,
                        Ar_PartName = motor.Ar_PartName,
                        En_Maker = motor.En_Maker,
                        Ar_Maker = motor.Ar_Maker,
                        En_Model = motor.En_Model,
                        Ar_Model = motor.Ar_Model,
                        En_Trim = motor.En_Trim,
                        Ar_Trim = motor.Ar_Trim,
                        En_Color = motor.En_Color,
                        Ar_Color = motor.Ar_Color,
                        Kilometers = motor.Kilometers,
                        Year = motor.Year,
                        En_Doors = motor.En_Doors,
                        Ar_Doors = motor.Ar_Doors,
                        Warranty = motor.Warranty,
                        En_Transmission = motor.En_Transmission,
                        Ar_Transmission = motor.Ar_Transmission,
                        En_RegionalSpecs = motor.En_RegionalSpecs,
                        Ar_RegionalSpecs = motor.Ar_RegionalSpecs,
                        En_BodyType = motor.En_BodyType,
                        Ar_BodyType = motor.Ar_BodyType,
                        En_FuelType = motor.En_FuelType,
                        Ar_FuelType = motor.Ar_FuelType,
                        En_NoOfCylinders = motor.En_NoOfCylinders,
                        Ar_NoOfCylinders = motor.Ar_NoOfCylinders,
                        En_Horsepower = motor.En_Horsepower,
                        Ar_Horsepower = motor.Ar_Horsepower,
                        En_Condition = motor.En_Condition,
                        Ar_Condition = motor.Ar_Condition,
                        En_MechanicalCondition = motor.En_MechanicalCondition,
                        Ar_MechanicalCondition = motor.Ar_MechanicalCondition,
                        Price = motor.Price,
                        En_Age = motor.En_Age,
                        Ar_Age = motor.Ar_Age,
                        En_Capacity = motor.En_Capacity,
                        Ar_Capacity = motor.Ar_Capacity,
                        En_EngineSize = motor.En_EngineSize,
                        Ar_EngineSize = motor.Ar_EngineSize,
                        En_Length = motor.En_Length,
                        En_Usage = motor.En_Usage,
                        Ar_Usage = motor.Ar_Usage,
                        En_Wheels = motor.En_Wheels,
                        Ar_Wheels = motor.Ar_Wheels,
                        En_SellerType = motor.En_SellerType,
                        Ar_SellerType = motor.Ar_SellerType,
                        En_FinalDriveSystem = motor.En_FinalDriveSystem,
                        Ar_FinalDriveSystem = motor.Ar_FinalDriveSystem,
                        Ar_SteeringSide = motor.Ar_SteeringSide,
                        En_SteeringSide = motor.En_SteeringSide,
                        SubCategoryId = motor.SubCategoryId,
                        SubCategoryEn_Name = motor.SubCategory.En_Name,
                        SubCategoryAr_Name = motor.SubCategory.Ar_Name,
                        OtherSubCategory = motor.OtherSubCategory,
                        UserImage = motor.Ad.User.ProfilePicture,
                        SubTypeId = motor.SubTypeId,
                        SubTypeEn_Name = motor.SubType.En_Name,
                        SubTypeAr_Name = motor.SubType.Ar_Name,
                        OtherSubType = motor.OtherSubType,
                        AgentId = motor.Ad.AgentId,
                        CategoryId = motor.Ad.CategoryId,
                        CategoryArName = motor.Ad.Category.Ar_Name,
                        CategoryEnName = motor.Ad.Category.En_Name,
                        Description = motor.Ad.Description,
                        Lat = motor.Ad.Lat,
                        Lng = motor.Ad.Lng,
                        En_Location = motor.Ad.En_Location,
                        Ar_Location = motor.Ad.Ar_Location,
                        UserId = motor.Ad.UserId,
                        Pictures = motor.Ad.Pictures.Select(p => new AdPictureDTO
                        {
                            Id = p.Id,
                            ImageURL = p.ImageURL,
                            MainPicture = p.MainPicture

                        }).OrderByDescending(p => p.MainPicture).ToList(),
                        PostDate = motor.Ad.PostDate,
                        Title = motor.Ad.Title,
                        Status = motor.Ad.Status
                    }).AsNoTracking().ToListAsync();

                if (isOwner)
                {
                    ads = ads.Where(a => a.Status == 1 || a.Status == 2).ToList();
                }
                else
                {
                    ads = ads.Where(a => a.Status == 1).ToList();
                }

                return ads;

            }

            else if (typeId == StaticData.Electronics_ID)
            {

                var ads = await _db.ElectronicAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.SubCategory).Include(a => a.SubType)
                    .Include(a => a.Ad.User)
                    .Where(a => a.Ad.UserId == userId)
                    .Select(electronic => new GetElectronicAd
                    {
                        Views = _db.AdStatistics.Where(s => s.UserId == userId && s.Type == (int)StatisticTypes.Views).ToList().Count,
                        Chates = _db.AdStatistics.Where(s => s.UserId == userId && s.Type == (int)StatisticTypes.Chat).ToList().Count,
                        TypeId = typeId,
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
                        UserImage = electronic.Ad.User.ProfilePicture,
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
                    }).AsNoTracking().ToListAsync();

                if (isOwner)
                {
                    ads = ads.Where(a => a.Status == 1 || a.Status == 2).ToList();
                }
                else
                {
                    ads = ads.Where(a => a.Status == 1).ToList();
                }

                return ads;

            }

            else if (typeId == StaticData.Jobs_ID)
            {
                var ads = await _db.JobAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category).Include(a => a.Ad.User)
                    .Where(a => a.Ad.UserId == userId && a.Ad.Status == 1)
                    .Select(job => new GetJobAdDTO
                    {
                        Views = _db.AdStatistics.Where(s => s.UserId == userId && s.Type == (int)StatisticTypes.Views).ToList().Count,
                        Chates = _db.AdStatistics.Where(s => s.UserId == userId && s.Type == (int)StatisticTypes.Chat).ToList().Count,
                        TypeId = typeId,
                        Id = job.Ad.Id,
                        En_JobType = job.En_JobType,
                        Ar_JobType = job.Ar_JobType,
                        PhoneNumber = job.Ad.PhoneNumber,
                        CV = job.CV,
                        En_Gender = job.En_Gender,
                        Ar_Gender = job.Ar_Gender,
                        En_Nationality = job.En_Nationality,
                        Ar_Nationality = job.Ar_Nationality,
                        En_CurrentLocation = job.En_CurrentLocation,
                        Ar_CurrentLocation = job.Ar_CurrentLocation,
                        En_EducationLevel = job.En_EducationLevel,
                        Ar_EducationLevel = job.Ar_EducationLevel,
                        CurrentPosition = job.CurrentPosition,
                        En_WorkExperience = job.En_WorkExperience,
                        Ar_WorkExperience = job.Ar_WorkExperience,
                        En_Commitment = job.En_Commitment,
                        Ar_Commitment = job.Ar_Commitment,
                        En_NoticePeriod = job.En_NoticePeriod,
                        Ar_NoticePeriod = job.Ar_NoticePeriod,
                        En_VisaStatus = job.En_VisaStatus,
                        Ar_VisaStatus = job.Ar_VisaStatus,
                        En_CareerLevel = job.En_CareerLevel,
                        Ar_CareerLevel = job.Ar_CareerLevel,
                        ExpectedMonthlySalary = job.ExpectedMonthlySalary,
                        CompanyName = job.CompanyName,
                        En_EmploymentType = job.En_EmploymentType,
                        Ar_EmploymentType = job.Ar_EmploymentType,
                        En_MinEducationLevel = job.En_MinEducationLevel,
                        Ar_MinEducationLevel = job.Ar_MinEducationLevel,
                        En_MinWorkExperience = job.En_MinWorkExperience,
                        Ar_MinWorkExperience = job.Ar_MinWorkExperience,
                        UserImage = job.Ad.User.ProfilePicture,
                        AgentId = job.Ad.AgentId,
                        CategoryId = job.Ad.CategoryId,
                        CategoryArName = job.Ad.Category.Ar_Name,
                        CategoryEnName = job.Ad.Category.En_Name,
                        Description = job.Ad.Description,
                        Lat = job.Ad.Lat,
                        Lng = job.Ad.Lng,
                        En_Location = job.Ad.En_Location,
                        Ar_Location = job.Ad.Ar_Location,
                        UserId = job.Ad.UserId,
                        PostDate = job.Ad.PostDate,
                        Title = job.Ad.Title,
                        Status = job.Ad.Status,
                        Pictures = job.Ad.Pictures.Select(p => new AdPictureDTO
                        {
                            Id = p.Id,
                            ImageURL = p.ImageURL,
                            MainPicture = p.MainPicture
                        }).ToList()
                    }).AsNoTracking().ToListAsync();

                if (isOwner)
                {
                    ads = ads.Where(a => a.Status == 1 || a.Status == 2).ToList();
                }
                else
                {
                    ads = ads.Where(a => a.Status == 1).ToList();
                }

                return ads;

            }

            else if (typeId == StaticData.Properties_ID)
            {
                var ads = await _db.PropertyAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.SubCategory)
                    .Include(a => a.Ad.User)
                    .Where(a => a.Ad.UserId == userId)
                    .Select(property => new GetPropertyAdDTO
                    {
                        Views = _db.AdStatistics.Where(s => s.UserId == userId && s.Type == (int)StatisticTypes.Views).ToList().Count,
                        Chates = _db.AdStatistics.Where(s => s.UserId == userId && s.Type == (int)StatisticTypes.Chat).ToList().Count,
                        TypeId = typeId,
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

                if (isOwner)
                {
                    ads = ads.Where(a => a.Status == 1 || a.Status == 2).ToList();
                }
                else
                {
                    ads = ads.Where(a => a.Status == 1).ToList();
                }

                return ads;
            }

            else if (typeId == StaticData.Business_ID)
            {
                var ads = await _db.BussinesAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.Ad.User)
                    .Where(a => a.Ad.UserId == userId)
                    .Select(business => new GetBussinesAdDTO
                    {
                        Views = _db.AdStatistics.Where(s => s.UserId == userId && s.Type == (int)StatisticTypes.Views).ToList().Count,
                        Chates = _db.AdStatistics.Where(s => s.UserId == userId && s.Type == (int)StatisticTypes.Chat).ToList().Count,
                        TypeId = typeId,
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
                    }).AsNoTracking().ToListAsync();

                if (isOwner)
                {
                    ads = ads.Where(a => a.Status == 1 || a.Status == 2).ToList();
                }
                else
                {
                    ads = ads.Where(a => a.Status == 1).ToList();
                }

                return ads;

            }

            else if (typeId == StaticData.Services_ID)
            {

                var ads = await _db.ServiceAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.SubCategory)
                    .Include(a => a.Ad.User)
                    .Where(a => a.Ad.UserId == userId)
                    .Select(service => new GetServiceAdDTO
                    {
                        Views = _db.AdStatistics.Where(s => s.UserId == userId && s.Type == (int)StatisticTypes.Views).ToList().Count,
                        Chates = _db.AdStatistics.Where(s => s.UserId == userId && s.Type == (int)StatisticTypes.Chat).ToList().Count,
                        TypeId = typeId,
                        Id = service.Ad.Id,
                        PhoneNumber = service.Ad.PhoneNumber,
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
                    }).AsNoTracking().ToListAsync();

                if (isOwner)
                {
                    ads = ads.Where(a => a.Status == 1 || a.Status == 2).ToList();
                }
                else
                {
                    ads = ads.Where(a => a.Status == 1).ToList();
                }

                return ads;

            }

            else if (typeId == StaticData.Numbers_ID)
            {
                var ads = await _db.NumberAds.Include(a => a.Ad).Include(a => a.Ad.Category).Include(a => a.Ad.User)
                    .Where(a => a.Ad.UserId == userId)
                    .Select(number => new GetNumberAdDTO
                    {
                        Views = _db.AdStatistics.Where(s => s.UserId == userId && s.Type == (int)StatisticTypes.Views).ToList().Count,
                        Chates = _db.AdStatistics.Where(s => s.UserId == userId && s.Type == (int)StatisticTypes.Chat).ToList().Count,
                        TypeId = typeId,
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

                if (isOwner)
                {
                    ads = ads.Where(a => a.Status == 1 || a.Status == 2).ToList();
                }
                else
                {
                    ads = ads.Where(a => a.Status == 1).ToList();
                }

                return ads;


            }

            else if (typeId == StaticData.Classifieds_ID)
            {
                var ads = await _db.ClassifiedAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.SubCategory).Include(a => a.SubType)
                    .Include(a => a.Ad.User)
                    .Where(a => a.Ad.UserId == userId)
                    .Select(classified => new GetClassifiedAdDTO
                    {
                        Views = _db.AdStatistics.Where(s => s.UserId == userId && s.Type == (int)StatisticTypes.Views).ToList().Count,
                        Chates = _db.AdStatistics.Where(s => s.UserId == userId && s.Type == (int)StatisticTypes.Chat).ToList().Count,
                        TypeId = typeId,
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
                    }).AsNoTracking().ToListAsync();

                if (isOwner)
                {
                    ads = ads.Where(a => a.Status == 1 || a.Status == 2).ToList();
                }
                else
                {
                    ads = ads.Where(a => a.Status == 1).ToList();
                }

                return ads;
            }

            return "";
        }

        public async Task<dynamic> GetMyFavoriteAds(int userId, int typeId)
        {
            if (typeId == StaticData.Motors_ID)
            {

                var motorAds = await (from ad in _db.Ads.Include(a => a.Pictures).Include(a => a.Category).Include(a => a.User)
                                      join favorite in _db.Favorites on ad.Id equals favorite.AdId
                                      join motor in _db.MotorAds.Include(a => a.SubCategory).Include(a => a.SubType)
                                      on ad.Id equals motor.AdId
                                      where favorite.UserId == userId && ad.Status == 1
                                      select new GetMotorAdDTO
                                      {
                                          UserImage = ad.User.ProfilePicture,
                                          Id = ad.Id,
                                          TypeId = typeId,
                                          PhoneNumber = ad.PhoneNumber,
                                          NameOfPart = motor.NameOfPart,
                                          En_PartName = motor.Ar_PartName,
                                          Ar_PartName = motor.Ar_PartName,
                                          En_Maker = motor.En_Maker,
                                          Ar_Maker = motor.Ar_Maker,
                                          En_Model = motor.En_Model,
                                          Ar_Model = motor.Ar_Model,
                                          En_Trim = motor.En_Trim,
                                          Ar_Trim = motor.Ar_Trim,
                                          En_Color = motor.En_Color,
                                          Ar_Color = motor.Ar_Color,
                                          Kilometers = motor.Kilometers,
                                          Year = motor.Year,
                                          En_Doors = motor.En_Doors,
                                          Ar_Doors = motor.Ar_Doors,
                                          Warranty = motor.Warranty,
                                          En_Transmission = motor.En_Transmission,
                                          Ar_Transmission = motor.Ar_Transmission,
                                          En_RegionalSpecs = motor.En_RegionalSpecs,
                                          Ar_RegionalSpecs = motor.Ar_RegionalSpecs,
                                          En_BodyType = motor.En_BodyType,
                                          Ar_BodyType = motor.Ar_BodyType,
                                          En_FuelType = motor.En_FuelType,
                                          Ar_FuelType = motor.Ar_FuelType,
                                          En_NoOfCylinders = motor.En_NoOfCylinders,
                                          Ar_NoOfCylinders = motor.Ar_NoOfCylinders,
                                          En_Horsepower = motor.En_Horsepower,
                                          Ar_Horsepower = motor.En_Horsepower,
                                          En_Condition = motor.En_Condition,
                                          Ar_Condition = motor.Ar_Condition,
                                          En_MechanicalCondition = motor.En_MechanicalCondition,
                                          Ar_MechanicalCondition = motor.Ar_MechanicalCondition,
                                          Price = motor.Price,
                                          En_Age = motor.En_Age,
                                          Ar_Age = motor.Ar_Age,
                                          En_Capacity = motor.En_Capacity,
                                          Ar_Capacity = motor.Ar_Capacity,
                                          En_EngineSize = motor.En_EngineSize,
                                          Ar_EngineSize = motor.Ar_EngineSize,
                                          En_Length = motor.En_Length,
                                          Ar_Length = motor.Ar_Length,
                                          En_Usage = motor.En_Usage,
                                          Ar_Usage = motor.Ar_Usage,
                                          En_Wheels = motor.En_Wheels,
                                          Ar_Wheels = motor.Ar_Wheels,
                                          En_SellerType = motor.En_SellerType,
                                          Ar_SellerType = motor.Ar_SellerType,
                                          En_FinalDriveSystem = motor.En_FinalDriveSystem,
                                          Ar_FinalDriveSystem = motor.Ar_FinalDriveSystem,
                                          Ar_SteeringSide = motor.Ar_SteeringSide,
                                          En_SteeringSide = motor.En_SteeringSide,
                                          SubCategoryId = motor.SubCategoryId,
                                          SubCategoryEn_Name = motor.SubCategory.En_Name,
                                          SubCategoryAr_Name = motor.SubCategory.Ar_Name,
                                          OtherSubCategory = motor.OtherSubCategory,
                                          SubTypeId = motor.SubTypeId,
                                          SubTypeEn_Name = motor.SubType.En_Name,
                                          SubTypeAr_Name = motor.SubType.Ar_Name,
                                          OtherSubType = motor.OtherSubType,
                                          AgentId = ad.AgentId,
                                          CategoryId = ad.CategoryId,
                                          CategoryArName = ad.Category.Ar_Name,
                                          CategoryEnName = ad.Category.En_Name,
                                          Description = ad.Description,
                                          Lat = ad.Lat,
                                          Lng = ad.Lng,
                                          En_Location = ad.En_Location,
                                          Ar_Location = ad.Ar_Location,
                                          UserId = ad.UserId,
                                          Pictures = ad.Pictures.Select(p => new AdPictureDTO
                                          {
                                              Id = p.Id,
                                              ImageURL = p.ImageURL,
                                              MainPicture = p.MainPicture

                                          }).OrderByDescending(p => p.MainPicture).ToList(),
                                          PostDate = ad.PostDate,
                                          Title = ad.Title,
                                          Status = ad.Status
                                      }).AsNoTracking().ToListAsync();

                return motorAds;

            }

            else if (typeId == StaticData.Electronics_ID)
            {
                var ads = await (from ad in _db.Ads.Include(a => a.Pictures).Include(a => a.Category).Include(a => a.User)
                                 join favorite in _db.Favorites on ad.Id equals favorite.AdId
                                 join electronic in _db.ElectronicAds.Include(m => m.SubCategory).Include(m => m.SubType)
                                 on ad.Id equals electronic.AdId
                                 where favorite.UserId == userId && ad.Status == 1
                                 select new GetElectronicAd
                                 {
                                     UserImage = ad.User.ProfilePicture,
                                     TypeId = typeId,
                                     PhoneNumber = ad.PhoneNumber,
                                     Id = ad.Id,
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
                                     AgentId = ad.AgentId,
                                     CategoryId = ad.CategoryId,
                                     CategoryArName = ad.Category.Ar_Name,
                                     CategoryEnName = ad.Category.En_Name,
                                     Description = ad.Description,
                                     Lat = ad.Lat,
                                     Lng = ad.Lng,
                                     En_Location = ad.En_Location,
                                     Ar_Location = ad.Ar_Location,
                                     UserId = ad.UserId,
                                     Pictures = ad.Pictures.Select(p => new AdPictureDTO
                                     {
                                         Id = p.Id,
                                         ImageURL = p.ImageURL,
                                         MainPicture = p.MainPicture

                                     }).OrderByDescending(p => p.MainPicture).ToList(),
                                     PostDate = ad.PostDate,
                                     Title = ad.Title,
                                     Status = ad.Status

                                 }).AsNoTracking().ToListAsync();
                return ads;

            }

            else if (typeId == StaticData.Jobs_ID)
            {
                var ads = await (from ad in _db.Ads.Include(a => a.Category).Include(a => a.Pictures).Include(a => a.User)
                                 join favorite in _db.Favorites on ad.Id equals favorite.AdId
                                 join job in _db.JobAds
                                 on ad.Id equals job.AdId
                                 where favorite.UserId == userId && ad.Status == 1
                                 select new GetJobAdDTO
                                 {
                                     UserImage = ad.User.ProfilePicture,
                                     TypeId = typeId,
                                     Id = ad.Id,
                                     En_JobType = job.En_JobType,
                                     Ar_JobType = job.Ar_JobType,
                                     PhoneNumber = ad.PhoneNumber,
                                     CV = job.CV,
                                     En_Gender = job.En_Gender,
                                     Ar_Gender = job.Ar_Gender,
                                     En_Nationality = job.En_Nationality,
                                     Ar_Nationality = job.Ar_Nationality,
                                     En_CurrentLocation = job.En_CurrentLocation,
                                     Ar_CurrentLocation = job.Ar_CurrentLocation,
                                     En_EducationLevel = job.En_EducationLevel,
                                     Ar_EducationLevel = job.Ar_EducationLevel,
                                     CurrentPosition = job.CurrentPosition,
                                     En_WorkExperience = job.En_WorkExperience,
                                     Ar_WorkExperience = job.Ar_WorkExperience,
                                     En_Commitment = job.En_Commitment,
                                     Ar_Commitment = job.Ar_Commitment,
                                     En_NoticePeriod = job.En_NoticePeriod,
                                     Ar_NoticePeriod = job.Ar_NoticePeriod,
                                     En_VisaStatus = job.En_VisaStatus,
                                     Ar_VisaStatus = job.Ar_VisaStatus,
                                     En_CareerLevel = job.En_CareerLevel,
                                     Ar_CareerLevel = job.Ar_CareerLevel,
                                     ExpectedMonthlySalary = job.ExpectedMonthlySalary,
                                     CompanyName = job.CompanyName,
                                     En_EmploymentType = job.En_EmploymentType,
                                     Ar_EmploymentType = job.Ar_EmploymentType,
                                     En_MinEducationLevel = job.En_MinEducationLevel,
                                     Ar_MinEducationLevel = job.Ar_MinEducationLevel,
                                     En_MinWorkExperience = job.En_MinWorkExperience,
                                     Ar_MinWorkExperience = job.Ar_MinWorkExperience,
                                     AgentId = ad.AgentId,
                                     CategoryId = ad.CategoryId,
                                     CategoryArName = ad.Category.Ar_Name,
                                     CategoryEnName = ad.Category.En_Name,
                                     Description = ad.Description,
                                     Lat = ad.Lat,
                                     Lng = ad.Lng,
                                     En_Location = ad.En_Location,
                                     Ar_Location = ad.Ar_Location,
                                     UserId = ad.UserId,
                                     PostDate = ad.PostDate,
                                     Title = ad.Title,
                                     Status = ad.Status,
                                     Pictures = ad.Pictures.Select(p => new AdPictureDTO
                                     {
                                         Id = p.Id,
                                         ImageURL = p.ImageURL,
                                         MainPicture = p.MainPicture
                                     }).ToList()
                                 }).AsNoTracking().ToListAsync();

                return ads;
            }

            else if (typeId == StaticData.Properties_ID)
            {

                var ads = await (from ad in _db.Ads.Include(a => a.Pictures).Include(a => a.Category).Include(a => a.User)
                                 join favorite in _db.Favorites on ad.Id equals favorite.AdId
                                 join property in _db.PropertyAds.Include(a => a.SubCategory)
                                 on ad.Id equals property.AdId
                                 where favorite.UserId == userId && ad.Status == 1
                                 select new GetPropertyAdDTO
                                 {
                                     UserImage = ad.User.ProfilePicture,
                                     TypeId = typeId,
                                     Id = ad.Id,
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
                                     AgentId = ad.AgentId,
                                     CategoryId = ad.CategoryId,
                                     CategoryArName = ad.Category.Ar_Name,
                                     CategoryEnName = ad.Category.En_Name,
                                     Description = ad.Description,
                                     Lat = ad.Lat,
                                     Lng = ad.Lng,
                                     En_Location = ad.En_Location,
                                     Ar_Location = ad.Ar_Location,
                                     UserId = ad.UserId,
                                     Pictures = ad.Pictures.Select(p => new AdPictureDTO
                                     {
                                         Id = p.Id,
                                         ImageURL = p.ImageURL,
                                         MainPicture = p.MainPicture

                                     }).OrderByDescending(p => p.MainPicture).ToList(),
                                     PostDate = ad.PostDate,
                                     Title = ad.Title,
                                     Status = ad.Status
                                 }).AsNoTracking().ToListAsync();

                return ads;
            }

            else if (typeId == StaticData.Business_ID)
            {

                var ads = await (from ad in _db.Ads.Include(a => a.Pictures).Include(a => a.Category).Include(a => a.User)
                                 join favorite in _db.Favorites on ad.Id equals favorite.AdId
                                 join business in _db.BussinesAds
                                 on ad.Id equals business.AdId
                                 where favorite.UserId == userId && ad.Status == 1
                                 select new GetBussinesAdDTO
                                 {
                                     UserImage = ad.User.ProfilePicture,
                                     TypeId = typeId,
                                     Id = ad.Id,
                                     Price = business.Price,
                                     PhoneNumber = ad.PhoneNumber,
                                     OtherCategoryName = business.OtherCategoryName,
                                     SubCategoryId = business.SubCategoryId,
                                     SubCategoryArName = business.SubCategory.Ar_Name,
                                     SubCategoryEnName = business.SubCategory.En_Name,
                                     OtherSubCategoryName = business.OtherSubCategoryName,
                                     AgentId = ad.AgentId,
                                     CategoryId = ad.CategoryId,
                                     CategoryArName = ad.Category.Ar_Name,
                                     CategoryEnName = ad.Category.En_Name,
                                     Description = ad.Description,
                                     Lat = ad.Lat,
                                     Lng = ad.Lng,
                                     En_Location = ad.En_Location,
                                     Ar_Location = ad.Ar_Location,
                                     UserId = ad.UserId,
                                     Pictures = ad.Pictures.Select(p => new AdPictureDTO
                                     {
                                         Id = p.Id,
                                         ImageURL = p.ImageURL,
                                         MainPicture = p.MainPicture

                                     }).OrderByDescending(p => p.MainPicture).ToList(),
                                     PostDate = ad.PostDate,
                                     Title = ad.Title,
                                     Status = ad.Status
                                 }).AsNoTracking().ToListAsync();

                return ads;

            }

            else if (typeId == StaticData.Services_ID)
            {

                var ads = await (from ad in _db.Ads.Include(a => a.Category).Include(a => a.Pictures).Include(a => a.User)
                                 join favorite in _db.Favorites on ad.Id equals favorite.AdId
                                 join service in _db.ServiceAds.Include(a => a.SubCategory)
                                 on ad.Id equals service.AdId
                                 where favorite.UserId == userId && ad.Status == 1
                                 select new GetServiceAdDTO
                                 {
                                     UserImage = ad.User.ProfilePicture,
                                     TypeId = typeId,
                                     Id = ad.Id,
                                     PhoneNumber = ad.PhoneNumber,
                                     ServiceTypeId = service.SubCategoryId,
                                     ServiceTypeEn_Name = service.SubCategory.En_Name,
                                     ServiceTypeAr_Name = service.SubCategory.Ar_Name,
                                     OtherServiceType = service.OtherSubCategory,
                                     AgentId = ad.AgentId,
                                     CategoryId = ad.CategoryId,
                                     CategoryArName = ad.Category.Ar_Name,
                                     CategoryEnName = ad.Category.En_Name,
                                     Description = ad.Description,
                                     Lat = ad.Lat,
                                     Lng = ad.Lng,
                                     En_Location = ad.En_Location,
                                     Ar_Location = ad.Ar_Location,
                                     UserId = ad.UserId,
                                     PostDate = ad.PostDate,
                                     Title = ad.Title,
                                     Status = ad.Status,
                                     Pictures = ad.Pictures.Select(p => new AdPictureDTO
                                     {
                                         Id = p.Id,
                                         ImageURL = p.ImageURL,
                                         MainPicture = p.MainPicture
                                     }).ToList()
                                 }).AsNoTracking().ToListAsync();

                return ads;

            }

            else if (typeId == StaticData.Numbers_ID)
            {
                var ads = await (from ad in _db.Ads.Include(a => a.Category).Include(a => a.User)
                                 join favorite in _db.Favorites on ad.Id equals favorite.AdId
                                 join number in _db.NumberAds
                                 on ad.Id equals number.AdId
                                 where favorite.UserId == userId && ad.Status == 1
                                 select new GetNumberAdDTO
                                 {
                                     UserImage = ad.User.ProfilePicture,
                                     TypeId = typeId,
                                     Id = ad.Id,
                                     Price = number.Price,
                                     PhoneNumber = ad.PhoneNumber,
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
                                     AgentId = ad.AgentId,
                                     CategoryId = ad.CategoryId,
                                     CategoryArName = ad.Category.Ar_Name,
                                     CategoryEnName = ad.Category.En_Name,
                                     Description = ad.Description,
                                     Lat = ad.Lat,
                                     Lng = ad.Lng,
                                     En_Location = ad.En_Location,
                                     Ar_Location = ad.Ar_Location,
                                     UserId = ad.UserId,
                                     PostDate = ad.PostDate,
                                     Title = ad.Title,
                                     Status = ad.Status
                                 }).AsNoTracking().ToListAsync();

                return ads;

            }

            else if (typeId == StaticData.Classifieds_ID)
            {
                var ads = await (from ad in _db.Ads.Include(a => a.Pictures).Include(a => a.Category).Include(a => a.User)
                                 join favorite in _db.Favorites on ad.Id equals favorite.AdId
                                 join classified in _db.ClassifiedAds.Include(a => a.SubCategory)
                                 .Include(a => a.SubType)
                                 on ad.Id equals classified.AdId
                                 where favorite.UserId == userId && ad.Status == 1
                                 select new GetClassifiedAdDTO
                                 {
                                     UserImage = ad.User.ProfilePicture,
                                     TypeId = typeId,
                                     Id = ad.Id,
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
                                     AgentId = ad.AgentId,
                                     CategoryId = ad.CategoryId,
                                     CategoryArName = ad.Category.Ar_Name,
                                     CategoryEnName = ad.Category.En_Name,
                                     Description = ad.Description,
                                     Lat = ad.Lat,
                                     Lng = ad.Lng,
                                     En_Location = ad.En_Location,
                                     Ar_Location = ad.Ar_Location,
                                     UserId = ad.UserId,
                                     PostDate = ad.PostDate,
                                     Title = ad.Title,
                                     Status = ad.Status,
                                     Pictures = ad.Pictures.Select(p => new AdPictureDTO
                                     {
                                         Id = p.Id,
                                         ImageURL = p.ImageURL,
                                         MainPicture = p.MainPicture

                                     }).OrderByDescending(p => p.MainPicture).ToList(),
                                 }).AsNoTracking().ToListAsync();

                return ads;
            }

            return null;
        }


        public async Task<dynamic> GetAds(int typeId, string searchText = "", string location = "",
            int maxKm = int.MaxValue, int minKm = 0, int maxYear = 5000,
            int minYear = 1900, double maxPrice = double.MaxValue, double minPrice = 0,
            string maker = "", string model = "", string trim = ""
            )

        {
            if (typeId == StaticData.Motors_ID)
            {
                var ads = await _db.MotorAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.SubCategory).Include(a => a.SubType)
                    .Where(a => a.Ad.Status == 1
                    && (string.IsNullOrEmpty(searchText)
                        || a.Ad.Title.ToLower().Contains(searchText.ToLower())
                        || a.Ad.Description.ToLower().Contains(searchText.ToLower()))
                    && (string.IsNullOrEmpty(location)
                        || a.Ad.Ar_Location.ToLower().Contains(location.ToLower())
                        || a.Ad.En_Location.ToLower().Contains(location.ToLower())
                        )
                    && ((a.Kilometers > minKm && a.Kilometers <= maxKm) || maxKm <= 0)
                    && ((a.Price >= minPrice && a.Price <= maxPrice) || maxPrice <= 0)
                    && (maker.Contains(a.En_Maker) || string.IsNullOrEmpty(maker))
                    && (model.Contains(a.En_Model) || string.IsNullOrEmpty(model))
                    && (trim.Contains(a.En_Trim) || string.IsNullOrEmpty(trim))
                    )
                    .Select(motor => new GetMotorAdDTO
                    {
                        Id = motor.Ad.Id,
                        TypeId = typeId,
                        PhoneNumber = motor.Ad.PhoneNumber,
                        NameOfPart = motor.NameOfPart,
                        En_PartName = motor.Ar_PartName,
                        Ar_PartName = motor.Ar_PartName,
                        En_Maker = motor.En_Maker,
                        Ar_Maker = motor.Ar_Maker,
                        En_Model = motor.En_Model,
                        Ar_Model = motor.Ar_Model,
                        En_Trim = motor.En_Trim,
                        Ar_Trim = motor.Ar_Trim,
                        En_Color = motor.En_Color,
                        Ar_Color = motor.Ar_Color,
                        Kilometers = motor.Kilometers,
                        Year = motor.Year,
                        En_Doors = motor.En_Doors,
                        Ar_Doors = motor.Ar_Doors,
                        Warranty = motor.Warranty,
                        En_Transmission = motor.En_Transmission,
                        Ar_Transmission = motor.Ar_Transmission,
                        En_RegionalSpecs = motor.En_RegionalSpecs,
                        Ar_RegionalSpecs = motor.Ar_RegionalSpecs,
                        En_BodyType = motor.En_BodyType,
                        Ar_BodyType = motor.Ar_BodyType,
                        En_FuelType = motor.En_FuelType,
                        Ar_FuelType = motor.Ar_FuelType,
                        En_NoOfCylinders = motor.En_NoOfCylinders,
                        Ar_NoOfCylinders = motor.Ar_NoOfCylinders,
                        En_Horsepower = motor.En_Horsepower,
                        Ar_Horsepower = motor.Ar_Horsepower,
                        En_Condition = motor.En_Condition,
                        Ar_Condition = motor.Ar_Condition,
                        En_MechanicalCondition = motor.En_MechanicalCondition,
                        Ar_MechanicalCondition = motor.Ar_MechanicalCondition,
                        Price = motor.Price,
                        En_Age = motor.En_Age,
                        Ar_Age = motor.Ar_Age,
                        En_Capacity = motor.En_Capacity,
                        Ar_Capacity = motor.Ar_Capacity,
                        En_EngineSize = motor.En_EngineSize,
                        Ar_EngineSize = motor.Ar_EngineSize,
                        En_Length = motor.En_Length,
                        Ar_Length = motor.Ar_Length,
                        En_Usage = motor.En_Usage,
                        Ar_Usage = motor.Ar_Usage,
                        En_Wheels = motor.En_Wheels,
                        Ar_Wheels = motor.Ar_Wheels,
                        En_SellerType = motor.En_SellerType,
                        Ar_SellerType = motor.Ar_SellerType,
                        En_FinalDriveSystem = motor.En_FinalDriveSystem,
                        Ar_FinalDriveSystem = motor.Ar_FinalDriveSystem,
                        Ar_SteeringSide = motor.Ar_SteeringSide,
                        En_SteeringSide = motor.En_SteeringSide,
                        SubCategoryId = motor.SubCategoryId,
                        SubCategoryEn_Name = motor.SubCategory.En_Name,
                        SubCategoryAr_Name = motor.SubCategory.Ar_Name,
                        OtherSubCategory = motor.OtherSubCategory,
                        SubTypeId = motor.SubTypeId,
                        SubTypeEn_Name = motor.SubType.En_Name,
                        SubTypeAr_Name = motor.SubType.Ar_Name,
                        OtherSubType = motor.OtherSubType,
                        AgentId = motor.Ad.AgentId,
                        CategoryId = motor.Ad.CategoryId,
                        CategoryArName = motor.Ad.Category.Ar_Name,
                        CategoryEnName = motor.Ad.Category.En_Name,
                        Description = motor.Ad.Description,
                        Lat = motor.Ad.Lat,
                        Lng = motor.Ad.Lng,
                        En_Location = motor.Ad.En_Location,
                        Ar_Location = motor.Ad.Ar_Location,
                        UserId = motor.Ad.UserId,
                        UserImage = motor.Ad.User.ProfilePicture,
                        Pictures = motor.Ad.Pictures.Select(p => new AdPictureDTO
                        {
                            Id = p.Id,
                            ImageURL = p.ImageURL,
                            MainPicture = p.MainPicture

                        }).OrderByDescending(p => p.MainPicture).ToList(),
                        PostDate = motor.Ad.PostDate,
                        Title = motor.Ad.Title,
                        Status = motor.Ad.Status
                    }).AsNoTracking().ToListAsync();

                if (!string.IsNullOrEmpty(searchText))
                {
                    foreach (var Item in ads)
                    {
                        AddSearchStatistic(Item.Id, (int)Item.UserId);

                    }
                }

                return ads;

            }

            else if (typeId == StaticData.Electronics_ID)
            {
                var ads = await _db.ElectronicAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.SubCategory).Include(a => a.SubType)
                    .Where(a => a.Ad.Status == 1 &&(string.IsNullOrEmpty(searchText)
                        || a.Ad.Title.ToLower().Contains(searchText.ToLower())
                        || a.Ad.Description.ToLower().Contains(searchText.ToLower()))
                    && (string.IsNullOrEmpty(location)
                    || a.Ad.Ar_Location.ToLower().Contains(location.ToLower())
                    || a.Ad.En_Location.ToLower().Contains(location.ToLower()))
                    )
                    .Select(electronic => new GetElectronicAd
                    {
                        TypeId = typeId,
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
                    }).AsNoTracking().ToListAsync();

                if (!string.IsNullOrEmpty(searchText))
                {
                    foreach (var Item in ads)
                    {
                        AddSearchStatistic(Item.Id, (int)Item.UserId);

                    }
                }
                return ads;
            }

            else if (typeId == StaticData.Jobs_ID)
            {
                var ads = await _db.JobAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Where(a => a.Ad.Status == 1 && (string.IsNullOrEmpty(searchText)
                        || a.Ad.Title.ToLower().Contains(searchText.ToLower())
                        || a.Ad.Description.ToLower().Contains(searchText.ToLower()))
                    && (string.IsNullOrEmpty(location)
                    || a.Ad.Ar_Location.ToLower().Contains(location.ToLower())
                    || a.Ad.En_Location.ToLower().Contains(location.ToLower())
                    && a.Ad.Status == 1)
                    )
                    .Select(job => new GetJobAdDTO
                    {
                        TypeId = typeId,
                        Id = job.Ad.Id,
                        En_JobType = job.En_JobType,
                        Ar_JobType = job.Ar_JobType,
                        PhoneNumber = job.Ad.PhoneNumber,
                        CV = job.CV,
                        En_Gender = job.En_Gender,
                        Ar_Gender = job.Ar_Gender,
                        En_Nationality = job.En_Nationality,
                        Ar_Nationality = job.Ar_Nationality,
                        En_CurrentLocation = job.En_CurrentLocation,
                        Ar_CurrentLocation = job.Ar_CurrentLocation,
                        En_EducationLevel = job.En_EducationLevel,
                        Ar_EducationLevel = job.Ar_EducationLevel,
                        CurrentPosition = job.CurrentPosition,
                        En_WorkExperience = job.En_WorkExperience,
                        Ar_WorkExperience = job.Ar_WorkExperience,
                        En_Commitment = job.En_Commitment,
                        Ar_Commitment = job.Ar_Commitment,
                        En_NoticePeriod = job.En_NoticePeriod,
                        Ar_NoticePeriod = job.Ar_NoticePeriod,
                        En_VisaStatus = job.En_VisaStatus,
                        Ar_VisaStatus = job.Ar_VisaStatus,
                        En_CareerLevel = job.En_CareerLevel,
                        Ar_CareerLevel = job.Ar_CareerLevel,
                        ExpectedMonthlySalary = job.ExpectedMonthlySalary,
                        CompanyName = job.CompanyName,
                        En_EmploymentType = job.En_EmploymentType,
                        Ar_EmploymentType = job.Ar_EmploymentType,
                        En_MinEducationLevel = job.En_MinEducationLevel,
                        Ar_MinEducationLevel = job.Ar_MinEducationLevel,
                        En_MinWorkExperience = job.En_MinWorkExperience,
                        Ar_MinWorkExperience = job.Ar_MinWorkExperience,
                        AgentId = job.Ad.AgentId,
                        CategoryId = job.Ad.CategoryId,
                        CategoryArName = job.Ad.Category.Ar_Name,
                        CategoryEnName = job.Ad.Category.En_Name,
                        Description = job.Ad.Description,
                        Lat = job.Ad.Lat,
                        Lng = job.Ad.Lng,
                        En_Location = job.Ad.En_Location,
                        Ar_Location = job.Ad.Ar_Location,
                        UserId = job.Ad.UserId,
                        PostDate = job.Ad.PostDate,
                        Title = job.Ad.Title,
                        Status = job.Ad.Status,
                        Pictures = job.Ad.Pictures.Select(p => new AdPictureDTO
                        {
                            Id = p.Id,
                            ImageURL = p.ImageURL,
                            MainPicture = p.MainPicture
                        }).ToList()
                    }).AsNoTracking().ToListAsync();
                if (!string.IsNullOrEmpty(searchText))
                {
                    foreach (var Item in ads)
                    {
                        AddSearchStatistic(Item.Id, (int)Item.UserId);

                    }
                }
                return ads;

            }

            else if (typeId == StaticData.Properties_ID)
            {
                var ads = await _db.PropertyAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.SubCategory)
                     .Where(a => a.Ad.Status == 1 &&(string.IsNullOrEmpty(searchText)
                        || a.Ad.Title.ToLower().Contains(searchText.ToLower())
                        || a.Ad.Description.ToLower().Contains(searchText.ToLower()))
                    && (string.IsNullOrEmpty(location)
                    || a.Ad.Ar_Location.ToLower().Contains(location.ToLower())
                    || a.Ad.En_Location.ToLower().Contains(location.ToLower()))
                    )
                    .Select(property => new GetPropertyAdDTO
                    {

                        TypeId = typeId,
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
                    }).AsNoTracking().ToListAsync();
                if (!string.IsNullOrEmpty(searchText))
                {
                    foreach (var Item in ads)
                    {
                        AddSearchStatistic(Item.Id, (int)Item.UserId);

                    }
                }
                return ads;

            }

            else if (typeId == StaticData.Business_ID)
            {
                var ads = await _db.BussinesAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                     .Where(a => a.Ad.Status == 1 && (string.IsNullOrEmpty(searchText)
                        || a.Ad.Title.ToLower().Contains(searchText.ToLower())
                        || a.Ad.Description.ToLower().Contains(searchText.ToLower()))
                    && (string.IsNullOrEmpty(location)
                    || a.Ad.Ar_Location.ToLower().Contains(location.ToLower())
                    || a.Ad.En_Location.ToLower().Contains(location.ToLower()))
                    )
                    .Select(business => new GetBussinesAdDTO
                    {
                        TypeId = typeId,
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
                        CategoryEnName = business.Ad.Category.En_Name,
                        CategoryArName = business.Ad.Category.Ar_Name,
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
                    }).AsNoTracking().ToListAsync();
                if (!string.IsNullOrEmpty(searchText))
                {
                    foreach (var Item in ads)
                    {
                        AddSearchStatistic(Item.Id, (int)Item.UserId);

                    }
                }

                return ads;


            }

            else if (typeId == StaticData.Services_ID)
            {

                var ads = await _db.ServiceAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.SubCategory)
                     .Where(a => a.Ad.Status == 1 && (string.IsNullOrEmpty(searchText)
                        || a.Ad.Title.ToLower().Contains(searchText.ToLower())
                        || a.Ad.Description.ToLower().Contains(searchText.ToLower()))
                    && (string.IsNullOrEmpty(location)
                    || a.Ad.Ar_Location.ToLower().Contains(location.ToLower())
                    || a.Ad.En_Location.ToLower().Contains(location.ToLower()))
                    )
                    .Select(service => new GetServiceAdDTO
                    {
                        TypeId = typeId,
                        Id = service.Ad.Id,
                        PhoneNumber = service.Ad.PhoneNumber,
                        ServiceTypeId = service.SubCategoryId,
                        OtherServiceType = service.OtherSubCategory,
                        ServiceTypeEn_Name = service.SubCategory.En_Name,
                        ServiceTypeAr_Name = service.SubCategory.Ar_Name,
                        AgentId = service.Ad.AgentId,
                        CategoryId = service.Ad.CategoryId,
                        CategoryEnName = service.Ad.Category.En_Name,
                        CategoryArName = service.Ad.Category.Ar_Name,
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
                    }).AsNoTracking().ToListAsync();
                if (!string.IsNullOrEmpty(searchText))
                {
                    foreach (var Item in ads)
                    {
                        AddSearchStatistic(Item.Id, (int)Item.UserId);

                    }
                }
                return ads;


            }

            else if (typeId == StaticData.Numbers_ID)
            {
                var ads = await _db.NumberAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                     .Where(a => a.Ad.Status == 1 &&(string.IsNullOrEmpty(searchText)
                        || a.Ad.Title.ToLower().Contains(searchText.ToLower())
                        || a.Ad.Description.ToLower().Contains(searchText.ToLower()))
                    && (string.IsNullOrEmpty(location)
                    || a.Ad.Ar_Location.ToLower().Contains(location.ToLower())
                    || a.Ad.En_Location.ToLower().Contains(location.ToLower()))
                    )
                    .Select(number => new GetNumberAdDTO
                    {
                        TypeId = typeId,
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
                    }).AsNoTracking().ToListAsync();
                if (!string.IsNullOrEmpty(searchText))
                {
                    foreach (var Item in ads)
                    {
                        AddSearchStatistic(Item.Id, (int)Item.UserId);

                    }
                }
                return ads;


            }

            else if (typeId == StaticData.Classifieds_ID)
            {
                var ads = await _db.ClassifiedAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.SubCategory).Include(a => a.SubType)
                     .Where(a => a.Ad.Status == 1 && (string.IsNullOrEmpty(searchText)
                        || a.Ad.Title.ToLower().Contains(searchText.ToLower())
                        || a.Ad.Description.ToLower().Contains(searchText.ToLower()))
                    && (string.IsNullOrEmpty(location)
                    || a.Ad.Ar_Location.ToLower().Contains(location.ToLower())
                    || a.Ad.En_Location.ToLower().Contains(location.ToLower()))
                    )
                    .Select(classified => new GetClassifiedAdDTO
                    {
                        TypeId = typeId,
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
                        CategoryEnName = classified.Ad.Category.En_Name,
                        CategoryArName = classified.Ad.Category.Ar_Name,
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
                    }).AsNoTracking().ToListAsync();
                if (!string.IsNullOrEmpty(searchText))
                {
                    foreach (var Item in ads)
                    {
                        AddSearchStatistic(Item.Id, (int)Item.UserId);

                    }
                }
                return ads;

            }

            return "";

        }

        public async Task<dynamic> GetLatestAds(int typeId)
        {
            if (typeId == StaticData.Motors_ID)
            {
                var ads = await _db.MotorAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.SubCategory).Include(a => a.SubType)
                    .Where(a => a.Ad.Status == 1)
                    .OrderByDescending(a => a.Ad.PostDate).Take(5)
                    .Select(motor => new GetMotorAdDTO
                    {
                        Id = motor.Ad.Id,
                        TypeId = typeId,
                        PhoneNumber = motor.Ad.PhoneNumber,
                        NameOfPart = motor.NameOfPart,
                        En_PartName = motor.Ar_PartName,
                        Ar_PartName = motor.Ar_PartName,
                        En_Maker = motor.En_Maker,
                        Ar_Maker = motor.Ar_Maker,
                        En_Model = motor.En_Model,
                        Ar_Model = motor.Ar_Model,
                        En_Trim = motor.En_Trim,
                        Ar_Trim = motor.Ar_Trim,
                        En_Color = motor.En_Color,
                        Ar_Color = motor.Ar_Color,
                        Kilometers = motor.Kilometers,
                        Year = motor.Year,
                        En_Doors = motor.En_Doors,
                        Ar_Doors = motor.Ar_Doors,
                        Warranty = motor.Warranty,
                        En_Transmission = motor.En_Transmission,
                        Ar_Transmission = motor.Ar_Transmission,
                        En_RegionalSpecs = motor.En_RegionalSpecs,
                        Ar_RegionalSpecs = motor.Ar_RegionalSpecs,
                        En_BodyType = motor.En_BodyType,
                        Ar_BodyType = motor.Ar_BodyType,
                        En_FuelType = motor.En_FuelType,
                        Ar_FuelType = motor.Ar_FuelType,
                        En_NoOfCylinders = motor.En_NoOfCylinders,
                        Ar_NoOfCylinders = motor.Ar_NoOfCylinders,
                        En_Horsepower = motor.En_Horsepower,
                        Ar_Horsepower = motor.Ar_Horsepower,
                        En_Condition = motor.En_Condition,
                        Ar_Condition = motor.Ar_Condition,
                        En_MechanicalCondition = motor.En_MechanicalCondition,
                        Ar_MechanicalCondition = motor.Ar_MechanicalCondition,
                        Price = motor.Price,
                        En_Age = motor.En_Age,
                        Ar_Age = motor.Ar_Age,
                        En_Capacity = motor.En_Capacity,
                        Ar_Capacity = motor.Ar_Capacity,
                        En_EngineSize = motor.En_EngineSize,
                        Ar_EngineSize = motor.Ar_EngineSize,
                        En_Length = motor.En_Length,
                        Ar_Length = motor.Ar_Length,
                        En_Usage = motor.En_Usage,
                        Ar_Usage = motor.Ar_Usage,
                        En_Wheels = motor.En_Wheels,
                        Ar_Wheels = motor.Ar_Wheels,
                        En_SellerType = motor.En_SellerType,
                        Ar_SellerType = motor.Ar_SellerType,
                        En_FinalDriveSystem = motor.En_FinalDriveSystem,
                        Ar_FinalDriveSystem = motor.Ar_FinalDriveSystem,
                        Ar_SteeringSide = motor.Ar_SteeringSide,
                        En_SteeringSide = motor.En_SteeringSide,
                        SubCategoryId = motor.SubCategoryId,
                        SubCategoryEn_Name = motor.SubCategory.En_Name,
                        SubCategoryAr_Name = motor.SubCategory.Ar_Name,
                        OtherSubCategory = motor.OtherSubCategory,
                        SubTypeId = motor.SubTypeId,
                        SubTypeEn_Name = motor.SubType.En_Name,
                        SubTypeAr_Name = motor.SubType.Ar_Name,
                        OtherSubType = motor.OtherSubType,
                        AgentId = motor.Ad.AgentId,
                        CategoryId = motor.Ad.CategoryId,
                        CategoryArName = motor.Ad.Category.Ar_Name,
                        CategoryEnName = motor.Ad.Category.En_Name,
                        Description = motor.Ad.Description,
                        Lat = motor.Ad.Lat,
                        Lng = motor.Ad.Lng,
                        En_Location = motor.Ad.En_Location,
                        Ar_Location = motor.Ad.Ar_Location,
                        UserId = motor.Ad.UserId,
                        UserImage = motor.Ad.User.ProfilePicture,
                        Pictures = motor.Ad.Pictures.Select(p => new AdPictureDTO
                        {
                            Id = p.Id,
                            ImageURL = p.ImageURL,
                            MainPicture = p.MainPicture

                        }).OrderByDescending(p => p.MainPicture).ToList(),
                        PostDate = motor.Ad.PostDate,
                        Title = motor.Ad.Title,
                        Status = motor.Ad.Status
                    }).AsNoTracking().ToListAsync();

                return ads;

            }

            else if (typeId == StaticData.Electronics_ID)
            {
                var ads = await _db.ElectronicAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.SubCategory).Include(a => a.SubType)
                    .Where(a => a.Ad.Status == 1)
                    .OrderByDescending(a => a.Ad.PostDate).Take(5)
                    .Select(electronic => new GetElectronicAd
                    {
                        TypeId = typeId,
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
                    }).AsNoTracking().ToListAsync();

                return ads;
            }

            else if (typeId == StaticData.Jobs_ID)
            {
                var ads = await _db.JobAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Where(a => a.Ad.Status == 1)
                    .OrderByDescending(a => a.Ad.PostDate).Take(5)
                    .Select(job => new GetJobAdDTO
                    {
                        TypeId = typeId,
                        Id = job.Ad.Id,
                        En_JobType = job.En_JobType,
                        Ar_JobType = job.Ar_JobType,
                        PhoneNumber = job.Ad.PhoneNumber,
                        CV = job.CV,
                        En_Gender = job.En_Gender,
                        Ar_Gender = job.Ar_Gender,
                        En_Nationality = job.En_Nationality,
                        Ar_Nationality = job.Ar_Nationality,
                        En_CurrentLocation = job.En_CurrentLocation,
                        Ar_CurrentLocation = job.Ar_CurrentLocation,
                        En_EducationLevel = job.En_EducationLevel,
                        Ar_EducationLevel = job.Ar_EducationLevel,
                        CurrentPosition = job.CurrentPosition,
                        En_WorkExperience = job.En_WorkExperience,
                        Ar_WorkExperience = job.Ar_WorkExperience,
                        En_Commitment = job.En_Commitment,
                        Ar_Commitment = job.Ar_Commitment,
                        En_NoticePeriod = job.En_NoticePeriod,
                        Ar_NoticePeriod = job.Ar_NoticePeriod,
                        En_VisaStatus = job.En_VisaStatus,
                        Ar_VisaStatus = job.Ar_VisaStatus,
                        En_CareerLevel = job.En_CareerLevel,
                        Ar_CareerLevel = job.Ar_CareerLevel,
                        ExpectedMonthlySalary = job.ExpectedMonthlySalary,
                        CompanyName = job.CompanyName,
                        En_EmploymentType = job.En_EmploymentType,
                        Ar_EmploymentType = job.Ar_EmploymentType,
                        En_MinEducationLevel = job.En_MinEducationLevel,
                        Ar_MinEducationLevel = job.Ar_MinEducationLevel,
                        En_MinWorkExperience = job.En_MinWorkExperience,
                        Ar_MinWorkExperience = job.Ar_MinWorkExperience,
                        AgentId = job.Ad.AgentId,
                        CategoryId = job.Ad.CategoryId,
                        CategoryArName = job.Ad.Category.Ar_Name,
                        CategoryEnName = job.Ad.Category.En_Name,
                        Description = job.Ad.Description,
                        Lat = job.Ad.Lat,
                        Lng = job.Ad.Lng,
                        En_Location = job.Ad.En_Location,
                        Ar_Location = job.Ad.Ar_Location,
                        UserId = job.Ad.UserId,
                        PostDate = job.Ad.PostDate,
                        Title = job.Ad.Title,
                        Status = job.Ad.Status,
                        Pictures = job.Ad.Pictures.Select(p => new AdPictureDTO
                        {
                            Id = p.Id,
                            ImageURL = p.ImageURL,
                            MainPicture = p.MainPicture
                        }).ToList()
                    }).AsNoTracking().ToListAsync();

                return ads;

            }

            else if (typeId == StaticData.Properties_ID)
            {
                var ads = await _db.PropertyAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.SubCategory)
                    .Where(a => a.Ad.Status == 1)
                    .OrderByDescending(a => a.Ad.PostDate).Take(5)
                    .Select(property => new GetPropertyAdDTO
                    {

                        TypeId = typeId,
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
                    }).AsNoTracking().ToListAsync();

                return ads;

            }

            else if (typeId == StaticData.Business_ID)
            {
                var ads = await _db.BussinesAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Where(a => a.Ad.Status == 1)
                    .OrderByDescending(a => a.Ad.PostDate).Take(5)
                    .Select(business => new GetBussinesAdDTO
                    {
                        TypeId = typeId,
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
                        CategoryEnName = business.Ad.Category.En_Name,
                        CategoryArName = business.Ad.Category.Ar_Name,
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
                    }).AsNoTracking().ToListAsync();


                return ads;


            }

            else if (typeId == StaticData.Services_ID)
            {

                var ads = await _db.ServiceAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.SubCategory)
                    .OrderByDescending(a => a.Ad.PostDate).Take(5)
                    .Where(a => a.Ad.Status == 1)
                    .Select(service => new GetServiceAdDTO
                    {
                        TypeId = typeId,
                        Id = service.Ad.Id,
                        PhoneNumber = service.Ad.PhoneNumber,
                        ServiceTypeId = service.SubCategoryId,
                        OtherServiceType = service.OtherSubCategory,
                        ServiceTypeEn_Name = service.SubCategory.En_Name,
                        ServiceTypeAr_Name = service.SubCategory.Ar_Name,
                        AgentId = service.Ad.AgentId,
                        CategoryId = service.Ad.CategoryId,
                        CategoryEnName = service.Ad.Category.En_Name,
                        CategoryArName = service.Ad.Category.Ar_Name,
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
                    }).AsNoTracking().ToListAsync();

                return ads;


            }

            else if (typeId == StaticData.Numbers_ID)
            {
                var ads = await _db.NumberAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Where(a => a.Ad.Status == 1)
                    .OrderByDescending(a => a.Ad.PostDate).Take(5)
                    .Select(number => new GetNumberAdDTO
                    {
                        TypeId = typeId,
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
                    }).AsNoTracking().ToListAsync();

                return ads;


            }

            else if (typeId == StaticData.Classifieds_ID)
            {
                var ads = await _db.ClassifiedAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.SubCategory).Include(a => a.SubType)
                    .Where(a => a.Ad.Status == 1)
                    .OrderByDescending(a => a.Ad.PostDate).Take(5)
                    .Select(classified => new GetClassifiedAdDTO
                    {
                        TypeId = typeId,
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
                        CategoryEnName = classified.Ad.Category.En_Name,
                        CategoryArName = classified.Ad.Category.Ar_Name,
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
                    }).AsNoTracking().ToListAsync();

                return ads;

            }

            return "";

        }


        public async Task<dynamic> GetAdsByCategoryId(int typeId, int categoryId, string searchText = "", string location = "",
            int maxKm = int.MaxValue, int minKm = 0, int maxYear = 5000,
            int minYear = 1900, double maxPrice = 0, double minPrice = 0,
            string maker = "", string model = "", string trim = ""
            )
        {
            if (typeId == StaticData.Motors_ID)
            {
                var ads = await _db.MotorAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.SubCategory).Include(a => a.SubType)
                    .Include(a => a.Ad.User)
                    .Where(a => a.Ad.CategoryId == categoryId && a.Ad.Status == 1
                    && (string.IsNullOrEmpty(searchText)
                        || a.Ad.Title.ToLower().Contains(searchText.ToLower())
                        || a.Ad.Description.ToLower().Contains(searchText.ToLower()))
                    && (string.IsNullOrEmpty(location)
                    || a.Ad.Ar_Location.ToLower().Contains(location.ToLower())
                    || a.Ad.En_Location.ToLower().Contains(location.ToLower()))
                    && ((a.Kilometers > minKm && a.Kilometers <= maxKm) || maxKm <= 0)
                    && ((a.Price >= minPrice && a.Price <= maxPrice) || maxPrice <= 0)
                    && (maker.Contains(a.En_Maker) || string.IsNullOrEmpty(maker) || maker == "none")
                    && (model.Contains(a.En_Model) || string.IsNullOrEmpty(model) || model == "none")
                    && (trim.Contains(a.En_Trim) || string.IsNullOrEmpty(trim) || trim == "none")
                    )
                    .Select(motor => new GetMotorAdDTO
                    {
                        Id = motor.Ad.Id,
                        TypeId = typeId,
                        PhoneNumber = motor.Ad.PhoneNumber,
                        NameOfPart = motor.NameOfPart,
                        En_PartName = motor.Ar_PartName,
                        Ar_PartName = motor.Ar_PartName,
                        En_Maker = motor.En_Maker,
                        Ar_Maker = motor.Ar_Maker,
                        En_Model = motor.En_Model,
                        Ar_Model = motor.Ar_Model,
                        En_Trim = motor.En_Trim,
                        Ar_Trim = motor.Ar_Trim,
                        En_Color = motor.En_Color,
                        Ar_Color = motor.Ar_Color,
                        Kilometers = motor.Kilometers,
                        Year = motor.Year,
                        En_Doors = motor.En_Doors,
                        Ar_Doors = motor.Ar_Doors,
                        Warranty = motor.Warranty,
                        En_Transmission = motor.En_Transmission,
                        Ar_Transmission = motor.Ar_Transmission,
                        En_RegionalSpecs = motor.En_RegionalSpecs,
                        Ar_RegionalSpecs = motor.Ar_RegionalSpecs,
                        En_BodyType = motor.En_BodyType,
                        Ar_BodyType = motor.Ar_BodyType,
                        En_FuelType = motor.En_FuelType,
                        Ar_FuelType = motor.Ar_FuelType,
                        En_NoOfCylinders = motor.En_NoOfCylinders,
                        Ar_NoOfCylinders = motor.Ar_NoOfCylinders,
                        En_Horsepower = motor.En_Horsepower,
                        Ar_Horsepower = motor.Ar_Horsepower,
                        En_Condition = motor.En_Condition,
                        Ar_Condition = motor.Ar_Condition,
                        En_MechanicalCondition = motor.En_MechanicalCondition,
                        Ar_MechanicalCondition = motor.Ar_MechanicalCondition,
                        Price = motor.Price,
                        En_Age = motor.En_Age,
                        Ar_Age = motor.Ar_Age,
                        En_Capacity = motor.En_Capacity,
                        Ar_Capacity = motor.Ar_Capacity,
                        En_EngineSize = motor.En_EngineSize,
                        Ar_EngineSize = motor.Ar_EngineSize,
                        En_Length = motor.En_Length,
                        Ar_Length = motor.Ar_Length,
                        En_Usage = motor.En_Usage,
                        Ar_Usage = motor.Ar_Usage,
                        En_Wheels = motor.En_Wheels,
                        Ar_Wheels = motor.Ar_Wheels,
                        En_SellerType = motor.En_SellerType,
                        Ar_SellerType = motor.Ar_SellerType,
                        En_FinalDriveSystem = motor.En_FinalDriveSystem,
                        Ar_FinalDriveSystem = motor.Ar_FinalDriveSystem,
                        Ar_SteeringSide = motor.Ar_SteeringSide,
                        En_SteeringSide = motor.En_SteeringSide,
                        SubCategoryId = motor.SubCategoryId,
                        SubCategoryEn_Name = motor.SubCategory.En_Name,
                        SubCategoryAr_Name = motor.SubCategory.Ar_Name,
                        OtherSubCategory = motor.OtherSubCategory,
                        SubTypeId = motor.SubTypeId,
                        SubTypeEn_Name = motor.SubType.En_Name,
                        SubTypeAr_Name = motor.SubType.Ar_Name,
                        OtherSubType = motor.OtherSubType,
                        AgentId = motor.Ad.AgentId,
                        CategoryId = motor.Ad.CategoryId,
                        CategoryArName = motor.Ad.Category.Ar_Name,
                        CategoryEnName = motor.Ad.Category.En_Name,
                        Description = motor.Ad.Description,
                        Lat = motor.Ad.Lat,
                        Lng = motor.Ad.Lng,
                        En_Location = motor.Ad.En_Location,
                        Ar_Location = motor.Ad.Ar_Location,
                        UserId = motor.Ad.UserId,
                        UserImage = motor.Ad.User.ProfilePicture,
                        Pictures = motor.Ad.Pictures.Select(p => new AdPictureDTO
                        {
                            Id = p.Id,
                            ImageURL = p.ImageURL,
                            MainPicture = p.MainPicture

                        }).OrderByDescending(p => p.MainPicture).ToList(),
                        PostDate = motor.Ad.PostDate,
                        Title = motor.Ad.Title,
                        Status = motor.Ad.Status
                    }).AsNoTracking().ToListAsync();
                if (!string.IsNullOrEmpty(searchText))
                {
                    foreach (var Item in ads)
                    {
                        AddSearchStatistic(Item.Id, (int)Item.UserId);

                    }
                }
                return ads;

            }

            else if (typeId == StaticData.Electronics_ID)
            {
                var ads = await _db.ElectronicAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.SubCategory).Include(a => a.SubType)
                    .Include(a => a.Ad.User)
                    .Where(a => a.Ad.CategoryId == categoryId && a.Ad.Status == 1
                    && (string.IsNullOrEmpty(searchText)
                        || a.Ad.Title.ToLower().Contains(searchText.ToLower())
                        || a.Ad.Description.ToLower().Contains(searchText.ToLower()))
                    && (string.IsNullOrEmpty(location)
                    || a.Ad.Ar_Location.ToLower().Contains(location.ToLower())
                    || a.Ad.En_Location.ToLower().Contains(location.ToLower()))
                    )

                    .Select(electronic => new GetElectronicAd
                    {
                        TypeId = typeId,
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
                    }).AsNoTracking().ToListAsync();
                if (!string.IsNullOrEmpty(searchText))
                {
                    foreach (var Item in ads)
                    {
                        AddSearchStatistic(Item.Id, (int)Item.UserId);

                    }
                }
                return ads;

            }

            else if (typeId == StaticData.Jobs_ID)
            {
                var ads = await _db.JobAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.Ad.User)
                    .Where(a => a.Ad.CategoryId == categoryId && a.Ad.Status == 1
                    && (string.IsNullOrEmpty(searchText)
                        || a.Ad.Title.ToLower().Contains(searchText.ToLower())
                        || a.Ad.Description.ToLower().Contains(searchText.ToLower()))
                    && (string.IsNullOrEmpty(location)
                    || a.Ad.Ar_Location.ToLower().Contains(location.ToLower())
                    || a.Ad.En_Location.ToLower().Contains(location.ToLower())
                    && a.Ad.Status == 1)
                    )
                    .Select(job => new GetJobAdDTO
                    {
                        TypeId = typeId,
                        Id = job.Ad.Id,
                        En_JobType = job.En_JobType,
                        Ar_JobType = job.Ar_JobType,
                        PhoneNumber = job.Ad.PhoneNumber,
                        CV = job.CV,
                        En_Gender = job.En_Gender,
                        Ar_Gender = job.Ar_Gender,
                        En_Nationality = job.En_Nationality,
                        Ar_Nationality = job.Ar_Nationality,
                        En_CurrentLocation = job.En_CurrentLocation,
                        Ar_CurrentLocation = job.Ar_CurrentLocation,
                        En_EducationLevel = job.En_EducationLevel,
                        Ar_EducationLevel = job.Ar_EducationLevel,
                        CurrentPosition = job.CurrentPosition,
                        En_WorkExperience = job.En_WorkExperience,
                        Ar_WorkExperience = job.Ar_WorkExperience,
                        En_Commitment = job.En_Commitment,
                        Ar_Commitment = job.Ar_Commitment,
                        En_NoticePeriod = job.En_NoticePeriod,
                        Ar_NoticePeriod = job.Ar_NoticePeriod,
                        En_VisaStatus = job.En_VisaStatus,
                        Ar_VisaStatus = job.Ar_VisaStatus,
                        En_CareerLevel = job.En_CareerLevel,
                        Ar_CareerLevel = job.Ar_CareerLevel,
                        ExpectedMonthlySalary = job.ExpectedMonthlySalary,
                        CompanyName = job.CompanyName,
                        En_EmploymentType = job.En_EmploymentType,
                        Ar_EmploymentType = job.Ar_EmploymentType,
                        En_MinEducationLevel = job.En_MinEducationLevel,
                        Ar_MinEducationLevel = job.Ar_MinEducationLevel,
                        En_MinWorkExperience = job.En_MinWorkExperience,
                        Ar_MinWorkExperience = job.Ar_MinWorkExperience,
                        UserImage = job.Ad.User.ProfilePicture,
                        AgentId = job.Ad.AgentId,
                        CategoryId = job.Ad.CategoryId,
                        CategoryArName = job.Ad.Category.Ar_Name,
                        CategoryEnName = job.Ad.Category.En_Name,
                        Description = job.Ad.Description,
                        Lat = job.Ad.Lat,
                        Lng = job.Ad.Lng,
                        En_Location = job.Ad.En_Location,
                        Ar_Location = job.Ad.Ar_Location,
                        UserId = job.Ad.UserId,
                        PostDate = job.Ad.PostDate,
                        Title = job.Ad.Title,
                        Status = job.Ad.Status,
                        Pictures = job.Ad.Pictures.Select(p => new AdPictureDTO
                        {
                            Id = p.Id,
                            ImageURL = p.ImageURL,
                            MainPicture = p.MainPicture
                        }).ToList()
                    }).AsNoTracking().ToListAsync();
                if (!string.IsNullOrEmpty(searchText))
                {
                    foreach (var Item in ads)
                    {
                        AddSearchStatistic(Item.Id, (int)Item.UserId);

                    }
                }
                return ads;

            }

            else if (typeId == StaticData.Properties_ID)
            {
                var ads = await _db.PropertyAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.SubCategory)
                    .Include(a => a.Ad.User)
                    .Where(a => a.Ad.CategoryId == categoryId && a.Ad.Status == 1
                    && (string.IsNullOrEmpty(searchText)
                        || a.Ad.Title.ToLower().Contains(searchText.ToLower())
                        || a.Ad.Description.ToLower().Contains(searchText.ToLower()))
                    && (string.IsNullOrEmpty(location)
                    || a.Ad.Ar_Location.ToLower().Contains(location.ToLower())
                    || a.Ad.En_Location.ToLower().Contains(location.ToLower()))
                    )
                    .Select(property => new GetPropertyAdDTO
                    {

                        TypeId = typeId,
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
                if (!string.IsNullOrEmpty(searchText))
                {
                    foreach (var Item in ads)
                    {
                        AddSearchStatistic(Item.Id, (int)Item.UserId);

                    }
                }
                return ads;

            }

            else if (typeId == StaticData.Business_ID)
            {
                var ads = await _db.BussinesAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.Ad.User)
                    .Where(a => a.Ad.CategoryId == categoryId && a.Ad.Status == 1
                    && (string.IsNullOrEmpty(searchText)
                        || a.Ad.Title.ToLower().Contains(searchText.ToLower())
                        || a.Ad.Description.ToLower().Contains(searchText.ToLower()))
                    && (string.IsNullOrEmpty(location)
                    || a.Ad.Ar_Location.ToLower().Contains(location.ToLower())
                    || a.Ad.En_Location.ToLower().Contains(location.ToLower()))
                    )
                    .Select(business => new GetBussinesAdDTO
                    {
                        TypeId = typeId,
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
                        CategoryEnName = business.Ad.Category.En_Name,
                        CategoryArName = business.Ad.Category.Ar_Name,
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
                    }).AsNoTracking().ToListAsync();

                if (!string.IsNullOrEmpty(searchText))
                {
                    foreach (var Item in ads)
                    {
                        AddSearchStatistic(Item.Id, (int)Item.UserId);

                    }
                }
                return ads;


            }

            else if (typeId == StaticData.Services_ID)
            {

                var ads = await _db.ServiceAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.SubCategory)
                    .Include(a => a.Ad.User)
                    .Where(a => a.Ad.CategoryId == categoryId && a.Ad.Status == 1
                    && (string.IsNullOrEmpty(searchText)
                        || a.Ad.Title.ToLower().Contains(searchText.ToLower())
                        || a.Ad.Description.ToLower().Contains(searchText.ToLower()))
                    && (string.IsNullOrEmpty(location)
                    || a.Ad.Ar_Location.ToLower().Contains(location.ToLower())
                    || a.Ad.En_Location.ToLower().Contains(location.ToLower()))

                    )
                    .Select(service => new GetServiceAdDTO
                    {
                        TypeId = typeId,
                        Id = service.Ad.Id,
                        PhoneNumber = service.Ad.PhoneNumber,
                        ServiceTypeId = service.SubCategoryId,
                        OtherServiceType = service.OtherSubCategory,
                        ServiceTypeEn_Name = service.SubCategory.En_Name,
                        ServiceTypeAr_Name = service.SubCategory.Ar_Name,
                        UserImage = service.Ad.User.ProfilePicture,
                        AgentId = service.Ad.AgentId,
                        CategoryId = service.Ad.CategoryId,
                        CategoryEnName = service.Ad.Category.En_Name,
                        CategoryArName = service.Ad.Category.Ar_Name,
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
                    }).AsNoTracking().ToListAsync();
                if (!string.IsNullOrEmpty(searchText))
                {
                    foreach (var Item in ads)
                    {
                        AddSearchStatistic(Item.Id, (int)Item.UserId);

                    }
                }
                return ads;


            }

            else if (typeId == StaticData.Numbers_ID)
            {
                var ads = await _db.NumberAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.Ad.User)
                    .Where(a => a.Ad.CategoryId == categoryId && a.Ad.Status == 1
                    && (string.IsNullOrEmpty(searchText)
                        || a.Ad.Title.ToLower().Contains(searchText.ToLower())
                        || a.Ad.Description.ToLower().Contains(searchText.ToLower()))
                    && (string.IsNullOrEmpty(location)
                    || a.Ad.Ar_Location.ToLower().Contains(location.ToLower())
                    || a.Ad.En_Location.ToLower().Contains(location.ToLower()))
                    )
                    .Select(number => new GetNumberAdDTO
                    {
                        TypeId = typeId,
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
                if (!string.IsNullOrEmpty(searchText))
                {
                    foreach (var Item in ads)
                    {
                        AddSearchStatistic(Item.Id, (int)Item.UserId);

                    }
                }
                return ads;


            }

            else if (typeId == StaticData.Classifieds_ID)
            {
                var ads = await _db.ClassifiedAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.SubCategory).Include(a => a.SubType)
                    .Include(a => a.Ad.User)
                    .Where(a => a.Ad.CategoryId == categoryId && a.Ad.Status == 1
                    && (string.IsNullOrEmpty(searchText)
                        || a.Ad.Title.ToLower().Contains(searchText.ToLower())
                        || a.Ad.Description.ToLower().Contains(searchText.ToLower()))
                    && (string.IsNullOrEmpty(location)
                    || a.Ad.Ar_Location.ToLower().Contains(location.ToLower())
                    || a.Ad.En_Location.ToLower().Contains(location.ToLower()))
                    )
                    .Select(classified => new GetClassifiedAdDTO
                    {
                        TypeId = typeId,
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
                        CategoryEnName = classified.Ad.Category.En_Name,
                        CategoryArName = classified.Ad.Category.Ar_Name,
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
                    }).AsNoTracking().ToListAsync();
                if (!string.IsNullOrEmpty(searchText))
                {
                    foreach (var Item in ads)
                    {
                        AddSearchStatistic(Item.Id, (int)Item.UserId);

                    }
                }
                return ads;

            }

            return "";

        }

        public async Task<dynamic> GetAd(int adId, int typeId)
        {

            #region add statistic obj
            var AD = _db.Ads.Where(x => x.Id == adId).FirstOrDefault();

            if (AD == null) return null;

            AdStatistic s = new AdStatistic
            {
                AdId = adId,
                Date = DateTime.Now,
                Type = (int)StatisticTypes.Views,
                UserId = (int)AD.UserId

            };
            _db.AdStatistics.Add(s);
            _db.SaveChanges();


            #endregion


            if (typeId == StaticData.Motors_ID)
            {
                var ad = await _db.MotorAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.SubCategory).Include(a => a.SubType)
                    .Where(a => a.Ad.Status == 1)
                    .Select(motor => new GetMotorAdDTO
                    {
                        Id = motor.Ad.Id,
                        TypeId = typeId,
                        PhoneNumber = motor.Ad.PhoneNumber,
                        NameOfPart = motor.NameOfPart,
                        En_PartName = motor.Ar_PartName,
                        Ar_PartName = motor.Ar_PartName,
                        En_Maker = motor.En_Maker,
                        Ar_Maker = motor.Ar_Maker,
                        En_Model = motor.En_Model,
                        Ar_Model = motor.Ar_Model,
                        En_Trim = motor.En_Trim,
                        Ar_Trim = motor.Ar_Trim,
                        En_Color = motor.En_Color,
                        Ar_Color = motor.Ar_Color,
                        Kilometers = motor.Kilometers,
                        Year = motor.Year,
                        En_Doors = motor.En_Doors,
                        Ar_Doors = motor.Ar_Doors,
                        Warranty = motor.Warranty,
                        En_Transmission = motor.En_Transmission,
                        Ar_Transmission = motor.Ar_Transmission,
                        En_RegionalSpecs = motor.En_RegionalSpecs,
                        Ar_RegionalSpecs = motor.Ar_RegionalSpecs,
                        En_BodyType = motor.En_BodyType,
                        Ar_BodyType = motor.Ar_BodyType,
                        En_FuelType = motor.En_FuelType,
                        Ar_FuelType = motor.Ar_FuelType,
                        En_NoOfCylinders = motor.En_NoOfCylinders,
                        Ar_NoOfCylinders = motor.Ar_NoOfCylinders,
                        En_Horsepower = motor.En_Horsepower,
                        Ar_Horsepower = motor.Ar_Horsepower,
                        En_Condition = motor.En_Condition,
                        Ar_Condition = motor.Ar_Condition,
                        En_MechanicalCondition = motor.En_MechanicalCondition,
                        Ar_MechanicalCondition = motor.Ar_MechanicalCondition,
                        Price = motor.Price,
                        En_Age = motor.En_Age,
                        Ar_Age = motor.Ar_Age,
                        En_Capacity = motor.En_Capacity,
                        Ar_Capacity = motor.Ar_Capacity,
                        En_EngineSize = motor.En_EngineSize,
                        Ar_EngineSize = motor.Ar_EngineSize,
                        En_Length = motor.En_Length,
                        Ar_Length = motor.Ar_Length,
                        En_Usage = motor.En_Usage,
                        Ar_Usage = motor.Ar_Usage,
                        En_Wheels = motor.En_Wheels,
                        Ar_Wheels = motor.Ar_Wheels,
                        En_SellerType = motor.En_SellerType,
                        Ar_SellerType = motor.Ar_SellerType,
                        En_FinalDriveSystem = motor.En_FinalDriveSystem,
                        Ar_FinalDriveSystem = motor.Ar_FinalDriveSystem,
                        Ar_SteeringSide = motor.Ar_SteeringSide,
                        En_SteeringSide = motor.En_SteeringSide,
                        SubCategoryId = motor.SubCategoryId,
                        SubCategoryEn_Name = motor.SubCategory.En_Name,
                        SubCategoryAr_Name = motor.SubCategory.Ar_Name,
                        OtherSubCategory = motor.OtherSubCategory,
                        SubTypeId = motor.SubTypeId,
                        SubTypeEn_Name = motor.SubType.En_Name,
                        SubTypeAr_Name = motor.SubType.Ar_Name,
                        OtherSubType = motor.OtherSubType,
                        AgentId = motor.Ad.AgentId,
                        CategoryId = motor.Ad.CategoryId,
                        CategoryArName = motor.Ad.Category.Ar_Name,
                        CategoryEnName = motor.Ad.Category.En_Name,
                        Description = motor.Ad.Description,
                        Lat = motor.Ad.Lat,
                        Lng = motor.Ad.Lng,
                        En_Location = motor.Ad.En_Location,
                        Ar_Location = motor.Ad.Ar_Location,
                        UserId = motor.Ad.UserId,
                        UserImage = motor.Ad.User.ProfilePicture,
                        Pictures = motor.Ad.Pictures.Select(p => new AdPictureDTO
                        {
                            Id = p.Id,
                            ImageURL = p.ImageURL,
                            MainPicture = p.MainPicture

                        }).OrderByDescending(p => p.MainPicture).ToList(),
                        PostDate = motor.Ad.PostDate,
                        Title = motor.Ad.Title,
                        Status = motor.Ad.Status
                    }).AsNoTracking().FirstOrDefaultAsync(a => a.Id == adId);

                return ad;

            }

            else if (typeId == StaticData.Electronics_ID)
            {
                var ad = await _db.ElectronicAds.Include(a => a.Ad).Include(a => a.Ad.Pictures)
                    .Include(a => a.Ad.Category).Include(a => a.SubCategory).Include(a => a.SubType)
                    .Where(a => a.Ad.Status == 1)
                    .Select(electronic => new GetElectronicAd
                    {
                        TypeId = typeId,
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

                return ad;


            }

            else if (typeId == StaticData.Jobs_ID)
            {
                var ad = await _db.JobAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Where(a => a.Ad.Status == 1)
                    .Select(job => new GetJobAdDTO
                    {
                        TypeId = typeId,
                        Id = job.Ad.Id,
                        En_JobType = job.En_JobType,
                        Ar_JobType = job.Ar_JobType,
                        PhoneNumber = job.Ad.PhoneNumber,
                        CV = job.CV,
                        En_Gender = job.En_Gender,
                        Ar_Gender = job.Ar_Gender,
                        En_Nationality = job.En_Nationality,
                        Ar_Nationality = job.Ar_Nationality,
                        En_CurrentLocation = job.En_CurrentLocation,
                        Ar_CurrentLocation = job.Ar_CurrentLocation,
                        En_EducationLevel = job.En_EducationLevel,
                        Ar_EducationLevel = job.Ar_EducationLevel,
                        CurrentPosition = job.CurrentPosition,
                        En_WorkExperience = job.En_WorkExperience,
                        Ar_WorkExperience = job.Ar_WorkExperience,
                        En_Commitment = job.En_Commitment,
                        Ar_Commitment = job.Ar_Commitment,
                        En_NoticePeriod = job.En_NoticePeriod,
                        Ar_NoticePeriod = job.Ar_NoticePeriod,
                        En_VisaStatus = job.En_VisaStatus,
                        Ar_VisaStatus = job.Ar_VisaStatus,
                        En_CareerLevel = job.En_CareerLevel,
                        Ar_CareerLevel = job.Ar_CareerLevel,
                        ExpectedMonthlySalary = job.ExpectedMonthlySalary,
                        CompanyName = job.CompanyName,
                        En_EmploymentType = job.En_EmploymentType,
                        Ar_EmploymentType = job.Ar_EmploymentType,
                        En_MinEducationLevel = job.En_MinEducationLevel,
                        Ar_MinEducationLevel = job.Ar_MinEducationLevel,
                        En_MinWorkExperience = job.En_MinWorkExperience,
                        Ar_MinWorkExperience = job.Ar_MinWorkExperience,
                        AgentId = job.Ad.AgentId,
                        CategoryId = job.Ad.CategoryId,
                        CategoryArName = job.Ad.Category.Ar_Name,
                        CategoryEnName = job.Ad.Category.En_Name,
                        Description = job.Ad.Description,
                        Lat = job.Ad.Lat,
                        Lng = job.Ad.Lng,
                        En_Location = job.Ad.En_Location,
                        Ar_Location = job.Ad.Ar_Location,
                        UserId = job.Ad.UserId,
                        PostDate = job.Ad.PostDate,
                        Title = job.Ad.Title,
                        Status = job.Ad.Status,
                        Pictures = job.Ad.Pictures.Select(p => new AdPictureDTO
                        {
                            Id = p.Id,
                            ImageURL = p.ImageURL,
                            MainPicture = p.MainPicture
                        }).ToList()
                    }).AsNoTracking().FirstOrDefaultAsync(a => a.Id == adId && a.Status == 1);

                return ad;


            }

            else if (typeId == StaticData.Properties_ID)
            {
                var ad = await _db.PropertyAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.SubCategory)
                    .Where(a => a.Ad.Status == 1)
                    .Select(property => new GetPropertyAdDTO
                    {

                        TypeId = typeId,
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

                return ad;
            }

            else if (typeId == StaticData.Business_ID)
            {
                var ad = await _db.BussinesAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Where(a => a.Ad.Status == 1)
                    .Select(business => new GetBussinesAdDTO
                    {
                        TypeId = typeId,
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

                return ad;

            }

            else if (typeId == StaticData.Services_ID)
            {

                var ad = await _db.ServiceAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.SubCategory)
                    .Where(a => a.Ad.Status == 1)
                    .Select(service => new GetServiceAdDTO
                    {
                        TypeId = typeId,
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

            else if (typeId == StaticData.Numbers_ID)
            {
                var ad = await _db.NumberAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Where(a => a.Ad.Status == 1)
                    .Select(number => new GetNumberAdDTO
                    {
                        TypeId = typeId,
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

                return ad;

            }

            else if (typeId == StaticData.Classifieds_ID)
            {
                var ad = await _db.ClassifiedAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.SubCategory).Include(a => a.SubType)
                    .Where(a => a.Ad.Status == 1)
                    .Select(classified => new GetClassifiedAdDTO
                    {
                        TypeId = typeId,
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

                return ad;
            }

            return "";
        }

        public async Task<List<AdCountDTO>> GetUserAdsCount(int userId, bool isOwner)
        {
            var list = new List<AdCountDTO>();

            for (int i = 1; i <= 8; i++)
            {
                var adCountDTO = new AdCountDTO()
                {
                    TypeId = i
                };

                if (isOwner)
                {
                    adCountDTO.Count = await _db.Ads.Where(b => b.TypeId == i && b.UserId == userId && (b.Status == 1 || b.Status == 2 ))
                        .AsNoTracking().CountAsync();
                }
                else
                {
                    await _db.Ads.Where(b => b.TypeId == i && b.UserId == userId && b.Status == 1).AsNoTracking().CountAsync();
                }

                list.Add(adCountDTO);
            }

            return list;
        }

        public async Task<List<AdCountDTO>> GetMyFavoriteAdsCount(int userId)
        {
            var list = new List<AdCountDTO>();

            for (int i = 1; i <= 8; i++)
            {
                var adCountDTO = new AdCountDTO()
                {
                    Count = await _db.Favorites.Include(a => a.Ad).Where(a => a.Ad.TypeId == i && a.UserId == userId).AsNoTracking().CountAsync(),
                    TypeId = i
                };

                list.Add(adCountDTO);
            }

            return list;
        }



        public async Task<List<AdCountDTO>> GetSavedSearchCount(int userId)
        {
            var list = new List<AdCountDTO>();

            for (int i = 1; i <= 8; i++)
            {
                var adCountDTO = new AdCountDTO()
                {
                    Count = await _db.SavedSearch.Where(a => a.ADTypeId == i && a.UserId == userId).AsNoTracking().CountAsync(),
                    TypeId = i
                };

                list.Add(adCountDTO);
            }

            return list;
        }

        public async Task<int> IsDeatilsProcessDone(int userId, int typeId, int adId, int cateogryId)
        {
            if (typeId != StaticData.Properties_ID && typeId != StaticData.Jobs_ID)
            {
                var offer = await _db.AdOffers.AsNoTracking().FirstOrDefaultAsync(a => a.AdId == adId && a.UserId == userId);

                if (offer != null) return 1;

                return 0;
            }
            else if (typeId == StaticData.Properties_ID)
            {
                //var offer = await _db.Inqu.AsNoTracking().FirstOrDefaultAsync(a => a.AdId == adId && a.UserId == userId);

                //if (offer != null) return true;

                return 0;
            }
            else if (cateogryId == StaticData.JobOpening_ID)
            {
                var application = await _db.JobApplications.AsNoTracking()
                    .FirstOrDefaultAsync(a => a.AdId == adId && a.UserId == userId);

                if (application != null) return 1;

                return 0;
            }

            return -1;
        }

        public async Task<bool> IsOfferMaked(int userId, int adId)
        {
            var offer = await _db.AdOffers.AsNoTracking().FirstOrDefaultAsync(a => a.AdId == adId && a.UserId == userId);

            if (offer != null) return true;

            return false;
        }

        public async Task<bool> IsJobApplicationApplied(int userId, int adId)
        {
            var offer = await _db.AdOffers.AsNoTracking().FirstOrDefaultAsync(a => a.AdId == adId && a.UserId == userId);


            var application = await _db.JobApplications.AsNoTracking()
                .FirstOrDefaultAsync(a => a.AdId == adId && a.UserId == userId);

            if (application != null) return true;

            return false;
        }

        public async Task<bool> IsInFavorite(int userId, int adId)
        {
            var favorite = await _db.Favorites.AsNoTracking().FirstOrDefaultAsync(f => f.UserId == userId && f.AdId == adId);

            if (favorite != null) return true;

            return false;
        }

        public async Task<dynamic> GetSimilarAds(int typeId, int categoryId, int currentAdId)
        {
            if (typeId == StaticData.Motors_ID)
            {
                var ads = await _db.MotorAds.Include(a => a.Ad).Include(a => a.Ad.Pictures)
                    .Include(a => a.Ad.Category).Include(a => a.SubCategory).Include(a => a.SubType)
                    .Where(a => a.Ad.Id != currentAdId && a.Ad.CategoryId == categoryId && a.Ad.Status == 1)
                    .OrderByDescending(a => a.Ad.PostDate).Take(5)
                    .Select(motor => new GetMotorAdDTO
                    {
                        Id = motor.Ad.Id,
                        TypeId = typeId,
                        PhoneNumber = motor.Ad.PhoneNumber,
                        NameOfPart = motor.NameOfPart,
                        En_PartName = motor.Ar_PartName,
                        Ar_PartName = motor.Ar_PartName,
                        En_Maker = motor.En_Maker,
                        Ar_Maker = motor.Ar_Maker,
                        En_Model = motor.En_Model,
                        Ar_Model = motor.Ar_Model,
                        En_Trim = motor.En_Trim,
                        Ar_Trim = motor.Ar_Trim,
                        En_Color = motor.En_Color,
                        Ar_Color = motor.Ar_Color,
                        Kilometers = motor.Kilometers,
                        Year = motor.Year,
                        En_Doors = motor.En_Doors,
                        Ar_Doors = motor.Ar_Doors,
                        Warranty = motor.Warranty,
                        En_Transmission = motor.En_Transmission,
                        Ar_Transmission = motor.Ar_Transmission,
                        En_RegionalSpecs = motor.En_RegionalSpecs,
                        Ar_RegionalSpecs = motor.Ar_RegionalSpecs,
                        En_BodyType = motor.En_BodyType,
                        Ar_BodyType = motor.Ar_BodyType,
                        En_FuelType = motor.En_FuelType,
                        Ar_FuelType = motor.Ar_FuelType,
                        En_NoOfCylinders = motor.En_NoOfCylinders,
                        Ar_NoOfCylinders = motor.Ar_NoOfCylinders,
                        En_Horsepower = motor.En_Horsepower,
                        Ar_Horsepower = motor.Ar_Horsepower,
                        En_Condition = motor.En_Condition,
                        Ar_Condition = motor.Ar_Condition,
                        En_MechanicalCondition = motor.En_MechanicalCondition,
                        Ar_MechanicalCondition = motor.Ar_MechanicalCondition,
                        Price = motor.Price,
                        En_Age = motor.En_Age,
                        Ar_Age = motor.Ar_Age,
                        En_Capacity = motor.En_Capacity,
                        Ar_Capacity = motor.Ar_Capacity,
                        En_EngineSize = motor.En_EngineSize,
                        Ar_EngineSize = motor.Ar_EngineSize,
                        En_Length = motor.En_Length,
                        Ar_Length = motor.Ar_Length,
                        En_Usage = motor.En_Usage,
                        Ar_Usage = motor.Ar_Usage,
                        En_Wheels = motor.En_Wheels,
                        Ar_Wheels = motor.Ar_Wheels,
                        En_SellerType = motor.En_SellerType,
                        Ar_SellerType = motor.Ar_SellerType,
                        En_FinalDriveSystem = motor.En_FinalDriveSystem,
                        Ar_FinalDriveSystem = motor.Ar_FinalDriveSystem,
                        Ar_SteeringSide = motor.Ar_SteeringSide,
                        En_SteeringSide = motor.En_SteeringSide,
                        SubCategoryId = motor.SubCategoryId,
                        SubCategoryEn_Name = motor.SubCategory.En_Name,
                        SubCategoryAr_Name = motor.SubCategory.Ar_Name,
                        OtherSubCategory = motor.OtherSubCategory,
                        SubTypeId = motor.SubTypeId,
                        SubTypeEn_Name = motor.SubType.En_Name,
                        SubTypeAr_Name = motor.SubType.Ar_Name,
                        OtherSubType = motor.OtherSubType,
                        AgentId = motor.Ad.AgentId,
                        CategoryId = motor.Ad.CategoryId,
                        CategoryArName = motor.Ad.Category.Ar_Name,
                        CategoryEnName = motor.Ad.Category.En_Name,
                        Description = motor.Ad.Description,
                        Lat = motor.Ad.Lat,
                        Lng = motor.Ad.Lng,
                        En_Location = motor.Ad.En_Location,
                        Ar_Location = motor.Ad.Ar_Location,
                        UserId = motor.Ad.UserId,
                        UserImage = motor.Ad.User.ProfilePicture,
                        Pictures = motor.Ad.Pictures.Select(p => new AdPictureDTO
                        {
                            Id = p.Id,
                            ImageURL = p.ImageURL,
                            MainPicture = p.MainPicture

                        }).OrderByDescending(p => p.MainPicture).ToList(),
                        PostDate = motor.Ad.PostDate,
                        Title = motor.Ad.Title,
                        Status = motor.Ad.Status
                    }).AsNoTracking().ToListAsync();

                return ads;

            }

            else if (typeId == StaticData.Electronics_ID)
            {
                var ads = await _db.ElectronicAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.SubCategory).Include(a => a.SubType)
                    .Where(a => a.Ad.Id != currentAdId && a.Ad.CategoryId == categoryId && a.Ad.Status == 1)
                    .OrderByDescending(a => a.Ad.PostDate).Take(5)
                    .Select(electronic => new GetElectronicAd
                    {
                        TypeId = typeId,
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
                    }).AsNoTracking().ToListAsync();

                return ads;
            }

            else if (typeId == StaticData.Jobs_ID)
            {
                var ads = await _db.JobAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Where(a => a.Ad.Id != currentAdId && a.Ad.CategoryId == categoryId && a.Ad.Status == 1)
                    .OrderByDescending(a => a.Ad.PostDate).Take(5)
                    .Select(job => new GetJobAdDTO
                    {
                        TypeId = typeId,
                        Id = job.Ad.Id,
                        En_JobType = job.En_JobType,
                        Ar_JobType = job.Ar_JobType,
                        PhoneNumber = job.Ad.PhoneNumber,
                        CV = job.CV,
                        En_Gender = job.En_Gender,
                        Ar_Gender = job.Ar_Gender,
                        En_Nationality = job.En_Nationality,
                        Ar_Nationality = job.Ar_Nationality,
                        En_CurrentLocation = job.En_CurrentLocation,
                        Ar_CurrentLocation = job.Ar_CurrentLocation,
                        En_EducationLevel = job.En_EducationLevel,
                        Ar_EducationLevel = job.Ar_EducationLevel,
                        CurrentPosition = job.CurrentPosition,
                        En_WorkExperience = job.En_WorkExperience,
                        Ar_WorkExperience = job.Ar_WorkExperience,
                        En_Commitment = job.En_Commitment,
                        Ar_Commitment = job.Ar_Commitment,
                        En_NoticePeriod = job.En_NoticePeriod,
                        Ar_NoticePeriod = job.Ar_NoticePeriod,
                        En_VisaStatus = job.En_VisaStatus,
                        Ar_VisaStatus = job.Ar_VisaStatus,
                        En_CareerLevel = job.En_CareerLevel,
                        Ar_CareerLevel = job.Ar_CareerLevel,
                        ExpectedMonthlySalary = job.ExpectedMonthlySalary,
                        CompanyName = job.CompanyName,
                        En_EmploymentType = job.En_EmploymentType,
                        Ar_EmploymentType = job.Ar_EmploymentType,
                        En_MinEducationLevel = job.En_MinEducationLevel,
                        Ar_MinEducationLevel = job.Ar_MinEducationLevel,
                        En_MinWorkExperience = job.En_MinWorkExperience,
                        Ar_MinWorkExperience = job.Ar_MinWorkExperience,
                        AgentId = job.Ad.AgentId,
                        CategoryId = job.Ad.CategoryId,
                        CategoryArName = job.Ad.Category.Ar_Name,
                        CategoryEnName = job.Ad.Category.En_Name,
                        Description = job.Ad.Description,
                        Lat = job.Ad.Lat,
                        Lng = job.Ad.Lng,
                        En_Location = job.Ad.En_Location,
                        Ar_Location = job.Ad.Ar_Location,
                        UserId = job.Ad.UserId,
                        PostDate = job.Ad.PostDate,
                        Title = job.Ad.Title,
                        Status = job.Ad.Status,
                        Pictures = job.Ad.Pictures.Select(p => new AdPictureDTO
                        {
                            Id = p.Id,
                            ImageURL = p.ImageURL,
                            MainPicture = p.MainPicture
                        }).ToList()
                    }).AsNoTracking().ToListAsync();

                return ads;

            }

            else if (typeId == StaticData.Properties_ID)
            {
                var ads = await _db.PropertyAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.SubCategory)
                    .Where(a => a.Ad.Id != currentAdId && a.Ad.CategoryId == categoryId && a.Ad.Status == 1)
                    .OrderByDescending(a => a.Ad.PostDate).Take(5)
                    .Select(property => new GetPropertyAdDTO
                    {

                        TypeId = typeId,
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
                    }).AsNoTracking().ToListAsync();

                return ads;

            }

            else if (typeId == StaticData.Business_ID)
            {
                var ads = await _db.BussinesAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Where(a => a.Ad.Id != currentAdId && a.Ad.CategoryId == categoryId && a.Ad.Status == 1)
                    .OrderByDescending(a => a.Ad.PostDate).Take(5)
                    .Select(business => new GetBussinesAdDTO
                    {
                        TypeId = typeId,
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
                        CategoryEnName = business.Ad.Category.En_Name,
                        CategoryArName = business.Ad.Category.Ar_Name,
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
                    }).AsNoTracking().ToListAsync();


                return ads;


            }

            else if (typeId == StaticData.Services_ID)
            {

                var ads = await _db.ServiceAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.SubCategory)
                    .Where(a => a.Ad.Id != currentAdId && a.Ad.CategoryId == categoryId && a.Ad.Status == 1)
                    .OrderByDescending(a => a.Ad.PostDate).Take(5)
                    .Select(service => new GetServiceAdDTO
                    {
                        TypeId = typeId,
                        Id = service.Ad.Id,
                        PhoneNumber = service.Ad.PhoneNumber,
                        ServiceTypeId = service.SubCategoryId,
                        OtherServiceType = service.OtherSubCategory,
                        ServiceTypeEn_Name = service.SubCategory.En_Name,
                        ServiceTypeAr_Name = service.SubCategory.Ar_Name,
                        AgentId = service.Ad.AgentId,
                        CategoryId = service.Ad.CategoryId,
                        CategoryEnName = service.Ad.Category.En_Name,
                        CategoryArName = service.Ad.Category.Ar_Name,
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
                    }).AsNoTracking().ToListAsync();

                return ads;


            }

            else if (typeId == StaticData.Numbers_ID)
            {
                var ads = await _db.NumberAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Where(a => a.Ad.Id != currentAdId && a.Ad.CategoryId == categoryId && a.Ad.Status == 1)
                    .OrderByDescending(a => a.Ad.PostDate).Take(5)
                    .Select(number => new GetNumberAdDTO
                    {
                        TypeId = typeId,
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
                    }).AsNoTracking().ToListAsync();

                return ads;


            }

            else if (typeId == StaticData.Classifieds_ID)
            {
                var ads = await _db.ClassifiedAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.SubCategory).Include(a => a.SubType)
                    .Where(a => a.Ad.Id != currentAdId && a.Ad.CategoryId == categoryId && a.Ad.Status == 1)
                    .OrderByDescending(a => a.Ad.PostDate).Take(5)
                    .Select(classified => new GetClassifiedAdDTO
                    {
                        TypeId = typeId,
                        Id = classified.Ad.Id,
                        Price = classified.Price,
                        PhoneNumber = classified.Ad.PhoneNumber,
                        En_Age = classified.En_Age,
                        Ar_Age = classified.Ar_Age,
                        En_Brand = classified.En_Brand,
                        Ar_Brand = classified.Ar_Brand,
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
                        CategoryEnName = classified.Ad.Category.En_Name,
                        CategoryArName = classified.Ad.Category.Ar_Name,
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
                    }).AsNoTracking().ToListAsync();

                return ads;

            }

            return "";

        }

        public async Task<BaseResponse> MakeAnOffer(int userId, MakeAnOfferDTO model)
        {
            var response = new BaseResponse();

            try
            {
                if (model.Price <= 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Invalid Price";
                    return response;
                }

                var ad = await _db.Ads.Include(a => a.Pictures).FirstOrDefaultAsync(a => a.Id == model.AdId);
                var offer = new AdOffer()
                {
                    Price = (double)model.Price,
                    AdId = model.AdId,
                    UserId = userId
                };

                await _db.AdOffers.AddAsync(offer);

                await _db.SaveChangesAsync();

                var imageUrl = "";
                var Picture = ad.Pictures.OrderByDescending(p => p.MainPicture).FirstOrDefault();
                if (Picture != null)
                {
                    imageUrl = Picture.ImageURL;
                }
                if (model.TypeId == StaticData.Numbers_ID)
                {
                    var numberAd = await _db.NumberAds.Include(a => a.Ad).FirstOrDefaultAsync(a => a.AdId == model.AdId);
                    imageUrl = numberAd?.Photo;

                    var notification = new Notification
                    {
                        AdId = model.AdId,
                        Date = DateTime.Now,
                        Status = NotificationStatus.NOT_VIEWD,
                        OfferId = offer.Id,
                        ImageUrl = imageUrl == "" ? null : imageUrl,
                        UserId = ad.UserId,
                        CategoryId = ad.CategoryId,
                        En_Emirate = numberAd.En_Emirate,
                        PlateCode = numberAd.PlateCode,
                        Number = numberAd.Number,
                        Code = "",
                        En_PlateType = numberAd.En_PlateType,
                        Message= "You received a new offer on your ad"

                    };
                    await _db.Notifications.AddAsync(notification);
                }
                else
                {
                    var notification = new Notification
                    {
                        AdId = model.AdId,
                        Date = DateTime.Now,
                        Status = NotificationStatus.NOT_VIEWD,
                        OfferId = offer.Id,
                        ImageUrl = imageUrl == "" ? null : imageUrl,
                        UserId = ad.UserId,
                        CategoryId = ad.CategoryId,
                        En_Emirate = "",
                        PlateCode = "",
                        Number = 0,
                        Code = "",
                        En_PlateType = "",

                    };
                    await _db.Notifications.AddAsync(notification);
                }

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Offer Sent Sucessfully";
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }



        public async Task<SaveFiltersResponse> SaveFillters(int userId, SaveFiltersDTO savedSearchDto)
        {
            var response = new SaveFiltersResponse();

            try
            {
                var saveSearch = await _db.SavedSearch.AsNoTracking().FirstOrDefaultAsync(a => a.UserId == userId
                && a.Location == savedSearchDto.Location && a.ADCategoryId == savedSearchDto.CategoryId);

                if (saveSearch != null)
                {
                    response.IsSuccess = false;
                    response.Message = "Search already saved to your saved searches";
                    response.IsSaved = true;
                    return response;
                }

                saveSearch = new SavedSearch()
                {
                    UserId = userId,
                    ADCategoryId = savedSearchDto.CategoryId,
                    ADTypeId = savedSearchDto.TypeId,
                    Location = savedSearchDto.Location,
                    Alert = true,
                    EmailAlert = true,
                    Date = DateTime.Now

                };

                await _db.SavedSearch.AddAsync(saveSearch);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Search Was Saved Sucessfully";
                response.IsSaved = false;
                return response;
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = StaticData.ServerError_Message;
                response.IsSaved = false;
                return response;
            }
        }

        public async Task<BaseResponse> ReportAd(int userId, ReportDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var report = new Report()
                {
                    AdId = model.AdId,
                    UserId = userId,
                    Reason = model.Reason,
                    Description = model.Description,
                };

                await _db.Reports.AddAsync(report);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Report Send Successfuly";
                return response;
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddToFavorite(int userId, FavoriteAdDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var favorite = await _db.Favorites.AsNoTracking().FirstOrDefaultAsync(f => f.AdId == model.AdId && f.UserId == userId);

                if (favorite != null)
                {
                    response.IsSuccess = false;
                    response.Message = "Ad already in your favorites";
                    return response;
                }

                var favoriteAd = new FavoriteAd()
                {
                    AdId = model.AdId,
                    UserId = userId,
                };

                await _db.Favorites.AddAsync(favoriteAd);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Ad added to your favorites";
                return response;
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> RemoveFromFavorite(int userId, FavoriteAdDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var favorite = await _db.Favorites.AsNoTracking()
                    .FirstOrDefaultAsync(f => f.AdId == model.AdId && f.UserId == userId);

                if (favorite == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Ad is not in your favorite !!";
                    return response;
                }

                _db.Favorites.Remove(favorite);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Ad removed from your favorites";
                return response;
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> ApplyForJob(int userId, ApplyJobDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var cvImageUrl = "";

                if (model.CvFile != null)
                {
                    var webRootPath = _hostEnvironment.WebRootPath;

                    var folderPath = Path.Combine(webRootPath, "images");

                    cvImageUrl = await HelperFunctions.UploadImage(folderPath, model.CvFile, "ads");
                }

                var jobAppliation = new JobApplication()
                {
                    AdId = model.AdId,
                    CareerLevel = model.CareerLevel,
                    Commitment = model.Commitment,
                    CoverNote = model.CoverNote,
                    CurrentCompany = model.CurrentCompany,
                    CurrentPosition = model.CurrentPosition,
                    DefaultLanguage = model.DefaultLanguage,
                    DOB = model.DOB,
                    EducationLevel = model.EducationLevel,
                    Gender = model.Gender,
                    Nationality = model.Nationality,
                    NoticePeriod = model.NoticePeriod,
                    PhoneNumber = model.PhoneNumber,
                    VisaStatus = model.VisaStatus,
                    WorkExperience = model.WorkExperience,
                    CVImageUrl = cvImageUrl == "" ? null : cvImageUrl,
                    UserId = userId,
                };

                await _db.JobApplications.AddAsync(jobAppliation);

                await _db.SaveChangesAsync();

                var ad = await _db.Ads.Include(a => a.Pictures)
                    .Select(a => new GetNotificationAd
                    {
                        AdId = a.Id,
                        Picture = a.Pictures.OrderByDescending(p => p.MainPicture).FirstOrDefault(),
                        UserId = a.UserId,
                    }).AsNoTracking().FirstOrDefaultAsync(a => a.AdId == model.AdId);


                var notification = new Notification
                {
                    AdId = model.AdId,
                    Date = DateTime.Now,
                    Status = NotificationStatus.NOT_VIEWD,
                    JobApplicationId = jobAppliation.Id,
                    UserId = ad.UserId,
                    ImageUrl = "",
                };

                await _db.Notifications.AddAsync(notification);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Job Applied Succesfully";
                return response;
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteAd(int userId, int adId)
        {
            var response = new BaseResponse();

            try
            {
                var ad = await _db.Ads.FirstOrDefaultAsync(a => a.Id == adId && a.UserId == userId);

                if (ad == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not Found";
                    return response;
                }

                _db.Remove(ad);

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



        private class GetNotificationAd
        {
            public int? AdId { get; set; }

            public int? UserId { get; set; }

            public AdPicture Picture { get; set; }
        }



        public async Task<BaseResponse> DeleteSavedSearch(int userId, int searchId)
        {
            var response = new BaseResponse();
            try
            {
                var search = _db.SavedSearch.Where(s => s.Id == searchId && s.UserId == userId).FirstOrDefault();

                if (search == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not Found";
                    return response;
                }

                _db.SavedSearch.Remove(search);
                _db.SaveChangesAsync();


                response.IsSuccess = true;
                return response;

            }
            catch (Exception E)
            {
                response.IsSuccess = false;
                response.Message = StaticData.ServerError_Message;
                return response;
            }

        }

        public async Task<BaseResponse> DeleteAdPhoto(int id)
        {
            var response = new BaseResponse();

            try
            {
                var photo = await _db.AdPictures.FirstOrDefaultAsync(a => a.Id == id);

                if (photo == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Photo Not found";
                    return response;
                }

                _db.AdPictures.Remove(photo);

                await _db.SaveChangesAsync();

                string webRootPath = _hostEnvironment.WebRootPath;
                var imagePath = Path.Combine(webRootPath, photo.ImageURL.TrimStart('\\'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }

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

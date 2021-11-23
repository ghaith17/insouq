using insouq.EntityFramework;
using insouq.Models;
using insouq.Services.IServices;
using insouq.Shared.DTOS;
using insouq.Shared.DTOS.AdPictureDTOS;
using insouq.Shared.Utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var AdsList = _db.Ads.Where(ad => ad.Status == 2 || ad.Status == 1).Include(a=>a.Category)
                .Include(x=>x.Pictures.Where(u=>u.MainPicture == true))
                .OrderByDescending(x => x.Id).ToList();

            foreach(var ad in AdsList)
            {
                var price = getPrice(ad.Id, ad.TypeId, ad.CategoryId);
                ad.Price = (double)(price == null ? -1 : price);
            }

            return AdsList;
        }


        private double? getPrice(int AdId ,int TypeId, int categoryId)
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
                if (categoryId == StaticData.CommercialForSale_ID || categoryId == StaticData.ResidentialForSale_ID)
                {
                    return _db.PropertyAds.Where(m => m.AdId == AdId).Select(a => a.Price).FirstOrDefault();
                }

                return _db.PropertyAds.Where(m => m.AdId == AdId).Select(a => a.AnnualRent).FirstOrDefault();

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



        public async Task<bool> updateAdStatus(int adId,int status)
        {
            try
            {

                var ad = _db.Ads.Where(ad => ad.Id == adId)
                    .Include(x=>x.Category)
                    .Include(x=>x.Pictures.Where(p=>p.MainPicture==true)).FirstOrDefault();
                ad.Status = status;

                _db.SaveChanges();

                var imageUrl = "";

                var plateType = ""; 
                var emirate = ""; 
                var plateCode = ""; 
                var mobileCode = ""; 

                if(ad.TypeId == StaticData.Numbers_ID)
                {
                    var numberAd = await GetAd(adId, StaticData.Numbers_ID);

                    imageUrl = numberAd.Photo;

                    emirate = numberAd.En_Emirate;

                    plateType = numberAd.En_PlateType;

                    plateCode = numberAd.PlateCode;

                    mobileCode = numberAd.Code;
                }
                else
                {
                    imageUrl = ad.Pictures[0] == null ? null : ad.Pictures[0].ImageURL;
                }

                _db.Notifications.Add(new Notification()
                {
                    AdId = adId,
                    CategoryId = ad.CategoryId,
                    Status = NotificationStatus.NOT_VIEWD,
                    Date = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss")),
                    UserId = ad.UserId,
                    ImageUrl= imageUrl,
                    En_Emirate = emirate != "" ? emirate : null,
                    En_PlateType = plateType != "" ? plateType : null,
                    PlateCode = plateCode != "" ? plateCode : null,
                    Code = mobileCode != "" ? mobileCode : null,
                    Message= "You received a confirmed on your ad"
                });
                _db.SaveChanges();
                
                return true;
            }catch(Exception e)
            {
                return false;
            }

        }


        public async Task<List<AdPicture>> GetAdPictures(int adId)
        {
            var list = await _db.AdPictures.Where(a => a.AdId == adId).AsNoTracking().ToListAsync();

            return list;
        }


        public async Task<dynamic> GetAd(int adId, int typeId)
        {
            if (typeId == StaticData.Motors_ID)
            {
                var ad = await _db.MotorAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.SubCategory).Include(a => a.SubType)
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
                        JobTitle = job.JobTitle,
                        Pictures = job.Ad.Pictures.Select(p => new AdPictureDTO
                        {
                            Id = p.Id,
                            ImageURL = p.ImageURL,
                            MainPicture = p.MainPicture
                        }).ToList()
                    }).AsNoTracking().FirstOrDefaultAsync(a => a.Id == adId);

                return ad;


            }

            else if (typeId == StaticData.Properties_ID)
            {
                var ad = await _db.PropertyAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                    .Include(a => a.SubCategory)
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
                        CarLiftFrom = service.CarLiftFrom,
                        CarLiftTo = service.CarLiftTo,
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

    }
}
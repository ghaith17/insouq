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
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services
{
    public class MotorsService : IMotorsService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IDropDownService _dropDownService;

        public MotorsService(ApplicationDbContext db, IMapper mapper, IWebHostEnvironment hostEnvironment, IDropDownService dropDownService)
        {
            _db = db;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
            _dropDownService = dropDownService;
        }


        public async Task<UpdateMotorsDTO> GetMotorAd(int adId)
        {
            var ad = await _db.MotorAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                .Include(a => a.SubCategory).Include(a => a.SubType)
                .Where(a => a.Ad.Status == 1)
                .Select(motor => new GetMotorAdDTO
                {
                    Id = motor.Ad.Id,
                    TypeId = StaticData.Motors_ID,
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

            if (ad == null) return null;

            var dto = new UpdateMotorsDTO
            {
                AdId = ad.Id,
                Age = ad.En_Age + "-" + ad.Ar_Age,
                BodyType = ad.En_BodyType + "-" + ad.Ar_BodyType,
                Capacity = ad.En_Capacity + "-" + ad.Ar_Capacity,
                CategoryId = ad.CategoryId,
                Color = ad.En_Color + "-" + ad.Ar_Color,
                Condition = ad.En_Condition + "-" + ad.Ar_Condition,
                Description = ad.Description,
                Doors = ad.En_Doors + "-" + ad.Ar_Doors,
                EngineSize = ad.En_EngineSize + "-" + ad.Ar_EngineSize,
                FinalDriveSystem = ad.En_FinalDriveSystem + "-" + ad.Ar_FinalDriveSystem,
                FuelType = ad.En_FuelType + "-" + ad.Ar_FuelType,
                Horsepower = ad.En_Horsepower + "^" + ad.Ar_Horsepower,
                Kilometers = ad.Kilometers,
                Lat = ad.Lat,
                Length = ad.En_Length + "-" + ad.Ar_Length,
                Lng = ad.Lng,
                Location = ad.En_Location + "-" + ad.Ar_Location,
                MechanicalCondition = ad.En_MechanicalCondition + "-" + ad.Ar_MechanicalCondition,
                NameOfPart = ad.NameOfPart,
                NoOfCylinders = ad.En_NoOfCylinders + "-" + ad.Ar_NoOfCylinders,
                OtherSubCategory = ad.OtherSubCategory,
                OtherSubType = ad.OtherSubType,
                PartName = ad.En_PartName + "-" + ad.Ar_PartName,
                PhoneNumber = ad.PhoneNumber,
                Photos = ad.Pictures,
                Price = ad.Price,
                RegionalSpecs = ad.En_RegionalSpecs + "-" + ad.Ar_RegionalSpecs,
                SellerType = ad.En_SellerType + "-" + ad.Ar_SellerType,
                SteeringSide = ad.En_SteeringSide + "-" + ad.Ar_SteeringSide,
                SubCategoryId = ad.SubCategoryId,
                SubTypeId = ad.SubTypeId,
                Title = ad.Title,
                Transmission = ad.En_Transmission + "-" + ad.Ar_Transmission,
                Usage = ad.En_Usage + "-" + ad.Ar_Usage,
                Warranty = ad.Warranty,
                Wheels = ad.En_Wheels + "-" + ad.Ar_Wheels,
                Year = (int)ad.Year
            };


            if (ad.CategoryId == StaticData.UsedCars_ID || ad.CategoryId == StaticData.ExportCar_ID)
            {
                var maker = await _dropDownService.GetMotorMaker(ad.En_Maker);

                if (maker == null)
                {
                    dto.OtherMaker = ad.En_Maker;
                    dto.Maker = "others";
                }
                else
                {
                    dto.OtherMaker = null;
                    dto.Maker = ad.En_Maker + "-" + ad.Ar_Maker;
                }

                var model = await _dropDownService.GetMotorModel(ad.En_Model);

                if (model == null)
                {
                    dto.OtherModel = ad.En_Model;
                    dto.Model = "others";
                }
                else
                {
                    dto.OtherModel = null;
                    dto.Model = ad.En_Model + "-" + ad.Ar_Model;
                }

                var trim = await _dropDownService.GetMotorTrim(ad.En_Trim);

                if (trim == null)
                {
                    dto.OtherTrim = ad.En_Trim;
                    dto.Trim = "others";
                }
                else
                {
                    dto.OtherTrim = null;
                    dto.Trim = ad.En_Trim + "-" + ad.Ar_Trim;
                }
            }

            else if (ad.CategoryId == StaticData.Parts_ID)
            {
                var part = await _dropDownService.GetPart(ad.En_PartName);

                if (part == null)
                {
                    dto.OtherPartName = ad.En_PartName;
                    dto.PartName = "others";
                }
                else
                {
                    dto.OtherPartName = null;
                    dto.PartName = ad.En_PartName + "-" + ad.Ar_PartName;
                }

            }

            return dto;
        }

        public async Task<AddInitialDataResponse> AddInitialMotor(int userId, AddInitalMotor model)
        {
            var response = new AddInitialDataResponse();

            try
            {
                var en_partName = "";

                var ar_partName = "";

                if(model.OtherPartName != null)
                {
                    en_partName = model.OtherPartName;
                    ar_partName = model.OtherPartName;
                }
                else if (model.PartName != null)
                {
                    var PartNameArray = model.PartName.Split('-');
                    en_partName = PartNameArray[0].Trim();
                    ar_partName = PartNameArray[1].Trim();
                }


                var en_maker = "";
                var ar_maker = "";

                if (model.OtherMaker != null)
                {
                    en_maker = model.OtherMaker;
                    ar_maker = model.OtherMaker;
                }
                else if (model.Maker != null)
                {
                    var makerArray = model.Maker.Split('-');
                    en_maker = makerArray[0].Trim();
                    ar_maker = makerArray[1].Trim();
                }


                var en_model = "";

                var ar_model = "";

                if (model.OtherModel != null)
                {
                    en_model = model.OtherModel;
                    ar_model = model.OtherModel;
                }
                else if (model.Model != null)
                {
                    var modelArray = model.Model.Split('-');
                    en_model = modelArray[0].Trim();
                    ar_model = modelArray[1].Trim();
                }


                var en_trim = "";

                var ar_trim = "";

                if (model.OtherTrim != null)
                {
                    en_trim = model.OtherTrim;
                    ar_trim = model.OtherTrim;
                }
                else if (model.Trim != null)
                {
                    var trimArray = model.Trim.Split('-');
                    en_trim = trimArray[0].Trim();
                    ar_trim = trimArray[1].Trim();
                }


                var ad = new Ad()
                {
                    Title = model.Title,
                    PostDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    UserId = userId,
                    Status = 0,
                    CategoryId = model.CategoryId,
                    TypeId = StaticData.Motors_ID
                };


                await _db.Ads.AddAsync(ad);

                await _db.SaveChangesAsync();


                var usedCarsAd = new MotorAd()
                {
                    En_Maker = en_maker != "" ? en_maker : null,
                    Ar_Maker = ar_maker != "" ? ar_maker : null,
                    En_Model = en_model != "" ? en_model : null,
                    Ar_Model = ar_model != "" ? ar_model : null,
                    En_Trim = en_trim != "" ? en_trim : null,
                    Ar_Trim = ar_trim != "" ? ar_trim : null,
                    Year = model.Year,
                    En_PartName = en_partName != "" ? en_partName : null,
                    Ar_PartName = ar_partName != "" ? ar_partName : null,
                    SubCategoryId = model.SubCategoryId != 0 ? model.SubCategoryId : null,
                    OtherSubCategory = model.OtherSubCategory,
                    SubTypeId = model.SubTypeId != 0 ? model.SubTypeId : null,
                    OtherSubType = model.OtherSubType,
                    AdId = ad.Id,

                };

                await _db.MotorAds.AddAsync(usedCarsAd);

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


        public async Task<BaseResponse> Add(int userId, MotorsAdDTO model)
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

                var motorAd = await _db.MotorAds.Include(a => a.Ad).FirstOrDefaultAsync(a => a.AdId == model.AdId);

                var en_color = "";

                var ar_color = "";

                if (model.Color != null)
                {
                    var colorArray = model.Color.Split('-');
                    en_color = colorArray[0].Trim();
                    ar_color = colorArray[1].Trim();
                }


                var en_transmission = "";

                var ar_transmission = "";

                if (model.Transmission != null)
                {
                    var transmissionArray = model.Transmission.Split('-');
                    en_transmission = transmissionArray[0].Trim();
                    ar_transmission = transmissionArray[1].Trim();
                }


                var en_regionalSpecs = "";

                var ar_regionalSpecs = "";

                if (model.RegionalSpecs != null)
                {
                    var regionalSpecsArray = model.RegionalSpecs.Split('-');
                    en_regionalSpecs = regionalSpecsArray[0].Trim();
                    ar_regionalSpecs = regionalSpecsArray[1].Trim();
                }


                var en_bodyType = "";

                var ar_bodyType = "";

                if (model.BodyType != null)
                {
                    var bodyTypeArray = model.BodyType.Split('-');
                    en_bodyType = bodyTypeArray[0].Trim();
                    ar_bodyType = bodyTypeArray[1].Trim();
                }


                var en_fuelType = "";

                var ar_fuelType = "";

                if (model.FuelType != null)
                {
                    var fuelTypeArray = model.FuelType.Split('-');
                    en_fuelType = fuelTypeArray[0].Trim();
                    ar_fuelType = fuelTypeArray[1].Trim();
                }


                var en_condition = "";

                var ar_condition = "";

                if (model.Condition != null)
                {
                    var conditionArray = model.Condition.Split('-');
                    en_condition = conditionArray[0].Trim();
                    ar_condition = conditionArray[1].Trim();
                }


                var en_mechanicalCondition = "";

                var ar_mechanicalCondition = "";

                if (model.MechanicalCondition != null)
                {
                    var mechanicalConditionArray = model.MechanicalCondition.Split('-');
                    en_mechanicalCondition = mechanicalConditionArray[0].Trim();
                    ar_mechanicalCondition = mechanicalConditionArray[1].Trim();
                }


                var en_usage = "";

                var ar_usage = "";

                if (model.Usage != null)
                {
                    var usageArray = model.Usage.Split('-');
                    en_usage = usageArray[0].Trim();
                    ar_usage = usageArray[1].Trim();
                }

                var en_sellerType = "";

                var ar_sellerType = "";

                if (model.SellerType != null)
                {
                    var sellerTypeArray = model.SellerType.Split('-');
                    en_sellerType = sellerTypeArray[0].Trim();
                    ar_sellerType = sellerTypeArray[1].Trim();
                }

                var en_finalDriveSystem = "";

                var ar_finalDriveSystem = "";

                if (model.FinalDriveSystem != null)
                {
                    var finalDriveSystemArray = model.FinalDriveSystem.Split('-');
                    en_finalDriveSystem = finalDriveSystemArray[0].Trim();
                    ar_finalDriveSystem = finalDriveSystemArray[1].Trim();
                }

                var en_doors = "";

                var ar_doors = "";

                if (model.Doors != null)
                {
                    var doorsArray = model.Doors.Split('-');
                    en_doors = doorsArray[0].Trim();
                    ar_doors = doorsArray[1].Trim();
                }

                var en_noOfCylindes = "";

                var ar_noOfCylindes = "";

                if (model.NoOfCylinders != null)
                {
                    var noOfCylindersArray = model.NoOfCylinders.Split('-');
                    en_noOfCylindes = noOfCylindersArray[0].Trim();
                    ar_noOfCylindes = noOfCylindersArray[1].Trim();
                }

                var en_horsePower = "";

                var ar_horsePower = "";

                if (model.Horsepower != null)
                {
                    var HorsepowerArray = model.Horsepower.Split('^');
                    en_horsePower = HorsepowerArray[0].Trim();
                    ar_horsePower = HorsepowerArray[1].Trim();
                }

                var en_age = "";

                var ar_age = "";

                if (model.Age != null)
                {
                    var AgeArray = model.Age.Split('-');
                    en_age = AgeArray[0].Trim();
                    ar_age = AgeArray[1].Trim();
                }

                var en_capacity = "";

                var ar_capacity = "";

                if (model.Capacity != null)
                {
                    var CapacityArray = model.Capacity.Split('-');
                    en_capacity = CapacityArray[0].Trim();
                    ar_capacity = CapacityArray[1].Trim();
                }

                var en_engineSize = "";

                var ar_engineSize = "";

                if (model.EngineSize != null)
                {
                    var EngineSizeArray = model.EngineSize.Split('-');
                    en_engineSize = EngineSizeArray[0].Trim();
                    ar_engineSize = EngineSizeArray[1].Trim();
                }

                var en_length = "";

                var ar_length = "";

                if (model.Length != null)
                {
                    var LengthArray = model.Length.Split('-');
                    en_length = LengthArray[0].Trim();
                    ar_length = LengthArray[1].Trim();
                }

                var en_wheels = "";

                var ar_wheels = "";

                if (model.Wheels != null)
                {
                    var WheelsArray = model.Wheels.Split('-');
                    en_wheels = WheelsArray[0].Trim();
                    ar_wheels = WheelsArray[1].Trim();
                }

                var en_steeringSide = "";

                var ar_steeringSide = "";

                if (model.SteeringSide != null)
                {
                    var steeringSideArray = model.SteeringSide.Split('-');
                    en_steeringSide = steeringSideArray[0].Trim();
                    ar_steeringSide = steeringSideArray[1].Trim();
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




                category.NumberOfAds++;


                motorAd.Ad.Description = model.Description;
                motorAd.Ad.En_Location = en_location;
                motorAd.Ad.Ar_Location = ar_location;
                motorAd.Ad.Pictures = pictures;
                motorAd.Ad.Lat = model.Lat;
                motorAd.Ad.Lng = model.Lng;
                motorAd.Ad.Status = 2;
                motorAd.Ad.PhoneNumber = model.PhoneNumber;


                motorAd.En_Color = en_color != "" ? en_color : null;
                motorAd.Ar_Color = ar_color != "" ? ar_color : null;
                motorAd.Kilometers = model.Kilometers;
                motorAd.En_Doors = en_doors != "" ? en_doors : null;
                motorAd.Ar_Doors = ar_doors != "" ? ar_doors : null;
                if (model.Warranty == null)
                {
                    motorAd.Warranty = false;
                }
                else
                {
                    motorAd.Warranty = (bool)model.Warranty;
                }
                motorAd.En_Transmission = en_transmission != "" ? en_transmission : null;
                motorAd.Ar_Transmission = ar_transmission != "" ? ar_transmission : null;
                motorAd.En_RegionalSpecs = en_regionalSpecs != "" ? en_regionalSpecs : null;
                motorAd.Ar_RegionalSpecs = ar_regionalSpecs != "" ? ar_regionalSpecs : null;
                motorAd.En_BodyType = en_bodyType != "" ? en_bodyType : null;
                motorAd.Ar_BodyType = ar_bodyType != "" ? ar_bodyType : null;
                motorAd.En_FuelType = en_fuelType != "" ? en_fuelType : null;
                motorAd.Ar_FuelType = ar_fuelType != "" ? ar_fuelType : null;
                motorAd.En_NoOfCylinders = en_noOfCylindes != "" ? en_noOfCylindes : null;
                motorAd.Ar_NoOfCylinders = ar_noOfCylindes != "" ? ar_noOfCylindes : null;
                motorAd.En_Horsepower = en_horsePower != "" ? en_horsePower : null;
                motorAd.Ar_Horsepower = ar_horsePower != "" ? ar_horsePower : null;
                motorAd.En_Condition = en_condition != "" ? en_condition : null;
                motorAd.Ar_Condition = ar_condition != "" ? ar_condition : null;
                motorAd.En_MechanicalCondition = en_mechanicalCondition != "" ? en_mechanicalCondition : null;
                motorAd.Ar_MechanicalCondition = ar_mechanicalCondition != "" ? ar_mechanicalCondition : null;
                motorAd.Price = model.Price;
                motorAd.En_Age = en_age != "" ? en_age : null;
                motorAd.Ar_Age = ar_age != "" ? ar_age : null;
                motorAd.En_Capacity = en_capacity != "" ? en_capacity : null;
                motorAd.Ar_Capacity = ar_capacity != "" ? ar_capacity : null;
                motorAd.En_EngineSize = en_engineSize != "" ? en_engineSize : null;
                motorAd.Ar_EngineSize = ar_engineSize != "" ? ar_engineSize : null;
                motorAd.En_Length = en_length != "" ? en_length : null;
                motorAd.Ar_Length = ar_length != "" ? ar_length : null;
                motorAd.En_Usage = en_usage != "" ? en_usage : null;
                motorAd.Ar_Usage = ar_usage != "" ? ar_usage : null;
                motorAd.En_Wheels = en_wheels != "" ? en_wheels : null;
                motorAd.Ar_Wheels = ar_wheels != "" ? ar_wheels : null;
                motorAd.En_SellerType = en_sellerType != "" ? en_sellerType : null;
                motorAd.Ar_SellerType = ar_sellerType != "" ? ar_sellerType : null;
                motorAd.En_FinalDriveSystem = en_finalDriveSystem != "" ? en_finalDriveSystem : null;
                motorAd.Ar_FinalDriveSystem = ar_finalDriveSystem != "" ? ar_finalDriveSystem : null;
                motorAd.En_SteeringSide = en_steeringSide != "" ? en_steeringSide : null;
                motorAd.Ar_SteeringSide = ar_steeringSide != "" ? ar_steeringSide : null;
                motorAd.NameOfPart = model.NameOfPart;


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


        public async Task<BaseResponse> Update(int userId, UpdateMotorsDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var motorAd = await _db.MotorAds.Include(a => a.Ad).Include(a => a.Ad.Pictures)
                    .FirstOrDefaultAsync(a => a.AdId == model.AdId && a.Ad.UserId == userId);

                if (motorAd == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not Found";
                    return response;
                }

                var en_partName = "";

                var ar_partName = "";

                if (model.OtherPartName != null)
                {
                    en_partName = model.OtherPartName;
                    ar_partName = model.OtherPartName;
                }
                else if (model.PartName != null)
                {
                    var PartNameArray = model.PartName.Split('-');
                    en_partName = PartNameArray[0].Trim();
                    ar_partName = PartNameArray[1].Trim();
                }


                var en_maker = "";
                var ar_maker = "";

                if (model.OtherMaker != null)
                {
                    en_maker = model.OtherMaker;
                    ar_maker = model.OtherMaker;
                }
                else if (model.Maker != null)
                {
                    var makerArray = model.Maker.Split('-');
                    en_maker = makerArray[0].Trim();
                    ar_maker = makerArray[1].Trim();
                }


                var en_model = "";

                var ar_model = "";

                if (model.OtherModel != null)
                {
                    en_model = model.OtherModel;
                    ar_model = model.OtherModel;
                }
                else if (model.Model != null)
                {
                    var modelArray = model.Model.Split('-');
                    en_model = modelArray[0].Trim();
                    ar_model = modelArray[1].Trim();
                }


                var en_trim = "";

                var ar_trim = "";

                if (model.OtherTrim != null)
                {
                    en_trim = model.OtherTrim;
                    ar_trim = model.OtherTrim;
                }
                else if (model.Trim != null)
                {
                    var trimArray = model.Trim.Split('-');
                    en_trim = trimArray[0].Trim();
                    ar_trim = trimArray[1].Trim();
                }


                var en_color = "";

                var ar_color = "";

                if (model.Color != null)
                {
                    var colorArray = model.Color.Split('-');
                    en_color = colorArray[0].Trim();
                    ar_color = colorArray[1].Trim();
                }


                var en_transmission = "";

                var ar_transmission = "";

                if (model.Transmission != null)
                {
                    var transmissionArray = model.Transmission.Split('-');
                    en_transmission = transmissionArray[0].Trim();
                    ar_transmission = transmissionArray[1].Trim();
                }


                var en_regionalSpecs = "";

                var ar_regionalSpecs = "";

                if (model.RegionalSpecs != null)
                {
                    var regionalSpecsArray = model.RegionalSpecs.Split('-');
                    en_regionalSpecs = regionalSpecsArray[0].Trim();
                    ar_regionalSpecs = regionalSpecsArray[1].Trim();
                }


                var en_bodyType = "";

                var ar_bodyType = "";

                if (model.BodyType != null)
                {
                    var bodyTypeArray = model.BodyType.Split('-');
                    en_bodyType = bodyTypeArray[0].Trim();
                    ar_bodyType = bodyTypeArray[1].Trim();
                }


                var en_fuelType = "";

                var ar_fuelType = "";

                if (model.FuelType != null)
                {
                    var fuelTypeArray = model.FuelType.Split('-');
                    en_fuelType = fuelTypeArray[0].Trim();
                    ar_fuelType = fuelTypeArray[1].Trim();
                }


                var en_condition = "";

                var ar_condition = "";

                if (model.Condition != null)
                {
                    var conditionArray = model.Condition.Split('-');
                    en_condition = conditionArray[0].Trim();
                    ar_condition = conditionArray[1].Trim();
                }


                var en_mechanicalCondition = "";

                var ar_mechanicalCondition = "";

                if (model.MechanicalCondition != null)
                {
                    var mechanicalConditionArray = model.MechanicalCondition.Split('-');
                    en_mechanicalCondition = mechanicalConditionArray[0].Trim();
                    ar_mechanicalCondition = mechanicalConditionArray[1].Trim();
                }


                var en_usage = "";

                var ar_usage = "";

                if (model.Usage != null)
                {
                    var usageArray = model.Usage.Split('-');
                    en_usage = usageArray[0].Trim();
                    ar_usage = usageArray[1].Trim();
                }

                var en_sellerType = "";

                var ar_sellerType = "";

                if (model.SellerType != null)
                {
                    var sellerTypeArray = model.SellerType.Split('-');
                    en_sellerType = sellerTypeArray[0].Trim();
                    ar_sellerType = sellerTypeArray[1].Trim();
                }

                var en_finalDriveSystem = "";

                var ar_finalDriveSystem = "";

                if (model.FinalDriveSystem != null)
                {
                    var finalDriveSystemArray = model.FinalDriveSystem.Split('-');
                    en_finalDriveSystem = finalDriveSystemArray[0].Trim();
                    ar_finalDriveSystem = finalDriveSystemArray[1].Trim();
                }

                var en_doors = "";

                var ar_doors = "";

                if (model.Doors != null)
                {
                    var doorsArray = model.Doors.Split('-');
                    en_doors = doorsArray[0].Trim();
                    ar_doors = doorsArray[1].Trim();
                }

                var en_noOfCylindes = "";

                var ar_noOfCylindes = "";

                if (model.NoOfCylinders != null)
                {
                    var noOfCylindersArray = model.NoOfCylinders.Split('-');
                    en_noOfCylindes = noOfCylindersArray[0].Trim();
                    ar_noOfCylindes = noOfCylindersArray[1].Trim();
                }

                var en_horsePower = "";

                var ar_horsePower = "";

                if (model.Horsepower != null)
                {
                    var HorsepowerArray = model.Horsepower.Split('^');
                    en_horsePower = HorsepowerArray[0].Trim();
                    ar_horsePower = HorsepowerArray[1].Trim();
                }

                var en_age = "";

                var ar_age = "";

                if (model.Age != null)
                {
                    var AgeArray = model.Age.Split('-');
                    en_age = AgeArray[0].Trim();
                    ar_age = AgeArray[1].Trim();
                }

                var en_capacity = "";

                var ar_capacity = "";

                if (model.Capacity != null)
                {
                    var CapacityArray = model.Capacity.Split('-');
                    en_capacity = CapacityArray[0].Trim();
                    ar_capacity = CapacityArray[1].Trim();
                }

                var en_engineSize = "";

                var ar_engineSize = "";

                if (model.EngineSize != null)
                {
                    var EngineSizeArray = model.EngineSize.Split('-');
                    en_engineSize = EngineSizeArray[0].Trim();
                    ar_engineSize = EngineSizeArray[1].Trim();
                }

                var en_length = "";

                var ar_length = "";

                if (model.Length != null)
                {
                    var LengthArray = model.Length.Split('-');
                    en_length = LengthArray[0].Trim();
                    ar_length = LengthArray[1].Trim();
                }

                var en_wheels = "";

                var ar_wheels = "";

                if (model.Wheels != null)
                {
                    var WheelsArray = model.Wheels.Split('-');
                    en_wheels = WheelsArray[0].Trim();
                    ar_wheels = WheelsArray[1].Trim();
                }

                var en_steeringSide = "";

                var ar_steeringSide = "";

                if (model.SteeringSide != null)
                {
                    var steeringSideArray = model.SteeringSide.Split('-');
                    en_steeringSide = steeringSideArray[0].Trim();
                    ar_steeringSide = steeringSideArray[1].Trim();
                }

                var locationArray = model.Location.Split('-');

                var en_location = locationArray[0].Trim();

                var ar_location = locationArray[1].Trim();


                if (!string.IsNullOrEmpty(model.ImagesToDelete))
                {
                    model.ImagesToDelete = model.ImagesToDelete.TrimEnd(',');

                    var imagesToDelete = model.ImagesToDelete.Split(",");

                    if (motorAd.Ad.Pictures.Count == imagesToDelete.Length && model.Pictures.Count == 0)
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

                var oldAdPictures = motorAd.Ad.Pictures.ToList();

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
                                AdId = motorAd.AdId,
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


                motorAd.Ad.Title = model.Title;
                motorAd.Ad.Description = model.Description;
                motorAd.Ad.En_Location = en_location;
                motorAd.Ad.Ar_Location = ar_location;
                motorAd.Ad.LastUpdatedDate = DateTime.Now;
                motorAd.Ad.Lat = model.Lat;
                motorAd.Ad.Lng = model.Lng;
                motorAd.Ad.PhoneNumber = model.PhoneNumber;


                motorAd.En_Maker = en_maker != "" ? en_maker : null;
                motorAd.Ar_Maker = ar_maker != "" ? ar_maker : null;
                motorAd.En_Model = en_model != "" ? en_model : null;
                motorAd.Ar_Model = ar_model != "" ? ar_model : null;
                motorAd.En_Trim = en_trim != "" ? en_trim : null;
                motorAd.Ar_Trim = ar_trim != "" ? ar_trim : null;
                motorAd.Year = model.Year;
                motorAd.En_PartName = en_partName != "" ? en_partName : null;
                motorAd.Ar_PartName = ar_partName != "" ? ar_partName : null;
                motorAd.SubCategoryId = model.SubCategoryId != 0 ? model.SubCategoryId : null;
                motorAd.OtherSubCategory = model.OtherSubCategory;
                motorAd.SubTypeId = model.SubTypeId != 0 ? model.SubTypeId : null;
                motorAd.OtherSubType = model.OtherSubType;
                motorAd.En_Color = en_color != "" ? en_color : null;
                motorAd.Ar_Color = ar_color != "" ? ar_color : null;
                motorAd.Kilometers = model.Kilometers;
                motorAd.En_Doors = en_doors != "" ? en_doors : null;
                motorAd.Ar_Doors = ar_doors != "" ? ar_doors : null;
                if (model.Warranty == null)
                {
                    motorAd.Warranty = false;
                }
                else
                {
                    motorAd.Warranty = (bool)model.Warranty;
                }
                motorAd.En_Transmission = en_transmission != "" ? en_transmission : null;
                motorAd.Ar_Transmission = ar_transmission != "" ? ar_transmission : null;
                motorAd.En_RegionalSpecs = en_regionalSpecs != "" ? en_regionalSpecs : null;
                motorAd.Ar_RegionalSpecs = ar_regionalSpecs != "" ? ar_regionalSpecs : null;
                motorAd.En_BodyType = en_bodyType != "" ? en_bodyType : null;
                motorAd.Ar_BodyType = ar_bodyType != "" ? ar_bodyType : null;
                motorAd.En_FuelType = en_fuelType != "" ? en_fuelType : null;
                motorAd.Ar_FuelType = ar_fuelType != "" ? ar_fuelType : null;
                motorAd.En_NoOfCylinders = en_noOfCylindes != "" ? en_noOfCylindes : null;
                motorAd.Ar_NoOfCylinders = ar_noOfCylindes != "" ? ar_noOfCylindes : null;
                motorAd.En_Horsepower = en_horsePower != "" ? en_horsePower : null;
                motorAd.Ar_Horsepower = ar_horsePower != "" ? ar_horsePower : null;
                motorAd.En_Condition = en_condition != "" ? en_condition : null;
                motorAd.Ar_Condition = ar_condition != "" ? ar_condition : null;
                motorAd.En_MechanicalCondition = en_mechanicalCondition != "" ? en_mechanicalCondition : null;
                motorAd.Ar_MechanicalCondition = ar_mechanicalCondition != "" ? ar_mechanicalCondition : null;
                motorAd.Price = model.Price;
                motorAd.En_Age = en_age != "" ? en_age : null;
                motorAd.Ar_Age = ar_age != "" ? ar_age : null;
                motorAd.En_Capacity = en_capacity != "" ? en_capacity : null;
                motorAd.Ar_Capacity = ar_capacity != "" ? ar_capacity : null;
                motorAd.En_EngineSize = en_engineSize != "" ? en_engineSize : null;
                motorAd.Ar_EngineSize = ar_engineSize != "" ? ar_engineSize : null;
                motorAd.En_Length = en_length != "" ? en_length : null;
                motorAd.Ar_Length = ar_length != "" ? ar_length : null;
                motorAd.En_Usage = en_usage != "" ? en_usage : null;
                motorAd.Ar_Usage = ar_usage != "" ? ar_usage : null;
                motorAd.En_Wheels = en_wheels != "" ? en_wheels : null;
                motorAd.Ar_Wheels = ar_wheels != "" ? ar_wheels : null;
                motorAd.En_SellerType = en_sellerType != "" ? en_sellerType : null;
                motorAd.Ar_SellerType = ar_sellerType != "" ? ar_sellerType : null;
                motorAd.En_FinalDriveSystem = en_finalDriveSystem != "" ? en_finalDriveSystem : null;
                motorAd.Ar_FinalDriveSystem = ar_finalDriveSystem != "" ? ar_finalDriveSystem : null;
                motorAd.En_SteeringSide = en_steeringSide != "" ? en_steeringSide : null;
                motorAd.Ar_SteeringSide = ar_steeringSide != "" ? ar_steeringSide : null;
                motorAd.NameOfPart = model.NameOfPart;

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

        public async Task<List<GetMotorAdDTO>> FilterUsedCars(UsedCarsFilter model)
        {
            var en_maker = "";
            var en_model = "";
            var en_Trim = "";
            var en_color = "";
            var en_regionalSpeces = "";
            var en_fuelType = "";
            var en_location = "";
            var en_horsepower = "";


            if (!string.IsNullOrEmpty(model.Maker))
            {
                en_maker = model.Maker.Split('-')[0].Trim();
            }
            if (!string.IsNullOrEmpty(model.Model))
            {
                en_model = model.Model.Split('-')[0].Trim();
            }
            if (!string.IsNullOrEmpty(model.Trim))
            {
                en_Trim = model.Trim.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.Color))
            {
                en_color = model.Color.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.RegionalSpeces))
            {
                en_regionalSpeces = model.RegionalSpeces.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.FuelType))
            {
                en_fuelType = model.FuelType.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.Horsepower))
            {
                en_horsepower = model.Horsepower.Split('^')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.Location))
            {
                en_location = model.Location.Split('-')[0].Trim();
            }


            var query = _db.MotorAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.User)
                .Where(a => a.Ad.Status == 1 && a.Ad.CategoryId == model.CategoryId && a.Price >= model.FromPrice && a.Price <= model.ToPrice &&
                a.Kilometers >= model.FromKilometers && a.Kilometers <= model.ToKilometers &&
                a.Year >= model.FromYear && a.Year <= model.ToYear && a.Warranty == model.Warranty);

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
                query = query.OrderBy(m => m.Price);
            }

            if (!string.IsNullOrEmpty(model.Keyword))
            {
                query = query.Where(a => a.Ad.Title.Contains(model.Keyword));
            }

            if (en_maker != "")
            {
                query = query.Where(a => a.En_Maker == en_maker);
            }

            if (en_model != "")
            {
                query = query.Where(a => a.En_Model == en_model);
            }

            if (en_Trim != "")
            {
                query = query.Where(a => a.En_Trim == en_Trim);
            }

            if (en_color != "")
            {
                query = query.Where(a => a.En_Color == en_color);
            }

            if (en_regionalSpeces != "")
            {
                query = query.Where(a => a.En_RegionalSpecs == en_regionalSpeces);
            }

            if (en_fuelType != "")
            {
                query = query.Where(a => a.En_FuelType == en_fuelType);
            }

            if (en_horsepower != "")
            {
                query = query.Where(a => a.En_Horsepower == en_horsepower);
            }

            if (en_location != "")
            {
                query = query.Where(a => a.Ad.En_Location == en_location);
            }

            var motorAds = await query.Select(motor => new GetMotorAdDTO
            {
                Id = motor.Ad.Id,
                TypeId = motor.Ad.TypeId,
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
                Pictures = motor.Ad.Pictures.Select(p => new AdPictureDTO
                {
                    Id = p.Id,
                    ImageURL = p.ImageURL,
                    MainPicture = p.MainPicture

                }).OrderByDescending(p => p.MainPicture).ToList(),
                PostDate = motor.Ad.PostDate,
                Title = motor.Ad.Title,
                Status = motor.Ad.Status
            }
            ).AsNoTracking().ToListAsync();


            return motorAds;
        }

        public async Task<List<GetMotorAdDTO>> FilterBoats(BoatFilters model)
        {
            var en_usage = "";
            var en_location = "";
            var en_age = "";


            if (!string.IsNullOrEmpty(model.Usage))
            {
                en_usage = model.Usage.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.Age))
            {
                en_age = model.Age.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.Location))
            {
                en_location = model.Location.Split('-')[0].Trim();
            }


            var query = _db.MotorAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.User)
                .Where(a => a.Ad.Status == 1 && a.Ad.CategoryId == model.CategoryId && a.Price >= model.FromPrice && a.Price <= model.ToPrice &&
                a.Warranty == model.Warranty);

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
                query = query.OrderBy(m => m.Price);
            }


            if (!string.IsNullOrEmpty(model.Keyword))
            {
                query = query.Where(a => a.Ad.Title.Contains(model.Keyword));
            }

            if (en_usage != "")
            {
                query = query.Where(a => a.En_Usage == en_usage);
            }

            if (en_age != "")
            {
                query = query.Where(a => a.En_Age == en_age);
            }

            if (en_location != "")
            {
                query = query.Where(a => a.Ad.En_Location == en_location);
            }

            var motorAds = await query.Select(motor => new GetMotorAdDTO
            {
                Id = motor.Ad.Id,
                TypeId = motor.Ad.TypeId,
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
                Pictures = motor.Ad.Pictures.Select(p => new AdPictureDTO
                {
                    Id = p.Id,
                    ImageURL = p.ImageURL,
                    MainPicture = p.MainPicture

                }).OrderByDescending(p => p.MainPicture).ToList(),
                PostDate = motor.Ad.PostDate,
                Title = motor.Ad.Title,
                Status = motor.Ad.Status
            }
            ).AsNoTracking().ToListAsync();


            return motorAds;

        }

        public async Task<List<GetMotorAdDTO>> FilterMachinaries(MachinaryFilters model)
        {
            var en_maker = "";
            var en_model = "";
            var en_fuelType = "";
            var en_location = "";
            var en_horsepower = "";
            var en_capacity = "";


            if (!string.IsNullOrEmpty(model.Maker))
            {
                en_maker = model.Maker.Split('-')[0].Trim();
            }
            if (!string.IsNullOrEmpty(model.Model))
            {
                en_model = model.Model.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.FuelType))
            {
                en_fuelType = model.FuelType.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.Horsepower))
            {
                en_horsepower = model.Horsepower.Split('^')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.Capacity))
            {
                en_capacity = model.Capacity.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.Location))
            {
                en_location = model.Location.Split('-')[0].Trim();
            }


            var query = _db.MotorAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.User)
                .Where(a => a.Ad.Status == 1 && a.Ad.CategoryId == model.CategoryId && a.Price >= model.FromPrice && a.Price <= model.ToPrice &&
                a.Kilometers >= model.FromKilometers && a.Kilometers <= model.ToKilometers &&
                a.Year >= model.FromYear && a.Year <= model.ToYear && a.Warranty == model.Warranty);

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
                query = query.OrderBy(m => m.Price);
            }

            if (!string.IsNullOrEmpty(model.Keyword))
            {
                query = query.Where(a => a.Ad.Title.Contains(model.Keyword));
            }

            if (en_maker != "")
            {
                query = query.Where(a => a.En_Maker == en_maker);
            }

            if (en_model != "")
            {
                query = query.Where(a => a.En_Model == en_model);
            }

            if (en_fuelType != "")
            {
                query = query.Where(a => a.En_FuelType == en_fuelType);
            }

            if (en_horsepower != "")
            {
                query = query.Where(a => a.En_Horsepower == en_horsepower);
            }

            if (en_capacity != "")
            {
                query = query.Where(a => a.En_Capacity == en_capacity);
            }

            if (en_location != "")
            {
                query = query.Where(a => a.Ad.En_Location == en_location);
            }

            var motorAds = await query.Select(motor => new GetMotorAdDTO
            {
                Id = motor.Ad.Id,
                TypeId = motor.Ad.TypeId,
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
                Pictures = motor.Ad.Pictures.Select(p => new AdPictureDTO
                {
                    Id = p.Id,
                    ImageURL = p.ImageURL,
                    MainPicture = p.MainPicture

                }).OrderByDescending(p => p.MainPicture).ToList(),
                PostDate = motor.Ad.PostDate,
                Title = motor.Ad.Title,
                Status = motor.Ad.Status
            }
            ).AsNoTracking().ToListAsync();


            return motorAds;
        }

        public async Task<List<GetMotorAdDTO>> FilterParts(PartFilters model)
        {
            var en_maker = "";
            var en_model = "";
            var en_location = "";


            if (!string.IsNullOrEmpty(model.Maker))
            {
                en_maker = model.Maker.Split('-')[0].Trim();
            }
            if (!string.IsNullOrEmpty(model.Model))
            {
                en_model = model.Model.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.Location))
            {
                en_location = model.Location.Split('-')[0].Trim();
            }


            var query = _db.MotorAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.User)
                .Where(a => a.Ad.Status == 1 && a.Ad.CategoryId == model.CategoryId && a.Price >= model.FromPrice && a.Price <= model.ToPrice);

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
                query = query.OrderBy(m => m.Price);
            }

            if (!string.IsNullOrEmpty(model.Keyword))
            {
                query = query.Where(a => a.Ad.Title.Contains(model.Keyword));
            }


            if (en_maker != "")
            {
                query = query.Where(a => a.En_Maker == en_maker);
            }

            if (en_model != "")
            {
                query = query.Where(a => a.En_Model == en_model);
            }

            if (en_location != "")
            {
                query = query.Where(a => a.Ad.En_Location == en_location);
            }

            var motorAds = await query.Select(motor => new GetMotorAdDTO
            {
                Id = motor.Ad.Id,
                TypeId = motor.Ad.TypeId,
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
                Pictures = motor.Ad.Pictures.Select(p => new AdPictureDTO
                {
                    Id = p.Id,
                    ImageURL = p.ImageURL,
                    MainPicture = p.MainPicture

                }).OrderByDescending(p => p.MainPicture).ToList(),
                PostDate = motor.Ad.PostDate,
                Title = motor.Ad.Title,
                Status = motor.Ad.Status
            }
            ).AsNoTracking().ToListAsync();


            return motorAds;
        }

        public async Task<List<GetMotorAdDTO>> FilterBikes(BikeFilters model)
        {
            var en_maker = "";
            var en_model = "";
            var en_Trim = "";
            var en_color = "";
            var en_usage = "";
            var en_engineSize = "";
            var en_location = "";


            if (!string.IsNullOrEmpty(model.Maker))
            {
                en_maker = model.Maker.Split('-')[0].Trim();
            }
            if (!string.IsNullOrEmpty(model.Model))
            {
                en_model = model.Model.Split('-')[0].Trim();
            }
            if (!string.IsNullOrEmpty(model.Trim))
            {
                en_Trim = model.Trim.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.Color))
            {
                en_color = model.Color.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.Usage))
            {
                en_usage = model.Usage.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.EngineSize))
            {
                en_engineSize = model.EngineSize.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.Location))
            {
                en_location = model.Location.Split('-')[0].Trim();
            }


            var query = _db.MotorAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.User)
                .Where(a => a.Ad.Status == 1 && a.Ad.CategoryId == model.CategoryId && a.Price >= model.FromPrice && a.Price <= model.ToPrice &&
                a.Kilometers >= model.FromKilometers && a.Kilometers <= model.ToKilometers &&
                a.Year >= model.FromYear && a.Year <= model.ToYear && a.Warranty == model.Warranty);

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
                query = query.OrderBy(m => m.Price);
            }

            if (!string.IsNullOrEmpty(model.Keyword))
            {
                query = query.Where(a => a.Ad.Title.Contains(model.Keyword));
            }

            if (en_maker != "")
            {
                query = query.Where(a => a.En_Maker == en_maker);
            }

            if (en_model != "")
            {
                query = query.Where(a => a.En_Model == en_model);
            }

            if (en_Trim != "")
            {
                query = query.Where(a => a.En_Trim == en_Trim);
            }

            if (en_color != "")
            {
                query = query.Where(a => a.En_Color == en_color);
            }

            if (en_usage != "")
            {
                query = query.Where(a => a.En_Usage == en_usage);
            }

            if (en_engineSize != "")
            {
                query = query.Where(a => a.En_EngineSize == en_engineSize);
            }

            if (en_location != "")
            {
                query = query.Where(a => a.Ad.En_Location == en_location);
            }

            var motorAds = await query.Select(motor => new GetMotorAdDTO
            {
                Id = motor.Ad.Id,
                TypeId = motor.Ad.TypeId,
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
                Pictures = motor.Ad.Pictures.Select(p => new AdPictureDTO
                {
                    Id = p.Id,
                    ImageURL = p.ImageURL,
                    MainPicture = p.MainPicture

                }).OrderByDescending(p => p.MainPicture).ToList(),
                PostDate = motor.Ad.PostDate,
                Title = motor.Ad.Title,
                Status = motor.Ad.Status
            }
            ).AsNoTracking().ToListAsync();


            return motorAds;
        }

        public async Task<List<GetMotorAdDTO>> FilterScraps(ScrapFilters model)
        {
            var en_maker = "";
            var en_model = "";
            var en_Trim = "";
            var en_color = "";
            var en_location = "";


            if (!string.IsNullOrEmpty(model.Maker))
            {
                en_maker = model.Maker.Split('-')[0].Trim();
            }
            if (!string.IsNullOrEmpty(model.Model))
            {
                en_model = model.Model.Split('-')[0].Trim();
            }
            if (!string.IsNullOrEmpty(model.Trim))
            {
                en_Trim = model.Trim.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.Color))
            {
                en_color = model.Color.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.Location))
            {
                en_location = model.Location.Split('-')[0].Trim();
            }


            var query = _db.MotorAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.User)
                .Where(a => a.Ad.Status == 1 && a.Ad.CategoryId == model.CategoryId && a.Price >= model.FromPrice && a.Price <= model.ToPrice &&
                a.Year >= model.FromYear && a.Year <= model.ToYear);

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
                query = query.OrderBy(m => m.Price);
            }

            if (!string.IsNullOrEmpty(model.Keyword))
            {
                query = query.Where(a => a.Ad.Title.Contains(model.Keyword));
            }

            if (en_maker != "")
            {
                query = query.Where(a => a.En_Maker == en_maker);
            }

            if (en_model != "")
            {
                query = query.Where(a => a.En_Model == en_model);
            }

            if (en_Trim != "")
            {
                query = query.Where(a => a.En_Trim == en_Trim);
            }

            if (en_color != "")
            {
                query = query.Where(a => a.En_Color == en_color);
            }

            if (en_location != "")
            {
                query = query.Where(a => a.Ad.En_Location == en_location);
            }

            var motorAds = await query.Select(motor => new GetMotorAdDTO
            {
                Id = motor.Ad.Id,
                TypeId = motor.Ad.TypeId,
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
                Pictures = motor.Ad.Pictures.Select(p => new AdPictureDTO
                {
                    Id = p.Id,
                    ImageURL = p.ImageURL,
                    MainPicture = p.MainPicture

                }).OrderByDescending(p => p.MainPicture).ToList(),
                PostDate = motor.Ad.PostDate,
                Title = motor.Ad.Title,
                Status = motor.Ad.Status
            }
            ).AsNoTracking().ToListAsync();


            return motorAds;
        }

        public async Task<List<GetMotorAdDTO>> FilterMotors(MotorFilters model)
        {

            var en_maker = "";
            var en_model = "";
            var en_Trim = "";
            var en_location = "";
            var en_horsepower = "";
            var en_age = "";
            var en_usage = "";
            var en_partName = "";


            if (!string.IsNullOrEmpty(model.Maker))
            {
                en_maker = model.Maker.Split('-')[0].Trim();
            }
            if (!string.IsNullOrEmpty(model.Model))
            {
                en_model = model.Model.Split('-')[0].Trim();
            }
            if (!string.IsNullOrEmpty(model.Trim))
            {
                en_Trim = model.Trim.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.Horsepower))
            {
                en_horsepower = model.Horsepower.Split('^')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.Age))
            {
                en_age = model.Age.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.Usage))
            {
                en_usage = model.Usage.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.PartName))
            {
                en_partName = model.PartName.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.Location))
            {
                en_location = model.Location.Split('-')[0].Trim();
            }

            var query = _db.MotorAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.User)
                .Where(a => a.Ad.Status == 1 && a.Ad.CategoryId == model.CategoryId && a.Price >= model.FromPrice && a.Price <= model.ToPrice);


            if (model.FromYear != null && model.ToYear != null)
            {
                query = query.Where(a => a.Year >= model.FromYear && a.Year <= model.ToYear);
            }

            if (model.FromKilometers != null && model.ToKilometers != null)
            {
                query = query.Where(a => a.Kilometers >= model.FromKilometers && a.Kilometers <= model.ToKilometers);
            }

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

            if (model.Warranty != null)
            {
                query = query.Where(a => a.Warranty == model.Warranty);
            }

            if (en_maker != "")
            {
                query = query.Where(a => a.En_Maker == en_maker);
            }

            if (en_model != "")
            {
                query = query.Where(a => a.En_Model == en_model);
            }

            if (en_Trim != "")
            {
                query = query.Where(a => a.En_Trim == en_Trim);
            }

            if (en_horsepower != "")
            {
                query = query.Where(a => a.En_Horsepower == en_horsepower);
            }

            if (en_age != "")
            {
                query = query.Where(a => a.En_Age == en_age);
            }

            if (en_usage != "")
            {
                query = query.Where(a => a.En_Usage == en_usage);
            }


            if (en_partName != "")
            {
                query = query.Where(a => a.En_PartName == en_partName);
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

            var motorAds = await query.Select(motor => new GetMotorAdDTO
            {
                Id = motor.Ad.Id,
                TypeId = motor.Ad.TypeId,
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
            }
            ).AsNoTracking().ToListAsync();


            return motorAds;
        }


        public async Task UploadImage(IFormFile file)
        {
            var webRootPath = _hostEnvironment.ContentRootPath;

            var folderPath = Path.Combine(webRootPath, "testimg");

            var imageUrl = await HelperFunctions.UploadImage(folderPath, file, "ads");
        }
    }
}

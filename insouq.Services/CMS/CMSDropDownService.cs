using insouq.EntityFramework;
using insouq.Models.Dropdownlists;
using insouq.Services.IServices;
using insouq.Services.IServices.CMS;
using insouq.Shared.DTOS.CMS;
using insouq.Shared.Responses;
using insouq.Shared.Utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services.CMS
{
    public class CMSDropDownService : ICMSDropDownService
    {
        private readonly ApplicationDbContext _db;

        public CMSDropDownService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<BaseResponse> AddOperator(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLOperator()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLOperators.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateOperator(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLOperators.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteOperator(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLOperators.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddNumberPlan(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLNumberPlan()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLNumberPlans.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateNumberPlan(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLNumberPlans.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteNumberPlan(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLNumberPlans.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddMobileCode(RelationValueDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLMobileNumberCode()
                {
                    Value = model.Value,
                    OperatorId = model.ParentId,
                };

                _db.DLMobileNumberCodes.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateMobileCode(RelationValueDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLMobileNumberCodes.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Value = model.Value;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteMobileCode(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLMobileNumberCodes.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddPlateCode(RelationValueDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLPlateCode()
                {
                    Value = model.Value,
                    PlateTypeId = model.ParentId,
                };

                _db.DLPlateCodes.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdatePlateCode(RelationValueDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLPlateCodes.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Value = model.Value;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeletePlateCode(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLPlateCodes.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddPlateType(RelationTextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLPlateType()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle,
                    EmirateId = model.ParentId
                };

                _db.DLPlateTypes.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdatePlateType(RelationTextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLPlateTypes.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeletePlateType(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLPlateTypes.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddEmirate(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLEmirate()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLEmirates.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateEmirate(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLEmirates.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteEmirate(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLEmirates.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<List<DLAge>> GetAllAge(int categoryId)
        {
            var list = await _db.DLAges.Include(l => l.Category).Where(l => l.CategoryId == categoryId).AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLBathooms>> GetAllBathooms()
        {
            var list = await _db.DLBathooms.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLBedrooms>> GetAllBedrooms()
        {
            var list = await _db.DLBedrooms.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLBodyType>> GetAllBodyType()
        {
            var list = await _db.DLBodyTypes.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLNumberPlan>> GetAllNumberPlans()
        {
            var list = await _db.DLNumberPlans.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLCapacity>> GetAllCapacity()
        {
            var list = await _db.DLCapacities.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLCareerLevel>> GetAllCareerLevel()
        {
            var list = await _db.DLCareerLevels.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLColor>> GetAllColor()
        {
            var list = await _db.DLColors.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLCommitment>> GetAllCommitment()
        {
            var list = await _db.DLCommitments.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLCompanyIndustry>> GetAllCompanyIndustry()
        {
            var list = await _db.DLCompanyIndustries.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLCompanySize>> GetAllCompanySize()
        {
            var list = await _db.DLCompanySizes.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLCondition>> GetAllCondition(int categoryId)
        {
            var list = await _db.DLConditions.Include(l => l.Category).Where(l => l.CategoryId == categoryId).AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLCurrentNetwork>> GetAllCurrentNetwork()
        {
            var list = await _db.DLCurrentNetworks.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLDoor>> GetAllDoor()
        {
            var list = await _db.DLDoors.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLEducationLevel>> GetAllEducationLevel()
        {
            var list = await _db.DLEducationLevels.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLEmirate>> GetAllEmirate()
        {
            var list = await _db.DLEmirates.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLEmploymentType>> GetAllEmploymentType()
        {
            var list = await _db.DLEmploymentTypes.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLEngineSize>> GetAllEngineSize()
        {
            var list = await _db.DLEngineSizes.AsNoTracking().ToListAsync();

            return list;
        }

        //public async Task<List<DLEngineSize>> GetAllEngineSizeByMakerId(int makerId)
        //{
        //    var list = await _db.DLEngineSizes.Where(l => l.MakerId == makerId).AsNoTracking().ToListAsync();

        //    return list;
        //} 

        //public async Task<List<DLEngineSize>> GetAllEngineSizeByMaker(string maker)
        //{
        //    var makerArray = maker.Split('-');

        //    var en_maker = makerArray[0];

        //    var ar_maker = makerArray[1];

        //    var list = await _db.DLEngineSizes.Include(l => l.Maker)
        //        .Where(l => l.Maker.En_Text == en_maker || l.Maker.Ar_Text == ar_maker).AsNoTracking().ToListAsync();

        //    return list;
        //}


        public async Task<List<DLFuelType>> GetAllFuelType()
        {
            var list = await _db.DLFuelTypes.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLFurnishing>> GetAllFurnishing()
        {
            var list = await _db.DLFurnishings.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLHorsepower>> GetAllHorsepower(int categoryId)
        {
            var list = await _db.DLHorsepowers.Include(l => l.Category).Where(l => l.CategoryId == categoryId).AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLJobType>> GetAllJobType()
        {
            var list = await _db.DLJobTypes.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<DLJobType> GetJobType(string jobType)
        {
            var JobType = await _db.DLJobTypes.AsNoTracking().FirstOrDefaultAsync(l => l.En_Text == jobType || l.Ar_Text == jobType);

            return JobType;
        }

        public async Task<List<DLLocation>> GetAllLocation()
        {
            var list = await _db.DLLocations.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLMechanicalCondition>> GetAllMechanicalCondition()
        {
            var list = await _db.DLMechanicalConditions.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLMobileNumberCode>> GetAllMobileNumberCode()
        {
            var list = await _db.DLMobileNumberCodes.Include(l => l.Operator).AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLMobileNumberCode>> GetAllMobileNumberCodeByOperatorId(int? operatorId)
        {
            var list = new List<DLMobileNumberCode>();

            if (operatorId != null)
            {
                list = await _db.DLMobileNumberCodes.Where(l => l.OperatorId == operatorId).AsNoTracking().ToListAsync();
            }

            return list;
        }

        public async Task<List<DLMobileNumberCode>> GetAllMobileNumberCodeByOperator(string operatorName)
        {
            var list = new List<DLMobileNumberCode>();

            if (operatorName != null)
            {
                var operatorArray = operatorName.Split('-');

                var en_operator = operatorArray[0];

                var ar_operator = operatorArray[1];

                list = await _db.DLMobileNumberCodes.Include(l => l.Operator)
                    .Where(l => l.Operator.En_Text == en_operator || l.Operator.Ar_Text == ar_operator)
                    .AsNoTracking().ToListAsync();
            }

            return list;
        }

        public async Task<List<DLMonthlySalary>> GetAllMonthlySalary()
        {
            var list = await _db.DLMonthlySalaries.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLMotorLength>> GetAllMotorLength()
        {
            var list = await _db.DLMotorLengths.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLMotorMaker>> GetAllMotorMaker()
        {
            var list = await _db.DLMotorMakers.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<BaseResponse> AddMotorMaker(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLMotorMaker()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLMotorMakers.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }

        }

        public async Task<BaseResponse> UpdateMotorMaker(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLMotorMakers.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }

        }

        public async Task<BaseResponse> DeleteMotorMaker(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLMotorMakers.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }

        }

        public async Task<DLMotorMaker> GetMotorMaker(string value)
        {
            var entity = await _db.DLMotorMakers.AsNoTracking().FirstOrDefaultAsync(l => l.En_Text == value || l.Ar_Text == value);

            return entity;
        }

        public async Task<DLMotorModel> GetMotorModel(string value)
        {
            var entity = await _db.DLMotorModels.AsNoTracking().FirstOrDefaultAsync(l => l.En_Text == value || l.Ar_Text == value);

            return entity;
        }

        public async Task<List<DLMotorModel>> GetAllMotorModel()
        {
            var list = await _db.DLMotorModels.Include(l => l.Maker).AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLMotorModel>> GetAllMotorModelByMakerId(int? makerId)
        {
            var list = new List<DLMotorModel>();

            if (makerId != null)
            {
                list = await _db.DLMotorModels.Where(l => l.MakerId == makerId).AsNoTracking().ToListAsync();
            }

            return list;

        }

        public async Task<List<DLMotorModel>> GetAllMotorModelByMaker(string maker)
        {
            var list = new List<DLMotorModel>();

            if (maker != null)
            {
                var makerArray = maker.Split('-');

                var en_maker = makerArray[0];

                var ar_maker = makerArray[1];

                list = await _db.DLMotorModels.Include(l => l.Maker)
                    .Where(l => l.Maker.En_Text == en_maker || l.Maker.Ar_Text == ar_maker)
                    .AsNoTracking().ToListAsync();
            }

            return list;
        }

        public async Task<List<DLMotorRegionalSpecs>> GetAllMotorRegionalSpecs()
        {
            var list = await _db.DLMotorRegionalSpecs.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLMotorTrim>> GetAllMotorTrim()
        {
            var list = await _db.DLMotorTrims.Include(l => l.Model).AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<DLMotorTrim> GetMotorTrim(string value)
        {
            var entity = await _db.DLMotorTrims.AsNoTracking().FirstOrDefaultAsync(l => l.En_Text == value || l.Ar_Text == value);

            return entity;
        }

        public async Task<List<DLMotorTrim>> GetAllMotorTrimByModelId(int? modelId)
        {
            var list = new List<DLMotorTrim>();

            if (modelId != null)
            {
                list = await _db.DLMotorTrims.Where(l => l.ModelId == modelId).AsNoTracking().ToListAsync();
            }

            return list;
        }

        public async Task<List<DLMotorTrim>> GetAllMotorTrimByModel(string model)
        {
            var list = new List<DLMotorTrim>();

            if (model != null)
            {
                var modelArray = model.Split('-');

                var en_model = modelArray[0];

                var ar_model = modelArray[1];

                list = await _db.DLMotorTrims.Include(l => l.Model)
                    .Where(l => l.Model.En_Text == en_model || l.Model.Ar_Text == ar_model).AsNoTracking().ToListAsync();
            }

            return list;
        }

        public async Task<List<DLNationality>> GetAllNationality()
        {
            var list = await _db.DLNationalities.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLNoOfCylinders>> GetAllNoOfCylinders()
        {
            var list = await _db.DLNoOfCylinders.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLNoticePeriod>> GetAllNoticePeriod()
        {
            var list = await _db.DLNoticePeriods.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLOperator>> GetAllOperator()
        {
            var list = await _db.DLOperators.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLPlateCode>> GetAllPlateCode()
        {
            var list = await _db.DLPlateCodes.Include(l => l.PlateType).Include(l => l.PlateType.Emirate).AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLPlateCode>> GetAllPlateCode(string plateType, string emirate)
        {
            var list = new List<DLPlateCode>();

            if (!string.IsNullOrEmpty(plateType) && !string.IsNullOrEmpty(emirate))
            {
                var plateTypeArray = plateType.Split('-');

                var en_plateType = plateTypeArray[0];

                var ar_plateType = plateTypeArray[1];

                var emirateArray = emirate.Split('-');

                var en_emirate = emirateArray[0];

                var ar_emirate = emirateArray[1];

                list = await _db.DLPlateCodes.Include(l => l.PlateType).Include(l => l.PlateType.Emirate)
                    .Where(l => (l.PlateType.En_Text == en_plateType || l.PlateType.Ar_Text == ar_plateType) &&
                    (l.PlateType.Emirate.En_Text == en_emirate || l.PlateType.Emirate.Ar_Text == ar_emirate)

                    ).AsNoTracking().ToListAsync();
            }

            return list;
        }

        public async Task<List<DLPlateCode>> GetAllPlateCodeByPlateTypeId(int? plateTypeId)
        {
            var list = new List<DLPlateCode>();

            if (plateTypeId == null)
            {
                list = await _db.DLPlateCodes.Where(l => l.PlateTypeId == plateTypeId).AsNoTracking().ToListAsync();
            }

            return list;
        }

        public async Task<List<DLPlateCode>> GetAllPlateCodeByPlateType(string plateType)
        {
            var list = new List<DLPlateCode>();

            if (plateType != null)
            {
                var plateTypeArray = plateType.Split('-');

                var en_plateType = plateTypeArray[0];

                var ar_plateType = plateTypeArray[1];

                list = await _db.DLPlateCodes.Include(l => l.PlateType)
                    .Where(l => l.PlateType.En_Text == en_plateType || l.PlateType.Ar_Text == ar_plateType)
                    .AsNoTracking().ToListAsync();
            }

            return list;
        }

        public async Task<List<DLPlateDesign>> GetAllPlateDesign()
        {
            var list = await _db.DLPlateDesigns.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLPlateDesign>> GetAllPlateDesignByPlateTypeId(int? plateTypeId)
        {
            var list = new List<DLPlateDesign>();

            if (plateTypeId == null)
            {
                list = await _db.DLPlateDesigns.Where(l => l.PlateTypeId == plateTypeId).AsNoTracking().ToListAsync();
            }

            return list;
        }

        public async Task<List<DLPlateDesign>> GetAllPlateDesignByPlateType(string plateType)
        {
            var list = new List<DLPlateDesign>();

            if (plateType != null)
            {
                var plateTypeArray = plateType.Split('-');

                var en_plateType = plateTypeArray[0];

                var ar_plateType = plateTypeArray[1];

                list = await _db.DLPlateDesigns.Include(l => l.PlateType)
                    .Where(l => l.PlateType.En_Text == en_plateType || l.PlateType.Ar_Text == ar_plateType)
                    .AsNoTracking().ToListAsync();
            }

            return list;
        }

        public async Task<List<DLPlateType>> GetAllPlateType()
        {
            var list = await _db.DLPlateTypes.Include(l => l.Emirate).AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLPlateType>> GetAllPlateTypeByEmirateId(int? emirateId)
        {
            var list = new List<DLPlateType>();

            if (emirateId != null)
            {
                list = await _db.DLPlateTypes.Where(l => l.EmirateId == emirateId).AsNoTracking().ToListAsync();
            }

            return list;
        }

        public async Task<List<DLPlateType>> GetAllPlateTypeByEmirate(string emirate)
        {
            var list = new List<DLPlateType>();

            if (emirate != null)
            {
                var emirateArray = emirate.Split('-');

                var en_emirate = emirateArray[0];

                var ar_emirate = emirateArray[1];

                list = await _db.DLPlateTypes.Include(l => l.Emirate)
                    .Where(l => l.Emirate.En_Text == en_emirate || l.Emirate.Ar_Text == ar_emirate)
                    .AsNoTracking().ToListAsync();
            }

            return list;
        }

        public async Task<List<DLTransmission>> GetAllTransmission()
        {
            var list = await _db.DLTransmissions.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLUsage>> GetAllUsage(int categoryId)
        {
            var list = await _db.DLUsages.Include(l => l.Category).Where(l => l.CategoryId == categoryId).AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLVisaStatus>> GetAllVisaStatus()
        {
            var list = await _db.DLVisaStatuses.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLWheels>> GetAllWheels()
        {
            var list = await _db.DLWheels.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLWorkExperience>> GetAllWorkExperience()
        {
            var list = await _db.DLWorkExperiences.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLYear>> GetAllYear()
        {
            var list = await _db.DLYears.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLLength>> GetAllLength()
        {
            var list = await _db.DLLengths.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLFinalDriveSystem>> GetAllFinalDriveSystem()
        {
            var list = await _db.DLFinalDriveSystems.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLSellerType>> GetAllSellerType()
        {
            var list = await _db.DLSellerTypes.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLSteeringSide>> GetAllSteeringSide()
        {
            var list = await _db.DLSteeringSides.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<DLPart> GetPart(string value)
        {
            var entity = await _db.DLParts.AsNoTracking().FirstOrDefaultAsync(l => l.En_Text == value || l.Ar_Text == value);

            return entity;
        }

        public async Task<List<DLPart>> GetAllParts(int subTypeId)
        {
            var list = await _db.DLParts.Where(l => l.SubTypeId == subTypeId).AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLPart>> GetAllParts()
        {
            var list = await _db.DLParts.Include(p => p.SubType).AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLAge>> GetAllAgeByTypeId(int typeId)
        {
            var list = await _db.DLAges.Where(l => l.TypeId == typeId).AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLCondition>> GetAllConditionByTypeId(int typeId)
        {
            var list = await _db.DLConditions.Where(l => l.TypeId == typeId).AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<List<DLUsage>> GetAllUsageByTypeId(int typeId)
        {
            var list = await _db.DLUsages.Where(l => l.TypeId == typeId).AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<BaseResponse> AddMotorModel(RelationTextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLMotorModel()
                {
                    MakerId = model.ParentId,
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLMotorModels.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateMotorModel(RelationTextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLMotorModels.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.MakerId = model.ParentId;
                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteMotorModel(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLMotorModels.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddMotorTrim(RelationTextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLMotorTrim()
                {
                    ModelId = model.ParentId,
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLMotorTrims.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateMotorTrim(RelationTextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLMotorTrims.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.ModelId = model.ParentId;
                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteMotorTrim(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLMotorTrims.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddMotorSpecification(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLMotorRegionalSpecs()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLMotorRegionalSpecs.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }

        }

        public async Task<BaseResponse> UpdateMotorSpecification(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLMotorRegionalSpecs.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }

        }

        public async Task<BaseResponse> DeleteMotorSpecification(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLMotorRegionalSpecs.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }

        }

        public async Task<BaseResponse> AddDoors(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLDoor()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLDoors.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }

        }

        public async Task<BaseResponse> UpdateDoors(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLDoors.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }

        }

        public async Task<BaseResponse> DeleteDoors(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLDoors.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }

        }

        public async Task<BaseResponse> AddTransmission(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLTransmission()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLTransmissions.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateTransmission(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLTransmissions.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteTransmission(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLTransmissions.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddBodyType(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLBodyType()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLBodyTypes.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateBodyType(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLBodyTypes.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteBodyType(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLBodyTypes.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddFuelType(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLFuelType()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLFuelTypes.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateFuelType(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLFuelTypes.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteFuelType(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLFuelTypes.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddNoOfCylinder(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLNoOfCylinders()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLNoOfCylinders.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateNoOfCylinder(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLNoOfCylinders.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteNoOfCylinder(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLNoOfCylinders.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddSteeringSide(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLSteeringSide()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLSteeringSides.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateSteeringSide(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLSteeringSides.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteSteeringSide(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLSteeringSides.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddHorsepower(CategoryTextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLHorsepower()
                {
                    CategoryId = (int)model.CategoryId,
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLHorsepowers.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateHorsepower(CategoryTextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLHorsepowers.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteHorsepower(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLHorsepowers.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddAge(CategoryTextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLAge()
                {
                    CategoryId = model.CategoryId,
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle,
                    TypeId = model.TypeId
                };

                _db.DLAges.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateAge(CategoryTextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLAges.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteAge(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLAges.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddUsage(CategoryTextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLUsage()
                {
                    CategoryId = model.CategoryId,
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle,
                    TypeId = model.TypeId
                };

                _db.DLUsages.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateUsage(CategoryTextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLUsages.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteUsage(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLUsages.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddCondition(CategoryTextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLCondition()
                {
                    CategoryId = model.CategoryId,
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle,
                    TypeId = model.TypeId
                };

                _db.DLConditions.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateCondition(CategoryTextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLConditions.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteCondition(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLConditions.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddLength(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLLength()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLLengths.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateLength(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLLengths.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteLength(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLLengths.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddCapacity(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLCapacity()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLCapacities.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateCapacity(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLCapacities.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteCapacity(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLCapacities.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddSellerType(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLSellerType()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLSellerTypes.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateSellerType(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLSellerTypes.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteSellerType(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLSellerTypes.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddMechanicalCondition(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLMechanicalCondition()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLMechanicalConditions.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateMechanicalCondition(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLMechanicalConditions.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteMechanicalCondition(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLMechanicalConditions.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddPart(PartDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLPart()
                {
                    SubTypeId = model.SubTypeId,
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLParts.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdatePart(PartDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLParts.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeletePart(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLParts.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddColor(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLColor()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLColors.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateColor(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLColors.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteColor(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLColors.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddEngineSize(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLEngineSize()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLEngineSizes.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateEngineSize(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLEngineSizes.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteEngineSize(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLEngineSizes.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddWheels(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLWheels()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLWheels.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateWheels(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLWheels.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteWheels(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLWheels.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddFinalDriveSystem(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLFinalDriveSystem()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLFinalDriveSystems.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateFinalDriveSystem(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLFinalDriveSystems.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteFinalDriveSystem(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLFinalDriveSystems.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddJobType(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLJobType()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLJobTypes.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateJobType(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLJobTypes.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteJobType(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLJobTypes.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddCareerLevel(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLCareerLevel()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLCareerLevels.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateCareerLevel(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLCareerLevels.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteCareerLevel(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLCareerLevels.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddWorkExperience(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLWorkExperience()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLWorkExperiences.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateWorkExperience(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLWorkExperiences.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteWorkExperience(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLWorkExperiences.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddEducationLevel(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLEducationLevel()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLEducationLevels.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateEducationLevel(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLEducationLevels.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteEducationLevel(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLEducationLevels.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddEmploymentType(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLEmploymentType()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLEmploymentTypes.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateEmploymentType(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLEmploymentTypes.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteEmploymentType(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLEmploymentTypes.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddNationality(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLNationality()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLNationalities.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateNationality(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLNationalities.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteNationality(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLNationalities.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddCommitment(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLCommitment()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLCommitments.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateCommitment(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLCommitments.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteCommitment(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLCommitments.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddNoticePeriod(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLNoticePeriod()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLNoticePeriods.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateNoticePeriod(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLNoticePeriods.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteNoticePeriod(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLNoticePeriods.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddVisaStatus(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLVisaStatus()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLVisaStatuses.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateVisaStatus(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLVisaStatuses.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteVisaStatus(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLVisaStatuses.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddMonthlySalary(ValueDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLMonthlySalary()
                {
                    Value = model.Value
                };

                _db.DLMonthlySalaries.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateMonthlySalary(ValueDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLMonthlySalaries.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Value = model.Value;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteMonthlySalary(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLMonthlySalaries.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> AddLocation(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLLocation()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLLocations.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateLocation(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLLocations.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteLocation(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLLocations.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<List<DLAdvertisingBudjet>> GetAllAdvertisingBudjet()
        {
            var list = await _db.DLAdvertisingBudjets.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<BaseResponse> AddAdvertisingBudjet(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLAdvertisingBudjet()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLAdvertisingBudjets.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> UpdateAdvertisingBudjet(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLAdvertisingBudjets.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<BaseResponse> DeleteAdvertisingBudjet(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLAdvertisingBudjets.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }


        public async Task<List<DLClassifiedBrand>> GetAllClassifiedBrand()
        {
            var list = await _db.DLClassifiedBrands.AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<BaseResponse> AddClassifiedBrand(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = new DLClassifiedBrand()
                {
                    Ar_Text = model.ArabicTitle,
                    En_Text = model.EnglishTitle
                };

                _db.DLClassifiedBrands.Add(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;


            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }

        }

        public async Task<BaseResponse> UpdateClassifiedBrand(TextDropDownDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLClassifiedBrands.FirstOrDefaultAsync(e => e.Id == model.Id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                entity.Ar_Text = model.ArabicTitle;
                entity.En_Text = model.EnglishTitle;

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }

        }

        public async Task<BaseResponse> DeleteClassifiedBrand(int id)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _db.DLClassifiedBrands.FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                _db.Remove(entity);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = true;
                response.Message = StaticData.ServerError_Message;
                return response;
            }

        }

        public async Task<DLClassifiedBrand> GetClassifiedBrand(string value)
        {
            var entity = await _db.DLClassifiedBrands.AsNoTracking().FirstOrDefaultAsync(l => l.En_Text == value || l.Ar_Text == value);

            return entity;
        }
    }
}

using insouq.EntityFramework;
using insouq.Models.Dropdownlists;
using insouq.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services
{
    public class DropDownService : IDropDownService
    {
        private readonly ApplicationDbContext _db;

        public DropDownService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<DLAge>> GetAllAge(int categoryId)
        {
            var list = await _db.DLAges.Where(l => l.CategoryId == categoryId).AsNoTracking().ToListAsync();

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
            var list = await _db.DLConditions.Where(l => l.CategoryId == categoryId).AsNoTracking().ToListAsync();

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
            var list = await _db.DLHorsepowers.Where(l => l.CategoryId == categoryId).AsNoTracking().ToListAsync();

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
            var list = await _db.DLMobileNumberCodes.AsNoTracking().ToListAsync();

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
            var list = await _db.DLMotorModels.AsNoTracking().ToListAsync();

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
            var list = await _db.DLMotorTrims.AsNoTracking().ToListAsync();

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
            var list = await _db.DLPlateTypes.AsNoTracking().ToListAsync();

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
            var list = await _db.DLUsages.Where(l => l.CategoryId == categoryId).AsNoTracking().ToListAsync();

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

        public async Task<List<DLClassifiedBrand>> GetAllClassifiedBrand()
        {
            var list = await _db.DLClassifiedBrands.AsNoTracking().ToListAsync();

            return list;
        }
    }
}

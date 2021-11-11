using insouq.Models.Dropdownlists;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services.IServices
{
    public interface IDropDownService
    {
        Task<List<DLBodyType>> GetAllBodyType();
        Task<List<DLNumberPlan>> GetAllNumberPlans();
        Task<List<DLCapacity>> GetAllCapacity();
        Task<List<DLColor>> GetAllColor();
        Task<List<DLDoor>> GetAllDoor();
        Task<List<DLEngineSize>> GetAllEngineSize();
        //Task<List<DLEngineSize>> GetAllEngineSizeByMakerId(int makerId);
        //Task<List<DLEngineSize>> GetAllEngineSizeByMaker(string maker);
        Task<List<DLFuelType>> GetAllFuelType();
        Task<List<DLHorsepower>> GetAllHorsepower(int categoryId);
        Task<List<DLMechanicalCondition>> GetAllMechanicalCondition();
        Task<List<DLMotorLength>> GetAllMotorLength();
        Task<List<DLMotorMaker>> GetAllMotorMaker();
        Task<DLMotorMaker> GetMotorMaker(string value);
        Task<DLMotorModel> GetMotorModel(string value);
        Task<List<DLMotorModel>> GetAllMotorModel();
        Task<List<DLMotorModel>> GetAllMotorModelByMakerId(int? makerId);
        Task<List<DLMotorModel>> GetAllMotorModelByMaker(string maker);
        Task<List<DLMotorRegionalSpecs>> GetAllMotorRegionalSpecs();
        Task<List<DLMotorTrim>> GetAllMotorTrim();
        Task<DLMotorTrim> GetMotorTrim(string value);
        Task<List<DLMotorTrim>> GetAllMotorTrimByModelId(int? modelId);
        Task<List<DLMotorTrim>> GetAllMotorTrimByModel(string model);
        Task<List<DLNoOfCylinders>> GetAllNoOfCylinders();
        Task<List<DLTransmission>> GetAllTransmission();
        Task<List<DLFinalDriveSystem>> GetAllFinalDriveSystem();
        Task<List<DLSellerType>> GetAllSellerType();
        Task<List<DLWheels>> GetAllWheels();
        Task<List<DLPart>> GetAllParts(int subTypeId);
        Task<DLPart> GetPart(string value);
        Task<List<DLYear>> GetAllYear();
        Task<List<DLLength>> GetAllLength();
        Task<List<DLCommitment>> GetAllCommitment();
        Task<List<DLSteeringSide>> GetAllSteeringSide();
        Task<List<DLJobType>> GetAllJobType();
        Task<DLJobType> GetJobType(string jobType);
        Task<List<DLMonthlySalary>> GetAllMonthlySalary();
        Task<List<DLNoticePeriod>> GetAllNoticePeriod();
        Task<List<DLVisaStatus>> GetAllVisaStatus();
        Task<List<DLWorkExperience>> GetAllWorkExperience();
        Task<List<DLBathooms>> GetAllBathooms();
        Task<List<DLBedrooms>> GetAllBedrooms();
        Task<List<DLFurnishing>> GetAllFurnishing();
        Task<List<DLAge>> GetAllAge(int categoryId);
        Task<List<DLAge>> GetAllAgeByTypeId(int typeId);
        Task<List<DLCareerLevel>> GetAllCareerLevel();
        Task<List<DLCompanyIndustry>> GetAllCompanyIndustry();
        Task<List<DLCompanySize>> GetAllCompanySize();
        Task<List<DLCondition>> GetAllCondition(int categoryId);
        Task<List<DLCondition>> GetAllConditionByTypeId(int typeId);
        Task<List<DLEducationLevel>> GetAllEducationLevel();
        Task<List<DLEmploymentType>> GetAllEmploymentType();
        Task<List<DLLocation>> GetAllLocation();
        Task<List<DLNationality>> GetAllNationality();
        Task<List<DLUsage>> GetAllUsage(int categoryId);
        Task<List<DLUsage>> GetAllUsageByTypeId(int typeId);
        Task<List<DLCurrentNetwork>> GetAllCurrentNetwork();
        Task<List<DLEmirate>> GetAllEmirate();
        Task<List<DLMobileNumberCode>> GetAllMobileNumberCode();
        Task<List<DLMobileNumberCode>> GetAllMobileNumberCodeByOperatorId(int? operatorId);
        Task<List<DLMobileNumberCode>> GetAllMobileNumberCodeByOperator(string operatorName);
        Task<List<DLOperator>> GetAllOperator();
        Task<List<DLPlateCode>> GetAllPlateCode(string plateType, string emirate);
        Task<List<DLPlateCode>> GetAllPlateCodeByPlateTypeId(int? plateTypeId);
        Task<List<DLPlateCode>> GetAllPlateCodeByPlateType(string plateType);
        Task<List<DLPlateDesign>> GetAllPlateDesignByPlateTypeId(int? plateTypeId);
        Task<List<DLPlateDesign>> GetAllPlateDesignByPlateType(string plateTypeId);
        Task<List<DLPlateDesign>> GetAllPlateDesign();
        Task<List<DLPlateType>> GetAllPlateType();
        Task<List<DLPlateType>> GetAllPlateTypeByEmirateId(int? emirateId);
        Task<List<DLPlateType>> GetAllPlateTypeByEmirate(string emirateId);

    }
}

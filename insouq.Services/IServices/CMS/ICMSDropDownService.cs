using insouq.Models.Dropdownlists;
using insouq.Shared.DTOS.CMS;
using insouq.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services.IServices.CMS
{
    public interface ICMSDropDownService
    {
        Task<List<DLAdvertisingBudjet>> GetAllAdvertisingBudjet();
        Task<BaseResponse> AddAdvertisingBudjet(TextDropDownDTO model);
        Task<BaseResponse> UpdateAdvertisingBudjet(TextDropDownDTO model);
        Task<BaseResponse> DeleteAdvertisingBudjet(int id);

        Task<BaseResponse> AddLocation(TextDropDownDTO model);
        Task<BaseResponse> UpdateLocation(TextDropDownDTO model);
        Task<BaseResponse> DeleteLocation(int id);

        Task<BaseResponse> AddMonthlySalary(ValueDropDownDTO model);
        Task<BaseResponse> UpdateMonthlySalary(ValueDropDownDTO model);
        Task<BaseResponse> DeleteMonthlySalary(int id); 
        
        Task<BaseResponse> AddVisaStatus(TextDropDownDTO model);
        Task<BaseResponse> UpdateVisaStatus(TextDropDownDTO model);
        Task<BaseResponse> DeleteVisaStatus(int id);
        
        Task<BaseResponse> AddNoticePeriod(TextDropDownDTO model);
        Task<BaseResponse> UpdateNoticePeriod(TextDropDownDTO model);
        Task<BaseResponse> DeleteNoticePeriod(int id);

        Task<BaseResponse> AddCommitment(TextDropDownDTO model);
        Task<BaseResponse> UpdateCommitment(TextDropDownDTO model);
        Task<BaseResponse> DeleteCommitment(int id);
        
        Task<BaseResponse> AddNationality(TextDropDownDTO model);
        Task<BaseResponse> UpdateNationality(TextDropDownDTO model);
        Task<BaseResponse> DeleteNationality(int id);

        Task<BaseResponse> AddJobType(TextDropDownDTO model);
        Task<BaseResponse> UpdateJobType(TextDropDownDTO model);
        Task<BaseResponse> DeleteJobType(int id);
        
        Task<BaseResponse> AddEmploymentType(TextDropDownDTO model);
        Task<BaseResponse> UpdateEmploymentType(TextDropDownDTO model);
        Task<BaseResponse> DeleteEmploymentType(int id);

        Task<BaseResponse> AddCareerLevel(TextDropDownDTO model);
        Task<BaseResponse> UpdateCareerLevel(TextDropDownDTO model);
        Task<BaseResponse> DeleteCareerLevel(int id);

        Task<BaseResponse> AddWorkExperience(TextDropDownDTO model);
        Task<BaseResponse> UpdateWorkExperience(TextDropDownDTO model);
        Task<BaseResponse> DeleteWorkExperience(int id);
        
        Task<BaseResponse> AddEducationLevel(TextDropDownDTO model);
        Task<BaseResponse> UpdateEducationLevel(TextDropDownDTO model);
        Task<BaseResponse> DeleteEducationLevel(int id);

        Task<BaseResponse> AddOperator(TextDropDownDTO model);
        Task<BaseResponse> UpdateOperator(TextDropDownDTO model);
        Task<BaseResponse> DeleteOperator(int id);

        Task<BaseResponse> AddNumberPlan(TextDropDownDTO model);
        Task<BaseResponse> UpdateNumberPlan(TextDropDownDTO model);
        Task<BaseResponse> DeleteNumberPlan(int id);

        Task<BaseResponse> AddMobileCode(RelationValueDropDownDTO model);
        Task<BaseResponse> UpdateMobileCode(RelationValueDropDownDTO model);
        Task<BaseResponse> DeleteMobileCode(int id);

        Task<BaseResponse> AddEmirate(TextDropDownDTO model);
        Task<BaseResponse> UpdateEmirate(TextDropDownDTO model);
        Task<BaseResponse> DeleteEmirate(int id);

        Task<BaseResponse> AddPlateType(RelationTextDropDownDTO model);
        Task<BaseResponse> UpdatePlateType(RelationTextDropDownDTO model);
        Task<BaseResponse> DeletePlateType(int id);

        Task<BaseResponse> AddPlateCode(RelationValueDropDownDTO model);
        Task<BaseResponse> UpdatePlateCode(RelationValueDropDownDTO model);
        Task<BaseResponse> DeletePlateCode(int id);

        Task<List<DLBodyType>> GetAllBodyType();
        Task<List<DLNumberPlan>> GetAllNumberPlans();
        Task<List<DLCapacity>> GetAllCapacity();
        Task<List<DLColor>> GetAllColor();
        Task<List<DLDoor>> GetAllDoor();
        Task<BaseResponse> AddDoors(TextDropDownDTO model);
        Task<BaseResponse> UpdateDoors(TextDropDownDTO model);
        Task<BaseResponse> DeleteDoors(int id);
        Task<List<DLEngineSize>> GetAllEngineSize();
        //Task<List<DLEngineSize>> GetAllEngineSizeByMakerId(int makerId);
        //Task<List<DLEngineSize>> GetAllEngineSizeByMaker(string maker);
        Task<List<DLFuelType>> GetAllFuelType();
        Task<List<DLHorsepower>> GetAllHorsepower(int categoryId);
        Task<List<DLMechanicalCondition>> GetAllMechanicalCondition();
        Task<List<DLMotorLength>> GetAllMotorLength();
        Task<List<DLMotorMaker>> GetAllMotorMaker();
        Task<DLMotorMaker> GetMotorMaker(string value);
        Task<BaseResponse> AddMotorMaker(TextDropDownDTO model);
        Task<BaseResponse> UpdateMotorMaker(TextDropDownDTO model);
        Task<BaseResponse> DeleteMotorMaker(int id);
        Task<DLMotorModel> GetMotorModel(string value);
        Task<List<DLMotorModel>> GetAllMotorModel();
        Task<List<DLMotorModel>> GetAllMotorModelByMakerId(int? makerId);
        Task<List<DLMotorModel>> GetAllMotorModelByMaker(string maker);
        Task<BaseResponse> AddMotorModel(RelationTextDropDownDTO model);
        Task<BaseResponse> UpdateMotorModel(RelationTextDropDownDTO model);
        Task<BaseResponse> DeleteMotorModel(int id);
        Task<List<DLMotorRegionalSpecs>> GetAllMotorRegionalSpecs();
        Task<BaseResponse> AddMotorSpecification(TextDropDownDTO model);
        Task<BaseResponse> UpdateMotorSpecification(TextDropDownDTO model);
        Task<BaseResponse> DeleteMotorSpecification(int id);
        Task<List<DLMotorTrim>> GetAllMotorTrim();
        Task<DLMotorTrim> GetMotorTrim(string value);
        Task<List<DLMotorTrim>> GetAllMotorTrimByModelId(int? modelId);
        Task<List<DLMotorTrim>> GetAllMotorTrimByModel(string model);
        Task<BaseResponse> AddMotorTrim(RelationTextDropDownDTO model);
        Task<BaseResponse> UpdateMotorTrim(RelationTextDropDownDTO model);
        Task<BaseResponse> DeleteMotorTrim(int id);
        Task<List<DLNoOfCylinders>> GetAllNoOfCylinders();
        Task<List<DLTransmission>> GetAllTransmission();
        Task<BaseResponse> AddTransmission(TextDropDownDTO model);
        Task<BaseResponse> UpdateTransmission(TextDropDownDTO model);
        Task<BaseResponse> DeleteTransmission(int id);
        Task<List<DLFinalDriveSystem>> GetAllFinalDriveSystem();
        Task<List<DLSellerType>> GetAllSellerType();
        Task<List<DLWheels>> GetAllWheels();
        Task<List<DLPart>> GetAllParts(int subTypeId);
        Task<List<DLPart>> GetAllParts();
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
        Task<List<DLPlateCode>> GetAllPlateCode();
        Task<List<DLPlateCode>> GetAllPlateCode(string plateType, string emirate);
        Task<List<DLPlateCode>> GetAllPlateCodeByPlateTypeId(int? plateTypeId);
        Task<List<DLPlateCode>> GetAllPlateCodeByPlateType(string plateType);
        Task<List<DLPlateDesign>> GetAllPlateDesignByPlateTypeId(int? plateTypeId);
        Task<List<DLPlateDesign>> GetAllPlateDesignByPlateType(string plateTypeId);
        Task<List<DLPlateDesign>> GetAllPlateDesign();
        Task<List<DLPlateType>> GetAllPlateType();
        Task<List<DLPlateType>> GetAllPlateTypeByEmirateId(int? emirateId);
        Task<List<DLPlateType>> GetAllPlateTypeByEmirate(string emirateId);

        Task<BaseResponse> AddBodyType(TextDropDownDTO model);
        Task<BaseResponse> UpdateBodyType(TextDropDownDTO model);
        Task<BaseResponse> DeleteBodyType(int id);

        Task<BaseResponse> AddFuelType(TextDropDownDTO model);
        Task<BaseResponse> UpdateFuelType(TextDropDownDTO model);
        Task<BaseResponse> DeleteFuelType(int id);


        Task<BaseResponse> AddNoOfCylinder(TextDropDownDTO model);
        Task<BaseResponse> UpdateNoOfCylinder(TextDropDownDTO model);
        Task<BaseResponse> DeleteNoOfCylinder(int id);


        Task<BaseResponse> AddSteeringSide(TextDropDownDTO model);
        Task<BaseResponse> UpdateSteeringSide(TextDropDownDTO model);
        Task<BaseResponse> DeleteSteeringSide(int id);


        Task<BaseResponse> AddHorsepower(CategoryTextDropDownDTO model);
        Task<BaseResponse> UpdateHorsepower(CategoryTextDropDownDTO model);
        Task<BaseResponse> DeleteHorsepower(int id);

        Task<BaseResponse> AddAge(CategoryTextDropDownDTO model);
        Task<BaseResponse> UpdateAge(CategoryTextDropDownDTO model);
        Task<BaseResponse> DeleteAge(int id);

        Task<BaseResponse> AddUsage(CategoryTextDropDownDTO model);
        Task<BaseResponse> UpdateUsage(CategoryTextDropDownDTO model);
        Task<BaseResponse> DeleteUsage(int id);

        Task<BaseResponse> AddCondition(CategoryTextDropDownDTO model);
        Task<BaseResponse> UpdateCondition(CategoryTextDropDownDTO model);
        Task<BaseResponse> DeleteCondition(int id);

        Task<BaseResponse> AddLength(TextDropDownDTO model);
        Task<BaseResponse> UpdateLength(TextDropDownDTO model);
        Task<BaseResponse> DeleteLength(int id);

        Task<BaseResponse> AddCapacity(TextDropDownDTO model);
        Task<BaseResponse> UpdateCapacity(TextDropDownDTO model);
        Task<BaseResponse> DeleteCapacity(int id);

        Task<BaseResponse> AddSellerType(TextDropDownDTO model);
        Task<BaseResponse> UpdateSellerType(TextDropDownDTO model);
        Task<BaseResponse> DeleteSellerType(int id);

        Task<BaseResponse> AddMechanicalCondition(TextDropDownDTO model);
        Task<BaseResponse> UpdateMechanicalCondition(TextDropDownDTO model);
        Task<BaseResponse> DeleteMechanicalCondition(int id);

        Task<BaseResponse> AddPart(PartDropDownDTO model);
        Task<BaseResponse> UpdatePart(PartDropDownDTO model);
        Task<BaseResponse> DeletePart(int id);

        Task<BaseResponse> AddColor(TextDropDownDTO model);
        Task<BaseResponse> UpdateColor(TextDropDownDTO model);
        Task<BaseResponse> DeleteColor(int id);

        Task<BaseResponse> AddEngineSize(TextDropDownDTO model);
        Task<BaseResponse> UpdateEngineSize(TextDropDownDTO model);
        Task<BaseResponse> DeleteEngineSize(int id);

        Task<BaseResponse> AddWheels(TextDropDownDTO model);
        Task<BaseResponse> UpdateWheels(TextDropDownDTO model);
        Task<BaseResponse> DeleteWheels(int id);

        Task<BaseResponse> AddFinalDriveSystem(TextDropDownDTO model);
        Task<BaseResponse> UpdateFinalDriveSystem(TextDropDownDTO model);
        Task<BaseResponse> DeleteFinalDriveSystem(int id);

        Task<List<DLClassifiedBrand>> GetAllClassifiedBrand();

        Task<BaseResponse> AddClassifiedBrand(TextDropDownDTO model);


        Task<BaseResponse> UpdateClassifiedBrand(TextDropDownDTO model);


        Task<BaseResponse> DeleteClassifiedBrand(int id);

        Task<DLClassifiedBrand> GetClassifiedBrand(string value);
      
    }
}

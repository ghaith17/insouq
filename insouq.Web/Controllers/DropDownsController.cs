using insouq.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace insouq.Web.Controllers
{
    public class DropDownsController : Controller
    {
        private readonly IDropDownService _dropDownService;

        public DropDownsController(IDropDownService dropDownService)
        {
            _dropDownService = dropDownService;
        }

        #region API_CALLS


        [HttpGet]
        public async Task<JsonResult> GetAllAgeByTypeId(int typeId)
        {
            var list = await _dropDownService.GetAllAgeByTypeId(typeId);

            return Json(new { items = list });
        }


        [HttpGet]
        public async Task<JsonResult> GetAllUsageByTypeId(int typeId)
        {
            var list = await _dropDownService.GetAllUsageByTypeId(typeId);

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllConditionByTypeId(int typeId)
        {
            var list = await _dropDownService.GetAllConditionByTypeId(typeId);

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllParts(int subTypeId)
        {
            var list = await _dropDownService.GetAllParts(subTypeId);

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllSteeringSide()
        {
            var list = await _dropDownService.GetAllSteeringSide();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllFinalDriveSystem()
        {
            var list = await _dropDownService.GetAllFinalDriveSystem();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllSellerType()
        {
            var list = await _dropDownService.GetAllSellerType();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllAge(int categoryId)
        {
            var list = await _dropDownService.GetAllAge(categoryId);

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllLength()
        {
            var list = await _dropDownService.GetAllLength();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllBathooms()
        {
            var list = await _dropDownService.GetAllBathooms();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllBedrooms()
        {
            var list = await _dropDownService.GetAllBedrooms();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllBodyType()
        {
            var list = await _dropDownService.GetAllBodyType();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllNumberPlans()
        {
            var list = await _dropDownService.GetAllNumberPlans();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllCapacity()
        {
            var list = await _dropDownService.GetAllCapacity();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllCareerLevel()
        {
            var list = await _dropDownService.GetAllCareerLevel();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllColor()
        {
            var list = await _dropDownService.GetAllColor();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllCommitment()
        {
            var list = await _dropDownService.GetAllCommitment();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllCompanyIndustry()
        {
            var list = await _dropDownService.GetAllCompanyIndustry();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllCompanySize()
        {
            var list = await _dropDownService.GetAllCompanySize();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllCondition(int categoryId)
        {
            var list = await _dropDownService.GetAllCondition(categoryId);

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllCurrentNetwork()
        {
            var list = await _dropDownService.GetAllCurrentNetwork();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllDoor()
        {
            var list = await _dropDownService.GetAllDoor();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllEducationLevel()
        {
            var list = await _dropDownService.GetAllEducationLevel();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllEmirate()
        {
            var list = await _dropDownService.GetAllEmirate();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllEmploymentType()
        {
            var list = await _dropDownService.GetAllEmploymentType();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllEngineSize()
        {
            var list = await _dropDownService.GetAllEngineSize();

            return Json(new { items = list });
        }

        //[HttpGet]
        //public async Task<JsonResult> GetAllEngineSizeByMakerId([FromQuery] int makerId)
        //{
        //    var list = await _dropDownService.GetAllEngineSizeByMakerId(makerId);

        //    return Json(new { items = list });
        //}

        //[HttpGet]
        //public async Task<JsonResult> GetAllEngineSizeByMaker([FromQuery] string maker)
        //{
        //    var list = await _dropDownService.GetAllEngineSizeByMaker(maker);

        //    return Json(new { items = list });
        //}

        [HttpGet]
        public async Task<JsonResult> GetAllFuelType()
        {
            var list = await _dropDownService.GetAllFuelType();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllFurnishing()
        {
            var list = await _dropDownService.GetAllFurnishing();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllHorsepower(int categoryId)
        {
            var list = await _dropDownService.GetAllHorsepower(categoryId);

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllJobType()
        {
            var list = await _dropDownService.GetAllJobType();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllLocation()
        {
            var list = await _dropDownService.GetAllLocation();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllMechanicalCondition()
        {
            var list = await _dropDownService.GetAllMechanicalCondition();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllMobileNumberCode()
        {
            var list = await _dropDownService.GetAllMobileNumberCode();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllMobileNumberCodeByOperatorId([FromQuery] int? operatorId)
        {
            var list = await _dropDownService.GetAllMobileNumberCodeByOperatorId(operatorId);

            return Json(new { items = list });
        }  
        
        [HttpGet]
        public async Task<JsonResult> GetAllMobileNumberCodeByOperator([FromQuery] string operatorName)
        {
            var list = await _dropDownService.GetAllMobileNumberCodeByOperator(operatorName);

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllMonthlySalary()
        {
            var list = await _dropDownService.GetAllMonthlySalary();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllMotorLength()
        {
            var list = await _dropDownService.GetAllMotorLength();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllMotorMaker()
        {
            var list = await _dropDownService.GetAllMotorMaker();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllMotorModel()
        {
            var list = await _dropDownService.GetAllMotorModel();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllMotorModelByMakerId([FromQuery] int makerId)
        {
            var list = await _dropDownService.GetAllMotorModelByMakerId(makerId);

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllMotorModelByMaker([FromQuery] string maker)
        {
            var list = await _dropDownService.GetAllMotorModelByMaker(maker);

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllMotorRegionalSpecs()
        {
            var list = await _dropDownService.GetAllMotorRegionalSpecs();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllMotorTrim()
        {
            var list = await _dropDownService.GetAllMotorTrim();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllMotorTrimByModelId(int modelId)
        {
            var list = await _dropDownService.GetAllMotorTrimByModelId(modelId);

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllMotorTrimByModel(string model)
        {
            var list = await _dropDownService.GetAllMotorTrimByModel(model);

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllNationality()
        {
            var list = await _dropDownService.GetAllNationality();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllNoOfCylinders()
        {
            var list = await _dropDownService.GetAllNoOfCylinders();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllNoticePeriod()
        {
            var list = await _dropDownService.GetAllNoticePeriod();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllOperator()
        {
            var list = await _dropDownService.GetAllOperator();

            return Json(new { items = list });
        }

        //[HttpGet]
        //public async Task<JsonResult> GetAllPlateCode()
        //{
        //    var list = await _dropDownService.GetAllPlateCode();

        //    return Json(new { items = list });
        //}

        [HttpGet]
        public async Task<JsonResult> GetAllPlateCode(string plateType, string emirate)
        {
            var list = await _dropDownService.GetAllPlateCode(plateType, emirate);

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllPlateCodeByPlateTypeId([FromQuery] int plateTypeId)
        {
            var list = await _dropDownService.GetAllPlateCodeByPlateTypeId(plateTypeId);

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllPlateCodeByPlateType([FromQuery] string plateType)
        {
            var list = await _dropDownService.GetAllPlateCodeByPlateType(plateType);

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllPlateDesign()
        {
            var list = await _dropDownService.GetAllPlateDesign();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllPlateDesignByPlateTypeId([FromQuery] int plateTypeId)
        {
            var list = await _dropDownService.GetAllPlateDesignByPlateTypeId(plateTypeId);

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllPlateDesignByPlateType([FromQuery] string plateType)
        {
            var list = await _dropDownService.GetAllPlateDesignByPlateType(plateType);

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllPlateType()
        {
            var list = await _dropDownService.GetAllPlateType();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllPlateTypeByEmirateId([FromQuery] int emirateId)
        {
            var list = await _dropDownService.GetAllPlateTypeByEmirateId(emirateId);

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllPlateTypeByEmirate([FromQuery] string emirate)
        {
            var list = await _dropDownService.GetAllPlateTypeByEmirate(emirate);

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllTransmission()
        {
            var list = await _dropDownService.GetAllTransmission();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllUsage(int categoryId)
        {
            var list = await _dropDownService.GetAllUsage(categoryId);

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllVisaStatus()
        {
            var list = await _dropDownService.GetAllVisaStatus();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllWheels()
        {
            var list = await _dropDownService.GetAllWheels();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllWorkExperience()
        {
            var list = await _dropDownService.GetAllWorkExperience();

            return Json(new { items = list });
        }

        [HttpGet]
        public async Task<JsonResult> GetAllYear()
        {
            var list = await _dropDownService.GetAllYear();

            return Json(new { items = list });
        }
        [HttpGet]
        public async Task<JsonResult> GetAllClassifiedBrand()
        {
            var list = await _dropDownService.GetAllClassifiedBrand();

            return Json(new { items = list });
        }
        #endregion

    }
}

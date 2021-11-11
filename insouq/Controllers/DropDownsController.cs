using insouq.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace insouq.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DropDownsController : ControllerBase
    {
        private readonly IDropDownService _dropDownService;

        public DropDownsController(IDropDownService dropDownService)
        {
            _dropDownService = dropDownService;
        }

        #region API_CALLS


        [HttpGet(nameof(GetAllAgeByTypeId))]
        public async Task<IActionResult> GetAllAgeByTypeId(int typeId)
        {
            var list = await _dropDownService.GetAllAgeByTypeId(typeId);

            return Ok(list);
        }


        [HttpGet(nameof(GetAllAge))]
        public async Task<IActionResult> GetAllAge(int categoryId)
        {
            var list = await _dropDownService.GetAllAge(categoryId);

            return Ok(list);
        }


        [HttpGet(nameof(GetAllUsageByTypeId))]
        public async Task<IActionResult> GetAllUsageByTypeId(int typeId)
        {
            var list = await _dropDownService.GetAllUsageByTypeId(typeId);

            return Ok(list);
        }

        [HttpGet(nameof(GetAllUsage))]
        public async Task<IActionResult> GetAllUsage(int categoryId)
        {
            var list = await _dropDownService.GetAllUsage(categoryId);

            return Ok(list);
        }

        [HttpGet(nameof(GetAllConditionByTypeId))]
        public async Task<IActionResult> GetAllConditionByTypeId(int typeId)
        {
            var list = await _dropDownService.GetAllConditionByTypeId(typeId);

            return Ok(list);
        }

        [HttpGet(nameof(GetAllCondition))]
        public async Task<IActionResult> GetAllCondition(int categoryId)
        {
            var list = await _dropDownService.GetAllCondition(categoryId);

            return Ok(list);
        }

        [HttpGet(nameof(GetAllParts))]
        public async Task<IActionResult> GetAllParts(int subTypeId)
        {
            var list = await _dropDownService.GetAllParts(subTypeId);

            return Ok(list);
        }

        [HttpGet(nameof(GetAllSteeringSide))]
        public async Task<IActionResult> GetAllSteeringSide()
        {
            var list = await _dropDownService.GetAllSteeringSide();

            return Ok(list);
        }

        [HttpGet(nameof(GetAllFinalDriveSystem))]
        public async Task<IActionResult> GetAllFinalDriveSystem()
        {
            var list = await _dropDownService.GetAllFinalDriveSystem();

            return Ok(list);
        }

        [HttpGet(nameof(GetAllSellerType))]
        public async Task<IActionResult> GetAllSellerType()
        {
            var list = await _dropDownService.GetAllSellerType();

            return Ok(list);
        }


        [HttpGet(nameof(GetAllLength))]
        public async Task<IActionResult> GetAllLength()
        {
            var list = await _dropDownService.GetAllLength();

            return Ok(list);
        }

        //[HttpGet(nameof(GetAllBathooms))]
        //public async Task<IActionResult> GetAllBathooms()
        //{
        //    var list = await _dropDownService.GetAllBathooms();

        //    return Ok(list);
        //}

        //[HttpGet(nameof(GetAllBedrooms))]
        //public async Task<IActionResult> GetAllBedrooms()
        //{
        //    var list = await _dropDownService.GetAllBedrooms();

        //    return Ok(list);
        //}

        [HttpGet(nameof(GetAllBodyType))]
        public async Task<IActionResult> GetAllBodyType()
        {
            var list = await _dropDownService.GetAllBodyType();

            return Ok(list);
        }

        [HttpGet(nameof(GetAllNumberPlans))]
        public async Task<IActionResult> GetAllNumberPlans()
        {
            var list = await _dropDownService.GetAllNumberPlans();

            return Ok(list);
        }

        [HttpGet(nameof(GetAllCapacity))]
        public async Task<IActionResult> GetAllCapacity()
        {
            var list = await _dropDownService.GetAllCapacity();

            return Ok(list);
        }

        [HttpGet(nameof(GetAllCareerLevel))]
        public async Task<IActionResult> GetAllCareerLevel()
        {
            var list = await _dropDownService.GetAllCareerLevel();

            return Ok(list);
        }

        [HttpGet(nameof(GetAllColor))]
        public async Task<IActionResult> GetAllColor()
        {
            var list = await _dropDownService.GetAllColor();

            return Ok(list);
        }

        [HttpGet(nameof(GetAllCommitment))]
        public async Task<IActionResult> GetAllCommitment()
        {
            var list = await _dropDownService.GetAllCommitment();

            return Ok(list);
        }

        [HttpGet(nameof(GetAllCompanyIndustry))]
        public async Task<IActionResult> GetAllCompanyIndustry()
        {
            var list = await _dropDownService.GetAllCompanyIndustry();

            return Ok(list);
        }

        //[HttpGet(nameof(GetAllCompanySize))]
        //public async Task<IActionResult> GetAllCompanySize()
        //{
        //    var list = await _dropDownService.GetAllCompanySize();

        //    return Ok(list);
        //}



        //[HttpGet(nameof(GetAllCurrentNetwork))]
        //public async Task<IActionResult> GetAllCurrentNetwork()
        //{
        //    var list = await _dropDownService.GetAllCurrentNetwork();

        //    return Ok(list);
        //}

        [HttpGet(nameof(GetAllDoor))]
        public async Task<IActionResult> GetAllDoor()
        {
            var list = await _dropDownService.GetAllDoor();

            return Ok(list);
        }

        [HttpGet(nameof(GetAllEducationLevel))]
        public async Task<IActionResult> GetAllEducationLevel()
        {
            var list = await _dropDownService.GetAllEducationLevel();

            return Ok(list);
        }

        [HttpGet(nameof(GetAllEmirate))]
        public async Task<IActionResult> GetAllEmirate()
        {
            var list = await _dropDownService.GetAllEmirate();

            return Ok(list);
        }

        [HttpGet(nameof(GetAllEmploymentType))]
        public async Task<IActionResult> GetAllEmploymentType()
        {
            var list = await _dropDownService.GetAllEmploymentType();

            return Ok(list);
        }

        [HttpGet(nameof(GetAllEngineSize))]
        public async Task<IActionResult> GetAllEngineSize()
        {
            var list = await _dropDownService.GetAllEngineSize();

            return Ok(list);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAllEngineSizeByMakerId([FromQuery] int makerId)
        //{
        //    var list = await _dropDownService.GetAllEngineSizeByMakerId(makerId);

        //    return Ok(list);
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAllEngineSizeByMaker([FromQuery] string maker)
        //{
        //    var list = await _dropDownService.GetAllEngineSizeByMaker(maker);

        //    return Ok(list);
        //}

        [HttpGet(nameof(GetAllFuelType))]
        public async Task<IActionResult> GetAllFuelType()
        {
            var list = await _dropDownService.GetAllFuelType();

            return Ok(list);
        }

        //[HttpGet(nameof(GetAllFurnishing))]
        //public async Task<IActionResult> GetAllFurnishing()
        //{
        //    var list = await _dropDownService.GetAllFurnishing();

        //    return Ok(list);
        //}

        [HttpGet(nameof(GetAllHorsepower))]
        public async Task<IActionResult> GetAllHorsepower(int categoryId)
        {
            var list = await _dropDownService.GetAllHorsepower(categoryId);

            return Ok(list);
        }

        [HttpGet(nameof(GetAllJobType))]
        public async Task<IActionResult> GetAllJobType()
        {
            var list = await _dropDownService.GetAllJobType();

            return Ok(list);
        }

        [HttpGet(nameof(GetAllLocation))]
        public async Task<IActionResult> GetAllLocation()
        {
            var list = await _dropDownService.GetAllLocation();

            return Ok(list);
        }

        [HttpGet(nameof(GetAllMechanicalCondition))]
        public async Task<IActionResult> GetAllMechanicalCondition()
        {
            var list = await _dropDownService.GetAllMechanicalCondition();

            return Ok(list);
        }

        [HttpGet(nameof(GetAllMobileNumberCode))]
        public async Task<IActionResult> GetAllMobileNumberCode()
        {
            var list = await _dropDownService.GetAllMobileNumberCode();

            return Ok(list);
        }

        [HttpGet(nameof(GetAllMobileNumberCodeByOperatorId))]
        public async Task<IActionResult> GetAllMobileNumberCodeByOperatorId([FromQuery] int? operatorId)
        {
            var list = await _dropDownService.GetAllMobileNumberCodeByOperatorId(operatorId);

            return Ok(list);
        }

        [HttpGet(nameof(GetAllMobileNumberCodeByOperator))]
        public async Task<IActionResult> GetAllMobileNumberCodeByOperator([FromQuery] string operatorName)
        {
            var list = await _dropDownService.GetAllMobileNumberCodeByOperator(operatorName);

            return Ok(list);
        }

        [HttpGet(nameof(GetAllMonthlySalary))]
        public async Task<IActionResult> GetAllMonthlySalary()
        {
            var list = await _dropDownService.GetAllMonthlySalary();

            return Ok(list);
        }

        [HttpGet(nameof(GetAllMotorLength))]
        public async Task<IActionResult> GetAllMotorLength()
        {
            var list = await _dropDownService.GetAllMotorLength();

            return Ok(list);
        }

        [HttpGet(nameof(GetAllMotorMaker))]
        public async Task<IActionResult> GetAllMotorMaker()
        {
            var list = await _dropDownService.GetAllMotorMaker();

            return Ok(list);
        }

        [HttpGet(nameof(GetAllMotorModel))]
        public async Task<IActionResult> GetAllMotorModel()
        {
            var list = await _dropDownService.GetAllMotorModel();

            return Ok(list);
        }

        [HttpGet(nameof(GetAllMotorModelByMakerId))]
        public async Task<IActionResult> GetAllMotorModelByMakerId([FromQuery] int makerId)
        {
            var list = await _dropDownService.GetAllMotorModelByMakerId(makerId);

            return Ok(list);
        }

        [HttpGet(nameof(GetAllMotorModelByMaker))]
        public async Task<IActionResult> GetAllMotorModelByMaker([FromQuery] string maker)
        {
            var list = await _dropDownService.GetAllMotorModelByMaker(maker);

            return Ok(list);
        }

        [HttpGet(nameof(GetAllMotorRegionalSpecs))]
        public async Task<IActionResult> GetAllMotorRegionalSpecs()
        {
            var list = await _dropDownService.GetAllMotorRegionalSpecs();

            return Ok(list);
        }

        [HttpGet(nameof(GetAllMotorTrim))]
        public async Task<IActionResult> GetAllMotorTrim()
        {
            var list = await _dropDownService.GetAllMotorTrim();

            return Ok(list);
        }

        [HttpGet(nameof(GetAllMotorTrimByModelId))]
        public async Task<IActionResult> GetAllMotorTrimByModelId(int modelId)
        {
            var list = await _dropDownService.GetAllMotorTrimByModelId(modelId);

            return Ok(list);
        }

        [HttpGet(nameof(GetAllMotorTrimByModel))]
        public async Task<IActionResult> GetAllMotorTrimByModel(string model)
        {
            var list = await _dropDownService.GetAllMotorTrimByModel(model);

            return Ok(list);
        }

        [HttpGet(nameof(GetAllNationality))]
        public async Task<IActionResult> GetAllNationality()
        {
            var list = await _dropDownService.GetAllNationality();

            return Ok(list);
        }

        [HttpGet(nameof(GetAllNoOfCylinders))]
        public async Task<IActionResult> GetAllNoOfCylinders()
        {
            var list = await _dropDownService.GetAllNoOfCylinders();

            return Ok(list);
        }

        [HttpGet(nameof(GetAllNoticePeriod))]
        public async Task<IActionResult> GetAllNoticePeriod()
        {
            var list = await _dropDownService.GetAllNoticePeriod();

            return Ok(list);
        }

        [HttpGet(nameof(GetAllOperator))]
        public async Task<IActionResult> GetAllOperator()
        {
            var list = await _dropDownService.GetAllOperator();

            return Ok(list);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAllPlateCode()
        //{
        //    var list = await _dropDownService.GetAllPlateCode();

        //    return Ok(list);
        //}

        [HttpPost(nameof(GetAllPlateCode))]
        public async Task<IActionResult> GetAllPlateCode([FromBody] PlateCodeDTO dto)
        {
            var list = await _dropDownService.GetAllPlateCode(dto.plateType, dto.emirate);

            return Ok(list);
        }

        //[HttpGet(nameof(GetAllPlateCodeByPlateTypeId))]
        //public async Task<IActionResult> GetAllPlateCodeByPlateTypeId([FromQuery] int plateTypeId)
        //{
        //    var list = await _dropDownService.GetAllPlateCodeByPlateTypeId(plateTypeId);

        //    return Ok(list);
        //}

        //[HttpGet(nameof(GetAllPlateCodeByPlateType))]
        //public async Task<IActionResult> GetAllPlateCodeByPlateType([FromQuery] string plateType)
        //{
        //    var list = await _dropDownService.GetAllPlateCodeByPlateType(plateType);

        //    return Ok(list);
        //}

        //[HttpGet(nameof(GetAllPlateDesign))]
        //public async Task<IActionResult> GetAllPlateDesign()
        //{
        //    var list = await _dropDownService.GetAllPlateDesign();

        //    return Ok(list);
        //}

        //[HttpGet(nameof(GetAllPlateDesignByPlateTypeId))]
        //public async Task<IActionResult> GetAllPlateDesignByPlateTypeId([FromQuery] int plateTypeId)
        //{
        //    var list = await _dropDownService.GetAllPlateDesignByPlateTypeId(plateTypeId);

        //    return Ok(list);
        //}

        //[HttpGet(nameof(GetAllPlateDesignByPlateType))]
        //public async Task<IActionResult> GetAllPlateDesignByPlateType([FromQuery] string plateType)
        //{
        //    var list = await _dropDownService.GetAllPlateDesignByPlateType(plateType);

        //    return Ok(list);
        //}

        [HttpGet(nameof(GetAllPlateType))]
        public async Task<IActionResult> GetAllPlateType()
        {
            var list = await _dropDownService.GetAllPlateType();

            return Ok(list);
        }

        [HttpGet(nameof(GetAllPlateTypeByEmirateId))]
        public async Task<IActionResult> GetAllPlateTypeByEmirateId([FromQuery] int emirateId)
        {
            var list = await _dropDownService.GetAllPlateTypeByEmirateId(emirateId);

            return Ok(list);
        }

        [HttpGet(nameof(GetAllPlateTypeByEmirate))]
        public async Task<IActionResult> GetAllPlateTypeByEmirate([FromQuery] string emirate)
        {
            var list = await _dropDownService.GetAllPlateTypeByEmirate(emirate);

            return Ok(list);
        }


        [HttpGet(nameof(GetAllTransmission))]
        public async Task<IActionResult> GetAllTransmission()
        {
            var list = await _dropDownService.GetAllTransmission();

            return Ok(list);
        }



        [HttpGet(nameof(GetAllVisaStatus))]
        public async Task<IActionResult> GetAllVisaStatus()
        {
            var list = await _dropDownService.GetAllVisaStatus();

            return Ok(list);
        }

        [HttpGet(nameof(GetAllWheels))]
        public async Task<IActionResult> GetAllWheels()
        {
            var list = await _dropDownService.GetAllWheels();

            return Ok(list);
        }

        [HttpGet(nameof(GetAllWorkExperience))]
        public async Task<IActionResult> GetAllWorkExperience()
        {
            var list = await _dropDownService.GetAllWorkExperience();

            return Ok(list);
        }

        //[HttpGet(nameof(GetAllYear))]
        //public async Task<IActionResult> GetAllYear()
        //{
        //    var list = await _dropDownService.GetAllYear();

        //    return Ok(list);
        //}

        #endregion

    }

    public class PlateCodeDTO
    {
        public string plateType { get; set; }
        public string emirate { get; set; }
    }
}

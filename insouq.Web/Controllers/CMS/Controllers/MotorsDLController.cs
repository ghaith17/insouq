using insouq.Services.IServices;
using insouq.Services.IServices.CMS;
using insouq.Shared.DTOS.CMS;
using insouq.Shared.Utility;
using InsouqWebCMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsouqWebCMS.Controllers
{
    [Authorize(Roles = StaticData.Admin_Role)]
    public class MotorsDLController : Controller
    {
        private readonly ICMSDropDownService _dropDownService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly ISubTypeService _subTypeService;

        public MotorsDLController(
            ICMSDropDownService dropDownService,
            ISubCategoryService subCategoryService,
            ISubTypeService subTypeService)
        {
            _dropDownService = dropDownService;
            _subCategoryService = subCategoryService;
            _subTypeService = subTypeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UsedCars()
        {
            return View();
        }

        public IActionResult ExportCars()
        {
            return View();
        }

        public IActionResult Boats()
        {
            return View();
        } 
        
        public IActionResult Machineries()
        {
            return View();
        }

        public IActionResult Parts()
        {
            return View();
        }

        public IActionResult Bikes()
        {
            return View();
        }

        public async Task<IActionResult> Makers()
        {
            var list = await _dropDownService.GetAllMotorMaker();

            return View(list);
        }

        public async Task<IActionResult> Models()
        {
            var modelsVM = new ModelsVM()
            {
                Makers = await _dropDownService.GetAllMotorMaker(),
                Models = await _dropDownService.GetAllMotorModel()
            };

            return View(modelsVM);
        }

        public async Task<IActionResult> Trims()
        {
            var trimVM = new TrimVM()
            {
                Makers = await _dropDownService.GetAllMotorMaker(),
                Models = await _dropDownService.GetAllMotorModel(),
                Trims = await _dropDownService.GetAllMotorTrim()
            };

            return View(trimVM);
        }

        public async Task<IActionResult> Specifications()
        {
            var list = await _dropDownService.GetAllMotorRegionalSpecs();

            return View(list);
        }

        public async Task<IActionResult> Doors()
        {
            var list = await _dropDownService.GetAllDoor();

            return View(list);
        }

        public async Task<IActionResult> Transmissions()
        {
            var list = await _dropDownService.GetAllTransmission();

            return View(list);
        }

        public async Task<IActionResult> BodyTypes()
        {
            var list = await _dropDownService.GetAllBodyType();

            return View(list);
        }

        public async Task<IActionResult> FuelTypes()
        {
            var list = await _dropDownService.GetAllFuelType();

            return View(list);
        }

        public async Task<IActionResult> NoOfCylinders()
        {
            var list = await _dropDownService.GetAllNoOfCylinders();

            return View(list);
        }

        public async Task<IActionResult> SteeringSides()
        {
            var list = await _dropDownService.GetAllSteeringSide();

            return View(list);
        }

        public async Task<IActionResult> Horsepowers(int categoryId)
        {
            var list = await _dropDownService.GetAllHorsepower(categoryId);

            ViewBag.CategoryId = categoryId;

            return View(list);
        }

        public async Task<IActionResult> Ages(int categoryId)
        {
            var list = await _dropDownService.GetAllAge(categoryId);

            ViewBag.CategoryId = categoryId;

            return View(list);
        }

        public async Task<IActionResult> Usages(int categoryId)
        {
            var list = await _dropDownService.GetAllUsage(categoryId);

            ViewBag.CategoryId = categoryId;

            return View(list);
        }

        public async Task<IActionResult> Conditions(int categoryId)
        {
            var list = await _dropDownService.GetAllCondition(categoryId);

            ViewBag.CategoryId = categoryId;

            return View(list);
        }

        public async Task<IActionResult> Lengths()
        {
            var list = await _dropDownService.GetAllLength();

            return View(list);
        }

        public async Task<IActionResult> Capacities()
        {
            var list = await _dropDownService.GetAllCapacity();

            return View(list);
        }

        public async Task<IActionResult> SellerTypes()
        {
            var list = await _dropDownService.GetAllSellerType();

            return View(list);
        }

        public async Task<IActionResult> MechanicalConditions()
        {
            var list = await _dropDownService.GetAllMechanicalCondition();

            return View(list);
        }

        public async Task<IActionResult> PartsDL()
        {
            var partVM = new PartVM
            {
                SubCategories = await _subCategoryService.GetByCategoryId(StaticData.Parts_ID),
                SubTypes = await _subTypeService.GetByCategoryId(StaticData.Parts_ID),
                Parts = await _dropDownService.GetAllParts()
            };

            return View(partVM);
        }

        public async Task<IActionResult> Colors()
        {
            var list = await _dropDownService.GetAllColor();

            return View(list);
        }

        public async Task<IActionResult> EngineSizes()
        {
            var list = await _dropDownService.GetAllEngineSize();

            return View(list);
        }

        public async Task<IActionResult> Wheels()
        {
            var list = await _dropDownService.GetAllWheels();

            return View(list);
        }

        public async Task<IActionResult> FinalDriveSystems()
        {
            var list = await _dropDownService.GetAllFinalDriveSystem();

            return View(list);
        }

        #region API_CALLS

        #region MAKER_APIS

        [HttpPost]
        public async Task<IActionResult> AddMaker(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddMotorMaker(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Makers));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMaker(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateMotorMaker(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Makers));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteMaker(int id)
        {
            var response = await _dropDownService.DeleteMotorMaker(id);

            return Json(response);
        }

        #endregion

        #region MODEL_APIS

        [HttpPost]
        public async Task<IActionResult> AddModel(RelationTextDropDownDTO model)
        {
            var response = await _dropDownService.AddMotorModel(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Models));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateModel(RelationTextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateMotorModel(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Models));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteModel(int id)
        {
            var response = await _dropDownService.DeleteMotorModel(id);

            return Json(response);
        }

        #endregion

        #region TRIM_APIS

        [HttpGet]
        public async Task<JsonResult> GetModelByMakerId(int makerId)
        {
            var response = await _dropDownService.GetAllMotorModelByMakerId(makerId);

            return Json(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddTrim(RelationTextDropDownDTO model)
        {
            var response = await _dropDownService.AddMotorTrim(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Trims));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTrim(RelationTextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateMotorTrim(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Trims));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteTrim(int id)
        {
            var response = await _dropDownService.DeleteMotorTrim(id);

            return Json(response);
        }

        #endregion

        #region SPECIFICATIONS_APIS

        [HttpPost]
        public async Task<IActionResult> AddSpecification(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddMotorSpecification(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Specifications));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSpecification(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateMotorSpecification(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Specifications));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteSpecification(int id)
        {
            var response = await _dropDownService.DeleteMotorSpecification(id);

            return Json(response);
        }

        #endregion

        #region DOORS_APIS

        [HttpPost]
        public async Task<IActionResult> AddDoors(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddDoors(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Doors));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDoors(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateDoors(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Doors));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteDoors(int id)
        {
            var response = await _dropDownService.DeleteDoors(id);

            return Json(response);
        }

        #endregion

        #region TRANSMISSION_APIS

        [HttpPost]
        public async Task<IActionResult> AddTransmission(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddTransmission(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Transmissions));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTransmission(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateTransmission(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Transmissions));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteTransmission(int id)
        {
            var response = await _dropDownService.DeleteTransmission(id);

            return Json(response);
        }

        #endregion

        #region BODY_TYPE_APIS

        [HttpPost]
        public async Task<IActionResult> AddBodyType(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddBodyType(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(BodyTypes));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBodyType(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateBodyType(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(BodyTypes));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteBodyType(int id)
        {
            var response = await _dropDownService.DeleteBodyType(id);

            return Json(response);
        }

        #endregion

        #region FUEL_TYPE_APIS

        [HttpPost]
        public async Task<IActionResult> AddFuelType(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddFuelType(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(FuelTypes));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFuelType(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateFuelType(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(FuelTypes));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteFuelType(int id)
        {
            var response = await _dropDownService.DeleteFuelType(id);

            return Json(response);
        }

        #endregion

        #region NO_OF_CYLINDERS_APIS

        [HttpPost]
        public async Task<IActionResult> AddNoOfCylinder(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddNoOfCylinder(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(NoOfCylinders));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNoOfCylinder(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateNoOfCylinder(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(NoOfCylinders));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteNoOfCylinder(int id)
        {
            var response = await _dropDownService.DeleteNoOfCylinder(id);

            return Json(response);
        }

        #endregion

        #region STEERING_SIDE_APIS

        [HttpPost]
        public async Task<IActionResult> AddSteeringSide(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddSteeringSide(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(SteeringSides));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSteeringSide(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateSteeringSide(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(SteeringSides));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteSteeringSide(int id)
        {
            var response = await _dropDownService.DeleteSteeringSide(id);

            return Json(response);
        }

        #endregion

        #region HORSE_POWER_APIS

        [HttpPost]
        public async Task<IActionResult> AddHorsepower(CategoryTextDropDownDTO model)
        {
            var response = await _dropDownService.AddHorsepower(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Horsepowers), new { categoryId = model.CategoryId });
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateHorsepower(CategoryTextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateHorsepower(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Horsepowers), new { categoryId = model.CategoryId });
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteHorsepower(int id)
        {
            var response = await _dropDownService.DeleteHorsepower(id);

            return Json(response);
        }

        #endregion

        #region AGE_APIS

        [HttpPost]
        public async Task<IActionResult> AddAge(CategoryTextDropDownDTO model)
        {
            var response = await _dropDownService.AddAge(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Ages), new { categoryId = model.CategoryId });
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAge(CategoryTextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateAge(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Ages), new { categoryId = model.CategoryId });
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteAge(int id)
        {
            var response = await _dropDownService.DeleteAge(id);

            return Json(response);
        }

        #endregion

        #region USAGE_APIS

        [HttpPost]
        public async Task<IActionResult> AddUsage(CategoryTextDropDownDTO model)
        {
            var response = await _dropDownService.AddUsage(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Usages), new { categoryId = model.CategoryId });
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUsage(CategoryTextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateUsage(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Usages), new { categoryId = model.CategoryId });
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteUsage(int id)
        {
            var response = await _dropDownService.DeleteUsage(id);

            return Json(response);
        }

        #endregion

        #region CONDITION_APIS

        [HttpPost]
        public async Task<IActionResult> AddCondition(CategoryTextDropDownDTO model)
        {
            var response = await _dropDownService.AddCondition(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Conditions), new { categoryId = model.CategoryId });
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCondition(CategoryTextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateCondition(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Conditions), new { categoryId = model.CategoryId });
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteCondition(int id)
        {
            var response = await _dropDownService.DeleteCondition(id);

            return Json(response);
        }

        #endregion

        #region LENGTH_APIS

        [HttpPost]
        public async Task<IActionResult> AddLength(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddLength(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Lengths));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLength(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateLength(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Lengths));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteLength(int id)
        {
            var response = await _dropDownService.DeleteLength(id);

            return Json(response);
        }

        #endregion

        #region CAPACITY_APIS

        [HttpPost]
        public async Task<IActionResult> AddCapacity(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddCapacity(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Capacities));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCapacity(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateCapacity(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Capacities));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteCapacity(int id)
        {
            var response = await _dropDownService.DeleteCapacity(id);

            return Json(response);
        }

        #endregion

        #region SELLER_TYPE_APIS

        [HttpPost]
        public async Task<IActionResult> AddSellerType(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddSellerType(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(SellerTypes));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSellerType(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateSellerType(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(SellerTypes));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteSellerType(int id)
        {
            var response = await _dropDownService.DeleteSellerType(id);

            return Json(response);
        }

        #endregion

        #region MECHANICAL_CONDITION_APIS

        [HttpPost]
        public async Task<IActionResult> AddMechanicalCondition(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddMechanicalCondition(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(MechanicalConditions));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMechanicalCondition(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateMechanicalCondition(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(MechanicalConditions));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteMechanicalCondition(int id)
        {
            var response = await _dropDownService.DeleteMechanicalCondition(id);

            return Json(response);
        }

        #endregion

        #region PART_APIS


        [HttpGet]
        public async Task<JsonResult> GetSubTypeBySubCategoryId(int subCategoryId)
        {
            var response = await _subTypeService.GetBySubCategoryId(subCategoryId);

            return Json(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddPart(PartDropDownDTO model)
        {
            var response = await _dropDownService.AddPart(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(PartsDL));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePart(PartDropDownDTO model)
        {
            var response = await _dropDownService.UpdatePart(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(PartsDL));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeletePart(int id)
        {
            var response = await _dropDownService.DeletePart(id);

            return Json(response);
        }

        #endregion

        #region COLOR_APIS

        [HttpPost]
        public async Task<IActionResult> AddColor(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddColor(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Colors));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateColor(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateColor(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Colors));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteColor(int id)
        {
            var response = await _dropDownService.DeleteColor(id);

            return Json(response);
        }

        #endregion

        #region ENGINE_SIZE_APIS

        [HttpPost]
        public async Task<IActionResult> AddEngineSize(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddEngineSize(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(EngineSizes));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEngineSize(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateEngineSize(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(EngineSizes));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteEngineSize(int id)
        {
            var response = await _dropDownService.DeleteEngineSize(id);

            return Json(response);
        }

        #endregion

        #region WHEELS_APIS

        [HttpPost]
        public async Task<IActionResult> AddWheels(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddWheels(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Wheels));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateWheels(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateWheels(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Wheels));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteWheels(int id)
        {
            var response = await _dropDownService.DeleteWheels(id);

            return Json(response);
        }

        #endregion

        #region FINAL_DRIVE_SYSTEM_APIS

        [HttpPost]
        public async Task<IActionResult> AddFinalDriveSystem(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddFinalDriveSystem(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(FinalDriveSystems));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFinalDriveSystem(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateFinalDriveSystem(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(FinalDriveSystems));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteFinalDriveSystem(int id)
        {
            var response = await _dropDownService.DeleteFinalDriveSystem(id);

            return Json(response);
        }

        #endregion

        #endregion
    }
}
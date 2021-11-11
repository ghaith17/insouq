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
    public class NumbersDLController : Controller
    {
        private readonly ICMSDropDownService _dropDownService;

        public NumbersDLController(ICMSDropDownService dropDownService)
        {
            _dropDownService = dropDownService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PlateNumbers()
        {
            return View();
        }

        public IActionResult MobileNumbers()
        {
            return View();
        }

        public async Task<IActionResult> Emirates()
        {
            var list = await _dropDownService.GetAllEmirate();

            return View(list);
        }

        public async Task<IActionResult> Operators()
        {
            var list = await _dropDownService.GetAllOperator();

            return View(list);
        }

        public async Task<IActionResult> MobileCodes()
        {
            var mobileCodesVM = new MobileCodesVM
            {
                Operators = await _dropDownService.GetAllOperator(),
                MobileCodes = await _dropDownService.GetAllMobileNumberCode()
            };

            return View(mobileCodesVM);
        }

        public async Task<IActionResult> NumberPlans()
        {
            var list = await _dropDownService.GetAllNumberPlans();

            return View(list);
        }

        public async Task<IActionResult> PlateTypes()
        {
            var plateTypeVM = new PlateTypeVM
            {
                Emirates = await _dropDownService.GetAllEmirate(),
                PlateTypes = await _dropDownService.GetAllPlateType()
            };

            return View(plateTypeVM);
        }

        public async Task<IActionResult> PlateCodes()
        {
            var plateCodeVM = new PlateCodeVM
            {
                Emirates = await _dropDownService.GetAllEmirate(),
                PlateTypes = await _dropDownService.GetAllPlateType(),
                PlateCodes = await _dropDownService.GetAllPlateCode()
            };

            return View(plateCodeVM);
        }

        #region API_CALLS

        #region EMIRATE_APIS

        [HttpPost]
        public async Task<IActionResult> AddEmirate(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddEmirate(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Emirates));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmirate(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateEmirate(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Emirates));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteEmirate(int id)
        {
            var response = await _dropDownService.DeleteEmirate(id);

            return Json(response);
        }

        #endregion

        #region PLATE_TYPE_APIS

        [HttpPost]
        public async Task<IActionResult> AddPlateType(RelationTextDropDownDTO model)
        {
            var response = await _dropDownService.AddPlateType(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(PlateTypes));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePlateType(RelationTextDropDownDTO model)
        {
            var response = await _dropDownService.UpdatePlateType(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(PlateTypes));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeletePlateType(int id)
        {
            var response = await _dropDownService.DeletePlateType(id);

            return Json(response);
        }

        #endregion

        #region PLATE_CODE_APIS

        [HttpGet]
        public async Task<JsonResult> GetPlateTypeByEmirateId(int emirateId)
        {
            var list = await _dropDownService.GetAllPlateTypeByEmirateId(emirateId);

            return Json(list);
        }

        [HttpPost]
        public async Task<IActionResult> AddPlateCode(RelationValueDropDownDTO model)
        {
            var response = await _dropDownService.AddPlateCode(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(PlateCodes));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePlateCode(RelationValueDropDownDTO model)
        {
            var response = await _dropDownService.UpdatePlateCode(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(PlateCodes));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeletePlateCode(int id)
        {
            var response = await _dropDownService.DeletePlateCode(id);

            return Json(response);
        }

        #endregion

        #region OPERATOR_APIS

        [HttpPost]
        public async Task<IActionResult> AddOperator(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddOperator(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Operators));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOperator(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateOperator(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Operators));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteOperator(int id)
        {
            var response = await _dropDownService.DeleteOperator(id);

            return Json(response);
        }

        #endregion

        #region MOBILE_CODE_APIS

        [HttpPost]
        public async Task<IActionResult> AddMobileCode(RelationValueDropDownDTO model)
        {
            var response = await _dropDownService.AddMobileCode(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(MobileCodes));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMobileCode(RelationValueDropDownDTO model)
        {
            var response = await _dropDownService.UpdateMobileCode(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(MobileCodes));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteMobileCode(int id)
        {
            var response = await _dropDownService.DeleteMobileCode(id);

            return Json(response);
        }

        #endregion

        #region NUMBER_PLAN_APIS

        [HttpPost]
        public async Task<IActionResult> AddNumberPlan(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddNumberPlan(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(NumberPlans));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNumberPlan(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateNumberPlan(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(NumberPlans));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteNumberPlan(int id)
        {
            var response = await _dropDownService.DeleteNumberPlan(id);

            return Json(response);
        }

        #endregion

        #endregion
    }
}
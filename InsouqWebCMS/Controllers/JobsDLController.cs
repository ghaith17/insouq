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
    public class JobsDLController : Controller
    {
        private readonly ICMSDropDownService _dropDownService;

        public JobsDLController(ICMSDropDownService dropDownService)
        {
            _dropDownService = dropDownService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Common()
        {
            return View();
        }

        public IActionResult JobOpening()
        {
            return View();
        }

        public IActionResult JobWanted()
        {
            return View();
        }


        public async Task<IActionResult> JobTypes()
        {
            var list = await _dropDownService.GetAllJobType();

            return View(list);
        }

        public async Task<IActionResult> CareerLevels()
        {
            var list = await _dropDownService.GetAllCareerLevel();

            return View(list);
        }

        public async Task<IActionResult> WorkExperiences()
        {
            var list = await _dropDownService.GetAllWorkExperience();

            return View(list);
        }

        public async Task<IActionResult> EducationLevels()
        {
            var list = await _dropDownService.GetAllEducationLevel();

            return View(list);
        }

        public async Task<IActionResult> EmploymentTypes()
        {
            var list = await _dropDownService.GetAllEmploymentType();

            return View(list);
        }
        
        public async Task<IActionResult> Nationalities()
        {
            var list = await _dropDownService.GetAllNationality();

            return View(list);
        }

        public async Task<IActionResult> Commitments()
        {
            var list = await _dropDownService.GetAllCommitment();

            return View(list);
        }

        public async Task<IActionResult> NoticePeriods()
        {
            var list = await _dropDownService.GetAllNoticePeriod();

            return View(list);
        }

        public async Task<IActionResult> VisaStatus()
        {
            var list = await _dropDownService.GetAllVisaStatus();

            return View(list);
        }

        public async Task<IActionResult> MonthlySalaries()
        {
            var list = await _dropDownService.GetAllMonthlySalary();

            return View(list);
        }


        #region API_CALLS

        #region JOB_TYPE_APIS

        [HttpPost]
        public async Task<IActionResult> AddJobType(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddJobType(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(JobTypes));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateJobType(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateJobType(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(JobTypes));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteJobType(int id)
        {
            var response = await _dropDownService.DeleteJobType(id);

            return Json(response);
        }

        #endregion

        #region CAREER_LEVEL_APIS

        [HttpPost]
        public async Task<IActionResult> AddCareerLevel(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddCareerLevel(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(CareerLevels));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCareerLevel(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateCareerLevel(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(CareerLevels));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteCareerLevel(int id)
        {
            var response = await _dropDownService.DeleteCareerLevel(id);

            return Json(response);
        }

        #endregion

        #region WORK_EXPERINCE_APIS

        [HttpPost]
        public async Task<IActionResult> AddWorkExperience(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddWorkExperience(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(WorkExperiences));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateWorkExperience(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateWorkExperience(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(WorkExperiences));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteWorkExperience(int id)
        {
            var response = await _dropDownService.DeleteWorkExperience(id);

            return Json(response);
        }

        #endregion

        #region EDUCATION_LEVEL_APIS

        [HttpPost]
        public async Task<IActionResult> AddEducationLevel(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddEducationLevel(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(EducationLevels));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEducationLevel(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateEducationLevel(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(EducationLevels));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteEducationLevel(int id)
        {
            var response = await _dropDownService.DeleteEducationLevel(id);

            return Json(response);
        }

        #endregion

        #region EMPLOYMENT_TYPE_APIS

        [HttpPost]
        public async Task<IActionResult> AddEmploymentType(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddEmploymentType(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(EmploymentTypes));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmploymentType(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateEmploymentType(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(EmploymentTypes));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteEmploymentType(int id)
        {
            var response = await _dropDownService.DeleteEmploymentType(id);

            return Json(response);
        }

        #endregion

        #region NATIONALITY_APIS

        [HttpPost]
        public async Task<IActionResult> AddNationality(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddNationality(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Nationalities));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNationality(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateNationality(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Nationalities));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteNationality(int id)
        {
            var response = await _dropDownService.DeleteNationality(id);

            return Json(response);
        }

        #endregion

        #region COMMITMENT_APIS

        [HttpPost]
        public async Task<IActionResult> AddCommitment(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddCommitment(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Commitments));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCommitment(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateCommitment(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Commitments));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteCommitment(int id)
        {
            var response = await _dropDownService.DeleteCommitment(id);

            return Json(response);
        }

        #endregion

        #region NOTICE_PERIOD_APIS

        [HttpPost]
        public async Task<IActionResult> AddNoticePeriod(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddNoticePeriod(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(NoticePeriods));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNoticePeriod(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateNoticePeriod(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(NoticePeriods));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteNoticePeriod(int id)
        {
            var response = await _dropDownService.DeleteNoticePeriod(id);

            return Json(response);
        }

        #endregion

        #region VISA_STATUS_APIS

        [HttpPost]
        public async Task<IActionResult> AddVisaStatus(TextDropDownDTO model)
        {
            var response = await _dropDownService.AddVisaStatus(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(VisaStatus));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateVisaStatus(TextDropDownDTO model)
        {
            var response = await _dropDownService.UpdateVisaStatus(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(VisaStatus));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteVisaStatus(int id)
        {
            var response = await _dropDownService.DeleteVisaStatus(id);

            return Json(response);
        }

        #endregion

        #region MONTHLY_SALARY_APIS

        [HttpPost]
        public async Task<IActionResult> AddMonthlySalary(ValueDropDownDTO model)
        {
            var response = await _dropDownService.AddMonthlySalary(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(MonthlySalaries));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMonthlySalary(ValueDropDownDTO model)
        {
            var response = await _dropDownService.UpdateMonthlySalary(model);

            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(MonthlySalaries));
            }

            return View();
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteMonthlySalary(int id)
        {
            var response = await _dropDownService.DeleteMonthlySalary(id);

            return Json(response);
        }

        #endregion

        #endregion
    }
}
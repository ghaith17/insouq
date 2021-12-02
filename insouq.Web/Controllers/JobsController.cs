using insouq.Services.IServices;
using insouq.Shared.DTOS;
using insouq.Shared.DTOS.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace insouq.Web.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobAdsService _jobAdsService;

        private readonly IUsersService _usersService;

        private readonly IDropDownService _dropDownService;

        public JobsController(IJobAdsService jobAdsService, IUsersService usersService, IDropDownService dropDownService)
        {
            _jobAdsService = jobAdsService;
            _usersService = usersService;
            _dropDownService = dropDownService;
        }

        private int getUserId()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return Int32.Parse(claims.Value);
        }

        public async Task<IActionResult> Add(int categoryId)
        {
            if(categoryId == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.phoneNumber = await _usersService.GetPhoneNumber(getUserId());

            var dto = new JobAdDTO
            {
                CategoryId = categoryId
            };

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(JobAdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var hostName = $"{this.Request.Scheme}://{this.Request.Host}";
            var response = await _jobAdsService.Add(getUserId(), dto, hostName);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);

                return View(dto);
            }


            return RedirectToAction("PackagesSubsicription", "Ads");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddInitalJobWanted(AddInitialJobWanted dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var response = await _jobAdsService.AddInitialJobWanted(getUserId(), dto);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);

                return View(dto);
            }


            return RedirectToAction(nameof(AddJobWanted), new { adId = response.AdId });
        }


        public IActionResult AddJobWanted(int adId)
        {

            var addJobWanted = new AddJobWanted
            {
                AdId = adId,
            };

            return View(addJobWanted);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddJobWanted(AddJobWanted dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var hostName = $"{this.Request.Scheme}://{this.Request.Host}";
            var response = await _jobAdsService.AddJobWanted(getUserId(), dto, hostName);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);

                return View(dto);
            }


            return RedirectToAction("PackagesSubsicription", "Ads");
        }


        public async Task<IActionResult> Update(int adId)
        {
            var ad = await _jobAdsService.GetJobAd(adId);

            if(ad == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(ad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(JobAdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var response = await _jobAdsService.Update(getUserId(), dto);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);

                return View(dto);
            }


            return RedirectToAction("Index", "Home");
        }


        public async Task<PartialViewResult> GetJobWantedData()
        {
            ViewBag.phoneNumber = await _usersService.GetPhoneNumber(getUserId());

            return PartialView("~/Views/Partials/_JobWantedData.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> FilterJobs([FromBody] JobFilters dto)
        {
            var list = await _jobAdsService.FilterJobs(dto);

            return PartialView("~/Views/Partials/_UserAd.cshtml", list);

        }
    }
}

using insouq.Services.IServices;
using insouq.Shared.DTOS.UserDTOS;
using insouq.Shared.Responses;
using insouq.Shared.Utility;
using insouq.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace insouq.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        private readonly IAdsService _adsService;

        private readonly INotificationsService _notificationsService;

        private readonly IWebHostEnvironment _hostEnvironment;

        public UsersController(
            IUsersService usersService,
            IAdsService adsService,
            INotificationsService notificationsService,
            IWebHostEnvironment hostEnvironment)
        {
            _usersService = usersService;
            _adsService = adsService;
            _notificationsService = notificationsService;
            _hostEnvironment = hostEnvironment;
        }

        private int getUserId()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return Int32.Parse(claims.Value);
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> MyList()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            var MylistVM = new MylistVM
            {
                MyAdsCount = await _adsService.GetUserAdsCount(getUserId(), true),
                MyFavoriteCount = await _adsService.GetMyFavoriteAdsCount(getUserId()),
                MySavedSearchCount = await _adsService.GetSavedSearchCount(getUserId())
            };


            return View(MylistVM);
        }

        public async Task<IActionResult> MyFavorites()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public async Task<IActionResult> MyAds()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public async Task<IActionResult> SavedSearches()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            var UserSavedSearches = await _usersService.getSavedSearches(getUserId(), -1);

            return View(UserSavedSearches);
        }

        public async Task<IActionResult> Notifications()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            var notifications =  _notificationsService.GetNotifications(getUserId());

            return View(notifications);
        }




        public async Task<IActionResult> Chat()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public async Task<IActionResult> JobsDashBoard()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public async Task<IActionResult> LiveAds(int userId)
        {
            var user = await _usersService.GetById(userId);

            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var userAdsCount = await _adsService.GetUserAdsCount(userId, false);

            //var userAds = await _adsService.get

            var liveAdsVM = new LiveAdsVM
            {
                User = user,
                NoOfAds = userAdsCount
            };

            return View(liveAdsVM);
        }

        public async Task<IActionResult> MyProfile()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            var userDTO = await _usersService.GetById(getUserId());

            var updateProfileVM = new UpdateProfileVM()
            {
                User = userDTO,
            };

            return View(updateProfileVM);
        }
        [HttpGet]
        public async Task<IActionResult> GetCompanyProfile()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            

            var companyProfile = await _usersService.GetCompanyProfile(getUserId());

            if (companyProfile == null) return Ok(new BaseResponse { IsSuccess = false, Message = "0" });


            return Ok(new BaseResponse { IsSuccess = true, Message = "0" });
        }

        public async Task<IActionResult> MyCompanyProfile(int categoryId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            var companyProfileDTO = await _usersService.GetCompanyProfile(getUserId());

            var updateCompanyProfileVM = new UpdateCompanyProfileVM
            {
                CompanyProfile = companyProfileDTO,
                CategoryId = categoryId
            };


            return View(updateCompanyProfileVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile(UpdateProfileVM model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var updateProfileDTO = new UpdateProfileDTO
            {
                CareerLevel = model.User.CareerLevel,
                CoverNote = model.User.CoverNote,
                CurrentCompany = model.User.CurrentCompany,
                CurrentPosition = model.User.CurrentPosition,
                DefaultLanguage = model.User.DefaultLanguage,
                DefaultLocation = model.User.DefaultLocation,
                DOB = model.User.DOB,
                Education = model.User.Education,
                CurrentLocation = model.User.CurrentLocation,
                FirstName = model.User.FirstName,
                Gender = model.User.Gender,
                LastName = model.User.LastName,
                Nationality = model.User.Nationality,
                HideInfromation = model.User.HideInfromation,
                CVFile = model.CvFile,
                IndustryFile = model.IndustryFile,
                ProfilePictureFile = model.ProfilePictureFile,
            };

            var response = await _usersService.UpdateProfile(getUserId(), updateProfileDTO);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCompanyProfile(UpdateCompanyProfileVM model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


            var updateCompanyProfileDTO = new UpdateCompanyProfileDTO
            {
                ContactNumber = model.CompanyProfile.ContactNumber,
                Description = model.CompanyProfile.Description,
                Email = model.CompanyProfile.Email,
                Location = model.CompanyProfile.Location,
                Name = model.CompanyProfile.Name,
                ProfilePicture = model.ProfilePicture,
                Size = model.CompanyProfile.Size,
                TradeLicenseFile = model.TradeLicenseFile,
                TradeLicenseNumber = model.CompanyProfile.TradeLicenseNumber,
                Website = model.CompanyProfile.Website
            };

            var response = await _usersService.UpdateCompanyProfile(getUserId(), updateCompanyProfileDTO);

            if (!response.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, response.Message);
                return View();
            }

            if (model.CategoryId != 0)
            {
                return RedirectToAction("Add", "Jobs", new { categoryId = model.CategoryId });
            }

            return RedirectToAction("Index", "Home");
        }


        public IActionResult Statistics(int AdId , int type = (int)StatisticTypes.All, int period= (int)StatisticPeriod.All)
        {


            string Statistics = _usersService.getUserStatistics(getUserId(), AdId, (StatisticTypes) type, (StatisticPeriod)period);

            return View("Statistics", Statistics);
        }

       


        #region API_CALLS

        [HttpGet]
        public FileResult ShowFile(string path)
        {
            var paa = path.Replace("/", @"\");

            var webRootPath = _hostEnvironment.ContentRootPath;

            webRootPath = webRootPath.Replace("insouq.Web", "insouq");

            var folderPath = webRootPath + paa;

            var fileStream = new FileStream(folderPath, FileMode.OpenOrCreate, FileAccess.Read);

            return File(fileStream, "application/pdf");
        }

        [HttpGet]
        public async Task<BaseResponse> DeletSavedSearch(string searchId)
        {
            return await _adsService.DeleteSavedSearch(getUserId(), int.Parse(searchId));
        }



        [HttpGet]
        public async Task<BaseResponse> DeleteNotification(int id)
        {
            
            return  _notificationsService.DeleteNotification(id , getUserId());
        }




            #endregion

        }
}
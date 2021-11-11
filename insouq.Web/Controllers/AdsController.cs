using insouq.Services.IServices;
using insouq.Shared.DTOS;
using insouq.Shared.DTOS.Filters;
using insouq.Shared.Utility;
using insouq.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace insouq.Web.Controllers
{
    public class AdsController : Controller
    {
        private readonly ITypeService _typeService;
        private readonly IAdsService _adsService;
        private readonly IUsersService _usersService;
        private readonly ICategoryService _categoryService;
        private readonly INotificationsService _notificationsService;
        public AdsController(
            ITypeService typeService,
            IAdsService adsService,
            IUsersService usersService,
            ICategoryService categoryService,
            INotificationsService notificationsService)
        {
            _adsService = adsService;
            _typeService = typeService;
            _usersService = usersService;
            _categoryService = categoryService;
            _notificationsService = notificationsService;
        }

        private int getUserId()
        {
            try
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                //if(claims != null )
                return Int32.Parse(claims.Value);
            }catch(ArgumentNullException e)
            {
                throw new Exception("User Is Not Logged In");
            }
        }

        public async Task<IActionResult> Categories(int typeId)
        {
            var cateogires = await _categoryService.GetByTypeId(typeId);

            ViewBag.TypeId = typeId;

            return View(cateogires);
        }


        public IActionResult PackagesSubsicription()
        {
            return View();
        }

        public async Task<IActionResult> PostAnAd()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            var typesDTO = await _typeService.GetAll();

            return View(typesDTO);
        }

        public async Task<IActionResult> Details(int adId, int typeId)
        {
            var ad = await _adsService.GetAd(adId, typeId);

            if(ad == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var IsProcessDone = 0;
            var IsInFav = false;
            var loggedInUserId = 0;

            if (User.Identity.IsAuthenticated)
            {
                loggedInUserId = getUserId();
                IsProcessDone = await _adsService.IsDeatilsProcessDone(loggedInUserId, typeId, adId, ad.CategoryId);
                IsInFav = await _adsService.IsInFavorite(loggedInUserId, adId);
            }

            var adDetailsVM = new AdDetailsVM
            {
                Ad = ad,
                User = await _usersService.GetById(ad.UserId),
                SimilarAds = await _adsService.GetSimilarAds(typeId, ad.CategoryId, adId),
                IsInFavorite =IsInFav,
                IsProcessDone = IsProcessDone

            };

            return View(adDetailsVM);
        }

        public async Task<IActionResult> All(int typeId, 
            int categoryId , string searchText ,string location,
            string maxKm, string minKm , string maxYear ,
            string minYear, string maxPrice , string minPrice,
            string maker,string model, string trim
            )
        {
            dynamic ads;

            var cateogryName = "";

            var categoryStatus = 0;
             
            if(categoryId == 0)
            {
                ads = await _adsService.GetAds(typeId, searchText, location, int.Parse(maxKm==null?"0": maxKm), int.Parse(minKm == null ? "0" : minKm), int.Parse(maxYear == null ? "0" : maxYear), int.Parse(minYear == null ? "0" : minYear), double.Parse(maxPrice == null ? "0" : maxPrice), double.Parse(minPrice == null ? "0" : minPrice), maker, model, trim);
            }
            else
            {
                ads = await _adsService.GetAdsByCategoryId(typeId, categoryId, searchText, location, int.Parse(maxKm == null ? "0" : maxKm), int.Parse(minKm == null ? "0" : minKm), int.Parse(maxYear == null ? "0" : maxYear), int.Parse(minYear == null ? "0" : minYear), double.Parse(maxPrice == null ? "0" : maxPrice), double.Parse(minPrice == null ? "0" : minPrice), maker, model, trim);


                var category = await _categoryService.GetById(categoryId);

                if (category != null)
                {
                    cateogryName = category.En_Name;
                    categoryStatus = category.Status;
                }
            }
            

            var allAdsVM = new AllAdsVM
            {
                Ads = ads,
                TypeId = typeId,
                CategoryId = categoryId,
                CategoryName = cateogryName,
                CategoryStatus = categoryStatus,
                SearchLocation = location,
            };

            return View(allAdsVM);
        }


        #region API_CALLS


        
        [HttpPost]
        public async Task<JsonResult> SaveFillters([FromBody] SaveFiltersDTO model)
        {

            try
            {


                int userId = getUserId();

                var response = await _adsService.SaveFillters(userId, model);

                return Json(response);
            }catch (Exception e)
            {
                return  Json(new { error= e.Message.ToString() });
            }
        }


        [HttpPost]
        public async Task<JsonResult> Delete([FromBody] DeleteAdDTO dto)
        {
            var response = await _adsService.DeleteAd(getUserId(), dto.AdId);

            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> MakeAnOffer([FromBody] MakeAnOfferDTO model)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return Json(new { isSuccess = false, message = errors });
            }

            var response = await _adsService.MakeAnOffer(getUserId(), model);

            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> ReportAd([FromBody] ReportDTO model)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return Json(new { isSuccess = false, message = errors });
            }

            var response = await _adsService.ReportAd(getUserId(), model);

            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> AddToFavorite([FromBody] FavoriteAdDTO model)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return Json(new { isSuccess = false, message = errors });
            }

            var response = await _adsService.AddToFavorite(getUserId(), model);

            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> RemoveFromFavorite([FromBody] FavoriteAdDTO model)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return Json(new { isSuccess = false, message = errors });
            }

            var response = await _adsService.RemoveFromFavorite(getUserId(), model);

            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> ApplyForJob([FromForm] ApplyJobDTO model)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(Environment.NewLine,
                    ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

                return Json(new { isSuccess = false, message = errors });
            }

            var response = await _adsService.ApplyForJob(getUserId(), model);

            return Json(response);
        }

        [HttpGet]
        public async Task<PartialViewResult> GetMyAds(int typeId)
        {
            var ads = await _adsService.GetUserAds(getUserId(), typeId, true);

            return PartialView("~/Views/Partials/_MyAd.cshtml", ads);
        }

        [HttpGet]
        public async Task<PartialViewResult> GetUserAds(int userId, int typeId)
        {
            var ads = await _adsService.GetUserAds(userId, typeId, false);

            return PartialView("~/Views/Partials/_UserAd.cshtml", ads);
        }

        [HttpGet]
        public async Task<PartialViewResult> GetMyFavoriteAds(int typeId)
        {
            var ads = await _adsService.GetMyFavoriteAds(getUserId(), typeId);

            return PartialView("~/Views/Partials/_MyFavorite.cshtml", ads);
        }

        [HttpGet]
        public async Task<PartialViewResult> GetMySearches(int typeId)
        {
            var srearches = await _usersService.getSavedSearches(getUserId(), typeId);

            return PartialView("~/Views/Partials/_SavedSearchCards.cshtml", srearches);
        }

        [HttpGet]
        public async Task<JsonResult> NotiCont()
        {
            try
            {
                var UserId = getUserId();

                var response = _notificationsService.HasUnOpendNotifications(UserId);

                return Json(new { isSuccess = response });
            }catch(Exception e)
            {
                return Json(new { isSuccess = false });
            }
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteAdPhoto(int id)
        {
            var response = await _adsService.DeleteAdPhoto(id);

            return Json(response);
        }


        #endregion
    }
}

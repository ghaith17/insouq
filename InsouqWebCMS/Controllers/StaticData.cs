using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using insouq.Services;
using insouq.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using insouq.Shared.Utility;
using insouq.Models.StaticData;
using InsouqWebCMS.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace InsouqWebCMS.Controllers
{
    [Authorize(Roles = StaticData.Admin_Role)]
    public class WebsiteStaticData : Controller
    {
        private IStaticDataService staticDataService { get; set; }

        private readonly IWebHostEnvironment _hostEnvironment;


        public WebsiteStaticData(IStaticDataService _staticDataService, IWebHostEnvironment hostEnvironment)
        {
            staticDataService = _staticDataService;
            _hostEnvironment = hostEnvironment;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AboutUs()
        {
            var model = await staticDataService.GetAboutUs();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AboutUs(AboutUs model)
        {
            await staticDataService.UpsertAboutUs(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> AllFAQS()
        {
            var model = await staticDataService.GetListOfFAQS();
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> FAQS(int id)
        {
            var model = await staticDataService.GetFAQS(id);
            return View(model);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteFAQS(int id)
        {
            var model =await staticDataService.DeleteFAQS(id);
            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> FAQS(FAQS model)
        {
            await staticDataService.UpsertFAQS(model);
            return RedirectToAction(nameof(AllFAQS));
        }


        [HttpGet]
        public async Task<IActionResult> AllHIW()
        {

            var model = await staticDataService.GettHIW();
           
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> HIW()
        {

            var model = await staticDataService.GettHIW();
            UpsertHIWVM m = new UpsertHIWVM()
            {
                HIW = model,

            };
            return View(m);
        }

        [HttpPost]
        public async Task<IActionResult> HIW(UpsertHIWVM model)
        {

            var webRootPath = _hostEnvironment.WebRootPath;

            var folderPath = Path.Combine(webRootPath, "images");

            if (model.File != null)
            {
                var imageUrl1 = await HelperFunctions.UploadImage(folderPath, model.File, "");

                model.HIW.img1Url= imageUrl1;
            }

            if (model.File2 != null)
            {
                var imageUrl2 = await HelperFunctions.UploadImage(folderPath, model.File2, "");

                model.HIW.img2Url = imageUrl2;
            }

            await staticDataService.UpsertHIW(model.HIW);
            return RedirectToAction(nameof(AllHIW));
        }


        [HttpGet]
        public async Task<IActionResult> Banner()
        {
            var model = await staticDataService.GetBanner();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpsertBanner()
        {
            var vm = new UpsertBannerVM()
            {
                Banner = await staticDataService.GetBanner()
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> UpsertBanner(UpsertBannerVM upsertBannerVM)
        {
            var webRootPath = _hostEnvironment.WebRootPath;

            var folderPath = Path.Combine(webRootPath, "images");

            if (upsertBannerVM.File != null)
            {
                var imageUrl = await HelperFunctions.UploadImage(folderPath, upsertBannerVM.File, "");

                upsertBannerVM.Banner.ImgUrl = imageUrl;
            }


            await staticDataService.UpsertBanner(upsertBannerVM.Banner);

            return RedirectToAction(nameof(Banner));
        }


        [HttpGet]
        public async Task<IActionResult> AdvertisorImages()
        {
            var model = await staticDataService.GetAdvertisorImages();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpsertAdvertisorImages()
        {
            var upsertAdvirtisorImagesVM = new UpsertAdvirtisorImagesVM()
            {
                AdvertisorImages = await staticDataService.GetAdvertisorImages()
            };

            return View(upsertAdvirtisorImagesVM);
        }

        [HttpPost]
        public async Task<IActionResult> UpsertAdvertisorImages(UpsertAdvirtisorImagesVM upsertAdvirtisorImagesVM)
        {
            var webRootPath = _hostEnvironment.WebRootPath;

            var folderPath = Path.Combine(webRootPath, "images");

            if (upsertAdvirtisorImagesVM.Image1 != null)
            {
                var imageUrl1 = await HelperFunctions.UploadImage(folderPath, upsertAdvirtisorImagesVM.Image1, "");

                upsertAdvirtisorImagesVM.AdvertisorImages.ImageUrl1 = imageUrl1;
            }

            if (upsertAdvirtisorImagesVM.Image2 != null)
            {
                var imageUrl2 = await HelperFunctions.UploadImage(folderPath, upsertAdvirtisorImagesVM.Image2, "");

                upsertAdvirtisorImagesVM.AdvertisorImages.ImageUrl2 = imageUrl2;
            }

            if (upsertAdvirtisorImagesVM.File1 != null)
            {
                var fileUrl1 = await HelperFunctions.UploadImage(folderPath, upsertAdvirtisorImagesVM.File1, "");

                upsertAdvirtisorImagesVM.AdvertisorImages.FileUrl1 = fileUrl1;
            }

            if (upsertAdvirtisorImagesVM.File2 != null)
            {
                var fileUrl2 = await HelperFunctions.UploadImage(folderPath, upsertAdvirtisorImagesVM.File2, "");

                upsertAdvirtisorImagesVM.AdvertisorImages.FileUrl2 = fileUrl2;
            }


            await staticDataService.UpsertAdvertisorImages(upsertAdvirtisorImagesVM.AdvertisorImages);

            return RedirectToAction(nameof(AdvertisorImages));
        }

        [HttpGet]
        public async Task<IActionResult> UpsertAdvertisingReasons()
        {
            var model = await staticDataService.GetAdvertisingReasons();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpsertAdvertisingReasons(AdvertisingReason advertisingReason)
        {
            var model = await staticDataService.UpsertAdvertisingReasons(advertisingReason);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpsertSme()
        {
            var model = await staticDataService.GetSMEs();

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> UpsertSme(SME sme)
        {
            var model = await staticDataService.UpsertSMEs(sme);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Advertisings()
        {
            var model = await staticDataService.GetListOfAdvertisings();

            return View(model);
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteAdvertisings(int id)
        {
            var model = await staticDataService.DeleteAdvertisings(id);

            return Json(model);
        }

        public IActionResult Adv()
        {
            return View();
        }

    }
}

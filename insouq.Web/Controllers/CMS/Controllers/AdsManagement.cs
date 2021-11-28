using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using insouq.Services;
using insouq.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using insouq.Shared.Utility;

namespace InsouqWebCMS.Controllers
{
    [Authorize(Roles = StaticData.Admin_Role)]
    public class AdsManagement : Controller
    {
        private ICMSAds _CMSAds { get; set; }

        public AdsManagement(ICMSAds CMSAds)
        {
            _CMSAds = CMSAds;
        }


        public IActionResult Index()
        {
            var PendingAds = _CMSAds.GetAllAds();
            return View(PendingAds);
        }

        public async Task<IActionResult> Gallary(int adId)
        {
            var pictures = await _CMSAds.GetAdPictures(adId);

            return View(pictures);
        }

        public async Task<IActionResult> Details(int adId, int typeId)
        {
            var ad = await _CMSAds.GetAd(adId, typeId);

            return View(ad);
        }


        #region Apis

        [HttpGet]
        public async Task<bool> RejectAd(int AdId)
        {
            var result = await _CMSAds.updateAdStatus(AdId, 4);

            return result;
        }

        [HttpGet]
        public async Task<bool> DeleteAd(int AdId)
        {
            var result = await _CMSAds.updateAdStatus(AdId, 3);

            return result;
        }

        [HttpGet]
        public async Task<bool> AcceptAdd(int AdId)
        {
            var result = await _CMSAds.updateAdStatus(AdId, 1);

            return result;
        }

        #endregion
    }
}

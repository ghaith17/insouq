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



        #region Apis

        [HttpGet]
        public bool RejectAd(int AdId)
        {
          return  _CMSAds.updateAdStatus(AdId, 4);
        }

        [HttpGet]
        public bool DeleteAd(int AdId)
        {
            return _CMSAds.updateAdStatus(AdId, 3);
        }

        [HttpGet]
        public bool AcceptAdd(int AdId)
        {
            return _CMSAds.updateAdStatus(AdId, 1);
        }

        #endregion
    }
}

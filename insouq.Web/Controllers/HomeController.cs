using insouq.Services.IServices;
using insouq.Shared.DTOS;
using insouq.Shared.Utility;
using insouq.Web.Models;
using insouq.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace insouq.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsersService _usersService;
        private readonly ITypeService _typeService;
        private readonly IAdsService _adsService;

        public HomeController(
            ILogger<HomeController> logger,
            IUsersService usersService,
            ITypeService typeService,
            IAdsService adsService)
        {
            _logger = logger;
            _usersService = usersService;
            _typeService = typeService;
            _adsService = adsService;
        }

        private int getUserId()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return Int32.Parse(claims.Value);
        }

        [Route("/google2d2c91937a23cb3f.html")]
        public IActionResult googleVer()
        {
            return View();
        }
       
        public async Task<IActionResult> Index()
        {

            var motorsAds = await _adsService.GetLatestAds(StaticData.Motors_ID);
            var electronicAds = await _adsService.GetLatestAds(StaticData.Electronics_ID);
            var propertyAds = await _adsService.GetLatestAds(StaticData.Properties_ID);

            var jobsAds = await _adsService.GetLatestAds(StaticData.Jobs_ID);
            var serviceAds = await _adsService.GetLatestAds(StaticData.Services_ID);
            var businessAds = await _adsService.GetLatestAds(StaticData.Business_ID);
            var classifiedAds = await _adsService.GetLatestAds(StaticData.Classifieds_ID);
            var numberAds = await _adsService.GetLatestAds(StaticData.Numbers_ID);

            var homeVM = new HomeVM()
            {
                Types = await _typeService.GetAllWithCategories(),
                MotorsAds = motorsAds,
                ElectronicAds = electronicAds,
                PropertyAds = propertyAds,
                BusinessAds = businessAds,
                ClassifiedAds = classifiedAds,
                JobsAds = jobsAds,
                NumbersAds = numberAds,
                ServicesAds = serviceAds
            };

            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult AboutInsouq()
        {
            return View();
        }

        public IActionResult Advertisors()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult FAQ()
        {
            return View();
        }

        public IActionResult HowItWorks()
        {
            return View();
        }

        public IActionResult PrivacyPolicy()
        {
            return View();
        }

        public IActionResult SellingGuidelines()
        {
            return View();
        }

        public IActionResult Terms()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

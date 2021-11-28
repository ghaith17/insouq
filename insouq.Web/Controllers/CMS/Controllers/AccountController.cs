using insouq.Models.IdentityConfiguration;
using insouq.Services.IServices.CMS;
using insouq.Shared.DTOS.AccountsDTOS;
using insouq.Shared.Utility;
using InsouqWebCMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsouqWebCMS.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICMSAccountsService _accountsService;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public AccountController(ICMSAccountsService accountsService, SignInManager<ApplicationUser> signInManager)
        {
            _accountsService = accountsService;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Json(true);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var response = await _accountsService.Login(loginVM.Username, loginVM.Password);

            if (!response.IsSuccess)
            {
                ViewBag.ErrorMessage = response.Message;

                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        //[Authorize(Roles = StaticData.Admin_Role)]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Authorize(Roles = StaticData.Admin_Role)]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var response = await _accountsService.ChangePassword(38, changePasswordDTO);

            if (!response.IsSuccess)
            {
                ViewBag.ErrorMessage = response.Message;

                return View();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}

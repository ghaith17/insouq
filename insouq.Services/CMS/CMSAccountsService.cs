using Google.Apis.Auth;
using insouq.Configuration;
using insouq.EntityFramework;
using insouq.Models;
using insouq.Models.IdentityConfiguration;
using insouq.Services.IServices;
using insouq.Shared.DTOS.AccountsDTOS;
using insouq.Shared.Responses;
using insouq.Shared.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using insouq.Services.IServices.CMS;

namespace insouq.Services.CMS
{
    public class CMSAccountsService : ICMSAccountsService
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;


        public CMSAccountsService(
            ApplicationDbContext db,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole<int>> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<BaseResponse> Login(string username, string password)
        {
            var response = new BaseResponse();

            try
            {
                var applicationUser = await _db.ApplicationUsers.AsNoTracking().FirstOrDefaultAsync(u => u.UserName == username);

                if (applicationUser == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Please check your information";
                    return response;
                }

                if (!await _userManager.IsInRoleAsync(applicationUser, StaticData.Admin_Role))
                {
                    response.IsSuccess = false;
                    response.Message = "Please check your information";
                    return response;
                }

                var result = await _signInManager
                    .PasswordSignInAsync(applicationUser.UserName, password, true, lockoutOnFailure: false);

                if (!result.Succeeded)
                {
                    response.IsSuccess = false;
                    response.Message = "Please check your information";
                    return response;
                }

                response.IsSuccess = true;
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }


        public async Task<BaseResponse> ChangePassword(int userId, ChangePasswordDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var user = await _userManager.FindByIdAsync(userId.ToString());

                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

                if (!result.Succeeded)
                {
                    response.IsSuccess = false;
                    response.Message = result.Errors.First().Description;
                    return response;
                }

                response.IsSuccess = true;
                return response;
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = StaticData.ServerError_Message;
                return response;
            }


        }
    }
}

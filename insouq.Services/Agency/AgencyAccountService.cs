using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using insouq.EntityFramework;
using insouq.Models;
using insouq.Models.IdentityConfiguration;
using insouq.Services.IServices.Agency;
using insouq.Shared.DTOS.AgencyDTOS;
using insouq.Shared.Responses;
using insouq.Shared.Utility;
using Microsoft.AspNetCore.Identity;

namespace insouq.Services.Agency
{
    public class AgencyAccountService : IAgencyAccountService
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        public AgencyAccountService(
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

        public async Task<AuthenticationResponse> RegisterMotors(RegisterMotorsDTO model)
        {
            var response = new AuthenticationResponse();

            try
            {
                var identityUser = new ApplicationUser()
                {
                    Email = model.Email,
                    UserName = model.Email,
                    PhoneNumber = model.MobileNumber,
                };

                var result = await _userManager.CreateAsync(identityUser, model.Password);

                if (!result.Succeeded)
                {
                    response.IsSuccess = false;
                    response.Message = result.Errors.First().Description;
                    response.Status = AuthStatus.INFORMATION_ERROR;
                    return response;
                }

                var user = new User()
                {
                    Id = identityUser.Id,
                    Email = model.Email,
                    FirstName = model.CompanyName,
                    LastName = model.CompanyName,
                    MobileNumber = model.MobileNumber,
                    ProfilePicture = StaticData.DefaultUser_Image,
                    MemberSince = DateTime.Now
                };

                await _db.Users.AddAsync(user);

                if (!await _roleManager.RoleExistsAsync(StaticData.AgentManager_Role))
                {
                    await _roleManager.CreateAsync(new IdentityRole<int>(StaticData.AgentManager_Role));
                }

                await _userManager.AddToRoleAsync(identityUser, StaticData.AgentManager_Role);
               
                var agency = new insouq.Models.Agency()
                {
                    
                    Name = model.CompanyName,
                    CompanyTradeLicenseCopy = model.TradeLicenseCopyPath,
                    TradeLicenseNumber = model.LicenseIssuingAuthority,
                    Location = model.ShowroomAddress

                };
                await _db.Agencies.AddAsync(agency);

                var token = "";


                response.IsSuccess = true;
                response.Token = token;
                response.UserId = user.Id;
                response.PhoneNumber = user.MobileNumber;
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }
    }
}

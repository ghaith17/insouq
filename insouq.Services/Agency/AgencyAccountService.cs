using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using insouq.Configuration;
using insouq.EntityFramework;
using insouq.Models;
using insouq.Models.IdentityConfiguration;
using insouq.Services.IServices.Agency;
using insouq.Shared.DTOS.AgencyDTOS;
using insouq.Shared.Responses;
using insouq.Shared.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace insouq.Services.Agency
{
    public class AgencyAccountService : IAgencyAccountService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly JwtConfig _jwtConfig;
        private readonly IWebHostEnvironment _hostEnvironment;
        public AgencyAccountService(
            ApplicationDbContext db,
            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole<int>> roleManager,
            IOptionsMonitor<JwtConfig> optionsMonitor,
            IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtConfig = optionsMonitor.CurrentValue;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<AuthenticationResponse> RegisterMotors(RegisterMotorsDTO model)
        {
            var response = new AuthenticationResponse();

            try
            {
                var identityUser = new ApplicationUser()
                {
                    Id=_db.Users.Count()+1,
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
                    var identityRole = new IdentityRole<int>(StaticData.AgentManager_Role);
                    identityRole.Id = _db.UserRoles.Count() + 1;
                    await _roleManager.CreateAsync(identityRole);
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

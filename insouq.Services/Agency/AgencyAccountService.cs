using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using insouq.Configuration;
using insouq.EntityFramework;
using insouq.Models;
using insouq.Models.IdentityConfiguration;
using insouq.Services.IServices.Agency;
using insouq.Shared.DTOS.AccountsDTOS;
using insouq.Shared.DTOS.AgencyDTOS;
using insouq.Shared.Responses;
using insouq.Shared.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace insouq.Services.Agency
{
    public class AgencyAccountService : IAgencyAccountService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtConfig _jwtConfig;
        private readonly IWebHostEnvironment _hostEnvironment;
        public AgencyAccountService(
            ApplicationDbContext db,
            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole<int>> roleManager,
              SignInManager<ApplicationUser> signInManager,
            IOptionsMonitor<JwtConfig> optionsMonitor,
            IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _jwtConfig = optionsMonitor.CurrentValue;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<AuthenticationResponse> RegisterMotors(RegisterAgencyDTO model)
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
                    //var identityRole = new IdentityRole<int>(StaticData.AgentManager_Role);
                    //identityRole.Id = _db.UserRoles.Count() + 1;
                    //await _roleManager.CreateAsync(identityRole);
                    await _roleManager.CreateAsync(new IdentityRole<int>(StaticData.AgentManager_Role));
                }

                await _userManager.AddToRoleAsync(identityUser, StaticData.AgentManager_Role);
               
                var agency = new insouq.Models.Agency()
                {
                    
                    Name = model.CompanyName,
                    CompanyTradeLicenseCopy = model.TradeLicenseCopyPath,
                    TradeLicenseNumber = model.LicenseIssuingAuthority,
                    Location = model.ShowroomAddress,
                    MemberSince = DateTime.Now,
                    Type= "Motors"

                };
                await _db.Agency.AddAsync(agency);
                var agent = new insouq.Models.Agent()
                {
                    Id=user.Id,
                    Agency=agency,
                    AgencyId=agency.Id,
                    Gender=user.Gender,
                    Name=user.FirstName,
                    MobileNumber=user.MobileNumber,
                    Email=user.Email,
                    WorkNumber=user.MobileNumber,
                    Picture=user.ProfilePicture,
                    BrokerNo=agency.BrokerNo
                };
                await _db.Agent.AddAsync(agent);


                await _db.SaveChangesAsync();

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
                response.Message =ex.Message; ;
                return response;
            }
        }
        public async Task<AuthenticationResponse> RegisterPropoerty(RegisterAgencyDTO model)
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
                    //var identityRole = new IdentityRole<int>(StaticData.AgentManager_Role);
                    //identityRole.Id = _db.UserRoles.Count() + 1;
                    //await _roleManager.CreateAsync(identityRole);
                    await _roleManager.CreateAsync(new IdentityRole<int>(StaticData.AgentManager_Role));
                }

                await _userManager.AddToRoleAsync(identityUser, StaticData.AgentManager_Role);

                var agency = new insouq.Models.Agency()
                {

                    Name = model.CompanyName,
                    CompanyTradeLicenseCopy = model.TradeLicenseCopyPath,
                    TradeLicenseNumber = model.LicenseIssuingAuthority,
                    Location = model.ShowroomAddress,
                    Type= "Propoerty",
                    BrokerCardCopy=model.BrokerIdCopyPath,
                    BrokerNo=model.BrokerNo,
                    MemberSince=DateTime.Now
                };
                await _db.Agency.AddAsync(agency);

                var agent = new insouq.Models.Agent()
                {
                    Id=user.Id,
                    Agency = agency,
                    AgencyId = agency.Id,
                    Gender = user.Gender,
                    Name = user.FirstName,
                    MobileNumber = user.MobileNumber,
                    Email = user.Email,
                    WorkNumber = user.MobileNumber,
                    Picture = user.ProfilePicture,
                    BrokerNo = agency.BrokerNo
                };
                await _db.Agent.AddAsync(agent);
                await _db.SaveChangesAsync();

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
                response.Message = StaticData.ServerError_Message; ;
                return response;
            }
        }
        public async Task<AuthenticationResponse> Login(LoginDTO model)
        {
            //var response = new AuthenticationResponse();

            //try
            //{
            //    var applicationUser = await _db.ApplicationUsers.AsNoTracking()
            //        .FirstOrDefaultAsync(u => u.Email == model.EmailOrPhone || u.PhoneNumber == model.EmailOrPhone);


            //    if (applicationUser == null)
            //    {
            //        response.IsSuccess = false;
            //        response.Message = "Please check your information";
            //        response.Status = AuthStatus.INFORMATION_ERROR;
            //        return response;
            //    }

            //    if (!await _userManager.IsInRoleAsync(applicationUser, StaticData.AgentManager_Role))
            //    {
            //        response.IsSuccess = false;
            //        response.Message = "Please check your information";
            //        return response;
            //    }

            //    var user = await _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Status != 3 && u.Email==applicationUser.Email);

            //    if (user == null)
            //    {
            //        response.IsSuccess = false;
            //        response.Message = "Please check your information";
            //        return response;
            //    }


            //    var isCorrect = await _userManager.CheckPasswordAsync(applicationUser, model.Password);

            //    if (!isCorrect)
            //    {
            //        response.IsSuccess = false;
            //        response.Message = "Please check your information";
            //        response.Status = AuthStatus.ERROR_MESSAGE;

            //        return response;
            //    }
            //    var agent = await _db.Agent.AsNoTracking().FirstOrDefaultAsync(u => u.Email == user.Email);
            //    if (agent == null)
            //    {
            //        response.IsSuccess = false;
            //        response.Message = "this account does not register as agent";
            //        response.Status = AuthStatus.ERROR_MESSAGE;

            //        return response;
            //    }
            //    var agency = await _db.Agency.AsNoTracking().FirstOrDefaultAsync(u => u.Id == agent.AgencyId);
            //    if (agency == null)
            //    {
            //        response.IsSuccess = false;
            //        response.Message = "Agency related to this account not found";
            //        response.Status = AuthStatus.ERROR_MESSAGE;

            //        return response;
            //    }

            //    if (agency.Status==StaticData.Waiting)
            //    {
            //        response.IsSuccess = false;
            //        response.Message = "Agency not confirmed";
            //        response.Status = AuthStatus.MOBILE_NUMBER_NOT_CONFIRMED;
            //        response.UserId = applicationUser.Id;
            //        response.PhoneNumber = applicationUser.PhoneNumber;
            //        return response;
            //    }


            //    var token = HelperFunctions.GenerateJwtToken(applicationUser.Id, applicationUser.Email, _jwtConfig.Secret);

            //    response.IsSuccess = true;
            //    response.Token = token;
            //    response.UserId = applicationUser.Id;
            //    response.Status = AuthStatus.SUCCESS;
            //    return response;

            //}
            //catch (Exception ex)
            //{
            //    response.IsSuccess = false;
            //    response.Message = ex.Message;
            //    response.Status = AuthStatus.ERROR_MESSAGE;
            //    return response;
            //}
            var response = new AuthenticationResponse();

            try
            {
                var applicationUser = await _db.ApplicationUsers.AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Email == model.EmailOrPhone || u.PhoneNumber == model.EmailOrPhone);


                if (applicationUser == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Please check your information";
                    response.Status = AuthStatus.INFORMATION_ERROR;
                    return response;
                }

                if (!await _userManager.IsInRoleAsync(applicationUser, StaticData.AgentManager_Role))
                {
                    response.IsSuccess = false;
                    response.Message = "Please check your information";
                    return response;
                }

                var user = await _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Status != 3 && u.Email == applicationUser.Email);

                if (user == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Please check your information";
                    return response;
                }

                //if (!applicationUser.PhoneNumberConfirmed)
                //{
                //    var sendSmsDto = new SendSmsCodeDTO
                //    {
                //        MobileNumber = applicationUser.PhoneNumber,
                //        UserId = applicationUser.Id
                //    };

                //    var sendSmsResponse = await SendSmsCode(sendSmsDto);

                //    response.IsSuccess = false;
                //    response.Message = "Phone Number not confirmed";
                //    response.Status = AuthStatus.MOBILE_NUMBER_NOT_CONFIRMED;
                //    response.UserId = applicationUser.Id;
                //    response.PhoneNumber = applicationUser.PhoneNumber;
                //    return response;
                //}
                var agent = await _db.Agent.AsNoTracking().FirstOrDefaultAsync(u => u.Email == user.Email);
                if (agent == null)
                {
                    response.IsSuccess = false;
                    response.Message = "this account does not register as agent";
                    response.Status = AuthStatus.ERROR_MESSAGE;

                    return response;
                }
                var agency = await _db.Agency.AsNoTracking().FirstOrDefaultAsync(u => u.Id == agent.AgencyId);
                if (agency == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Agency related to this account not found";
                    response.Status = AuthStatus.ERROR_MESSAGE;

                    return response;
                }

                if (agency.Status == StaticData.Waiting)
                {
                    response.IsSuccess = false;
                    response.Message = "Agency not confirmed";
                    response.Status = AuthStatus.MOBILE_NUMBER_NOT_CONFIRMED;
                    response.UserId = applicationUser.Id;
                    response.PhoneNumber = applicationUser.PhoneNumber;
                    return response;
                }
                var result = await _signInManager
                    .PasswordSignInAsync(applicationUser.Email, model.Password, true, lockoutOnFailure: false);

                if (!result.Succeeded)
                {
                    response.IsSuccess = false;
                    response.Message = "Please check your information";
                    response.Status = AuthStatus.ERROR_MESSAGE;
                    return response;
                }

                response.IsSuccess = true;
                response.Status = AuthStatus.SUCCESS;
                return response;
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = StaticData.ServerError_Message;
                response.Status = AuthStatus.ERROR_MESSAGE;
                return response;
            }
        }

        public async Task<Models.Agency> GetAgencyByUserId(int userId)
        {


            try
            {
               
                var user = await _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);

                if (user == null)
                {
                    return null;
                }



                var agent = await _db.Agent.AsNoTracking().FirstOrDefaultAsync(u => u.Email == user.Email);
                if (agent == null)
                {
                    return null;
                }
                var agency = await _db.Agency.AsNoTracking().FirstOrDefaultAsync(u => u.Id == agent.AgencyId);
                if (agency == null)
                {
                    return null;
                }
                return agency;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<Models.User> GetUserById(int userId)
        {


            try
            {

                var user = await _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);

                if (user == null)
                {
                    return null;
                }


                return user;
              
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Models.Agent> GetAgentByUserId(int userId)
        {


            try
            {
                var user = await _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);

                if (user == null)
                {
                    return null;
                }



                var agent = await _db.Agent.AsNoTracking().FirstOrDefaultAsync(u => u.Email == user.Email);
                if (agent == null)
                {
                    return null;
                }
                return agent;

            }
            catch (Exception)
            {
                return null;
            }
        }



    }
}

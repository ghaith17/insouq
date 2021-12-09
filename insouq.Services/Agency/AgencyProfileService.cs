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
    public class AgencyProfileService : IAgencyProfileService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtConfig _jwtConfig;
        private readonly IWebHostEnvironment _hostEnvironment;
        public AgencyProfileService(
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
        public async Task<AuthenticationResponse> RegisterAgent(AgentDTO model)
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
                    FirstName = model.Name,
                    LastName = model.Name,
                    MobileNumber = model.MobileNumber,
                    ProfilePicture = StaticData.DefaultUser_Image,
                    MemberSince = DateTime.Now
                };

                await _db.Users.AddAsync(user);

                if (!await _roleManager.RoleExistsAsync(StaticData.Agent_Role))
                {

                    await _roleManager.CreateAsync(new IdentityRole<int>(StaticData.Agent_Role));
                }

                await _userManager.AddToRoleAsync(identityUser, StaticData.Agent_Role);



                var agent = new insouq.Models.Agent()
                {
                    Id = user.Id,
                    AgencyId = model.Agency.Id,
                    //Agency = model.Agency,
                    
                    Gender = user.Gender,
                    Name = user.FirstName,
                    MobileNumber = user.MobileNumber,
                    Email = user.Email,
                    WorkNumber = model.WorkNumber,
                    Picture = user.ProfilePicture,
                    BrokerNo = model.BrokerNo
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
        //public async Task<AuthenticationResponse> RegisterMotorsAgent(AgentDTO model)
        //{
        //    var response = new AuthenticationResponse();

        //    try
        //    {
        //        var identityUser = new ApplicationUser()
        //        {

        //            Email = model.Email,
        //            UserName = model.Email,
        //            PhoneNumber = model.MobileNumber,
        //        };

        //        var result = await _userManager.CreateAsync(identityUser, model.Password);

        //        if (!result.Succeeded)
        //        {
        //            response.IsSuccess = false;
        //            response.Message = result.Errors.First().Description;
        //            response.Status = AuthStatus.INFORMATION_ERROR;
        //            return response;
        //        }

        //        var user = new User()
        //        {
        //            Id = identityUser.Id,
        //            Email = model.Email,
        //            FirstName = model.Name,
        //            LastName = model.Name,
        //            MobileNumber = model.MobileNumber,
        //            ProfilePicture = StaticData.DefaultUser_Image,
        //            MemberSince = DateTime.Now
        //        };

        //        await _db.Users.AddAsync(user);

        //        if (!await _roleManager.RoleExistsAsync(StaticData.Agent_Role))
        //        {

        //            await _roleManager.CreateAsync(new IdentityRole<int>(StaticData.Agent_Role));
        //        }

        //        await _userManager.AddToRoleAsync(identityUser, StaticData.Agent_Role);



        //        var agent = new insouq.Models.Agent()
        //        {
        //            Id = user.Id,
        //            Agency = model.Agency,
        //            AgencyId = model.Agency.Id,
        //            Gender = user.Gender,
        //            Name = user.FirstName,
        //            MobileNumber = user.MobileNumber,
        //            Email = user.Email,
        //            WorkNumber = model.WorkNumber,
        //            Picture = user.ProfilePicture,
        //            BrokerNo = model.BrokerNo
        //        };
        //        await _db.Agent.AddAsync(agent);
        //        await _db.SaveChangesAsync();

        //        var token = "";


        //        response.IsSuccess = true;
        //        response.Token = token;
        //        response.UserId = user.Id;
        //        response.PhoneNumber = user.MobileNumber;
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.IsSuccess = false;
        //        response.Message = StaticData.ServerError_Message; ;
        //        return response;
        //    }

        //}

        public async Task<BaseResponse> RemoveAgent(int agentId)
        {
            var response = new BaseResponse();

            try
            {
                var agent = await _db.Agent.AsNoTracking()
                    .FirstOrDefaultAsync(a => a.Id == agentId);

                if (agent == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Agent not found";
                    return response;
                }
                var user = await _db.Users.AsNoTracking()
                   .FirstOrDefaultAsync(a => a.Id == agentId);

                if (user == null)
                {
                    response.IsSuccess = false;
                    response.Message = "User not found";
                    return response;
                }


                _db.Agent.Remove(agent);
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Agent removed from your agency";
                return response;
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }
        //public async Task<BaseResponse> RemoveMotorsAgent(int agentId)
        //{
        //    var response = new BaseResponse();

        //    try
        //    {
        //        var agent = await _db.Agent.AsNoTracking()
        //            .FirstOrDefaultAsync(a => a.Id == agentId);

        //        if (agent == null)
        //        {
        //            response.IsSuccess = false;
        //            response.Message = "Agent not found";
        //            return response;
        //        }
        //        var user = await _db.Users.AsNoTracking()
        //           .FirstOrDefaultAsync(a => a.Id == agentId);

        //        if (user == null)
        //        {
        //            response.IsSuccess = false;
        //            response.Message = "User not found";
        //            return response;
        //        }


        //        _db.Agent.Remove(agent);
        //        _db.Users.Remove(user);
        //        await _db.SaveChangesAsync();

        //        response.IsSuccess = true;
        //        response.Message = "Agent removed from your agency";
        //        return response;
        //    }
        //    catch (Exception)
        //    {
        //        response.IsSuccess = false;
        //        response.Message = StaticData.ServerError_Message;
        //        return response;
        //    }
        //}

        public async Task<BaseResponse> ActivateAgent(int agentId)
        {
            var response = new BaseResponse();

            try
            {
                var agent = await _db.Agent.AsNoTracking()
                    .FirstOrDefaultAsync(a => a.Id == agentId);

                if (agent == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Agent not found";
                    return response;
                }

                agent.Status = StaticData.Active;
                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Agent account activated successfully";
                return response;
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }
        //public async Task<BaseResponse> ActivatePropertyAgent(int agentId)
        //{
        //    var response = new BaseResponse();

        //    try
        //    {
        //        var agent = await _db.Agent.AsNoTracking()
        //            .FirstOrDefaultAsync(a => a.Id == agentId);

        //        if (agent == null)
        //        {
        //            response.IsSuccess = false;
        //            response.Message = "Agent not found";
        //            return response;
        //        }

        //        agent.Status = StaticData.Active;
        //        await _db.SaveChangesAsync();

        //        response.IsSuccess = true;
        //        response.Message = "Agent account activated successfully";
        //        return response;
        //    }
        //    catch (Exception)
        //    {
        //        response.IsSuccess = false;
        //        response.Message = StaticData.ServerError_Message;
        //        return response;
        //    }
        //}

        public async Task<BaseResponse> DisableAgent(int agentId)
        {
            var response = new BaseResponse();

            try
            {
                var agent = await _db.Agent.AsNoTracking()
                    .FirstOrDefaultAsync(a => a.Id == agentId);

                if (agent == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Agent not found";
                    return response;
                }

                agent.Status = StaticData.disable;
                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Agent account disabled successfully";
                return response;
            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }
        public async Task<List<Agent>> GetAllAgentsByAgency(int agencyId)
        {
            
                var agents = await _db.Agent.Where(l => l.AgencyId == agencyId).AsNoTracking().ToListAsync();

            return agents;
                
        }
        //public async Task<BaseResponse> DisableMotorsAgent(int agentId)
        //{
        //    var agent = await _db.Agent.AsNoTracking()
        //           .FirstOrDefaultAsync(a => a.Id == agentId);

        //    if (agent == null)
        //    {
        //        response.IsSuccess = false;
        //        response.Message = "Agent not found";
        //        return response;
        //    }

        //    agent.Status = StaticData.disable;
        //    await _db.SaveChangesAsync();

        //    response.IsSuccess = true;
        //    response.Message = "Agent account disabled successfully";
        //    return response;
        //}


    }
}

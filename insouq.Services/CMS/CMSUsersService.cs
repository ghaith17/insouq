using AutoMapper;
using insouq.Configuration;
using insouq.EntityFramework;
using insouq.Models;
using insouq.Models.IdentityConfiguration;
using insouq.Services.IServices;
using insouq.Shared.DTOS.UserDTOS;
using insouq.Shared.Responses;
using insouq.Shared.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using insouq.Models.ViewModels;
using insouq.Services.IServices.CMS;

namespace insouq.Services.CMS
{
    public class CMSUsersService : ICMSUsersService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public CMSUsersService(
            ApplicationDbContext db,
            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole<int>> roleManager)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            var users = await _db.Users.AsNoTracking().Where(u => u.Status != 3).ToListAsync();

            var usersDTO = _mapper.Map<List<UserDTO>>(users);

            return usersDTO;
        }

        public async Task<BaseResponse> DeleteUser(int userId)
        {
            var response = new BaseResponse();

            try
            {
                var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == userId && u.Status != 3);

                if (user == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not found";
                    return response;
                }

                user.Status = 3;

                var ads = await _db.Ads.Where(a => a.UserId == userId).ToListAsync();

                foreach (var ad in ads)
                {
                    ad.Status = 3;
                }

                await _db.SaveChangesAsync();

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

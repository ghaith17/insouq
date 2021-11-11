using insouq.Models;
using insouq.Shared.DTOS.UserDTOS;
using insouq.Shared.Responses;
using insouq.Shared.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services.IServices.CMS
{
    public interface ICMSUsersService
    {
        Task<List<UserDTO>> GetAllUsers();

        Task<BaseResponse> DeleteUser(int userId);
    }
}

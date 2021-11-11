using insouq.Shared.DTOS.AccountsDTOS;
using insouq.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services.IServices.CMS
{
    public interface ICMSAccountsService
    {
        Task<BaseResponse> Login(string username, string password);

        Task<BaseResponse> ChangePassword(int userId, ChangePasswordDTO model);
    }
}

using insouq.Shared.DTOS.AccountsDTOS;
using insouq.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services.IServices
{
    public interface IAccountsService
    {
        Task<AuthenticationResponse> Login(LoginDTO model);

        Task<AuthenticationResponse> WebLogin(LoginDTO model);

        Task<BaseResponse> SendEmailCode(int userId, SendEmailCodeDTO model);

        Task<BaseResponse> VerifyEmailCode(int userId, VerifyEmailCodeDTO model);

        Task<BaseResponse> ChangePassword(int userId, ChangePasswordDTO model);

        Task<BaseResponse> ConfirmMobileNumber(int userId, ConfirmMobileNumberDTO model);

        Task<BaseResponse> SendSmsCode(SendSmsCodeDTO model);

        Task<BaseResponse> VerifySmsCode(VerifySmsCodeDTO model);

        Task<BaseResponse> ForgotPassword(ForgotPasswordDTO model);

        Task<VerifyForgotPasswordCodeResponse> VerifyForgotPasswordCode(VerifyEmailCodeDTO model);

        Task<BaseResponse> ResetPassword(ResetPasswordDTO model);

        Task<AuthenticationResponse> FacebookLogin(string accessToken, string type);

        Task<AuthenticationResponse> GmailLogin(string accessToken, string type);

        Task<BaseResponse> LoginAfterReg(string email);

        Task<VerifyForgotPasswordCodeResponse> RequestForgotPasswordToken(string phoneNumber);

        Task<BaseResponse> ResetPasswordMobile(ResetMobilePasswordDTO model);
    }
}

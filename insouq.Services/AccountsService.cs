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


namespace insouq.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly JwtConfig _jwtConfig;

        public AccountsService(
            ApplicationDbContext db,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole<int>> roleManager,
            IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        public async Task<AuthenticationResponse> Login(LoginDTO model)
        {
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

                if (!await _userManager.IsInRoleAsync(applicationUser, StaticData.User_Role))
                {
                    response.IsSuccess = false;
                    response.Message = "Please check your information";
                    return response;
                }

                var user = await _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Status != 3);

                if(user == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Please check your information";
                    return response;
                }


                var isCorrect = await _userManager.CheckPasswordAsync(applicationUser, model.Password);

                if (!isCorrect)
                {
                    response.IsSuccess = false;
                    response.Message = "Please check your information";
                    response.Status = AuthStatus.ERROR_MESSAGE;

                    return response;
                }

                if (!applicationUser.PhoneNumberConfirmed)
                {
                    response.IsSuccess = false;
                    response.Message = "Phone Number not confirmed";
                    response.Status = AuthStatus.MOBILE_NUMBER_NOT_CONFIRMED;
                    response.UserId = applicationUser.Id;
                    response.PhoneNumber = applicationUser.PhoneNumber;
                    return response;
                }

                var token = HelperFunctions.GenerateJwtToken(applicationUser.Id, applicationUser.Email, _jwtConfig.Secret);

                response.IsSuccess = true;
                response.Token = token;
                response.UserId = applicationUser.Id;
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

        public async Task<AuthenticationResponse> WebLogin(LoginDTO model)
        {
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

                if (!await _userManager.IsInRoleAsync(applicationUser, StaticData.User_Role))
                {
                    response.IsSuccess = false;
                    response.Message = "Please check your information";
                    return response;
                }

                var user = await _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Status != 3);

                if (user == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Please check your information";
                    return response;
                }

                if (!applicationUser.PhoneNumberConfirmed)
                {
                    var sendSmsDto = new SendSmsCodeDTO
                    {
                        MobileNumber = applicationUser.PhoneNumber,
                        UserId = applicationUser.Id
                    };

                    var sendSmsResponse = await SendSmsCode(sendSmsDto);

                    response.IsSuccess = false;
                    response.Message = "Phone Number not confirmed";
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

        // For Mobile (Just for make phone number confirmed and update phone number if needed so this represent confirm and change)
        public async Task<BaseResponse> ConfirmMobileNumber(int userId, ConfirmMobileNumberDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var applicationUser = await _db.ApplicationUsers.FirstOrDefaultAsync(u => u.Id == userId);

                // this happens when change phone number
                if (applicationUser.PhoneNumber != model.MobileNumber)
                {
                    var userRoles = await _userManager.GetRolesAsync(applicationUser);

                    var role = userRoles.First();

                    if (role == StaticData.User_Role)
                    {
                        var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);

                        user.MobileNumber = model.MobileNumber;

                    }
                    else if (role != StaticData.User_Role)
                    {
                        //var agent = await _db.Agents.FirstOrDefaultAsync(a => a.Id == userId);

                        //agent.MobileNumber = model.MobileNumber;
                    }


                    applicationUser.PhoneNumber = model.MobileNumber;
                }


                applicationUser.PhoneNumberConfirmed = true;

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

        public async Task<BaseResponse> ForgotPassword(ForgotPasswordDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Email not found";
                    return response;
                }

                var otp = new OTP()
                {
                    //Code = randomCode,
                    Code = "666666",
                    UserId = user.Id,
                };

                await _db.OTPs.AddAsync(otp);

                await _db.SaveChangesAsync();



                // Sending Email Process
                //....
                //....
                //End

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

        public async Task<BaseResponse> ResetPassword(ResetPasswordDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Email not found";
                    return response;
                }

                var resetPassResult = await _userManager.ResetPasswordAsync(user, model.ResetPasswordToken, model.NewPassword);

                if (!resetPassResult.Succeeded)
                {
                    response.IsSuccess = false;
                    response.Message = resetPassResult.Errors.First().Description;
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

        public async Task<VerifyForgotPasswordCodeResponse> VerifyForgotPasswordCode(VerifyEmailCodeDTO model)
        {
            var response = new VerifyForgotPasswordCodeResponse();

            try
            {
                var identityUser = await _userManager.FindByEmailAsync(model.Email);

                if (identityUser == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Email not found";
                    return response;
                }

                var userOtp = await _db.OTPs.FirstOrDefaultAsync(o => o.UserId == identityUser.Id && o.Code == model.Code);

                if (userOtp == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Code not found";
                    return response;
                }

                var firstUsername = await _db.Users.Where(u => u.Id == identityUser.Id).Select(u => u.FirstName)
                    .AsNoTracking().FirstOrDefaultAsync();

                var resetPasswordToken = await _userManager.GeneratePasswordResetTokenAsync(identityUser);

                response.ResetPasswordToken = resetPasswordToken;
                response.Username = firstUsername;
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

        public async Task<BaseResponse> SendEmailCode(int userId, SendEmailCodeDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var otp = new OTP()
                {
                    //Code = randomCode,
                    Code = "666666",
                    UserId = userId
                };

                await _db.OTPs.AddAsync(otp);

                await _db.SaveChangesAsync();

                // sending Email proccess

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

        // VerifyEmailCode are used in ChangeEmail in edit profile
        public async Task<BaseResponse> VerifyEmailCode(int userId, VerifyEmailCodeDTO model)
        {
            var response = new BaseResponse();

            try
            {

                var userOtp = await _db.OTPs.FirstOrDefaultAsync(o => o.UserId == userId && o.Code == model.Code);

                if (userOtp == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Code not found";
                    return response;
                }


                var applicationUser = await _db.ApplicationUsers.FirstOrDefaultAsync(u => u.Id == userId);

                // this is becuase he maybe will verfiy his old email only!!
                if (applicationUser.Email != model.Email)
                {
                    var userRoles = await _userManager.GetRolesAsync(applicationUser);

                    var role = userRoles.First();

                    if (role == StaticData.User_Role)
                    {
                        var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);

                        user.Email = model.Email;

                    }
                    else if (role != StaticData.Agent_Role)
                    {
                        //var agent = await _db.Agents.FirstOrDefaultAsync(a => a.Id == userData.Id);

                        //agent.Email = newEmail;

                        //await _db.SaveChangesAsync();
                    }

                    applicationUser.Email = model.Email;
                    applicationUser.UserName = model.Email;
                    applicationUser.NormalizedEmail = model.Email.ToUpper();
                    applicationUser.NormalizedUserName = model.Email.ToUpper();
                }

                applicationUser.EmailConfirmed = true;

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

        //For Web (Without Firebase)
        //  SendSmsCode and VerifySmsCode are used when create user or change phone number
        public async Task<BaseResponse> SendSmsCode(SendSmsCodeDTO model)
        {
            var response = new BaseResponse();

            try
            {
                Random generator = new Random();
                var code = generator.Next(0, 1000000).ToString("D6");

                var otp = new OTP()
                {
                    Code = code,
                    UserId = model.UserId,
                    MobileNumber = model.MobileNumber
                };

                if(!SmsHelper.SMSSend(code, model.MobileNumber))
                {
                    response.IsSuccess = false;
                    response.Message = "Error while sending code";
                    return response;
                }

                await _db.OTPs.AddAsync(otp);

                await _db.SaveChangesAsync();

                // sending Sms proccess

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

        public async Task<BaseResponse> VerifySmsCode(VerifySmsCodeDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var userOtp = await _db.OTPs.FirstOrDefaultAsync(o => o.UserId == model.UserId
                && o.Code == model.Code && o.MobileNumber == model.MobileNumber);

                if (userOtp == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Code not found";
                    return response;
                }

                var applicationUser = await _db.ApplicationUsers.FirstOrDefaultAsync(u => u.Id == model.UserId);

                // Change Phone Number
                if (applicationUser.PhoneNumber != model.MobileNumber)
                {
                    var userRoles = await _userManager.GetRolesAsync(applicationUser);

                    var role = userRoles.First();

                    if (role == StaticData.User_Role)
                    {
                        var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == model.UserId);

                        user.MobileNumber = model.MobileNumber;
                    }
                    else if (role != StaticData.User_Role)
                    {
                        //var agent = await _db.Agents.FirstOrDefaultAsync(a => a.Id == userData.Id);

                        //agent.MobileNumber = mobileNumber;
                    }

                    applicationUser.PhoneNumber = model.MobileNumber;

                }

                applicationUser.PhoneNumberConfirmed = true;

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

        public async Task<AuthenticationResponse> FacebookLogin(string accessToken, string type)
        {
            var response = new AuthenticationResponse();

            try
            {
                //check token
                var httpClient = new HttpClient { BaseAddress = new Uri("https://graph.facebook.com/v2.8/") };
              
                var fResponse = await httpClient.GetAsync($"me?access_token={accessToken}&fields=id,name,email,first_name,last_name,age_range,birthday,gender,locale,picture&scope=public_profile,email");

                if (!fResponse.IsSuccessStatusCode)
                {
                    response.IsSuccess = false;
                    response.Message = "Invalid token";
                    response.Status = AuthStatus.ERROR_MESSAGE;
                    return response;
                }

                var result = await fResponse.Content.ReadAsStringAsync();

                var facebookAccount = JsonConvert.DeserializeObject<FacebookAccountDTO>(result);

                if (facebookAccount?.Email != null)
                {
                    var identityUser = await _userManager.FindByEmailAsync(facebookAccount.Email);

                    if (identityUser != null) // user already registerd with this email or user already registered with facebook
                    {
                        response.IsSuccess = true;
                        response.UserId = identityUser.Id;
                        response.Status = AuthStatus.SUCCESS;

                        if (type == "API")
                        {

                            var token = HelperFunctions.GenerateJwtToken(identityUser.Id, identityUser.Email, _jwtConfig.Secret);
                            response.Token = token;
                        }
                        else
                        {
                            await _signInManager.SignInAsync(identityUser, isPersistent: false);

                        }

                        return response;
                    }

                    identityUser = new ApplicationUser()
                    {
                        Email = facebookAccount.Email,
                        UserName = facebookAccount.Email,
                    };

                    await _userManager.CreateAsync(identityUser);

                    if (!await _roleManager.RoleExistsAsync(StaticData.User_Role))
                    {
                        await _roleManager.CreateAsync(new IdentityRole<int>(StaticData.User_Role));
                    }

                    await _userManager.AddToRoleAsync(identityUser, StaticData.User_Role);

                    DateTime? date = null;

                    if (facebookAccount.Birthday != null)
                    {
                        date = Convert.ToDateTime(facebookAccount.Birthday);
                    }

                    var user = new User()
                    {
                        Id = identityUser.Id,
                        Email = facebookAccount.Email,
                        FirstName = facebookAccount?.First_Name != null ? facebookAccount.First_Name : null,
                        LastName = facebookAccount?.Last_Name != null ? facebookAccount.Last_Name : null,
                        Gender = facebookAccount?.Gender != null ? facebookAccount.Gender : null,
                        DOB = date,
                        ProfilePicture = StaticData.DefaultUser_Image,
                        ExternalLogin = true,
                        MemberSince = DateTime.Now
                    };

                    await _db.Users.AddAsync(user);

                    await _db.SaveChangesAsync();

                    if (type == "API")
                    {

                        var token = HelperFunctions.GenerateJwtToken(identityUser.Id, identityUser.Email, _jwtConfig.Secret);
                        response.Token = token;
                    }

                    response.IsSuccess = true;
                    response.UserId = identityUser.Id;
                    response.Status = AuthStatus.EXTERNAL_SUCCESS;
                    response.Email = identityUser.Email;
                    return response;

                }

                response.IsSuccess = false;
                response.Message = "your facebook account does not have an email";
                response.Status = AuthStatus.ERROR_MESSAGE;
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

        public async Task<AuthenticationResponse> GmailLogin(string idToken, string type)
        {
            var response = new AuthenticationResponse();

            try
            {
                GoogleJsonWebSignature.ValidationSettings settings = new GoogleJsonWebSignature.ValidationSettings();
                // Change this to your google client ID
                settings.Audience = new List<string>() { "347827155629-55umcequ7jk4s0mv6lg7u7kthrc03cgr.apps.googleusercontent.com" };

                var payload = await GoogleJsonWebSignature.ValidateAsync(idToken);


                var identityUser = await _userManager.FindByEmailAsync(payload.Email);

                if (identityUser != null) // user already registerd with this email or user already registered with gmail.
                {
                    response.IsSuccess = true;
                    response.UserId = identityUser.Id;
                    response.Status = AuthStatus.SUCCESS;

                    if (type == "API")
                    {
                        var token = HelperFunctions.GenerateJwtToken(identityUser.Id, identityUser.Email, _jwtConfig.Secret);
                        response.Token = token;
                    }
                    else
                    {
                        await _signInManager.SignInAsync(identityUser, isPersistent: false);
                    }

                    return response;
                }

                identityUser = new ApplicationUser()
                {
                    Email = payload.Email,
                    UserName = payload.Email,
                };

                await _userManager.CreateAsync(identityUser);

                if (!await _roleManager.RoleExistsAsync(StaticData.User_Role))
                {
                    await _roleManager.CreateAsync(new IdentityRole<int>(StaticData.User_Role));
                }

                await _userManager.AddToRoleAsync(identityUser, StaticData.User_Role);

                var user = new User()
                {
                    Id = identityUser.Id,
                    Email = payload.Email,
                    FirstName = payload?.GivenName != null ? payload.GivenName : null,
                    LastName = payload?.FamilyName != null ? payload.FamilyName : null,
                    ProfilePicture = StaticData.DefaultUser_Image,
                    ExternalLogin = true,
                    MemberSince = DateTime.Now
                };

                await _db.Users.AddAsync(user);

                await _db.SaveChangesAsync();



                if (type == "API")
                {
                    var token = HelperFunctions.GenerateJwtToken(identityUser.Id, identityUser.Email, _jwtConfig.Secret);
                    response.Token = token;
                }
                else
                {
                    await _signInManager.SignInAsync(identityUser, isPersistent: false);
                }

                response.IsSuccess = true;
                response.UserId = identityUser.Id;
                response.Status = AuthStatus.EXTERNAL_SUCCESS;
                response.Email = identityUser.Email;
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = StaticData.ServerError_Message;
                response.Status = AuthStatus.ERROR_MESSAGE;
                return response;
            }

        }


        public async Task<BaseResponse> LoginAfterReg(string email)
        {
            var response = new BaseResponse();

            try
            {
                var identityUser = await _userManager.FindByEmailAsync(email);

                if(identityUser == null)
                {
                    response.IsSuccess = false;
                    response.Message = "User not found";
                    return response;
                }

                response.IsSuccess = true;

                await _signInManager.SignInAsync(identityUser, isPersistent: false);

                return response;

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = StaticData.ServerError_Message;
                return response;
            }

        }


        // Services for apis
        public async Task<VerifyForgotPasswordCodeResponse> RequestForgotPasswordToken(string mobileNumber)
        {
            var response = new VerifyForgotPasswordCodeResponse();

            try
            {
                var identityUser = await _db.ApplicationUsers.FirstOrDefaultAsync(u => mobileNumber.Contains(u.PhoneNumber));

                if (identityUser == null)
                {
                    response.IsSuccess = false;
                    response.Message = "User not found";
                    return response;
                }


                var firstUsername = await _db.Users.Where(u => u.Id == identityUser.Id).Select(u => u.FirstName)
                    .AsNoTracking().FirstOrDefaultAsync();

                var resetPasswordToken = await _userManager.GeneratePasswordResetTokenAsync(identityUser);

                response.ResetPasswordToken = resetPasswordToken;
                response.Username = firstUsername;
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

        public async Task<BaseResponse> ResetPasswordMobile(ResetMobilePasswordDTO model)
        {
            var response = new BaseResponse();

            try
            {
                var user = await _db.ApplicationUsers.FirstOrDefaultAsync(u => model.MobileNumber.Contains(u.PhoneNumber));

                if (user == null)
                {
                    response.IsSuccess = false;
                    response.Message = "User not found";
                    return response;
                }

                var resetPassResult = await _userManager.ResetPasswordAsync(user, model.ResetPasswordToken, model.NewPassword);

                if (!resetPassResult.Succeeded)
                {
                    response.IsSuccess = false;
                    response.Message = resetPassResult.Errors.First().Description;
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

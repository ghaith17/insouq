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

namespace insouq.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly JwtConfig _jwtConfig;
        private readonly IWebHostEnvironment _hostEnvironment;


        public UsersService(
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
        public async Task<UserDTO> GetById(int id)
        {
            var user = await _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id && u.Status != 3);

            var userDTO = _mapper.Map<UserDTO>(user);

            return userDTO;
        }

        public async Task<UserDTO> GetByEmailOrPhone(string value)
        {
            var user = await _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == value || u.MobileNumber == value && u.Status != 3);

            var userDTO = _mapper.Map<UserDTO>(user);

            return userDTO;
        }

        public async Task<AuthenticationResponse> Add(AddUserDTO model, string type, string host)
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
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MobileNumber = model.MobileNumber,
                    ProfilePicture = StaticData.DefaultUser_Image,
                    MemberSince = DateTime.Now
                };

                await _db.Users.AddAsync(user);

                if (!await _roleManager.RoleExistsAsync(StaticData.User_Role))
                {
                    await _roleManager.CreateAsync(new IdentityRole<int>(StaticData.User_Role));
                }

                await _userManager.AddToRoleAsync(identityUser, StaticData.User_Role);

                var token = "";

                if (type == "Mobile")
                {
                    token = HelperFunctions.GenerateJwtToken(user.Id, user.Email, _jwtConfig.Secret);
                }

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

        public async Task<UpdateProfileResponse> UpdateProfile(int userId, UpdateProfileDTO model, string host)
        {
            var response = new UpdateProfileResponse();

            try
            {
                var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);

                var webRootPath = _hostEnvironment.WebRootPath;

                var folderPath = Path.Combine(webRootPath, "images");

                var profileImageUrl = user.ProfilePicture; // null or oldImage

                if (model.ProfilePictureFile != null)
                {
                    if (!String.IsNullOrEmpty(profileImageUrl))
                    {
                        //Image changed, we need to remove old image

                        var imagePath = Path.Combine(webRootPath, profileImageUrl.TrimStart('\\'));

                        if (File.Exists(imagePath))
                        {
                            File.Delete(imagePath);
                        }
                    }

                    profileImageUrl = await HelperFunctions.UploadImage(folderPath, model.ProfilePictureFile, "users", host);

                }

                var CvImageUrl = user.CV; // null or oldImage

                if (model.CVFile != null)
                {
                    if (!String.IsNullOrEmpty(CvImageUrl))
                    {
                        //Image changed, we need to remove old image

                        var imagePath = Path.Combine(webRootPath, CvImageUrl.TrimStart('\\'));

                        if (File.Exists(imagePath))
                        {
                            File.Delete(imagePath);
                        }
                    }

                    CvImageUrl = await HelperFunctions.UploadImage(folderPath, model.CVFile, "users", host);
                }

                var industryImageUrl = user.Industry; // null or oldImage

                if (model.IndustryFile != null)
                {
                    if (!String.IsNullOrEmpty(industryImageUrl))
                    {
                        //Image changed, we need to remove old image

                        var imagePath = Path.Combine(webRootPath, industryImageUrl.TrimStart('\\'));

                        if (File.Exists(imagePath))
                        {
                            File.Delete(imagePath);
                        }
                    }

                    industryImageUrl = await HelperFunctions.UploadImage(folderPath, model.IndustryFile, "users", host);
                }


                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Gender = model.Gender;
                user.DOB = model.DOB;
                user.Nationality = model.Nationality;
                user.DefaultLocation = model.DefaultLocation;
                user.DefaultLanguage = model.DefaultLanguage;
                user.CareerLevel = model.CareerLevel;
                user.Education = model.Education;
                user.CurrentLocation = model.CurrentLocation;
                user.CurrentPosition = model.CurrentPosition;
                user.CurrentCompany = model.CurrentCompany;
                user.CV = CvImageUrl;
                user.CoverNote = model.CoverNote;
                user.ProfilePicture = profileImageUrl;
                user.Industry = industryImageUrl;
                user.HideInfromation = model.HideInfromation;

                _db.Users.Update(user);

                await _db.SaveChangesAsync();

                var userDTO = _mapper.Map<UserDTO>(user);

                response.User = userDTO;
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

        public async Task<CompanyProfileDTO> GetCompanyProfile(int userId)
        {
            var companyProfile = await _db.CompanyProfiles.FirstOrDefaultAsync(c => c.UserId == userId);

            var companyProfileDTO = _mapper.Map<CompanyProfileDTO>(companyProfile);

            return companyProfileDTO;
        }

        public async Task<UpdateCompanyProfileResponse> UpdateCompanyProfile(int userId, UpdateCompanyProfileDTO model,string host)
        {
            var response = new UpdateCompanyProfileResponse();

            try
            {
                var companyProfile = await _db.CompanyProfiles.FirstOrDefaultAsync(c => c.UserId == userId);

                var webRootPath = _hostEnvironment.WebRootPath;

                var folderPath = Path.Combine(webRootPath, "images");

                var tradeLicenseImageUrl = companyProfile?.TradeLicenseCopy; // null or old image

                if (model.TradeLicenseFile != null)
                {
                    if (!String.IsNullOrEmpty(tradeLicenseImageUrl))
                    {
                        //Image changed, we need to remove old image

                        var imagePath = Path.Combine(webRootPath, tradeLicenseImageUrl.TrimStart('\\'));

                        if (File.Exists(imagePath))
                        {
                            File.Delete(imagePath);
                        }

                    }

                    tradeLicenseImageUrl = await HelperFunctions.UploadImage(folderPath, model.TradeLicenseFile, "users", host);
                }

                var profilePictureImageUrl = companyProfile?.Picture; // null or old image

                if (model.ProfilePicture != null)
                {
                    if (!String.IsNullOrEmpty(profilePictureImageUrl))
                    {
                        //Image changed, we need to remove old image

                        var imagePath = Path.Combine(webRootPath, profilePictureImageUrl.TrimStart('\\'));

                        if (File.Exists(imagePath))
                        {
                            File.Delete(imagePath);
                        }

                    }

                    profilePictureImageUrl = await HelperFunctions.UploadImage(folderPath, model.ProfilePicture, "users", host);
                }

                var isNew = companyProfile == null;

                if (isNew)
                {
                    companyProfile = new CompanyProfile();
                }

                companyProfile.Name = model.Name;
                companyProfile.Email = model.Email;
                companyProfile.Description = model.Description;
                companyProfile.TradeLicenseNumber = model.TradeLicenseNumber;
                companyProfile.TradeLicenseCopy = tradeLicenseImageUrl;
                companyProfile.ContactNumber = model.ContactNumber;
                companyProfile.Size = model.Size;
                companyProfile.Website = model.Website;
                companyProfile.Location = model.Location;
                companyProfile.Picture = profilePictureImageUrl;

                if (isNew)
                {
                    companyProfile.UserId = userId;
                    await _db.CompanyProfiles.AddAsync(companyProfile);
                }
                else
                {
                    _db.CompanyProfiles.Update(companyProfile);
                }

                await _db.SaveChangesAsync();

                var companyProfileDTO = _mapper.Map<CompanyProfileDTO>(companyProfile);

                response.IsSuccess = true;
                response.CompanyProfile = companyProfileDTO;
                return response;

            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }

        public async Task<string> GetPhoneNumber(int userId)
        {
            var phoneNumber = await _db.Users.Where(u => u.Id == userId && u.Status != 3).Select(u => u.MobileNumber)
                .AsNoTracking().FirstOrDefaultAsync();

            return phoneNumber;
        }

        public async Task<List<SavedSearch>> getSavedSearches(int UserId,int TypeId)
        {
            return _db.SavedSearch.Where(s => s.UserId == UserId && (s.ADTypeId ==TypeId || TypeId <0 ))
                 .Include(s => s.ADCategory)
                 .Include(s => s.ADType)
                 .ToList();
        }


        public string getUserStatistics(List<AdStatistic> UserStatistics, StatisticPeriod period)
        {
            try
            {
                string DateFormat = "yyyy/MM/dd";

                ChartsDataVM ChartsData = new ChartsDataVM();

                ChartsData.Yaxies = new List<double>();
                ChartsData.Xaxies = new List<string>();
                //var FilterArray = new List<string>();


                if (period == StatisticPeriod.Today)
                {
                    DateFormat = "yyyy/MM/dd HH";
                    int i = int.Parse(DateTime.Now.ToString("HH"));
                    for ( ; i >= 0; i--)
                    {
                        ChartsData.Xaxies.Add(DateTime.Now.AddHours(-i).ToString(DateFormat));
                        ChartsData.Yaxies.Add(0);
                    }
                }
                else if(period == StatisticPeriod.ThisMonth)
                {
                    var z = DateTime.Now.Month;
                    for (int i = 30; i >= 0; i--)
                    {
                        ChartsData.Xaxies.Add(DateTime.Now.AddDays(-i).ToString(DateFormat));
                        ChartsData.Yaxies.Add(0);
                    }
                }
                else if (period == StatisticPeriod.ThisWeak)
                {
                    var z = DateTime.Now.DayOfWeek; 
                    for (int i = 6; i >=0; i--)
                    {
                        ChartsData.Xaxies.Add(DateTime.Now.AddDays(-i).ToString(DateFormat));
                        ChartsData.Yaxies.Add(0);
                    }
                }

                

                foreach (var item in UserStatistics)
                {
                    int indexIfExist = ChartsData.Xaxies.IndexOf(item.Date.ToString(DateFormat));
                    if (indexIfExist != -1)
                    {
                        ChartsData.Yaxies[indexIfExist]++;
                    }
                    else
                    {
                        ChartsData.Xaxies.Add(item.Date.ToString(DateFormat));
                        
                        ChartsData.Yaxies.Add(1);
                    }

                }

                if (period == StatisticPeriod.Today)
                {
                    DateFormat = "HH";
                    for (int i = 0; i < ChartsData.Xaxies.Count; i++)
                    {
                        ChartsData.Xaxies[i] = Convert.ToDateTime(ChartsData.Xaxies[i]+":00").ToString(DateFormat);
                    }

                    
                }
                else
                {
                    DateFormat = "dd/MM/yyyy";
                    for (int i = 0; i < ChartsData.Xaxies.Count; i++)
                    {
                        ChartsData.Xaxies[i] = Convert.ToDateTime(ChartsData.Xaxies[i]).ToString(DateFormat);
                    }
                }

                

                return JsonSerializer.Serialize(ChartsData); 
            }
            catch(Exception e)
            {
                return "";
            }
        }

        public string getUserStatistics(int userId,int AdId,StatisticTypes Type, StatisticPeriod Period)
        {
            try
            {
                var result = new List<ChartsDataVM>();

                ChartsDataVM Viewsdata = new ChartsDataVM();

                var UserStatistics = _db.AdStatistics
                    .Where(s => s.UserId == userId )
                    .OrderBy(s => s.Date).ToList();

                UserStatistics= UserStatistics.Where (s=>(Type == StatisticTypes.All || s.Type == (int)Type) && s.AdId== AdId
                                && (
                                (Period == StatisticPeriod.All)
                                || (Period == StatisticPeriod.ThisMonth && s.Date.ToString("MM-yyyy") == DateTime.Now.ToString("MM-yyyy"))
                                || (Period == StatisticPeriod.Today && s.Date.ToString("dd-MM-yyyy") == DateTime.Now.ToString("dd-MM-yyyy"))
                                || (Period == StatisticPeriod.ThisWeak && (s.Date - DateTime.Now) <= TimeSpan.FromDays(7))
                                )).ToList();


                return UserStatistics==null?"": getUserStatistics(UserStatistics,Period);
            }
            catch(Exception E)
            {
                return "";
            }
        }

    }
}

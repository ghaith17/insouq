using insouq.Models;
using insouq.Shared.DTOS.UserDTOS;
using insouq.Shared.Responses;
using insouq.Shared.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services.IServices
{
    public interface IUsersService
    {
        Task<UserDTO> GetById(int userID);

        Task<UserDTO> GetByEmailOrPhone(string value);

        Task<string> GetPhoneNumber(int userId);

        Task<AuthenticationResponse> Add(AddUserDTO model, string type, string host);

        Task<UpdateProfileResponse> UpdateProfile(int userId, UpdateProfileDTO model, string host);

        Task<CompanyProfileDTO> GetCompanyProfile(int userId);

        Task<UpdateCompanyProfileResponse> UpdateCompanyProfile(int userId, UpdateCompanyProfileDTO model, string host);

        Task<List<SavedSearch>> getSavedSearches(int UserId, int TypeId);
        string getUserStatistics(List<AdStatistic> UserStatistics, StatisticPeriod Period);
        string getUserStatistics(int userId, int AdId, StatisticTypes Type, StatisticPeriod Period);
    }
}

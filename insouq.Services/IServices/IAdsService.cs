using insouq.Models;
using insouq.Shared.DTOS;
using insouq.Shared.DTOS.Filters;
using insouq.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services.IServices
{
    public interface IAdsService
    {
        Task<dynamic> GetAds(int typeId, string searchText, string location,
            int maxKm, int minKm, int maxYear,
            int minYear, double maxPrice, double minPrice,
            string maker, string model, string trim
            );

        Task<dynamic> GetLatestAds(int typeId);

        Task<dynamic> GetAdsByCategoryId(int userId,int typeId,
            int categoryId, string searchText , string location ,
            int maxKm , int minKm , int maxYear ,
            int minYear , double maxPrice , double minPrice,
            string maker, string model, string trim
            );

        Task<dynamic> GetAd(int adId, int typeId);

        Task<BaseResponse> DeleteAd(int userId, int adId);

        Task<dynamic> GetUserAds(int userId, int typeId, bool isOwner);

        Task<dynamic> GetSimilarAds(int typeId, int categoryId, int currentAdId);

        Task<dynamic> GetMyFavoriteAds(int userId, int typeId);

        Task<List<AdCountDTO>> GetUserAdsCount(int userId, bool isOwner);

        Task<List<AdCountDTO>> GetMyFavoriteAdsCount(int userId);

        Task<int> IsDeatilsProcessDone(int userId, int typeId, int adId, int cateogryId);

        Task<bool> IsOfferMaked(int userId, int adId);

        Task<bool> IsJobApplicationApplied(int userId, int adId);

        Task<bool> IsInFavorite(int userId, int adId);

        Task<BaseResponse> MakeAnOffer(int userId, MakeAnOfferDTO model);

        Task<BaseResponse> ReportAd(int userId, ReportDTO model);

        Task<BaseResponse> AddToFavorite(int userId, FavoriteAdDTO model);

        Task<BaseResponse> RemoveFromFavorite(int userId, FavoriteAdDTO model);

        Task<SaveFiltersResponse> SaveFillters(int userId, SaveFiltersDTO savedSearch);
        Task<BaseResponse> ApplyForJob(int userId, ApplyJobDTO model);

        Task<BaseResponse> DeleteSavedSearch(int userId, int searchId);

        Task<List<AdCountDTO>> GetSavedSearchCount(int userId);

        Task<BaseResponse> DeleteAdPhoto(int id);
    }
}

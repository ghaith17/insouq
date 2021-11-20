using insouq.Models;
using insouq.Shared.DTOS.AdPictureDTOS;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services.IServices
{
    public interface ICMSAds
    {
        public List<Ad> GetAllAds();

        Task<bool> updateAdStatus(int adId, int status);

        public Task<List<AdPicture>> GetAdPictures(int adId);

        Task<dynamic> GetAd(int adId, int typeId);
    }
}

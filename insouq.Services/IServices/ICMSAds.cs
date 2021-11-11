using insouq.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services.IServices
{
    public interface ICMSAds
    {
        public List<Ad> GetAllAds();

        public bool updateAdStatus(int adId, int status);

    }
}

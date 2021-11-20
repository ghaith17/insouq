using insouq.Models;
using insouq.Models.StaticData;
using insouq.Shared.DTOS.TypeDTOS;
using insouq.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services.IServices
{
    public interface IStaticDataService
    {
        Task<AboutUs> UpsertAboutUs(AboutUs model);
        Task<FAQS> UpsertFAQS(FAQS model);
        Task<HIW> UpsertHIW(HIW model);
        Task<List<FAQS>> GetListOfFAQS();
        Task<bool> DeleteFAQS(int id);

        Task<AboutUs> GetAboutUs();
        Task<FAQS> GetFAQS(int id);
        Task<HIW> GettHIW();

        Task<Banner> GetBanner();
        Task<Banner> UpsertBanner(Banner model);
        Task<AdvertisingReason> GetAdvertisingReasons();
        Task<AdvertisingReason> UpsertAdvertisingReasons(AdvertisingReason model);
        Task<SME> GetSMEs();
        Task<SME> UpsertSMEs(SME model);
        Task<AdvertisorImages> GetAdvertisorImages();
        Task<AdvertisorImages> UpsertAdvertisorImages(AdvertisorImages model);
        Task<List<Advertising>> GetListOfAdvertisings();
        Task<bool> DeleteAdvertisings(int id);
    }
}

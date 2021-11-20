using insouq.EntityFramework;
using insouq.Models;
using insouq.Models.StaticData;
using insouq.Services.IServices;
using insouq.Shared.DTOS;
using insouq.Shared.DTOS.AdPictureDTOS;
using insouq.Shared.Utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace insouq.Services
{
    public class CMSStaticDataService : IStaticDataService
    {
        private readonly ApplicationDbContext _db;
        public CMSStaticDataService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<AboutUs> GetAboutUs()
        {
            var aboutUs = await _db.AboutUs.FirstOrDefaultAsync();
            if(aboutUs == null)
            {
                aboutUs = new AboutUs();
            }

            return aboutUs;
        }

        public async Task<FAQS> GetFAQS(int id)
        {
            var _FQAS = await _db.FQAS.FirstOrDefaultAsync(x=>x.Id == id);
            if (_FQAS == null)
            {
                _FQAS = new FAQS();
            }

            return _FQAS;
        }

        public async Task<bool> DeleteFAQS(int id)
        {
            var _FQAS = await _db.FQAS.FirstOrDefaultAsync(x=>x.Id == id);
            if (_FQAS != null)
            {
                _db.FQAS.Remove(_FQAS);
                _db.SaveChanges();
            }

            return true;
        }

        public async Task<List<FAQS>> GetListOfFAQS()
        {
            var _FQAS = await _db.FQAS.Where(x=>x.isDeleted == 0).ToListAsync();
            if (_FQAS == null)
            {
                _FQAS = new List<FAQS>();
            }

            return _FQAS;
        }

        public async Task<HIW> GettHIW()
        {
            var _HIW = await _db.HIW.FirstOrDefaultAsync();
            if (_HIW == null)
            {
                _HIW = new HIW();
            }

            return _HIW;
        }

        public async Task<AboutUs> UpsertAboutUs(AboutUs model)
        {
            var IsEditMode = model.Id != 0;
            AboutUs _AboutUs = new AboutUs();

            if (IsEditMode)
            {
                _AboutUs = await _db.AboutUs.FirstOrDefaultAsync(x => x.Id == model.Id);
            }

            _AboutUs.AboutUsText = model.AboutUsText;
            _AboutUs.AboutUsArText = model.AboutUsArText;

            if (!IsEditMode)
            {
                _db.AboutUs.Add(_AboutUs);
            }
            _db.SaveChanges();
            return _AboutUs;

        }

        public async Task<FAQS> UpsertFAQS(FAQS model)
        {
            var IsEditMode = model.Id != 0;
            FAQS _FAQS = new FAQS();

            if (IsEditMode)
            {
                _FAQS = await _db.FQAS.FirstOrDefaultAsync(x=>x.Id==model.Id);
            }

            _FAQS.Question = model.Question;
            _FAQS.Answer = model.Answer;
            _FAQS.Ar_Answer = model.Ar_Answer;
            _FAQS.Ar_Question = model.Ar_Question;

            if (!IsEditMode)
            {
                _db.FQAS.Add(_FAQS);
            }
            _db.SaveChanges();
            return _FAQS;
        }

        public async Task<HIW> UpsertHIW(HIW model)
        {
            var IsEditMode = model.Id != 0;
            HIW _HIW = new HIW();

            if (IsEditMode)
            {
                _HIW = await _db.HIW.FirstOrDefaultAsync(x => x.Id == model.Id);
            }

            _HIW.img1Url = model.img1Url;
            _HIW.img2Url = model.img2Url;
            _HIW.paragraph1 = model.paragraph1;
            _HIW.paragraph2 = model.paragraph2;
            _HIW.paragraph3 = model.paragraph3;

            _HIW.Ar_paragraph1= model.Ar_paragraph1;
            _HIW.Ar_paragraph2 = model.Ar_paragraph2;
            _HIW.Ar_paragraph3 = model.Ar_paragraph3;

            _HIW.VIDUrl = model.VIDUrl;

            if (!IsEditMode)
            {
                _db.HIW.Add(_HIW);
            }
            _db.SaveChanges();
            return _HIW;
        }


        public async Task<Banner> GetBanner()
        {
            var _Banners = await _db.Banners.FirstOrDefaultAsync();

            if (_Banners == null)
            {
                _Banners = new Banner();
            }

            return _Banners;
        }



        public async Task<Banner> UpsertBanner(Banner model)
        {
            var IsEditMode = model.Id != 0;
            Banner _Banner = new Banner();

            if (IsEditMode)
            {
                _Banner = await _db.Banners.FirstOrDefaultAsync(x => x.Id == model.Id);
            }

            _Banner.Ar_Description = model.Ar_Description;
            _Banner.Ar_Title = model.Ar_Title;
            _Banner.En_Description = model.En_Description;
            _Banner.En_Title = model.En_Title;
            if(model.ImgUrl != null)
            {
                _Banner.ImgUrl = model.ImgUrl;
            }

            if (!IsEditMode)
            {
                _db.Banners.Add(_Banner);
            }
            _db.SaveChanges();
            return _Banner;
        }


        public async Task<AdvertisingReason> GetAdvertisingReasons()
        {
            var _AdvertisingReasons = await _db.AdvertisingReasons.FirstOrDefaultAsync();

            if (_AdvertisingReasons == null)
            {
                _AdvertisingReasons = new AdvertisingReason();
            }

            return _AdvertisingReasons;
        }


        public async Task<AdvertisingReason> UpsertAdvertisingReasons(AdvertisingReason model)
        {
            var IsEditMode = model.Id != 0;
            AdvertisingReason _model = new AdvertisingReason();

            if (IsEditMode)
            {
                _model = await _db.AdvertisingReasons.FirstOrDefaultAsync(x => x.Id == model.Id);
            }

            _model.Ar_Description1 = model.Ar_Description1;
            _model.Ar_Description2 = model.Ar_Description2;
            _model.Ar_Description3 = model.Ar_Description3;


            _model.Ar_Title1 = model.Ar_Title1;
            _model.Ar_Title2 = model.Ar_Title2;
            _model.Ar_Title3 = model.Ar_Title3;



            _model.En_Title1 = model.En_Title1;
            _model.En_Title2 = model.En_Title2;
            _model.En_Title3 = model.En_Title3;


            _model.En_Description1 = model.En_Description1;
            _model.En_Description2 = model.En_Description2;
            _model.En_Description3 = model.En_Description3;



            if (!IsEditMode)
            {
                _db.AdvertisingReasons.Add(_model);
            }
            _db.SaveChanges();
            return _model;
        }


        public async Task<SME> GetSMEs()
        {
            var _SME = await _db.SMEs.FirstOrDefaultAsync();

            if (_SME == null)
            {
                _SME = new SME();
            }

            return _SME;
        }

        public async Task<SME> UpsertSMEs(SME model)
        {
            var IsEditMode = model.Id != 0;
            SME _model = new SME();

            if (IsEditMode)
            {
                _model = await _db.SMEs.FirstOrDefaultAsync(x => x.Id == model.Id);
            }

            _model.Ar_Title = model.Ar_Title;
            _model.En_Title = model.En_Title;
            _model.Ar_Description = model.Ar_Description;
            _model.En_Description = model.En_Description;
            _model.VideoUrl = model.VideoUrl;


            if (!IsEditMode)
            {
                _db.SMEs.Add(_model);
            }
            _db.SaveChanges();
            return _model;
        }

        public async Task<AdvertisorImages> GetAdvertisorImages()
        {
            var _Model = await _db.AdvertisorImages.FirstOrDefaultAsync();

            if (_Model == null)
            {
                _Model = new AdvertisorImages();
            }

            return _Model;
        }

        public async Task<AdvertisorImages> UpsertAdvertisorImages(AdvertisorImages model)
        {
            var IsEditMode = model.Id != 0;
            AdvertisorImages _model = new AdvertisorImages();

            if (IsEditMode)
            {
                _model = await _db.AdvertisorImages.FirstOrDefaultAsync(x => x.Id == model.Id);
            }

            _model.ImageUrl1 = model.ImageUrl1;
            _model.ImageUrl2 = model.ImageUrl2;
            _model.FileUrl1 = model.FileUrl1;
            _model.FileUrl2 = model.FileUrl2;

            if (!IsEditMode)
            {
                _db.AdvertisorImages.Add(_model);
            }
            _db.SaveChanges();
            return _model;
        }

        public async Task<List<Advertising>> GetListOfAdvertisings()
        {
            var list = await _db.Advertisings.Include(l => l.AdvertisingBudget).ToListAsync();
            if (list == null)
            {
                list = new List<Advertising>();
            }

            return list;
        }


        public async Task<bool> DeleteAdvertisings(int id)
        {
            var _Model = await _db.Advertisings.FirstOrDefaultAsync(x => x.Id == id);

            if (_Model != null)
            {
                _db.Advertisings.Remove(_Model);
                _db.SaveChanges();

                return true;
            }

            return false;

        }
    }
}
using AutoMapper;
using insouq.EntityFramework;
using insouq.Models;
using insouq.Services.IServices;
using insouq.Shared.DTOS;
using insouq.Shared.DTOS.AdPictureDTOS;
using insouq.Shared.DTOS.Filters;
using insouq.Shared.Responses;
using insouq.Shared.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insouq.Services
{
    public class JobAdsService : IJobAdsService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IDropDownService _dropDownService;


        public JobAdsService(ApplicationDbContext db, IMapper mapper, IWebHostEnvironment hostEnvironment, IDropDownService dropDownService)
        {
            _db = db;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
            _dropDownService = dropDownService;
        }

        // get just for update !!!!
        public async Task<JobAdDTO> GetJobAd(int adId)
        {
            var ad = await _db.JobAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.Category)
                .Where(a => a.Ad.Status == 1 || a.Ad.Status == 2)
                .Select(job => new GetJobAdDTO
                {
                    TypeId = StaticData.Jobs_ID,
                    Id = job.Ad.Id,
                    En_JobType = job.En_JobType,
                    Ar_JobType = job.Ar_JobType,
                    PhoneNumber = job.Ad.PhoneNumber,
                    CV = job.CV,
                    En_Gender = job.En_Gender,
                    Ar_Gender = job.Ar_Gender,
                    En_Nationality = job.En_Nationality,
                    Ar_Nationality = job.Ar_Nationality,
                    En_CurrentLocation = job.En_CurrentLocation,
                    Ar_CurrentLocation = job.Ar_CurrentLocation,
                    En_EducationLevel = job.En_EducationLevel,
                    Ar_EducationLevel = job.Ar_EducationLevel,
                    CurrentPosition = job.CurrentPosition,
                    En_WorkExperience = job.En_WorkExperience,
                    Ar_WorkExperience = job.Ar_WorkExperience,
                    En_Commitment = job.En_Commitment,
                    Ar_Commitment = job.Ar_Commitment,
                    En_NoticePeriod = job.En_NoticePeriod,
                    Ar_NoticePeriod = job.Ar_NoticePeriod,
                    En_VisaStatus = job.En_VisaStatus,
                    Ar_VisaStatus = job.Ar_VisaStatus,
                    En_CareerLevel = job.En_CareerLevel,
                    Ar_CareerLevel = job.Ar_CareerLevel,
                    ExpectedMonthlySalary = job.ExpectedMonthlySalary,
                    CompanyName = job.CompanyName,
                    En_EmploymentType = job.En_EmploymentType,
                    Ar_EmploymentType = job.Ar_EmploymentType,
                    En_MinEducationLevel = job.En_MinEducationLevel,
                    Ar_MinEducationLevel = job.Ar_MinEducationLevel,
                    En_MinWorkExperience = job.En_MinWorkExperience,
                    Ar_MinWorkExperience = job.Ar_MinWorkExperience,
                    AgentId = job.Ad.AgentId,
                    CategoryId = job.Ad.CategoryId,
                    CategoryArName = job.Ad.Category.Ar_Name,
                    CategoryEnName = job.Ad.Category.En_Name,
                    Description = job.Ad.Description,
                    Lat = job.Ad.Lat,
                    Lng = job.Ad.Lng,
                    En_Location = job.Ad.En_Location,
                    Ar_Location = job.Ad.Ar_Location,
                    UserId = job.Ad.UserId,
                    PostDate = job.Ad.PostDate,
                    Title = job.Ad.Title,
                    Status = job.Ad.Status,
                    Pictures = job.Ad.Pictures.Select(p => new AdPictureDTO
                    {
                        Id = p.Id,
                        ImageURL = p.ImageURL,
                        MainPicture = p.MainPicture
                    }).ToList()
                }).AsNoTracking().FirstOrDefaultAsync(a => a.Id == adId && a.Status == 1);

            if (ad == null) return null;

            var dto = new JobAdDTO
            {
                AdId = ad.Id,
                Id = ad.Id,
                CareerLevel = ad.En_CareerLevel + "-" + ad.Ar_CareerLevel,
                CategoryId = ad.CategoryId,
                Commitment = ad.En_Commitment + "-" + ad.Ar_Commitment,
                CompanyName = ad.CompanyName,
                CurrentLocation = ad.En_CurrentLocation + "-" + ad.Ar_CurrentLocation,
                CurrentPosition = ad.CurrentPosition,
                CV = ad.CV,
                Description = ad.Description,
                EducationLevel = ad.En_EducationLevel + "-" + ad.Ar_EducationLevel,
                EmploymentType = ad.En_EmploymentType + "-" + ad.Ar_EmploymentType,
                ExpectedMonthlySalary = ad.ExpectedMonthlySalary,
                Gender = ad.En_Gender + "-" + ad.Ar_Gender,
                Lat = ad.Lat,
                Lng = ad.Lng,
                Location = ad.En_Location + "-" + ad.Ar_Location,
                MinEducationLevel = ad.En_MinEducationLevel + "-" + ad.Ar_MinEducationLevel,
                MinWorkExperience = ad.En_MinWorkExperience + "^" + ad.Ar_MinWorkExperience,
                Nationality = ad.En_Nationality + "-" + ad.Ar_Nationality,
                NoticePeriod = ad.En_NoticePeriod + "-" + ad.Ar_NoticePeriod,
                PhoneNumber = ad.PhoneNumber,
                Title = ad.Title,
                VisaStatus = ad.En_VisaStatus + "-" + ad.Ar_VisaStatus,
                WorkExperience = ad.En_WorkExperience + "^" + ad.Ar_WorkExperience,
            };


            var jobType = await _dropDownService.GetJobType(ad.En_JobType);

            if (jobType == null)
            {
                dto.OtherJobType = ad.En_JobType;
                dto.JobType = "others";
            }
            else
            {
                dto.OtherJobType = null;
                dto.JobType = ad.En_JobType + "-" + ad.Ar_JobType;
            }

            return dto;
        }


        public async Task<AddInitialJobWantedResponse> AddInitialJobWanted(int userId, AddInitialJobWanted model, string host)
        {
            var response = new AddInitialJobWantedResponse();

            try
            {
                var en_jobType = "";
                var ar_jobType = "";

                if (model.OtherJobType != null)
                {
                    en_jobType = model.OtherJobType;
                    ar_jobType = model.OtherJobType;
                }
                else
                {
                    var jobTypeArray = model.JobType.Split('-');
                    en_jobType = jobTypeArray[0].Trim();
                    ar_jobType = jobTypeArray[1].Trim();
                }


                var ad = new Ad()
                {
                    Title = model.Title,
                    PostDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    UserId = userId,
                    Status = 0,
                    CategoryId = StaticData.JobWanted_ID,
                    TypeId = StaticData.Jobs_ID,
                    PhoneNumber = model.PhoneNumber
                };

                await _db.Ads.AddAsync(ad);


                await _db.SaveChangesAsync();


                var jobWantedAd = new JobAd()
                {
                    En_JobType = en_jobType,
                    Ar_JobType = ar_jobType,
                    JobTitle = model.JobTitle,
                    AdId = ad.Id,
                };

                await _db.JobAds.AddAsync(jobWantedAd);

                await _db.SaveChangesAsync();

                response.IsSuccess = true;
                response.AdId = ad.Id;
                return response;

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = StaticData.ServerError_Message;
                return response;
            }
        }


        public async Task<BaseResponse> AddJobWanted(int userId, AddJobWanted model, string host)
        {
            var response = new BaseResponse();

            try
            {
                var category = await _db.Categories.FirstOrDefaultAsync(a => a.Id == StaticData.JobWanted_ID);

                if (category == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Category not found";
                    return response;
                }

                var ad = await _db.JobAds.Include(a => a.Ad).FirstOrDefaultAsync(a => a.AdId == model.AdId);


                if (ad == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Ad not found";
                    return response;
                }


                var en_gender = "";
                var ar_gender = "";

                if (model.Gender != null)
                {
                    var genderArray = model.Gender.Split('-');
                    en_gender = genderArray[0].Trim();
                    ar_gender = genderArray[1].Trim();
                }

                var en_nationality = "";
                var ar_nationality = "";

                if (model.Nationality != null)
                {
                    var nationalityArray = model.Nationality.Split('-');
                    en_nationality = nationalityArray[0].Trim();
                    ar_nationality = nationalityArray[1].Trim();
                }

                var en_currentLocation = "";
                var ar_currentLocation = "";

                if (model.CurrentLocation != null)
                {
                    var currentLocationArray = model.CurrentLocation.Split('-');
                    en_currentLocation = currentLocationArray[0].Trim();
                    ar_currentLocation = currentLocationArray[1].Trim();
                }

                var en_educationLevel = "";
                var ar_educationLevel = "";

                if (model.EducationLevel != null)
                {
                    var educationLevelArray = model.EducationLevel.Split('-');
                    en_educationLevel = educationLevelArray[0].Trim();
                    ar_educationLevel = educationLevelArray[1].Trim();
                }

                var en_commitment = "";
                var ar_commitment = "";

                if (model.Commitment != null)
                {
                    var commitmentArray = model.Commitment.Split('-');
                    en_commitment = commitmentArray[0].Trim();
                    ar_commitment = commitmentArray[1].Trim();
                }

                var en_noticePeriod = "";
                var ar_noticePeriod = "";

                if (model.NoticePeriod != null)
                {
                    var noticePeriodArray = model.NoticePeriod.Split('-');
                    en_noticePeriod = noticePeriodArray[0].Trim();
                    ar_noticePeriod = noticePeriodArray[1].Trim();
                }

                var en_visaStatus = "";
                var ar_visaStatus = "";

                if (model.VisaStatus != null)
                {
                    var visaStatusArray = model.VisaStatus.Split('-');
                    en_visaStatus = visaStatusArray[0].Trim();
                    ar_visaStatus = visaStatusArray[1].Trim();
                }

                var en_careerLevel = "";
                var ar_careerLevel = "";

                if (model.CareerLevel != null)
                {
                    var careerLevelArray = model.CareerLevel.Split('-');
                    en_careerLevel = careerLevelArray[0].Trim();
                    ar_careerLevel = careerLevelArray[1].Trim();
                }

                var en_workExperience = "";
                var ar_workExperience = "";

                if (model.WorkExperience != null)
                {
                    var WorkExperienceArray = model.WorkExperience.Split('^');
                    en_workExperience = WorkExperienceArray[0].Trim();
                    ar_workExperience = WorkExperienceArray[1].Trim();
                }


                var locationArray = model.Location.Split('-');

                var en_location = locationArray[0].Trim();

                var ar_location = locationArray[1].Trim();


                var adPictures = new List<AdPicture>();


                var adPicture = new AdPicture()
                {
                    ImageURL = @"\images\jobWantedImage.png",
                    MainPicture = true
                };

                adPictures.Add(adPicture);


                var cvImageUrl = "";

                if (model.CvFile != null)
                {
                    var webRootPath = _hostEnvironment.WebRootPath;

                    var folderPath = Path.Combine(webRootPath, "images");

                    cvImageUrl = await HelperFunctions.UploadImage(folderPath, model.CvFile, "ads", host);
                }


                ad.Ad.Description = model.Description;
                ad.Ad.En_Location = en_location;
                ad.Ad.Ar_Location = ar_location;
                ad.Ad.Lat = model.Lat;
                ad.Ad.Lng = model.Lng;
                ad.Ad.UserId = userId;
                ad.Ad.Status = 2;
                ad.Ad.Pictures = adPictures;


                category.NumberOfAds++;

                await _db.SaveChangesAsync();


                ad.CV = cvImageUrl == "" ? null : cvImageUrl;
                ad.En_Gender = en_gender != "" ? en_gender : null;
                ad.Ar_Gender = ar_gender != "" ? ar_gender : null;
                ad.En_Nationality = en_nationality != "" ? en_nationality : null;
                ad.Ar_Nationality = ar_nationality != "" ? ar_nationality : null;
                ad.En_CurrentLocation = en_currentLocation != "" ? en_currentLocation : null;
                ad.Ar_CurrentLocation = ar_currentLocation != "" ? ar_currentLocation : null;
                ad.En_EducationLevel = en_educationLevel != "" ? en_educationLevel : null;
                ad.Ar_EducationLevel = ar_educationLevel != "" ? ar_educationLevel : null;
                ad.CurrentPosition = model.CurrentPosition;
                ad.En_WorkExperience = en_workExperience != "" ? en_workExperience : null;
                ad.Ar_WorkExperience = ar_workExperience != "" ? ar_workExperience : null;
                ad.En_Commitment = en_commitment != "" ? en_commitment : null;
                ad.Ar_Commitment = ar_commitment != "" ? ar_commitment : null;
                ad.En_NoticePeriod = en_noticePeriod != "" ? en_noticePeriod : null;
                ad.Ar_NoticePeriod = ar_noticePeriod != "" ? ar_noticePeriod : null;
                ad.En_VisaStatus = en_visaStatus != "" ? en_visaStatus : null;
                ad.Ar_VisaStatus = ar_visaStatus != "" ? ar_visaStatus : null;
                ad.En_CareerLevel = en_careerLevel != "" ? en_careerLevel : null;
                ad.Ar_CareerLevel = ar_careerLevel != "" ? ar_careerLevel : null;
                ad.ExpectedMonthlySalary = model.ExpectedMonthlySalary;


                await _db.SaveChangesAsync();

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


        public async Task<BaseResponse> Add(int userId, JobAdDTO model, string host)
        {
            var response = new BaseResponse();

            try
            {
                var category = await _db.Categories.FirstOrDefaultAsync(a => a.Id == model.CategoryId);

                if (category == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Category not found";
                    return response;
                }


                var en_jobType = "";
                var ar_jobType = "";

                if (model.OtherJobType != null)
                {
                    en_jobType = model.OtherJobType;
                    ar_jobType = model.OtherJobType;
                }
                else
                {
                    var jobTypeArray = model.JobType.Split('-');
                    en_jobType = jobTypeArray[0].Trim();
                    ar_jobType = jobTypeArray[1].Trim();
                }

                var en_gender = "";
                var ar_gender = "";

                if (model.Gender != null)
                {
                    var genderArray = model.Gender.Split('-');
                    en_gender = genderArray[0].Trim();
                    ar_gender = genderArray[1].Trim();
                }

                var en_nationality = "";
                var ar_nationality = "";

                if (model.Nationality != null)
                {
                    var nationalityArray = model.Nationality.Split('-');
                    en_nationality = nationalityArray[0].Trim();
                    ar_nationality = nationalityArray[1].Trim();
                }

                var en_currentLocation = "";
                var ar_currentLocation = "";

                if (model.CurrentLocation != null)
                {
                    var currentLocationArray = model.CurrentLocation.Split('-');
                    en_currentLocation = currentLocationArray[0].Trim();
                    ar_currentLocation = currentLocationArray[1].Trim();
                }

                var en_educationLevel = "";
                var ar_educationLevel = "";

                if (model.EducationLevel != null)
                {
                    var educationLevelArray = model.EducationLevel.Split('-');
                    en_educationLevel = educationLevelArray[0].Trim();
                    ar_educationLevel = educationLevelArray[1].Trim();
                }

                var en_commitment = "";
                var ar_commitment = "";

                if (model.Commitment != null)
                {
                    var commitmentArray = model.Commitment.Split('-');
                    en_commitment = commitmentArray[0].Trim();
                    ar_commitment = commitmentArray[1].Trim();
                }

                var en_noticePeriod = "";
                var ar_noticePeriod = "";

                if (model.NoticePeriod != null)
                {
                    var noticePeriodArray = model.NoticePeriod.Split('-');
                    en_noticePeriod = noticePeriodArray[0].Trim();
                    ar_noticePeriod = noticePeriodArray[1].Trim();
                }

                var en_visaStatus = "";
                var ar_visaStatus = "";

                if (model.VisaStatus != null)
                {
                    var visaStatusArray = model.VisaStatus.Split('-');
                    en_visaStatus = visaStatusArray[0].Trim();
                    ar_visaStatus = visaStatusArray[1].Trim();
                }

                var en_careerLevel = "";
                var ar_careerLevel = "";

                if (model.CareerLevel != null)
                {
                    var careerLevelArray = model.CareerLevel.Split('-');
                    en_careerLevel = careerLevelArray[0].Trim();
                    ar_careerLevel = careerLevelArray[1].Trim();
                }


                var en_employmentType = "";
                var ar_employmentType = "";

                if (model.EmploymentType != null)
                {
                    var employmentTypeArray = model.EmploymentType.Split('-');
                    en_employmentType = employmentTypeArray[0].Trim();
                    ar_employmentType = employmentTypeArray[1].Trim();
                }

                var en_minEducationLevel = "";
                var ar_minEducationLevel = "";

                if (model.MinEducationLevel != null)
                {
                    var minEducationLevelArray = model.MinEducationLevel.Split('-');
                    en_minEducationLevel = minEducationLevelArray[0].Trim();
                    ar_minEducationLevel = minEducationLevelArray[1].Trim();
                }

                var en_workExperience = "";
                var ar_workExperience = "";

                if (model.WorkExperience != null)
                {
                    var WorkExperienceArray = model.WorkExperience.Split('^');
                    en_workExperience = WorkExperienceArray[0].Trim();
                    ar_workExperience = WorkExperienceArray[1].Trim();
                }

                var en_minWorkExperience = "";
                var ar_minWorkExperience = "";

                if (model.MinWorkExperience != null)
                {
                    var MinWorkExperienceArray = model.MinWorkExperience.Split('^');
                    en_minWorkExperience = MinWorkExperienceArray[0].Trim();
                    ar_minWorkExperience = MinWorkExperienceArray[1].Trim();
                }

                var locationArray = model.Location.Split('-');

                var en_location = locationArray[0].Trim();

                var ar_location = locationArray[1].Trim();

                var adPictures = new List<AdPicture>();

                var adPicture = new AdPicture()
                {
                    ImageURL = @"\images\defaultAdImage.png",
                    MainPicture = true
                };

                adPictures.Add(adPicture);

                var cvImageUrl = "";

                if (model.CvFile != null)
                {
                    var webRootPath = _hostEnvironment.WebRootPath;

                    var folderPath = Path.Combine(webRootPath, "images");

                    cvImageUrl = await HelperFunctions.UploadImage(folderPath, model.CvFile, "ads", host);
                }


                var ad = new Ad()
                {
                    Title = model.Title,
                    Description = model.Description,
                    En_Location = en_location,
                    Ar_Location = ar_location,
                    PostDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    Lat = model.Lat,
                    Lng = model.Lng,
                    UserId = userId,
                    Status = 2,
                    CategoryId = model.CategoryId,
                    TypeId = StaticData.Jobs_ID,
                    PhoneNumber = model.PhoneNumber,
                    Pictures = adPictures
                };

                await _db.Ads.AddAsync(ad);

                category.NumberOfAds++;

                await _db.SaveChangesAsync();



                var jobOpeningAd = new JobAd()
                {
                    En_JobType = en_jobType,
                    Ar_JobType = ar_jobType,
                    CV = cvImageUrl == "" ? null : cvImageUrl,
                    En_Gender = en_gender != "" ? en_gender : null,
                    Ar_Gender = ar_gender != "" ? ar_gender : null,
                    En_Nationality = en_nationality != "" ? en_nationality : null,
                    Ar_Nationality = ar_nationality != "" ? ar_nationality : null,
                    En_CurrentLocation = en_currentLocation != "" ? en_currentLocation : null,
                    Ar_CurrentLocation = ar_currentLocation != "" ? ar_currentLocation : null,
                    En_EducationLevel = en_educationLevel != "" ? en_educationLevel : null,
                    Ar_EducationLevel = ar_educationLevel != "" ? ar_educationLevel : null,
                    CurrentPosition = model.CurrentPosition,
                    En_WorkExperience = en_workExperience != "" ? en_workExperience : null,
                    Ar_WorkExperience = ar_workExperience != "" ? ar_workExperience : null,
                    En_Commitment = en_commitment != "" ? en_commitment : null,
                    Ar_Commitment = ar_commitment != "" ? ar_commitment : null,
                    En_NoticePeriod = en_noticePeriod != "" ? en_noticePeriod : null,
                    Ar_NoticePeriod = ar_noticePeriod != "" ? ar_noticePeriod : null,
                    En_VisaStatus = en_visaStatus != "" ? en_visaStatus : null,
                    Ar_VisaStatus = ar_visaStatus != "" ? ar_visaStatus : null,
                    En_CareerLevel = en_careerLevel != "" ? en_careerLevel : null,
                    Ar_CareerLevel = ar_careerLevel != "" ? ar_careerLevel : null,
                    ExpectedMonthlySalary = model.ExpectedMonthlySalary,
                    CompanyName = model.CompanyName,
                    En_EmploymentType = en_employmentType != "" ? en_employmentType : null,
                    Ar_EmploymentType = ar_employmentType != "" ? ar_employmentType : null,
                    En_MinEducationLevel = en_minEducationLevel != "" ? en_minEducationLevel : null,
                    Ar_MinEducationLevel = ar_minEducationLevel != "" ? ar_minEducationLevel : null,
                    En_MinWorkExperience = en_minWorkExperience != "" ? en_minWorkExperience : null,
                    Ar_MinWorkExperience = ar_minWorkExperience != "" ? ar_minWorkExperience : null,

                    AdId = ad.Id,
                };

                await _db.JobAds.AddAsync(jobOpeningAd);

                await _db.SaveChangesAsync();

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


        public async Task<List<GetJobAdDTO>> FilterJobs(JobFilters model)
        {

            var en_jobType = "";
            var en_commitment = "";
            var en_location = "";
            var en_educationLevel = "";
            var en_workExperience = "";


            if (!string.IsNullOrEmpty(model.JobType))
            {
                en_jobType = model.JobType.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.Commitment))
            {
                en_commitment = model.Commitment.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.EducationLevel))
            {
                en_educationLevel = model.EducationLevel.Split('-')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.WorkExperience))
            {
                en_workExperience = model.WorkExperience.Split('^')[0].Trim();
            }

            if (!string.IsNullOrEmpty(model.Location))
            {
                en_location = model.Location.Split('-')[0].Trim();
            }

            var query = _db.JobAds.Include(a => a.Ad).Include(a => a.Ad.Pictures).Include(a => a.Ad.User).Where(a => a.Ad.CategoryId == model.CategoryId
            && a.Ad.Status == 1);

            if (!string.IsNullOrEmpty(model.Keyword))
            {
                query = query.Where(a => a.Ad.Title.Contains(model.Keyword));
            }

            if (en_jobType != "")
            {
                query = query.Where(a => a.En_JobType == en_jobType);
            }

            if (model.CategoryId == StaticData.JobWanted_ID)
            {
                if (en_commitment != "")
                {
                    query = query.Where(a => a.En_Commitment == en_commitment);
                }

                if (en_workExperience != "")
                {
                    query = query.Where(a => a.En_WorkExperience == en_workExperience);
                }
            }
            else if (model.CategoryId == StaticData.JobOpening_ID)
            {
                if (en_commitment != "")
                {
                    query = query.Where(a => a.En_EmploymentType == en_commitment);
                }

                if (en_workExperience != "")
                {
                    query = query.Where(a => a.En_MinWorkExperience == en_workExperience);
                }
            }

            if (model.CategoryId == StaticData.JobWanted_ID)
            {
                if (en_educationLevel != "")
                {
                    query = query.Where(a => a.En_EducationLevel == en_educationLevel);
                }
            }
            else if (model.CategoryId == StaticData.JobOpening_ID)
            {
                if (en_educationLevel != "")
                {
                    query = query.Where(a => a.En_MinEducationLevel == en_educationLevel);
                }
            }


            if (en_location != "")
            {
                query = query.Where(a => a.Ad.En_Location == en_location);
            }

            if (model.PostedIn != null)
            {
                if (model.PostedIn == StaticData.Posted_Today)
                {
                    query = query.Where(a => a.Ad.PostDate.Date == DateTime.Today);
                }

                //else if (model.PostedIn == StaticData.Posted_ThisWeek)
                //{
                //    query = query.Where(a => a.Ad.PostDate.Date == DateTime.);
                //}
            }

            if (model.SortBy == StaticData.Newest_To_Oldest)
            {
                query = query.OrderByDescending(m => m.Ad.PostDate);
            }
            else if (model.SortBy == StaticData.Oldest_To_Newest)
            {
                query = query.OrderBy(m => m.Ad.PostDate);
            }

            var list = await query.Select(job => new GetJobAdDTO
            {
                TypeId = job.Ad.TypeId,
                Id = job.Ad.Id,
                En_JobType = job.En_JobType,
                Ar_JobType = job.Ar_JobType,
                PhoneNumber = job.Ad.PhoneNumber,
                CV = job.CV,
                En_Gender = job.En_Gender,
                Ar_Gender = job.Ar_Gender,
                En_Nationality = job.En_Nationality,
                Ar_Nationality = job.Ar_Nationality,
                En_CurrentLocation = job.En_CurrentLocation,
                Ar_CurrentLocation = job.Ar_CurrentLocation,
                En_EducationLevel = job.En_EducationLevel,
                Ar_EducationLevel = job.Ar_EducationLevel,
                CurrentPosition = job.CurrentPosition,
                En_WorkExperience = job.En_WorkExperience,
                Ar_WorkExperience = job.Ar_WorkExperience,
                En_Commitment = job.En_Commitment,
                Ar_Commitment = job.Ar_Commitment,
                En_NoticePeriod = job.En_NoticePeriod,
                Ar_NoticePeriod = job.Ar_NoticePeriod,
                En_VisaStatus = job.En_VisaStatus,
                Ar_VisaStatus = job.Ar_VisaStatus,
                En_CareerLevel = job.En_CareerLevel,
                Ar_CareerLevel = job.Ar_CareerLevel,
                ExpectedMonthlySalary = job.ExpectedMonthlySalary,
                CompanyName = job.CompanyName,
                En_EmploymentType = job.En_EmploymentType,
                Ar_EmploymentType = job.Ar_EmploymentType,
                En_MinEducationLevel = job.En_MinEducationLevel,
                Ar_MinEducationLevel = job.Ar_MinEducationLevel,
                En_MinWorkExperience = job.En_MinWorkExperience,
                Ar_MinWorkExperience = job.Ar_MinWorkExperience,
                UserImage = job.Ad.User.ProfilePicture,
                AgentId = job.Ad.AgentId,
                CategoryId = job.Ad.CategoryId,
                CategoryArName = job.Ad.Category.Ar_Name,
                CategoryEnName = job.Ad.Category.En_Name,
                Description = job.Ad.Description,
                Lat = job.Ad.Lat,
                Lng = job.Ad.Lng,
                En_Location = job.Ad.En_Location,
                Ar_Location = job.Ad.Ar_Location,
                UserId = job.Ad.UserId,
                PostDate = job.Ad.PostDate,
                Title = job.Ad.Title,
                Status = job.Ad.Status,
                Pictures = job.Ad.Pictures.Select(p => new AdPictureDTO
                {
                    Id = p.Id,
                    ImageURL = p.ImageURL,
                    MainPicture = p.MainPicture
                }).ToList()
            }).AsNoTracking().ToListAsync();

            return list;
        }


        public async Task<BaseResponse> Update(int userId, JobAdDTO model,string host)
        {

            var response = new BaseResponse();

            try
            {
                var ad = await _db.JobAds.Include(a => a.Ad)
                    .FirstOrDefaultAsync(a => a.AdId == model.AdId && a.Ad.UserId == userId);

                if (ad == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not Found";
                    return response;
                }

                var en_jobType = "";
                var ar_jobType = "";

                if (model.OtherJobType != null)
                {
                    en_jobType = model.OtherJobType;
                    ar_jobType = model.OtherJobType;
                }
                else
                {
                    var jobTypeArray = model.JobType.Split('-');
                    en_jobType = jobTypeArray[0].Trim();
                    ar_jobType = jobTypeArray[1].Trim();
                }

                var en_gender = "";
                var ar_gender = "";

                if (model.Gender != null)
                {
                    var genderArray = model.Gender.Split('-');
                    en_gender = genderArray[0].Trim();
                    ar_gender = genderArray[1].Trim();
                }

                var en_nationality = "";
                var ar_nationality = "";

                if (model.Nationality != null)
                {
                    var nationalityArray = model.Nationality.Split('-');
                    en_nationality = nationalityArray[0].Trim();
                    ar_nationality = nationalityArray[1].Trim();
                }

                var en_currentLocation = "";
                var ar_currentLocation = "";

                if (model.CurrentLocation != null)
                {
                    var currentLocationArray = model.CurrentLocation.Split('-');
                    en_currentLocation = currentLocationArray[0].Trim();
                    ar_currentLocation = currentLocationArray[1].Trim();
                }

                var en_educationLevel = "";
                var ar_educationLevel = "";

                if (model.EducationLevel != null)
                {
                    var educationLevelArray = model.EducationLevel.Split('-');
                    en_educationLevel = educationLevelArray[0].Trim();
                    ar_educationLevel = educationLevelArray[1].Trim();
                }

                var en_commitment = "";
                var ar_commitment = "";

                if (model.Commitment != null)
                {
                    var commitmentArray = model.Commitment.Split('-');
                    en_commitment = commitmentArray[0].Trim();
                    ar_commitment = commitmentArray[1].Trim();
                }

                var en_noticePeriod = "";
                var ar_noticePeriod = "";

                if (model.NoticePeriod != null)
                {
                    var noticePeriodArray = model.NoticePeriod.Split('-');
                    en_noticePeriod = noticePeriodArray[0].Trim();
                    ar_noticePeriod = noticePeriodArray[1].Trim();
                }

                var en_visaStatus = "";
                var ar_visaStatus = "";

                if (model.VisaStatus != null)
                {
                    var visaStatusArray = model.VisaStatus.Split('-');
                    en_visaStatus = visaStatusArray[0].Trim();
                    ar_visaStatus = visaStatusArray[1].Trim();
                }

                var en_careerLevel = "";
                var ar_careerLevel = "";

                if (model.CareerLevel != null)
                {
                    var careerLevelArray = model.CareerLevel.Split('-');
                    en_careerLevel = careerLevelArray[0].Trim();
                    ar_careerLevel = careerLevelArray[1].Trim();
                }


                var en_employmentType = "";
                var ar_employmentType = "";

                if (model.EmploymentType != null)
                {
                    var employmentTypeArray = model.EmploymentType.Split('-');
                    en_employmentType = employmentTypeArray[0].Trim();
                    ar_employmentType = employmentTypeArray[1].Trim();
                }

                var en_minEducationLevel = "";
                var ar_minEducationLevel = "";

                if (model.MinEducationLevel != null)
                {
                    var minEducationLevelArray = model.MinEducationLevel.Split('-');
                    en_minEducationLevel = minEducationLevelArray[0].Trim();
                    ar_minEducationLevel = minEducationLevelArray[1].Trim();
                }

                var en_workExperience = "";
                var ar_workExperience = "";

                if (model.WorkExperience != null)
                {
                    var WorkExperienceArray = model.WorkExperience.Split('^');
                    en_workExperience = WorkExperienceArray[0].Trim();
                    ar_workExperience = WorkExperienceArray[1].Trim();
                }

                var en_minWorkExperience = "";
                var ar_minWorkExperience = "";

                if (model.MinWorkExperience != null)
                {
                    var MinWorkExperienceArray = model.MinWorkExperience.Split('^');
                    en_minWorkExperience = MinWorkExperienceArray[0].Trim();
                    ar_minWorkExperience = MinWorkExperienceArray[1].Trim();
                }

                var locationArray = model.Location.Split('-');

                var en_location = locationArray[0].Trim();

                var ar_location = locationArray[1].Trim();

                var cvImageUrl = ad.CV;

                if (model.CvFile != null)
                {
                    var webRootPath = _hostEnvironment.WebRootPath;

                    var folderPath = Path.Combine(webRootPath, "images");

                    cvImageUrl = await HelperFunctions.UploadImage(folderPath, model.CvFile, "ads", host);
                }

                ad.Ad.Title = model.Title;
                ad.Ad.Description = model.Description;
                ad.Ad.En_Location = en_location;
                ad.Ad.Ar_Location = ar_location;
                ad.Ad.LastUpdatedDate = DateTime.Now;
                ad.Ad.Lat = model.Lat;
                ad.Ad.Lng = model.Lng;
                ad.Ad.PhoneNumber = model.PhoneNumber;

                ad.En_JobType = en_jobType;
                ad.Ar_JobType = ar_jobType;
                if (string.IsNullOrEmpty(cvImageUrl))
                {
                    ad.CV = null;
                }
                else
                {
                    ad.CV = cvImageUrl;
                }
                ad.En_Gender = en_gender != "" ? en_gender : null;
                ad.Ar_Gender = ar_gender != "" ? ar_gender : null;
                ad.En_Nationality = en_nationality != "" ? en_nationality : null;
                ad.Ar_Nationality = ar_nationality != "" ? ar_nationality : null;
                ad.En_CurrentLocation = en_currentLocation != "" ? en_currentLocation : null;
                ad.Ar_CurrentLocation = ar_currentLocation != "" ? ar_currentLocation : null;
                ad.En_EducationLevel = en_educationLevel != "" ? en_educationLevel : null;
                ad.Ar_EducationLevel = ar_educationLevel != "" ? ar_educationLevel : null;
                ad.CurrentPosition = model.CurrentPosition;
                ad.En_WorkExperience = en_workExperience != "" ? en_workExperience : null;
                ad.Ar_WorkExperience = ar_workExperience != "" ? ar_workExperience : null;
                ad.En_Commitment = en_commitment != "" ? en_commitment : null;
                ad.Ar_Commitment = ar_commitment != "" ? ar_commitment : null;
                ad.En_NoticePeriod = en_noticePeriod != "" ? en_noticePeriod : null;
                ad.Ar_NoticePeriod = ar_noticePeriod != "" ? ar_noticePeriod : null;
                ad.En_VisaStatus = en_visaStatus != "" ? en_visaStatus : null;
                ad.Ar_VisaStatus = ar_visaStatus != "" ? ar_visaStatus : null;
                ad.En_CareerLevel = en_careerLevel != "" ? en_careerLevel : null;
                ad.Ar_CareerLevel = ar_careerLevel != "" ? ar_careerLevel : null;
                ad.ExpectedMonthlySalary = model.ExpectedMonthlySalary;
                ad.CompanyName = model.CompanyName;
                ad.En_EmploymentType = en_employmentType != "" ? en_employmentType : null;
                ad.Ar_EmploymentType = ar_employmentType != "" ? ar_employmentType : null;
                ad.En_MinEducationLevel = en_minEducationLevel != "" ? en_minEducationLevel : null;
                ad.Ar_MinEducationLevel = ar_minEducationLevel != "" ? ar_minEducationLevel : null;
                ad.En_MinWorkExperience = en_minWorkExperience != "" ? en_minWorkExperience : null;
                ad.Ar_MinWorkExperience = ar_minWorkExperience != "" ? ar_minWorkExperience : null;

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

    }
}

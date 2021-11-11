using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using insouq.Models;
using insouq.Models.Dropdownlists;
using insouq.Models.IdentityConfiguration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace insouq.EntityFramework
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<int>>().HasKey(p => new { p.UserId, p.RoleId });

            builder.Entity<Models.Type>()
                .HasMany(c => c.Ads)
                .WithOne(t => t.Type)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Ad>()
    .HasOne(a => a.Type)
    .WithMany(t => t.Ads)
    .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<PropertyAd>()
.HasOne(c => c.SubCategory)
.WithMany()
.OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ServiceAd>()
.HasOne(c => c.SubCategory)
.WithMany()
.OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ClassifiedAd>()
.HasOne(c => c.SubCategory)
.WithMany()
.OnDelete(DeleteBehavior.Restrict);


            builder.Entity<ClassifiedAd>()
.HasOne(c => c.SubType)
.WithMany()
.OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ElectronicAd>()
.HasOne(c => c.SubCategory)
.WithMany()
.OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ElectronicAd>()
.HasOne(c => c.SubType)
.WithMany()
.OnDelete(DeleteBehavior.Restrict);

            builder.Entity<BussinesAd>()
.HasOne(c => c.SubCategory)
.WithMany()
.OnDelete(DeleteBehavior.Restrict);


//            builder.Entity<DLAge>()
//.HasOne(c => c.Type)
//.WithMany()
//.OnDelete(DeleteBehavior.Restrict);

//            builder.Entity<DLAge>()
//.HasOne(c => c.Category)
//.WithMany()
//.OnDelete(DeleteBehavior.Restrict);

//            builder.Entity<DLUsage>()
//.HasOne(c => c.Type)
//.WithMany()
//.OnDelete(DeleteBehavior.Restrict);

//            builder.Entity<DLUsage>()
//.HasOne(c => c.Category)
//.WithMany()
//.OnDelete(DeleteBehavior.Restrict);

//            builder.Entity<DLCondition>()
//.HasOne(c => c.Type)
//.WithMany()
//.OnDelete(DeleteBehavior.Restrict);

//            builder.Entity<DLCondition>()
//.HasOne(c => c.Category)
//.WithMany()
//.OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(builder);
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Models.Type> Types { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<SubType> SubTypes { get; set; }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<MotorAd> MotorAds  { get; set; }
        public DbSet<PropertyAd> PropertyAds { get; set; }
        public DbSet<JobAd> JobAds { get; set; }
        public DbSet<AdStatistic> AdStatistics { get; set; }
        public DbSet<Advertising> Advertisings { get; set; }
        public DbSet<NumberAd> NumberAds { get; set; }
        public DbSet<BussinesAd> BussinesAds { get; set; }
        public DbSet<ClassifiedAd> ClassifiedAds { get; set; }
        public DbSet<ServiceAd> ServiceAds { get; set; }
        public DbSet<ElectronicAd> ElectronicAds { get; set; }
        public DbSet<AdPicture> AdPictures { get; set; }
        public DbSet<SavedSearch> SavedSearch { get; set; }
        public DbSet<OTP> OTPs { get; set; }
        public DbSet<CompanyProfile> CompanyProfiles { get; set; }
        public DbSet<AdOffer> AdOffers { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<FavoriteAd> Favorites { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<Notification> Notifications { get; set; }


        //DLs

        public DbSet<DLCommitment> DLCommitments { get; set; }
        public DbSet<DLJobType> DLJobTypes { get; set; }
        public DbSet<DLMonthlySalary> DLMonthlySalaries { get; set; }
        public DbSet<DLNoticePeriod> DLNoticePeriods { get; set; }
        public DbSet<DLVisaStatus> DLVisaStatuses { get; set; }
        public DbSet<DLWorkExperience> DLWorkExperiences { get; set; }
        public DbSet<DLBodyType> DLBodyTypes { get; set; }
        public DbSet<DLNumberPlan> DLNumberPlans { get; set; }
        public DbSet<DLCapacity> DLCapacities { get; set; }
        public DbSet<DLColor> DLColors { get; set; }
        public DbSet<DLEngineSize> DLEngineSizes { get; set; }
        public DbSet<DLSellerType> DLSellerTypes { get; set; }
        public DbSet<DLFinalDriveSystem> DLFinalDriveSystems { get; set; }
        public DbSet<DLFuelType> DLFuelTypes { get; set; }
        public DbSet<DLHorsepower> DLHorsepowers { get; set; }
        public DbSet<DLMechanicalCondition> DLMechanicalConditions { get; set; }
        public DbSet<DLDoor> DLDoors { get; set; }
        public DbSet<DLMotorLength> DLMotorLengths { get; set; }
        public DbSet<DLMotorMaker> DLMotorMakers { get; set; }
        public DbSet<DLMotorModel> DLMotorModels { get; set; }
        public DbSet<DLMotorRegionalSpecs> DLMotorRegionalSpecs { get; set; }
        public DbSet<DLMotorTrim> DLMotorTrims { get; set; }
        public DbSet<DLNoOfCylinders> DLNoOfCylinders { get; set; }
        public DbSet<DLTransmission> DLTransmissions { get; set; }
        public DbSet<DLWheels> DLWheels { get; set; }
        public DbSet<DLYear> DLYears { get; set; }
        public DbSet<DLLength> DLLengths { get; set; }
        public DbSet<DLBathooms> DLBathooms { get; set; }
        public DbSet<DLBedrooms> DLBedrooms { get; set; }
        public DbSet<DLFurnishing> DLFurnishings { get; set; }
        public DbSet<DLAge> DLAges { get; set; }
        public DbSet<DLCareerLevel> DLCareerLevels { get; set; }
        public DbSet<DLCompanyIndustry> DLCompanyIndustries { get; set; }
        public DbSet<DLCompanySize> DLCompanySizes { get; set; }
        public DbSet<DLCondition> DLConditions { get; set; }
        public DbSet<DLEducationLevel> DLEducationLevels { get; set; }
        public DbSet<DLEmploymentType> DLEmploymentTypes { get; set; }
        public DbSet<DLLocation> DLLocations { get; set; }
        public DbSet<DLNationality> DLNationalities { get; set; }
        public DbSet<DLUsage> DLUsages { get; set; }
        public DbSet<DLCurrentNetwork> DLCurrentNetworks { get; set; }
        public DbSet<DLEmirate> DLEmirates { get; set; }
        public DbSet<DLMobileNumberCode> DLMobileNumberCodes { get; set; }
        public DbSet<DLOperator> DLOperators { get; set; }
        public DbSet<DLPlateCode> DLPlateCodes { get; set; }
        public DbSet<DLPlateDesign> DLPlateDesigns { get; set; }
        public DbSet<DLPlateType> DLPlateTypes { get; set; }
        public DbSet<DLSteeringSide> DLSteeringSides { get; set; }
        public DbSet<DLPart> DLParts { get; set; }
        public DbSet<DLAdvertisingBudjet> DLAdvertisingBudjets { get; set; }
    }
}


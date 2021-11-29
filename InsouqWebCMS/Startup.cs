using AutoMapper;
using insouq.Configuration;
using insouq.EntityFramework;
using insouq.Models.IdentityConfiguration;
using insouq.Services;
using insouq.Services.CMS;
using insouq.Services.Configuration;
using insouq.Services.IServices;
using insouq.Services.IServices.CMS;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsouqWebCMS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            #region IdentityConfigration
            services.AddScoped<SignInManager<ApplicationUser>>();
            services.AddScoped<UserManager<ApplicationUser>>();
            services.AddScoped<RoleManager<IdentityRole<int>>>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole<int>>()
                            .AddEntityFrameworkStores<ApplicationDbContext>()
                            .AddRoles<IdentityRole<int>>()
                              .AddSignInManager<SignInManager<ApplicationUser>>()
                            .AddDefaultTokenProviders();
            #endregion

            services.AddScoped<ICMSAccountsService, CMSAccountsService>();
            services.AddScoped<ICMSAds, CMSAds>();
            services.AddScoped<ICMSUsersService, CMSUsersService>();
            services.AddScoped<ICMSDropDownService, CMSDropDownService>();
            services.AddScoped<ISubCategoryService, SubCategoryService>();
            services.AddScoped<ISubTypeService, SubTypeService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IStaticDataService, CMSStaticDataService>();


            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);

            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddControllersWithViews();

            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login/";
                    options.ExpireTimeSpan = TimeSpan.FromHours(2);
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
Path.Combine(env.WebRootPath, "images")),
                RequestPath = "/images"
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=AdsManagement}/{action=Index}/{id?}");
            });
        }
    }
}
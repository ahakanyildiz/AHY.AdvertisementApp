using AHY.AdvertisementApp.Business.DependencyResolvers.Microsoft;
using AHY.AdvertisementApp.Business.Helpers;
using AHY.AdvertisementApp.UI.Mappings.AutoMapper;
using AHY.AdvertisementApp.UI.Models;
using AHY.AdvertisementApp.UI.ValidationRules;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace AHY.AdvertisementApp.UI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDependencies(Configuration);
            var mapperConfiguration = new MapperConfiguration(opt =>
            {
                opt.AddProfiles(ProfileHelper.GetProfileList());
                opt.AddProfile(new UserCreateModelProfile());
            });
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
            services.AddTransient<IValidator<UserCreateModel>, UserCreateModelValidator>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(opt =>
            {
                opt.Cookie.Name = "AHY.AdvertisementApp";
                opt.Cookie.HttpOnly = true;
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.SecurePolicy= CookieSecurePolicy.SameAsRequest;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
                opt.LoginPath= new PathString("/Account/SignIn");
                opt.LogoutPath = new PathString("/Account/LogOut");
                opt.AccessDeniedPath = new PathString("/Account/AccessDenied");
            });
                                                                              
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}

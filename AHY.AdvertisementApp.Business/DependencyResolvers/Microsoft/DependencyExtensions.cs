using AHY.AdvertisementApp.Business.Abstract;
using AHY.AdvertisementApp.Business.Concrete;
using AHY.AdvertisementApp.Business.Mappings.AutoMapper;
using AHY.AdvertisementApp.Business.Services;
using AHY.AdvertisementApp.Business.ValidationRules.Advertisement;
using AHY.AdvertisementApp.Business.ValidationRules.AppUser;
using AHY.AdvertisementApp.Business.ValidationRules.Gender;
using AHY.AdvertisementApp.Business.ValidationRules.ProvidedService;
using AHY.AdvertisementApp.DataAccess.Contexts;
using AHY.AdvertisementApp.DataAccess.UnitOfWork;
using AHY.AdvertisementApp.Dtos;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AHY.AdvertisementApp.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtensions
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdvertisementContext>(opt =>
            {
                //Appsetings.json dosyasından veritabanı bağlantı adresimi okudum.
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });

            #region AutoMapper Injection
            var mapperConfiguration = new MapperConfiguration(opt =>
                {
                    opt.AddProfile(new ProvidedServiceProfile());
                    opt.AddProfile(new AdvertisementProfile());
                    opt.AddProfile(new AppUserProfile());
                    opt.AddProfile(new GenderProfile());
                });

            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            services.AddScoped<IUow, Uow>();

            #region Validator Injections
            services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceUpdateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementCreateDto>, AdvertisementCreateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementUpdateDto>, AdvertisementUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();
            services.AddTransient<IValidator<GenderCreateDto>, GenderCreateDtoValidator>();
            services.AddTransient<IValidator<GenderUpdateDto>, GenderUpdateDtoValidator>();
            #endregion

            #region Service Injection
            services.AddScoped<IProvidedServiceService, ProvidedServiceManager>();
            services.AddScoped<IAdvertisementService, AdvertisementManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IGenderService, GenderManager>();
            #endregion                     
        }
    }
}

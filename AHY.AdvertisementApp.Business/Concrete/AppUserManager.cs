using AHY.AdvertisementApp.Business.Abstract;
using AHY.AdvertisementApp.Business.Services;
using AHY.AdvertisementApp.DataAccess.UnitOfWork;
using AHY.AdvertisementApp.Dtos;
using AHY.AdvertisementApp.Entities;
using AutoMapper;
using FluentValidation;

namespace AHY.AdvertisementApp.Business.Concrete
{
    public class AppUserManager : GenericManager<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>, IAppUserService
    {
        public AppUserManager(IMapper mapper, IValidator<AppUserCreateDto> createDtoValidator, IValidator<AppUserUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
        }
    }
}

using AHY.AdvertisementApp.Business.Abstract;
using AHY.AdvertisementApp.Business.Services;
using AHY.AdvertisementApp.DataAccess.UnitOfWork;
using AHY.AdvertisementApp.Dtos;
using AHY.AdvertisementApp.Entities;
using AutoMapper;
using FluentValidation;


namespace AHY.AdvertisementApp.Business.Concrete
{
    public class GenderManager : GenericManager<GenderCreateDto, GenderUpdateDto, GenderListDto, Gender>, IGenderService
    {
        public GenderManager(IMapper mapper, IValidator<GenderCreateDto> createDtoValidator, IValidator<GenderUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
        }
    }
}

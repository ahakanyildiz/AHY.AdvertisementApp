using AHY.AdvertisementApp.Dtos;
using AHY.AdvertisementApp.Entities;
using AutoMapper;

namespace AHY.AdvertisementApp.Business.Mappings.AutoMapper
{
    public class AdvertisementAppUserProfile : Profile
    {
        public AdvertisementAppUserProfile()
        {
            CreateMap<AdvertisementAppUserCreateDto, AdvertisementAppUser>().ReverseMap();
            CreateMap<AdvertisementAppUserListDto, AdvertisementAppUser>().ReverseMap();

        }
    }
}

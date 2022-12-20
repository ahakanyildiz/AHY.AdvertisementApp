using AHY.AdvertisementApp.Dtos;
using AutoMapper;

namespace AHY.AdvertisementApp.Business.Mappings.AutoMapper
{
    public class AdvertisementAppUser : Profile
    {
        public AdvertisementAppUser()
        {
            CreateMap<AdvertisementAppUserCreateDto, AdvertisementAppUser>().ReverseMap();
        }
    }
}

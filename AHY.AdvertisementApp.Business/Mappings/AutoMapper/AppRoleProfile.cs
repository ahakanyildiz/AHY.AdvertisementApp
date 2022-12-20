using AHY.AdvertisementApp.Dtos;
using AHY.AdvertisementApp.Entities;
using AutoMapper;

namespace AHY.AdvertisementApp.Business.Mappings.AutoMapper
{
    public class AppRoleProfile : Profile
    {
        public AppRoleProfile()
        {
            CreateMap<AppRole, AppRoleListDto>().ReverseMap();
        }
    }
}

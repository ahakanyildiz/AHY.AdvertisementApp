using AHY.AdvertisementApp.Dtos;
using AHY.AdvertisementApp.UI.Models;
using AutoMapper;

namespace AHY.AdvertisementApp.UI.Mappings.AutoMapper
{
    public class UserCreateModelProfile : Profile
    {
        public UserCreateModelProfile()
        {
            CreateMap<UserCreateModel, AppUserCreateDto>();
        }
    }
}

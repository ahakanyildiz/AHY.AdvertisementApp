using AHY.AdvertisementApp.Dtos;
using AHY.AdvertisementApp.Entities;
using AutoMapper;

namespace AHY.AdvertisementApp.Business.Mappings.AutoMapper
{
    public class GenderProfile : Profile
    {
        public GenderProfile()
        {
            CreateMap<Gender, GenderUpdateDto>().ReverseMap();
            CreateMap<Gender,GenderCreateDto>().ReverseMap();
            CreateMap<Gender,GenderListDto>().ReverseMap();
        }
    }
}

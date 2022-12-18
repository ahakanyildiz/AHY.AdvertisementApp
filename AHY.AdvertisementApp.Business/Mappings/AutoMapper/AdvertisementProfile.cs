using AHY.AdvertisementApp.Dtos;
using AHY.AdvertisementApp.Entities;
using AutoMapper;

namespace AHY.AdvertisementApp.Business.Mappings.AutoMapper
{
    public class AdvertisementProfile :Profile
    {
        public AdvertisementProfile()
        {
            CreateMap<Advertisement, AdvertisementListDto>().ReverseMap();
            CreateMap<Advertisement,AdvertisementCreateDto>().ReverseMap();
            CreateMap<Advertisement,AdvertisementUpdateDto>().ReverseMap();
        }
    }
}

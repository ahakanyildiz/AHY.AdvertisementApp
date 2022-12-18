using AHY.AdvertisementApp.Dtos;
using AHY.AdvertisementApp.Entities;

namespace AHY.AdvertisementApp.Business.Abstract
{
    public interface IGenderService : IGenericService<GenderCreateDto,GenderUpdateDto,GenderListDto,Gender>
    {
    }
}

using AHY.AdvertisementApp.Dtos;
using AHY.AdvertisementApp.Entities;

namespace AHY.AdvertisementApp.Business.Abstract
{
    public interface IAppUserService : IGenericService<AppUserCreateDto,AppUserUpdateDto,AppUserListDto,AppUser>
    {
    }
}

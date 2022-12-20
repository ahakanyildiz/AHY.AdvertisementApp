using AHY.AdvertisementApp.Dtos;
using AHY.AdvertisementApp.Dtos.Concrete.AppRoleDtos;
using AHY.AdvertisementApp.Entities;

namespace AHY.AdvertisementApp.Business.Abstract
{
    public interface IAppRoleService : IGenericService<AppRoleCreateDto,AppRoleUpdateDto,AppRoleListDto,AppRole>
    {
    }
}

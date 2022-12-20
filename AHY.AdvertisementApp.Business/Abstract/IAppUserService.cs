using AHY.AdvertisementApp.Common.Result.Abstract;
using AHY.AdvertisementApp.Dtos;
using AHY.AdvertisementApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AHY.AdvertisementApp.Business.Abstract
{
    public interface IAppUserService : IGenericService<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>
    {
        Task<IResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto appUserCreateDto, int roleId);
        Task<IResponse<AppUserListDto>> CheckUser(AppUserLoginDto appUserLoginDto);
        Task<IResponse<List<AppRoleListDto>>> GetRolesByUserIdAsync(int userId);
    }
}

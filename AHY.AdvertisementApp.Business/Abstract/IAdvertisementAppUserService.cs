using AHY.AdvertisementApp.Common.Result.Abstract;
using AHY.AdvertisementApp.Dtos;
using System.Threading.Tasks;

namespace AHY.AdvertisementApp.Business.Abstract
{
    public interface IAdvertisementAppUserService
    {
        Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto);
    }
}

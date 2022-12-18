using AHY.AdvertisementApp.Common.Result.Abstract;
using AHY.AdvertisementApp.Dtos;
using AHY.AdvertisementApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AHY.AdvertisementApp.Business.Abstract
{
    public interface IAdvertisementService : IGenericService<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, Advertisement>
    {
        Task<IResponse<List<AdvertisementListDto>>> GetActivesAsync();
    }
}

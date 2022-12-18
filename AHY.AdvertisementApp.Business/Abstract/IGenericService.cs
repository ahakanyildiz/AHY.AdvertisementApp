using AHY.AdvertisementApp.Common.Result.Abstract;
using AHY.AdvertisementApp.Dtos.Abstract;
using AHY.AdvertisementApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AHY.AdvertisementApp.Business.Abstract
{
    public interface IGenericService<CreateDto,UpdateDto,ListDto,T> 
        where CreateDto : class,IDto,new()
        where UpdateDto : class, IUpdateDto, new()
        where ListDto : class, IDto, new()
        where T : BaseEntity
    {
        Task<IResponse<CreateDto>> CreateAsync(CreateDto dto);
        Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto);
        Task<IResponse<IDto>> GetByIdAsync<IDto>(int id);
        Task<IResponse> RemoveAsync(int id);
        Task<IResponse<List<ListDto>>> GetAllAsync();
    }
}

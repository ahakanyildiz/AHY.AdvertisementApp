using AHY.AdvertisementApp.Business.Abstract;
using AHY.AdvertisementApp.Business.Extensions;
using AHY.AdvertisementApp.Common.Enums;
using AHY.AdvertisementApp.Common.Result.Abstract;
using AHY.AdvertisementApp.Common.Result.Concrete;
using AHY.AdvertisementApp.DataAccess.UnitOfWork;
using AHY.AdvertisementApp.Dtos;
using AHY.AdvertisementApp.Entities;
using AutoMapper;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AHY.AdvertisementApp.Business.Concrete
{
    public class AdvertisementAppUserManager : IAdvertisementAppUserService
    {
        private readonly IUow _uow;
        private readonly IValidator<AdvertisementAppUserCreateDto> _createDtoValidator;
        private readonly IMapper _mapper;

        public AdvertisementAppUserManager(IUow uow, IValidator<AdvertisementAppUserCreateDto> createDtoValidator, IMapper mapper)
        {
            _uow = uow;
            _createDtoValidator = createDtoValidator;
            _mapper = mapper;
        }

        public async Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto)
        {
            var result = _createDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var control = await _uow.GetRepository<AdvertisementAppUser>().GetByFilterAsync(x => x.AppUserId == dto.AppUserId && x.AdvertisementId == dto.AdvertisementId);
                if (control == null)
                {
                    var createdAdvertisementAppUser = _mapper.Map<AdvertisementAppUser>(dto);
                    await _uow.GetRepository<AdvertisementAppUser>().CreateAsync(createdAdvertisementAppUser);
                    await _uow.SaveChangesAsync();
                    return new Response<AdvertisementAppUserCreateDto>(ResponseType.Success, dto);
                }

                var errors = new List<CustomValidationError> { new()
                {
                    PropertyName="",
                    ErrorMessage="Bu ilana daha önce başvurdunuz"
                } };

                return new Response<AdvertisementAppUserCreateDto>(dto, errors);

            }
            return new Response<AdvertisementAppUserCreateDto>(dto, result.ConvertToCustomValidationError());
        }

        public async Task<List<AdvertisementAppUserListDto>> GetList(AdvertisementAppUserStatusType type)
        {
            var query = _uow.GetRepository<AdvertisementAppUser>().GetQuery();
            var list = await query.Include(x => x.Advertisement).Include(x => x.AdvertisementAppUserStatus).Include(x => x.MilitaryStatus).Include(x => x.AppUser).ThenInclude(x => x.Gender).Where(x => x.AdvertisementAppUserStatusId == (int)type).ToListAsync();

            return _mapper.Map<List<AdvertisementAppUserListDto>>(list);
        }

        public async Task SetStatusAsync(int advertisementAppUserId, AdvertisementAppUserStatusType type)
        {
            var unChanged = await _uow.GetRepository<AdvertisementAppUser>().FindAsync(advertisementAppUserId);
            var changed = await _uow.GetRepository<AdvertisementAppUser>().GetByFilterAsync(x => x.Id == advertisementAppUserId);
            changed.AdvertisementAppUserStatusId = (int)type;
            _uow.GetRepository<AdvertisementAppUser>().Update(changed, unChanged);
            await _uow.SaveChangesAsync();
        }
    }
}

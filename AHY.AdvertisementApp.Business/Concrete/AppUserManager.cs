using AHY.AdvertisementApp.Business.Abstract;
using AHY.AdvertisementApp.Business.Extensions;
using AHY.AdvertisementApp.Business.Services;
using AHY.AdvertisementApp.Common.Result.Abstract;
using AHY.AdvertisementApp.Common.Result.Concrete;
using AHY.AdvertisementApp.DataAccess.UnitOfWork;
using AHY.AdvertisementApp.Dtos;
using AHY.AdvertisementApp.Entities;
using AutoMapper;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AHY.AdvertisementApp.Business.Concrete
{
    public class AppUserManager : GenericManager<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>, IAppUserService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<AppUserCreateDto> _createDtoValidator;
        private readonly IValidator<AppUserLoginDto> _loginDtoValidator;
        public AppUserManager(IMapper mapper, IValidator<AppUserCreateDto> createDtoValidator, IValidator<AppUserUpdateDto> updateDtoValidator, IUow uow, IValidator<AppUserLoginDto> loginDtoValidator) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _mapper = mapper;
            _uow = uow;
            _createDtoValidator = createDtoValidator;
            _loginDtoValidator = loginDtoValidator;
        }

        public async Task<IResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto appUserCreateDto, int roleId)
        {
            var validationResult = _createDtoValidator.Validate(appUserCreateDto);
            if (validationResult.IsValid)
            {
                #region 1.Yol
                //1. yol
                //user.AppUserRoles = new List<AppUserRole>() { new AppUserRole
                //{
                //    AppUser=user,
                //    AppRoleId=roleId
                //} }; 
                #endregion

                //2. yol
                var user = _mapper.Map<AppUser>(appUserCreateDto);
                await _uow.GetRepository<AppUser>().CreateAsync(user);
                await _uow.GetRepository<AppUserRole>().CreateAsync(new AppUserRole
                {
                    AppUser = user,
                    AppRoleId = roleId
                });
                await _uow.SaveChangesAsync();
                return new Response<AppUserCreateDto>(ResponseType.Success, appUserCreateDto);
            }

            return new Response<AppUserCreateDto>(appUserCreateDto, validationResult.ConvertToCustomValidationError());
        }

        public async Task<IResponse<AppUserListDto>> CheckUser(AppUserLoginDto appUserLoginDto)
        {
            var validationResult = _loginDtoValidator.Validate(appUserLoginDto);
            if (validationResult.IsValid)
            {
                var user = await _uow.GetRepository<AppUser>().GetByFilterAsync(x => x.Username == appUserLoginDto.Username && x.Password == appUserLoginDto.Password);
                if (user != null)
                {
                    var appUserDto= _mapper.Map<AppUserListDto>(user);
                    return new Response<AppUserListDto>(ResponseType.Success, appUserDto);
                }
                else
                {
                    return new Response<AppUserListDto>(ResponseType.NotFound, "Kullanıcı adı ve ya şifre hatalı.");
                }
            }
            return new Response<AppUserListDto>(ResponseType.ValidationError, "Kullanıcı adı veya şifre boş olamaz");
        }

        public async Task<IResponse<List<AppRoleListDto>>> GetRolesByUserIdAsync(int userId)
        {
           var roles = await _uow.GetRepository<AppRole>().GetAllAsync(x => x.AppUserRoles.Any(x => x.AppUserId == userId));
            if (roles == null)
            {
                return new Response<List<AppRoleListDto>>(ResponseType.NotFound, "İlgili rol bulunamadı");
            }
            var dto = _mapper.Map<List<AppRoleListDto>>(roles);

            return new Response<List<AppRoleListDto>>(ResponseType.Success, dto);

        }
    }
}

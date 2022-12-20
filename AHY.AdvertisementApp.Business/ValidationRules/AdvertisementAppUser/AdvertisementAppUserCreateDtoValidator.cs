using AHY.AdvertisementApp.Common.Enums;
using AHY.AdvertisementApp.Dtos;
using FluentValidation;

namespace AHY.AdvertisementApp.Business.ValidationRules.AdvertisementAppUser
{
    public class AdvertisementAppUserCreateDtoValidator : AbstractValidator<AdvertisementAppUserCreateDto>
    {
        public AdvertisementAppUserCreateDtoValidator()
        {
            RuleFor(x => x.AdvertisementAppUserStatusId).NotEmpty();
            RuleFor(x => x.AdvertisementId).NotEmpty();
            RuleFor(x => x.AppUserId).NotEmpty();
            RuleFor(x => x.CvPath).NotEmpty().WithMessage("Bir cv dosyası seçiniz.");
            RuleFor(x => x.EndDate).NotEmpty().When(x => x.MilitaryStatusId == (int)MilitaryStatusType.Tecilli).WithMessage("Tecil tarihi boş bırakılamaz.");
        }
    }
}

using AHY.AdvertisementApp.Dtos;
using FluentValidation;

namespace AHY.AdvertisementApp.Business.ValidationRules.Advertisement
{
    public class AdvertisementCreateDtoValidator : AbstractValidator<AdvertisementCreateDto>
    {
        public AdvertisementCreateDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}

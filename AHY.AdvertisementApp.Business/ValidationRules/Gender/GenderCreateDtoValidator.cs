using AHY.AdvertisementApp.Dtos;
using FluentValidation;

namespace AHY.AdvertisementApp.Business.ValidationRules.Gender
{
    public class GenderCreateDtoValidator :AbstractValidator<GenderCreateDto>
    {
        public GenderCreateDtoValidator()
        {
            RuleFor(x => x.Definition).NotEmpty();
        }
    }
}

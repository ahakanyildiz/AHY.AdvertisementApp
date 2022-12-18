using AHY.AdvertisementApp.Dtos;
using FluentValidation;

namespace AHY.AdvertisementApp.Business.ValidationRules.ProvidedService
{
    public class ProvidedServiceUpdateDtoValidator :AbstractValidator<ProvidedServiceUpdateDto>
    {
        public ProvidedServiceUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Description).NotEmpty ();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.ImagePath).NotEmpty();
        }
    }
}

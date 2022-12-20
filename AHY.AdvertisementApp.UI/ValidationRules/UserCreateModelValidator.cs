using AHY.AdvertisementApp.UI.Models;
using FluentValidation;
using System;

namespace AHY.AdvertisementApp.UI.ValidationRules
{
    public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
    {
        public UserCreateModelValidator()
        {
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).MinimumLength(3);
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Password not match");
            RuleFor(x => x.Username).MinimumLength(3);
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Firstname).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => new
            {
                x.Username,
                x.Firstname
            }).Must(x => CanNotFirstName(x.Username, x.Firstname)).WithMessage("Username can not contains firstname").When(x=>x.Firstname!=null && x.Username!=null);
            RuleFor(x => x.GenderId).NotEmpty();

        }

        private bool CanNotFirstName(string userName,string firstName)
        {
            return !userName.Contains(firstName);
        }
    }
}

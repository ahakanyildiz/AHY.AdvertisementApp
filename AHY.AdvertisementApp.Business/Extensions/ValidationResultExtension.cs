
using AHY.AdvertisementApp.Common.Result.Concrete;
using FluentValidation.Results;
using System.Collections.Generic;

namespace AHY.AdvertisementApp.Business.Extensions
{
    public static class ValidationResultExtension
    {
        public static List<CustomValidationError> ConvertToCustomValidationError(this ValidationResult validationResult)
        {
            var errorList = new List<CustomValidationError>();
            foreach (var item in validationResult.Errors)
            {
                errorList.Add(new()
                {
                    ErrorMessage = item.ErrorMessage,
                    PropertyName = item.PropertyName,
                });
            }
            return errorList;
        }
    }
}

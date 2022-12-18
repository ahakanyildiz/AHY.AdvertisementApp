using System.Collections.Generic;
using AHY.AdvertisementApp.Common.Result.Concrete;

namespace AHY.AdvertisementApp.Common.Result.Abstract
{
    public interface IResponse<T> : IResponse
    {
        T Data { get; set; }
        List<CustomValidationError> ValidationErrors { get; set; }
    }
}

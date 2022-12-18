using AHY.AdvertisementApp.Common.Result.Concrete;

namespace AHY.AdvertisementApp.Common.Result.Abstract
{
    public interface IResponse
    {
        string Message { get; set; }
        ResponseType ResponseType { get; set; }
    }
}

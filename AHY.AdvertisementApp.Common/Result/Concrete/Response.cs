using AHY.AdvertisementApp.Common.Result.Abstract;

namespace AHY.AdvertisementApp.Common.Result.Concrete
{
    public class Response : IResponse // Data taşımayan response yapısı.(Delete,Update,Add)
    {
        public Response(ResponseType responseType)
        {
            ResponseType = responseType;
        }

        public Response(ResponseType responseType, string message)
        {
            Message = message;
            ResponseType = responseType;
        }

        public string Message { get; set; }
        public ResponseType ResponseType { get; set; }
    }

    public enum ResponseType
    {
        Success,
        ValidationError,
        NotFound,
    }
}

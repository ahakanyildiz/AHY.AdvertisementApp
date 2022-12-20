using AHY.AdvertisementApp.Dtos.Abstract;

namespace AHY.AdvertisementApp.Dtos
{
    public class AppUserLoginDto : IDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}

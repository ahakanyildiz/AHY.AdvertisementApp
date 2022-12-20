using AHY.AdvertisementApp.Dtos.Abstract;

namespace AHY.AdvertisementApp.Dtos
{
    public class AppRoleListDto : IDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}

using AHY.AdvertisementApp.Dtos.Abstract;

namespace AHY.AdvertisementApp.Dtos.Concrete.AppRoleDtos
{
    public class AppRoleUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}

using AHY.AdvertisementApp.Common.Result;

namespace AHY.AdvertisementApp.Entities
{
    public class AppUserRole : BaseEntity
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int AppRoleId { get; set; }
        public AppRole AppRole { get; set; }
    }
}

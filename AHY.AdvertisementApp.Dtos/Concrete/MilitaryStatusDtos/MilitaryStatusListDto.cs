using AHY.AdvertisementApp.Dtos.Abstract;

namespace AHY.AdvertisementApp.Dtos.Concrete.MilitaryStatusDtos
{
    public class MilitaryStatusListDto : IDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}

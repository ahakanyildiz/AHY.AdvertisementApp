using AHY.AdvertisementApp.Dtos.Abstract;

namespace AHY.AdvertisementApp.Dtos 
{
    public class AdvertisementCreateDto : IDto
    {
        public string Title { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
    }
}

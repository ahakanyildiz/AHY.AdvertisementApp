using AHY.AdvertisementApp.Dtos.Abstract;
using System;


namespace AHY.AdvertisementApp.Dtos
{
    public class ProvidedServiceUpdateDto :IUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

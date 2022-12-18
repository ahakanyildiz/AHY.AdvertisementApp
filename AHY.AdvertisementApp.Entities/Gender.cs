using AHY.AdvertisementApp.Common.Result;
using System.Collections.Generic;

namespace AHY.AdvertisementApp.Entities
{
    public class Gender :BaseEntity
    {
        public string Definition { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}

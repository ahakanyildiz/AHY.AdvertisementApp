using AHY.AdvertisementApp.Common.Result;
using System.Collections.Generic;

namespace AHY.AdvertisementApp.Entities
{
    public class MilitaryStatus : BaseEntity
    {
        public string Definition { get; set; }
        public List<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}

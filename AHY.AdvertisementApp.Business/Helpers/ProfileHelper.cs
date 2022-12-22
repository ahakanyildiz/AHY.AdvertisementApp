using AHY.AdvertisementApp.Business.Mappings.AutoMapper;
using AutoMapper;
using System.Collections.Generic;

namespace AHY.AdvertisementApp.Business.Helpers
{
    public static class ProfileHelper
    {
       public static List<Profile> GetProfileList()
        {
            return new List<Profile>()
            {
                new ProvidedServiceProfile(),
                new AdvertisementProfile(),
                new AppUserProfile(),
                new GenderProfile(),
                new AppRoleProfile(),
                new AdvertisementAppUserProfile(),
                new AdvertisementAppUserStatusProfile(),
                new MilitaryStatusProfile()
             };
        }
    }
}

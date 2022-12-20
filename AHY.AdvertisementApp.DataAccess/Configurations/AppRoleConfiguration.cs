using AHY.AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace AHY.AdvertisementApp.DataAccess.Configurations
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.Property(x => x.Definition).HasMaxLength(300).IsRequired();
            builder.HasData(new List<AppRole>(){ new AppRole()
            {
                Id = 1,
                Definition = "Member"
            },
            new AppRole()
            {
                Id=2,
                Definition="Admin"
            }
            });
        }
    }
}

using AHY.AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AHY.AdvertisementApp.DataAccess.Configurations
{
    public class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasIndex(x => new
            {
                x.AppRoleId,
                x.AppUserId
            });

            builder.HasOne(x=>x.AppRole).WithMany(x=>x.AppUserRoles).HasForeignKey(x=>x.AppRoleId);
            builder.HasOne(x => x.AppUser).WithMany(x => x.AppUserRoles).HasForeignKey(x => x.AppUserId);
        }
    }
}

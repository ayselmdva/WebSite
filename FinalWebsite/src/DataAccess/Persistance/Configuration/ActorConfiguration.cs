using FinalWebsite.DataAccess.Persistance.Configuration.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalWebsite.DataAccess.Persistance.Configuration
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.BaseEntityConfigure();
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.About);
            builder.HasMany(x => x.Movies).WithMany(x => x.Actors);
        }

    }
}

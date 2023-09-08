using FinalWebsite.DataAccess.Persistance.Configuration.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalWebsite.DataAccess.Persistance.Configuration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.BaseEntityConfigure();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description);
            builder.HasOne(x => x.Genre).WithMany(x => x.Movies).HasForeignKey(x => x.GenreId);
            builder.HasOne(x => x.Director).WithMany(x => x.Movies).HasForeignKey(x => x.DirectorId);
            builder.HasMany(x => x.Actors).WithMany(x => x.Movies);
            builder.Property(x => x.DirectorId).IsRequired();
            builder.Property(x => x.GenreId).IsRequired();
            builder.Property(x => x.Rate).HasDefaultValue(0).HasColumnType("decimal(18,1)");
            builder.Property(x => x.RunTime).HasDefaultValue(0);


        }
    }
}

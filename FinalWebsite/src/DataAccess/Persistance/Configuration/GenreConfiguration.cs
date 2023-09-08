using FinalWebsite.DataAccess.Persistance.Configuration.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalWebsite.DataAccess.Persistance.Configuration
{
    public class GenreConfiguration: IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.BaseEntityConfigure();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
        }
    }
}

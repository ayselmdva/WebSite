using FinalWebsite.DataAccess.Persistance.Configuration.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalWebsite.DataAccess.Persistance.Configuration
{
    public class DirectorConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.BaseEntityConfigure();
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.About);


            
        }
    }
}

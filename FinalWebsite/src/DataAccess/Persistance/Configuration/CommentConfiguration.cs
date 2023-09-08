/*using FinalWebsite.DataAccess.Persistance.Configuration.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalWebsite.DataAccess.Persistance.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.BaseEntityConfigure();
            builder.Property(x => x.Description);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.Date);
            builder.HasOne(x => x.Movie).WithMany(x => x.Comments).HasForeignKey(x => x.MovieId);
            builder.HasOne(x => x.AppUser).WithMany(x => x.Comments).HasForeignKey(x => x.AppUserId);
        }

    }
}*/
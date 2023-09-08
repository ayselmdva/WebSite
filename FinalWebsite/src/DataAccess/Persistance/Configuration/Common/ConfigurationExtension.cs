using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalWebsite.DataAccess.Persistance.Configuration.Common
{
    public static class ConfigurationExtension
    {
        public static EntityTypeBuilder<TEntity> BaseEntityConfigure<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : BaseEntity
        {
            builder.HasKey(x => x.Id);
            return builder;
        }
    }
}

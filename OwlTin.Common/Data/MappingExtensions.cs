
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwlTin.Common.Entities;

namespace OwlTin.Common.Data
{
    public static class MappingExtensions
    {
        public static void AddTrackedEntityProperties<T>(this EntityTypeBuilder<T> builder, bool lowerCase = false) where T : class, ITrackedEntity
        {
            builder.Property(e => e.CreateDate)
                .HasColumnName(lowerCase ? "create_date" : "CREATE_DATE")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(e => e.ModifiedDate)
                .HasColumnName(lowerCase ? "modified_date" : "MODIFIED_DATE")
                .IsRequired()
                .ValueGeneratedOnAddOrUpdate();
        }

        public static void AddActiveEntityProperties<T>(this EntityTypeBuilder<T> builder, bool lowerCase = false) where T : class, IActiveEntity
        {
            builder.Property(e => e.Active)
                .HasColumnName(lowerCase ? "active" : "ACTIVE")
                .IsRequired();
        }

    }
}

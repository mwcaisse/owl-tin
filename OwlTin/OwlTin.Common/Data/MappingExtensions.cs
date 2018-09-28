using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwlTin.Common.Entities;

namespace OwlTin.Common.Data
{
    public static class MappingExtensions
    {

        public static void AddTrackedEntityProperties<T>(this EntityTypeBuilder<T> builder) where T : class, ITrackedEntity
        {
            builder.Property(e => e.CreateDate)
                .HasColumnName("CREATE_DATE")
                .IsRequired()
                .ValueGeneratedOnAddOrUpdate();

            builder.Property(e => e.ModifiedDate)
                .HasColumnName("MODIFIED_DATE")
                .IsRequired()
                .ValueGeneratedOnAddOrUpdate();
        }

        public static void AddActiveEntityProperties<T>(this EntityTypeBuilder<T> builder) where T : class, IActiveEntity
        {
            builder.Property(e => e.Active)
                .HasColumnName("ACTIVE")
                .IsRequired();
        }

    }
}

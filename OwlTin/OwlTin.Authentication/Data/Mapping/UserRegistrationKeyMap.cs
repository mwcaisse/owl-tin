using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mitchell.Authentication.Entities;
using Mitchell.Common.Data;

namespace Mitchell.Authentication.Data.Mapping
{
    public class UserRegistrationKeyMap : IEntityTypeConfiguration<UserRegistrationKey>
    {
        public void Configure(EntityTypeBuilder<UserRegistrationKey> builder)
        {
            builder.ToTable("USER_REGISTRATION_KEY")
                .HasKey(k => k.UserRegistrationKeyId);

            builder.Property(k => k.UserRegistrationKeyId)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(k => k.Key)
                .HasColumnName("KEY_VAL")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(k => k.UsesRemaining)
                .HasColumnName("USES_REMAINING")
                .IsRequired();

            builder.Property(k => k.Active)
                .HasColumnName("ACTIVE")
                .IsRequired();

            builder.AddTrackedEntityProperties();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwlTin.Authentication.Entities;
using OwlTin.Common.Data;

namespace OwlTin.Authentication.Data.Mapping
{
    public class UserRegistrationKeyUseMap : IEntityTypeConfiguration<UserRegistrationKeyUse>
    {
        public void Configure(EntityTypeBuilder<UserRegistrationKeyUse> builder)
        {
            builder.ToTable("USER_REGISTRATION_KEY_USE")
                .HasKey(u => u.UserRegistrationKeyUseId);

            builder.Property(u => u.UserRegistrationKeyUseId)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(u => u.UserRegistrationKeyId)
                .HasColumnName("KEY_ID")
                .IsRequired();

            builder.Property(u => u.UserId)
                .HasColumnName("USER_ID");

            builder.HasOne(u => u.UserRegistrationKey)
                .WithMany(k => k.UserRegistrationKeyUses)
                .HasForeignKey(u => u.UserRegistrationKeyId);

            builder.HasOne(ur => ur.User)
                .WithMany(u => u.UserRegistrationKeyUses)
                .HasForeignKey(ur => ur.UserId);

            builder.AddTrackedEntityProperties();
        }
    }
}

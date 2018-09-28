using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mitchell.Authentication.Entities;
using Mitchell.Common.Data;

namespace Mitchell.Authentication.Data.Mapping
{
    public class UserAuthenticationTokenMap : IEntityTypeConfiguration<UserAuthenticationToken>
    {
        public void Configure(EntityTypeBuilder<UserAuthenticationToken> builder)
        {

            builder.ToTable("USER_AUTHENTICATION_TOKEN")
                .HasKey(u => u.UserAuthenticationTokenId);

            builder.Property(u => u.UserAuthenticationTokenId)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(u => u.UserId)
                .HasColumnName("USER_ID")
                .IsRequired();

            builder.Property(u => u.Token)
                .HasColumnName("TOKEN")
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(u => u.Description)
                .HasColumnName("DESCRIPTION")
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(u => u.LastLogin)
                .HasColumnName("LAST_LOGIN");

            builder.Property(u => u.LastLoginAddress)
                .HasColumnName("LAST_LOGIN_ADDRESS")
                .HasMaxLength(250);

            builder.Property(u => u.ExpirationDate)
                .HasColumnName("EXPIRATION_DATE");

            builder.HasOne(t => t.User)
                .WithMany(u => u.UserAuthenticationTokens)
                .HasForeignKey(t => t.UserId);

            builder.AddTrackedEntityProperties();
            builder.AddActiveEntityProperties();
        }
    }
}

﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.DbRepository.Domain.Models;

namespace Sample.DbRepository.Infrastructure.Contexts.Configurations
{
    internal sealed class ArtistConfig : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Artists");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("ArtistId")
                   .HasColumnType("INTEGER")
                   .IsRequired(true)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                   .HasColumnName("Title")
                   .HasColumnType("NVARCHAR(120)")
                   .HasMaxLength(120)
                   .IsRequired(false)
                   .IsUnicode(true);
        }
    }
}

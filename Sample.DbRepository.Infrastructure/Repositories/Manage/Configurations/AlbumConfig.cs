﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.DbRepository.Domain.Manage.Models;

namespace Sample.DbRepository.Infrastructure.Repositories.Manage.Configurations
{
    internal sealed class AlbumConfig : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Albums");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("AlbumId")
                   .HasColumnType("INTEGER")
                   .IsRequired(true)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Title)
                   .HasColumnName("Title")
                   .HasColumnType("NVARCHAR(160)")
                   .HasMaxLength(160)
                   .IsRequired(true)
                   .IsUnicode(true);

            builder.Property(x => x.ArtistId)
                   .HasColumnName("ArtistId")
                   .HasColumnType("INTEGER")
                   .IsRequired(true)
                   .ValueGeneratedNever();
        }
    }
}

﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.DbRepository.Domain.Manage.Models;

namespace Sample.DbRepository.Infrastructure.Repositories.Manage.Configurations
{
    internal sealed class TrackConfig : IEntityTypeConfiguration<Track>
    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {
            builder.ToTable("Tracks");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("TrackId")
                   .HasColumnType("INTEGER")
                   .IsRequired(true)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                   .HasColumnName("Name")
                   .HasColumnType("NVARCHAR(200)")
                   .HasMaxLength(200)
                   .IsRequired(true)
                   .IsUnicode(true);

            builder.Property(x => x.AlbumId)
                   .HasColumnName("AlbumId")
                   .HasColumnType("INTEGER")
                   .IsRequired(false)
                   .ValueGeneratedNever();

            builder.Property(x => x.GenreId)
                   .HasColumnName("GenreId")
                   .HasColumnType("INTEGER")
                   .IsRequired(false)
                   .ValueGeneratedNever();

            builder.Property(x => x.Composer)
                   .HasColumnName("Composer")
                   .HasColumnType("NVARCHAR(220)")
                   .HasMaxLength(220)
                   .IsRequired(false)
                   .IsUnicode(true);

            builder.Property(x => x.PlayTimeInMilliseconds)
                   .HasColumnName("Milliseconds")
                   .HasColumnType("INTEGER")
                   .IsRequired(true)
                   .ValueGeneratedNever();

            builder.Property(x => x.SizeInBytes)
                   .HasColumnName("Bytes")
                   .HasColumnType("INTEGER")
                   .IsRequired(false)
                   .ValueGeneratedNever();
        }
    }
}

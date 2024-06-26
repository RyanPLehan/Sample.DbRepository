﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.DbRepository.Domain.Aggregation.Models;

namespace Sample.DbRepository.Infrastructure.Contexts.Aggregation.Configurations
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

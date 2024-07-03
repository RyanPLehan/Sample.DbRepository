using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Infrastructure.Repositories.Search.Configurations
{
    internal sealed class AlbumTrackConfig : IEntityTypeConfiguration<AlbumTrack>
    {
        public void Configure(EntityTypeBuilder<AlbumTrack> builder)
        {
            builder.ToView("vw_AlbumTracks");
            builder.HasKey(x => new {x.AlbumId, x.TrackId});

            // Album
            builder.Property(x => x.AlbumId)
                   .HasColumnName("AlbumId")
                   .HasColumnType("INTEGER")
                   .IsRequired(true)
                   .ValueGeneratedNever();

            builder.Property(x => x.AlbumTitle)
                   .HasColumnName("AlbumTitle")
                   .HasColumnType("NVARCHAR(160)")
                   .HasMaxLength(160)
                   .IsRequired(true)
                   .IsUnicode(true);

            builder.Property(x => x.ArtistId)
                   .HasColumnName("ArtistId")
                   .HasColumnType("INTEGER")
                   .IsRequired(true)
                   .ValueGeneratedNever();


            // Tracks
            builder.Property(x => x.TrackId)
                   .HasColumnName("TrackId")
                   .HasColumnType("INTEGER")
                   .IsRequired(true)
                   .ValueGeneratedNever();

            builder.Property(x => x.TrackName)
                   .HasColumnName("TrackName")
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

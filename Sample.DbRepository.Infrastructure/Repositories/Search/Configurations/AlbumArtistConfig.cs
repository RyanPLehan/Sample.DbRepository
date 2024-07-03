using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Infrastructure.Repositories.Search.Configurations
{
    internal sealed class AlbumArtistConfig : IEntityTypeConfiguration<AlbumArtist>
    {
        public void Configure(EntityTypeBuilder<AlbumArtist> builder)
        {
            builder.ToView("vw_AlbumArtist");
            builder.HasKey(x => x.AlbumId);

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

            builder.Property(x => x.ArtistName)
                   .HasColumnName("ArtistName")
                   .HasColumnType("NVARCHAR(120)")
                   .HasMaxLength(120)
                   .IsRequired(false)
                   .IsUnicode(true);
        }
    }
}

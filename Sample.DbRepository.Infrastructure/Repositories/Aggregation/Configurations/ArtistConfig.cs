using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.DbRepository.Domain.Aggregation.Models;

namespace Sample.DbRepository.Infrastructure.Repositories.Aggregation.Configurations
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
        }
    }
}

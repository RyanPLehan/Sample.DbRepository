﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.DbRepository.Domain.Manage.Models;

namespace Sample.DbRepository.Infrastructure.Repositories.Manage.Configurations
{
    internal sealed class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genres");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("GenreId")
                   .HasColumnType("INTEGER")
                   .IsRequired(true)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                   .HasColumnName("Name")
                   .HasColumnType("NVARCHAR(120)")
                   .HasMaxLength(120)
                   .IsRequired(false)
                   .IsUnicode(true);
        }
    }
}

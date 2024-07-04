using System;
using Microsoft.EntityFrameworkCore;
using Sample.DbRepository.Domain.Manage.Models;
using Sample.DbRepository.Infrastructure.Repositories.Manage.Configurations;

namespace Sample.DbRepository.Infrastructure.Repositories.Manage
{
    public sealed class ManageContext : DbContext
    {

        public ManageContext(DbContextOptions<ManageContext> options)
                : base(options)
        {
        }

        internal DbSet<Album> Albums { get; set; }
        internal DbSet<Artist> Artists { get; set; }
        internal DbSet<Genre> Genres { get; set; }
        internal DbSet<Track> Tracks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlbumConfig());
            modelBuilder.ApplyConfiguration(new ArtistConfig());
            modelBuilder.ApplyConfiguration(new GenreConfig());
            modelBuilder.ApplyConfiguration(new TrackConfig());
        }
    }
}

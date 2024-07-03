using System;
using Microsoft.EntityFrameworkCore;
using Sample.DbRepository.Infrastructure.Repositories.Aggregation.Configurations;
using Sample.DbRepository.Infrastructure.Repositories.Aggregation.Models;

namespace Sample.DbRepository.Infrastructure.Repositories.Aggregation
{
    /// <summary>
    /// Using a separate Aggregation Context because we may want to take advantage of the following
    /// 1.  The data maybe stored at a readonly database, most probably some type of data store, data warehouse, or data lake.
    /// 2.  The data maybe structurely differently, ie in a view or specialized Aggregation table
    /// 3.  We can use a new model/class to represent a subset of the fields of the same table.
    ///     FYI, EF has a strict 1 to 1 relationship between class and table, but it is restricted to the context.
    ///     Therefore, by defining a separate context, we can have a separate class that contains sub fields to an existing table.
    ///     Just be sure to use a separate EF configuration file
    /// </summary>
    public sealed class AggregationContext : DbContext
    {

        public AggregationContext(DbContextOptions<AggregationContext> options)
                : base(options)
        {
        }

        internal DbSet<Track> Tracks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TrackConfig());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sample.DbRepository.Domain.Helpers;
using Sample.DbRepository.Domain.Management;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Infrastructure.Repositories.Management
{
    internal sealed class ArtistRepository : IArtistRepository
    {
        private readonly IContextFactory<ManagementContext> _contextFactory;

        public ArtistRepository(IContextFactory<ManagementContext> contextFactory)
        {
            ArgumentNullException.ThrowIfNull(contextFactory, nameof(contextFactory));

            _contextFactory = contextFactory;
        }

        public async Task<Artist> Add(Artist entity)
        {
            using (var context = _contextFactory.CreateCommandContext())
            {
                context.Add(entity);
                await context.SaveChangesAsync();
            }

            return entity;
        }


        public async Task Delete(int id)
        {
            using (var context = _contextFactory.CreateCommandContext())
            {
                var entity = await context.Artists
                                          .Where(x => x.Id == id)
                                          .FirstOrDefaultAsync();

                if (entity != null)
                {
                    context.Remove(entity);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<Artist> Get(int id)
        {
            Artist? entity = null;
            using (var context = _contextFactory.CreateQueyContext())
            {
                entity = await context.Artists
                                      .Where(x => x.Id == id)
                                      .FirstOrDefaultAsync();
            }

            return entity;
        }

        public async Task<Artist> GetForUpdate(int id)
        {
            Artist? entity = null;
            using (var context = _contextFactory.CreateCommandContext())
            {
                entity = await context.Artists
                                      .Where(x => x.Id == id)
                                      .FirstOrDefaultAsync();
            }

            return entity;
        }


        public async Task<Artist> Update(Artist entity)
        {
            using (var context = _contextFactory.CreateCommandContext())
            {
                context.Update(entity);
                await context.SaveChangesAsync();
            }

            return entity;
        }
    }
}

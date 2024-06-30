using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sample.DbRepository.Domain.Helpers;
using Sample.DbRepository.Domain.Infrastructure;
using Sample.DbRepository.Domain.Management;
using Sample.DbRepository.Domain.Management.Models;
using Sample.DbRepository.Infrastructure.Contexts.Management;

namespace Sample.DbRepository.Infrastructure.Repositories.Management
{
    internal sealed class ArtistRepository : IArtistRepository
    {
        private readonly IContextFactory<ManagementContext> _contextFactory;
        private readonly IMapper _mapper;

        public ArtistRepository(IContextFactory<ManagementContext> contextFactory,
                               IMapper mapper)
        {
            ArgumentNullException.ThrowIfNull(contextFactory, nameof(contextFactory));
            ArgumentNullException.ThrowIfNull(mapper, nameof(mapper));

            _contextFactory = contextFactory;
            _mapper = mapper;
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

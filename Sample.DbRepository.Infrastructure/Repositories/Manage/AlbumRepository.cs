﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sample.DbRepository.Domain.Helpers;
using Sample.DbRepository.Domain.Manage;
using Sample.DbRepository.Domain.Manage.Models;

namespace Sample.DbRepository.Infrastructure.Repositories.Manage
{
    internal sealed class AlbumRepository : IAlbumRepository
    {
        const int MAX_BATCH_SIZE = 250;
        private readonly IContextFactory<ManageContext> _contextFactory;

        public AlbumRepository(IContextFactory<ManageContext> contextFactory)
        {
            ArgumentNullException.ThrowIfNull(contextFactory, nameof(contextFactory));

            _contextFactory = contextFactory;
        }

        public async Task<Album> Add(Album entity)
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
                var entity = await context.Albums
                                          .Where(x => x.Id == id)
                                          .FirstOrDefaultAsync();

                if (entity != null)
                {
                    context.Remove(entity);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task Delete(IEnumerable<int> ids)
        {
            var deleteSql = RepositoryService.CreateDeleteSql("Albums", "AlbumId");
            var distinctIds = ids.Distinct();

            using (var context = _contextFactory.CreateCommandContext())
            {
                // Using a batching routine to issue a Raw SQL Delete Statement
                await BatchHelper.BatchAsync<int>(MAX_BATCH_SIZE, distinctIds, async batchIds =>
                {
                    var inClause = String.Join(',', batchIds);
                    var sql = String.Format(deleteSql, inClause);
                    await context.Database.ExecuteSqlRawAsync(sql);

                });
            }
        }

        public async Task<Album> Get(int id)
        {
            Album? entity = null;
            using (var context = _contextFactory.CreateQueyContext())
            {
                entity = await context.Albums
                                      .Where(x => x.Id == id)
                                      .FirstOrDefaultAsync();
            }

            return entity;
        }

        public async Task<Album> GetForUpdate(int id)
        {
            Album? entity = null;
            using (var context = _contextFactory.CreateCommandContext())
            {
                entity = await context.Albums
                                      .Where(x => x.Id == id)
                                      .FirstOrDefaultAsync();
            }

            return entity;
        }


        public async Task<Album> Update(Album entity)
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

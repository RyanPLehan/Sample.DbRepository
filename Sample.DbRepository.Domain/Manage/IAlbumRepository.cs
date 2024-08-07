﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sample.DbRepository.Domain.Manage.Models;

namespace Sample.DbRepository.Domain.Manage
{
    public interface IAlbumRepository
    {
        Task<Album> Add(Album entity);
        Task Delete(int id);
        Task Delete(IEnumerable<int> ids);
        Task<Album> Get(int id);
        Task<Album> GetForUpdate(int id);
        Task<Album> Update(Album entity);
    }
}

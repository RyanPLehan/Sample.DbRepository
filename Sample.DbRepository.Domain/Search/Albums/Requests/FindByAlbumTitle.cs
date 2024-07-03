using System;
using System.Collections.Generic;
using MediatR;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Albums.Requests
{
    public class FindByAlbumTitle : IRequest<IEnumerable<AlbumArtist>>
    {
        public string Title { get; set; }
    }
}

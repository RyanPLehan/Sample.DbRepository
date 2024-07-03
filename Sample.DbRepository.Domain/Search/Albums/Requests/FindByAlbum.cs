using System;
using System.Collections.Generic;
using MediatR;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Albums.Requests
{
    public class FindByAlbum : IRequest<AlbumArtist>
    {
        public int AlbumId { get; set; }
    }
}

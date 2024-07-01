using System;
using System.Collections.Generic;
using MediatR;
using Sample.DbRepository.Domain.Aggregation.Models;

namespace Sample.DbRepository.Domain.Aggregation.Tracks.Requests
{
    public class GetAlbumCount : IRequest<int>
    {
        public int AlbumId { get; set; }
    }
}

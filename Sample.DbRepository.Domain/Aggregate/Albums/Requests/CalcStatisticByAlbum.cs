using System;
using System.Collections.Generic;
using MediatR;
using Sample.DbRepository.Domain.Aggregate.Models;

namespace Sample.DbRepository.Domain.Aggregate.Albums.Requests
{
    public class CalcStatisticByAlbum : IRequest<AlbumStatistic>
    {
        public int AlbumId { get; set; }
    }
}

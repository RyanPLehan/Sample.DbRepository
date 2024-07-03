using System;
using System.Collections.Generic;
using MediatR;
using Sample.DbRepository.Domain.Aggregation.Models;

namespace Sample.DbRepository.Domain.Aggregation.Albums.Requests
{
    public class CalcStatisticByAlbum : IRequest<AlbumStatistic>
    {
        public int AlbumId { get; set; }
    }
}

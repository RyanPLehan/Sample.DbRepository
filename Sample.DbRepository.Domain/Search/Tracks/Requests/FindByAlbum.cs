﻿using System;
using System.Collections.Generic;
using MediatR;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Tracks.Requests
{
    public class FindByAlbum : IRequest<IEnumerable<AlbumTrack>>
    {
        public int AlbumId { get; set; }
    }
}

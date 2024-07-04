using System;
using MediatR;
using Sample.DbRepository.Domain.Manage.Models;

namespace Sample.DbRepository.Domain.Manage.Tracks.Requests
{
    public class Add : IRequest<Track>
    {
        public string Name { get; set; }
        public int? AlbumId { get; set; }
        public int? GenreId { get; set; }
        public string Composer { get; set; }
        public int PlayLengthInMilliseconds { get; set; }
        public int SizeInBytes { get; set; }
    }
}

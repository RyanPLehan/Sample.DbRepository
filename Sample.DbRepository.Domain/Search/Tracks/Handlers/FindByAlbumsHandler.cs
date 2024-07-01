using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Search.Tracks.Requests;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Tracks.Handlers
{
    internal class FindByAlbumsHandler : IRequestHandler<FindByAlbums, IEnumerable<Track>>
    {
        private readonly ITrackRepository _repository;

        public FindByAlbumsHandler(ITrackRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<IEnumerable<Track>> Handle(FindByAlbums request, CancellationToken cancellationToken)
        {
            return await _repository.FindByAlbum(request.AlbumIds);
        }
    }
}

using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Search.Tracks.Requests;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Tracks.Handlers
{
    internal class FindByAlbumHandler : IRequestHandler<FindByAlbum, IEnumerable<AlbumTrack>>
    {
        private readonly ITrackRepository _repository;

        public FindByAlbumHandler(ITrackRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<IEnumerable<AlbumTrack>> Handle(FindByAlbum request, CancellationToken cancellationToken)
        {
            return await _repository.FindByAlbum(request.AlbumId);
        }
    }
}

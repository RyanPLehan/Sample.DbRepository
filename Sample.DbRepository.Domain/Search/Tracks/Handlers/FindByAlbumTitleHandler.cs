using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Search.Tracks.Requests;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Tracks.Handlers
{
    internal class FindByAlbumTitleHandler : IRequestHandler<FindByAlbumTitle, IEnumerable<AlbumTrack>>
    {
        private readonly ITrackRepository _repository;

        public FindByAlbumTitleHandler(ITrackRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<IEnumerable<AlbumTrack>> Handle(FindByAlbumTitle request, CancellationToken cancellationToken)
        {
            return await _repository.FindByAlbumTitle(request.Title);
        }
    }
}

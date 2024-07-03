using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Search.Tracks.Requests;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Tracks.Handlers
{
    internal class FindByGenreHandler : IRequestHandler<FindByGenre, IEnumerable<AlbumTrack>>
    {
        private readonly ITrackRepository _repository;

        public FindByGenreHandler(ITrackRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<IEnumerable<AlbumTrack>> Handle(FindByGenre request, CancellationToken cancellationToken)
        {
            return await _repository.FindByGenre(request.GenreId);
        }
    }
}

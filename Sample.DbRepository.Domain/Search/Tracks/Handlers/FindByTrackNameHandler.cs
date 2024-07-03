using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Search.Tracks.Requests;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Tracks.Handlers
{
    internal class FindByTrackNameHandler : IRequestHandler<FindByTrackName, IEnumerable<AlbumTrack>>
    {
        private readonly ITrackRepository _repository;

        public FindByTrackNameHandler(ITrackRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<IEnumerable<AlbumTrack>> Handle(FindByTrackName request, CancellationToken cancellationToken)
        {
            return await _repository.FindByTrackName(request.Name);
        }
    }
}

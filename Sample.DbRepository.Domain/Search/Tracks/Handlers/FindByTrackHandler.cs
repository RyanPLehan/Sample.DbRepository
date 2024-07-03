using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Search.Tracks.Requests;
using Sample.DbRepository.Domain.Search.Models;

namespace Sample.DbRepository.Domain.Search.Tracks.Handlers
{
    internal class FindByTrackHandler : IRequestHandler<FindByTrack, AlbumTrack>
    {
        private readonly ITrackRepository _repository;

        public FindByTrackHandler(ITrackRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<AlbumTrack> Handle(FindByTrack request, CancellationToken cancellationToken)
        {
            return await _repository.FindByTrack(request.TrackId);
        }
    }
}

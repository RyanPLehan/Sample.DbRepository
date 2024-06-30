using System;
using System.Threading.Tasks;
using MediatR;
using Sample.DbRepository.Domain.Management.Tracks.Requests;
using Sample.DbRepository.Domain.Management.Models;

namespace Sample.DbRepository.Domain.Management.Tracks.Handlers
{
    internal class FetchHandler : IRequestHandler<Fetch, Track>
    {
        private readonly ITrackRepository _repository;

        public FetchHandler(ITrackRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<Track> Handle(Fetch request, CancellationToken cancellationToken)
        {
            return await _repository.Get(request.Id);
        }

    }
}
